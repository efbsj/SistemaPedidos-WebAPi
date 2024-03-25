using System;
using Microsoft.AspNetCore.Mvc;
using Pedidos.Application.Interfaces;
using Pedidos.Application.ViewModels;

namespace Pedidos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            this.pedidoService = pedidoService;
        }

        [HttpGet, Route("Listar")]
        public IActionResult Get()
        {
            try
            {
                var result = this.pedidoService.Listar();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet, Route("ListarPorCnpjFornecedor")]
        public IActionResult ListarPorCnpjFornecedor(string cnpj)
        {
            try
            {
                var result = this.pedidoService.ListarPorCnpjFornecedor(cnpj);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet, Route("ObterPorId")]
        public IActionResult Obter(int Id)
        {
            try
            {
                var result = this.pedidoService.ObterPorId(Id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost, Route("Salvar")]
        public IActionResult Salvar(PedidoViewModel model)
        {
            try
            {
                if (this.pedidoService.Salvar(model))
                {
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpPut, Route("Atualizar")]
        public IActionResult Update(PedidoViewModel model)
        {
            try
            {
                var Pedido = this.pedidoService.ObterPorId(model.Id);
                if (Pedido == null) return NotFound();

                if (pedidoService.Atualizar(model))
                {
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpDelete, Route("Apagar")]
        public IActionResult delete(int Id)
        {
            try
            {
                if (this.pedidoService.Delete(Id))
                {
                    return Ok(new { message = "Deletado" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
    }
}
