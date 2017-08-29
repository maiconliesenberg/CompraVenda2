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
            new Funcionario {Name = "Alfredo", Id = 1, Cargo = "Analista"},
            new Funcionario {Name = "Miranda", Id = 2, Cargo = "Fisioterapeuta"}
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