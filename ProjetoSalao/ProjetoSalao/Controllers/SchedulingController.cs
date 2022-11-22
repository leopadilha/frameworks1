using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoSalao.Models;
using ProjetoSalao.Repository.ClientRepository;
using ProjetoSalao.Repository.SchedulingRepository;
using ProjetoSalao.Repository.ServiceRepository;

namespace ProjetoSalao.Controllers
{
    public class SchedulingController : Controller
    {
        private readonly ISchedulingRepository _schedulingRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IServiceRepository _serviceRepository;

        public SchedulingController(ISchedulingRepository scheduling, IClientRepository client, IServiceRepository service)
        {
            _schedulingRepository = scheduling;
            _clientRepository = client;
            _serviceRepository = service;
        }
        public ActionResult Index()
        {
            var schedulings = _schedulingRepository.ListAll();
            return View(schedulings);
        }
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Create()
        {
            var schedulingViewModel = new SchedulingFormViewModel();
            schedulingViewModel.Clients = _clientRepository.ListAll();
            schedulingViewModel.Services = _serviceRepository.ListAll();
            return View(schedulingViewModel);
        }

      
        [HttpPost]
        public ActionResult Create(Scheduling scheduling)
        {

            if (_schedulingRepository.findByDateAndHour(scheduling.Date, scheduling.Hour))
            {
                TempData["MessageExists"] = "Já existe um agendamento para essa data e hora";
                return RedirectToAction("Create");
            }
            else
            {
                _schedulingRepository.Save(scheduling);
                return RedirectToAction("index");
            }   
            
        }

        // GET: SchedulingController/Edit/5
        public ActionResult Edit(int id)
        {
            Scheduling scheduling = _schedulingRepository.FindById(id);

            var schedulingFormViewModel = new SchedulingFormViewModel();
            schedulingFormViewModel.Scheduling = scheduling;
            schedulingFormViewModel.Clients = _clientRepository.ListAll();
            schedulingFormViewModel.Services = _serviceRepository.ListAll();
            return View(schedulingFormViewModel);
        }

        [HttpPost]
        public ActionResult Edit(Scheduling scheduling)
        {
            if (_schedulingRepository.FindByDateAndDifferentId(scheduling.Date, scheduling.Hour, scheduling.Id))
            {
                TempData["MessageExists"] = "Já existe um agendamento para essa data e hora";
                return RedirectToAction("Edit");
            }
            else
            {
                _schedulingRepository.Edit(scheduling);
                return RedirectToAction("index");
            }
            
        }

        public ActionResult Delete(int id)
        {
            Scheduling scheduling = _schedulingRepository.FindById(id);
            return PartialView(scheduling);
        }

        [HttpPost]
        
        public ActionResult Remove(int id)
        {
            Scheduling scheduling = _schedulingRepository.FindById(id);
            _schedulingRepository.Remove(scheduling);
            return RedirectToAction("index");
        }

        public ActionResult Receipt(int id)
        {
            var scheduling = _schedulingRepository.FindById(id);
            return PartialView(scheduling);
        }
    }
}
