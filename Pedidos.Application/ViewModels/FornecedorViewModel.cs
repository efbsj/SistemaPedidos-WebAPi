using System;
using System.ComponentModel.DataAnnotations;

namespace Pedidos.Application.ViewModels
{
    public class FornecedorViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string NomeRazaoSocial { get; set; }

        [Required]
        public string CNPJ { get; set; }

        [Required]
        public string UF { get; set; }

        [Required]
        public string EmailContato { get; set; }

        [Required]
        public string NomeContato { get; set; }
    }
}
