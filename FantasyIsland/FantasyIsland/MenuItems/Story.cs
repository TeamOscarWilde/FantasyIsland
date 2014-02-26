using System;
using System.Threading;
using System.IO;

namespace FantasyIsland.MenuItems
{
    class Story
    {
        public static void GameStory()
        {
            using (StreamReader sr = new StreamReader(@"..\..\Text\Story.txt"))
            {
                sr.ReadAndType();
            }
            Console.WriteLine();
            Console.WriteLine("     PRESS ANY KEY TO CHOOSE LEVEL AND START YOUR BATTLE...");
            Reaction.Wait();
        }
    }
}
