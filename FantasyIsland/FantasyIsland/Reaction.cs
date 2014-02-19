namespace FantasyIsland
{
    using System;
    using System.Diagnostics;

    public static class Reaction
    {
        #region Constants
        private const long NO_REACTION = 3000;
        #endregion

        #region Static Methods
        //Stops the program until any button is presed 
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

        /* Measures the reaction in miliseconds of the player 
         * to press a certain key(the parameter) or breaks if there is no reaction in certain time */
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
                if (timer.ElapsedMilliseconds > NO_REACTION)
                {
                    timer.Stop();
                    return timer.ElapsedMilliseconds;
                }
            }
        } 
        #endregion
    }
}
