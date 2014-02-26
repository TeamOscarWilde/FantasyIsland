
/* The attack power shows what damage would the player cause if he hits his enemy 
 * The accuracy shows what is the chance of the player to hit his enemy when he tries
 * The defence is used to calculate what percentage of the enemy attack will cause damage to the player when he is hit */

namespace FantasyIsland
{
    using System;

    public class Stats
    {
        #region Fields
        private int attackPower;
        private int accuracy;
        private int defence;
        #endregion

        #region Constructors
        public Stats(int attackPower, int accuracy, int defence)
        {
            this.AttackPower = attackPower;
            this.Accuracy = accuracy;
            this.Defence = defence;
        }
        #endregion

        #region Properties
        public int AttackPower
        {
            get
            {
                return this.attackPower;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The attack power cannot be negative.");
                }

                this.attackPower = value;
            }
        }

        public int Accuracy
        {
            get
            {
                return this.accuracy;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The accuracy cannot be negative.");
                }

                this.accuracy = value;
            }
        }

        public int Defence
        {
            get
            {
                return this.defence;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The defence cannot be negative.");
                }

                this.defence = value;
            }
        }
        #endregion

        #region Methods
        //Calculates the coefficient of enemy's attack neutralization(lower coefficient - bigger neutralization)
        public decimal CalculateDefencePercentage()
        {
            decimal result = (100 - this.Defence) / 100m;

            return result;
        }
        #endregion
    }
}
