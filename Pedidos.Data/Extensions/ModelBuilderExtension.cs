using Microsoft.EntityFrameworkCore;
using System;
using Pedidos.Domain.Entities;

namespace Pedidos.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder SeedData(this ModelBuilder builder)
        {
            builder.Entity<Produto>()
                .HasData(
                new Produto { Id = 1, Descricao = "água", ValorProduto = 10, DataCadastro = DateTime.Now },
                new Produto { Id = 2, Descricao = "terra", ValorProduto = 1000, DataCadastro = DateTime.Now },
                new Produto { Id = 3, Descricao = "tijolo", ValorProduto = 5000, DataCadastro = DateTime.Now }
            );

            builder.Entity<Fornecedor>()
                .HasData(
                    new Fornecedor { Id = 1, NomeRazaoSocial = "Francisco e Carlos Comercio de Bebidas ME", CNPJ = "86673673000128", UF = "DF", EmailContato = "fiscal@franciscoecarloscomerciodebebidasme.com.br", NomeContato = "Juca" },
                    new Fornecedor { Id = 2, NomeRazaoSocial = "Isabelly e Manoel Pizzaria Ltda", CNPJ = "55738477000160", UF = "DF", EmailContato = "auditoria@isabellyemanoelpizzarialtda.com.br", NomeContato = "Isabelly" },
                    new Fornecedor { Id = 3, NomeRazaoSocial = "Sebastião e Geraldo Gráfica ME", CNPJ = "07805502000139", UF = "DF", EmailContato = "fiscal@sebastiaoegeraldograficame.com.br", NomeContato = "Sebastião" }
                );

            builder.Entity<Pedido>()
                .HasData(
                new Pedido { Id = 1, FornecedorId = 1, ProdutoId = 1, QuantidadeProdutos = 5, DataPedido = DateTime.Now },
                new Pedido { Id = 2, FornecedorId = 2, ProdutoId = 2, QuantidadeProdutos = 5, DataPedido = DateTime.Now },
                new Pedido { Id = 3, FornecedorId = 3, ProdutoId = 3, QuantidadeProdutos = 5, DataPedido = DateTime.Now }
            );

            return builder;
        }
    }
}
