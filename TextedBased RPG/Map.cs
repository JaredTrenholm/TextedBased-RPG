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


        public static int MapYLength = 29;
        public static int MapXLength = 29;



       
        public static string[,] mapData;


        private static Player player;

        

        

        public static void LoadMap(int mapID)
        {
            string[] mapLoaded;
            if (mapID == 0)
            {
                mapLoaded = System.IO.File.ReadAllLines("Overworld.txt");
                int mapLength = Convert.ToInt32(mapLoaded.Length);
                mapData = new string[mapLength, mapLength];
                for (int x = 0; x < mapLength; x++)
                {
                    string[] mapLineSplit = mapLoaded[x].Split(' ');
                    for (int y = 0; y < mapLength; y++){
                        mapData[x, y] = mapLineSplit[y];
                    }
                }
                Renderer.LoadRender(mapData, mapLength);
                
            }
        }

        public static void FindPlayer(Player playerTarget)
        {
            player = playerTarget;
        }

        public static string GetTile(int x, int y)
        {
            if((x == 0) || (x == 30))
            {
                x = player.CharacterX;
            }
            if ((x == 0) || (x == 30))
            {
                y = player.CharacterY;
            }
            return mapData[x, y];
        }
    }
}
