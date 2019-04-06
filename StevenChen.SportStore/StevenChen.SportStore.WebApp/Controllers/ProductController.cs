using StevenChen.SportStore.Domain.Abstract;
using StevenChen.SportStore.WebApp.Models;
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

        public int PageSize = 5;

        public ProductController(IProductsRepository productsRepository)
        {
            this.repository = productsRepository;
        }
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult List(string category, int page = 1)
        {
            var categoryProducts = repository
                .Products
                .Where(p => category == null || p.Category == category);

            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = categoryProducts
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = categoryProducts.Count()
                },

                CurrentCategory = category
            };

            return View(model);
        }
       
    }
}