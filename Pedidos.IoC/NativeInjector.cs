using Microsoft.Extensions.DependencyInjection;
using System;
using Pedidos.Application.Interfaces;
using Pedidos.Application.Services;
using Pedidos.Data.Repositories;
using Pedidos.Domain.Interfaces;

namespace Pedidos.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IPedidoService, PedidoService>();

            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
        }
    }
}
