namespace FantasyIsland
{
    public class Hero : Player
    {
        #region Constructors
        public Hero(PlayerStats stats, Armor armor, Weapon weapon, SuperPower powers)
            : base(stats, armor, weapon)
        {
            this.Powers = powers;
        }
        #endregion

        #region Properties
        public SuperPower Powers { get; private set; }
        #endregion
    }
}
