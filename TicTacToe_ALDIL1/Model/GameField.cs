using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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

        public void SetField(int fieldNumber, char symbol)
        {
            field[fieldNumber].symbol = symbol;
            field[fieldNumber].isPushed = true;
            EmptyFields--;
        }

        public GameResult CheckGameStatus()
        {
            // Prüfe ob 3 in einer Reihe sind
            return GameResult.NoResult;
        }
    }

    public class Field
    {
        public int fieldNumber { get; set; }
        public char symbol { get; set; }
        public bool isPushed { get; set; }

        public Field(int number)
        {
            this.fieldNumber = number;
            this.symbol = ' ';
            this.isPushed = false;
        }


    }
}
