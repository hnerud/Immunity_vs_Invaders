﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Immunity_vs_Invaders
{
    class PersistentGameData
    {
        public bool JustWon
        {
            get;
            set;
        }
        public LevelDescription CurrentLevel { get; set; }
        public PersistentGameData()
        {
            JustWon = false;
        }
    }
}
