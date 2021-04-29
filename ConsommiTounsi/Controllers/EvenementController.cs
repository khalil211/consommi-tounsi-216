using ConsommiTounsi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ConsommiTounsi.Models.Evenement;
using ConsommiTounsi.Models.User;

namespace ConsommiTounsi.Controllers
{
    public class EvenementController : Controller
    {
        // GET: Evenement
        public ActionResult Index()
        {
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            HttpResponseMessage response = httpClient.GetAsync("Events").Result;
            response.EnsureSuccessStatusCode();
            return View(response.Content.ReadAsAsync<IEnumerable<Evenement>>().Result);
        }
    
        public ActionResult EventListAdmin()
        {
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            HttpResponseMessage response = httpClient.GetAsync("Events").Result;
            response.EnsureSuccessStatusCode();
            return View(response.Content.ReadAsAsync<IEnumerable<Evenement>>().Result);
        }
        

         public ActionResult EventDisponible()
        {
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            HttpResponseMessage response = httpClient.GetAsync("DisponibleEvent").Result;
            response.EnsureSuccessStatusCode();
            return View(response.Content.ReadAsAsync<IEnumerable<Evenement>>().Result);
        }
        public ActionResult LastEvents()
        {
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            HttpResponseMessage response = httpClient.GetAsync("LastEvents").Result;
            response.EnsureSuccessStatusCode();
            return View(response.Content.ReadAsAsync<IEnumerable<Evenement>>().Result);
        }
        public ActionResult SelectedEvents()
        {
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            User user = (User)Session["user"];
            if (user == null)
            {
                return RedirectToAction("Login", "User");

            }
   
            long userId = user.id;
            string url = "SelectedEvents/" + userId;
            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            return View(response.Content.ReadAsAsync<IEnumerable<Evenement>>().Result);
        }

        public ActionResult EvenementById(int id)
        {
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            string url = "event/" + id;
            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            return View(response.Content.ReadAsAsync<Evenement>().Result);
        }

   
        public ActionResult CreateEvent()
        {
            return View();
        }

        // POST: Evenement/Create
        [HttpPost]
     
        public ActionResult CreateEvent(Evenement evenement)
        {
            HttpClient httpClient = HttpClientBuilder.Get();
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = httpClient.PostAsJsonAsync<Evenement>("AddEvent", evenement).Result;
                response.EnsureSuccessStatusCode();

            }
            return View(evenement);
        }

        [HttpPost]
        public ActionResult Donate(int EvId , Participation participation)
        {
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            User user = (User)Session["user"];
            if (user == null)
            {
                return RedirectToAction("Login", "User");

            }
            long userId = user.id;
            string url = "donate/" + userId +" /" + EvId;
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = httpClient.PostAsJsonAsync<Participation>(url, participation).Result;
                response.EnsureSuccessStatusCode();
            }
            return View(participation);
        }

      
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(long id)
        {
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            string url = "deleteEvent/" + id;
            HttpResponseMessage response = httpClient.DeleteAsync(url).Result;
            response.EnsureSuccessStatusCode();
            return RedirectToAction("EventListAdmin", "Evenement");
        }

      
    }
}
