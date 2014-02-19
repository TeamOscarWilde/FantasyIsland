// The player can choose the difficulty of each level and gain more experience if he chooses a more difficult level.

namespace FantasyIsland
{
    using System;

    public abstract class Level : IIntro, IBattle
    {
        #region Fields
        private Enemy enemy; 
        #endregion

        #region Constructors
        protected Level(Difficulty difficulty)
        {
            this.Difficulty = difficulty;
        }
        #endregion

        #region Properties
        public Difficulty Difficulty { get; private set; }

        public Enemy Enemy
        {
            get
            {
                return new Enemy(this.enemy.PlayerStats, this.enemy.Armor, this.enemy.Weapon, this.enemy.Magic);
            }
            private set
            {
                this.enemy = value;
            }
        }
        #endregion

        #region Methods
        public abstract void Intro();

        public abstract void Battle(Hero hero);
        #endregion
    }
}
