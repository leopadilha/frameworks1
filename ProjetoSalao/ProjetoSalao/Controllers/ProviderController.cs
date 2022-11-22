using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoSalao.Models;
using ProjetoSalao.Repository.ProviderRepository;

namespace ProjetoSalao.Controllers
{
    public class ProviderController : Controller
    {
        private readonly IProviderRepository _providerRepository;

        public ProviderController(IProviderRepository provider)
        {
            _providerRepository = provider;
        }
     
        public ActionResult Index()
        {
            var providers = _providerRepository.ListAll();
            return View(providers);
        }

        public ActionResult Details(int id)
        {
            var provider = _providerRepository.FindById(id);
            return PartialView(provider);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Provider provider)
        {
            if (ModelState.IsValid)
            {
                _providerRepository.Save(provider);
                return RedirectToAction("index");
            }
                
            return View(provider);
        }

        public ActionResult Edit(int id)
        {
            var provider = _providerRepository.FindById(id);
            return View(provider);
        }

        [HttpPost]
        public IActionResult Edit(Provider provider)
        {
            if (ModelState.IsValid)
            {
                _providerRepository.Edit(provider);
                return RedirectToAction("index");
            }
            return View("Edit", provider);
                
        }

        public ActionResult Delete(int id)
        {
            Provider provider = _providerRepository.FindById(id);
            return PartialView(provider);
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            try
            {
                Provider provider = _providerRepository.FindById(id);
                _providerRepository.Remove(provider);
                return RedirectToAction("index");
            }
            catch(Exception e)
            {
                TempData["MessageError"] = "Não foi possível deletar o fornecedor, pois possui produtos vinculados.";
                return RedirectToAction("index");
            }
           
        }
    }
}
