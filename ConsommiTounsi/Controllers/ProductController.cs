using ConsommiTounsi.Models.Payment;
using ConsommiTounsi.Models.User;
using ConsommiTounsi.Models.ViewModels;
using ConsommiTounsi.Repositories.Payment;
using ConsommiTounsi.Repositories.Product;
using System;
using System.Collections.Generic;
using System.Linq;
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
                var response = await cartRepository.Get((int)user.id);
                cart = response.Body;
            }

            return cart;
        }

    }
}