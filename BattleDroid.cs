using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars
{
    public class BattleDroid : Droid
    {
        public string Series { get; set; }

        public BattleDroid(int attackPower, int defense, string name, string series) : base(attackPower, defense, name)
        {
            Series = series;
        }

        public override void DroidAbility(Character target)
        {
            if (!IsAlive)
            {
                return;
            }

            int cost = 20;
            if (cost > BatteryLevel)
            {
                Console.WriteLine($"{Name} does not have enough battery to use Blaster Barage");
                return;
            }
            BatteryLevel -= cost;

            int damage = (int)(AttackPower * (75.0 / (100 + target.Defense)) * 2);
            damage = Math.Max(0, damage);
            Console.WriteLine($"{Name} uses Blaster Barage on {target.Name} and deals {damage} damage");
            target.TakeDamage(damage);
        }

        public override string ToString()
        {
            return base.ToString() + $" | Series: {Series}";
        }
    }
}
