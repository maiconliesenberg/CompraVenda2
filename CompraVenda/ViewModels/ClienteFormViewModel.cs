using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompraVenda.Models;

namespace CompraVenda.ViewModels
{
    public class ClienteFormViewModel
    {
        public Cliente Cliente { get; set; }
        public string Title
        {
            get
            {
                if (Cliente != null && Cliente.Id != 0)
                    return "Editar Cliente";

                return "Novo Cliente";
            }
        }
    }
}