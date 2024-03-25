using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Domain.Entities;

namespace Pedidos.Data.Mappings
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.FornecedorId).IsRequired();
            builder.Property(x => x.Fornecedor).IsRequired();
            builder.Property(x => x.ProdutoId).IsRequired();
            builder.Property(x => x.Produto).IsRequired();
            builder.Property(x => x.DataPedido).IsRequired();
            builder.Property(x => x.QuantidadeProdutos).IsRequired();
            builder.Property(x => x.ValorTotalPedido).IsRequired();
        }
    }
}
