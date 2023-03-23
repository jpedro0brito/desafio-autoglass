using System;

namespace Domain.Entities
{
    public class Produto
    {
        protected Produto() { }

        public Produto(string descricao, DateTime dataDeFabricacao, DateTime dataDeValidade, Fornecedor fornecedor)
        {
            Descricao = descricao;
            DataDeFabricacao = dataDeFabricacao;
            DataDeValidade = dataDeValidade;
            Fornecedor = fornecedor;
            Situacao = true;
            ValidarCampos();
        }

        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public bool Situacao { get; private set; }
        public DateTime DataDeFabricacao { get; private set; }
        public DateTime DataDeValidade { get; private set; }
        public Fornecedor Fornecedor { get; private set; }

        public void EditarCampos(string descricao, DateTime? dataDeFabricacao, DateTime? dataDeValidade, Fornecedor fornecedor)
        {
            if (!string.IsNullOrEmpty(Descricao))
            {
                Descricao = descricao;
            }

            if (dataDeFabricacao.HasValue)
            {
                DataDeFabricacao = dataDeFabricacao.Value;
            }

            if (dataDeValidade.HasValue)
            {
                DataDeFabricacao = dataDeValidade.Value;
            }

            if (Fornecedor == null)
            {
                Fornecedor = fornecedor;
            }

            ValidarCampos();
        }

        public void Desativar() => Situacao = false;

        public void ValidarCampos()
        {
            if (DataDeFabricacao >= DataDeValidade)
            {
                throw new ArgumentException("Data de fabricação não poderá se maior ou igual a data de validade");
            }
        }
    }
}
