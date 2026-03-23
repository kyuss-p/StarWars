using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Text;

namespace StarWars
{
    public class Trooper : BlasterUser
    {
        public string TroopNumber { get; set; }

        public Trooper(int attackPower, int defense, string name, string troopNumber) : base(attackPower, defense, name)
        {
            Health = 80;
            TroopNumber = troopNumber;
        }

        public override void SpecialAbility(Character target)
        {
            if (!IsAlive)
            {
                return;
            }

            int cost = 15;
            if (cost > Ammo)
            {
                Console.WriteLine($"{Name} does not have enough ammo to use his shotgun");
                return;
            }
            Ammo -= cost;

            int damage = (int)(AttackPower * (75.0 / (100 + target.Defense)) * 1.5);
            damage = Math.Max(0, damage);
            Console.WriteLine($"{Name} fires a shotgun blast at {target.Name} for {damage} damage");
            target.TakeDamage(damage);
        }

        public override string ToString()
        {
            return base.ToString() + $" | Ammo: {Ammo} | Troop Number: {TroopNumber}";
        }
    }
}
