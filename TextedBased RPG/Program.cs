using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class Program
    {
        public static GameManager GM = new GameManager();

        private static string gameOverMessage = GM.user.GetName() + " have died!";




        static void Main(string[] args)
        {
            GM.GameLoop();

        }
    }
}
