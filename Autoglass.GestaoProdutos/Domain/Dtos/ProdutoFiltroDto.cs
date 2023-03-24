using System;

namespace Domain.Dtos
{
    public class ProdutoFiltroDto
    {
        public string DescricaoDoProduto { get; set; }
        public DateTime? DataDeFabricacao { get; set; }
        public DateTime? DataDeValidade { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string Cnpj { get; set; }
    }
}
