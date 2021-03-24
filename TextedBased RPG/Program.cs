using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class Program
    {
        private static Hud HUD;
        static void Main(string[] args)
        {
            GameManager GM = new GameManager();
            HUD = new Hud();
            HUD.MainMenu();
            HUD.Intro();
            GM.RunGame();

        }
    }
}
