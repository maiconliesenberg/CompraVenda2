using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompraVenda.Models;
using CompraVenda.ViewModels;

namespace CompraVenda.Controllers
{
    public class VendaController : Controller
    {
        // GET: Venda

        public List<Venda> Vendas = new List<Venda>
        {
            new Venda {Id = 1,Name = "Relogio"},
            new Venda { Id = 2, Name = "Ampulheta"}
        };

        public ActionResult Index()
        {
            var viewModel = new VendaIndexViewModel
            {
                Venda = Vendas
            };

            return View(viewModel);
        }

        public ActionResult Detalhes(int id)
        {
            if (Vendas.Count < id)
            {
                return HttpNotFound();
            }

            var venda = Vendas[id - 1];

            return View(venda);
        }
    }
}