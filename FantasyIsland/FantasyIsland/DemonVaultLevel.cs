/*
 * This level represents Demons' Vault and the Hero needs to survive. 
 * if hero has a shooting weapon he can easier survive and take less damage by the demons.
 * Difficulty is used when calculating demon's damage.
*/
namespace FantasyIsland
{
    using System;
    using System.Threading;
    using System.IO;

    using FantasyIsland.Characters;
    using FantasyIsland.Enumerations;

    public class DemonVaultLevel : Level
    {
        #region Constants
        private const int MinNumberOfFlyingDemons = 6;
        private const int MaxNumberOfFlyingDemons = 10;
        #endregion

        #region Fields
        private Enemy enemyDemon; // to be invoked in parent class Level after changes
        private Random rand = new Random();
        private int damage;
        #endregion

        #region Constructors
        public DemonVaultLevel(Difficulty difficulty, Hero hero)
            : base(difficulty, hero)
        {
            this.enemyDemon = new Enemy(PlayerStats.FlyingDemon, Armor.None, Weapon.None, Magic.HighDrop);
        }
        #endregion

        #region Methods
        protected override void Intro()
        {
            using (StreamReader sr = new StreamReader(@"..\..\Text\DemonVaultIntro.txt"))
            {
                sr.ReadAndType();
            }
            Reaction.Wait();
        }

        public override void Start()
        {
            Console.CursorVisible = false;
            Console.Clear();
            this.Intro();
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
            using (StreamReader sr = new StreamReader(@"..\..\Text\DemonVaultFinished.txt"))
            {
                sr.ReadAndType();
            }

            this.Hero.ResetHealth();
            this.Hero.IncreaseAgility(this.Hero.PlayerStats.Agility); //this will double the hero agility
            this.ChangeConsoleColor(ConsoleColor.White);
            Reaction.Wait();

        }

        protected override void Battle()
        {
            int randomNumber = this.rand.Next(101);
            this.enemyDemon.ResetHealth();
            //To check what kind of weapon the hero has??? !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            bool isLongRangeWeapon = false;

            if (randomNumber % 6 == 0) //demon has 16% chance to surprise you with HighDrop
            {
                ChangeConsoleColor(ConsoleColor.Red);
                Console.WriteLine("SUDDENLY! A demon surprises you with hit from the back!");
                damage = (int)(this.Damage(false) * 1.5); /*implement demon magic HighDrop - Demon deals 50% more damage*/
                Console.WriteLine("Now you are caught and dropped from high altitude! Damage: {0}", damage);
                this.Hero.LooseHealth(damage);
            }
            else
            {
                ChangeConsoleColor(ConsoleColor.White);
                Console.WriteLine("A demon saw you and is coming to get you!");
            }

            while (true)
            {
                ChangeConsoleColor(ConsoleColor.Yellow);
                Console.WriteLine("Hero HEALTH: {0}", this.Hero.PlayerStats.Stamina);
                Console.WriteLine("Demon HEALTH: {0}", this.enemyDemon.PlayerStats.Stamina);

                if (this.Hero.PlayerStats.Stamina <= 0)
                {
                    this.ChangeConsoleColor(ConsoleColor.Red);
                    Console.WriteLine("The flying demon killed you!");
                    Console.WriteLine("\nGAME OVER!\nPress and key to exit!");
                    Environment.Exit(0);
                }

                //TO DO - At the end of each turn to give the player a choice what to do
                ChangeConsoleColor(ConsoleColor.Cyan);
                Console.WriteLine("Now make your choice:");
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
                    if (rand.Next(71) + this.Hero.TotalStats.Agility >= 100)
                    {
                        this.ChangeConsoleColor(ConsoleColor.Green);
                        Console.WriteLine("You are so fast and the demon cannot see you anymore.\nBut be careful there are many demons around!");
                        Reaction.Wait();
                        break;
                }
                    else
                    {
                        ChangeConsoleColor(ConsoleColor.Yellow);
                        Console.WriteLine("You did not hide good enough and the demon saw you.");
                        this.DemonAttack();
                        continue;
                    }
                }

                if (isLongRangeWeapon) //the hero can shoot at the demon
                {
                    this.BattleWithLongRangeWeapon();
                }
                else //hero has hand weapon
                {
                    this.BattleWithHandWeapon();
                }

                if (this.enemyDemon.PlayerStats.Stamina <= 0) //demon is dead and cannot hit you
                {
                    this.ChangeConsoleColor(ConsoleColor.Green);
                    Console.WriteLine("You successfully killed the flying demon!");
                    this.ChangeConsoleColor(ConsoleColor.White);
                    Console.WriteLine("But be carefull there are many of them here.\nPress any key when you are ready for the next one.");
                    Reaction.Wait();
                    break;
                }
                this.DemonAttack();
            }
                
