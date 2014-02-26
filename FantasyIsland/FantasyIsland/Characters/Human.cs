namespace FantasyIsland.Characters
{
    using FantasyIsland.Classes.Items;

    public class Human : Hero
    {
        public Human()
            : base(PlayerStats.Human, Armor.Light, new Sword(), SuperPower.DoubleAttack)
        {
        }
    }
}
