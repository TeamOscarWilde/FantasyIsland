namespace FantasyIsland
{
    public class Enemy : Player
    {
        #region Constructors
        public Enemy(PlayerStats stats, Armor armor, Weapon weapon, Magic magic)
            : base(stats, armor, weapon)
        {
            this.Magic = magic;
        }
        #endregion

        #region Properties
        public Magic Magic { get; private set; }
        #endregion
    }
}
