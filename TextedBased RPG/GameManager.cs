using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class GameManager
    {

        public Player user;
        public Enemy enemy;
        private Hud HUD;



        public FriendlyNPC npc = new FriendlyNPC();
        private Chest chest = new Chest();


        /// <summary>
        /// 9 left of the player is the map border
        /// 10 right of the player is the map border
        /// 4 up of the player is the map border
        /// 5 down of the player is the map border
        /// </summary>
        /// 

        public GameManager()
        {
            Map.LoadMap(0);
            enemy = new Enemy(Program.GM);
            user = new Player(enemy, Program.GM);
            HUD = new Hud(user,enemy);
            enemy.GetPlayerTarget(user);
            user.Alive = true;
            enemy.Alive = true;
            chest.SetPos(12, 2);
            npc.Dialogue = "To my north is water. You cannot cross without a boat.\nTo my east is a mountain. You cannot hike up without hiking boots.";

            user.SetSpeciesType(0);
            enemy.SetSpeciesType(0);
            
        }


        public void GameLoop()
        {
            Console.CursorVisible = false;
            for (int x = 0; x < 1;)
            {

                StartRound();
                Console.Clear();
                if(enemy.Alive == true)
                {
                    enemy.DrawEnemy();
                }
                else
                {
                    Console.Clear();
                    Map.RenderData[enemy.CharacterY, enemy.CharacterX] = Map.mapData[enemy.CharacterY, enemy.CharacterX];
                    enemy.SetAttackMessage(" ");
                }

                if (user.Alive == true)
                {
                    user.DrawPlayer();
                }
                else
                {
                    x = 1;
                    Console.Clear();
                    Map.RenderData[user.CharacterY, user.CharacterX] = Map.mapData[user.CharacterY, user.CharacterX];
                }

                Map.DrawMap();
                HUD.Display();
                

                if (user.Alive == true)
                {
                    user.MovePlayer();
                    user.SetAttackMessage(" ");
                }
                else
                {
                    x = 1;

                }

                if (enemy.Alive == true)
                {
                    enemy.EnemyTurn();
                }

                EndRound();
                
            }
        }

        private void StartRound()
        {
            chest.DrawChest();
            npc.DrawNPC();
        }
        private void EndRound()
        {
            if (user.CharacterX == chest.xPos)
            {
                if (user.CharacterY == chest.yPos)
                {
                    chest.CheckChest();
                }
            }
            else if (user.CharacterX == npc.x)
            {
                if (user.CharacterY == npc.y)
                {
                    npc.Talk();
                }
            }
        }

        

        


        
    }
}
