using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Pedidos.Application.ViewModels;

namespace Pedidos.Application.Interfaces
{
    public interface IFornecedorService
    {
        List<FornecedorViewModel> Listar();
        FornecedorViewModel ObterPorId(int id);
        bool Salvar(FornecedorViewModel model);
        bool Atualizar(FornecedorViewModel model);
        bool Delete(int id);
    }
}
