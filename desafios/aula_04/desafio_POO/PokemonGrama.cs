public class PokemonGrama : Pokemon
{
    private static Random random = new Random();

    public PokemonGrama(string nome, int vida, int ataque, int defesa)
        : base(nome, "Grama", vida, ataque, defesa)
    {
    }

    // pokemon de grama possui chance de crítico
    public override void Atacar(Pokemon alvo)
    {
        int dano = Ataque - alvo.Defesa;

        if (dano < 1)
            dano = 1;

        // 20% de chance de crítico
        if (random.Next(100) < 20)
        {
            dano *= 2;
            Console.WriteLine("Ataque crítico!");
        }

        alvo.Vida -= dano;

        if (alvo.Vida < 0)
            alvo.Vida = 0;

        Console.WriteLine($"{Nome} atacou {alvo.Nome} causando {dano} de dano.");
    }
}