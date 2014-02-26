namespace FantasyIsland
{
    using System;

    public class InvalidHeroException : ApplicationException
    {
        public InvalidHeroException(string msg)
            : base(msg)
        {
        }
    }
}
