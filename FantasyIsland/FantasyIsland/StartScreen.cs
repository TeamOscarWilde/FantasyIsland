using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;


class StartScreen
{

    private static int sleepdelay = 50;
    private static string logo = File.ReadAllText(@"..\..\Text\StartScreen.txt");

    public static void SetScreen()
    {
        Console.WindowHeight = 50;
        Console.BufferHeight = 50;
        Console.WindowWidth = 80;
        Console.BufferWidth = 80;
    }

    private static void PrintLogo()
    {
        foreach (var item in logo)
        {
            if (item != '\n')
            {
                if (item == '.')
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                else if (item == 'j')
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
                else if (item == 'f')
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                else if (item == 'G')
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                }
                Console.Write(item);
            }
        }
    }


    public static void Screen()
    {
        SetScreen();

        #region PrintLogo

        Console.Clear();
        PrintLogo();

        #endregion PrintLogo

        Thread.Sleep(sleepdelay);

        #region PRESS ANY KEY

        for (int i = 46; i > 42; i = i - 2)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(30, i + 2);
            Console.WriteLine("PRESS SPACE TO START");

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(30, i);
            Console.WriteLine("PRESS SPACE TO START");

            Thread.Sleep(sleepdelay);
        }

        #endregion PRESS ANY KEY

        Console.ReadKey(true);
    }
}
