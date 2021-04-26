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
    public class CagnotteController : Controller
    {
        // GET: Cagnotte
        public ActionResult CagnotteList()
        {
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            HttpResponseMessage response = httpClient.GetAsync("Cagnottes").Result;
            response.EnsureSuccessStatusCode();
            return View(response.Content.ReadAsAsync<IEnumerable<Cagnotte>>().Result);
        }

     
        public ActionResult CagnotteListAdmin()
        {
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            HttpResponseMessage response = httpClient.GetAsync("Cagnottes").Result;
            response.EnsureSuccessStatusCode();
            return View(response.Content.ReadAsAsync<IEnumerable<Cagnotte>>().Result);
        }

        
    
        public ActionResult Bet(long cagnotteId)
        {
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            User user = (User)Session["user"];
            if (user == null) {
                return RedirectToAction("Login", "User");

            }
            else
            {
                long userId = user.id;
                string url = "bet/" + userId + "/" + cagnotteId;
                HttpResponseMessage response = httpClient.PostAsJsonAsync<Ticket>(url, new Ticket()).Result;
                response.EnsureSuccessStatusCode();
                return RedirectToAction("CagnotteList", "Cagnotte");
            }    
        }
       

        public ActionResult AddCagnotte()
        {
            HttpClient httpClient = HttpClientBuilder.Get();
       
            HttpResponseMessage response = httpClient.PostAsJsonAsync<Cagnotte>("AddCagnotte", new Cagnotte()).Result;
            response.EnsureSuccessStatusCode();
            return RedirectToAction("CagnotteListAdmin", "Cagnotte");
        }

        // GET: Cagnotte/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cagnotte/Edit/5
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

        // GET: Cagnotte/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cagnotte/Delete/5
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
