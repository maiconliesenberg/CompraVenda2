using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CompraVenda.Models
{
    public class Produto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Nome")]
        public string Name { get; set; }
    }
}