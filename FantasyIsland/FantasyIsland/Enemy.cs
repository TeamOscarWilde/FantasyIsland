// For each level the player will have different enemy.
namespace FantasyIsland
{
    public class Enemy : Player
    {
        #region Constructors
        //TODO Make use of the Magics
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
