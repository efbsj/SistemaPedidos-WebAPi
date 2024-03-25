using System;
using System.ComponentModel.DataAnnotations;

namespace Pedidos.Application.ViewModels
{
    public class PedidoViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int FornecedorId { get; set; }
        
        [Required]
        public FornecedorViewModel Fornecedor { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        [Required]
        public ProdutoViewModel Produto{ get; set; }

        [Required]
        public DateTime DataPedido { get; set; }

        [Required]
        public int QuantidadeProdutos { get; set; }

        [Required]
        public decimal ValorTotalPedido { get; set; }

    }
}
