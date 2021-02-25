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

        private Enemy[] enemy;

        public Enemy targetFoe;
        private GameManager GM;


        public Player(Enemy[] enemyTarget, GameManager GMTarget)
        {
            enemy = enemyTarget;
            GM = Program.GM;
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
                Map.RenderData[CharacterY, CharacterX] = "@";
                Console.ForegroundColor = ConsoleColor.White;
            
            
        }
       
        private bool CheckPlayerInput()
        {
            if (input == ConsoleKey.W.ToString())
            {
                if(CharacterY > MinPos)
                {
                    if(Map.RenderData[CharacterY-1, CharacterX] == "E")
                    {
                        for (int x = 1; x < Program.GM.EnemyLimit; x++)
                        {
                            if (CharacterX == Program.GM.enemy[x].CharacterX)
                            {
                                if (CharacterY-1 == Program.GM.enemy[x].CharacterY)
                                {
                                    Program.GM.enemy[x].TakeDamage(attack);
                                    PlayerAttackMessage = GetName() + " attacked " + enemy[x].GetName() + " for " + attack + " points of damage!";
                                    targetFoe = enemy[x];
                                }
                            }
                        }
                        AttackOrMove = false;
                        Map.TileDesc("You are engaged in a fight.");
                    }
                    else if (Map.RenderData[CharacterY - 1, CharacterX] == "D")
                    {
                        for (int x = 1; x < Program.GM.EnemyLimit; x++)
                        {
                            if (CharacterX == Program.GM.enemy[x].CharacterX)
                            {
                                if (CharacterY - 1 == Program.GM.enemy[x].CharacterY)
                                {
                                    Program.GM.enemy[x].TakeDamage(attack);
                                    PlayerAttackMessage = GetName() + " attacked " + enemy[x].GetName() + " for " + attack + " points of damage!";
                                    targetFoe = enemy[x];
                                }
                            }
                        }
                        AttackOrMove = false;
                        Map.TileDesc("You are engaged in a fight.");
                    }
                    else if (Map.RenderData[CharacterY - 1, CharacterX] == "B")
                    {
                        for (int x = 1; x < Program.GM.EnemyLimit; x++)
                        {
                            if (CharacterX == Program.GM.enemy[x].CharacterX)
                            {
                                if (CharacterY - 1 == Program.GM.enemy[x].CharacterY)
                                {
                                    Program.GM.enemy[x].TakeDamage(attack);
                                    PlayerAttackMessage = GetName() + " attacked " + enemy[x].GetName() + " for " + attack + " points of damage!";
                                    targetFoe = enemy[x];
                                }
                            }
                        }
                        AttackOrMove = false;
                        Map.TileDesc("You are engaged in a fight.");
                    }
                    else if (Map.RenderData[CharacterY - 1, CharacterX] == "~")
                    {
                        AttackOrMove = true;
                        Moving = false;
                        Map.TileDesc("You cannot cross without a boat.");
                    }
                    else if (Map.RenderData[CharacterY - 1, CharacterX] == "^")
                    {
                        AttackOrMove = true;
                        Moving = false;
                        Map.TileDesc("You cannot go hiking without hiking boots.");
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
                    if (Map.RenderData[CharacterY, CharacterX - 1] == "E")
                    {
                        for (int x = 1; x < Program.GM.EnemyLimit; x++)
                        {
                            if (CharacterX-1 == Program.GM.enemy[x].CharacterX)
                            {
                                if (CharacterY == Program.GM.enemy[x].CharacterY)
                                {
                                    Program.GM.enemy[x].TakeDamage(attack);
                                    PlayerAttackMessage = GetName() + " attacked " + enemy[x].GetName() + " for " + attack + " points of damage!";
                                    targetFoe = enemy[x];
                                }
                            }
                        }
                        AttackOrMove = false;
                        Map.TileDesc("You are engaged in a fight.");
                    }
                    else if (Map.RenderData[CharacterY, CharacterX-1] == "D")
                    {
                        for (int x = 1; x < Program.GM.EnemyLimit; x++)
                        {
                            if (CharacterX - 1 == Program.GM.enemy[x].CharacterX)
                            {
                                if (CharacterY == Program.GM.enemy[x].CharacterY)
                                {
                                    Program.GM.enemy[x].TakeDamage(attack);
                                    PlayerAttackMessage = GetName() + " attacked " + enemy[x].GetName() + " for " + attack + " points of damage!";
                                    targetFoe = enemy[x];
                                }
                            }
                        }
                        AttackOrMove = false;
                        Map.TileDesc("You are engaged in a fight.");
                    }
                    else if (Map.RenderData[CharacterY, CharacterX - 1] == "B")
                    {
                        for (int x = 1; x < Program.GM.EnemyLimit; x++)
                        {
                            if (CharacterX - 1 == Program.GM.enemy[x].CharacterX)
                            {
                                if (CharacterY == Program.GM.enemy[x].CharacterY)
                                {
                                    Program.GM.enemy[x].TakeDamage(attack);
                                    PlayerAttackMessage = GetName() + " attacked " + enemy[x].GetName() + " for " + attack + " points of damage!";
                                    targetFoe = enemy[x];
                                }
                            }
                        }
                        AttackOrMove = false;
                        Map.TileDesc("You are engaged in a fight.");
                    }
                    else if (Map.RenderData[CharacterY, CharacterX - 1] == "~")
                    {
                        AttackOrMove = true;
                        Moving = false;
                        Map.TileDesc("You cannot cross without a boat.");
                    }
                    else if (Map.RenderData[CharacterY, CharacterX - 1] == "^")
                    {
                        AttackOrMove = true;
                        Moving = false;
                        Map.TileDesc("You cannot go hiking without hiking boots.");
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
                    if (Map.RenderData[CharacterY + 1, CharacterX] == "E")
                    {
                        for (int x = 1; x < Program.GM.EnemyLimit; x++)
                        {
                            if (CharacterX == Program.GM.enemy[x].CharacterX)
                            {
                                if (CharacterY+1 == Program.GM.enemy[x].CharacterY)
                                {
                                    Program.GM.enemy[x].TakeDamage(attack);
                                    PlayerAttackMessage = GetName() + " attacked " + enemy[x].GetName() + " for " + attack + " points of damage!";
                                    targetFoe = enemy[x];
                                }
                            }
                        }
                        AttackOrMove = false;
                        Map.TileDesc("You are engaged in a fight.");
                    } else if (Map.RenderData[CharacterY + 1, CharacterX] == "D")
                    {
                        for (int x = 1; x < Program.GM.EnemyLimit; x++)
                        {
                            if (CharacterX == Program.GM.enemy[x].CharacterX)
                            {
                                if (CharacterY + 1 == Program.GM.enemy[x].CharacterY)
                                {
                                    Program.GM.enemy[x].TakeDamage(attack);
                                    PlayerAttackMessage = GetName() + " attacked " + enemy[x].GetName() + " for " + attack + " points of damage!";
                                    targetFoe = enemy[x];
                                }
                            }
                        }
                        AttackOrMove = false;
                        Map.TileDesc("You are engaged in a fight.");
                    } else if (Map.RenderData[CharacterY + 1, CharacterX] == "B")
                    {
                        for (int x = 1; x < Program.GM.EnemyLimit; x++)
                        {
                            if (CharacterX == Program.GM.enemy[x].CharacterX)
                            {
                                if (CharacterY + 1 == Program.GM.enemy[x].CharacterY)
                                {
                                    Program.GM.enemy[x].TakeDamage(attack);
                                    PlayerAttackMessage = GetName() + " attacked " + enemy[x].GetName() + " for " + attack + " points of damage!";
                                    targetFoe = enemy[x];
                                }
                            }
                        }
                        AttackOrMove = false;
                        Map.TileDesc("You are engaged in a fight.");
                    }
                    else if (Map.RenderData[CharacterY+1, CharacterX] == "~")
                    {
                        AttackOrMove = true;
                        Moving = false;
                        Map.TileDesc("You cannot cross without a boat.");
                    }
                    else if (Map.RenderData[CharacterY + 1, CharacterX] == "^")
                    {
                        AttackOrMove = true;
                        Moving = false;
                        Map.TileDesc("You cannot go hiking without hiking boots.");
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
                    if (Map.RenderData[CharacterY, CharacterX + 1] == "E")
                    {
                        for (int x = 1; x < Program.GM.EnemyLimit; x++)
                        {
                            if (CharacterX + 1 == Program.GM.enemy[x].CharacterX)
                            {
                                if (CharacterY == Program.GM.enemy[x].CharacterY)
                                {
                                    Program.GM.enemy[x].TakeDamage(attack);
                                    PlayerAttackMessage = GetName() + " attacked " + enemy[x].GetName() + " for " + attack + " points of damage!";
                                    targetFoe = enemy[x];
                                }
                            }
                        }
                        AttackOrMove = false;
                        Map.TileDesc("You are engaged in a fight.");
                    }
                    else if (Map.RenderData[CharacterY, CharacterX + 1] == "D")
                    {
                        for (int x = 1; x < Program.GM.EnemyLimit; x++)
                        {
                            if (CharacterX + 1 == Program.GM.enemy[x].CharacterX)
                            {
                                if (CharacterY  == Program.GM.enemy[x].CharacterY)
                                {
                                    Program.GM.enemy[x].TakeDamage(attack);
                                    PlayerAttackMessage = GetName() + " attacked " + enemy[x].GetName() + " for " + attack + " points of damage!";
                                    targetFoe = enemy[x];
                                }
                            }
                        }
                        AttackOrMove = false;
                        Map.TileDesc("You are engaged in a fight.");
                    }
                    else if (Map.RenderData[CharacterY, CharacterX + 1] == "B")
                    {
                        for (int x = 1; x < Program.GM.EnemyLimit; x++)
                        {
                            if (CharacterX + 1 == Program.GM.enemy[x].CharacterX)
                            {
                                if (CharacterY  == Program.GM.enemy[x].CharacterY)
                                {
                                    Program.GM.enemy[x].TakeDamage(attack);
                                    targetFoe = enemy[x];
                                    PlayerAttackMessage = GetName() + " attacked " + enemy[x].GetName() + " for " + attack + " points of damage!";
                                }
                            }
                        }
                        AttackOrMove = false;
                        Map.TileDesc("You are engaged in a fight.");
                    }
                    else if (Map.RenderData[CharacterY, CharacterX + 1] == "~")
                    {
                        AttackOrMove = true;
                        Moving = false;
                        Map.TileDesc("You cannot cross without a boat.");
                    }
                    else if (Map.RenderData[CharacterY, CharacterX + 1] == "^")
                    {
                        AttackOrMove = true;
                        Moving = false;
                        Map.TileDesc("You cannot go hiking without hiking boots.");
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
                
                
            }
            else 
            {
                PlayerAttackMessage = " ";
                Map.RenderData[CharacterY, CharacterX] = Map.mapData[CharacterY, CharacterX];
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
                Map.TileDesc();
                }
            }
            
        }
    }
}
