using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ProdutoService: IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository) =>
            (_repository) = (repository);

        public async Task<Produto> Buscar(int id) => await _repository.Obter(id);

        public async Task<IList<Produto>> Filtrar(int pagina, ProdutoFiltroDto filtro) => await _repository.Filtrar(pagina, filtro);

        public async Task Criar(string descricao, DateTime dataDeFabricacao, DateTime dataDeValidade, Fornecedor fornecedor) 
        {
            var produto = new Produto(descricao, dataDeFabricacao, dataDeValidade, fornecedor);
            await _repository.Gravar(produto);
        }

        public async Task Editar(int id, string descricao = null, DateTime? dataDeFabricacao = null, DateTime? dataDeValidade = null, Fornecedor fornecedor = null)
        {
            var produto = await _repository.Obter(id);
            produto.EditarCampos(descricao, dataDeFabricacao, dataDeValidade, fornecedor);
            await _repository.Atualizar(produto);
        }

        public async Task Excluir(int id)
        {
            var produto = await _repository.Obter(id);
            produto.Desativar();
            await _repository.Atualizar(produto);
        }
    }
}
