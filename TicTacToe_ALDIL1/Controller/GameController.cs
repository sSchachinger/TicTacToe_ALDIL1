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
            SetupMainEventConnection();

            InitializeGameField();
            Application.Run(view);
        }

        private void SetupMainEventConnection()
        {
            //Button Events
            view.btnClicked += MainForm_btnClickedEvent;
        }

        private void GameLogic(int buttonNumber)
        {
            if (gamefield.EmptyFields > 0 && gameState == GameStates.PlayerTurn)
            {
                // Prüfe welcher Button gedrückt wurde
                // falls Button bereits gedrückt, mache nichts  bzw. (Meldung anzeigen)
                // falls Button noch nicht gedrückt, Button setzen
                if (gamefield.field[buttonNumber].isPushed == false)
                    gamefield.SetField(buttonNumber, 'X');
                UpdateGameField();
                // Prüfen ob Spiel gewonnen
                if (gamefield.CheckGameStatus(this.gamefield) == GameResult.PlayerHasWon)
                {
                    view.UpdateLabel("You won!");
                    gameState = GameStates.GameOver;
                }
                else
                    gameState = GameStates.ComputerTurn;
            }


            if (gamefield.EmptyFields > 0 && gameState == GameStates.ComputerTurn)
            {
                // Computer an der Reihe
                // MiniMax
                int nr = GameTree.ComputersTurn(gamefield);
                // Computer Button setzen
                //gamefield.SetField(nr, 'O');
                UpdateGameField();
                // Prüfen ob Spiel gewonnen
                if (gamefield.CheckGameStatus(this.gamefield) == GameResult.ComputerHasWon)
                {
                    view.UpdateLabel("Computer won!");
                    gameState = GameStates.GameOver;
                }

                else
                    gameState = GameStates.PlayerTurn;
            }

            if (gamefield.EmptyFields <= 0 && gameState != GameStates.GameOver)
            {
                view.UpdateLabel("Tie!");
                gameState = GameStates.GameOver;
            }

            if (gameState == GameStates.GameOver)
            {
                // TODO
            }


        }

        private void InitializeGameField()
        {
            gamefield = new Gamefield();

            UpdateGameField();
            gameState = GameStates.PlayerTurn;
            view.UpdateLabel("You can do it!");
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
            // New Game - erstelle leeres Spielfeld
            if (e == 0) InitializeGameField();
            // Weiter im aktuellen Spielverlauf
            else GameLogic(e - 1);
        }
    }
}
