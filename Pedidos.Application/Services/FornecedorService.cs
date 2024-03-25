using AutoMapper;
using System;
using System.Collections.Generic;
using Pedidos.Application.Interfaces;
using Pedidos.Application.ViewModels;
using Pedidos.Domain.Entities;
using Pedidos.Domain.Interfaces;

namespace Pedidos.Application.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository fornecedorRepository;
        private readonly IMapper mapper;

        public FornecedorService(IFornecedorRepository fornecedorRepository, IMapper mapper)
        {
            this.fornecedorRepository = fornecedorRepository;
            this.mapper = mapper;
        }

        public List<FornecedorViewModel> Listar()
        {
            IEnumerable<Fornecedor> _fornecedores = this.fornecedorRepository.ListarTodos();

            List<FornecedorViewModel> _FornecedorViewModels = mapper.Map<List<FornecedorViewModel>>(_fornecedores);

            return _FornecedorViewModels;
        }

        public FornecedorViewModel ObterPorId(int id)
        {
            Fornecedor _fornecedor = this.fornecedorRepository.Find(x => x.Id == id);
            if (_fornecedor == null)
                throw new Exception("fornecedor not found");

            return mapper.Map<FornecedorViewModel>(_fornecedor);
        }

        public bool Salvar(FornecedorViewModel FornecedorViewModel)
        {
            if (FornecedorViewModel.Id != 0)
                throw new Exception("fornecedorID must be empty");

            Fornecedor _fornecedor = mapper.Map<Fornecedor>(FornecedorViewModel);

            this.fornecedorRepository.Create(_fornecedor);

            return true;
        }

        public bool Atualizar(FornecedorViewModel FornecedorViewModel)
        {
            if (FornecedorViewModel.Id == 0)
                throw new Exception("ID is invalid");

            Fornecedor _fornecedor = this.fornecedorRepository.Find(x => x.Id == FornecedorViewModel.Id);
            if (_fornecedor == null)
                throw new Exception("fornecedor not found");

            _fornecedor = mapper.Map<Fornecedor>(FornecedorViewModel);

            this.fornecedorRepository.Update(_fornecedor);

            return true;
        }

        public bool Delete(int id)
        {
            Fornecedor _fornecedor = this.fornecedorRepository.Find(x => x.Id == id);
            if (_fornecedor == null)
                throw new Exception("User not found");

            return this.fornecedorRepository.Delete(_fornecedor);
        }
    }
}
