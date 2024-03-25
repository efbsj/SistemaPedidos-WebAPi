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
    public class PedidoServiceTests
    {
        private PedidoService pedidoService;


        public PedidoServiceTests()
        {
            pedidoService = new PedidoService(new Mock<IPedidoRepository>().Object, new Mock<IMapper>().Object);
        }

        [Fact]
        public void Post_SendingValidId()
        {
            var exception = Assert.Throws<Exception>(() => pedidoService.Salvar(new PedidoViewModel { Id = 0 }));
            Assert.Equal("UserID must be empty", exception.Message);
        }

        [Fact]
        public void GetById_SendingEmptyGuid()
        {
            var exception = Assert.Throws<Exception>(() => pedidoService.ObterPorId(0));
            Assert.Equal("UserID is not valid", exception.Message);
        }

        [Fact]
        public void Put_SendingEmptyGuid()
        {
            var exception = Assert.Throws<Exception>(() => pedidoService.Atualizar(new PedidoViewModel()));
            Assert.Equal("ID is invalid", exception.Message);
        }

        [Fact]
        public void Delete_SendingEmptyGuid()
        {
            var exception = Assert.Throws<Exception>(() => pedidoService.Delete(0));
            Assert.Equal("UserID is not valid", exception.Message);
        }

        [Fact]
        public void Post_SendingValidObject()
        {
            var result = pedidoService.Salvar(new PedidoViewModel { Id = 1, FornecedorId = 1, ProdutoId = 1, QuantidadeProdutos = 5, DataPedido = DateTime.Now });
            Assert.True(result);
        }

        [Fact]
        public void Get_ValidatingObject()
        {
            //Criando a lista com um objeto para que seja retornado pelo repository
            List<Pedido> _Pedidoes = new List<Pedido>();
            _Pedidoes.Add(new Pedido { Id = 1, FornecedorId = 1, ProdutoId = 1, QuantidadeProdutos = 5, DataPedido = DateTime.Now });
            
            //Criando um objeto mock do UserRepository e configurando para retornar a lista criada anteriormente se chamar o método GetAll()
            var _PedidoRepository = new Mock<IPedidoRepository>();
            _PedidoRepository.Setup(x => x.ListarTodos()).Returns(_Pedidoes);

            //Criando um objeto mock do AutoMapper para que possamos converter o retorno para o tipo List<UserViewModel>()
            var _autoMapperProfile = new AutoMapperSetup();
            var _configuration = new MapperConfiguration(x => x.AddProfile(_autoMapperProfile));
            IMapper _mapper = new Mapper(_configuration);

            //Istanciando nossa classe de serviço novamente com os novos objetos mocks que criamos
            pedidoService = new PedidoService(_PedidoRepository.Object, _mapper);

            //Obtendo os valores do método Get para validar se vai retornar o objeto criado acima.
            var result = pedidoService.Listar();

            //Validando se o retorno contém uma lista com objetos.
            Assert.True(result.Count > 0);
        }
    }
}
