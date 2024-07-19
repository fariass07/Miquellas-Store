using Xunit;
using System;
using System.IO;
using System.Linq;
using Miquellas_Store;

namespace EstoqueJogosTests
{
    public class EstoqueTests
    {
        [Fact]
        public void TesteCalculoFrete()
        {
           
            var jogo = new Jogo("Jogo Teste", 2, 100.0, "Marca Teste");
            double distancia = 50.0;
            int quantidadeComprar = jogo.Quantidade;

            double peso = jogo.Peso;
            double preco = jogo.Preco;

            double freteCalculado = distancia * (peso * 0.1) / (preco * 0.1) * quantidadeComprar;

            Assert.Equal(0.36, freteCalculado);
        }

        [Fact]
        public void TestePreçoFinal()
        {
            var jogo = new Jogo("Jogo Teste", 2, 100.0, "Marca Teste");
            double distancia = 50.0;
            int quantidadeComprar = jogo.Quantidade;

            double peso = jogo.Peso;
            double preco = jogo.Preco;

            double freteCalculado = distancia * (peso * 0.1) / (preco * 0.1) * quantidadeComprar;
            double PrecoFinal = freteCalculado + (preco * quantidadeComprar);

            Assert.Equal(200.36, PrecoFinal);
        }
    }
}
