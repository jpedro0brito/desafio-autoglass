using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testes
{
    public class ProdutoTeste
    {
        [Fact]
        public void DeveCriarUmProduto()
        {
            //Arrange
            var descricaoForncedor = "José Pedro";
            var cpnj = "12345678911111";

            var descricaoProduto = "Motor v8";
            var dataDeFabricacao = new DateTime(2023, 01, 01);
            var dataDeValidade = new DateTime(2023, 02, 01);

            //Action
            var fornecedor = new Fornecedor(descricaoForncedor, cpnj);
            var produto = new Produto(descricaoProduto, dataDeFabricacao.Date, dataDeValidade.Date, fornecedor);

            //Assert
            Assert.NotNull(fornecedor);
            Assert.Equal(descricaoForncedor, fornecedor.Descricao);
            Assert.Equal(cpnj, fornecedor.Cnpj.Codigo);

            Assert.NotNull(produto);
            Assert.Equal(descricaoProduto, produto.Descricao);
            Assert.Equal(dataDeFabricacao.Date, produto.DataDeFabricacao.Date);
            Assert.Equal(dataDeValidade.Date, produto.DataDeValidade.Date);
        }

        [Fact]
        public void NaoDeveCriarUmProduto()
        {
            //Arrange
            var descricaoForncedor = "José Pedro";
            var cpnj = "12345678911111";

            var descricaoProduto = "Motor v8";
            var dataDeFabricacao = new DateTime(2023, 02, 01);
            var dataDeValidade = new DateTime(2023, 02, 01);

            //Action Assert
            Assert.Throws<ArgumentException>(() =>
            {
                var fornecedor = new Fornecedor(descricaoForncedor, cpnj);
                var produto = new Produto(descricaoProduto, dataDeFabricacao.Date, dataDeValidade.Date, fornecedor);
            });
        }
    }
}
