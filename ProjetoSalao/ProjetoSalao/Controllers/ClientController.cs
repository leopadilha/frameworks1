using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoSalao.Models;
using ProjetoSalao.Repository.ClientRepository;

namespace ProjetoSalao.Controllers
{
    public class ClientController : Controller
    { 
        private readonly IClientRepository _clientRepository;
    
        public ClientController(IClientRepository client)
        {
            _clientRepository = client;
        }

        public IActionResult Index()
        {

            var clientes = _clientRepository.ListAll();
            return View(clientes);

        }

        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(Client client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_clientRepository.FindByCpf(client.Cpf))
                    {
                        TempData["MessageCpfExists"] = "Cpf já cadastrado no sistema";
                    }
                    else
                    {
                        client.Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(client.Name.ToLower());
                        _clientRepository.Save(client);
                        TempData["MessageSucess"] = "Cliente Cadastrado com sucesso";
                        return RedirectToAction("create");


                    }               
                }
                return View(client);
            }
            catch(Exception ex)
            {
                TempData["MessageError"] = "Não foi possível cadastrar o cliente";
                return RedirectToAction("create");

            }
        }

        public ActionResult Edit(int id)
        {

            Client client = _clientRepository.FindById(id);
            return View(client);
        }

        [HttpPost]
        public IActionResult UpdateClient(Client client)
        {
            if (ModelState.IsValid)
            {
                if (_clientRepository.FindByCpfAndDifferentId(client.Cpf, client.Id))
                {
                    TempData["MessageCpfExists"] = "Cpf já cadastrado no sistema";
                }
                else
                {
                    _clientRepository.UpdateClient(client);
                    TempData["MessageSucess"] = "Cliente alterado com sucesso";
                    return RedirectToAction("Edit");
                }
                
            }
            return View("Edit", client);
        }
       
       public ActionResult Confirm(int id)
        {
            Client client = _clientRepository.FindById(id);
            return PartialView(client);
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            try
            {
                Client client = _clientRepository.FindById(id);
                _clientRepository.Remove(client);
                return RedirectToAction("index");
            }
           catch(Exception e)
            {
                TempData["MessageError"] = "O cliente não pode ser excluido, pois possui agendamentos.";
                return RedirectToAction("index");
            }
        }

        public ActionResult Details(int id)
        {
            Client client = _clientRepository.FindById(id);
            return PartialView(client);
        }


    }
}

