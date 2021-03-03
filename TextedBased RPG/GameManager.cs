using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class GameManager
    {

        private Player player;
        
        
        private FriendlyNPC npc = new FriendlyNPC();
        private Hud HUD;
        private Town town;
        private EnemyManager enemies;
        private ChestManager chests;







        /// <summary>
        /// 9 left of the player is the map border
        /// 10 right of the player is the map border
        /// 4 up of the player is the map border
        /// 5 down of the player is the map border
        /// </summary>
        /// 

        public GameManager()
        {
            

            

        }


        public void RunGame()
        {
            Map.LoadMap(0);

            enemies = new EnemyManager();
            chests = new ChestManager();
            town = new Town("Midori", "Have you heard of the Bandit King down south? Heard he isn't very strong without his goons.");
            npc.Dialogue = "To my north is water. You cannot cross without a boat.\nTo my east is a mountain. You cannot hike up without hiking boots.";
            player = new Player(enemies, chests, town, npc);
            town.SetPlayer(player);
            HUD = new Hud(player, enemies.enemy);
            chests.chestInitialize();
            enemies.enemyInitialize(player, enemies);
            chests.FindPlayer(player);
            Renderer.FindPlayer(player);
            Map.FindPlayer(player);

            while (player.Alive == true)
            {
                Console.SetCursorPosition(0, 0);
                Console.CursorVisible = false;
                npc.Draw();
                town.Draw();
                chests.Draw();
                enemies.Draw();
                player.Draw();
                Renderer.Draw();
                HUD.Display();
                player.MovePlayer();
                player.SetAttackMessage(" ");
                enemies.Update();
                player.Update();
            }

                
            
        }  
    }
}
