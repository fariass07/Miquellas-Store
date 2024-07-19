using System;

namespace Miquellas_Store;
class Frete
{
    public static double CalcularFrete(Jogo jogo, int quantidade, double distancia)
    {
        double peso = jogo.Peso;
        double frete = distancia * (0.1 * peso) * quantidade;
        return frete;
    }

    public static double PrecoFinal(Jogo jogo, int quantidade, double precoFrete)
    {
        double precoJogo = jogo.Preco * quantidade;
        double precoFinal = precoJogo + precoFrete;
        return precoFinal;
    }
}