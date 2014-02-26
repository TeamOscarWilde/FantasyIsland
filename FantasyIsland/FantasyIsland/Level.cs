/* The player can choose the difficulty of each level and gain more experience if he chooses a more difficult level.
 * Each level will have intro() and battle() methods. The intro explains to the player what enemies he will meet in
 * that level and gives him an option to enter the level or go back and choose another level. 
 * The battle method will contain the action of the level */

namespace FantasyIsland
{
    using System;

    using FantasyIsland.Enumerations;
    using FantasyIsland.Interfaces;

    public abstract class Level : ILevel
    {
        #region Fields
        private Enemy enemy;
        #endregion

        #region Constructors
        protected Level(Difficulty difficulty, Hero hero)
        {
            this.Difficulty = difficulty;
            this.Hero = hero;
        }
        #endregion

        #region Properties
        public Hero Hero { get; private set; }
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
        public abstract void Start();
        protected abstract void Intro();
        protected abstract void Battle();
        protected abstract void LevelFinished();
        #endregion
    }
}
