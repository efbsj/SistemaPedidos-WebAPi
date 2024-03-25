using Microsoft.EntityFrameworkCore;
using Pedidos.Data.Extensions;
using Pedidos.Data.Mappings;
using Pedidos.Domain.Entities;

namespace Pedidos.Data.Context
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> option) : base(option) { }

        #region "DBSets"

        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FornecedorMap());
            modelBuilder.SeedData();

            base.OnModelCreating(modelBuilder);
        }
    }
}
