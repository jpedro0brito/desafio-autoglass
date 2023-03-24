using Domain.Dtos;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        Task<Produto> Obter(int id);
        Task<(IList<Produto> Result, int QuantidadeNoBanco)> Filtrar(int pagina, ProdutoFiltroDto filtro, int quantidade = 40);
        Task Gravar(Produto produto);
        Task Atualizar(Produto produto);
    }
}
