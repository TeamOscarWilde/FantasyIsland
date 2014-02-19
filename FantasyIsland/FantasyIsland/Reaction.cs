namespace FantasyIsland
{
    using System;
    using System.Diagnostics;

    public static class Reaction
    {
        #region Static Methods
        public static void Wait()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                    Console.Clear();
                    break;
                }
            }
        }

        public static long MeasureReaction(char key)
        {
            Stopwatch timer = new Stopwatch();
            timer.Restart();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo info = Console.ReadKey(true);
                    if (info.KeyChar == key)
                    {
                        timer.Stop();
                        return timer.ElapsedMilliseconds;
                    }
                }
                if (timer.ElapsedMilliseconds > 3000)
                {
                    timer.Stop();
                    return timer.ElapsedMilliseconds;
                }
            }
        } 
        #endregion
    }
}
