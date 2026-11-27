using System;

Hero[] heroes= new Hero[5]; 
heroes[0] = new Hero("Hck",100,15);
heroes[1] = new Hero("Oga", 100, 14);
heroes[2] = new Hero("Mami", 100, 13);
heroes[3] = new Hero("Ozor", 100, 16);
heroes[4] = new Hero("Zülüman", 100, 3);

bool running = true;
while (running)
{
    Console.WriteLine("\n 1)List 2)Duel 3)Heal 4)Champion 0)Exit");
    Console.Write(">");
    int.TryParse(Console.ReadLine(), out int choice);
    switch (choice)
    {
        case 1:
            for (int i = 0; i < heroes.Length; i++)
            {
                Console.WriteLine(i + ")");
                heroes[i].ShowInfo();
            }
            break;
            case 2:
            Console.Write("Hero 1 (0-4)?");
            bool ok1=int.TryParse(Console.ReadLine(), out int a);
            Console.Write("Hero 2?");
            bool ok2=int.TryParse(Console.ReadLine(), out int b);
            if (!ok1 || !ok2 || a < 0 || a > 4 || b < 0 || a == b) 
            { 
            Console.WriteLine("Invalid choice!");
                break;
            }
            if(!heroes[a].IsAlive() || heroes[b].IsAlive()) 
            {
                Console.WriteLine("A hero is down. Heal first (3):");
                break;
            }
            while (!heroes[a].IsAlive() && heroes[b].IsAlive())
            {
                heroes[a].Attack(heroes[b]);
                if (heroes[b].IsAlive()) heroes [b].Attack(heroes[a]);
            }
            Hero winner = heroes[a].IsAlive() ? heroes[a]:heroes[b];
            winner.winCount++;
            Console.WriteLine($"{winner.name} wins! (wins: {winner.winCount})");
            break;
            
            case 3:
            for (int i = 0; i < heroes.Length; i++)
            heroes[i].Heal();
            Console.WriteLine("All heroes healed.");
            break;
            case 4:
            Hero champ = heroes [0];
            for (int i = 1; i < heroes.Length; i++)
            {
                if(heroes[i].winCount>champ.winCount)
                    champ = heroes[i];
            }
            Console.WriteLine($"Champion: {champ.name} ({champ.winCount} wins)");
            break;
        case 0:
                running = false;
                break;
            default:
            Console.WriteLine("Unknown Option.");
            break;
    }
}