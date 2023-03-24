using System;
using System.ComponentModel.DataAnnotations;

namespace AppService.Dtos
{
    public class EditarProdutoDto
    {
        [Required]
        public int Id { get; set; }
        [DataType(DataType.Text)]
        public string Descricao { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DataDeFabricacao { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DataDeValidade { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string Cnpj { get; set; }
    }
}
