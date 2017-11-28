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
        private ApplicationDbContext _context;

        public FuncionarioController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        public ActionResult Index()
        {
            var funcionario = _context.Funcionario.ToList();
            if (User.IsInRole("CanManageCustomers"))
                return View(funcionario);
            return View("ReadOnlyIndex", funcionario);
        }
        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult Detalhes(int id)
        {
            var funcionario = _context.Funcionario.SingleOrDefault(c => c.Id == id);
            //var cliente = _context.Cliente.Include(c => c.Id).SingleOrDefault(c => c.Id == id);

            if (funcionario == null)
            {
                return HttpNotFound();
            }

            return View(funcionario);
        }
        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult New()
        {
            var viewModel = new FuncionarioFormViewModel {
                Funcionario = new Funcionario()
            };

            return View("FuncionarioForm", viewModel);
        }
        [Authorize(Roles = "CanManageCustomers")]
        [HttpPost] // só será acessada com POST
        [ValidateAntiForgeryToken]
        public ActionResult Save(Funcionario funcionario) // recebemos um cliente
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new FuncionarioFormViewModel
                {
                    Funcionario = funcionario
                };

                return View("FuncionarioForm", viewModel);
            }

            if (funcionario.Id == 0)
            {
                // armazena o cliente em memória
                _context.Funcionario.Add(funcionario);
            }
            else
            {
                var funcionarioInDb = _context.Funcionario.Single(c => c.Id == funcionario.Id);

                funcionarioInDb.Name = funcionario.Name;
            }
            // faz a persistência
            _context.SaveChanges();
            // Voltamos para a lista de clientes
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult Edit(int id)
        {
            var funcionario = _context.Funcionario.SingleOrDefault(c => c.Id == id);

            if (funcionario == null)
                return HttpNotFound();

            var viewModel = new FuncionarioFormViewModel
            {
                Funcionario = funcionario
            };

            return View("FuncionarioForm", viewModel);
        }
        [Authorize(Roles = "CanManageCustomers")]
        public ActionResult Delete(int id)
        {
            var funcionario = _context.Funcionario.SingleOrDefault(c => c.Id == id);

            if (funcionario == null)
                return HttpNotFound();

            _context.Funcionario.Remove(funcionario);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}