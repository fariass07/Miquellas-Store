using System;

namespace Miquellas_Store;
public class Jogo
{
    public string Nome { get; set; }
    public int Quantidade { get; set; }
    public double Peso { get; set; }
    public double Preco { get; set; }
    public string Marca { get; set; }

    public Jogo(string nome, int quantidade, double preco, string marca)
    {
        Nome = nome.ToUpper();
        Quantidade = quantidade;
        Peso = 0.36;
        Preco = preco;
        Marca = marca.ToUpper();
    }

    public override string ToString()
    {
        return $"Nome: {Nome}, Quantidade: {Quantidade}, Peso: {Peso}kg, Preço: {Preco:C}, Marca: {Marca}";
    }
}
