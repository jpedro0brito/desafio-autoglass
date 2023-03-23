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
    }
}