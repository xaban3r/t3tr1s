using System;
using System.Collections.Generic;
using System.Text;
using Logic.TetrisFigure;

namespace Logic
{
    class Game
    {
        public int Score { get; private set; } = 0;
        public int Lvl { get; private set; } = 0;
        public bool IsEndGame { get; private set; } = false;
        
       

        public static readonly int Rows = 20;
        public static readonly int Columns = 10;

        private readonly Random random = new Random();


    }
}

