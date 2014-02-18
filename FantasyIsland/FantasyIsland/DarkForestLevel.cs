﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FantasyIsland
{
    public class DarkForestLevel : Level
    {
        private const int ALPHABET_START_INDEX = 97;
        private const int ALPHABET_END_INDEX = 123;
        private const int MIN_ROUNDS = 7;
        private const int MAX_ROUNDS = 11;

        private decimal fastReaction;
        private decimal averageReaction;
        private decimal slowReaction;
        private decimal agilityEffect;
        private static Enemy enemy = new Enemy(PlayerStats.HumanEatingPlant, Armor.None, Weapon.None, Magic.Bite);
        public DarkForestLevel(Difficulty difficulty)
            : base(difficulty)
        {
            if (difficulty == FantasyIsland.Difficulty.Easy)
            {
                this.fastReaction = 1800;
                this.averageReaction = 2100;
                this.slowReaction = 2400;
            }
            else if (difficulty == FantasyIsland.Difficulty.Medium)
            {
                this.fastReaction = 1500;
                this.averageReaction = 1800;
                this.slowReaction = 2100;
            }
            else
            {
                this.fastReaction = 1200;
                this.averageReaction = 1500;
                this.slowReaction = 1800;
            }
        }
        public override void Intro()
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
            Reaction.Wait();
        }

        public override void Battle(Hero hero)
        {
            Random rand = new Random();
            int rounds = rand.Next(MIN_ROUNDS, MAX_ROUNDS);
            Thread.Sleep(1000);
            long reaction = 0;
            int bitePower = (int)(enemy.Stats.AttackPower * hero.Stats.CalculateDefencePercentage());
            this.agilityEffect = hero.Stats.CalculateAgilityPercentage();
            for (int round = 0; round < rounds; round++)
            {
                Console.Clear();
                Console.WriteLine("Health {0}", hero.Stats.Stamina);
                if (hero.Stats.Stamina <= 0)
                {
                    Console.WriteLine("Too much damage taken! You are dead!");
                    break;
                }
                char keyToPress = (char)rand.Next(ALPHABET_START_INDEX, ALPHABET_END_INDEX);
                Console.WriteLine("You are attacked by a plant!!! \nPRESS \"{0}\" TO COUNTER-ATTACK!!!", keyToPress);
                reaction = Reaction.MeasureReaction(keyToPress);
                if (reaction < this.fastReaction*agilityEffect)
                {
                    Console.WriteLine("Well done! Attack avoided, plant killed! No health lost!");
                    Thread.Sleep(rand.Next(1500, 3500));
                }
                else if (reaction >= this.fastReaction*agilityEffect && reaction < this.averageReaction*agilityEffect)
                {
                    Console.WriteLine("Small bite! Little health lost!");
                    hero.Stats.Stamina -= bitePower;
                    Thread.Sleep(rand.Next(1500, 3500));
                }
                else if (reaction >= this.averageReaction*agilityEffect && reaction < this.slowReaction*agilityEffect)
                {
                    Console.WriteLine("Big bite! A lot of health lost!");
                    hero.Stats.Stamina -= bitePower * 2;
                    Thread.Sleep(rand.Next(1500, 3500));
                }
                else
                {
                    Console.WriteLine("Too slow reaction! You are dead!");
                    hero.Stats.Stamina = 0;
                    break;
                }
            }
            if (hero.Stats.Stamina > 0)
            {
                Console.Clear();
                Console.WriteLine("You passed the human-eating plants forest!");
            }
        }
    }
}