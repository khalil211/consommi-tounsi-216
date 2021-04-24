using ConsommiTounsi.Models.Products;
using ConsommiTounsi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ConsommiTounsi.Controllers
{
    public class CategorieController : Controller
    {
        // GET: Categorie
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            HttpClient httpClient = HttpClientBuilder.Get();
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = httpClient.PostAsJsonAsync<Category>("categories", category).Result;
                response.EnsureSuccessStatusCode();

            }
            return View(category);
        }
    }
}