public class PokemonFogo : Pokemon
{
    public PokemonFogo(string nome, int vida, int ataque, int defesa)
        : base(nome, "Fogo", vida, ataque, defesa)
    {
    }

    // pokemon de fogo causa +2 de dano
    public override void Atacar(Pokemon alvo)
    {
        int dano = (Ataque - alvo.Defesa) + 2;

        if (dano < 1)
            dano = 1;

        alvo.Vida -= dano;

        if (alvo.Vida < 0)
            alvo.Vida = 0;

        Console.WriteLine($"{Nome} lançou chamas e causou {dano} de dano.");
    }
}