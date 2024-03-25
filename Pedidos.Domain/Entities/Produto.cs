using System;

namespace Pedidos.Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public decimal ValorProduto { get; set; }
    }
}
