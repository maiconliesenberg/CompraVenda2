using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompraVenda.Models;

namespace CompraVenda.ViewModels
{
    public class VendaFormViewModel
    {
        public IEnumerable<Produto> Produto { get; set; }
        public IEnumerable<Cliente> Cliente { get; set; }
        public IEnumerable<Funcionario> Funcionario { get; set; }
        public Venda Venda { get; set; }
        public string Title
        {
            get
            {
                if (Venda != null && Venda.Id != 0)
                    return "Editar Venda";

                return "Novo Venda";
            }
        }
    }
}