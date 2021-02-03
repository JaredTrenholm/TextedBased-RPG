using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class Program
    {
        public static Player user = new Player();
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            for (int x = 0; x < 1;) {
                Console.Clear();
                Map.DrawMap();
                user.DrawPlayer();
                user.MovePlayer();
            }
            
        }
    }
}
