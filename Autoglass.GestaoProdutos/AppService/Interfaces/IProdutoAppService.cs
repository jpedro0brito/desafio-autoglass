using AppService.Dtos;
using Domain.Dtos;
using System.Threading.Tasks;

namespace AppService.Interfaces
{
    public interface IProdutoAppService
    {
        Task<ProdutoDto> Buscar(int id);
        Task<ProdutoFiltradoDto> Filtrar(int pagina, ProdutoFiltroDto filtro);
        Task Criar(CriarProdutoDto produtoDto);
        Task Editar(EditarProdutoDto produtoDto);
        Task Excluir(int id);
    }
}
