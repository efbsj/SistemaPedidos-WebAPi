using AutoMapper;
using System;
using System.Collections.Generic;
using Pedidos.Application.Interfaces;
using Pedidos.Application.ViewModels;
using Pedidos.Domain.Entities;
using Pedidos.Domain.Interfaces;

namespace Pedidos.Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository pedidoRepository;
        private readonly IMapper mapper;

        public PedidoService(IPedidoRepository pedidoRepository, IMapper mapper)
        {
            this.pedidoRepository = pedidoRepository;
            this.mapper = mapper;
        }

        public List<PedidoViewModel> Listar()
        {
            IEnumerable<Pedido> _Pedidoes = this.pedidoRepository.ListarTodos();

            List<PedidoViewModel> _PedidoViewModels = mapper.Map<List<PedidoViewModel>>(_Pedidoes);

            return _PedidoViewModels;
        }

        public List<PedidoViewModel> ListarPorCnpjFornecedor(string cnpj)
        {
            IEnumerable<Pedido> _Pedidoes = this.pedidoRepository.ListarPorCnpjFornecedor(cnpj);

            List<PedidoViewModel> _PedidoViewModels = mapper.Map<List<PedidoViewModel>>(_Pedidoes);

            return _PedidoViewModels;
        }

        public PedidoViewModel ObterPorId(int id)
        {
            Pedido _Pedido = this.pedidoRepository.Find(x => x.Id == id);
            if (_Pedido == null)
                throw new Exception("Pedido not found");

            return mapper.Map<PedidoViewModel>(_Pedido);
        }

        public bool Salvar(PedidoViewModel PedidoViewModel)
        {
            if (PedidoViewModel.Id != 0)
                throw new Exception("PedidoID must be empty");

            Pedido _Pedido = mapper.Map<Pedido>(PedidoViewModel);

            this.pedidoRepository.Create(_Pedido);

            return true;
        }

        public bool Atualizar(PedidoViewModel PedidoViewModel)
        {
            if (PedidoViewModel.Id == 0)
                throw new Exception("ID is invalid");

            Pedido _Pedido = this.pedidoRepository.Find(x => x.Id == PedidoViewModel.Id);
            if (_Pedido == null)
                throw new Exception("Pedido not found");

            _Pedido = mapper.Map<Pedido>(PedidoViewModel);

            this.pedidoRepository.Update(_Pedido);

            return true;
        }

        public bool Delete(int id)
        {
            Pedido _Pedido = this.pedidoRepository.Find(x => x.Id == id);
            if (_Pedido == null)
                throw new Exception("User not found");

            return this.pedidoRepository.Delete(_Pedido);
        }
    }
}
