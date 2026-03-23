using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace StarWars
{
    public abstract class BlasterUser : Character
    {
        private int _ammo;

        public int Ammo 
        {
            get
            {
                return _ammo;
            }
            set
            {
                if (value < 0)
                {
                    _ammo = 0;
                }
                else if (value > 30)
                {
                    _ammo = 30;
                }
                else
                {
                    _ammo = value;
                }
            }
        }

        public BlasterUser(int attackPower, int defense, string name) : base(attackPower, defense, name)
        {
            Ammo = 30;
        }

        public void Reload()
        {
            Ammo = 30;
            Console.WriteLine($"{Name} is reloading");
        }

        public override void Attack(Character target)
        {
            if (Ammo < 5)
            {
                Console.WriteLine($"{Name} is out of ammo");
                return;
            }
            Ammo -= 5;
            base.Attack(target);
        }

        public abstract void SpecialAbility(Character target);
    }
}
