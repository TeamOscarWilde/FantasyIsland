namespace FantasyIsland.Characters
{
    using FantasyIsland.Classes.Items;

    public class Elf : Hero
    {
        public Elf()
            : base(PlayerStats.Elf, Armor.Light, new Bow(), SuperPower.Heal)
        {
        }
    }
}
