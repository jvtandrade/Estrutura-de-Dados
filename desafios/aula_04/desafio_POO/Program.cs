using System;

class Program
{
    static void Main()
    {
        // cria os treinadores
        Treinador ash = new Treinador("Ash");
        Treinador misty = new Treinador("Misty");

        // adiciona os pokemons do Ash
        ash.AdicionarPokemon(
            new PokemonFogo("Charmander", 20, 8, 2));

        ash.AdicionarPokemon(
            new PokemonGrama("Bulbasaur", 25, 7, 3));

        // adiciona os pokemons da Misty
        misty.AdicionarPokemon(
            new PokemonAgua("Squirtle", 22, 7, 2));

        misty.AdicionarPokemon(
            new PokemonGrama("Oddish", 18, 6, 2));

        // escolhe os pokemons da batalha
        Pokemon p1 = ash.EscolherPokemon(0);
        Pokemon p2 = misty.EscolherPokemon(0);

        Console.WriteLine($"{ash.Nome} escolheu {p1.Nome}!");
        Console.WriteLine($"{misty.Nome} escolheu {p2.Nome}!");

        Console.WriteLine();
        Console.WriteLine("=== Inicio da batalha ===");
        Console.WriteLine();

        // batalha por turnos
        while (p1.Vida > 0 && p2.Vida > 0)
        {
            p1.Atacar(p2);

            // mostra a vida restante do adversário
            Console.WriteLine($"{p2.Nome} ficou com {p2.Vida} de vida.");

            if (p2.Vida <= 0)
                break;

            Console.WriteLine();

            p2.Atacar(p1);

            // mostra a vida restante do adversário
            Console.WriteLine($"{p1.Nome} ficou com {p1.Vida} de vida.");

            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine("=== Fim da batalha ===");

        // exibe o vencedor
        if (p1.Vida > 0)
            Console.WriteLine($"{p1.Nome} venceu a batalha!");
        else
            Console.WriteLine($"{p2.Nome} venceu a batalha!");
    }
}