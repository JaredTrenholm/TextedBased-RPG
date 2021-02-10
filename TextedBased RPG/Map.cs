﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class Map
    {
        private static int MapX;
        private static int MapY;
        private static string BaseMapTile;
        public static int xOffset = 5; //Highest xoffset right now is ten
        public static int yOffset = 1; //Highest yoffset right now is two
        public static string[,] mapData = new string[,] // dimensions defined by following data:
    {
        {"^","^","^","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'",},
        {"^","^","'","'","'","'","*","*","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","~","~","~","'","'","'",},
        {"^","^","'","'","'","*","*","'","'","'","'","'","'","'","'","'","'","'","'","'","'","~","~","~","~","'","'","'","'","'",},
        {"^","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","~","~","~","~","'","'","'","'","'","'",},
        {"'","'","'","'","~","~","~","'","'","'","'","'","'","'","'","'","'","'","~","~","~","'","'","'","'","'","'","'","'","'",},
        {"'","'","'","'","~","~","~","'","'","'","'","'","'","'","5","~","~","~","~","~","~","'","'","'","'","'","'","'","'","'",},
        {"'","'","'","~","~","~","~","'","'","'","'","'","'","'","~","~","~","~","~","~","'","'","^","^","'","'","'","'","'","'",},
        {"'","'","'","'","'","~","~","~","'","'","'","'","'","'","'","'","'","'","'","'","'","^","^","^","^","'","'","'","'","'",},
        {"'","'","'","'","'","~","~","~","~","'","'","'","'","'","'","'","'","'","'","'","'","'","'","^","^","^","^","'","'","'",},
        {"'","'","'","'","'","'","'","~","'","'","'","'","'","'","'","'","'","'","'","'","^","^","'","'","'","'","'","'","'","'",},
        {"'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","^","^","^","^","^","^","^","'","'",},
        {"'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","^","^","^","^","'","'","'","'",},
        {"^","^","^","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'",},
        {"^","^","'","'","'","'","*","*","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","~","~","~","'","'","'",},
        {"^","^","'","'","'","*","*","'","'","'","'","'","'","'","'","'","'","'","'","'","'","~","~","~","~","'","'","'","'","'",},
        {"^","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","~","~","~","~","'","'","'","'","'","'",},
        {"'","'","'","'","~","~","~","'","'","'","'","'","'","'","'","'","'","'","~","~","~","'","'","'","'","'","'","'","'","'",},
        {"'","'","'","'","~","~","~","'","'","'","'","'","'","'","'","~","~","~","~","~","~","'","'","'","'","'","'","'","'","'",},
        {"'","'","'","~","~","~","~","'","'","'","'","'","'","'","~","~","~","~","~","~","'","'","^","^","'","'","'","'","'","'",},
        {"'","'","'","'","'","~","~","~","'","'","'","'","'","'","'","'","'","'","'","'","'","^","^","^","^","'","'","'","'","'",},
        {"'","'","'","'","'","~","~","~","~","'","'","'","'","'","'","'","'","'","'","'","'","'","'","^","^","^","^","'","'","'",},
        {"'","'","'","'","'","'","'","~","'","'","'","'","'","'","'","'","'","'","'","'","^","^","'","'","'","'","'","'","'","'",},
        {"'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","^","^","^","^","^","^","^","'","'",},
        {"'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","^","^","^","^","'","'","'","'",},
        {"'","'","'","~","~","~","~","'","'","'","'","'","'","'","~","~","~","~","~","~","'","'","^","^","'","'","'","'","'","'",},
        {"'","'","'","'","'","~","~","~","'","'","'","'","'","'","'","'","'","'","'","'","'","^","^","^","^","'","'","'","'","'",},
        {"'","'","'","'","'","~","~","~","~","'","'","'","'","'","'","'","'","'","'","'","'","'","'","^","^","^","^","'","'","'",},
        {"'","'","'","'","'","'","'","~","'","'","'","'","'","'","'","'","'","'","'","'","^","^","'","'","'","'","'","'","'","'",},
        {"'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","^","^","^","^","^","^","^","'","'",},
        {"'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","^","^","^","^","'","'","'","'",}
    };

        public static string[,] BaseMapData = new string[,] // dimensions defined by following data:
    {
        {"^","^","^","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'",},
        {"^","^","'","'","'","'","*","*","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","~","~","~","'","'","'",},
        {"^","^","'","'","'","*","*","'","'","'","'","'","'","'","'","'","'","'","'","'","'","~","~","~","~","'","'","'","'","'",},
        {"^","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","~","~","~","~","'","'","'","'","'","'",},
        {"'","'","'","'","~","~","~","'","'","'","'","'","'","'","'","'","'","'","~","~","~","'","'","'","'","'","'","'","'","'",},
        {"'","'","'","'","~","~","~","'","'","'","'","'","'","'","'","~","~","~","~","~","~","'","'","'","'","'","'","'","'","'",},
        {"'","'","'","~","~","~","~","'","'","'","'","'","'","'","~","~","~","~","~","~","'","'","^","^","'","'","'","'","'","'",},
        {"'","'","'","'","'","~","~","~","'","'","'","'","'","'","'","'","'","'","'","'","'","^","^","^","^","'","'","'","'","'",},
        {"'","'","'","'","'","~","~","~","~","'","'","'","'","'","'","'","'","'","'","'","'","'","'","^","^","^","^","'","'","'",},
        {"'","'","'","'","'","'","'","~","'","'","'","'","'","'","'","'","'","'","'","'","^","^","'","'","'","'","'","'","'","'",},
        {"'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","^","^","^","^","^","^","^","'","'",},
        {"'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","^","^","^","^","'","'","'","'",},
        {"^","^","^","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'",},
        {"^","^","'","'","'","'","*","*","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","~","~","~","'","'","'",},
        {"^","^","'","'","'","*","*","'","'","'","'","'","'","'","'","'","'","'","'","'","'","~","~","~","~","'","'","'","'","'",},
        {"^","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","~","~","~","~","'","'","'","'","'","'",},
        {"'","'","'","'","~","~","~","'","'","'","'","'","'","'","'","'","'","'","~","~","~","'","'","'","'","'","'","'","'","'",},
        {"'","'","'","'","~","~","~","'","'","'","'","'","'","'","'","~","~","~","~","~","~","'","'","'","'","'","'","'","'","'",},
        {"'","'","'","~","~","~","~","'","'","'","'","'","'","'","~","~","~","~","~","~","'","'","^","^","'","'","'","'","'","'",},
        {"'","'","'","'","'","~","~","~","'","'","'","'","'","'","'","'","'","'","'","'","'","^","^","^","^","'","'","'","'","'",},
        {"'","'","'","'","'","~","~","~","~","'","'","'","'","'","'","'","'","'","'","'","'","'","'","^","^","^","^","'","'","'",},
        {"'","'","'","'","'","'","'","~","'","'","'","'","'","'","'","'","'","'","'","'","^","^","'","'","'","'","'","'","'","'",},
        {"'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","^","^","^","^","^","^","^","'","'",},
        {"'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","^","^","^","^","'","'","'","'",},
        {"'","'","'","~","~","~","~","'","'","'","'","'","'","'","~","~","~","~","~","~","'","'","^","^","'","'","'","'","'","'",},
        {"'","'","'","'","'","~","~","~","'","'","'","'","'","'","'","'","'","'","'","'","'","^","^","^","^","'","'","'","'","'",},
        {"'","'","'","'","'","~","~","~","~","'","'","'","'","'","'","'","'","'","'","'","'","'","'","^","^","^","^","'","'","'",},
        {"'","'","'","'","'","'","'","~","'","'","'","'","'","'","'","'","'","'","'","'","^","^","'","'","'","'","'","'","'","'",},
        {"'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","^","^","^","^","^","^","^","'","'",},
        {"'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","'","^","^","^","^","'","'","'","'",}
    };

        public static void DrawMap()
        {
            Console.Write("┌");
            for(int i = 0; i < 20; i++)
            {
                Console.Write("─");
            }
            Console.WriteLine("┐");
            for(int y = 0; y < 10; y++)
            {
                Console.Write("│");
                for(int x = 0; x<20; x++)
                {
                    MapX = x+xOffset;
                    MapY = y+yOffset;
                    TileColor();
                    Console.Write(mapData[y+yOffset, x+xOffset]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("│");
            }
            Console.Write("└");
            for (int i = 0; i < 20; i++)
            {
                Console.Write("─");
            }
            Console.WriteLine("┘");
        }

        private static void TileColor()
        {
            if (mapData[MapY, MapX] == "^") { Console.ForegroundColor = ConsoleColor.Gray; }
            else if (mapData[MapY, MapX] == "~") { Console.ForegroundColor = ConsoleColor.Blue; }
            else if (mapData[MapY, MapX] == "*") { Console.ForegroundColor = ConsoleColor.DarkGreen; }
            else if (mapData[MapY, MapX] == "E") { Console.ForegroundColor = ConsoleColor.Red; }
            else if (mapData[MapY, MapX] == "'") { Console.ForegroundColor = ConsoleColor.Green; }
            else { Console.ForegroundColor = ConsoleColor.White; }
        }
    }
}
