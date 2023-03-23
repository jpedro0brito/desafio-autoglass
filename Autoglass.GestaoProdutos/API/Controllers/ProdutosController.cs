using AppService.Interfaces;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : ControllerBase
    {
        [HttpGet("{id:int}")]
        public async Task<IActionResult> BuscarUmProduto(int id, [FromServices] IProdutoAppService appService)
        {
            var produtoDto = await appService.Buscar(id);
            if (produtoDto == null)
            {
                return NoContent();
            }

            return Ok(produtoDto);
        }

        [HttpPost("Filtro/{paigna:int}/pagina")]
        public async Task<IActionResult> BuscarUmProduto(int paigna, [FromServices] IProdutoAppService appService, [FromBody] ProdutoFiltroDto filtroDto)
        {
            var listaDeProdutoDto = await appService.Filtrar(paigna, filtroDto);
            if (!listaDeProdutoDto.Any())
            {
                return NoContent();
            }

            return Ok(listaDeProdutoDto);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarUmProduto([FromServices] IProdutoAppService appService, [FromBody] ProdutoFiltroDto filtroDto)
        {
            var listaDeProdutoDto = await appService.Criar(paigna, filtroDto);
            if (!listaDeProdutoDto.Any())
            {
                return NoContent();
            }

            return Ok(listaDeProdutoDto);
        }
    }
}
