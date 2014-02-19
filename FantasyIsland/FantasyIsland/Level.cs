
/* The player can choose the difficulty of each level and gain more experience if he chooses a more difficult level. */

namespace FantasyIsland
{
    using System;

    public abstract class Level : IIntro, IBattle
    {
        public Difficulty Difficulty { get; set; }
        protected Enemy Enemy;

        protected Level(Difficulty difficulty)
        {
            this.Difficulty = difficulty;
        }
        public abstract void Intro();
        public abstract void Battle(Hero hero);       
    }
}
