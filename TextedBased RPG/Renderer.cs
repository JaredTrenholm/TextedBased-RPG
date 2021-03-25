using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class Renderer
    {
        public static string[,] RenderData;

        private static int MapY;
        private static int MapX;

        private static Player player;

        private static string[,] mapData;
        private static string tile;

        public static int xOffset = 5; //Highest xoffset right now is ten
        public static int yOffset = 1; //Highest yoffset right now is two

        public static void LoadRender(string[,] mapDataTarget)
        {
            mapData = mapDataTarget;
            RenderData = new string[Global.MAP_Y_LENGTH, Global.MAP_X_LENGTH];
            for (int x = 0; x < Global.MAP_X_LENGTH; x++)
            {
                for (int y = 0; y < Global.MAP_Y_LENGTH; y++)
                {
                    RenderData[y, x] = mapData[y, x];
                }
            }
        }

        public static void FindPlayer(Player playerTarget)
        {
            player = playerTarget;
        }

        public static void Draw()
        {
            Console.Write("┌");
            for (int i = 0; i < Global.RENDER_WIDTH; i++)
            {
                Console.Write("─");
            }
            Console.WriteLine("┐");
            for (int y = 0; y < Global.RENDER_LENGTH; y++)
            {
                Console.Write("│");
                for (int x = 0; x < Global.RENDER_WIDTH; x++)
                {
                    MapX = x + xOffset;
                    MapY = y + yOffset;
                    if (MapX > Global.MAP_X_LENGTH-1)
                    {
                        MapX = Global.MAP_X_LENGTH-1;
                    }

                    if (MapY > Global.MAP_Y_LENGTH-1)
                    {
                        MapY = Global.MAP_Y_LENGTH-1;
                    }
                    TileColor();
                    Console.Write(RenderData[MapY, MapX]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("│");
            }
            Console.Write("└");
            for (int i = 0; i < Global.RENDER_WIDTH; i++)
            {
                Console.Write("─");
            }
            Console.WriteLine("┘");
        }
        private static void TileColor()
        {
            try
            {
                if (RenderData[MapY, MapX] == "^") { Console.ForegroundColor = ConsoleColor.Gray; }
                else if (RenderData[MapY, MapX] == "~") { Console.ForegroundColor = ConsoleColor.Blue; }
                else if (RenderData[MapY, MapX] == "*") { Console.ForegroundColor = ConsoleColor.DarkGreen; }
                else if (RenderData[MapY, MapX] == "E") { Console.ForegroundColor = ConsoleColor.Red; }
                else if (RenderData[MapY, MapX] == "D") { Console.ForegroundColor = ConsoleColor.Red; }
                else if (RenderData[MapY, MapX] == "S") { Console.ForegroundColor = ConsoleColor.Red; }
                else if (RenderData[MapY, MapX] == "B") { Console.ForegroundColor = ConsoleColor.Red; }
                else if (RenderData[MapY, MapX] == "'") { Console.ForegroundColor = ConsoleColor.Green; }
                else if (RenderData[MapY, MapX] == "T") { Console.ForegroundColor = ConsoleColor.Yellow; }
                else if (RenderData[MapY, MapX] == "C") { Console.ForegroundColor = ConsoleColor.Cyan; }
                else { Console.ForegroundColor = ConsoleColor.White; }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine(MapX +", " + MapY);
                Console.ReadKey(true);
            }
        }

        public static string TileDesc()
        {

            if (mapData[player.CharacterY, player.CharacterX] == "^") { tile = "You climbed up a mountain."; }
            else if (mapData[player.CharacterY, player.CharacterX] == "~") { tile = "You crossed a body of water."; }
            else if (mapData[player.CharacterY, player.CharacterX] == "*") { tile = "You hiked through a forest."; }
            else if (mapData[player.CharacterY, player.CharacterX] == "'") { tile = "You walk through some plains."; }
            else if (mapData[player.CharacterY, player.CharacterX] == "T") { tile = "You are outside of a town."; }
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

        public static string GetTile(int x, int y)
        {
            return mapData[y,x];
        }
    }
}
