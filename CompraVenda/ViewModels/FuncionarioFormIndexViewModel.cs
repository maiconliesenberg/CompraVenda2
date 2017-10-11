using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompraVenda.Models;

namespace CompraVenda.ViewModels
{
    public class FuncionarioFormViewModel
    {
        public Funcionario Funcionario { get; set; }
        public string Title
        {
            get
            {
                if (Funcionario != null && Funcionario.Id != 0)
                    return "Editar Funcionario";

                return "Novo Funcionario";
            }
        }
    }
}