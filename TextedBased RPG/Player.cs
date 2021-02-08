﻿using System;
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
        
        
        public Player()
        {
            maxHealth = 100;
            health = maxHealth;
            name = "You";
            Alive = true;
            CharacterX = 10;
            CharacterY = 5;
        }
        public void DrawPlayer()
        {
            Console.SetCursorPosition(CharacterX, CharacterY);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void MovePlayer()
        {
            string input = Console.ReadKey(true).Key.ToString(); ;
            if (input == ConsoleKey.W.ToString())
            {
                if (CharacterYOffset > 0 && CharacterY > 10)
                {
                    CharacterY = CharacterY - 1;
                    CharacterYOffset = CharacterYOffset - 1;
                }
                else
                {
                    if (Map.yOffset > 0)
                    {
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
                if (CharacterYOffset > 0 && CharacterY < 10)
                {
                    CharacterY = CharacterY + 1;
                    CharacterYOffset = CharacterYOffset - 1;
                }
                else
                {
                    if (Map.yOffset <= 10)
                    {
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