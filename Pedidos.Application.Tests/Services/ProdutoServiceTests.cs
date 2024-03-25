using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Pedidos.Application.AutoMapper;
using Pedidos.Application.Services;
using Pedidos.Application.ViewModels;
using Pedidos.Domain.Entities;
using Pedidos.Domain.Interfaces;
using Xunit;

namespace Pedidos.Application.Tests.Services
{
    public class ProdutoServiceTests
    {
        private ProdutoService produtoService;


        public ProdutoServiceTests()
        {
            produtoService = new ProdutoService(new Mock<IProdutoRepository>().Object, new Mock<IMapper>().Object);
        }

        [Fact]
        public void Post_SendingValidId()
        {
            var exception = Assert.Throws<Exception>(() => produtoService.Salvar(new ProdutoViewModel { Id = 0 }));
            Assert.Equal("UserID must be empty", exception.Message);
        }

        [Fact]
        public void GetById_SendingEmptyGuid()
        {
            var exception = Assert.Throws<Exception>(() => produtoService.ObterPorId(0));
            Assert.Equal("UserID is not valid", exception.Message);
        }

        [Fact]
        public void Put_SendingEmptyGuid()
        {
            var exception = Assert.Throws<Exception>(() => produtoService.Atualizar(new ProdutoViewModel()));
            Assert.Equal("ID is invalid", exception.Message);
        }

        [Fact]
        public void Delete_SendingEmptyGuid()
        {
            var exception = Assert.Throws<Exception>(() => produtoService.Delete(0));
            Assert.Equal("UserID is not valid", exception.Message);
        }

        [Fact]
        public void Post_SendingValidObject()
        {
            var result = produtoService.Salvar(new ProdutoViewModel { Id = 1, Descricao = "água", ValorProduto = 10, DataCadastro = DateTime.Now });
            Assert.True(result);
        }

        [Fact]
        public void Get_ValidatingObject()
        {
            //Criando a lista com um objeto para que seja retornado pelo repository
            List<Produto> _Produtoes = new List<Produto>();
            _Produtoes.Add(new Produto { Id = 1, Descricao = "água", ValorProduto = 10, DataCadastro = DateTime.Now });
            
            //Criando um objeto mock do UserRepository e configurando para retornar a lista criada anteriormente se chamar o método GetAll()
            var _ProdutoRepository = new Mock<IProdutoRepository>();
            _ProdutoRepository.Setup(x => x.ListarTodos()).Returns(_Produtoes);

            //Criando um objeto mock do AutoMapper para que possamos converter o retorno para o tipo List<UserViewModel>()
            var _autoMapperProfile = new AutoMapperSetup();
            var _configuration = new MapperConfiguration(x => x.AddProfile(_autoMapperProfile));
            IMapper _mapper = new Mapper(_configuration);

            //Istanciando nossa classe de serviço novamente com os novos objetos mocks que criamos
            produtoService = new ProdutoService(_ProdutoRepository.Object, _mapper);

            //Obtendo os valores do método Get para validar se vai retornar o objeto criado acima.
            var result = produtoService.Listar();

            //Validando se o retorno contém uma lista com objetos.
            Assert.True(result.Count > 0);
        }

        [Fact]
        public void Post_SendingInvalidObject()
        {
            var exception = Assert.Throws<ValidationException>(() => produtoService.Salvar(new ProdutoViewModel { Descricao = "Francisco e Carlos Comercio de Bebidas ME" }));
            Assert.Equal("The Email field is required.", exception.Message);
        }
    }
}
