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
        GameResult gameResult;

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
        }

        private void GameLogic(int buttonNumber)
        {
            // Player turn
            if (gamefield.emptyFields > 0 && gameState == GameStates.PlayerTurn)
            {
                // Prüfe welcher Button gedrückt wurde
                // falls Button bereits gedrückt, mache nichts  bzw. (Meldung anzeigen)
                // falls Button noch nicht gedrückt, Button setzen
                if (gamefield.field[buttonNumber].isPushed == false)
                {
                    gamefield.SetField(buttonNumber);

                    view.UpdatePlayground(this.gamefield);

                    // Prüfen ob Spiel gewonnen
                    gameResult = gamefield.CheckGameStatus();

                    if (gameResult == GameResult.PlayerHasWon)
                    {
                        view.UpdateLabel("You won!");
                        gameState = GameStates.GameOver;
                    }
                    else gameState = GameStates.ComputerTurn;
                }
            }

            // Computer turn
            if (gamefield.emptyFields > 0 && gameState == GameStates.ComputerTurn)
            {
                // MiniMax
                int nr = GameTree.ComputersTurn(gamefield);
                // Computer Button setzen
                gamefield.SetField(nr);
                view.UpdatePlayground(this.gamefield);

                // Prüfen ob Spiel gewonnen
                gameResult = gamefield.CheckGameStatus();

                if (gameResult == GameResult.ComputerHasWon)
                {
                    view.UpdateLabel("Computer won!");
                    gameState = GameStates.GameOver;
                }
                else
                    gameState = GameStates.PlayerTurn;
            }

            if (gamefield.emptyFields <= 0 && gameState != GameStates.GameOver)
            {
                view.UpdateLabel("Tie!");
                gameState = GameStates.GameOver;
                gameResult = GameResult.Tie;
            }

            if (gameState == GameStates.GameOver && gameResult != GameResult.Tie)
                view.GameOver(gamefield.CheckWinningFields());
        }

        private void InitializeGameField()
        {
            view.InitializeGameField();
            view.UpdatePlayground(this.gamefield);
            gameState = GameStates.PlayerTurn;
            gameResult = GameResult.NoResult;
            view.UpdateLabel("You can do it!");
        }

        private void MainForm_btnClickedEvent(object? sender, int buttonNr)
        {
            // New Game - erstelle leeres Spielfeld
            if (buttonNr == 0)
            {
                gamefield = new Gamefield();
                InitializeGameField();
            }
            // Weiter im aktuellen Spielverlauf
            else GameLogic(buttonNr - 1);
        }
    }
}
