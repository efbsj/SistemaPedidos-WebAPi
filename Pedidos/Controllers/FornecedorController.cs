using System;
using Microsoft.AspNetCore.Mvc;
using Pedidos.Application.Interfaces;
using Pedidos.Application.ViewModels;

namespace Pedidos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorService fornecedorService;

        public FornecedorController(IFornecedorService fornecedorService)
        {
            this.fornecedorService = fornecedorService;
        }

        [HttpGet, Route("Listar")]
        public IActionResult Get()
        {
            try
            {
                var result = this.fornecedorService.Listar();

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
                var result = this.fornecedorService.ObterPorId(Id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost, Route("Salvar")]
        public IActionResult Salvar(FornecedorViewModel model)
        {
            try
            {
                if (this.fornecedorService.Salvar(model))
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
        public IActionResult Update(FornecedorViewModel model)
        {
            try
            {
                var Fornecedor = this.fornecedorService.ObterPorId(model.Id);
                if (Fornecedor == null) return NotFound();

                if (fornecedorService.Atualizar(model))
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
                if (this.fornecedorService.Delete(Id))
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
