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


        private Random random = new Random();
        private FriendlyNPC npc = new FriendlyNPC();
        private Hud HUD;
        private Town town;
        private List<Shop> shops = new List<Shop>();
        private EnemyManager enemies;
        private ChestManager chests;

        private GameLoopConditionals gameLoop;

        private ItemManager items;

        List<ITEM> stockListForShop1 = new List<ITEM>();
        List<ITEM> stockListForShop2 = new List<ITEM>();
        List<ITEM> stockListForShop3 = new List<ITEM>();
        /*





        */
        /// <summary>
        /// 9 left of the player is the map border
        /// 10 right of the player is the map border
        /// 4 up of the player is the map border
        /// 5 down of the player is the map border
        /// </summary>
        /// 
        //constructor
        /* public GameManager()
         {

         }*/
        //private methods
        private void SetUpShops()
        {
            stockListForShop1.Add(ITEM.POTION);
            stockListForShop1.Add(ITEM.SWORD);
            stockListForShop1.Add(ITEM.BOW);
            shops.Add(new Shop("The $hop", $"You sure look like you could use a boat!,\ntoo bad I sold my last one to a guy in {town.Name}! :D HA,HA,HA.", 16, 7, items, stockListForShop1)); // I-0
            shops[0].itemsInShop = shops[0].itemsInShop;
            shops[0].SetPlayer(player);

            stockListForShop2.Add(ITEM.POTION);
            stockListForShop2.Add(ITEM.SWORD);
            stockListForShop2.Add(ITEM.BOW);
            stockListForShop2.Add(ITEM.RAFT);
            shops.Add(new Shop("CommerceSuperCentre", "I didn't know what these other shop keepers should say", 18, 8, items, stockListForShop2)); // I-1
            shops[1].SetPlayer(player);

            stockListForShop3.Add(ITEM.SWORD);
            shops.Add(new Shop("Lorem Ipsum", "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", 19, 9, items, stockListForShop3)); // I-2
            shops[2].SetPlayer(player);
        }

        //public methods
        public void RunGame()
        {
            InitObjects();

            while (gameLoop.GameLoopActive() == true)
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(0, 0);
                npc.Draw();
                town.Draw();
                shops[0].Draw();
                shops[1].Draw();
                shops[2].Draw();
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
            enemies = new EnemyManager(random);
            chests = new ChestManager(items, random);
            town = new Town("Cido", "There is a Bandit Lord on a small island in the east.\nThere is an old boat to the south you can use.");
            
            npc.Dialogue = "To my north is water. You cannot cross without a boat.\nTo my east is a mountain. You cannot hike up the mountain.";
            HUD = new Hud();
            player = new Player(enemies, chests, town, shops, npc, HUD, items);
            town.SetPlayer(player);
            
            HUD.findTargets(player, enemies.enemy);
            chests.chestInitialize();
            enemies.enemyInitialize(player, enemies);
            chests.FindPlayer(player);
            Renderer.FindPlayer(player);
            Map.FindPlayer(player);

            SetUpShops();

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
