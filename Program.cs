using System;

namespace Miquellas_Store;
class Program
{
    static void Main(string[] args)
    {
        Estoque estoque = new Estoque(50);
        estoque.PreencherEstoque();
        estoque.ExibirEstoque();
        estoque.ProcessarCompras();
        Console.WriteLine("Fim...");
    }
}