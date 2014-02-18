namespace FantasyIsland
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    public static class Game
    {
        static long MeasureReaction(char key)
        {
            Stopwatch timer = new Stopwatch();
            timer.Restart();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo info = Console.ReadKey(true);
                    if (info.KeyChar == key)
                    {
                        timer.Stop();
                        return timer.ElapsedMilliseconds;
                    }
                }
                if (timer.ElapsedMilliseconds > 3000)
                {
                    timer.Stop();
                    return timer.ElapsedMilliseconds;
                }
            }
        }
        static void Battle(Hero hero)
        {
            Random rand = new Random();
            int rounds = rand.Next(6, 11);
            Stopwatch timer = new Stopwatch();
            Thread.Sleep(1000);
            long reaction = 0;
            for (int round = 0; round < rounds; round++)
            {
                Console.Clear();
                ShowHealth(hero);
                if (hero.Stats.Stamina <= 0)
                {
                    Console.WriteLine("Too much damage taken! You are dead!");
                    break;
                }
                char keyToPress = (char)rand.Next(97, 123);
                Console.WriteLine("You are attacked by a plant!!! \nPRESS \"{0}\" TO COUNTER-ATTACK!!!", keyToPress);
                reaction = MeasureReaction(keyToPress);
                if (reaction < 1200)
                {
                    Console.WriteLine("Well done! Attack avoided, plant killed! No health lost!");
                    Thread.Sleep(rand.Next(1500, 3500));
                }
                else if (reaction >= 1200 && reaction < 1600)
                {
                    Console.WriteLine("Small bite received! Little health lost!");
                    hero.Stats.Stamina -= 10;
                    Thread.Sleep(rand.Next(1500, 3500));
                }
                else if (reaction >= 1600 && reaction < 2000)
                {
                    Console.WriteLine("Big bite received! A lot of health lost!");
                    hero.Stats.Stamina -= 20;
                    Thread.Sleep(rand.Next(1500, 3500));
                }
                else
                {
                    Console.WriteLine("Too slow reaction! You are dead!");
                    break;
                }
            }
            if (hero.Stats.Stamina > 0)
            {
                Console.Clear();
                Console.WriteLine("You passed the human-eating plants forest!");
            }

        }
        static void ShowHealth(Hero hero)
        {
            Console.WriteLine("Health: {0}", hero.Stats.Stamina);
        }
        static void Wait()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                    Console.Clear();
                    break;
                }
            }
        }
        static void LevelOne(Hero hero)
        {
            Console.CursorVisible = false;
            Console.WriteLine("You entered the dark forest of human-eating plants.");
            Thread.Sleep(1500);
            Console.WriteLine("\nBe careful - the dangerous plants are everywhere!");
            Thread.Sleep(1500);
            Console.WriteLine("\nYou will be attacked several times. ");
            Thread.Sleep(1500);
            Console.WriteLine("\nYou have to be quick to avoid being bitten or eaten.");
            Thread.Sleep(1500);
            Console.WriteLine("\nTo avoid the attack and destroy the plant you will \nhave to press a certain key as fast as you can!");
            Thread.Sleep(2000);
            Console.WriteLine("\nPress any key to start when you are ready!");
            Wait();
            Battle(hero);
        }

        static void Main()
        {
            Hero myHero = new Hero(PlayerStats.Human, Armor.Medium, Weapon.Sword, SuperPower.DoubleAttack);
            LevelOne(myHero);
        }
    }
}
