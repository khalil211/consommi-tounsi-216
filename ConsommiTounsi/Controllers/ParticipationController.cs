using ConsommiTounsi.Models.Evenement;
using ConsommiTounsi.Models.User;
using ConsommiTounsi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ConsommiTounsi.Controllers
{
    public class ParticipationController : Controller
    {
        // GET: Participation
        public ActionResult ParticipationsListAdmin()
        {
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            HttpResponseMessage response = httpClient.GetAsync("Participations").Result;
            response.EnsureSuccessStatusCode();
            return View(response.Content.ReadAsAsync<IEnumerable<Participation>>().Result);
        }

        // GET: Participation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

 
        public ActionResult Participé(long EvId)
        {
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            User user = (User)Session["user"];
            if (user == null)
            {
                return RedirectToAction("Login", "User");

            }
            else
            {
                long userId = user.id;
                string url = "Participation/" + userId + "/" + EvId;
                HttpResponseMessage response = httpClient.PostAsJsonAsync<Participation>(url, new Participation()).Result;
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Index", "Evenement");
            }
        }

        // POST: Participation/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Participation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Participation/Edit/5
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

        // GET: Participation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Participation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
