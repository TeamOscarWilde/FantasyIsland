
/* The player has player stats that reffer only to his type of hero 
 * and total stats that are calculated from his personal stats and the stats of his weapons, armor, etc. */

namespace FantasyIsland
{
    public class Player
    {
        #region Fields
        private PlayerStats playerStats;
        private Armor armor;
        private Weapon weapon;
        private PlayerStats totalStats; 
        #endregion

        #region Constructors
        public Player(PlayerStats playerStats, Armor armor, Weapon weapon)
        {
            this.PlayerStats = playerStats;
            this.Armor = armor;
            this.Weapon = weapon;

            int totalAttackPower = playerStats.AttackPower + weapon.WeaponStats.AttackPower;
            int totalAccuracy = playerStats.Accuracy + weapon.WeaponStats.Accuracy;
            int totalDefence = playerStats.Defence + armor.Strength + weapon.WeaponStats.Defence;
            int totalAgility = playerStats.Agility - armor.Weight;

            this.TotalStats = new PlayerStats(totalAttackPower, totalAccuracy, totalDefence, playerStats.Stamina, totalAgility);
        } 
        #endregion

        #region Properties
        public PlayerStats PlayerStats
        {
            get
            {
                return new PlayerStats(this.playerStats.AttackPower, this.playerStats.Accuracy, 
                    this.playerStats.Defence, this.playerStats.Stamina, this.playerStats.Agility);
            }
            private set
            {
                this.playerStats = value;
            }
        }

        public Armor Armor
        {
            get
            {
                return new Armor(this.armor.Weight, this.armor.Strength);
            }
            private set
            {
                this.armor = value;
            }
        }

        public Weapon Weapon
        {
            get
            {
                return new Weapon(this.weapon.WeaponStats.AttackPower, this.weapon.WeaponStats.Accuracy, 
                    this.weapon.WeaponStats.Defence);
            }
            private set
            {
                this.weapon = value;
            }
        }

        public PlayerStats TotalStats
        {
            get
            {
                return new PlayerStats(this.totalStats.AttackPower, this.totalStats.Accuracy, 
                    this.totalStats.Defence, this.totalStats.Stamina, this.totalStats.Agility);
            }
            private set
            {
                this.totalStats = value;
            }
        }
        #endregion
    }
}
