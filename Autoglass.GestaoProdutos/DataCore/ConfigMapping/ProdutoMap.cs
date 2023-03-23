using DataCore.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataCore.ConfigMapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable(nameof(GestaoProdutosContext.Produtos), GestaoProdutosContext.GestaoProdutosDB);

            builder.HasKey(p => p.Id);

            builder
                .Property(p => p.Descricao)
                .IsRequired();

            builder
                .Property(p => p.Situacao)
                .IsRequired();

            builder
                .Property(p => p.DataDeFabricacao)
                .IsRequired();

            builder
                .Property(p => p.DataDeValidade)
                .IsRequired();

            builder.HasOne(p => p.Fornecedor);
        }
    }
}
