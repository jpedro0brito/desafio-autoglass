using AppService.Dtos;
using AppService.Interfaces;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("Filtro/{codigo:int}/pagina")]
        public async Task<IActionResult> BuscarUmProduto(int codigo, [FromServices] IProdutoAppService appService, [FromBody] ProdutoFiltroDto filtroDto)
        {
            var listaDeProdutoDto = await appService.Filtrar(codigo, filtroDto);
            if (listaDeProdutoDto == null)
            {
                return NoContent();
            }

            return Ok(listaDeProdutoDto);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarUmProduto([FromServices] IProdutoAppService appService, [FromBody] CriarProdutoDto produtoDto)
        {
            await appService.Criar(produtoDto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarUmProduto([FromServices] IProdutoAppService appService, [FromBody] EditarProdutoDto produtoDto)
        {
            await appService.Editar(produtoDto);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveUmProduto(int id, [FromServices] IProdutoAppService appService)
        {
            await appService.Excluir(id);
            return Ok();
        }
    }
}
