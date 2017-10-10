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
    }
}