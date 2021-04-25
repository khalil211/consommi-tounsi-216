using ConsommiTounsi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ConsommiTounsi.Models.Evenement;

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
        public ActionResult SelectedEvents(long id)
        {
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            string url = "SelectedEvents/" + id;
            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            return View(response.Content.ReadAsAsync<IEnumerable<Evenement>>().Result);
        }

        // GET: Evenement/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Evenement/Create
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

        // GET: Evenement/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Evenement/Edit/5
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
