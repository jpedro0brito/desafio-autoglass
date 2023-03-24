using DataCore.Context;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataCore.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        protected readonly GestaoProdutosContext _context;
        protected readonly DbSet<Produto> _dbSet;

        public ProdutoRepository(GestaoProdutosContext context)
        {
            _context = context;
            _dbSet = _context.Set<Produto>();
        }

        public async Task<Produto> Obter(int id) => await _dbSet
            .Include(p => p.Fornecedor)
            .FirstOrDefaultAsync(p => p.Id == id && p.Situacao);

        public async Task<(IList<Produto> Result, int QuantidadeNoBanco)> Filtrar(int pagina, ProdutoFiltroDto filtro, int quantidade = 40)
        {
            var produtosBanco = _dbSet.Include(p => p.Fornecedor).Where(p => p.Situacao).AsNoTracking();

            if (!string.IsNullOrEmpty(filtro.DescricaoDoProduto))
                produtosBanco = produtosBanco.Where(x => x.Descricao.Contains(filtro.DescricaoDoProduto));

            if (!string.IsNullOrEmpty(filtro.DescricaoFornecedor))
                produtosBanco = produtosBanco.Where(x => x.Fornecedor.Descricao.Contains(filtro.DescricaoFornecedor));

            if (filtro.DataDeFabricacao.HasValue)
                produtosBanco = produtosBanco.Where(x => x.DataDeFabricacao.Date == filtro.DataDeFabricacao.Value.Date);

            if (filtro.DataDeValidade.HasValue)
                produtosBanco = produtosBanco.Where(x => x.DataDeValidade.Date == filtro.DataDeValidade.Value.Date);

            if (!string.IsNullOrEmpty(filtro.Cnpj))
                produtosBanco = produtosBanco.Where(x => x.Fornecedor.Cnpj.Codigo.Contains(filtro.Cnpj));

            var listaFiltrada = await produtosBanco
                .Skip(Math.Max(0, pagina - 1) * quantidade)
                .Take(quantidade)
                .ToListAsync();

            return (listaFiltrada, await _dbSet.Include(p => p.Fornecedor).Where(p => p.Situacao).CountAsync());
        }

        public async Task Gravar(Produto produto)
        {
            await _dbSet.AddAsync(produto);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Produto produto)
        {
            _dbSet.Update(produto);
            await _context.SaveChangesAsync();
        }
    }
}
