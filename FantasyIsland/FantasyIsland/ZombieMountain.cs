namespace FantasyIsland
{
    using System;
    using System.Threading;
    using System.IO;

    using FantasyIsland.Enumerations;

    public class ZombieMountain : Level
    {
        #region Constants
        private const int ALPHABET_START_INDEX = 97;
        private const int ALPHABET_END_INDEX = 123;
        private const int MIN_ZOMBIES = 4;
        private const int MAX_ZOMBIES = 7;

        #endregion

        static Random rand = new Random();
        #region Fields
        private readonly decimal fastReaction;
        private readonly decimal averageReaction;
        private readonly decimal slowReaction;
        private readonly decimal initialHitPercentage;
        //private Hero hero;

        //Zombie damage
        private int strongHit;
        //Hero damage
        private int heroHit;
        //The agility percentage that affects the time to react to each attack
        private decimal agilityEffect;
        //Chance to be hit is used to control if the zombie misses you or not
        private decimal chanceToBeHit;
        private static Enemy enemy;
        #endregion

        #region Constructors
        public ZombieMountain(Difficulty difficulty, Hero hero)
            : base(difficulty, hero)
        {
            if (difficulty == Difficulty.Easy)
            {
                this.initialHitPercentage = 70;
                this.fastReaction = (int)ReactionTime.Normal;
                this.averageReaction = (int)ReactionTime.Slow;
                this.slowReaction = (int)ReactionTime.UltraSlow;
            }
            else if (difficulty == Difficulty.Medium)
            {
                this.initialHitPercentage = 60;
                this.fastReaction = (int)ReactionTime.Fast;
                this.averageReaction = (int)ReactionTime.Normal;
                this.slowReaction = (int)ReactionTime.Slow;
            }
            else
            {
                this.initialHitPercentage = 45;
                this.fastReaction = (int)ReactionTime.UltraFast;
                this.averageReaction = (int)ReactionTime.Fast;
                this.slowReaction = (int)ReactionTime.Normal;
            }

            enemy = new Enemy(PlayerStats.Zombie, Armor.None, Weapon.None, Magic.StrongHit);

        }
        #endregion

        #region Methods
        public override void Start()
        {
            if (this.Hero.PlayerStats.Stamina <= 0)
            {
                return;
            }
            this.Intro();
            this.Battle();
            this.LevelFinished();
        }

        protected override void Intro()
        {
            Console.CursorVisible = false;
            using (StreamReader sr = new StreamReader(@"..\..\Text\ZombieMountainIntro.txt"))
            {
                sr.ReadAndType();
            }
            Reaction.Wait();
        }

        protected override void Battle()
        {
            int zombies = rand.Next(MIN_ZOMBIES, MAX_ZOMBIES);
            int zombieKills = 0;
            long reaction = 0;
            this.agilityEffect = this.Hero.PlayerStats.CalculateAgilityPercentage();
            chanceToBeHit = initialHitPercentage - agilityEffect;
            

            Thread.Sleep(1000);
            strongHit = (int)(enemy.PlayerStats.AttackPower * this.Hero.PlayerStats.CalculateDefencePercentage() - agilityEffect);
            heroHit = (int)(this.Hero.PlayerStats.AttackPower * enemy.PlayerStats.CalculateDefencePercentage());

            for (int zombie = 0; zombie < zombies; zombie++)
            {
                enemy.ResetHealth();
                while (!(enemy.PlayerStats.Stamina <= 0 || this.Hero.PlayerStats.Stamina <= 0))
                {

                    decimal chance = rand.Next(0, 101);
                    Console.Clear();
                    Console.WriteLine("There is a zombie near you!");
                    Console.Write("\nPlayer Health: {0}", this.Hero.PlayerStats.Stamina);
                    Console.Write("   Attack power: {0}", this.Hero.PlayerStats.AttackPower);
                    Console.Write("   Zombie Health: {0}", enemy.PlayerStats.Stamina);
                    Console.WriteLine("   Zombie kills: {0}", zombieKills);

                    char keyToPress = (char)rand.Next(ALPHABET_START_INDEX, ALPHABET_END_INDEX);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\nTHE ZOMBIE IS AFTER YOU!!!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("PRESS \"{0}\" TO ATTACK!", keyToPress);
                    reaction = Reaction.MeasureReaction(keyToPress);
                    if (reaction <= this.fastReaction)
                    {
                        Console.WriteLine("Swift attack! The zombie couldn't even touch you!");
                        enemy.LooseHealth(heroHit);
                        Thread.Sleep(2000);
                    }
                    else if (reaction <= this.averageReaction)
                    {
                        Console.WriteLine("A decent attack! You lost some health though!");
                        enemy.LooseHealth(heroHit - 15);
                        this.Hero.LooseHealth(strongHit);
                        Thread.Sleep(2000);
                    }
                    else if (reaction <= this.slowReaction)
                    {
                        Console.WriteLine("Poorly done... The zombie almost killed you!");
                        enemy.LooseHealth(heroHit - 30);
                        this.Hero.LooseHealth(strongHit * 2);
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("WHAT ARE YOU DOING!? The zombie is performing its special skill.");
                        Thread.Sleep(1000);
                        Console.WriteLine("LOOK OUT!!!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Thread.Sleep(1000);

                        if (chance <= chanceToBeHit)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The zombie missed you! RUNAWAY!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Thread.Sleep(1000);
                        }
                        else if (chance > chanceToBeHit)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You have been hit by the zombie!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            this.Hero.LooseHealth(0);
                            Thread.Sleep(1000);
                        }

                    }
                    if (this.Hero.PlayerStats.Stamina <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("YOU ARE DEAD!");
                        Environment.Exit(0);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (enemy.PlayerStats.Stamina <= 0)
                    {
                        zombieKills++;
                        this.Hero.AddToAttack(5);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\nYOU DEFEATED THE ZOMBIE!\nYou have been granted +5 attack power!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Thread.Sleep(1000);
                        Console.WriteLine("\nBE CAREFUL! There might be others!");
                        Thread.Sleep(3000);

                    }
                }

            }
        }
        protected override void LevelFinished()
        {
            bool crossbowChoice;
            if (this.Hero.PlayerStats.Stamina > 0)
            {
                Console.Clear();
                using (StreamReader sr = new StreamReader(@"..\..\Text\ZombieMountainFinished.txt"))
                {
                    sr.ReadAndType();
                }
            }
            crossbowChoice = Reaction.CheckKey(ConsoleKey.Spacebar, ConsoleKey.Escape);

            if (crossbowChoice)
            {
                Thread.Sleep(1500);
                Console.WriteLine("\nPicking up the item!");
                this.Hero.Weapon = Weapon.CrossBow;
            }
            else 
            {
                Thread.Sleep(1500);
                Console.WriteLine("\nOKAY! I did say it will come in handy though!");
            }
            Thread.Sleep(1500);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nCONGRATULATIONS!");
            Thread.Sleep(1500);
            Console.WriteLine("\nYou have found a secret passage that helps you get out of this zombie hell!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        #endregion
    }
}