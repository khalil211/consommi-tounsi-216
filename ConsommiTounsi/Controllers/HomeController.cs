using ConsommiTounsi.Models.Payment;
using ConsommiTounsi.Models.User;
using ConsommiTounsi.Models.ViewModels;
using ConsommiTounsi.Repositories.Payment;
using ConsommiTounsi.Repositories.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ConsommiTounsi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly ICartRepository cartRepository;

        public HomeController(ICategoryRepository categoryRepository,
                              ICartRepository cartRepository)
        {
            this.categoryRepository = categoryRepository;
            this.cartRepository = cartRepository;
        }

        public async Task<ActionResult> Index()
        {
            var categories = await categoryRepository.GetAsync();

            return View(categories);
        }

        [ChildActionOnly]
        public ActionResult RenderSearchCategories()
        {
            var categories = this.categoryRepository.Get();
            return PartialView("_SearchCategories", categories);
        }
    }
}