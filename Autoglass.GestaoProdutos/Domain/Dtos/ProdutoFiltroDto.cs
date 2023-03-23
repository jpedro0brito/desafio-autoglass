using System;

namespace Domain.Dtos
{
    public class ProdutoFiltroDto
    {
        public string DescricaoDoProduto { get; private set; }
        public DateTime? DataDeFabricacao { get; private set; }
        public DateTime? DataDeValidade { get; private set; }
        public string DescricaoFornecedor { get; private set; }
        public string Cnpj { get; private set; }
    }
}
