using System;

class Program
{
    static void Main(string[] args)
    {
        Estoque estoque = new Estoque(50);
        estoque.PreencherEstoque();
        estoque.ExibirEstoque();
        Console.WriteLine("Fim...");
    }
}

class Jogo
{
    public string Nome { get; set; }
    public int Quantidade { get; set; }
    public double Peso { get; set; }
    public double Preco { get; set; }
    public double Distancia { get; set; }
    public string Marca { get; set; }

    public Jogo(string nome, int quantidade, double peso, double preco, double distancia, string marca)
    {
        Nome = nome.ToUpper();
        Quantidade = quantidade;
        Peso = peso;
        Preco = preco;
        Distancia = distancia;
        Marca = marca.ToUpper();
    }

    public override string ToString()
    {
        return $"Nome: {Nome}, Quantidade: {Quantidade}, Peso: {Peso}kg, Preço: {Preco:C}, Distância: {Distancia}km, Marca: {Marca}";
    }
}

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
        for (int i = 0; i < jogos.Length; i++)
        {
            Console.Write("Informe o nome do jogo: ");
            string nome = Console.ReadLine();
            Console.Write("Informe a quantidade do jogo: ");
            int qtd = int.Parse(Console.ReadLine());
            Console.Write("Informe o peso do jogo: ");
            double peso = double.Parse(Console.ReadLine());
            Console.Write("Informe o preço do jogo: ");
            double preco = double.Parse(Console.ReadLine());
            Console.Write("Informe a distância do jogo: ");
            double distancia = double.Parse(Console.ReadLine());
            Console.Write("Informe a marca do jogo: ");
            string marca = Console.ReadLine();

            jogos[quantidade] = new Jogo(nome, qtd, peso, preco, distancia, marca);
            quantidade++;

            if (i >= 1)
            {
                if (!DesejaContinuar())
                {
                    break;
                }
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

    public static bool DesejaContinuar()
    {
        Console.Write("Deseja continuar adiciona jogos? (S/N): ");
        string resposta = Console.ReadLine().ToUpper();
        return resposta.Equals("S", StringComparison.OrdinalIgnoreCase);
    }
}
