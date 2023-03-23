using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IProdutoService
    {
        Task<Produto> Buscar(int id);
        Task<IList<Produto>> Filtrar(int pagina, ProdutoFiltroDto filtro);
        Task Criar(string descricao, DateTime dataDeFabricacao, DateTime dataDeValidade, Fornecedor fornecedor);
        Task Editar(int id, string descricao = null, DateTime? dataDeFabricacao = null, DateTime? dataDeValidade = null, Fornecedor fornecedor = null);
        Task Excluir(int id);
    }
}
