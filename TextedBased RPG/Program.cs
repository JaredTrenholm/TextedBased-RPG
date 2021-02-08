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
        public static Player user = new Player();


        static void Main(string[] args)
        {

            GM.GameLoop();

        }
    }
}
