using System;

namespace Pedidos.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public int FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public DateTime DataPedido { get; set; }
        public int QuantidadeProdutos { get; set; }
        public decimal ValorTotalPedido { get; set; }
    }
}
