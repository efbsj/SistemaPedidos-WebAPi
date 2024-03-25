using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Pedidos.Application.ViewModels;

namespace Pedidos.Application.Interfaces
{
    public interface IPedidoService
    {
        List<PedidoViewModel> Listar();
        List<PedidoViewModel> ListarPorCnpjFornecedor(string cnpj);
        PedidoViewModel ObterPorId(int id);
        bool Salvar(PedidoViewModel model);
        bool Atualizar(PedidoViewModel model);
        bool Delete(int id);
    }
}
