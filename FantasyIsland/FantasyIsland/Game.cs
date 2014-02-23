﻿namespace FantasyIsland
{
    using System;

    public static class Game
    {
        public static void Main()
        {
            // TODO Menu and implement IIntro to it(Intro to the game - story, goal, etc.)
            Hero myHero = new Hero(PlayerStats.Human, Armor.Medium, Weapon.Sword, SuperPower.DoubleAttack);
            //DarkForestLevel level = new DarkForestLevel(Difficulty.Easy);
            //level.Intro();
            //level.Battle(myHero);

            ZombieMountain mountain = new ZombieMountain(Difficulty.Easy);
            mountain.Intro();
            mountain.Battle(myHero);
        }
    }
}
