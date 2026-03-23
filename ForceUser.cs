using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars
{
    public abstract class ForceUser : Character
    {
        protected ForceUser(int attackPower, int defense, string name) : base(attackPower, defense, name)
        {

        }

        public abstract void ForceAbility(Character target);
    }
}
