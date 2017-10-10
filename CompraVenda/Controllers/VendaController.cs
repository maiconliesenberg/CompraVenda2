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
            var venda = _context.Venda.Include(c => c.Id).ToList();
            //var venda = _context.Venda.ToList();
            return View(venda);
        }

        public ActionResult Detalhes(int id)
        {
            var produtos = _context.Venda.SingleOrDefault(m => m.Id == id);
            //var produtos = db.Produto.Include(c => c.Id).SingleOrDefault(c => c.Id == id);

            if (produtos == null)
            {
                return HttpNotFound();
            }

            return View(produtos);
        }
    }
}