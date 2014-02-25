/*
 * This level represents Demons' Vault and the Hero needs to survive. 
 * if hero has a shooting weapon he can easier survive and take less damage by the demons.
*/
namespace FantasyIsland
{
    using System;
    using System.Threading;

    public class DemonVaultLevel : Level
    {
        #region Constants
        private const int MinNumberOfFlyingDemons = 6;
        private const int MaxNumberOfFlyingDemons = 10;
        #endregion

        #region Fields
        private Enemy enemyDemon; // to be invoked in parent class Level after changes
        private Random rand = new Random();
        #endregion

        #region Constructors
        public DemonVaultLevel(Difficulty difficulty, Hero hero)
            : base(difficulty, hero)
        {
            if (difficulty == FantasyIsland.Difficulty.Easy) //affects the damageDemon 
            {
                // to do
            }
            else if (difficulty == FantasyIsland.Difficulty.Medium)
            {
                // to do + 10% damageDemon dealt by flying demons
            }
            else
            {
                // to do + 20% damageDemon dealt by flying demons
            }

            this.enemyDemon = new Enemy(PlayerStats.FlyingDemon, Armor.None, Weapon.None, Magic.HighDrop);
        }
        #endregion

        #region Methods
        protected override void Intro()
        {
            Console.WriteLine("You entered the FLYING DEMONS' vault!");
            Thread.Sleep(1500);
            Console.WriteLine("\nThis is dark place with strange noices and you better be careful.");
            Thread.Sleep(1500);
            Console.WriteLine("Demons will try to catch you and throw you in some\ndirection in order to hurt and kill you");
            Thread.Sleep(2000);
            Console.WriteLine("Shooting weapons will be your best defence.");
            Thread.Sleep(1500);
            Console.WriteLine("Get ready for the battle!");
            Thread.Sleep(1500);
            Console.WriteLine("\nPress any key to start when you are ready!");
            Reaction.Wait();
        }

        public override void Start()
        {
            Console.CursorVisible = false;
            Console.Clear();
            //this.Intro(); //UNCOMMENT!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            int totalRounds = rand.Next(MinNumberOfFlyingDemons, MaxNumberOfFlyingDemons + 1);

            for (int round = 0; round < totalRounds; round++)
            {
                this.Battle();
            }

            this.LevelFinished();
        }

        protected override void LevelFinished()
        {
            Console.Clear();
            this.ChangeConsoleColor(ConsoleColor.Yellow);
            Console.WriteLine("You successfully passed the Demon Vault!");
            Console.WriteLine("It looks like a miracle, but you take the wings\nfrom demon and now you can fly!");
            Console.WriteLine("As a result your Agility(speed) increases twice!");
            hero.IncreaseAgility(hero.PlayerStats.Agility); //this will double the hero agility
            this.ChangeConsoleColor(ConsoleColor.White);
        }

