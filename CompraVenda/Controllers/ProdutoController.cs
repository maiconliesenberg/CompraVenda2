using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompraVenda.Models;
using CompraVenda.ViewModels;

namespace CompraVenda.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public List<Produto> Produtos = new List<Produto>
        {
            new Produto {Name = "Relogio", Id = 1},
            new Produto {Name = "Ampulheta", Id = 2}
        };

        public ActionResult Index()
        {
            var viewModel = new ProdutoIndexViewModel
            {
                Produto = Produtos
            };

            return View(viewModel);
        }

        public ActionResult Detalhes(int id)
        {
            if (Produtos.Count < id)
            {
                return HttpNotFound();
            }

            var produto = Produtos[id - 1];

            return View(produto);
        }
    }
}