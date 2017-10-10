using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompraVenda.Models;
using CompraVenda.ViewModels;
using System.Data.Entity;

namespace CompraVenda.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente

        private ApplicationDbContext _context;

        public ClienteController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var cliente = _context.Cliente.ToList();
            return View(cliente);
        }

        public ActionResult Detalhes(int id)
        {
            var cliente = _context.Cliente.SingleOrDefault(c => c.Id == id);
            //var cliente = _context.Cliente.Include(c => c.Id).SingleOrDefault(c => c.Id == id);

            if (cliente == null)
            {
                return HttpNotFound();
            }

            return View(cliente);
        }

        public ActionResult New()
        {
            var viewModel = new ClienteFormViewModel
            {
            };

            return View("ClienteForm", viewModel);
        }

        [HttpPost] // só será acessada com POST
        public ActionResult Save(Cliente cliente) // recebemos um cliente
        {
            // armazena o cliente em memória
            _context.Cliente.Add(cliente);
            // faz a persistência
            _context.SaveChanges();
            // Voltamos para a lista de clientes
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var cliente = _context.Cliente.SingleOrDefault(c => c.Id == id);

            if (cliente == null)
                return HttpNotFound();

            var viewModel = new ClienteFormViewModel
            {
                Cliente = cliente
            };

            return View("ClienteForm", viewModel);
        }
    }
}