        protected override void Battle()
        //TO DO
        //Use the this.enemyDemon.Magic - HighDrop
        //Use method that returns random damage with parameters Damage(playerDamage, accuracy) to be universal for hero and for demon
        {
            Console.Clear();
            int randomNumber = this.rand.Next(101);
            int damageDemon = this.enemyDemon.TotalStats.AttackPower; //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! +- % Accuracy
            int damageHero = this.hero.PlayerStats.AttackPower * this.hero.PlayerStats.Accuracy / 100; //!!!!! +- % Accuracy
            this.enemyDemon.ResetHealth();
            //How to check what kind of weapon the hero has??? !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            bool isLongRangeWeapon = false;

            if (randomNumber % 6 == 0) //demon has 16% chance to surprise you with HighDrop
            {
                ChangeConsoleColor(ConsoleColor.Red);
                Console.WriteLine("SUDDENLY! A demon surprises you with hit from the back!");
                Console.WriteLine("Now you are caught and dropped from high altitude! Damage: {0}", damageDemon/*implement demon magic HighDrop*/);
                this.hero.LooseHealth(damageDemon);
            }
            else
            {
                ChangeConsoleColor(ConsoleColor.White);
                Console.WriteLine("A demon saw you and is coming to get you!");
            }

            while (true)
            {
                ChangeConsoleColor(ConsoleColor.Yellow);
                Console.WriteLine("Hero HEALTH: {0}", this.hero.PlayerStats.Stamina);
                Console.WriteLine("Demon HEALTH: {0}", this.enemyDemon.PlayerStats.Stamina);

                if (this.hero.PlayerStats.Stamina <= 0)
                {
                    this.ChangeConsoleColor(ConsoleColor.Red);
                    Console.WriteLine("The flying demon killed you!");
                    Console.WriteLine("\nGAME OVER!\nPress and key to exit!");
                    Environment.Exit(0);
                }

                //TO DO - At the end of each turn to give the player a choice what to do
                ChangeConsoleColor(ConsoleColor.White);
                Console.WriteLine("Now make your choise:");
                Console.WriteLine("To ATTACK the demon press 'A'.");
                Console.WriteLine("To try to ESCAPE and HIDE from this demon press 'E'.");

                bool isA = Reaction.CheckKey(ConsoleKey.A, ConsoleKey.E);

                if (isA)
                {
                    //means to continue the battle
                }
                else
                {
                    //There must be any chance to escape from the demon, but he can also catch you and hurt you
                    Console.WriteLine("EEEEEEEEEEE");
                    //TO DO
                }

                if (isLongRangeWeapon) //the hero can shoot at the demon
                {
                    BattleWithLongRangeWeapon(damageHero);
                }
                else //hero has hand weapon
                {
                    BattleWithHandWeapon(damageHero);
                }

                if (this.enemyDemon.PlayerStats.Stamina <= 0) //demon is dead and cannot hit you
                {
                    this.ChangeConsoleColor(ConsoleColor.Green);
                    Console.WriteLine("You successfully killed the flying demon!");
                    this.ChangeConsoleColor(ConsoleColor.White);
                    Console.WriteLine("But be carefull there are many of them here.");
                    break;
                }
                ChangeConsoleColor(ConsoleColor.Red);
                Console.WriteLine("Demon successfully grabbed you and threw you into a stone. Damage: {0}", damageDemon);
                this.hero.LooseHealth(damageDemon);

                
            }
            
        }

        private void BattleWithHandWeapon(int damageHero)
        {
            this.ChangeConsoleColor(ConsoleColor.White);
            Console.WriteLine("The demon is flying against you, but you can\nonly prepare to hit him when he is close enough!");
            if (rand.Next(11) <= 8) //80% chance to hit demon
            {
                ChangeConsoleColor(ConsoleColor.Green);
                Console.WriteLine("You were fast enough to hit the demon first. Damage: {0}", damageHero);
                this.enemyDemon.LooseHealth(damageHero);
            }
            else
            {
                Console.WriteLine("Unfortunately the demon was so fast and you missed him!");
            }
        }

        private void BattleWithLongRangeWeapon(int damageHero)
        {
            this.ChangeConsoleColor(ConsoleColor.White);
            Console.WriteLine("You saw the demon and immediately prepare to shoot.");
            this.ChangeConsoleColor(ConsoleColor.Green);

            if (this.hero.PlayerStats.Agility >= 90 && rand.Next(11) >= 5) // 50% chance to shoot twice
            {
                Console.WriteLine("You are fast enough to shoot at the demon\ntwo times while it is approaching!");
                this.enemyDemon.LooseHealth(damageHero);
                Console.WriteLine("Damage dealt to demon is {0}", damageHero);
            }
            this.enemyDemon.LooseHealth(damageHero);
            Console.WriteLine("Damage dealt to demon is {0}", damageHero);
        }

        private int Damage(int attackPower, int accuracy, int opponentDefence)
        {
            int damage = (int)(attackPower * ((double)accuracy / 100)) - opponentDefence;
            return damage; 
        }

        private void ChangeConsoleColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
        #endregion
    }
}
