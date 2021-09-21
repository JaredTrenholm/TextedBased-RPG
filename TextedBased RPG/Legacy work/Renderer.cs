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

        private static int CameraY;
        private static int CameraX;

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
                    CameraX = x + xOffset;
                    CameraY = y + yOffset;
                    if (CameraX > Global.MAP_X_LENGTH-1)
                    {
                        CameraX = Global.MAP_X_LENGTH-1;
                    }

                    if (CameraY > Global.MAP_Y_LENGTH-1)
                    {
                        CameraY = Global.MAP_Y_LENGTH-1;
                    }
                    TileColor();
                    Console.Write(RenderData[CameraY, CameraX]);
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
                if (RenderData[CameraY, CameraX] == "^") { Console.ForegroundColor = ConsoleColor.Gray; }
                else if (RenderData[CameraY, CameraX] == "~") { Console.ForegroundColor = ConsoleColor.Blue; }
                else if (RenderData[CameraY, CameraX] == "*") { Console.ForegroundColor = ConsoleColor.DarkGreen; }
                else if (RenderData[CameraY, CameraX] == "E") { Console.ForegroundColor = ConsoleColor.Red; }
                else if (RenderData[CameraY, CameraX] == "D") { Console.ForegroundColor = ConsoleColor.Red; }
                else if (RenderData[CameraY, CameraX] == "S") { Console.ForegroundColor = ConsoleColor.Red; }
                else if (RenderData[CameraY, CameraX] == "B") { Console.ForegroundColor = ConsoleColor.Red; }
                else if (RenderData[CameraY, CameraX] == "'") { Console.ForegroundColor = ConsoleColor.Green; }
                else if (RenderData[CameraY, CameraX] == "T") { Console.ForegroundColor = ConsoleColor.Yellow; }
                else if (RenderData[CameraY, CameraX] == "C") { Console.ForegroundColor = ConsoleColor.Cyan; }
                else { Console.ForegroundColor = ConsoleColor.White; }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine(CameraX +", " + CameraY);
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
