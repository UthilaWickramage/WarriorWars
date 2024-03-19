using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarriorWars.Enum;
using WarriorWars.Equipment;

namespace WarriorWars
{
    class Warrior
    {
        private const int GOOD_GUY_STARTING_HEALTH = 100;
        private const int BAD_GUY_STARTING_HEALTH = 100;


        private readonly Faction FACTION;
        private int health;
        private string name;
        private bool isAlive;

        public bool IsAlive {
            get
            {
                return isAlive;
            }
        }
        private Weapon weapon;
        private Armor armor;

        public Warrior(String name,Faction faction)
        {
            this.name = name;
            FACTION = faction;
            this.isAlive = true;

            switch (faction) {
                case Faction.GoodGuy:
                    armor = new Armor(faction);
                    weapon = new Weapon(faction);
                    health = GOOD_GUY_STARTING_HEALTH;
                    break;
                case Faction.BadGuy:
                    weapon = new Weapon(faction);
                    armor = new Armor(faction);
                    health = BAD_GUY_STARTING_HEALTH;
                    break;
                    default: 
                    break;
}
        }

        public void attack(Warrior enemy)
        {
            int damage = weapon.Damage / enemy.armor.ArmorPoints;

            enemy.health -= damage;

            AttackResult(enemy, damage);
        }

        private void AttackResult(Warrior enemy, int damage)
        {
            if (enemy.health <= 0)
            {
                enemy.isAlive = false;
                Tools.colorfulLine($"{enemy.name} is dead!", ConsoleColor.Red);
                Tools.colorfulLine($"{name} is victorious", ConsoleColor.Green);
            }
            else
            {
                Console.WriteLine($"{name} just attacked {enemy.name} inflicted a damage of {damage}, The health is {enemy.health}");
            }
        }
    }
}
