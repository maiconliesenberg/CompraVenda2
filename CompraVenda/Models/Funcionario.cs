using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CompraVenda.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set;} 
    }
}