using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyIsland
{
    public static class Reaction
    {
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
    }
}
