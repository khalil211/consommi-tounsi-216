using ConsommiTounsi.Models.Payment;
using ConsommiTounsi.Models.Products;
using ConsommiTounsi.Models.User;
using ConsommiTounsi.Models.ViewModels;
using ConsommiTounsi.Repositories.Payment;
using ConsommiTounsi.Repositories.Product;
using ConsommiTounsi.Utils;
using System;
using System.Collections.Generic;
using System.IO;
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
            Cart cart = await _getCart();

            var homeViewModel = new ProductIndexViewModel()
            {
                Cart = cart,
                Categories = categories,
                Products = products
            };

            return View(homeViewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var product = await productRepository.Get(id);

            if (product == null)
            {
                return View("~/Views/Shared/NotFound.cshtml");
            }


            var categories = await categoryRepository.Get();
            Cart cart = await _getCart();

            var model = new ProductDetailsViewModel()
            {
                Cart = cart,
                Product = product,
                Categories = categories
            };

            return View(model);
        }


        private async Task<Cart> _getCart()
        {
            Cart cart = null;
            var user = Session["user"] as User;
            if (user != null)
            {
                var response = await cartRepository.GetAsync((int)user.id);
                cart = response.Body;
            }

            return cart;
        }


        public ActionResult Indexback()
        {
            HttpClient httpClient = HttpClientBuilder.Get();
            HttpResponseMessage response = httpClient.GetAsync("products").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }

            return View();
        }

        public ActionResult Product(long id)
        {
            return DisplayProduct(id);
        }

        private ActionResult DisplayProduct(long id)
        {
            HttpClient httpClient = HttpClientBuilder.Get();
            HttpResponseMessage response = httpClient.GetAsync("products/" + id).Result;
            response.EnsureSuccessStatusCode();
            Product product = response.Content.ReadAsAsync<Product>().Result;
            string url = "products/" + id;
            response = httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();



            ViewBag.product = product;
            response = httpClient.GetAsync("products/" + id).Result;
            response.EnsureSuccessStatusCode();

            ModelState.Clear();
            return View("Product");
        }


        [HttpPost]
        public ActionResult AddComment(Comment comment, long id)
        {
            User user = (User)Session["user"];
            if (user == null)
                return Redirect("Index");
            Comment p = new Comment()
            {

                content = comment.content
            };


            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            string url = "customer/comments/" + user.id + "/" + id;
            HttpResponseMessage response = httpClient.PostAsJsonAsync<Comment>(url, p).Result;
            response.EnsureSuccessStatusCode();

            return RedirectToAction("Details", new { id = id });
        }

        [ChildActionOnly]
        public ActionResult AddComment()
        {

            User user = (User)Session["user"];
            if (user == null)
                return Redirect("Index");

            return PartialView("_AddComment");

        }

        public ActionResult Rate(int id, int rating)
        {
            User user = (User)Session["user"];
            if (user != null)
            {
                HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
                string url = "customer/" + user.id + "/" + "products/" + id + "/" + "ratings" + "/" + rating;
                httpClient.PutAsync(url, null);
            }
            return RedirectToAction("Details", new { id = id });
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product pro, HttpPostedFileBase file)
        {

            Product p = new Product();
            //{
              //  Picture = null
            //};
            if (file != null && file.ContentLength > 0)
            {
                if (file.FileName.EndsWith(".jpg") || file.FileName.EndsWith(".png") || file.FileName.EndsWith(".gif"))
                {
                    string filename = file.FileName;
                    file.SaveAs(Path.Combine(Server.MapPath("~/Content/Product/"), filename));
                    p.Picture = filename;
                }
                else
                {
                    ModelState.AddModelError("medias", "Must be a jpg, png or gif.");
                    // return DisplayProduct();
                }
            }

            HttpClient httpClient = HttpClientBuilder.Get();
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = httpClient.PostAsJsonAsync<Product>("products/", pro).Result;
                response.EnsureSuccessStatusCode();

            }
            return View(pro);
        }



        public JsonResult LikeComment(long id, bool liked)
        {
             User user = (User)Session["user"];
            if (user == null)
            return Json("failed", JsonRequestBehavior.AllowGet);
             HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
             string url = "customer/comments/" + id + "/" + user.id + "/" + liked;
            HttpResponseMessage response = httpClient.PutAsync(url, null).Result;
            if (!response.IsSuccessStatusCode)
            return Json("failed", JsonRequestBehavior.AllowGet);
            return Json("success", JsonRequestBehavior.AllowGet);
           

        }

        public ActionResult Delete(long id)
        {
            HttpClient httpClient = HttpClientBuilder.Get(Session["api-cookie"]);
            string url = "products/" + id;
            HttpResponseMessage response = httpClient.DeleteAsync(url).Result;
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Indexback");
        }


        
                   
    }
}