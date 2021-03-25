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


        public static int MapYLength = Global.MAP_Y_LENGTH;
        public static int MapXLength = Global.MAP_X_LENGTH;



       
        public static string[,] mapData;


        private static Player player;

        

        

        public static void LoadMap(int mapID)
        {
            string[] mapLoaded;
            if (mapID == 0)
            {
                mapLoaded = System.IO.File.ReadAllLines("Overworld.txt");
                mapData = new string[Global.MAP_Y_LENGTH, Global.MAP_X_LENGTH];
                for (int x = 0; x < Global.MAP_Y_LENGTH; x++)
                {
                    string[] mapLineSplit = mapLoaded[x].Split(' ');
                        for (int y = 0; y < Global.MAP_X_LENGTH; y++)
                        {
                    try
                    {
                            mapData[x, y] = mapLineSplit[y];
                    }
                    catch
                    {
                            Console.WriteLine(x + ", " + y);
                            Console.ReadKey(true);
                    }
                        }
                }
                Renderer.LoadRender(mapData);
                
            }
        }

        public static void FindPlayer(Player playerTarget)
        {
            player = playerTarget;
        }

        public static string GetTile(int x, int y)
        {
            if((x < 0) || (x == Global.MAP_X_LENGTH))
            {
                x = player.CharacterX;
            }
            if ((y < 0) || (y == Global.MAP_Y_LENGTH))
            {
                y = player.CharacterY;
            }

                return mapData[x, y];

        }
    }
}
