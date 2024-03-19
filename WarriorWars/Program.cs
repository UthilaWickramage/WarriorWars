using WarriorWars;
using WarriorWars.Enum;

class Program
{
    static void Main()
    {
        Random random = new Random();
        Warrior goodGuy = new Warrior("John",Faction.GoodGuy);
        Warrior badGuy = new Warrior("Jack",Faction.BadGuy);

        while (goodGuy.IsAlive && badGuy.IsAlive)
        {
            if (random.Next(0, 10) < 5)
            {
                goodGuy.attack(badGuy);
            }
            else
            {
                badGuy.attack(goodGuy);
            }
            Thread.Sleep(50);
        }
    }
}