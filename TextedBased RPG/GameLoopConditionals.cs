using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class GameLoopConditionals
    {
        private EnemyManager enemies;
        private Player player;

        private int Condition = 0; // 0 = None 1 = Player Death 2 = Enemies Killed 3 = Exit Found


        private int EndConditions = 0;
        public GameLoopConditionals(EnemyManager enemiesTarget, Player playerTarget)
        {
            player = playerTarget;
            enemies = enemiesTarget;
        }
        public bool GameLoopActive()
        {
            if(player.Alive == false)
            {
                EndConditions = EndConditions + 1;
                Condition = 1;
            } else if (enemies.AllDeadCheck() == true)
            {
                EndConditions = EndConditions + 1;
                Condition = 2;
            } else if(enemies.BossDead() == true)
            {
                Condition = 3;
                EndConditions = EndConditions + 1;
            }
            
            if(EndConditions > 0)
            {
                return false;
            } else
            {
                return true;

            }
        }

        public int CheckCondition()
        {
            return Condition;
        }
    }
}
