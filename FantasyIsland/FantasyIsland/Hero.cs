namespace FantasyIsland
{
    public class Hero : Player
    {
        #region Constructors
        //TODO Make use of the SuperPowers
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
