namespace FantasyIsland.Characters
{
    public class Hero : Player
    {
        //TODO Make use of the SuperPowers
        #region Constructors
        public Hero(PlayerStats stats, Armor armor, Weapon weapon, SuperPower powers)
            : base(stats, armor, weapon)
        {
            this.Powers = powers;
        }
        #endregion

        //TODO Add Exprerience
        #region Properties
        public SuperPower Powers { get; private set; }
        #endregion
    }
}
