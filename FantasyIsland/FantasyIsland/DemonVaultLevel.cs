/*
 * The main idea is to type a word and depending on that time 
 * 
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
        private Enemy enemy; // to be invoked in parent class Level after changes
        #endregion

        #region Constructors
        public DemonVaultLevel(Difficulty difficulty) : base(difficulty)
        {
            if (difficulty == FantasyIsland.Difficulty.Easy) //affects the damage 
            {
                // to do
            }
            else if (difficulty == FantasyIsland.Difficulty.Medium)
            {
                // to do + 10% damage dealt by flying demons
            }
            else
            {
                // to do + 20% damage dealt by flying demons
            }

            this.enemy = new Enemy(PlayerStats.FlyingDemon, Armor.None, Weapon.None, Magic.HighDrop); 
        }
        #endregion

        #region Properties

        #endregion

        #region Methods
        public override void Intro()
        {
            Console.CursorVisible = false;
            Console.WriteLine("You entered the flying demons' vault!");
            Thread.Sleep(1500);
            Console.WriteLine("Demons will try to catch you and throw you in some\ndirection in order to hurt and kill you");
            Thread.Sleep(1500);
            Console.WriteLine("Shooting weapons will be your best defence.");
            Thread.Sleep(1500);
        }

        public override void Battle(Hero hero)
        {
            Console.Clear();
            Console.WriteLine("A demon saw you and is coming to get you!");
            Thread.Sleep(1000);
            Console.WriteLine("");



        }

        #endregion

    }
}
