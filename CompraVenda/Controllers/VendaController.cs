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
        [Authorize]
        public ActionResult Index()
        { 
            var venda = _context.Venda.Include(c => c.Produto).Include(c => c.Cliente).Include(c => c.Funcionario).ToList();
            return View(venda);
        }
        [Authorize]
        public ActionResult Detalhes(int id)
        {
           // var produtos = _context.Venda.SingleOrDefault(m => m.Id == id);
            var vendas = _context.Venda.Include(c => c.Produto).Include(c => c.Cliente).Include(c => c.Funcionario).SingleOrDefault(c => c.Id == id);

            if (vendas == null)
            {
                return HttpNotFound();
            }

            return View(vendas);
        }
        [Authorize]
        public ActionResult New()
        {
            var cliente = _context.Cliente.ToList();
            var produto = _context.Produto.ToList();
            var funcionario = _context.Funcionario.ToList();
            var viewModel = new VendaFormViewModel
            {
                Venda = new Venda(),
                Cliente = cliente,
                Produto = produto,
                Funcionario = funcionario
            };

            return View("VendaForm", viewModel);
        }
        [Authorize]
        [HttpPost] // só será acessada com 
        [ValidateAntiForgeryToken]
        public ActionResult Save(Venda venda) // recebemos um cliente
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new VendaFormViewModel
                {
                    Venda = venda,
                    Cliente = _context.Cliente.ToList(),
                    Produto = _context.Produto.ToList(),
                    Funcionario = _context.Funcionario.ToList()                    
                };

                return View("VendaForm", viewModel);
            }

            if (venda.Id == 0)
            {
                // armazena o cliente em memória
                _context.Venda.Add(venda);
            }
            else
            { 
                var customerInDb = _context.Venda.Include(c => c.Produto).Include(c => c.Cliente).Include(c => c.Funcionario).SingleOrDefault(c => c.Id == venda.Id);

                customerInDb.Name = venda.Name;
                customerInDb.ClienteId = venda.ClienteId;
                customerInDb.ProdutoId = venda.ProdutoId;
                customerInDb.FuncionarioId = venda.FuncionarioId;
            }

            // faz a persistência
            _context.SaveChanges();
            // Voltamos para a lista de clientes
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            var venda = _context.Venda.Include(c => c.Produto).Include(c => c.Cliente).Include(c => c.Funcionario).SingleOrDefault(c => c.Id == id);

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

        [Authorize]
        public ActionResult Delete(int id)
        {
            var venda = _context.Venda.SingleOrDefault(c => c.Id == id);

            if (venda == null)
                return HttpNotFound();

            _context.Venda.Remove(venda);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}