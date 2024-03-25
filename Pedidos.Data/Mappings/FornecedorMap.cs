using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Domain.Entities;

namespace Pedidos.Data.Mappings
{
    public class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.NomeRazaoSocial).IsRequired();
            builder.Property(x => x.CNPJ).IsRequired();
            builder.Property(x => x.UF).IsRequired();
            builder.Property(x => x.EmailContato).IsRequired();
            builder.Property(x => x.NomeContato).IsRequired();
        }
    }
}
