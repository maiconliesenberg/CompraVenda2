using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompraVenda.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public byte ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public byte FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }

    }
}