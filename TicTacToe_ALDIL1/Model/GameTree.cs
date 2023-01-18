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
            // Aktuelles Spielfeld --> [0,1,2,3,4,5,6,7]
            // int[] rootTree = int[9] {-1, 0 , +1, 0, 0 -1} ---> Node

            // Node bekommt Kinder für mögliche Spielzüge
            // Jeder der Kinder bekommt wieder Kinder für mögliche Spielzüge
            // --> Stack
            Node root = CreateTree(gf);
            int nr = Minimax(root, true);


            // Computer setzt seinen Zug zufällig
            //return GenerateRandom(gf);
            return nr;
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

        public static int Minimax(Node node, bool max)
        {
            int value;
            int maxUtility = int.MinValue;
            int minUtility = int.MaxValue;

            if (node.children.Count == 0)
            {
                int ut =  node.gamefield.Utility();        
                return ut;
            }

            if (max)
            {

                for (int i = 0; i < node.children.Count; i++)
                {
                    Node child = node.children[i];
                    value = Minimax(child, !max);
                    maxUtility = Math.Max(maxUtility, value);
                }
                return maxUtility;
            }
            else
            {
                for (int i = 0; i < node.children.Count; i++)
                {
                    Node child = node.children[i];
                    value = Minimax(child, !max);
                    minUtility = Math.Min(minUtility, value);
                }
                return minUtility;
            }
        }

        public static Node CreateTree(Gamefield gf)
        {
            char symbol = 'O';
            Stack<Node> stack = new Stack<Node>();
            Node root = new Node(gf); //aktuelles Gamefield wird als Rootknoten definiert
            stack.Push(root);

            while (stack.Count > 0)
            {
                Node topNode = stack.Pop();
                // Generiere eine Liste mit den leeren Feldern des Spielfeldes
                List<int> emptyFields = topNode.gamefield.ReturnEmptyFields();

                // Für jedes leere Feld, erstelle ein Child und setze abwechseln jeweiligen Feld ein Kreuz
                
                
                // Baum soll nicht weitergeführt werden, wenn bereits jemand gewonnen hat
                foreach (int emptyField in emptyFields)
                {             
                    Gamefield newChild = new Gamefield();
                    newChild = (Gamefield)topNode.gamefield.Clone();
                    newChild.SetField(emptyField, symbol);

                    Node node = new Node(newChild);
                    topNode.children.Add(node);

                    // Erstelle aus dem veränderten Child einen Node und pushe auf den Stack
                    if (GameResult.NoResult == node.gamefield.CheckGameStatus())
                    {
                        stack.Push(node);
                    }
                    
                }
                if (symbol == 'O') symbol = 'X';
                else symbol = 'O';
                //break;
            }

            return root;
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
