using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using t3tr1s.Figures;

namespace t3tr1s
{
    class Game
    {

        public int Score { get; private set; } = 0;
        public int Lvl { get; private set; } = 0;
        public bool isEndGame { get; private set; } = false;
        public bool isPause { get; set; }
        private Thread thread;
        private Figure figure;
        private Figure nextFigure;
        private Figure holdFigure;
        public Figure GetFigure { get { return figure; } }
        public Figure GetNextFigure { get { return nextFigure; } }
        public Figure GetHoldFigure { get { return holdFigure; } }

        public delegate void MoveDown();
        public event MoveDown ThreadMoveDown;
        private const int timeout = 1000;
        public const int Rows = 20;
        public const int Columns = 10;

        private List<FieldElement> AllEllements = new List<FieldElement>();
        public List<FieldElement> GetAllEllements() { return AllEllements; }

        private void ThMoveDown()
        {
            while (true)
            {
                if (isEndGame)
                    thread.Abort();
                if (!isPause)
                    ThreadMoveDown?.Invoke(); //if (ThreadMoveDown != null) { ThreadMoveDown(); }
                Thread.Sleep(timeout);
            }
        }

        public void StartTheGame()
        {
            AddNewFigure();
            thread = new Thread(ThMoveDown)
            {
                IsBackground = false
            };
            thread.Start();
        }


        private void CreateNewNextFigure()
        {
            Random random = new Random();
            switch (random.Next(0, 6))   
            {
                case 0:
                    {
                        nextFigure = new FigureO();
                        break;
                    }
                case 1:
                    {
                        nextFigure = new FigureI();
                        break;
                    }
                case 2:
                    {
                        nextFigure = new FigureL();
                        break;
                    }
                case 3:
                    {
                        nextFigure = new FigureZ();
                        break;
                    }
                case 4:
                    {
                        nextFigure = new FigureT();
                        break;
                    }
                case 5:
                    {
                        nextFigure = new FigureJ();
                        break;
                    }
                case 6:
                    {
                        nextFigure = new FigureS();
                        break;
                    }
            }
            nextFigure.Generate(Columns / 2, 0);
        }


        public void AddNewFigure()
        {
            if (figure != null)
                //AllEllements.Add(figure.Elements.ForEach(el => (el.ForEach => (elem = figure.Elements)));
                AllEllements.AddRange(figure.Elements);   //ЛИБО ЗДЕСЬ ОШИБКА

            //need to check rows function

            if (nextFigure == null)
                CreateNewNextFigure();

            figure = nextFigure;

            if (figure.Collision(GetAllEllements()))
                isEndGame = true;

            CreateNewNextFigure();
        }

        /*=========MOVES=========*/

        public void RightMove()
        {
            if (isPause)
                return;
            figure.RightMove(GetAllEllements());
        }
        public void LeftMove()
        {
            if (isPause)
                return;
            figure.LeftMove(GetAllEllements());
        }
        public void DownMove()
        {
            if (isPause)
                return;
            if (!figure.DownMove(GetAllEllements()))
            {
                AddNewFigure();
            }
        }
        public void Rotate()
        {
            if (isPause) return;
            figure.Rotate(GetAllEllements());
        }

        public void EndGame()
        {
            thread.Abort();
        }
    }
}