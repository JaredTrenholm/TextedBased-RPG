using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class FriendlyNPC
    {
        public string Dialogue = "";
        public int x;
        public int y;



        public FriendlyNPC()
        {
            x = 20;
            y = 7;

        }

        public void DrawNPC()
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Map.RenderData[y, x] = "F";
            Console.ForegroundColor = ConsoleColor.White;


        }
        public void Talk()
        {
            Console.Clear();
            Console.WriteLine("You encountered a friendly traveler. Here is what they had to say.");
            Console.WriteLine();
            Console.WriteLine(Dialogue);
            Console.ReadKey(true);
        }
    }
}
