using ConsommiTounsi.Models.User;
using ConsommiTounsi.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace ConsommiTounsi.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            HttpClient httpClient = HttpClientBuilder.Get();
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = httpClient.PostAsJsonAsync<User>("users", user).Result;
                response.EnsureSuccessStatusCode();
                string message = response.Content.ReadAsStringAsync().Result;
                if (message.Equals("\"SUCCESS\""))
                    return Redirect("Login");
                else if (message.Equals("\"USERNAME_ALREADY_EXISTS\""))
                    ModelState.AddModelError("username", "Username already exists");
                else if (message.Equals("\"EMAIL_ALREADY_EXISTS\""))
                    ModelState.AddModelError("email", "Email already exists");
            }
            return View(user);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            HttpClient httpClient = HttpClientBuilder.Get();
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "multipart/form-data");
            var loginForm = new MultipartFormDataContent
            {
                { new StringContent(user.username), "username" },
                { new StringContent(user.password), "password" }
            };
            HttpResponseMessage response = httpClient.PostAsync("http://localhost:8080/api/login", loginForm).Result;
            response.EnsureSuccessStatusCode();
            User u = response.Content.ReadAsAsync<User>().Result;
            if (u != null)
            {
                Session["user"] = u;
                Session["api-cookie"] = response.Headers.GetValues("Set-Cookie").First().Split(';')[0];
                if (u.type == UserType.ADMIN)
                    return RedirectToAction("Index", "Admin");
                else if (u.type == UserType.DELIVERER)
                    return RedirectToAction("Index", "Deliverer");
                else
                    return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("password", "Wrong username or password");
            return View(user);
        }

        public ActionResult Logout()
        {
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            httpClient.GetAsync("logout");
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Details()
        {
            User user = (User)Session["user"];
            if (user == null)
                return Redirect("Login");
            return View(user);
        }

        public ActionResult Edit()
        {
            User user = (User)Session["user"];
            if (user == null)
                return Redirect("Login");
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            User u = (User)Session["user"];
            if (u == null)
                return Redirect("Login");
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            user.id = u.id;
            HttpResponseMessage response = httpClient.PostAsJsonAsync<User>("customer/users/edit", user).Result;
            response.EnsureSuccessStatusCode();
            string message = response.Content.ReadAsStringAsync().Result;
            if (message.Equals("\"SUCCESS\""))
            {
                user.type = u.type;
                Session["user"] = user;
                return Redirect("Details");
            }
            else if (message.Equals("\"USERNAME_ALREADY_EXISTS\""))
                ModelState.AddModelError("username", "Username already exists");
            else if (message.Equals("\"EMAIL_ALREADY_EXISTS\""))
                ModelState.AddModelError("email", "Email already exists");
            return View(user);
        }

        public ActionResult Password()
        {
            User user = (User)Session["user"];
            if (user == null)
                return Redirect("Login");
            return View();
        }

        [HttpPost]
        public ActionResult Password(PasswordEdit password)
        {
            User user = (User)Session["user"];
            if (user == null)
                return Redirect("Login");
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            string url = "customer/users/" + user.id + "/password";
            HttpResponseMessage response = httpClient.PostAsJsonAsync<PasswordEdit>(url, password).Result;
            response.EnsureSuccessStatusCode();
            string message = response.Content.ReadAsStringAsync().Result;
            if (message.Equals("\"SUCCESS\""))
                return Redirect("Details");
            ModelState.AddModelError("oldPassword", "Wrong password");
            return View(password);
        }

        public ActionResult Addresses()
        {
            User user = (User)Session["user"];
            if (user == null)
                return Redirect("Login");
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            string url = "customer/users/" + user.id + "/addresses";
            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            ViewBag.addresses = response.Content.ReadAsAsync<IEnumerable<Address>>().Result;
            return View();
        }

        [HttpPost]
        public ActionResult Addresses(Address address)
        {
            User user = (User)Session["user"];
            if (user == null)
                return Redirect("Login");
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            string url = "customer/addresses/" + user.id;
            HttpResponseMessage postResponse = httpClient.PostAsJsonAsync<Address>(url, address).Result;
            postResponse.EnsureSuccessStatusCode();
            url = "customer/users/" + user.id + "/addresses";
            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            ViewBag.addresses = response.Content.ReadAsAsync<IEnumerable<Address>>().Result;
            return View();
        }

        public ActionResult EditAddress(long id)
        {
            User user = (User)Session["user"];
            if (user == null)
                return RedirectToAction("Login", "User");
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            string url = "customer/addresses/" + id;
            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            return View(response.Content.ReadAsAsync<Address>().Result);
        }

        [HttpPost]
        public ActionResult EditAddress(Address address)
        {
            User user = (User)Session["user"];
            if (user == null)
                return RedirectToAction("Login", "User");
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            HttpResponseMessage response = httpClient.PostAsJsonAsync<Address>("customer/addresses/edit", address).Result;
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Addresses", "User");
            return View(address);
        }

        public ActionResult DeleteAddress(long id)
        {
            User user = (User)Session["user"];
            if (user == null)
                return Redirect("Login");
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            string url = "customer/addresses/" + id;
            httpClient.DeleteAsync(url);
            return RedirectToAction("Addresses", "User");
        }

        public ActionResult ManageUsers()
        {
            User user = (User)Session["user"];
            if (user == null)
                return Redirect("Login");
            if (user.type != UserType.ADMIN)
                return RedirectToAction("Index", "Home");
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            HttpResponseMessage response = httpClient.GetAsync("customer/users").Result;
            response.EnsureSuccessStatusCode();
            return View(response.Content.ReadAsAsync<IEnumerable<User>>().Result);
        }

        public ActionResult Type(long id, UserType type)
        {
            User user = (User)Session["user"];
            if (user == null)
                return RedirectToAction("Login", "User");
            if (user.type != UserType.ADMIN)
                return RedirectToAction("Index", "Home");
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            string url = "admin/users/" + id + "/" + type;
            HttpResponseMessage response = httpClient.PutAsync(url, null).Result;
            response.EnsureSuccessStatusCode();
            if (user.id == id)
            {
                user.type = type;
                Session["user"] = user;
            }
            return RedirectToAction("ManageUsers", "User");
        }

        public ActionResult Delete(long id)
        {
            User user = (User)Session["user"];
            if (user == null)
                return RedirectToAction("Login", "User");
            if (user.type != UserType.ADMIN)
                return RedirectToAction("Index", "Home");
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            string url = "admin/users/" + id;
            HttpResponseMessage response = httpClient.DeleteAsync(url).Result;
            response.EnsureSuccessStatusCode();
            if (user.id == id)
                return RedirectToAction("Logout", "User");
            return RedirectToAction("ManageUsers", "User");
        }
    }
}