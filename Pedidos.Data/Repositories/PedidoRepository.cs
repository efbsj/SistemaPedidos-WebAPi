using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pedidos.Data.Context;
using Pedidos.Domain.Entities;
using Pedidos.Domain.Interfaces;

namespace Pedidos.Data.Repositories
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {

        public PedidoRepository(DataContext context)
            : base(context) { }

        public IEnumerable<Pedido> ListarTodos()
        {
            IQueryable<Pedido> query = _context.Pedidos
                        .Include(c => c.Produto)
                        .Include(c => c.Fornecedor);

            return query.AsNoTracking()
                         .OrderBy(pedido => pedido.Id);
        }

        public IEnumerable<Pedido> ListarPorCnpjFornecedor(string cnpj)
        {
            IQueryable<Pedido> query = _context.Pedidos
                        .Include(c => c.Produto)
                        .Include(c => c.Fornecedor);

            return query.AsNoTracking()
                         .Where(pedido => pedido.Fornecedor.CNPJ == cnpj)
                         .OrderBy(pedido => pedido.Id);
        }
    }
}
