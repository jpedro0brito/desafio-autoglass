using AppService.Dtos;
using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppService.Interfaces
{
    public interface IProdutoAppService
    {
        Task<ProdutoDto> Buscar(int id);
        Task<IList<ProdutoDto>> Filtrar(int pagina, ProdutoFiltroDto filtro);
        Task Criar(string descricao, DateTime dataDeFabricacao, DateTime dataDeValidade, FornecedorDto fornecedorDto);
        Task Editar(int id, string descricao = null, DateTime? dataDeFabricacao = null, DateTime? dataDeValidade = null, FornecedorDto fornecedorDto = null);
        Task Excluir(int id);
    }
}
