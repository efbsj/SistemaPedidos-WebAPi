using System;
using System.Collections.Generic;
using Pedidos.Data.Context;
using Pedidos.Domain.Entities;
using Pedidos.Domain.Interfaces;

namespace Pedidos.Data.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {

        public ProdutoRepository(DataContext context)
            : base(context) { }

        public IEnumerable<Produto> ListarTodos()
        {
            return Query(x => x.Id > 0);
        }
    }
}
