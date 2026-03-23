using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace StarWars
{
    public class SithApprentice : Sith
    {
        public Sith Master { get; set; }

        public SithApprentice(int attackPower, int defense, string name, int rageLevel, Sith master) : base(attackPower, defense, name, rageLevel)
        {
            Health = 80;
            Master = master;
        }

        public override void ForceAbility(Character target)
        {
            if (!IsAlive)
            {
                return;
            }

            int cost = 15;
            if (cost > RageLevel)
            {
                Console.WriteLine("Rage Level not high enough to use Force Drain");
                return;
            }
            RageLevel -= cost;

            int healthBefore = Health;
            int baseDamage = 12;
            int damage = (int)(baseDamage * (1 + (RageLevel / 100.0)));
            Health = Math.Min(100, Health + damage);
            int actualHeal = Health - healthBefore;

            Console.WriteLine($"{Name} used Force Drain on {target.Name} dealing {damage} damage and gaining {damage} HP");
            target.TakeDamage(damage);
        }

        public override string ToString()
        {
            return base.ToString() + $" | Master: {Master.Name}";
        }
    }
}
