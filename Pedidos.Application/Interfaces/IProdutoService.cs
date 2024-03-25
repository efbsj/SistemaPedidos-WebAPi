using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Pedidos.Application.ViewModels;

namespace Pedidos.Application.Interfaces
{
    public interface IProdutoService
    {
        List<ProdutoViewModel> Listar();
        ProdutoViewModel ObterPorId(int id);
        bool Salvar(ProdutoViewModel model);
        bool Atualizar(ProdutoViewModel model);
        bool Delete(int id);
    }
}
