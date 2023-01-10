using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe_ALDIL1.Controller;
using TicTacToe_ALDIL1.View;

namespace TicTacToe_ALDIL1
{
    internal class MainController
    {
        IView view;
        IGameController gameController;
        public MainController(IGameController ge, IView vw)
        {
            this.view = vw;  
            this.gameController = ge;

            LinkSubController();
        }

        private void LinkSubController()
        {
            throw new NotImplementedException();
        }
    }
}
