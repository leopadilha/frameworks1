using Microsoft.AspNetCore.Mvc;
using ProjetoSalao.Models;
using ProjetoSalao.Repository.ClientRepository;
using ProjetoSalao.Repository.SchedulingRepository;
using System.Diagnostics;

namespace ProjetoSalao.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly IClientRepository _clienteRepository;
        private readonly ISchedulingRepository _agendamentoRepository;

        public HomeController(IClientRepository clientRepository,ISchedulingRepository schedulingRepository)
        {
            _clienteRepository = clientRepository;
            _agendamentoRepository = schedulingRepository;
        }

        public IActionResult Index()
        {
            var dataAtual = DateTime.Today;
            Console.WriteLine(dataAtual);
            
            var schedulings = _agendamentoRepository.listSchedulingDay(dataAtual);
           
            return View(schedulings);
        }

      
        public IActionResult Privacy()
        {
            return View();
        }

    }
}