using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StarWars
{
    public class Sith : ForceUser
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
            if (cost > RageLevel)
            {
                Console.WriteLine($"{Name}'s Rage Level is not high enough to use Force Choke");
                return;
            }
            RageLevel -= cost;

            int baseDamage = 15;
            int damage = (int)(baseDamage * (1 + (RageLevel / 100.0)));
            Console.WriteLine($"{Name} used Force Choke on {target.Name} and deals {damage} damage");
            target.TakeDamage(damage);
        }

        public override string ToString()
        {
            return base.ToString() + $" | Rage Level: {RageLevel}";  
        }
    }
}
