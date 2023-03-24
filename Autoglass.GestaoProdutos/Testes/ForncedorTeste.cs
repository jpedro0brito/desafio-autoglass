using Domain.Entities;
using System;
using Xunit;

namespace Testes
{
    public class ForncedorTeste
    {
        [Fact]
        public void DeveCriarUmFornecedor()
        {
            //Arrange
            var descricao = "José Pedro";
            var cpnj = "12345678911111";


            //Action
            var fornecedor = new Fornecedor(descricao, cpnj);

            //Assert
            Assert.NotNull(fornecedor);
            Assert.Equal(descricao, fornecedor.Descricao);
            Assert.Equal(cpnj, fornecedor.Cnpj.Codigo);
        }

        [Fact]
        public void NaoDeveCriarUmFornecedor()
        {
            //Arrange
            var descricao = "José Pedro";
            var cpnj = "12345678911";


            //Action Assert
            Assert.Throws<ArgumentException>(() => 
            {
                new Fornecedor(descricao, cpnj);
            });
        }
    }
}
