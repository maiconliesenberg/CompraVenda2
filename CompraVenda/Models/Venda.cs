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
        [Required]
        [StringLength(255)]
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        [Display(Name = "Produto")]
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        [Display(Name = "Funcionario")]
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }

    }
}