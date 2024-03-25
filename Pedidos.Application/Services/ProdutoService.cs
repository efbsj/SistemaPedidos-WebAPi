using AutoMapper;
using System;
using System.Collections.Generic;
using Pedidos.Application.Interfaces;
using Pedidos.Application.ViewModels;
using Pedidos.Domain.Entities;
using Pedidos.Domain.Interfaces;

namespace Pedidos.Application.Services
{
    public class ProdutoService : IProdutoService
    {

        private readonly IProdutoRepository produtoRepository;
        private readonly IMapper mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            this.produtoRepository = produtoRepository;
            this.mapper = mapper;
        }

        public List<ProdutoViewModel> Listar()
        {
            IEnumerable<Produto> _Produtoes = this.produtoRepository.ListarTodos();

            List<ProdutoViewModel> _ProdutoViewModels = mapper.Map<List<ProdutoViewModel>>(_Produtoes);

            return _ProdutoViewModels;
        }

        public ProdutoViewModel ObterPorId(int id)
        {
            Produto _Produto = this.produtoRepository.Find(x => x.Id == id);
            if (_Produto == null)
                throw new Exception("Produto not found");

            return mapper.Map<ProdutoViewModel>(_Produto);
        }

        public bool Salvar(ProdutoViewModel ProdutoViewModel)
        {
            if (ProdutoViewModel.Id != 0)
                throw new Exception("ProdutoID must be empty");

            Produto _Produto = mapper.Map<Produto>(ProdutoViewModel);

            this.produtoRepository.Create(_Produto);

            return true;
        }

        public bool Atualizar(ProdutoViewModel ProdutoViewModel)
        {
            if (ProdutoViewModel.Id == 0)
                throw new Exception("ID is invalid");

            Produto _Produto = this.produtoRepository.Find(x => x.Id == ProdutoViewModel.Id);
            if (_Produto == null)
                throw new Exception("Produto not found");

            _Produto = mapper.Map<Produto>(ProdutoViewModel);

            this.produtoRepository.Update(_Produto);

            return true;
        }

        public bool Delete(int id)
        {
            Produto _Produto = this.produtoRepository.Find(x => x.Id == id);
            if (_Produto == null)
                throw new Exception("User not found");

            return this.produtoRepository.Delete(_Produto);
        }
    }
}
