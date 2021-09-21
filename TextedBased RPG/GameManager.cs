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
        private Shop shop;
        private EnemyManager enemies;
        private ChestManager chests;

        private GameLoopConditionals gameLoop;

        private ItemManager items;
/*





*/
        /// <summary>
        /// 9 left of the player is the map border
        /// 10 right of the player is the map border
        /// 4 up of the player is the map border
        /// 5 down of the player is the map border
        /// </summary>
        /// 
/*      constructorrrrrerrrr
        public GameManager()
        {
            

            

        }

*/
        public void RunGame()
        {
            InitObjects();

            while (gameLoop.GameLoopActive() == true)
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(0, 0);
                npc.Draw();
                town.Draw();
                shop.Draw();
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

            GameEnding();



        }  

        private void InitObjects()
        {
            Map.LoadMap(0);

            items = new ItemManager();
            enemies = new EnemyManager();
            chests = new ChestManager(items);
            town = new Town("Cido", "There is a Bandit Lord on a small island in the east.\nThere is an old boat to the south you can use.");
            shop = new Shop("The $hop", $"You sure look like you could use a boat!,\ntoo bad I sold my last one to a guy in {town.Name}! :D HA,HA,HA.");
            npc.Dialogue = "To my north is water. You cannot cross without a boat.\nTo my east is a mountain. You cannot hike up the mountain.";
            HUD = new Hud();
            player = new Player(enemies, chests, town, shop, npc, HUD, items);
            town.SetPlayer(player);
            shop.SetPlayer(player);
            HUD.findTargets(player, enemies.enemy);
            chests.chestInitialize();
            enemies.enemyInitialize(player, enemies);
            chests.FindPlayer(player);
            Renderer.FindPlayer(player);
            Map.FindPlayer(player);

            gameLoop = new GameLoopConditionals(enemies, player);
        }

        private void GameEnding()
        {
            if (gameLoop.CheckCondition() == 1)
            {
                Console.Clear();
                Console.WriteLine(player.GetName() + " have died!");
                Console.ReadKey(true);
            }
            else if (gameLoop.CheckCondition() == 2)
            {
                Console.Clear();
                Console.WriteLine(player.GetName() + " have defeated all of the bandits!");
                Console.WriteLine("Upon defeating " + Global.BOSS_NAME + " and his army, you finally are at peace and able to head home.");
                Console.WriteLine("The stories of what you did travel across the land and bandits fear your name.");
                Console.ReadKey(true);
            }
            else if (gameLoop.CheckCondition() == 3)
            {
                Console.Clear();
                Console.WriteLine(player.GetName() + " have defeated the Bandit Lord!");
                Console.WriteLine("Upon defeating " + Global.BOSS_NAME + ", you realize there is work yet to be finished.");
                Console.WriteLine("You may have shattered the Bandit army, but you did not defeat all of them.");
                Console.WriteLine("The remaining bandit army caused chaos across the land as they searched for a new leader.");
                Console.ReadKey(true);
            }
        }
    }
}
