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
    public class FornecedorServiceTests
    {
        private FornecedorService fornecedorService;


        public FornecedorServiceTests()
        {
            fornecedorService = new FornecedorService(new Mock<IFornecedorRepository>().Object, new Mock<IMapper>().Object);
        }

        [Fact]
        public void Post_SendingValidId()
        {
            var exception = Assert.Throws<Exception>(() => fornecedorService.Salvar(new FornecedorViewModel { Id = 0 }));
            Assert.Equal("UserID must be empty", exception.Message);
        }

        [Fact]
        public void GetById_SendingEmptyGuid()
        {
            var exception = Assert.Throws<Exception>(() => fornecedorService.ObterPorId(0));
            Assert.Equal("UserID is not valid", exception.Message);
        }

        [Fact]
        public void Put_SendingEmptyGuid()
        {
            var exception = Assert.Throws<Exception>(() => fornecedorService.Atualizar(new FornecedorViewModel()));
            Assert.Equal("ID is invalid", exception.Message);
        }

        [Fact]
        public void Delete_SendingEmptyGuid()
        {
            var exception = Assert.Throws<Exception>(() => fornecedorService.Delete(0));
            Assert.Equal("UserID is not valid", exception.Message);
        }

        [Fact]
        public void Post_SendingValidObject()
        {
            var result = fornecedorService.Salvar(new FornecedorViewModel { Id = 1, NomeRazaoSocial = "Francisco e Carlos Comercio de Bebidas ME", CNPJ = "86673673000128", UF = "DF", EmailContato = "fiscal@franciscoecarloscomerciodebebidasme.com.br", NomeContato = "Juca" });
            Assert.True(result);
        }

        [Fact]
        public void Get_ValidatingObject()
        {
            //Criando a lista com um objeto para que seja retornado pelo repository
            List<Fornecedor> _fornecedores = new List<Fornecedor>();
            _fornecedores.Add(new Fornecedor { Id = 1, NomeRazaoSocial = "Francisco e Carlos Comercio de Bebidas ME", CNPJ = "86673673000128", UF = "DF", EmailContato = "fiscal@franciscoecarloscomerciodebebidasme.com.br", NomeContato = "Juca" });
            
            //Criando um objeto mock do UserRepository e configurando para retornar a lista criada anteriormente se chamar o método GetAll()
            var _fornecedorRepository = new Mock<IFornecedorRepository>();
            _fornecedorRepository.Setup(x => x.ListarTodos()).Returns(_fornecedores);

            //Criando um objeto mock do AutoMapper para que possamos converter o retorno para o tipo List<UserViewModel>()
            var _autoMapperProfile = new AutoMapperSetup();
            var _configuration = new MapperConfiguration(x => x.AddProfile(_autoMapperProfile));
            IMapper _mapper = new Mapper(_configuration);

            //Istanciando nossa classe de serviço novamente com os novos objetos mocks que criamos
            fornecedorService = new FornecedorService(_fornecedorRepository.Object, _mapper);

            //Obtendo os valores do método Get para validar se vai retornar o objeto criado acima.
            var result = fornecedorService.Listar();

            //Validando se o retorno contém uma lista com objetos.
            Assert.True(result.Count > 0);
        }

        [Fact]
        public void Post_SendingInvalidObject()
        {
            var exception = Assert.Throws<ValidationException>(() => fornecedorService.Salvar(new FornecedorViewModel { NomeRazaoSocial = "Francisco e Carlos Comercio de Bebidas ME" }));
            Assert.Equal("The Email field is required.", exception.Message);
        }
    }
}
