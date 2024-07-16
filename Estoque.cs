using System;

public class Estoque
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
        while (quantidade < jogos.Length)
        {
            Console.Write("Informe o nome do jogo: ");
            string nome = Console.ReadLine();
            Console.Write("Informe a quantidade do jogo: ");
            int qtd = int.Parse(Console.ReadLine());
            Console.Write("Informe o peso do jogo: ");
            double peso = double.Parse(Console.ReadLine());
            Console.Write("Informe o preço do jogo: ");
            double preco = double.Parse(Console.ReadLine());
            Console.Write("Informe a marca do jogo: ");
            string marca = Console.ReadLine();

            jogos[quantidade] = new Jogo(nome, qtd, peso, preco, marca);
            quantidade++;

            if (!DesejaContinuar())
            {
                break;
            }
        }
    }

    public void ExibirEstoque()
    {
        Console.WriteLine("--------------------");
        Console.WriteLine("Estoque de jogos:");
        for (int i = 0; i < quantidade; i++)
        {
            Console.WriteLine(jogos[i]);
        }
        Console.WriteLine("--------------------");
    }

    public bool DesejaContinuar()
    {
        Console.Write("Deseja continuar adiciona jogos? (S/N): ");
        string resposta = Console.ReadLine().ToUpper();
        return resposta.Equals("S", StringComparison.OrdinalIgnoreCase);
    }
}