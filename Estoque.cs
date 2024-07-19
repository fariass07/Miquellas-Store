using System;
using System.Linq;

namespace Miquellas_Store;
class Estoque
{
    private Jogo[] jogos;
    private int quantidade;

    public Estoque(int tamanho)
    {
        jogos = new Jogo[tamanho];
        quantidade = 0;
    }

    public void PreencherEstoque()
    {
        while (true)
        {
            Console.Write("Informe o nome do jogo: ");
            string nome = Console.ReadLine();
            Console.Write("Informe a quantidade do jogo: ");
            int qtd = int.Parse(Console.ReadLine());
            Console.Write("Informe o preço do jogo: ");
            double preco = double.Parse(Console.ReadLine());
            Console.Write("Informe a marca do jogo: ");
            string marca = Console.ReadLine();

            jogos[quantidade] = new Jogo(nome, qtd, preco, marca);
            quantidade++;

            Console.Write("Deseja continuar adicionando jogos? (S/N): ");
            if (Console.ReadLine().ToUpper() != "S") break;
        }
    }

    public void ExibirEstoque()
    {
        foreach (var jogo in jogos.Take(quantidade))
        {
            Console.WriteLine("--------");
            Console.WriteLine(jogo);
            Console.WriteLine("--------");
        }
    }

    public void ProcessarCompras()
    {
        while (true)
        {
            if (quantidade == 0)
            {
                Console.WriteLine("Não há mais jogos no estoque. Sistema será fechado.");
                return;
            }

            Console.Write("Qual jogo você deseja? ");
            string jogoDesejado = Console.ReadLine().ToUpper();
            var jogo = jogos.Take(quantidade).FirstOrDefault(j => j.Nome == jogoDesejado);

            if (jogo == null)
            {
                Console.WriteLine("Este jogo não existe no estoque.");
                continue;
            }

            if (jogo.Quantidade == 0)
            {
                Console.WriteLine($"O jogo {jogo.Nome} não está mais disponível no estoque.");
                continue;
            }

            Console.WriteLine(jogo);
            Console.Write("Deseja comprar o jogo? (S/N): ");
            if (Console.ReadLine().ToUpper() != "S") continue;

            int quantidadeComprar;
            while (true)
            {
                Console.Write("Informe a quantidade de unidades a serem compradas: ");
                quantidadeComprar = int.Parse(Console.ReadLine());
                if (quantidadeComprar <= jogo.Quantidade)
                {
                    break;
                }
                Console.WriteLine($"Só temos {jogo.Quantidade} unidades disponíveis.");
            }

            Console.Write("Informe a distância a ser percorrida (km): ");
            double distancia = double.Parse(Console.ReadLine());

            jogo.Quantidade -= quantidadeComprar;
            Console.WriteLine("Compra realizada com sucesso!");
            if (jogo.Quantidade == 0)
            {
                RemoverJogo(Array.IndexOf(jogos, jogo));
            }
            ExibirEstoque();

            double frete = Frete.CalcularFrete(jogo, quantidadeComprar, distancia);
            double precoFinal = Frete.PrecoFinal(jogo, quantidadeComprar, frete);

            Console.WriteLine($"Frete: {frete:C}");
            Console.WriteLine($"Jogo: {jogo.Preco * quantidadeComprar:C}");
            Console.WriteLine($"Preço final com frete: {precoFinal:C}");

            return;
        }
    }

    public void RemoverJogo(int indice)
    {
        for (int i = indice; i < quantidade - 1; i++)
        {
            jogos[i] = jogos[i + 1];
        }
        jogos[quantidade - 1] = null;
        quantidade--;
    }
}
