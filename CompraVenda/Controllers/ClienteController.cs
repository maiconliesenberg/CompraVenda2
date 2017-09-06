using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompraVenda.Models;
using CompraVenda.ViewModels;

namespace CompraVenda.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente

        public List<Cliente> Clientes = new List<Cliente>
        {
            new Cliente {Name = "Alberth", Id = 1},
            new Cliente {Name = "Alberta", Id = 2}
        };

        public ActionResult Index()
        {
            var viewModel = new ClienteIndexViewModel
            {
                Cliente = Clientes
            };

            return View(viewModel);
        }

        public ActionResult Detalhes(int id)
        {
            if (Clientes.Count < id)
            {
                return HttpNotFound();
            }

            var cliente = Clientes[id - 1];

            return View(cliente);
        }
    }
}