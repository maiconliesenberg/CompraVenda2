using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompraVenda.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Cliente cliente { get; set; }
        public Produto Produto { get; set; }
        public Funcionario Funcionario { get; set; }

    }
}