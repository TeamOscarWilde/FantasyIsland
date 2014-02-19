namespace FantasyIsland
{
    using System;

    public static class Game
    {
        public static void Main()
        {
            Hero myHero = new Hero(PlayerStats.Human, Armor.Medium, Weapon.Sword, SuperPower.DoubleAttack);
            DarkForestLevel level = new DarkForestLevel(Difficulty.Easy);
            level.Intro();
            level.Battle(myHero);
        }
    }
}
