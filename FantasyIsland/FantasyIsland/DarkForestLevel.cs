/* 
 * Depending on the difficulty chosen we have preset times to react. 
 * The agility also affects the available time to react. It is calculated with the following formula: 
 * Preset time to react*(agility/100)  -  or the higher the agility is the more the time to react is.
 * Example: If we have chosen easy difficulty(1800ms for fast reaction) and our hero has 70 agility his time to react calculates to:
 * 1800*0.7 = 1260ms to react. If he had 30 agility he would have less time to react = 1800*0.3 = 540ms 
 * The attack power of the enemy is calculated depending on the defensive power of our hero with this formula: 
 * Enemy attack power*((100 - hero defence) / 100)   -   or the defence of the hero "neutralizes" part of the enemy's attack
 * Example: If the enemy has 20 attack power and our hero has 80 defence the actual damage that will be caused is:
 * 20*0.2 = 4 damage. If the hero had 20 defence the damage would have been 20*0.8 = 16
 */

namespace FantasyIsland
{
    using System;
    using System.Threading;

    public class DarkForestLevel : Level
    {
        #region Constants
        private const int ALPHABET_START_INDEX = 97;
        private const int ALPHABET_END_INDEX = 123;
        private const int ROUNDS = 10;
        private const decimal DOUBLE_ATTACK_ADDITIONAL_TIME = 1.5M;
        #endregion

        #region Fields
        private readonly decimal fastReaction;
        private readonly decimal averageReaction;
        private readonly decimal slowReaction;

        //The value of the stamina that the player loses in case he is bitten
        private int bitePower;
        //The agility percentage that affects the time to react to each attack
        private decimal agilityEffect;
        //private Hero hero;

        private static Enemy enemy = enemy = new Enemy(PlayerStats.HumanEatingPlant, Armor.None, Weapon.None, Magic.Bite);
        private static Random rand = new Random();
        #endregion

        #region Constructors
        public DarkForestLevel(Difficulty difficulty, Hero hero)
            : base(difficulty, hero)
        {
            this.bitePower = (int)(enemy.PlayerStats.AttackPower * this.hero.PlayerStats.CalculateDefencePercentage());
            this.agilityEffect = this.hero.PlayerStats.CalculateAgilityPercentage();

            if (difficulty == FantasyIsland.Difficulty.Easy)
            {
                this.fastReaction = (int)ReactionTime.Normal * this.agilityEffect;
                this.averageReaction = (int)ReactionTime.Slow * this.agilityEffect;
                this.slowReaction = (int)ReactionTime.UltraSlow * this.agilityEffect;
            }
            else if (difficulty == FantasyIsland.Difficulty.Medium)
            {
                this.fastReaction = (int)ReactionTime.Fast * this.agilityEffect;
                this.averageReaction = (int)ReactionTime.Normal * this.agilityEffect;
                this.slowReaction = (int)ReactionTime.Slow * this.agilityEffect;
            }
            else
            {
                this.fastReaction = (int)ReactionTime.UltraFast * this.agilityEffect;
                this.averageReaction = (int)ReactionTime.Fast * this.agilityEffect;
                this.slowReaction = (int)ReactionTime.Normal * this.agilityEffect;
            }
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
        
        protected override void Battle()
        {
            for (int round = 0; round < ROUNDS; round++)
            {
                Console.Clear();
                Console.SetCursorPosition(35,0);
                Console.WriteLine("HEALTH {0}", this.hero.PlayerStats.Stamina);
                if (this.hero.PlayerStats.Stamina <= 0)
                {
                    Console.WriteLine("Too much damage taken! You are dead!");
                    break;
                }

                int attackType = rand.Next(1, 11);
                if (attackType < 8)
                {
                    Attack();
                }
                else
                {
                    DoubleAttack();
                }
            }
            LevelFinished();
        }

        protected override void LevelFinished()
        {
            if (this.hero.PlayerStats.Stamina > 0)
            {
                Console.Clear();
                Console.WriteLine("Congratulations! You passed the dark forest.");
                Thread.Sleep(2000);
                Console.WriteLine("You reached a magic healing plant. Your health is back to it's initial level");
                Thread.Sleep(2000);
                Console.WriteLine("You can take some magic leafs from the plant with you");
                Thread.Sleep(2000);
                Console.WriteLine("That will increase your health level, but the plant has a very strong scent.");
                Thread.Sleep(1000);
                Console.WriteLine("It causes dizzyness and decreases your agility level.");
                Thread.Sleep(2000);
                Console.WriteLine("Would you like to take the magic leafs with you? ");
                Console.WriteLine("Press Spacebar for Yes or Escape for No ...");
                bool decision = Reaction.CheckKey(ConsoleKey.Spacebar, ConsoleKey.Escape);
                if (decision)
                {
                    int increaseHealthValue = rand.Next(20, 31);
                    int decreaseAgilityValue = rand.Next(20, 31);
                    this.hero.IncreaseHealth(increaseHealthValue);
                    this.hero.DecreaseAgility(decreaseAgilityValue);
                    Console.WriteLine("+ {0} Health", increaseHealthValue);
                    Console.WriteLine("- {0} Agility", decreaseAgilityValue);
                }
            }
            else
            {
                //TODO: Game Over
            }
        }

        private void Attack()
        {
            //Use the random generator to pick a character that has to be pressed to avoid the attack
            char keyToPress = GenerateRandomKey();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ATTACKED !!! \nPRESS \"{0}\" TO COUNTER-ATTACK!!!", keyToPress);
            Console.ForegroundColor = ConsoleColor.Gray;
            long reaction = Reaction.MeasureReaction(keyToPress);
            if (rand.Next(1, 11) < 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("PLANT NOT KILLED YET!");
                Console.ForegroundColor = ConsoleColor.Gray;
                Thread.Sleep(1500);
                Attack();
            }
            ReactionResult(reaction);
        }

