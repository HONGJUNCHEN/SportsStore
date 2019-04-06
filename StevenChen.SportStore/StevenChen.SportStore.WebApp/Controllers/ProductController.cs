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

        public int PageSize = 2;

        public ProductController(IProductsRepository productsRepository)
        {
            this.repository = productsRepository;
        }
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult List(int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository
            .Products
            .OrderBy(p => p.ProductId)
            .Skip((page - 1) * PageSize)
            .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Products.Count()
                }
            };
            return View(model);
        }
    }
}