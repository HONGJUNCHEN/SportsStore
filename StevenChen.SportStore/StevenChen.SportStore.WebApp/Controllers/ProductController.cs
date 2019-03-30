using StevenChen.SportStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StevenChen.SportStore.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository repository;
        public ProductController(IProductsRepository productsRepository)
        {
            this.repository = productsRepository;
        }
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult List()
        {
            return View(repository.Products);
        }
    }
}