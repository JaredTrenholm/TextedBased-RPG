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
        private static int EnemyAmount = 4;
        public Enemy[] enemy = new Enemy[EnemyAmount];
        public int EnemyLimit = EnemyAmount;
        private Chest[] chest = new Chest[4];
        private FriendlyNPC npc = new FriendlyNPC();
        private Hud HUD;
        private Town town;






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
            for(int x = 1; x< EnemyLimit; x++)
            {
            enemy[x] = new Enemy(Program.GM);
            }
            user = new Player(enemy, Program.GM);
            HUD = new Hud(user,enemy);
            for(int x = 1; x < EnemyLimit; x++)
            {
                enemy[x].GetPlayerTarget(user);
            }
            user.Alive = true;
            for (int x = 1; x < EnemyLimit; x++)
            {
                enemy[x].Alive = true;
            }
            chest[1] = new Chest();
            chest[2] = new Chest();
            chest[3] = new Chest();
            chest[1].SetPos(12, 1);
            chest[2].SetPos(11, 2);
            chest[3].SetPos(13, 3);
            npc.Dialogue = "To my north is water. You cannot cross without a boat.\nTo my east is a mountain. You cannot hike up without hiking boots.";

            user.SetSpeciesType(0);
            for (int x = 1; x < EnemyLimit; x++)
            {
                enemy[x].SetSpeciesType(0);
            }

            enemy[1].CharacterX = 1;
            enemy[1].CharacterY = 1;
            enemy[1].WeaponChange(0);
            enemy[1].SetName("Serdun");

            enemy[2].CharacterX = 2;
            enemy[2].CharacterY = 2;
            enemy[2].Avatar = "B";
            enemy[2].SetSpeciesType(1);
            enemy[2].SetName("Dory");
            enemy[1].WeaponChange(1);

            enemy[3].CharacterX = 3;
            enemy[3].CharacterY = 3;
            enemy[3].Avatar = "D";
            enemy[3].SetSpeciesType(3);
            enemy[3].SetName("Alfynn");
            enemy[1].WeaponChange(2);

            town = new Town("Midori", "Have you heard of the Bandit King down south? Heard he isn't very strong without his goons.", user);

        }


        public void GameLoop()
        {
            HUD.MainMenu();
            if (HUD.inGame == true)
            {
                Console.CursorVisible = false;
                for (int x = 0; x < 1;)
                {
                    if (user.Alive == true)
                    {
                        StartRound();
                        //Console.Clear();
                        Console.SetCursorPosition(0, 0);
                        for (int z = 1; z < EnemyLimit; z++)
                        {
                            if (enemy[z].Alive == true)
                            {
                                enemy[z].Draw();
                            }
                            else
                            {
                                Console.Clear();
                                Map.RenderData[enemy[z].CharacterY, enemy[z].CharacterX] = Map.mapData[enemy[z].CharacterY, enemy[z].CharacterX];
                                enemy[z].SetAttackMessage(" ");
                            }
                        }



                        if (user.Alive == true)
                        {
                            user.Draw();
                        }
                        else
                        {
                            x = 1;
                            Console.Clear();
                            Map.RenderData[user.CharacterY, user.CharacterX] = Map.mapData[user.CharacterY, user.CharacterX];
                        }

                        Map.Draw();
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

                        for (int z = 1; z < EnemyLimit; z++)
                        {
                            if (enemy[z].Alive == true)
                            {
                                enemy[z].EnemyTurn();
                            }
                        }


                        EndRound();

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("GAME OVER \nYou died.");
                        Console.ReadKey(true);
                    }
                }
            }
        }

        private void StartRound()
        {
            chest[1].Draw();
            chest[2].Draw();
            chest[3].Draw();
            npc.Draw();
            town.Draw();
            user.CheckHealth();
        }
        private void EndRound()
        {
           
                if (user.CharacterX == chest[1].xPos)
                {
                    if (user.CharacterY == chest[1].yPos)
                    {
                        chest[1].CheckChest(0,1);
                    }
                } else if (user.CharacterX == chest[2].xPos)
            {
                if (user.CharacterY == chest[2].yPos)
                {
                    chest[2].CheckChest(0,2);
                }
            }
            else if (user.CharacterX == chest[3].xPos)
            {
                if (user.CharacterY == chest[3].yPos)
                {
                    chest[3].CheckChest(1, 1);
                }
            }
            else if (user.CharacterX == npc.x)
                {
                    if (user.CharacterY == npc.y)
                    {
                        npc.Talk();
                    }
                }
            else if (user.CharacterX == town.x)
            {
                if (user.CharacterY == town.y)
                {
                    town.EnterTown();
                }
            }

            user.CheckHealth();
        }

        

        


        
    }
}
