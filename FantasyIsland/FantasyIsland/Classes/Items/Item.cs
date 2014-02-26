namespace FantasyIsland
{
    using System;

    using FantasyIsland.Interfaces;

    public class Item : IItem
    {
        private int weight;
        private int strength;

        protected Item(int weight, int strength)
        {
            this.Weight = weight;
            this.Strength = strength;
        }

        public int Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The weight of the armor cannot be negative.");
                }

                this.weight = value;
            }
        }

        public int Strength
        {
            get
            {
                return this.strength;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The strength of the armor cannot be negative.");
                }

                this.strength = value;
            }
        }
    }
}
