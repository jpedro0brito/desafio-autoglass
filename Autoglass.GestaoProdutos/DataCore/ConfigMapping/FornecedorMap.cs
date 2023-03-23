using DataCore.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataCore.ConfigMapping
{
    public class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable(nameof(GestaoProdutosContext.Fornecedores), GestaoProdutosContext.GestaoProdutosDB);

            builder.HasKey(p => p.Id);

            builder
                .Property(p => p.Descricao)
                .IsRequired(false);

            builder
                .OwnsOne(c => c.Cnpj, cnpj =>
                {
                    cnpj.Property(c => c.Codigo)
                        .IsRequired()
                        .HasColumnName("CNPJ")
                        .HasColumnType("varchar(14)");
                });
        }
    }
}
