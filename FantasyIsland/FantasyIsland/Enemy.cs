using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyIsland
{
    public abstract class Enemy : Player
    {
        protected Magic magic;

        public Enemy(PlayerStats stats, Armor armor, Weapon weapon, Magic magic)
            : base(stats, armor, weapon)
        {
            this.magic = magic;
        }
    }
}
