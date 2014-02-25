
/* The stamina of the player shows his current health condition. 
 * The agility shows how quick the player is to avoid attacks. */

namespace FantasyIsland
{
    using System;

    public class PlayerStats : Stats
    {
        #region Constants
        private readonly int InitialHealth;
        #endregion

        #region Static Fields
        private static PlayerStats elf;
        private static PlayerStats human;
        private static PlayerStats dwarf;
        private static PlayerStats humanEatingPlant;
        private static PlayerStats witch;
        private static PlayerStats zombie;
        private static PlayerStats flyingDemon;
        private static PlayerStats dragon;
        #endregion

        #region Fields
        private int stamina;
        private int agility;
        #endregion

        #region Static Constructors
        static PlayerStats()
        {
            elf = new PlayerStats(30, 35, 40, 75, 85);
            human = new PlayerStats(45, 35, 30, 75, 80);
            dwarf = new PlayerStats(25, 30, 50, 60, 100);
            humanEatingPlant = new PlayerStats(20, 5, 0, 5, 5);
            witch = new PlayerStats(25, 50, 0, 5, 25);
            zombie = new PlayerStats(30, 5, 5, 20, 5);
            flyingDemon = new PlayerStats(15, 15, 10, 25, 10);
            dragon = new PlayerStats(30, 15, 40, 60, 15);
        }
        #endregion

        #region Constructors
        public PlayerStats(int attackPower, int accuracy, int defence, int stamina, int agility)
            : base(attackPower, accuracy, defence)
        {
            this.Stamina = stamina;
            this.Agility = agility;
            this.InitialHealth = stamina;
        }
        #endregion

        #region StaticProperties
        public static PlayerStats Elf
        {
            get
            {
                return elf;
            }
        }

        public static PlayerStats Human
        {
            get
            {
                return human;
            }
        }

        public static PlayerStats Dwarf
        {
            get
            {
                return dwarf;
            }
        }

        public static PlayerStats HumanEatingPlant
        {
            get
            {
                return humanEatingPlant;
            }
        }

        public static PlayerStats Witch
        {
            get
            {
                return witch;
            }
        }

        public static PlayerStats Zombie
        {
            get
            {
                return zombie;
            }
        }

        public static PlayerStats FlyingDemon
        {
            get
            {
                return flyingDemon;
            }
        }

        public static PlayerStats Dragon
        {
            get
            {
                return dragon;
            }
        }
        #endregion

        #region Properties
        public int Stamina
        {
            get
            {
                return this.stamina;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The stamina cannot be negative.");
                }

                this.stamina = value;
            }
        }

        public int Agility
        {
            get
            {
                return this.agility;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The agility cannot be negative.");
                }

                this.agility = value;
            }
        }
        #endregion

        #region Methods
        public decimal CalculateAgilityPercentage()
        {
            decimal result = this.Agility / 100m;

            return result;
        }

        public void IncreaseAgility(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount to increase Agility cannot be negative!");
            }
            this.Agility += amount;
        }

        public void DecreaseAgility(int amount)
        {
            if (this.Agility - amount < 0)
            {
                this.Agility = 0;
            }
            else
            {
                this.Agility -= amount;
            }
        }

        public void IncreaseHealth(int amount)
        {
            this.Stamina += amount;
        }

        public void LooseHealth(int amount)
        {
            if (this.Stamina - amount <= 0)
            {
                this.Stamina = 0;
            }
            else
            {
                this.Stamina -= amount;
            }
        }

        public void ResetHealth()
        {
            this.Stamina = this.InitialHealth;
        }

        public void AddToAttack(int amount)
        {
            this.AttackPower += amount;
        }

        #endregion
    }
}
