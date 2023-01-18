using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace TicTacToe_ALDIL1.Model
{
    public enum GameResult
    {
        ComputerHasWon,
        PlayerHasWon,
        Tie,
        NoResult
    }
    /// <summary>
    /// 3x3 Gamefield with char-Array 
    /// </summary>
    public class Gamefield
    {
        public Field[] field { get; set; }
        public int EmptyFields;
        public int lastSetted { get; set; }

        public Gamefield()
        {
            int number = 1;
            field = new Field[9];
            EmptyFields = 9;
            for (int i = 0; i < field.Length; i++)
            {
                field[i] = new Field(number);
                number++;
            }
        }

        public List<int> ReturnEmptyFields()
        {
            List<int> emptyFieldList = new List<int>();
            for (int i = 0; i < field.Length; i++)
            {
                if (!field[i].isPushed) emptyFieldList.Add(i);
            }
            return emptyFieldList;
        }

        public void SetField(int fieldNumber)
        {
            if (EmptyFields % 2 == 1)
            {
                field[fieldNumber].symbol = 'X';
                field[fieldNumber].value = -1;
            }

            else 
            {
                field[fieldNumber].symbol = 'O';
                field[fieldNumber].value = +1;

            }
            field[fieldNumber].isPushed = true;
            EmptyFields--;
            lastSetted = fieldNumber;
        }


        public GameResult CheckGameStatus()
        {
            // Prüfe ob 3 in einer Reihe sind
            GameResult res = GameResult.NoResult;

            List<int[]> testOrder = new List<int[]>
            {
                new int[]  { 0, 1, 2 },
                new int[]  { 3, 4, 5 },
                new int[]  { 6, 7, 8 },

                new int[]  { 0, 3, 6 },
                new int[]  { 1, 4, 7 },
                new int[]  { 2, 5, 8 },

                new int[]  { 0, 4, 8 },
                new int[]  { 2, 4, 6 },
            };


            foreach (int[] ord in testOrder)
            {
                res = CalcResult(this.field[ord[0]], this.field[ord[1]], this.field[ord[2]]);
                if (res != GameResult.NoResult)
                {
                    return res;
                }
            }
            return res;
        }

        private GameResult CalcResult(Field field1, Field field2, Field field3)
        {
            if (field1.value + field2.value + field3.value == 3) { return GameResult.ComputerHasWon; }
            else if (field1.value + field2.value + field3.value == -3) { return GameResult.PlayerHasWon; }
            else { return GameResult.NoResult; }
        }

        public int Utility()
        {

            switch (CheckGameStatus())
            {
                case (GameResult.PlayerHasWon):
                    return -1;
                case (GameResult.ComputerHasWon):
                    return 1;
                case (GameResult.Tie):
                    return 0;

                default:
                    break;
            }
            return 0;
        }

        public object Clone()
        {
            var obj = new Gamefield();
            for (int i = 0; i < 9; i++)
            {
                obj.field[i] = (Field)field[i].Clone();
            }
            obj.EmptyFields = EmptyFields;
            return obj;
        }
    }

    public class Field
    {
        public int fieldNumber { get; set; }
        public char symbol { get; set; }
        public bool isPushed { get; set; }
        public int value { get; set; }

        public Field(int number)
        {
            this.fieldNumber = number;
            this.symbol = ' ';
            this.isPushed = false;
            this.value = 0;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
