using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace FantasyIsland
{
    public static class Extensions
    {
        private const int MiliSecsBetweenChars = 100;
        public static void TypeSlow(this string str)
        {
            foreach (char ch in str)
            {
                Console.Write(ch);
                Thread.Sleep(MiliSecsBetweenChars);
            }
        }

        public static void ReadAndType(this StreamReader sr)
        {
            string line = sr.ReadLine();
            while (line != null)
            {
                line.TypeSlow();
                Console.WriteLine();
                line = sr.ReadLine();
            }
        }
    }
}
