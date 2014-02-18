using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyIsland
{
    public class PlayerStats : Stats
    {
        protected int stamina;
        protected int agility;
        private static PlayerStats elf = new PlayerStats(30, 35, 40, 75, 35);
        private static PlayerStats human = new PlayerStats(45, 35, 30, 75, 30);
        private static PlayerStats dwarf = new PlayerStats(25, 30, 50, 60, 50);
        private static PlayerStats humanEatingPlant = new PlayerStats(20, 5, 0, 5, 5);
        private static PlayerStats witch = new PlayerStats(25, 50, 0, 5, 25);
        private static PlayerStats zombie = new PlayerStats(30, 5, 5, 20, 5);
        private static PlayerStats flyingDemon = new PlayerStats(15, 15, 10, 25, 10);
        private static PlayerStats dragon = new PlayerStats(30, 15, 40, 60, 15);

        public PlayerStats(int attack, int accuracy, int defence, int stamina, int agility)
            : base(attack, accuracy, defence)
        {
            this.stamina = stamina;
            this.agility = agility;
        }

        public static PlayerStats Elf
        {
            get { return elf; }
        }

        public static PlayerStats Human
        {
            get { return human; }
        }

        public static PlayerStats Dwarf
        {
            get { return dwarf; }
        }

        public static PlayerStats HumanEatingPlant
        {
            get { return humanEatingPlant; }
        }

        public static PlayerStats Witch
        {
            get { return witch; }
        }

        public static PlayerStats Zombie
        {
            get { return zombie; }
        }

        public static PlayerStats FlyingDemon
        {
            get { return flyingDemon; }
        }

        public static PlayerStats Dragon
        {
            get { return dragon; }
        }

        public int Stamina
        {
            get { return this.stamina; }
            set { this.stamina = value; }
        }

        public int Agility
        {
            get { return this.agility; }
            private set { this.agility = value; }
        }

        public decimal CalculateAgilityPercentage()
        {
            return (100 - this.agility) / 100m;
        }
    }
}
