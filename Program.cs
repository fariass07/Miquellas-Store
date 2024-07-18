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