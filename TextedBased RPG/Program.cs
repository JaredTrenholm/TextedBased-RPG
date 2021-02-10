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
        


        static void Main(string[] args)
        {

            GM.GameLoop();

        }
    }
}
