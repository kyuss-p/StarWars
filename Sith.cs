using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StarWars
{
    internal class Sith : ForceUser
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

        public Sith(int attackPower, int defense, string name, int rageLevel) : base(attackPower, defense, name)
        {
            RageLevel = rageLevel;
        }

        public override void ForceAbility(Character target)
        {
            if (!IsAlive)
            {
                return;
            }

            int cost = 20;
            int baseDamage = 15;

            if (cost > RageLevel)
            {
                Console.WriteLine("Rage Level not high enough to use Force Choke");
                return;
            }

            RageLevel -= cost;
            int damage = (int)(baseDamage * (1 + (RageLevel / 100.0)));
            Console.WriteLine($"{Name} used Force Choke and deals {damage} damage to {target.Name}");
            target.TakeDamage(Math.Max(0, target.Health - damage));
        }

        public override string ToString()
        {
            return base.ToString() + $" | Rage Level: {RageLevel}";  
        }
    }
}
