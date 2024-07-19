using Xunit;

namespace Miquellas_Store;
public class FreteCalculatorTests
{
    [Fact]
    public void TesteCalcularFrete()
    {
        Jogo jogo = new Jogo("Nome do jogo", 50, 0.36, "Categoria");
        int quantidade = 2;
        double distancia = 100.0;
        double resultadoEsperado = 20.0;

        double resultado = FreteCalculator.CalcularFrete(jogo, quantidade, distancia);
        Assert.Equal(resultadoEsperado, resultado);
    }

    [Fact]
    public void TesteCalcularFrete_DistanciaZero()
    {
        Jogo jogo = new Jogo("Nome do jogo", 10, 1.0, "Categoria");
        int quantidade = 2;
        double distancia = 0.0;
        double resultadoEsperado = 0.0;

        double resultado = FreteCalculator.CalcularFrete(jogo, quantidade, distancia);
        Assert.Equal(resultadoEsperado, resultado);
    }

    [Fact]
    public void TesteCalcularFrete_QuantidadeZero()
    {
        Jogo jogo = new Jogo("Nome do jogo", 10, 1.0, "Categoria");
        int quantidade = 0;
        double distancia = 100.0;
        double resultadoEsperado = 0.0;

        double resultado = FreteCalculator.CalcularFrete(jogo, quantidade, distancia);
        Assert.Equal(resultadoEsperado, resultado);
    }
}