            Console.Clear();
            }
            
        private void DemonAttack()
        {
            ChangeConsoleColor(ConsoleColor.Red);
            damage = this.Damage(false);
            Console.WriteLine("Demon successfully grabbed you and threw you into a stone. Damage: {0}", damage);
            this.Hero.LooseHealth(damage);
        }

        private void BattleWithHandWeapon()
        {
            this.ChangeConsoleColor(ConsoleColor.White);
            Console.WriteLine("The demon is flying against you, but you can\nonly prepare to hit him until he is close enough!");
            if (rand.Next(101) < 80) //80% chance to hit demon, if depends on the Agility - makes game too unfair 
            {
                ChangeConsoleColor(ConsoleColor.Green);
                damage = this.Damage(true);
                Console.WriteLine("You were fast enough to hit the demon first. Damage: {0}", damage);
                this.enemyDemon.LooseHealth(damage);
            }
            else
            {
                Console.WriteLine("Unfortunately the demon was so fast and you missed him!");
            }
        }

        private void BattleWithLongRangeWeapon()
        {
            this.ChangeConsoleColor(ConsoleColor.White);
            Console.WriteLine("You saw the demon and immediately prepare to shoot.");
            this.ChangeConsoleColor(ConsoleColor.Green);

            if (this.Hero.TotalStats.Agility >= 70 && rand.Next(11) % 2 == 0) // 50% chance to shoot twice if Hero is fast enough
            {
                Console.WriteLine("You are fast enough to shoot at the demon\ntwo times while it is approaching!");
                damage = this.Damage(true);
                this.enemyDemon.LooseHealth(damage);
                Console.WriteLine("Damage dealt to demon is {0}", damage);
            }
            damage = this.Damage(true);
            this.enemyDemon.LooseHealth(damage);
            Console.WriteLine("Damage dealt to demon is {0}", damage);
            }

        private int Damage(bool isHero)
        {
            int attackPower;
            int accuracy;
            double agility;
            int opponentDefence;

            if (isHero)
            {
                attackPower = this.Hero.TotalStats.AttackPower;
                accuracy = this.Hero.TotalStats.Accuracy;
                agility = (double)this.Hero.TotalStats.Agility / 100;
                opponentDefence = this.enemyDemon.TotalStats.Defence;
        }
            else
            {
                attackPower = this.enemyDemon.TotalStats.AttackPower;

                if (this.Difficulty == Difficulty.Medium)
                {
                    attackPower += attackPower / 4; //adds 25% more damage
                }
                else if (this.Difficulty == Difficulty.Hard)
        {
                    attackPower += attackPower / 2; //adds 50% more damage
                }

                accuracy = this.enemyDemon.TotalStats.Accuracy * 4;
                agility = 0.9;
                opponentDefence = this.Hero.PlayerStats.Defence / 10; //when thrown player defence does not help him much
            }

            int damageToTake = (int)(attackPower * ((double)accuracy * agility / 100)) - opponentDefence;
            damageToTake = rand.Next((damageToTake - damageToTake / 4), (damageToTake + damageToTake / 4) + 1); // +-25%

            return damageToTake;
        }

        private void ChangeConsoleColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
        #endregion
    }
}
