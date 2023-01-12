using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_ALDIL1.Model
{
    /// <summary>
    /// 3x3 Gamefield with char-Array 
    /// </summary>
    internal class Gamefield
    {
        public char[,] Field { get; set; }

        public Gamefield()
        {
            Field = new char[3, 3];
        }
    }
}
