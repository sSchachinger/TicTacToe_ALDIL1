using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe_ALDIL1.Controller;
using TicTacToe_ALDIL1.Model;

namespace TicTacToe_ALDIL1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // View
            MainForm myMainForm = new MainForm();
            // Controller
            GameController myController = new GameController(myMainForm);

            
            
        }
    }
}
