using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace t3tr1s
{
    public class Figure
    {
        public List<FieldElement> elements { get; } = new List<FieldElement>();              // свойство
        //public List<FieldElement> Elements => elements;
        private readonly List<Color> color = new List<Color> { Colors.Red, Colors.Yellow, Colors.Green, Colors.Blue };
        private readonly Random random = new Random();

        public void SetRandomColor()
        {
            int i = random.Next(0, color.Count);
            Color col = color[i];
            elements.ForEach(element => element.color = col);                         // читается как переходит в 
        }
        public void SetColor(Color color)
        {
            elements.ForEach(element => element.color = color);
        }

        bool move { get; set; }
        public Figure() { move = true; }

        /*==========================================*/
        /*обработка движений и столкновений*/

        public bool RightMove(List<FieldElement> listOfFallenElements)                       // метод .Exists(Predicate<T> pr)  (существует ли элемент)
        {                                                                                    // с помощью лямбда-выражения проходиться по элементам листа
            //move = true;                                                                   // и возвращает последний элемент, координата х которого является
            if (!elements.Exists(element => (element.x + 1) == Game.Columns))                // последней, x+1 т.к свойство Columns возвращает 10 
            {
                if (!listOfFallenElements.Exists(lofe => elements.Exists(element => (element.x + 1) == lofe.x && element.y == lofe.y)))
                {
                    elements.ForEach(element => element.x++);
                }
            }
            return move;
        }


        public bool LeftMove(List<FieldElement> listOfFallenElements)
        {
            //move = true;                                                                 
            if (!elements.Exists(element => (element.x - 1) < 0))
            {
                if (!listOfFallenElements.Exists(lofe => elements.Exists(element => (element.x - 1) == lofe.x && element.y == lofe.y)))
                {
                    elements.ForEach(element => element.x--);
                }
            }
            return move;
        }

        public bool DownMove(List<FieldElement> listOfFallenElements)
        {
            if (!elements.Exists(element => (element.y + 1) == Game.Rows))
            {
                if (!listOfFallenElements.Exists(lofe => elements.Exists(element => (element.y + 1) == lofe.y && element.x == lofe.x)))
                {
                    elements.ForEach(element => element.y++);
                    move = true;
                }
                else move = false;
            }
            else move = false;

            return move;
        }

        /*
         * НАДО ОПИСАТЬ ROTATE
         */


    }
}
