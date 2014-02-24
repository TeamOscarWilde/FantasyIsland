namespace FantasyIsland
{
    using System;
    using System.Collections.Generic;

    public static class Game
    {
        public static void Main()
        {
            // TODO Menu and implement IIntro to it(Intro to the game - story, goal, etc.)
            Hero myHero = new Hero(PlayerStats.Human, Armor.Medium, Weapon.Sword, SuperPower.DoubleAttack);
            DarkForestLevel forest = new DarkForestLevel(Difficulty.Easy, myHero);
            //forest.Start();

            ZombieMountain mountain = new ZombieMountain(Difficulty.Easy, myHero);
            //mountain.Start();

            //Using polimorphism
            List<Level> levels = new List<Level>();
            levels.Add(forest);
            levels.Add(mountain);
            foreach (var level in levels)
            {
                level.Start();
            }

        }
    }
}
