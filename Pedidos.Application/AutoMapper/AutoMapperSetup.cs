using AutoMapper;
using Pedidos.Application.ViewModels;
using Pedidos.Domain.Entities;

namespace Pedidos.Application.AutoMapper
{
    public class AutoMapperSetup: Profile
    {
        public AutoMapperSetup()
        {
            CreateMap<FornecedorViewModel, Fornecedor>();
            CreateMap<ProdutoViewModel, Produto>();
            CreateMap<PedidoViewModel, Pedido>();

            CreateMap<Fornecedor, FornecedorViewModel>();
            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<Pedido, PedidoViewModel>();
        }
    }
}
