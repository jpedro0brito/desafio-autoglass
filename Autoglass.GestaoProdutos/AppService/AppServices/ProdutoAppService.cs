using AppService.Dtos;
using AppService.Interfaces;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppService.AppServices
{
    public class ProdutoAppService: IProdutoAppService
    {
        private readonly IProdutoService _produtoService;
        public readonly IMapper _mapper;
        public ProdutoAppService(IProdutoService produtoService, IMapper mapper) => 
            (_produtoService, _mapper) = (produtoService, mapper);

        public async Task<ProdutoDto> Buscar(int id)
        {
            var produto = await _produtoService.Buscar(id);
            return _mapper.Map<ProdutoDto>(produto);
        }

        public async Task<IList<ProdutoDto>> Filtrar(int pagina, ProdutoFiltroDto filtro)
        {
            var listaDeProdutos = await _produtoService.Filtrar(pagina, filtro);
            return _mapper.Map<List<ProdutoDto>>(listaDeProdutos);
        }

        public async Task Criar(string descricao, DateTime dataDeFabricacao, DateTime dataDeValidade, FornecedorDto fornecedorDto)
        {
            var fornecedor = _mapper.Map<Fornecedor>(fornecedorDto);
            await _produtoService.Criar(descricao, dataDeFabricacao, dataDeValidade, fornecedor);
        }

        public async Task Editar(int id, string descricao = null, DateTime? dataDeFabricacao = null, DateTime? dataDeValidade = null, FornecedorDto fornecedorDto = null)
        {
            var fornecedor = _mapper.Map<Fornecedor>(fornecedorDto);
            await _produtoService.Editar(id, descricao, dataDeFabricacao, dataDeValidade, fornecedor);
        }

        public async Task Excluir(int id) => await _produtoService.Excluir(id);
    }
}
