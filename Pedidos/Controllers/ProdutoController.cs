using System;
using Microsoft.AspNetCore.Mvc;
using Pedidos.Application.Interfaces;
using Pedidos.Application.ViewModels;

namespace Pedidos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            this.produtoService = produtoService;
        }

        [HttpGet, Route("Listar")]
        public IActionResult Get()
        {
            try
            {
                var result = this.produtoService.Listar();

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
                var result = this.produtoService.ObterPorId(Id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost, Route("Salvar")]
        public IActionResult Salvar(ProdutoViewModel model)
        {
            try
            {
                if (this.produtoService.Salvar(model))
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
        public IActionResult Update(ProdutoViewModel model)
        {
            try
            {
                var Produto = this.produtoService.ObterPorId(model.Id);
                if (Produto == null) return NotFound();

                if (produtoService.Atualizar(model))
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
                if (this.produtoService.Delete(Id))
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
