using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TicTacToe_ALDIL1.Model
{
    public static class GameTree
    {
        public static int ComputersTurn(Gamefield gf)
        {
            Node root = CreateTree(gf);
            List<Tuple<int,int>> bestTurns = new();// Minimax für jedes Kinder der folgenden Ebene durchführen und Utilitywert in Liste speichern

            for (int i = 0; i < root.children.Count; i++)
            {
                int ut = Minimax(root.children[i], true);
                bestTurns.Add(Tuple.Create(root.children[i].gamefield.lastSetted, ut));
            }

            int bestValue = int.MinValue;
            int fieldNr = -1;

            foreach (Tuple<int, int> turn in bestTurns)
            {
                if (turn.Item2 > bestValue)
                {
                    bestValue = turn.Item2;
                    fieldNr = turn.Item1;
                }
            }
            // Computer setzt seinen Zug zufällig
            //return GenerateRandom(gf);
            return fieldNr;
        }

        //private static int GenerateRandom(Gamefield gf)
        //{
        //    var rand = new Random();
        //    int nr = 0;
        //    do
        //    {
        //        nr = rand.Next(1, 9);

        //    } while (gf.field[nr].isPushed == true);
        //    return nr;
        //}

        public static int Minimax(Node node, bool max)
        {
            int value;
            int maxUtility = int.MinValue;
            int minUtility = int.MaxValue;

            if (node.children.Count == 0)
            {
                int ut =  node.gamefield.Utility() * (node.gamefield.emptyFields + 1);        
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
            Stack<Node> stack = new Stack<Node>();
            Node root = new Node(gf); //aktuelles Gamefield wird als Rootknoten definiert
            stack.Push(root);

            while (stack.Count > 0)
            {
                Node topNode = stack.Pop();
                // Generiere eine Liste mit den leeren Feldern des Spielfeldes                        
                foreach (int emptyField in topNode.gamefield.ReturnEmptyFields())
                {             
                    Gamefield newChild = new Gamefield();
                    newChild = (Gamefield)topNode.gamefield.Clone();
                    newChild.SetField(emptyField);

                    Node node = new Node(newChild);
                    topNode.children.Add(node);

                    // Erstelle aus dem veränderten Child einen Node und pushe auf den Stack
                    // Baum soll nicht weitergeführt werden, wenn bereits jemand gewonnen hat
                    if (GameResult.NoResult == node.gamefield.CheckGameStatus())
                        stack.Push(node);
                }
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
