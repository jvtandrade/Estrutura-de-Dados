public class PokemonAgua : Pokemon
{
    public PokemonAgua(string nome, int vida, int ataque, int defesa)
        : base(nome, "Agua", vida, ataque, defesa)
    {
    }

    // pokemon de água recupera vida após atacar
    public override void Atacar(Pokemon alvo)
    {
        int dano = Ataque - alvo.Defesa;

        if (dano < 1)
            dano = 1;

        alvo.Vida -= dano;

        if (alvo.Vida < 0)
            alvo.Vida = 0;

        Vida += 2;

        Console.WriteLine($"{Nome} atacou {alvo.Nome} e recuperou 2 de vida.");
    }
}