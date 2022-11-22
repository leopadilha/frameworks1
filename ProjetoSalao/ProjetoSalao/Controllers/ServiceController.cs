using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoSalao.Models;
using ProjetoSalao.Repository.ServiceRepository;

namespace ProjetoSalao.Controllers
{
    public class ServiceController : Controller
    {
        
        private readonly IServiceRepository _serviceRepository; 
        public ServiceController(IServiceRepository service)
        {
            _serviceRepository = service;
        }

        
        public IActionResult Index()
        {

            ViewBag.Services = _serviceRepository.ListAll();
            return View();

        }

        public ActionResult Details(int id)
        {
            return View();
        }

  
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Service service)
        {
            if (ModelState.IsValid)
            {
                _serviceRepository.Save(service);
                return RedirectToAction("index");
            }
                
            return View(service);
        }

        public ActionResult Edit(int id)
        {
            Service service = _serviceRepository.FindById(id);
            return View(service);
        }

        [HttpPost]
        public IActionResult Edit(Service service)
        {
            if (ModelState.IsValid)
            {
                _serviceRepository.Edit(service);
                return RedirectToAction("index");
            }

            return View("Edit",service);
        }

        public ActionResult Delete(int id)
        {
            Service service = _serviceRepository.FindById(id);
            return PartialView(service);
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            try
            {
                Service service = _serviceRepository.FindById(id);
                _serviceRepository.Remove(service);
                return RedirectToAction("index");
            }
            catch(Exception e )
            {
                TempData["MessageError"] = "O serviço não pode ser excluido, pois possui agendamentos vinculados a este serviço.";
                return RedirectToAction("index");
            }
          
        }

    }
}
