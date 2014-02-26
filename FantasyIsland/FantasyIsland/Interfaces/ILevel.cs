namespace FantasyIsland.Interfaces
{
    using FantasyIsland.Enumerations;

    public interface ILevel
    {
        Hero Hero { get; }

        Difficulty Difficulty { get; }
        
        Enemy Enemy { get; }

        void Start();
    }
}
