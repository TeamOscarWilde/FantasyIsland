using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FantasyIsland
{
    class Help
    {
        public static void GameHelp()
        {
            using (StreamReader sr = new StreamReader(@"..\..\Text\Help.txt"))
            {
                string help = sr.ReadToEnd();
                Console.WriteLine(help); 
            }
            Console.WriteLine();
            Console.WriteLine("PRESS ANY KEY TO RETURN...");
            Reaction.Wait();
        }
    }
}
