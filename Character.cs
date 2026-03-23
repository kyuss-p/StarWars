using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars
{
    public abstract class Character
    {
        private int _health;
        public int Health 
        { 
            get
            {
                return _health;
            }
            set
            {
                if (value < 0)
                { 
                    _health = 0;
                }
                else if (value > 100)
                {
                    
                    _health = 100;
                }
                else
                {
                    _health = value;
                }
            }
        }

        private int _attackPower;
        public int AttackPower 
        { 
            get
            {
                return _attackPower;
            }
            set
            {
                if (value < 0)
                {
                    _attackPower = 0;
                }
                else if (value > 100)
                {
                    _attackPower = 100;
                }
                else
                {
                    _attackPower = value;
                }
            }
        }

        private int _defense;
        public int Defense 
        {
            get
            {
                return _defense;
            } 
            set
            {
                if (value < 0)
                {
                    _defense = 0;
                } else if (value > 100)
                {
                    _defense = 100;
                } else
                {
                    _defense = value;
                }
            }
        }

        public string Name { get; set; }

        public bool IsAlive => Health > 0;

        protected Character(int attackPower, int defense, string name)
        {
            Health = 100;
            AttackPower = attackPower;
            Defense = defense;
            Name = name;
        }

        public virtual void Attack(Character target)
        {
            if (!IsAlive)
            {
                return;
            }

            int damage = (int)(AttackPower * (75.0 / (100 + target.Defense)));
            damage = Math.Max(0, damage);
            Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage ");
            target.TakeDamage(damage);
        }

        public void TakeDamage(int damage)
        {
            Health = Math.Max(0, Health - damage);
            if (!IsAlive)
            {
                Console.WriteLine($"{Name} has died!");
                return;
            }
        }

        public override string ToString()
        {
            return $"[{GetType().Name}] {Name} | Health: {Health} | Attack Power: {AttackPower} | Defense: {Defense}";
        }
    }
}
