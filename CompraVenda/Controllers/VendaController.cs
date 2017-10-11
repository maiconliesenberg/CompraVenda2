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
    public class VendaController : Controller
    {
        private ApplicationDbContext _context;

        public VendaController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        { 
            var venda = _context.Venda.Include(c => c.Produto).Include(c => c.cliente).Include(c => c.Funcionario).ToList();
            return View(venda);
        }

        public ActionResult Detalhes(int id)
        {
           // var produtos = _context.Venda.SingleOrDefault(m => m.Id == id);
            var vendas = _context.Venda.Include(c => c.Produto).Include(c => c.cliente).Include(c => c.Funcionario).SingleOrDefault(c => c.Id == id);

            if (vendas == null)
            {
                return HttpNotFound();
            }

            return View(vendas);
        }

        public ActionResult New()
        {
            var cliente = _context.Cliente.ToList();
            var produto = _context.Produto.ToList();
            var funcionario = _context.Funcionario.ToList();
            var viewModel = new VendaFormViewModel
            {
                Cliente = cliente,
                Produto = produto,
                Funcionario = funcionario
            };

            return View("VendaForm", viewModel);
        }

        [HttpPost] // só será acessada com POST
        public ActionResult Save(Venda venda) // recebemos um cliente
        {
            if (venda.Id == 0)
            {
                // armazena o cliente em memória
                _context.Venda.Add(venda);
            }
            else
            {
                var customerInDb = _context.Venda.Include(c => c.Produto).Include(c => c.cliente).Include(c => c.Funcionario).SingleOrDefault(c => c.Id == venda.Id);

                customerInDb.Name = venda.Name;
                customerInDb.cliente = venda.cliente;
                customerInDb.Produto = venda.Produto;
                customerInDb.Funcionario = venda.Funcionario;
            }

            // faz a persistência
            _context.SaveChanges();
            // Voltamos para a lista de clientes
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var venda = _context.Venda.Include(c => c.Produto).Include(c => c.cliente).Include(c => c.Funcionario).SingleOrDefault(c => c.Id == id);

            if (venda == null)
                return HttpNotFound();

            var viewModel = new VendaFormViewModel
            {
                Venda = venda,
                Cliente = _context.Cliente.ToList(),
                Produto = _context.Produto.ToList(),
                Funcionario = _context.Funcionario.ToList()
            };

            return View("VendaForm", viewModel);
        }
    }
}