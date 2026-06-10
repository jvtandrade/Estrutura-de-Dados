public class Pokemon
{
    public string Nome { get; set; }
    public string Tipo { get; set; }
    public int Vida { get; set; }
    public int Ataque { get; set; }
    public int Defesa { get; set; }

   
    public Pokemon(string nome, string tipo, int vida, int ataque, int defesa)
    {
        Nome = nome;
        Tipo = tipo;
        Vida = vida;
        Ataque = ataque;
        Defesa = defesa;
    }

    // exibe as informações do pokemon
    public void ExibirStatus()
    {
        Console.WriteLine($"{Nome} | Tipo: {Tipo} | Vida: {Vida}");
    }

    // ataque padrão
    public virtual void Atacar(Pokemon alvo)
    {
        int dano = Ataque - alvo.Defesa;

        if (dano < 1)
            dano = 1;

        alvo.Vida -= dano;

        // evita vida negativa
        if (alvo.Vida < 0)
            alvo.Vida = 0;

        Console.WriteLine($"{Nome} atacou {alvo.Nome} e causou {dano} de dano.");
    }
}