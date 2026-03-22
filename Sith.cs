using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars
{
    internal class Sith : Character
    {
        private int _rageLevel;
        public int RageLevel 
        {
            get
            {
                return _rageLevel;
            }
            set
            {
                if (value < 0)
                {
                    _rageLevel = 0;
                }
                else if (value > 100)
                {
                    _rageLevel = 100;
                }
                else
                {
                    _rageLevel = value;
                }
            }
        }

        public Sith(int health, int attackPower, int defense, string name, int rageLevel) : base(health, attackPower, defense, name)
        {
            RageLevel = rageLevel;
        }

        public override void SpecialAbility(Character target)
        {
            if (!IsAlive)
            {
                return;
            }

            int cost = 20;
            int baseDamage = 15;

            if (cost > _rageLevel)
            {
                Console.WriteLine("Rage Level not high enough to use Force Choke");
                return;
            }

            RageLevel -= cost;
            int damage = (int)(baseDamage * (1 + (RageLevel / 100.0)));
            target.Health = Math.Max(0, target.Health - damage);
            Console.WriteLine($"{Name} used force choke and deals {damage} damage to {target.Name}");
        }

        public override string ToString()
        {
            return base.ToString() + $" | Rage Level: {RageLevel}";
        }
    }
}
