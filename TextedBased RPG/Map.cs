using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    abstract class Map
    {

        static string CurrentPath = Directory.GetCurrentDirectory();
        static string[] mapFile = new string[]
        {
            CurrentPath + @"\Overworld.txt"
        };
        private static int MapX;
        private static int MapY;
        private static string tile;
        public static int xOffset = 5; //Highest xoffset right now is ten
        public static int yOffset = 1; //Highest yoffset right now is two


        private static string[] mapLoaded = System.IO.File.ReadAllLines(Directory.GetCurrentDirectory() + @"\Overworld.txt");
        public static string[,] mapData;
        public static string[,] RenderData;

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
                    Console.Write(RenderData[y+yOffset, x+xOffset]);
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
            if (RenderData[MapY, MapX] == "^") { Console.ForegroundColor = ConsoleColor.Gray; }
            else if (RenderData[MapY, MapX] == "~") { Console.ForegroundColor = ConsoleColor.Blue; }
            else if (RenderData[MapY, MapX] == "*") { Console.ForegroundColor = ConsoleColor.DarkGreen; }
            else if (RenderData[MapY, MapX] == "E") { Console.ForegroundColor = ConsoleColor.Red; }
            else if (RenderData[MapY, MapX] == "'") { Console.ForegroundColor = ConsoleColor.Green; }
            else { Console.ForegroundColor = ConsoleColor.White; }
        }

        public static string TileDesc()
        {
            
            if (mapData[Program.GM.user.CharacterY, Program.GM.user.CharacterX] == "^") { tile = "You climbed up a mountain."; }
            else if (mapData[Program.GM.user.CharacterY, Program.GM.user.CharacterX] == "~") { tile = "You crossed a body of water."; }
            else if (mapData[Program.GM.user.CharacterY, Program.GM.user.CharacterX] == "*") { tile = "You hiked through a forest."; }
            else if (mapData[Program.GM.user.CharacterY, Program.GM.user.CharacterX] == "'") { tile = "You walk through some plains."; }
            else { tile = ""; }
            return tile;
        }

        public static string TileDesc(string message)
        {
            tile = message;
            return tile;
        }

        public static string GetTileDesc()
        {
            return tile;
        }

        public static void LoadMap(int mapID)
        {
            if(mapID == 0)
            {
                mapLoaded = System.IO.File.ReadAllLines(Directory.GetCurrentDirectory()+ @"\Overworld.txt");
                int mapLength = Convert.ToInt32(mapLoaded.Length);
                mapData = new string[mapLength, mapLength];
                for (int x = 0; x < mapLength; x++)
                {
                    string[] mapLineSplit = mapLoaded[x].Split(' ');
                    for (int y = 0; y < mapLength; y++){
                        mapData[x, y] = mapLineSplit[y];
                    }
                }
                RenderData = new string[mapLength, mapLength];
                for (int x = 0; x < mapLength; x++)
                {
                    for (int y = 0; y < mapLength; y++)
                    {
                        RenderData[y,x] = mapData[y,x];
                    }
                }
            }
        }
    }
}
