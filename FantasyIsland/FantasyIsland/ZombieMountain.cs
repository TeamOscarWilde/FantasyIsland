namespace FantasyIsland
{
    using System;
    using System.Threading;

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
            if (difficulty == FantasyIsland.Difficulty.Easy)
            {
                this.initialHitPercentage = 70;
                this.fastReaction = (int)ReactionTime.Normal;
                this.averageReaction = (int)ReactionTime.Slow;
                this.slowReaction = (int)ReactionTime.UltraSlow;
            }
            else if (difficulty == FantasyIsland.Difficulty.Medium)
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
            this.Intro();
            this.Battle();
            this.LevelFinished();
        }

        protected override void Intro()
        {
            Console.CursorVisible = false;
            Console.WriteLine("You have entered the ZOMBIE MOUNTAIN!");
            Thread.Sleep(1500);
            Console.WriteLine("\nThis mountain is filled with zombies!");
            Thread.Sleep(1500);
            Console.WriteLine("\nThey are blind but really dangerous. ");
            Thread.Sleep(1500);
            Console.WriteLine("\nThey can feel your scent and come after you!");
            Thread.Sleep(1500);
            Console.WriteLine("\nYou have to move fast and attack swiftly!");
            Thread.Sleep(1500);
            Console.WriteLine("\nThe more agility you have the less damage the zombies \nwill do to you or even miss you!");
            Thread.Sleep(1500);
            Console.WriteLine("\nTo avoid the attack and destroy the zombie you will \nhave to press a certain key as fast as you can!");
            Thread.Sleep(2000);
            Console.WriteLine("\nPress any key to start when you are ready!");
            Reaction.Wait();
        }

        protected override void Battle()
        {
            int zombies = rand.Next(MIN_ZOMBIES, MAX_ZOMBIES);
            int zombieKills = 0;
            long reaction = 0;
            this.agilityEffect = this.hero.PlayerStats.CalculateAgilityPercentage();
            chanceToBeHit = initialHitPercentage - agilityEffect;
            

            Thread.Sleep(1000);
            strongHit = (int)(enemy.PlayerStats.AttackPower * this.hero.PlayerStats.CalculateDefencePercentage() - agilityEffect);
            heroHit = (int)(this.hero.PlayerStats.AttackPower * enemy.PlayerStats.CalculateDefencePercentage());

            for (int zombie = 0; zombie < zombies; zombie++)
            {
                enemy.ResetHealth();
                while (!(enemy.PlayerStats.Stamina <= 0 || this.hero.PlayerStats.Stamina <= 0))
                {

                    decimal chance = rand.Next(0, 101);
                    Console.Clear();
                    Console.WriteLine("There is a zombie near you!");
                    Console.Write("\nPlayer Health: {0}", this.hero.PlayerStats.Stamina);
                    Console.Write("   Attack power: {0}", this.hero.PlayerStats.AttackPower);
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
                        this.hero.LooseHealth(strongHit);
                        Thread.Sleep(2000);
                    }
                    else if (reaction <= this.slowReaction)
                    {
                        Console.WriteLine("Poorly done... The zombie almost killed you!");
                        enemy.LooseHealth(heroHit - 30);
                        this.hero.LooseHealth(strongHit * 2);
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
                            this.hero.LooseHealth(0);
                            Thread.Sleep(1000);
                        }

                    }
                    if (this.hero.PlayerStats.Stamina <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("YOU ARE DEAD!");
                        Environment.Exit(0);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (enemy.PlayerStats.Stamina <= 0)
                    {
                        zombieKills++;
                        this.hero.AddToAttack(5);
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
            string crossbowChoice;
            if (this.hero.PlayerStats.Stamina > 0)
            {
                Console.Clear();
                Console.WriteLine("It seems like that was the last of them.");
            }
            Thread.Sleep(2500);
            Console.WriteLine("\nYou have found your old friend John's corpse.");
            Thread.Sleep(1500);
            Console.WriteLine("\nGuess he wasn't that lucky with the zombies...");
            Thread.Sleep(1500);
            Console.WriteLine("\nYOU HAVE FOUND HIS LEGENDARY CROSSBOW!\nIt might come in handy!!! Would you like to pick it up? YES or NO?");
            crossbowChoice = Console.ReadLine().ToUpper();

            if ((crossbowChoice.CompareTo("YES") == 0))
            {
                Thread.Sleep(1500);
                Console.WriteLine("\nPicking up the item!");
                this.hero.Weapon = Weapon.CrossBow;
            }
            else if ((crossbowChoice.CompareTo("NO") == 0))
            {
                Thread.Sleep(1500);
                Console.WriteLine("\nOKAY! I did say it will come in handy though!");
            }
            else
            {
                Thread.Sleep(1500);
                Console.WriteLine("\nInvalid input. Picking up the item.");
                this.hero.Weapon = Weapon.CrossBow;
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