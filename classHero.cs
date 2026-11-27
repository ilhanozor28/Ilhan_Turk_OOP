using System;

public class Hero
{
    public int hp;
    public string name = "";
    public int winCount;
    public int power;

    static Random rnd = new Random();
    public Hero() { }
    public Hero(string name, int hp, int power)
    {
        this.name = name;
        this.hp = hp;
        this.power = power;
        this.winCount = 0;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"{name} | HP: {hp} | Power:{power} | Wins:{winCount}");
    }
    public void TakeDmg(int amount)
    {
        hp -= amount;
        if (hp < 0) hp = 0;
    }
    public void Heal()
    {
        hp = 100;
    }
    public bool IsAlive()
    {
        return hp > 0;
    }
    public void Attack(Hero target)
    {
        int damage = power + rnd.Next(-5, 6);
        if (damage < 0) damage = 0;
        target.TakeDmg(damage);
        Console.WriteLine($"{name} hits {target.name}: - {damage} ({target.name}'s {target.hp})");
    }
}