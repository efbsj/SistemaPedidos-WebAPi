using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Domain.Entities;

namespace Pedidos.Data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Descricao).IsRequired();
            builder.Property(x => x.DataCadastro).IsRequired();
            builder.Property(x => x.ValorProduto).IsRequired();
        }
    }
}
