using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe_ALDIL1
{
    public partial class Form1 : Form
    {

        public event EventHandler<int> btnClicked;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnActionClicked(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button b = (Button)sender;
                if (b.Tag.ToString() == "btnNewGame")
                {
                    btnClicked?.Invoke(this, 0);
                }
                if (b.Tag.ToString() == "btnField1")
                {
                    btnClicked?.Invoke(this, 1);
                }
                if (b.Tag.ToString() == "btnField2")
                {
                    btnClicked?.Invoke(this, 2);
                }
                if (b.Tag.ToString() == "btnField3")
                {
                    btnClicked?.Invoke(this, 3);
                }
                if (b.Tag.ToString() == "btnField4")
                {
                    btnClicked?.Invoke(this, 4);
                }
                if (b.Tag.ToString() == "btnField5")
                {
                    btnClicked?.Invoke(this, 5);
                }
                if (b.Tag.ToString() == "btnField6")
                {
                    btnClicked?.Invoke(this, 6);
                }
                if (b.Tag.ToString() == "btnField7")
                {
                    btnClicked?.Invoke(this, 7);
                }
                if (b.Tag.ToString() == "btnField8")
                {
                    btnClicked?.Invoke(this, 8);
                }
                if (b.Tag.ToString() == "btnField9")
                {
                    btnClicked?.Invoke(this, 9);
                }

            }

        }

    }

    
}
