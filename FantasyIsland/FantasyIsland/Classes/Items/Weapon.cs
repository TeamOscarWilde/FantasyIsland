namespace FantasyIsland
{
    public class Weapon : Item
    {
        #region Static Fields
        private static Weapon none;
        private static Weapon bow;
        private static Weapon crossBow;
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
            none = new Weapon(0, 0, 0, 0, 0);
            bow = new Weapon(30, 40, 0, 5, 5);
            crossBow = new Weapon(35, 50, 0, 10, 8);
            flamethrower = new Weapon(35, 30, 0, 20, 15);
            axe = new Weapon(35, 25, 6, 20, 25);
            hammer = new Weapon(45, 10, 0, 30, 30);
            sword = new Weapon(30, 30, 15, 15, 25);
            dagger = new Weapon(25, 35, 12, 5, 15);
        }
        #endregion

        #region Constructors
        public Weapon(int attackPower, int accuracy, int defence, int weight, int strength)
            : base(weight, strength)
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

        public static Weapon CrossBow
        {
            get
            {
                return crossBow;
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
