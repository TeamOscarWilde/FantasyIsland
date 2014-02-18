using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyIsland
{
    public class Player
    {
        protected PlayerStats playerStats;
        protected Armor armor;
        protected Weapon weapon;
        protected PlayerStats totalStats;

        public Player(PlayerStats playerStats, Armor armor, Weapon weapon)
        {
            this.playerStats = playerStats;
            this.armor = armor;
            this.weapon = weapon;
            int totalAttack = playerStats.AttackPower + weapon.WeaponStats.AttackPower;
            int totalDefence = playerStats.Defence + armor.Strength + weapon.WeaponStats.Defence;
            int totalStamina = playerStats.Stamina - armor.Weight;
            int totalAccuracy = playerStats.Accuracy + weapon.WeaponStats.Accuracy;
            this.totalStats = new PlayerStats(totalAttack, totalAccuracy, totalDefence, totalStamina, playerStats.Agility);
        }

        public PlayerStats Stats
        {
            get { return this.playerStats; }
            private set { this.playerStats = value; }
        }
    }
}
