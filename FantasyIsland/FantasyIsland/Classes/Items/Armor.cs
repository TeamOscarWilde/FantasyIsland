/* 
 * The armor is part of the invertory of the hero or the enemy. The strength of the armor affects 
 * the defence qualities of the player - the higher the strength the higher the defence of the player.
 * The weight of the armor affects the agility of the player - makes him slower and therefore reduces the agility.
 * We have 4 preset static armors to use depending on the player's choice.
 */

namespace FantasyIsland
{
    using System;

    public class Armor : Item
    {
        #region Static Fields
        private static Armor none;
        private static Armor light;
        private static Armor medium;
        private static Armor heavy;
        #endregion

        #region Static Constructors
        static Armor()
        {
            none = new Armor(0, 0);
            light = new Armor(15, 20);
            medium = new Armor(30, 35);
            heavy = new Armor(50, 50);
        }
        #endregion

        #region Constructors
        public Armor(int weight, int strength)
            : base(weight, strength)
        {
        }
        #endregion

        #region Static Properties
        public static Armor None
        {
            get
            {
                return none;
            }
        }

        public static Armor Light
        {
            get
            {
                return light;
            }
        }

        public static Armor Medium
        {
            get
            {
                return medium;
            }
        }

        public static Armor Heavy
        {
            get
            {
                return heavy;
            }
        }
        #endregion
    }
}
