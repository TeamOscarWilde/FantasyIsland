using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyIsland
{
    public class Weapon
    {
        protected Stats weaponStats;
        private static Weapon bow = new Weapon(30, 0, 40);
        private static Weapon flamethrower = new Weapon(35, 0, 30);
        private static Weapon axe = new Weapon(35, 6, 25);
        private static Weapon hammer = new Weapon(45, 0, 10);
        private static Weapon sword = new Weapon(30, 12, 30);
        private static Weapon dagger = new Weapon(25, 15, 25);

        public Weapon(int attack, int accuracy, int defence)
        {
            this.weaponStats = new Stats(attack, accuracy, defence);
        }

        public Stats WeaponStats
        {
            get { return this.weaponStats; }
            private set { }
        }

        public static Weapon Bow
        {
            get { return bow; }
        }

        public static Weapon Flamethrower
        {
            get { return flamethrower; }
        }

        public static Weapon Axe
        {
            get { return axe; }
        }

        public static Weapon Hammer
        {
            get { return hammer; }
        }

        public static Weapon Sword
        {
            get { return sword; }
        }

        public static Weapon Dagger
        {
            get { return dagger; }
        }
    }
}
