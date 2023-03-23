using System.Collections.Generic;

namespace AppService.Dtos
{
    public class ProdutoFiltradoDto
    {
        public int QuantidadeNoBanco { get; set; }
        public int TamanhoDaPagina { get; set; }
        public int Pagina { get; set; }
        public IList<ProdutoDto> Resultado { get; set; }
    }
}
