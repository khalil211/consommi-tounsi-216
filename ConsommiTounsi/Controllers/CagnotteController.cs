using ConsommiTounsi.Models.Evenement;
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

        // GET: Cagnotte/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cagnotte/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cagnotte/Create
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
