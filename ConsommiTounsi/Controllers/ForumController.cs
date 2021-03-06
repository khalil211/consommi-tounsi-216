using ConsommiTounsi.Models.Forum;
using ConsommiTounsi.Models.User;
using ConsommiTounsi.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ConsommiTounsi.Controllers
{
    public class ForumController : Controller
    {
        public ActionResult Index(int page = 1, string sort = "date")
        {
            HttpClient httpClient = HttpClientBuilder.Get();
            string url = "topics?sort="+sort;
            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            List<Topic> topics = response.Content.ReadAsAsync<List<Topic>>().Result;
            int totalPages = (topics.Count + 9) / 10;
            if (page < 1)
                page = totalPages;
            else if (page > totalPages)
                page = 1;
            ViewBag.topics = topics.Skip(10 * (page - 1)).Take(10);
            ViewBag.page = page;
            ViewBag.totalPages = totalPages;
            ViewBag.sort = sort;
            response = httpClient.GetAsync("topics/users").Result;
            response.EnsureSuccessStatusCode();
            ViewBag.users = response.Content.ReadAsAsync<List<User>>().Result.Take(10);
            return View();
        }

        [HttpPost]
        public ActionResult Index(Topic topic)
        {
            User user = (User)Session["user"];
            if (user == null)
                return Redirect("Index");
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            string url = "customer/topics/" + user.id;
            HttpResponseMessage response = httpClient.PostAsJsonAsync<Topic>(url, topic).Result;
            response.EnsureSuccessStatusCode();
            topic = response.Content.ReadAsAsync<Topic>().Result;
            return RedirectToAction("Topic", new { id = topic.id });
        }

        public ActionResult Topic(long id, int page = 1, string sort = "date")
        {
            return DisplayTopic(id, page, sort);
        }

        [HttpPost]
        public ActionResult Topic(Post post, HttpPostedFileBase file, long id, int page = 1, string sort = "date")
        {
            User user = (User)Session["user"];
            if (user == null)
                return Redirect("Index");
            Post p = new Post()
            {
                content = post.content,
                medias = null
            };
            if (file != null && file.ContentLength > 0)
            {
                if (file.FileName.EndsWith(".jpg") || file.FileName.EndsWith(".png") || file.FileName.EndsWith(".gif"))
                {
                    string filename = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + file.FileName;
                    file.SaveAs(Path.Combine(Server.MapPath("~/Content/Forum/"), filename));
                    p.medias = filename;
                }
                else
                {
                    ModelState.AddModelError("medias", "Must be a jpg, png or gif.");
                    return DisplayTopic(id, page, sort);
                }
            }
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            string url = "customer/posts/" + user.id + "/" + id;
            HttpResponseMessage response = httpClient.PostAsJsonAsync<Post>(url, p).Result;
            response.EnsureSuccessStatusCode();
            return DisplayTopic(id, page, sort);
        }

        private ActionResult DisplayTopic(long id, int page, string sort)
        {
            HttpClient httpClient = HttpClientBuilder.Get();
            HttpResponseMessage response = httpClient.GetAsync("topics/" + id).Result;
            response.EnsureSuccessStatusCode();
            Topic topic = response.Content.ReadAsAsync<Topic>().Result;
            string url = "topics/" + id + "/posts?sort=" + sort;
            response = httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            List<Post> posts = response.Content.ReadAsAsync<List<Post>>().Result;
            int totalPages = (posts.Count + 9) / 10;
            if (page < 1)
                page = totalPages;
            else if (page > totalPages)
                page = 1;
            ViewBag.posts = posts.Skip(10 * (page - 1)).Take(10);
            ViewBag.page = page;
            ViewBag.totalPages = totalPages;
            ViewBag.sort = sort;
            ViewBag.topic = topic;
            response = httpClient.GetAsync("topics/" + id + "/users").Result;
            response.EnsureSuccessStatusCode();
            ViewBag.users = response.Content.ReadAsAsync<List<User>>().Result.Take(10);
            ModelState.Clear();
            return View("Topic");
        }

        public ActionResult Rate(long id, int page, string sort, int value)
        {
            User user = (User)Session["user"];
            if (user != null)
            {
                HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
                string url = "customer/topics/" + id + "/" + user.id + "/" + value;
                httpClient.PutAsync(url, null);
            }
            return RedirectToAction("Topic", "Forum", new { id = id, page = page, sort = sort });
        }

        public JsonResult LikePost(long id, bool liked)
        {
            User user = (User)Session["user"];
            if (user == null)
                return Json("failed", JsonRequestBehavior.AllowGet);
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            string url = "customer/posts/" + id + "/" + user.id + "/" + liked;
            HttpResponseMessage response = httpClient.PutAsync(url, null).Result;
            if (!response.IsSuccessStatusCode)
                return Json("failed", JsonRequestBehavior.AllowGet);
            return Json("success", JsonRequestBehavior.AllowGet);
        }
    }
}