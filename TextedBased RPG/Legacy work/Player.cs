using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class Player : Characters
    {
        public int CharacterXOffset = 0;
        public int CharacterYOffset = 0;
        private string input;
        private bool AttackOrMove = false; //false = attack    true = move
        private bool Moving = true;

        public string PlayerAttackMessage;

        private EnemyManager enemies;

        public Enemy targetFoe;


        public int potionNumber = 0;
        private int money;


        private ChestManager chests;
        private Town town;
        private List<Shop> shops = new List<Shop>();
        private FriendlyNPC npc;

        public bool hasBoat = false;

        private Hud HUD;




        public Player(EnemyManager enemyManagerTarget, ChestManager chestManager, Town townTarget, List<Shop> shopsTarget, FriendlyNPC npcTarget, Hud HUDTarget, ItemManager itemTarget)
        {
            npc = npcTarget;
            chests = chestManager;
            town = townTarget;
            shops = shopsTarget;
            enemies = enemyManagerTarget;
            maxHealth = 100;
            money = 0;
            health = maxHealth;
            name = Global.PLAYER_NAME;
            Alive = true;
            CharacterX = 14;
            CharacterY = 5;
            attack = baseAttack;
            SetSpeciesType(0);
            HUD = HUDTarget;
            items = itemTarget;
        }
        public int Money { get { return money; } }

        public void Draw()
        {
            
                Renderer.RenderData[CharacterY, CharacterX] = "@";
            
            
        }
        public void Update()
        {
            Chest chestTarget = chests.LocateChest(CharacterX, CharacterY);
            if (chestTarget != null)
            {
                chestTarget.CheckChest();
            }
            if (CharacterX == npc.x)
            {
                if (CharacterY == npc.y)
                {
                    npc.Talk();
                }
            }
            else if (CharacterX == town.x)
            {
                if (CharacterY == town.y)
                {
                    town.EnterTown();
                }
            }
            for (int i = 0; i < shops.Count; i++)
            { 
                if (CharacterX == shops[i].x)
                {
                    if (CharacterY == shops[i].y)
                    {
                        shops[i].EnterShop();
                    }
                }
            }

            CheckHealth();
        }
            
       
        private void CheckPlayerInput()
        {
            int xModified = 0;
            int yModified = 0;
            if (input == ConsoleKey.W.ToString())
            {
                xModified = CharacterX;
                yModified = CharacterY - 1;
            }
            else if (input == ConsoleKey.A.ToString())
            {
                xModified = CharacterX-1;
                yModified = CharacterY;
            }
            else if (input == ConsoleKey.S.ToString())
            {
                xModified = CharacterX;
                yModified = CharacterY + 1;
            }
            else if (input == ConsoleKey.D.ToString())
            {
                xModified = CharacterX + 1;
                yModified = CharacterY;
            }

            if ((xModified < 0) || (xModified >= Global.MAP_X_LENGTH+1))
            {
                xModified = CharacterX;
            }
            if ((yModified < 0) || (yModified >= Global.MAP_Y_LENGTH + 1))
            {
                yModified = CharacterY;
            }

            targetFoe = enemies.LocateEnemy(xModified, yModified);
            if(targetFoe != null)
            {
                PlayerAttackMessage = GetName() + " attacked " + targetFoe.GetName() + " for " + attack + " points of damage!";
                targetFoe.TakeDamage(attack);
                HUD.GetEnemy(targetFoe);
                AttackOrMove = false;
                Moving = false;
                Renderer.TileDesc("You are engaged in a fight.");
            } else
            {
                AttackOrMove = true;
                HUD.GetEnemy(targetFoe);
            }

            try
            {
                Renderer.RenderData[yModified, xModified] = "@";
                Moving = true;
                Renderer.RenderData[yModified, xModified] = Map.mapData[yModified, xModified];
            }
            catch
            {
                Moving = false;
            }

            string tile = Map.GetTile(yModified, xModified);
            if(tile == "~")
            {
                if (hasBoat == false)
                {
                    Moving = false;
                    Renderer.TileDesc("You cannot cross without a boat.");
                } else
                {
                    Moving = true;
                }
            } else if (tile == "^")
            {
                Moving = false;
                Renderer.TileDesc("You cannot cross the mountains!");
            }
            else if (tile == "*")
            {
                Moving = true;
            }
            else if (tile == "'")
            {
                Moving = true;
            }

        }
        
        public void MovePlayer()
        {
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;
            input = Console.ReadKey(true).Key.ToString();
            if (input == ConsoleKey.P.ToString())
            {
                if(potionNumber > 0)
                {
                    UseItem(ITEM.POTION); 
                    potionNumber = potionNumber - 1;
                } else
                {
                    Console.Clear();
                    Console.WriteLine("You do not have potions to use.");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            }
            else
            {
                CheckPlayerInput();
            }
            
            if (AttackOrMove == false)
            {
                
                
            }
            else 
            {
                if((CharacterX < 0) || (CharacterX == Global.MAP_X_LENGTH + 1))
                {
                    Moving = false;
                }
                if ((CharacterY < 0) || (CharacterY == Global.MAP_Y_LENGTH + 1))
                {
                    Moving = false;
                }
                PlayerAttackMessage = " ";
                Renderer.RenderData[CharacterY, CharacterX] = Map.mapData[CharacterY, CharacterX];
                if (Moving == true)
                {
                    if (input == ConsoleKey.W.ToString())
                    {
                        if (CharacterYOffset > 0 && CharacterY > Map.MapYLength - 4)
                        {
                            CharacterY = CharacterY - 1;
                            CharacterYOffset = CharacterYOffset - 1;
                        }
                        else
                        {
                            if (Renderer.yOffset > 0)
                            {
                                CharacterY = CharacterY - 1;
                                Renderer.yOffset = Renderer.yOffset - 1;
                            }
                            else
                            {
                                if (CharacterY > MinPos)
                                {
                                    CharacterY = CharacterY - 1;
                                    CharacterYOffset = CharacterYOffset + 1;

                                }
                            }
                        }
                    }
                    else if (input == ConsoleKey.A.ToString())
                    {
                        if (CharacterXOffset > 0 && CharacterX > 10)
                        {
                            CharacterX = CharacterX - 1;
                            CharacterXOffset = CharacterXOffset - 1;
                        }
                        else
                        {
                            if (Renderer.xOffset > 0)
                            {
                                CharacterX = CharacterX - 1;
                                Renderer.xOffset = Renderer.xOffset - 1;
                            }
                            else
                            {
                                if (CharacterX > MinPos)
                                {
                                    CharacterX = CharacterX - 1;
                                    CharacterXOffset = CharacterXOffset + 1;

                                }
                            }
                        }
                    }
                    else if (input == ConsoleKey.S.ToString())
                    {
                        if (CharacterYOffset > 0 && CharacterY < 5)
                        {
                            CharacterY = CharacterY + 1;
                            CharacterYOffset = CharacterYOffset - 1;
                        }
                        else
                        {
                            if (Renderer.yOffset < Global.PLAYER_Y_OFFSET)
                            {
                                CharacterY = CharacterY + 1;
                                Renderer.yOffset = Renderer.yOffset + 1;
                            }
                            else
                            {
                                if (CharacterY < MaxPosY)
                                {
                                    CharacterY = CharacterY + 1;
                                    CharacterYOffset = CharacterYOffset + 1;

                                }
                            }
                        }
                    }
                    else if (input == ConsoleKey.D.ToString())
                    {
                        if (CharacterXOffset > 0 && CharacterX < Map.MapXLength - 9)
                        {
                            CharacterX = CharacterX + 1;
                            CharacterXOffset = CharacterXOffset - 1;
                        }
                        else
                        {
                            if (Renderer.xOffset < Global.PLAYER_X_OFFSET)
                            {
                                CharacterX = CharacterX + 1;
                                Renderer.xOffset = Renderer.xOffset + 1;
                            }
                            else
                            {
                                if (CharacterX < MaxPosX)
                                {
                                    CharacterX = CharacterX + 1;
                                    CharacterXOffset = CharacterXOffset + 1;

                                }
                            }
                        }
                    }
                    Renderer.TileDesc();
                }
            }
            
        }

        public void CashGain(int amount)
        {
            money = money + amount;
        }
        public void CashSpend(int amount)
        {
            money = money - amount;
        }
    }
}
