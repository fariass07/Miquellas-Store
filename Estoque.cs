using System;
using System.Linq;

namespace Miquellas_Store
{
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
                try
                {
                    Console.Write("Informe o nome do jogo: ");
                    string nome = Console.ReadLine();

                    
                    if (jogos.Take(quantidade).Any(j => j != null && j.Nome == nome))
                    {
                        Console.WriteLine("Erro: Este jogo j� est� adicionado ao estoque.");
                        continue;
                    }

                    Console.Write("Informe a quantidade do jogo: ");
                    int qtd = int.Parse(Console.ReadLine());
                    if (qtd <= 0)
                    {
                        Console.WriteLine("Erro: A quantidade de jogos deve ser maior que zero.");
                        continue;
                    }

                    Console.Write("Informe o pre�o do jogo: ");
                    double preco = double.Parse(Console.ReadLine());
                    if (preco <= 0)
                    {
                        Console.WriteLine("Erro: O pre�o do jogo deve ser maior que zero.");
                        continue;
                    }

                    Console.Write("Informe a marca do jogo: ");
                    string marca = Console.ReadLine();

                    jogos[quantidade] = new Jogo(nome, qtd, preco, marca);
                    quantidade++;

                    while (true)
                    {
                        Console.Write("Deseja continuar adicionando jogos? (S/N): ");
                        string resposta = Console.ReadLine().ToUpper();
                        if (resposta == "S")
                        {
                            break;
                        }
                        else if (resposta == "N")
                        {
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Erro: Resposta inv�lida. Por favor, digite 'S' para Sim ou 'N' para N�o.");
                        }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Erro: Valor inserido n�o � v�lido. Por favor, insira um valor num�rico correto.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Erro: Valor inserido � muito grande para ser armazenado. Por favor, insira um valor menor.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro inesperado: {ex.Message}");
                }
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
                try
                {
                    if (quantidade == 0)
                    {
                        Console.WriteLine("N�o h� mais jogos no estoque. Sistema ser� fechado.");
                        return;
                    }

                    Console.Write("Qual jogo voc� deseja? ");
                    string jogoDesejado = Console.ReadLine().ToUpper();
                    var jogo = jogos.Take(quantidade).FirstOrDefault(j => j.Nome == jogoDesejado);

                    if (jogo == null)
                    {
                        Console.WriteLine("Este jogo n�o existe no estoque.");
                        continue;
                    }

                    if (jogo.Quantidade == 0)
                    {
                        Console.WriteLine($"O jogo {jogo.Nome} n�o est� mais dispon�vel no estoque.");
                        continue;
                    }

                    Console.WriteLine(jogo);
                    Console.Write("Deseja comprar o jogo? (S/N): ");
                    string resposta = Console.ReadLine().ToUpper();
                    if (resposta != "S" && resposta != "N")
                    {
                        Console.WriteLine("Erro: Resposta inv�lida. Por favor, digite 'S' para Sim ou 'N' para N�o.");
                        continue;
                    }
                    if (resposta == "N")
                    {
                        continue;
                    }

                    int quantidadeComprar;
                    while (true)
                    {
                        try
                        {
                            Console.Write("Informe a quantidade de unidades a serem compradas: ");
                            quantidadeComprar = int.Parse(Console.ReadLine());
                            if (quantidadeComprar <= 0)
                            {
                                Console.WriteLine("Erro: A quantidade de unidades deve ser maior que zero.");
                                continue;
                            }
                            if (quantidadeComprar > jogo.Quantidade)
                            {
                                Console.WriteLine($"Erro: S� temos {jogo.Quantidade} unidades dispon�veis.");
                                continue;
                            }
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Erro: Valor inserido n�o � v�lido. Por favor, insira um valor num�rico correto.");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Erro: Valor inserido � muito grande para ser armazenado. Por favor, insira um valor menor.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro inesperado: {ex.Message}");
                        }
                    }

                    Console.Write("Informe a dist�ncia a ser percorrida (km): ");
                    double distancia = double.Parse(Console.ReadLine());
                    if (distancia < 0)
                    {
                        Console.WriteLine("Erro: A dist�ncia n�o pode ser negativa.");
                        continue;
                    }

                    jogo.Quantidade -= quantidadeComprar;
                    Console.WriteLine("Compra realizada com sucesso!");
                    if (jogo.Quantidade == 0)
                    {
                        RemoverJogo(Array.IndexOf(jogos, jogo));
                    }
                    ExibirEstoque();

                    double frete = Frete.CalcularFrete(jogo, quantidadeComprar, distancia);
                    if (frete < 0)
                    {
                        Console.WriteLine("Erro: O valor do frete n�o pode ser negativo.");
                        continue;
                    }

                    double precoFinal = Frete.PrecoFinal(jogo, quantidadeComprar, frete);

                    Console.WriteLine($"Frete: {frete:C}");
                    Console.WriteLine($"Jogo: {jogo.Preco * quantidadeComprar:C}");
                    Console.WriteLine($"Pre�o final com frete: {precoFinal:C}");

                    return;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Erro: Valor inserido n�o � v�lido. Por favor, insira um valor num�rico correto.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Erro: Valor inserido � muito grande para ser armazenado. Por favor, insira um valor menor.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro inesperado: {ex.Message}");
                }
            }
        }

        public void RemoverJogo(int indice)
        {
            if (indice < 0 || indice >= quantidade)
            {
                throw new ArgumentOutOfRangeException("�ndice fora dos limites do array.");
            }

            for (int i = indice; i < quantidade - 1; i++)
            {
                jogos[i] = jogos[i + 1];
            }
            jogos[quantidade - 1] = null;
            quantidade--;
        }
    }
}
