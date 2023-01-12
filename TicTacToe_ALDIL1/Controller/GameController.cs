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
        private enum GameStates
        {
            NewGame,
            PlayerTurn,
            ComputerTurn,
            CheckField,

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

        private void StartStateMachine()
        {
            // Prüfe welcher Button gedrückt wurde
            // falls Button bereits gedrückt, mache nichts  bzw. (Meldung anzeigen)
            // falls Button noch nicht gedrückt, Button setzen
            // Prüfen ob Spiel gewonnen
            // Computer an der Reihe
            // MiniMax
            // Computer Button setzen
            // Prüfen ob Spiel gewonnen
        }

        private void InitializeGameField()
        {
            Gamefield gamefield = new Gamefield();
            //foreach field in gamefield
            //view.UpdatePlayground(field, '')
        }

        private void MainForm_btnClickedEvent(object? sender, int e)
        {
            view.UpdatePlayground(e, 'O');
            view.UpdateLabel("You got it!");
            //throw new NotImplementedException();
        }
    }
}
