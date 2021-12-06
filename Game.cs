using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace t3tr1s
{
    class Game
    {
        public int Score { get; private set; } = 0;
        public int Lvl { get; private set; } = 0;
        public bool IsEndGame { get; private set; } = false;



        public static readonly int Rows = 20;
        public static readonly int Columns = 10;

        private readonly Random random = new Random();

        private List<FieldElement> AllEllements = new List<FieldElement>();
        public List<FieldElement> GetAllEllements() { return AllEllements; }
    }
}
