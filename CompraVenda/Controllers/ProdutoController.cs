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
    public class ProdutoController : Controller
    {
        private ApplicationDbContext _context;

        public ProdutoController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var produto = _context.Produto.ToList();
            return View(produto);
            //_context.Alunos.ToList();

            // var asd = alunos.SingleOrDefault(c => c.Id == alunos);
        }

        public ActionResult Detalhes(int id)
        {
            var produtos = _context.Produto.SingleOrDefault(m => m.Id == id);
            //var produtos = db.Produto.Include(c => c.Id).SingleOrDefault(c => c.Id == id);

            if (produtos == null)
            {
                return HttpNotFound();
            }

            return View(produtos);
        }

        public ActionResult New()
        {
            var viewModel = new ProdutoFormViewModel {
                Produto = new Produto()
            };

            return View("ProdutoForm", viewModel);
        }

        [HttpPost] // só será acessada com POST
        [ValidateAntiForgeryToken]
        public ActionResult Save(Produto produto) // recebemos um cliente
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ProdutoFormViewModel
                {
                    Produto = produto
                };

                return View("ProdutoForm", viewModel);
            }

            if (produto.Id == 0)
            {
                // armazena o cliente em memória
                _context.Produto.Add(produto);
            }
            else
            {
                var produtoInDb = _context.Produto.Single(c => c.Id == produto.Id);

                produtoInDb.Name = produto.Name;
                
            }
            // faz a persistência
            _context.SaveChanges();
            // Voltamos para a lista de clientes
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var produto = _context.Produto.SingleOrDefault(c => c.Id == id);

            if (produto == null)
                return HttpNotFound();

            var viewModel = new ProdutoFormViewModel
            {
                Produto = produto
            };

            return View("ProdutoForm", viewModel);
        }

        public ActionResult Delete(int id)
        {
            var produto = _context.Produto.SingleOrDefault(c => c.Id == id);

            if (produto == null)
                return HttpNotFound();

            _context.Produto.Remove(produto);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}