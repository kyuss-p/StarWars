using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars
{
    public class AstroDroid : Droid
    {
        public string Unit { get; set; }

        public AstroDroid(int attackPower, int defense, string name, string unit) : base(attackPower, defense, name)
        {
            Unit = unit;
        }

        public override void DroidAbility(Character target)
        {
            if (!IsAlive)
            {
                return;
            }

            int cost = 25;
            if (cost > BatteryLevel)
            {
                Console.WriteLine($"{Name} does not have enough battery to use Shock");
                return;
            }
            BatteryLevel -= cost;

            int newDefense = target.Defense / 2;
            Console.WriteLine($"{Name} uses Shock on {target.Name} and lowers his defense to {newDefense}");
            target.Defense = newDefense;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Unit: {Unit}";
        }
    }
}
