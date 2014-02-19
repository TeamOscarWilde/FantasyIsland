﻿namespace FantasyIsland
{
    public class Weapon
    {
        #region Static Fields
        private static Weapon none;
        private static Weapon bow;
        private static Weapon flamethrower;
        private static Weapon axe;
        private static Weapon hammer;
        private static Weapon sword;
        private static Weapon dagger;
        #endregion

        #region Fields
        private Stats weaponStats;
        #endregion

        #region Static Constructors
        static Weapon()
        {
            none = new Weapon(0, 0, 0);
            bow = new Weapon(30, 0, 40);
            flamethrower = new Weapon(35, 0, 30);
            axe = new Weapon(35, 6, 25);
            hammer = new Weapon(45, 0, 10);
            sword = new Weapon(30, 12, 30);
            dagger = new Weapon(25, 15, 25);
        }
        #endregion

        #region Constructors
        public Weapon(int attackPower, int accuracy, int defence)
        {
            this.WeaponStats = new Stats(attackPower, accuracy, defence);
        }
        #endregion

        #region Static Properties
        public static Weapon None
        {
            get
            {
                return none;
            }
        }

        public static Weapon Bow
        {
            get
            {
                return bow;
            }
        }

        public static Weapon Flamethrower
        {
            get
            {
                return flamethrower;
            }
        }

        public static Weapon Axe
        {
            get
            {
                return axe;
            }
        }

        public static Weapon Hammer
        {
            get
            {
                return hammer;
            }
        }

        public static Weapon Sword
        {
            get
            {
                return sword;
            }
        }

        public static Weapon Dagger
        {
            get
            {
                return dagger;
            }
        }
        #endregion

        #region Properties
        public Stats WeaponStats
        {
            get
            {
                return new Stats(this.weaponStats.AttackPower, this.weaponStats.Accuracy, this.weaponStats.Defence);
            }
            private set
            {
                this.weaponStats = value;
            }
        }
        #endregion
    }
}
