using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars
{
    internal class BountyHunter : BlasterUser
    {
        public int Kills { get; set; }

        public BountyHunter(int attackPower, int defense, string name) : base(attackPower, defense, name)
        {
            
        }

        public override void Attack(Character target)
        {
            base.Attack(target);
            if (!target.IsAlive)
            {
                Kills++;
            }
        }

        public override void SpecialAbility(Character target)
        {
            if (!IsAlive)
            {
                return;
            }

            int cost = 30;
            if (cost > Ammo)
            {
                Console.WriteLine($"{Name} does not have enough ammo to use his wrist rocket");
                return;
            }
            Ammo -= cost;

            int damage = (int)(AttackPower * (75.0 / (100 + target.Defense)) * 2);
            damage = Math.Max(0, damage);
            Console.WriteLine($"{Name} fires a shotgun blast at {target.Name} for {damage} damage");
            target.TakeDamage(damage);
        }

        public override string ToString()
        {
            return base.ToString() + $" | Kills: {Kills}";
        }
    }
}
