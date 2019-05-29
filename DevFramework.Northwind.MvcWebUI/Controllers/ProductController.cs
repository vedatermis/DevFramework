using System.Web.Mvc;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Entities.Concrete;

namespace DevFramework.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };

            return View(model);
        }

        public string Add()
        {
            _productService.Add(new Product { CategoryId=1, ProductName = "Gsm", QuantityPerUnit = "1", UnitPrice = 25});
            return "Added";
        }

        public string AddUpdate()
        {
            _productService.TransactionalOperation(
                new Product { CategoryId = 1, ProductName = "Computer", QuantityPerUnit = "1", UnitPrice = 25 },
                new Product { CategoryId = 1, ProductName = "Computer 2", QuantityPerUnit = "1", UnitPrice = 10 }
                );

            return "Done";
        }
    }
}