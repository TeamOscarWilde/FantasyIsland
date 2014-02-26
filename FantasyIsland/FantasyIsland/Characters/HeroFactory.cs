namespace FantasyIsland.Characters
{
    public static class HeroFactory
    {
        private const string Human = "Human";
        private const string Elf = "Elf";
        private const string Dwarf = "Dwarf";

        public static Hero MakeHero(string heroType)
        {
            Hero generatedHero = null;

            if (heroType == HeroFactory.Human)
            {
                generatedHero = new Human();
            }
            else if (heroType == HeroFactory.Elf)
            {
                generatedHero = new Elf();
            }
            else if (heroType == HeroFactory.Dwarf)
            {
                generatedHero = new Dwarf();
            }
            else
            {
                throw new InvalidHeroException("Entered hero is invalid!");
            }

            return generatedHero;
        }
    }
}
