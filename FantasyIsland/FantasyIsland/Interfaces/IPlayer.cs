namespace FantasyIsland.Interfaces
{
    public interface IPlayer
    {
        PlayerStats PlayerStats { get; }

        Armor Armor { get; }

        Weapon Weapon { get; }

        PlayerStats TotalStats { get; }

        void IncreaseAgility(int amount);

        void DecreaseAgility(int amount);

        void LooseHealth(int amount);

        void IncreaseHealth(int amount);

        void ResetHealth();

        void AddToAttack(int amount);
    }
}
