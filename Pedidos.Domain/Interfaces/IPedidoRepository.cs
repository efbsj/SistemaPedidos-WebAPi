using System;
using System.Collections.Generic;
using System.Text;
using Pedidos.Domain.Entities;

namespace Pedidos.Domain.Interfaces
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        IEnumerable<Pedido> ListarTodos();
        IEnumerable<Pedido> ListarPorCnpjFornecedor(string cnpj);
    }
}
