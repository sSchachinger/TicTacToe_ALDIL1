using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;

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
            // Computer setzt seinen Zug zufällig
            //return GenerateRandom(gf);



            // Aktuelles Spielfeld --> [0,1,2,3,4,5,6,7]
            // int[] rootTree = int[9] {-1, 0 , +1, 0, 0 -1} ---> Node

            // Node bekommt Kinder für mögliche Spielzüge
            // Jeder der Kinder bekommt wieder Kinder für mögliche Spielzüge
            // --> Stack
            CreateTree(gf);

            return 0;






        }

        private static int GenerateRandom(Gamefield gf)
        {
            var rand = new Random();
            int nr = 0;
            do
            {
                nr = rand.Next(1, 9);

            } while (gf.field[nr].isPushed == true);
            return nr;
        }

        //public static int Minimax(Node node, bool max)
        //{
        //    int value;
        //    if (max == true)
        //    {
        //        value = int.MinValue; // Number that's smaller than what the evaluation algorithm can return

        //        foreach (Node child in node)
        //        {
        //            int m = Minimax(child, !max);  //ignore the move part
        //            value = Math.Max((byte)value, (byte)m);
        //        }
        //        return value;
        //    }
        //    else
        //    {
        //        value = int.MaxValue;
        //        foreach (Node child in node)
        //        {
        //            int?m = Minimax(child, !max); //ignore the move part
        //            value = Math.Min((byte)value, (byte)m);
        //        }
        //        return value;
        //    }
        //}

        public static int CreateTree(Gamefield gf)
        {

            Stack<Node> stack = new Stack<Node>();
            Node root = new Node(gf);         
            stack.Push(root);

            while(stack.Count > 0)
            {
                Node topNode = stack.Pop();
                // Generiere eine Liste mit den leeren Feldern des Spielfeldes
                List<int> emptyFields = topNode.gamefield.ReturnEmptyFields();

                // Für jedes leere Feld, erstelle ein Child und setze im jeweiligen Feld ein Kreuz
                foreach (int emptyField in emptyFields)
                {
                    Gamefield newChild = (Gamefield)topNode.gamefield.Clone();
                    newChild.SetField(emptyField, 'O');

                    Node node = new Node(newChild);
                    topNode.children.Add(node);

                    // Erstelle aus dem veränderten Child einen Node und pushe auf den Stack
                    stack.Push(node);
                }
                break;

            }
            




           

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

    public class Node
    {
        public Gamefield gamefield;
        public List<Node> children;

        public Node(Gamefield gf)
        {
            this.gamefield = gf;
            this.children = new List<Node>();
        }
    }



}
