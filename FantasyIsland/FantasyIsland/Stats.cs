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
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The attack power cannot be negative or equal to zero.");
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
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The accuracy cannot be negative or equal to zero.");
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
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The defence cannot be negative or equal to zero.");
                }

                this.defence = value;
            }
        }
        #endregion

        #region Methods
        public decimal CalculateDefencePercentage()
        {
            decimal result = (100 - this.Defence) / 100m;

            return result;
        }
        #endregion
    }
}
