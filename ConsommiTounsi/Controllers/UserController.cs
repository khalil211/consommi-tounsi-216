using ConsommiTounsi.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ConsommiTounsi.Controllers
{
    public class UserController : Controller
    {
        private HttpClient httpClient;

        public UserController()
        {
            httpClient = new HttpClient(new HttpClientHandler() { UseCookies = false });
            httpClient.BaseAddress = new Uri("http://localhost:8080/api/");
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = httpClient.PostAsJsonAsync<User>("users", user).Result;
                response.EnsureSuccessStatusCode();
                string message;
                try
                {
                    message = response.Content.ReadAsStringAsync().Result;
                }
                catch (HttpRequestException e)
                {
                    message = e.Message;
                }

                if (message.Equals("\"SUCCESS\""))
                    return Redirect("Login");
                ViewBag.Message = message;
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
            httpClient.DefaultRequestHeaders.Add("Cookie", (string)Session["api-cookie"]);
            httpClient.GetAsync("lougout");
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}