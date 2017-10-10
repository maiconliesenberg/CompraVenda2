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
            return View(funcionario);
        }

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
    }
}