using System;
using System.ComponentModel.DataAnnotations;

namespace Pedidos.Application.ViewModels
{
    public class ProdutoViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }

        [Required]
        public decimal ValorProduto { get; set; }
    }
}
