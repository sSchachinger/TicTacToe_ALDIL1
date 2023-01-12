using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe_ALDIL1.Model;

namespace TicTacToe_ALDIL1.Controller
{
    internal class GameController
    {
        private readonly MainForm view;
        Gamefield gamefield;
        GameStates gameState;
        
        private enum GameStates
        {
            NewGame,
            PlayerTurn,
            ComputerTurn,
            GameOver
        }


        public GameController(MainForm _form)
        {
            this.view = _form;
            gamefield = new Gamefield();

            SetupMainEventConnection();

            InitializeGameField();
            Application.Run(view);
            


        }

        private void SetupMainEventConnection()
        {
            //Button Events
            view.btnClicked += MainForm_btnClickedEvent;
            //gamefield.ModelChangedEvent += Gamefield_ModelChangedEvent;
        }

        private void Gamefield_ModelChangedEvent(object? sender, Field[] e)
        {
            UpdateGameField();
        }

        private void StateMachine(int buttonNumber)
        {
            while (gamefield.CheckGameStatus() == GameResult.NoResult)
            {
                switch (gameState)
                {
                    case GameStates.PlayerTurn:

                        // Prüfe welcher Button gedrückt wurde
                        // falls Button bereits gedrückt, mache nichts  bzw. (Meldung anzeigen)
                        // falls Button noch nicht gedrückt, Button setzen
                        if (gamefield.field[buttonNumber].symbol == ' ')
                            gamefield.SetField(buttonNumber, 'X');
                        UpdateGameField();
                        // Prüfen ob Spiel gewonnen
                        if (gamefield.CheckGameStatus() == GameResult.PlayerHasWon)
                            gameState = GameStates.GameOver;
                        else
                            gameState = GameStates.ComputerTurn;
                        break;


                    case GameStates.ComputerTurn:
                        // Computer an der Reihe
                        // MiniMax
                        int nr = GameTree.ComputersTurn(gamefield);
                        // Computer Button setzen
                        gamefield.SetField(nr, 'O');

                        // Prüfen ob Spiel gewonnen
                        if (gamefield.CheckGameStatus() == GameResult.ComputerHasWon)
                            gameState = GameStates.GameOver;
                        else
                            gameState = GameStates.PlayerTurn;
                        break;

                    case GameStates.GameOver:


                    default:
                        break;
                }
            }

           

        }

        

        private void InitializeGameField()
        {
            gamefield = new Gamefield();
         
            UpdateGameField();
            gameState = GameStates.PlayerTurn;
        }
        private void UpdateGameField()
        {
            foreach (var f in this.gamefield.field)
            {
                view.UpdatePlayground(f.fieldNumber, f.symbol);
            }
        }

        private void MainForm_btnClickedEvent(object? sender, int e)
        {
            // NUR ZUM TESTEN
            //view.UpdatePlayground(e, 'O');
            //view.UpdateLabel("You got it!");

            // New Game - erstelle leeres Spielfeld
            if (e == 0) InitializeGameField();
            // Weiter im aktuellen Spielverlauf
            else StateMachine(e);


        }
    }
}
