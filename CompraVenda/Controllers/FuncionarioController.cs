using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompraVenda.Models;
using CompraVenda.ViewModels;

namespace CompraVenda.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: Funcionario
        public List<Funcionario> Funcionarios = new List<Funcionario>
        { 
            new Funcionario {Id = 1, Name = "Alfredo"},
            new Funcionario {Id = 2,Name = "Miranda"}
        };

        public ActionResult Index()
        {
            var viewModel = new FuncionarioIndexViewModel
            {
                Funcionario = Funcionarios
            };

            return View(viewModel);
        }

        public ActionResult Detalhes(int id)
        {
            if (Funcionarios.Count < id)
            {
                return HttpNotFound();
            }

            var funcionario = Funcionarios[id - 1];

            return View(funcionario);
        }
    }
}