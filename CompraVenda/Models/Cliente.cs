using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompraVenda.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Boolean IsSub { get; set;}
        public TipoMembro tipoMembro { get; set; }
        //public int tipo { get; set; }
    }
}