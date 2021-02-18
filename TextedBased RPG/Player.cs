using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class Player : CharacterSystem
    {
        public int CharacterXOffset = 0;
        public int CharacterYOffset = 0;
        private string input;
        private bool AttackOrMove = false; //false = attack    true = move
        private bool Moving = true;

        private Enemy enemy;
        private GameManager GM;


        public Player(Enemy enemyTarget, GameManager GMTarget)
        {
            enemy = enemyTarget;
            GM = GMTarget;
            maxHealth = 100;
            health = maxHealth;
            name = "You";
            Alive = true;
            CharacterX = 14;
            CharacterY = 5;
            baseAttack = 10;
            attack = baseAttack;
        }
        public void DrawPlayer()
        {
            
                Console.ForegroundColor = ConsoleColor.Red;
                Map.mapData[CharacterY, CharacterX] = "@";
                Console.ForegroundColor = ConsoleColor.White;
            
            
        }
       
        private bool CheckPlayerInput()
        {
            if (input == ConsoleKey.W.ToString())
            {
                if(CharacterY > MinPos)
                {
                    if(Map.mapData[CharacterY-1, CharacterX] == "E")
                    {
                        AttackOrMove = false;
                    }
                    else if (Map.mapData[CharacterY - 1, CharacterX] == "~")
                    {
                        AttackOrMove = true;
                        Moving = false;
                    }
                    else if (Map.mapData[CharacterY - 1, CharacterX] == "^")
                    {
                        AttackOrMove = true;
                        Moving = false;
                    }
                    else
                    {
                        AttackOrMove = true;
                        Moving = true;
                    }
                }
            }
            else if (input == ConsoleKey.A.ToString())
            {
                if (CharacterX > MinPos)
                {
                    if (Map.mapData[CharacterY, CharacterX - 1] == "E")
                    {
                        AttackOrMove = false;
                    }
                    else if (Map.mapData[CharacterY, CharacterX - 1] == "~")
                    {
                        AttackOrMove = true;
                        Moving = false;
                    }
                    else if (Map.mapData[CharacterY, CharacterX - 1] == "^")
                    {
                        AttackOrMove = true;
                        Moving = false;
                    }
                    else
                    {
                        AttackOrMove = true;
                        Moving = true;
                    }
                }
            }
            else if (input == ConsoleKey.S.ToString())
            {
                if (CharacterY < MaxPosY)
                {
                    if (Map.mapData[CharacterY + 1, CharacterX] == "E")
                    {
                        AttackOrMove = false;
                    }
                    else if (Map.mapData[CharacterY+1, CharacterX] == "~")
                    {
                        AttackOrMove = true;
                        Moving = false;
                    }
                    else if (Map.mapData[CharacterY + 1, CharacterX] == "^")
                    {
                        AttackOrMove = true;
                        Moving = false;
                    }
                    else
                    {
                        AttackOrMove = true;
                        Moving = true;
                    }
                }
            }
            else if (input == ConsoleKey.D.ToString())
            {
                if (CharacterX < MaxPosX)
                {
                    if (Map.mapData[CharacterY, CharacterX + 1] == "E")
                    {
                        AttackOrMove = false;
                    }
                    else if (Map.mapData[CharacterY, CharacterX + 1] == "~")
                    {
                        AttackOrMove = true;
                        Moving = false;
                    }
                    else if (Map.mapData[CharacterY, CharacterX + 1] == "^")
                    {
                        AttackOrMove = true;
                        Moving = false;
                    }
                    else
                    {
                        AttackOrMove = true;
                        Moving = true;
                    }
                }
            }
            return AttackOrMove;
        }
        
        public void MovePlayer()
        {

            input = Console.ReadKey(true).Key.ToString();
            CheckPlayerInput();
            
            if (AttackOrMove == false)
            {
                enemy.TakeDamage(attack);
                AttackMessage = GetName() + " attacked " + enemy.GetName() + " for " + attack + " points of damage!";
            }
            else 
            {
                AttackMessage = " ";
                Map.mapData[CharacterY, CharacterX] = Map.BaseMapData[CharacterY, CharacterX];
                if (Moving == true)
                {
                    if (input == ConsoleKey.W.ToString())
                    {
                        if (CharacterYOffset > 0 && CharacterY > 25)
                        {
                            CharacterY = CharacterY - 1;
                            CharacterYOffset = CharacterYOffset - 1;
                        }
                        else
                        {
                            if (Map.yOffset > 0)
                            {
                                CharacterY = CharacterY - 1;
                                Map.yOffset = Map.yOffset - 1;
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
                            if (Map.xOffset > 0)
                            {
                                CharacterX = CharacterX - 1;
                                Map.xOffset = Map.xOffset - 1;
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
                            if (Map.yOffset < 20)
                            {
                                CharacterY = CharacterY + 1;
                                Map.yOffset = Map.yOffset + 1;
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
                        if (CharacterXOffset > 0 && CharacterX < 10)
                        {
                            CharacterX = CharacterX + 1;
                            CharacterXOffset = CharacterXOffset - 1;
                        }
                        else
                        {
                            if (Map.xOffset < 10)
                            {
                                CharacterX = CharacterX + 1;
                                Map.xOffset = Map.xOffset + 1;
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
                }
                
            }
        }
    }
}
