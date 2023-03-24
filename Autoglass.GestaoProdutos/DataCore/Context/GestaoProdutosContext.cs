using DataCore.ConfigMapping;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataCore.Context
{
    public class GestaoProdutosContext : DbContext
    {
        public const string GestaoProdutosDB = "GestaoProdutosDB";

        public GestaoProdutosContext(DbContextOptions<GestaoProdutosContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new FornecedorMap());
            builder.ApplyConfiguration(new ProdutoMap());
            base.OnModelCreating(builder);
        }
    }
}
