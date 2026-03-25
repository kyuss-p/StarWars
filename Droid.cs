using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars
{
    public abstract class Droid : Character
    {
        private int _batteryLevel;
        public int BatteryLevel 
        {
            get
            {
                return _batteryLevel;
            }
            set
            {
                if (value < 0)
                {
                    _batteryLevel = 0;
                } else if (value > 100)
                {
                    _batteryLevel = 100;
                } else
                {
                    _batteryLevel = value;
                }
            }
        }

        public Droid(int attackPower, int defense, string name, int batteryLevel) : base(attackPower, defense, name)
        {
            BatteryLevel = batteryLevel;
        }

        public void Recharge()
        {
            BatteryLevel = 100;
            Console.WriteLine($"{Name} is recharging");
        }

        public override void Attack(Character target)
        {
            if (BatteryLevel < 10)
            {
                Console.WriteLine($"{Name}´s battery is empty");
                return;
            }
            BatteryLevel -= 10;
            base.Attack(target);
        }

        public abstract void DroidAbility(Character target);
    }
}
