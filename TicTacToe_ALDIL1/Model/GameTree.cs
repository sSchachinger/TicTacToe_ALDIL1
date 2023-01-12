using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_ALDIL1.Model
{
    internal class GameTree
    {
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
