using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace StarWars
{
    public class Padawan : Jedi
    {
        public Jedi Master { get; set; }

        public Padawan(int attackPower, int defense, string name, int forcePoints, Jedi master) : base(attackPower, defense, name, forcePoints)
        {
            Health = 75;
            Master = master;
        }

        public override void ForceAbility(Character target)
        {
            if (!IsAlive)
            {
                return;
            }

            int cost = 15; 
            if (cost > ForcePoints)
            {
                Console.WriteLine($"{Name} does not have enough Force Points to use Force Push");
                return;
            }
            ForcePoints -= cost;

            int damage = (int)(10 * (1 + ForcePoints / 100.0));
            Console.WriteLine($"{Name} used Force Push on {target.Name} and deals {damage} damage");
            target.TakeDamage(damage);
            target.Defense = Math.Max(0, target.Defense - 10);
        }

        public override string ToString()
        {
            return base.ToString() + $" | Master: {Master.Name}";
        }
    }
}
