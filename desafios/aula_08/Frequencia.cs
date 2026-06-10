using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int opcao = 0;

        // guarda a frequência das palavras do texto atual
        Dictionary<string, int> frequencia = new Dictionary<string, int>();

        // guarda os textos digitados para comparação futura
        List<HashSet<string>> historicoTextos = new List<HashSet<string>>();

        while (opcao != 4)
        {
            Console.WriteLine("\n===== MENU =====");
            Console.WriteLine("1 - Novo texto");
            Console.WriteLine("2 - Buscar palavra");
            Console.WriteLine("3 - Comparar textos");
            Console.WriteLine("4 - Sair");

            Console.Write("Escolha uma opção: ");
            opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                frequencia.Clear();

                string textoCompleto = "";

                Console.WriteLine("\nDigite o texto (linha vazia para encerrar):");

                while (true)
                {
                    string linha = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(linha))
                        break;

                    textoCompleto += linha + " ";
                }

                // transforma tudo em minúsculo
                textoCompleto = textoCompleto.ToLower();

                // remove pontuações
                textoCompleto = textoCompleto.Replace(".", "");
                textoCompleto = textoCompleto.Replace(",", "");
                textoCompleto = textoCompleto.Replace("!", "");
                textoCompleto = textoCompleto.Replace("?", "");
                textoCompleto = textoCompleto.Replace(":", "");
                textoCompleto = textoCompleto.Replace(";", "");

                // separa o texto em palavras
                string[] palavras = textoCompleto.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int totalPalavras = 0;

                // conjunto usado pra comparação entre textos
                HashSet<string> palavrasDoTexto = new HashSet<string>();

                foreach (string palavra in palavras)
                {
                    totalPalavras++;

                    palavrasDoTexto.Add(palavra);

                    // se a palavra já existe, soma 1
                    if (frequencia.ContainsKey(palavra))
                    {
                        frequencia[palavra]++;
                    }
                    else
                    {
                        frequencia[palavra] = 1;
                    }
                }

                // guarda o texto 
                historicoTextos.Add(palavrasDoTexto);

                Console.WriteLine("\n===== RESULTADO =====");
                Console.WriteLine($"Total de palavras: {totalPalavras}");
                Console.WriteLine($"Palavras distintas: {frequencia.Count}");

                Console.WriteLine("\nTop 10 palavras mais frequentes:");

                int posicao = 1;

                foreach (var item in frequencia
                         .OrderByDescending(x => x.Value)
                         .Take(10))
                {
                    Console.WriteLine($"{posicao}. {item.Key} - {item.Value} ocorrencias");
                    posicao++;
                }
            }

            else if (opcao == 2)
            {
                Console.Write("\nQual palavra deseja buscar? ");

                string palavraBusca = Console.ReadLine().ToLower();

                if (frequencia.ContainsKey(palavraBusca))
                {
                    Console.WriteLine(
                        $"A palavra \"{palavraBusca}\" apareceu {frequencia[palavraBusca]} vezes.");
                }
                else
                {
                    Console.WriteLine("Essa palavra não apareceu no texto.");
                }
            }

            else if (opcao == 3)
            {
                // precisa existir dois textos pra comparar
                if (historicoTextos.Count < 2)
                {
                    Console.WriteLine("Cadastre pelo menos dois textos antes de comparar.");
                    continue;
                }

                HashSet<string> texto1 =
                    new HashSet<string>(historicoTextos[historicoTextos.Count - 2]);

                HashSet<string> texto2 =
                    historicoTextos[historicoTextos.Count - 1];

                // mantém só as palavras que existem nos dois textos
                texto1.IntersectWith(texto2);

                Console.WriteLine("\nPalavras em comum:");

                foreach (string palavra in texto1)
                {
                    Console.WriteLine(palavra);
                }
            }

            else if (opcao == 4)
            {
                Console.WriteLine("Tchau!");
            }

            else
            {
                Console.WriteLine("Opção inválida.");
            }
        }
    }
}