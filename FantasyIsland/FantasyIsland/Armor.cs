using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
