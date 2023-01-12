using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_ALDIL1.Model
{
    /// <summary>
    /// 3x3 Gamefield with char-Array 
    /// </summary>
    internal class Gamefield
    {
        public Field[] field { get; set; }

        public Gamefield()
        {
            int number = 1;
            field = new Field[9];
            for (int i = 0; i < field.GetLength(0); i++)
            {
                field[i] = new Field(number);
                number++;
            }
        }

        public void SetField(int fieldNumber, char symbol)
        {
            field[fieldNumber].symbol = symbol;
        }
    }

    public class Field
    {
        public int fieldNumber { get; set; }
        public char symbol;
        public bool isPushed;
        
        public Field(int number)
        {
            this.fieldNumber = number;
            this.symbol = ' ';
            this.isPushed = false;
        }


    }
}
