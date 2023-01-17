using System;
using System.Collections;
using System.Collections.Generic;

namespace TicTacToe_ALDIL1.Model
{
    public static class GameTree
    {
        public enum FieldState
        {
            Player,
            Computer

        }

        public static int ComputersTurn(Gamefield gf)
        {
            // Computer ruft Minimax auf und setzt seinen Zug
            var rand = new Random();
            int nr = 0;
            do
            {
                nr = rand.Next(1, 9);

            } while (gf.field[nr].isPushed == true);
            return nr;
        }

        public static int? Minimax(Node<int> node, bool max)
        {
            int? value;
            if (max == true)
            {
                value = int.MinValue; // Number that's smaller than what the evaluation algorithm can return

                foreach (Node<int> child in node)
                {
                    int? m = Minimax(child, !max);  //ignore the move part
                    value = Math.Max((byte)value, (byte)m);
                }
                return value;
            }
            else
            {
                value = int.MaxValue;
                foreach (Node<int> child in node)
                {
                    int? m = Minimax(child, !max); //ignore the move part
                    value = Math.Min((byte)value, (byte)m);
                }
                return value;
            }
        }

        public static int CreateTree(Gamefield gf)
        {
            Stack<Node<Gamefield>> stack = new Stack<Node<Gamefield>>();
            Node<Gamefield> root = new Node<Gamefield>(gf);
            stack.Push(root);

            //FieldState state = FieldState.Player;
            //while (stack.Count > 0)
            //{
            //    state = state.Equals(FieldState.Player) ? FieldState.Computer : FieldState.Player;
            //    var topNode = stack.Pop();
            //    var emptyFields = topNode.value.EmptyFields;

            //    while(emptyFields>0)
            //    {
            //        Gamefield newfield = new Gamefield(topNode.value);
            //        newfield.SetField(emptyFields, state);


            //        //Node < Gamefield > = new Node<Gamefield>(newfield);
            //        Node<Gamefield> node = new Node<Gamefield>(newfield);
            //        topNode.next.Add(node);
            //        emptyFields--;

            //    }
            //}
            return 1;
        }
    }

    public class Node<T> : IEnumerable, IEnumerator<T>
    {
        public T value { get; set; }

        public Node<T> next { get; set; }

        public T _previous { get; set; }

        public Node(T val, Node<T> nxt)
        {
            value = val;
            next = nxt;
        }
        public Node(T val)
        {
            value = val;
        }
        public void getEmptyChilds()
        {

        }

        private int index = 0;

        public int length { get; set; }

        public T Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            index++;
            return index <= length;
        }

        public void Reset()
        {
            index = -1;
        }

        public void Dispose()
        {
            index = 0;
        }
    }
}
