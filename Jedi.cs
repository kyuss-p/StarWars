using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars
{
    internal class Jedi : Character
    {
        private int _forcePoints;
        public int ForcePoints 
        { 
            get
            {
                return _forcePoints;
            }
            set
            {
                if (value < 0)
                {
                    _forcePoints = 0;
                } else if (value > 100)
                {
                    _forcePoints = 100;
                } else
                {
                    _forcePoints = value;
                }
            }
        }

        public Jedi(int health, int attackPower, int defense, string name, int forcePoints) : base(health, attackPower, defense, name)
        {
            ForcePoints = forcePoints;
        }

        public override void SpecialAbility(Character target)
        {
            if (!IsAlive)
            {
                return;
            } 

            int cost = 20;
            int baseHeal = 15;
            int healthBefore = target.Health;

            if (cost > _forcePoints)
            {
                Console.WriteLine("Not enough Force Points to use Force Heal");
                return;
            }

            ForcePoints -= cost;
            int healing = (int)(baseHeal * (1 + (ForcePoints / 100.0)));
            target.Health = Math.Min(100, target.Health + healing);

            int actualHeal = target.Health - healthBefore;
            if (target == this)
            {
                Console.WriteLine($"{Name} used force healing and gains {actualHeal} HP");
            }
            else
            {
                Console.WriteLine($"{Name} used force healing and heals {target.Name} for {actualHeal} HP");
            }
        }

        public override string ToString()
        {
            return base.ToString() + $" | Force Points: {ForcePoints}";
        }
    }
}
