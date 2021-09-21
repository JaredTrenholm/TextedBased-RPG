using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    abstract class InteractiveArea
    {
        //variables
        public string dialogue = "";
        public string name;
        public int x;
        public int y;
        protected string lastAction;
        protected string avatar;
        protected ConsoleKey input;

        //classes
        protected Player user;

        //constructor
        public InteractiveArea(string name, string desiredDialogue)
        {
            this.name = name;
            dialogue = desiredDialogue;
            //avatar init in Child
        }

        //public methods
        public void SetPlayer(Player userTarget)
        {
            user = userTarget;
        }

        public void Draw()
        {
            Renderer.RenderData[y, x] = avatar;
        }
    }
}