        private void DoubleAttack()
        {
            char[] keysToPress = 
            {
                 GenerateRandomKey(),
                 GenerateRandomKey()
            };
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("DOUBLE ATTACK !!! \nPRESS {0} + {1} TO COUNTER-ATTACK!!!", keysToPress[0], keysToPress[1]);
            Console.ForegroundColor = ConsoleColor.Gray;
            long reaction = Reaction.MeasureReaction(keysToPress[0]) + Reaction.MeasureReaction(keysToPress[1]);
            if (rand.Next(1, 11) < 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("PLANTS NOT KILLED YET!");
                Console.ForegroundColor = ConsoleColor.Gray;
                Thread.Sleep(1500);
                DoubleAttack();
            }
            ReactionResult(reaction, DOUBLE_ATTACK_ADDITIONAL_TIME);
        }

        private char GenerateRandomKey()
        {
            return (char)rand.Next(ALPHABET_START_INDEX, ALPHABET_END_INDEX);
        }

        private void ReactionResult(long reaction, decimal timeChangeCoefficient = 1)
        {

            if (reaction < this.fastReaction * timeChangeCoefficient)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("WELL DONE!");
                Console.ForegroundColor = ConsoleColor.Gray;
                Thread.Sleep(rand.Next(1500, 3500));
            }
            else if (reaction >= this.fastReaction * timeChangeCoefficient
                && reaction < this.averageReaction * timeChangeCoefficient)
            {
                this.hero.LooseHealth(bitePower);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("SMALL BITE! -{0} HEALTH!", bitePower);
                Console.ForegroundColor = ConsoleColor.Gray;
                Thread.Sleep(rand.Next(1500, 3500));
            }
            else if (reaction >= this.averageReaction * timeChangeCoefficient
                && reaction < this.slowReaction * timeChangeCoefficient)
            {
                this.hero.LooseHealth(bitePower * 2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("BIG BITE! -{0} HEALT!", bitePower * 2);
                Console.ForegroundColor = ConsoleColor.Gray;
                Thread.Sleep(rand.Next(1500, 3500));
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("TOO SLOW! YOU'RE DEAD!");
                Console.ForegroundColor = ConsoleColor.Gray;
                this.hero.LooseHealth(0);
            }
        }
        #endregion
    }
}
