using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompraVenda.Models;

namespace CompraVenda.ViewModels
{
    public class ProdutoFormViewModel
    {
        public Produto Produto{ get; set; }
        public string Title
        {
            get
            {
                if (Produto != null && Produto.Id != 0)
                    return "Editar Produto";

                return "Novo Cliente";
            }
        }
    }
}