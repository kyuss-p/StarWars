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
                    _health = 80;
                } else
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
                if (value < 1)
                {
                    _attackPower = 1;
                } else if (value > 50)
                {
                    _attackPower = 50;
                } else
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
                } else if (value > 40)
                {
                    _defense = 40;
                } else
                {
                    _defense = value;
                }
            }
        }

        public string Name { get; set; }

        public bool IsAlive
        {
            get
            {
                return _health > 0;
            }
        }

        protected Character(int health, int attackPower, int defense, string name)
        {
            Health = health;
            AttackPower = attackPower;
            Defense = defense;
            Name = name;
        }

        public virtual void Attack(Character target)
        {
            int damage = _attackPower - target._defense;
            damage = Math.Max(0, damage);
            TakeDamage(damage);
            Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage ");
        }

        public void TakeDamage(int damage)
        {
            _health -= Math.Max(0, _health - damage);
        }

        public abstract void SpecialAbility(Character target);

        public override string ToString()
        {
            return $"[{GetType().Name}] {Name} | Health: {Health} | Attack Power: {AttackPower} | Defense: {Defense}";
        }
    }
}
