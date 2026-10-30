// A1:5, A2:Hurt, A3:4, A4:14

//B1
{
    {
      int baseDamage = 40;
      int armor = 15;
      int level = 4;

      int damage = baseDamage - armor;
      if (level >= 5) damage += 10;
      if (damage < 1) damage = 1;

      string damageAmount;
      if (damage >= 30) damageAmount = "Strong Hit";
      else if (damage >= 10) damageAmount = "Normal Hit";
      else damageAmount = "Weak Hit";

      Console.WriteLine($"Damage: {damage} ({damageAmount})");

    }

    {
        int baseDamage = 40;
        int armor = 15;
        int level = 6;

        int damage = baseDamage - armor;
        if (level >= 5) damage += 10;
        if (damage < 1) damage = 1;

        string damageAmount;
        if (damage >= 30) damageAmount = "Strong hit";
        else if (damage >= 10) damageAmount = "Normal hit";
        else damageAmount = "Weak hit";

        Console.WriteLine($"Damage: {damage} ({damageAmount})");


    }

    {
        int baseDamage = 40;
        int armor = 50;
        int level = 4;

        int damage = baseDamage - armor;
        if (level >= 5) damage += 10;
        if (damage < 1) damage = 1;

        string damageAmount;
        if (damage >= 30) damageAmount = "Strong hit";
        else if (damage >= 10) damageAmount = "Normal hit";
        else damageAmount = "Weak hit";

        Console.WriteLine($"Damage: {damage} ({damageAmount})");

    }
}


//B2
{
    int gold = 120;
    int choice = 2;
    string itemName = "";
    int price = 0;

    switch(choice)
    {
        case 1:
            itemName = "Sword";
            price = 100;
            break;
        case 2:
            itemName = "Bow";
            price = 80;
            break;
        case 3:
            itemName = "Potion";
            price = 25;
            break;
        default:
            Console.WriteLine("Invalid choice");
            break;
    }

    if(price > 0)
    {
        if(gold >= price)
        {
            gold -= price;
            Console.WriteLine($"You bought a {itemName}! Gold left: {gold}");
        }
        else
        {
            Console.WriteLine($"Not enough gold! You need {price - gold} more gold.");
        }
    }

}

//B3
{
    for (int wave = 1; wave <= 30; wave++)
    {
        string monster;
        if (wave % 3 == 0 && wave % 5 == 0) monster = "BOSS";
        else if (wave % 3 == 0) monster = "Slime";
        else if (wave % 5 == 0) monster = "Bat";
        else monster = "empty";
        Console.WriteLine($"Wave {wave}: {monster}");
    }
}

//B4
{
    int level = 1;
    int xp = 0;
    int fights = 0;

    while (level <5)
    {
        fights++;
        xp += 35;

        if(xp >= 100)
        {
            xp -= 100;
            level++;
            Console.WriteLine($"LEVEL UP! Now level {level}");
        }
    }
    Console.WriteLine($"Reached level 5 after {fights} fights (xp left: {xp})");
}

//B5
{
    int Clamp(int value, int min, int max)
    {
        if (value < min) return min;
        if (value > max) return max;
        return value;
    }

    Console.WriteLine(Clamp(150, 0, 100));
    Console.WriteLine(Clamp(-20, 0, 100));
    Console.WriteLine(Clamp(55, 0, 100));

    int hp = 80;
    hp = Clamp(hp + 50, 0, 100);
    Console.WriteLine($"HP after potion: {hp}");
}

//B6
{
    string GetRank(int score)
    {
        if (score >= 1000) return "Gold";
        if (score >= 500) return "Silver";
        if (score >= 1) return "Bronze";
        return "No medal";
    }

    for (int score = 0; score <= 1250; score += 250)
    {
        Console.WriteLine($"Score {score}: {GetRank(score)}");
    }
}

//B7
{
    int Attack(int hp, int damage)
    {
        hp -= damage;
        if (hp < 0) hp = 0;
        return hp;
    }

    bool IsAlive(int hp)
    {
        return hp > 0;
    }

    int playerHp = 150;
    int bossHp = 120;
    int turn = 0;

    while (IsAlive(playerHp) && IsAlive(bossHp))
    {
        turn++;

        
        bossHp = Attack(bossHp, 25);

        if (!IsAlive(bossHp))
        {
            Console.WriteLine($"Turn {turn} | Boss: {bossHp}");
            break; 
        }

       
        int bossDamage = (turn % 3 == 0) ? 50 : 25;
        playerHp = Attack(playerHp, bossDamage);

        Console.WriteLine($"Turn {turn} | Boss: {bossHp} | Player: {playerHp}");
    }

    if (IsAlive(playerHp))
        Console.WriteLine($"You win in {turn} turns! HP left: {playerHp}");
    else
        Console.WriteLine($"You lose in {turn} turns! Boss HP left: {bossHp}");
}

//B8
{
    string Hint(int guess, int secret)
    {
        if (guess < secret) return "Too low";
        if (guess > secret) return "Too high";
        return "Correct!";
    }

    int secret = 42;
    
    int maxTries = 5;
    int triesLeft = maxTries;
    int triesUsed = 0;
    bool found = false;

    while (triesLeft > 0 && !found)
    {
        Console.Write($"Guess ({triesLeft} tries left): ");
        string input = Console.ReadLine();

        if (!int.TryParse(input, out int guess))
        {
            Console.WriteLine("Please enter a number.");
            continue;
        }

        triesLeft--;
        triesUsed++;

        string hint = Hint(guess, secret);
        Console.WriteLine(hint);

        if (hint == "Correct!") found = true;
    }

    if (found)
        Console.WriteLine($"You found it in {triesUsed} tries!");
    else
        Console.WriteLine($"You lost! The secret number was {secret}.");
}