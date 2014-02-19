
/* The armor si part of the invertory of the hero or the enemy. The strength of the armor affects 
 * the defence qualities of the player - the higher the strength the higher the defence of the player.
 * The weight of the armor affects the agility of the player - makes him slower and therefore reduces the agility.
 * We have 4 preset static armors to use depending on the player's choice. */

namespace FantasyIsland
{
    public class Armor
    {
        private static Armor none = new Armor(0, 0);
        private static Armor light = new Armor(15, 20);
        private static Armor medium = new Armor(30, 35);
        private static Armor heavy = new Armor(50, 50);
        private int weight;
        private int strength;

        public Armor(int weight, int strength)
        {
            this.weight = weight;
            this.strength = strength;
        }

        public static Armor None
        {
            get { return none; }
        }

        public static Armor Light
        {
            get { return light; }
        }

        public static Armor Medium
        {
            get { return medium; }
        }

        public static Armor Heavy
        {
            get { return heavy; }
        }
        public int Weight
        {
            get { return this.weight; }
            set { this.weight = value; }
        }

        public int Strength
        {
            get { return this.strength; }
            set { this.strength = value; }
        }
    }
}
