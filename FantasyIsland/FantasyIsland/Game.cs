namespace FantasyIsland
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    public static class Game
    {
        static void Main()
        {
            Hero myHero = new Hero(PlayerStats.Human, Armor.Medium, Weapon.Sword, SuperPower.DoubleAttack);
            DarkForestLevel level = new DarkForestLevel(Difficulty.Easy);
            level.Intro();
            level.Battle(myHero);
        }
    }
}
