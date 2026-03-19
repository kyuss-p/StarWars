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

        public Jedi(int forcePoints, int health, int attackPower, int defense, string name) : base(health, attackPower, defense, name)
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
            int healing = 25;

            if (cost > _forcePoints)
            {
                Console.WriteLine("Not enough force points to use special ability");
                return;
            }

            ForcePoints -= cost;
            Health = Math.Min(100, Health + healing);
            Console.WriteLine($"{Name} uses force healing and gains {healing} HP");
        }

        public override string ToString()
        {
            return base.ToString() + $" | Force Points: {ForcePoints}";
        }
    }
}
