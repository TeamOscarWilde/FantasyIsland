namespace FantasyIsland.Characters
{
    using FantasyIsland.Classes.Items;

    public class Dwarf : Hero
    {
        public Dwarf()
            : base(PlayerStats.Dwarf, Armor.Light, new Axe(), SuperPower.DoubleDefence)
        {
        }
    }
}
