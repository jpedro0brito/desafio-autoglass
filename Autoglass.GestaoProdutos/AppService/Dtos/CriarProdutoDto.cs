using System;
using System.ComponentModel.DataAnnotations;

namespace AppService.Dtos
{
    public class CriarProdutoDto
    {
        [Required]
        public string Descricao { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataDeFabricacao { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataDeValidade { get; set; }
        [Required]
        public string DescricaoFornecedor { get; set; }
        [Required]
        public string Cnpj { get; set; }
    }
}
