using System;
using System.Collections.Generic;
using System.Text;
using Pedidos.Domain.Entities;

namespace Pedidos.Domain.Interfaces
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        IEnumerable<Fornecedor> ListarTodos();
    }
}
