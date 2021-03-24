using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    abstract class Global
    {
        public static int ENEMY_COUNT = 10;
        public static int RENDER_WIDTH = 20;
        public static int RENDER_LENGTH = 10;

        public static int MAP_X_LENGTH = 58;
        public static int MAP_Y_LENGTH = 58;

        public static int BASE_ATTACK = 10;
        public static int POTION_HEAL = 25;

        public static int CHEST_LIMIT = 14;

        public static int PLAYER_Y_OFFSET = MAP_Y_LENGTH - 9;
        public static int PLAYER_X_OFFSET = MAP_X_LENGTH-19;
    }
}
