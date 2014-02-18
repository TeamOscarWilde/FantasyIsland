using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyIsland
{
    public class Hero : Player
    {
        protected SuperPower powers;

        public Hero(PlayerStats stats, Armor armor, Weapon weapon, SuperPower power)
            : base(stats, armor, weapon)
        {
            this.powers = power;
        }
    }
}
