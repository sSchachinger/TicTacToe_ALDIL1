using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe_ALDIL1.Controller
{
    internal class GameController
    {
        private readonly MainForm mMyView;


        public GameController(MainForm _form)
        {
            this.mMyView = _form;

            SetupMainEventConnection();

            Application.Run(mMyView);
        }

        private void SetupMainEventConnection()
        {
            //Button Events
            mMyView.btnClicked += MainForm_btnClickedEvent;
        }

        private void MainForm_btnClickedEvent(object? sender, int e)
        {
            throw new NotImplementedException();
        }
    }
}
