﻿namespace FantasyIsland
{
    using System;

    public static class Game
    {
        public static void Main()
        {
            StartScreen.Screen();
            Menu.ShowMenu();
            
            // TODO Menu and implement IIntro to it(Intro to the game - story, goal, etc.)
            //Hero myHero = new Hero(PlayerStats.Human, Armor.Medium, Weapon.Sword, SuperPower.DoubleAttack);
            //DarkForestLevel forest = new DarkForestLevel(Difficulty.Easy, myHero);
            //forest.Start();

            //ZombieMountain mountain = new ZombieMountain(Difficulty.Easy, myHero);
            //mountain.Start();

            //DemonVaultLevel vault = new DemonVaultLevel(Difficulty.Easy, myHero);
            //vault.Start();
        }
    }
}
