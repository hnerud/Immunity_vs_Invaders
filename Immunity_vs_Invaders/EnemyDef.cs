using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace Immunity_vs_Invaders
{
    class EnemyDef
    {
        public string EnemyType { get; set; }
        public Vector StartPosition { get; set; }
        public double LaunchTime { get; set; }

        public EnemyDef()
        {
            EnemyType = "particles";
            StartPosition = new Vector(300, 0, 0);
            LaunchTime = 0;

        }

        public EnemyDef(string enemyType, Vector startPosition, double launchtime)
        {
            EnemyType = enemyType;
            StartPosition = startPosition;
            LaunchTime = launchtime;
        }
    }
}
