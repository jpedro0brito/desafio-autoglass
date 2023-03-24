using AppService.Dtos;
using AppService.Interfaces;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces.Services;
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

        public async Task<ProdutoFiltradoDto> Filtrar(int pagina, ProdutoFiltroDto filtro)
        {
            var resultFiltro = await _produtoService.Filtrar(pagina, filtro);
            var listaDeProdutosDto = _mapper.Map<List<ProdutoDto>>(resultFiltro.Result);


            return new ProdutoFiltradoDto 
            {
                QuantidadeNoBanco = resultFiltro.QuantidadeNoBanco,
                TamanhoDaPagina = listaDeProdutosDto.Count,
                Pagina = pagina,
                Resultado = listaDeProdutosDto
            };
        }

        public async Task Criar(CriarProdutoDto criarProdutoDto)
        {
            var fornecedor = new Fornecedor(criarProdutoDto.DescricaoFornecedor, criarProdutoDto.Cnpj);
            await _produtoService.Criar(criarProdutoDto.Descricao, criarProdutoDto.DataDeFabricacao, criarProdutoDto.DataDeValidade, fornecedor);
        }

        public async Task Editar(EditarProdutoDto produtoDto)
        {
            await _produtoService.Editar(produtoDto.Id, produtoDto.Descricao, produtoDto.DataDeFabricacao, produtoDto.DataDeValidade, produtoDto.DescricaoFornecedor, produtoDto.Cnpj);
        }

        public async Task Excluir(int id) => await _produtoService.Excluir(id);
    }
}
