using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Fornecedor
    {
        public Fornecedor() { }
        public Fornecedor(string descricao, string cnpj)
        {
            Descricao = descricao;
            Cnpj = new Cnpj(cnpj);
        }

        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public Cnpj Cnpj { get; private set; }

        public void EditarCampos(string descricao = null, string cnpj = null)
        {
            if (!string.IsNullOrEmpty(descricao))
            {
                Descricao = descricao;
            }

            if (!string.IsNullOrEmpty(cnpj))
            {
                Cnpj = new Cnpj(cnpj);
            }
        }
    }
}