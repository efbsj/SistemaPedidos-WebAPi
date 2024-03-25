using System;
using System.Collections.Generic;
using Pedidos.Data.Context;
using Pedidos.Domain.Entities;
using Pedidos.Domain.Interfaces;

namespace Pedidos.Data.Repositories
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {

        public FornecedorRepository(DataContext context)
            : base(context) { }

        public IEnumerable<Fornecedor> ListarTodos()
        {
            return Query(x => x.Id > 0);
        }
    }
}
