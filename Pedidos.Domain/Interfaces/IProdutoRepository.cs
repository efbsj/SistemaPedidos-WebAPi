using System;
using System.Collections.Generic;
using System.Text;
using Pedidos.Domain.Entities;

namespace Pedidos.Domain.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        IEnumerable<Produto> ListarTodos();
    }
}
