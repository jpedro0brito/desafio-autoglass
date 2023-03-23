namespace AppService.Dtos
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string DataDeFabricacao { get; set; }
        public string DataDeValidade { get; set; }
        public FornecedorDto Fornecedor { get; set; }
    }
}
