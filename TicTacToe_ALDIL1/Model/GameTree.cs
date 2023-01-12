using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_ALDIL1.Model
{
    public static class GameTree
    {
        public static int ComputersTurn(Gamefield gf)
        {
            // Computer ruft Minimax auf und setzt seinen Zug
            var rand = new Random();
            int nr = 0;
            do
            {
                nr = rand.Next(9);

            } while (gf.field[nr].symbol != ' ');


            return nr;
        }
    }

    internal class Node<T>
    {
        public T value { get; set; }

        public Node<T> next { get; set; }

        public T _previous { get; set; }

        public Node(T val, Node<T> nxt)
        {
            value = val;
            next = nxt;
        }
    }
}
