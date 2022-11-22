using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoSalao.Models;
using ProjetoSalao.Repository.ProductRepository;
using ProjetoSalao.Repository.ProviderRepository;

namespace ProjetoSalao.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductRepository _productRepository;
        private readonly IProviderRepository _providerRepository;   
        public ProductController(IProductRepository product, IProviderRepository provider)
        {
            _productRepository = product;
            _providerRepository = provider;
        }
      
        public ActionResult Index()
        {
            ViewBag.Product = _productRepository.ListAll();
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public IActionResult Create()
        {
            var productViewModel = new ProductFormViewModel();
            productViewModel.Providers = _providerRepository.ListAll();
            return View(productViewModel);
        }

        [HttpPost]
        
        public ActionResult Create(Product product)
        {
            _productRepository.Save(product);
            return RedirectToAction("index");
        }

        public ActionResult Edit(int id)
        {
            Product product = _productRepository.FindById(id);

            var productViewModel = new ProductFormViewModel();
            productViewModel.Product = product;
            productViewModel.Providers = _providerRepository.ListAll();
            return View(productViewModel);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            _productRepository.Edit(product);
            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            Product product = _productRepository.FindById(id);
            return PartialView(product);
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            Product product = _productRepository.FindById(id);
            _productRepository.Remove(product);
            return RedirectToAction("index");
        }
    }
}
