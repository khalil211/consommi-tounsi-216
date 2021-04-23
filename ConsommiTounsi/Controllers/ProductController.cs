﻿using ConsommiTounsi.Models.Payment;
using ConsommiTounsi.Models.Products;
using ConsommiTounsi.Models.User;
using ConsommiTounsi.Models.ViewModels;
using ConsommiTounsi.Repositories.Payment;
using ConsommiTounsi.Repositories.Product;
using ConsommiTounsi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ConsommiTounsi.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IProductRepository productRepository;
        private readonly ICartRepository cartRepository;


        public ProductController(ICategoryRepository categoryRepository,
                                IProductRepository productRepository,
                              ICartRepository cartRepository)
        {
            this.categoryRepository = categoryRepository;
            this.productRepository = productRepository;
            this.cartRepository = cartRepository;
        }

        // GET: Product
       
        public async Task<ActionResult> Index()
        {
            var categories = await categoryRepository.Get();
            var products = await productRepository.Get();


            Cart cart = null;
            var user = Session["user"] as User;
            if (user != null)
            {
                var response = await cartRepository.Get(1);
                cart = response.Body;
            }


            var homeViewModel = new ProductIndexViewModel()
            {
                Cart = cart,
                Categories = categories,
                Products = products
            };

            return View(homeViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product pro)
        {
            HttpClient httpClient = HttpClientBuilder.Get();
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = httpClient.PostAsJsonAsync<Product>("products/", pro).Result;
                response.EnsureSuccessStatusCode();

            }
            return View(pro);
        }
}
}