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
    public partial class MainForm : Form
    {

        public event EventHandler<int> btnClicked;

        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnClicked(object sender, EventArgs e)
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

        public void UpdatePlayground(int field, char symbol)
        {
            switch (field)
            {
                case 0:
                    break;
                case 1:
                    btnField1.Text = symbol.ToString();
                    break;
                case 2:
                    btnField2.Text = symbol.ToString();
                    break;
                case 3:
                    btnField3.Text = symbol.ToString();
                    break;
                case 4:
                    btnField4.Text = symbol.ToString();
                    break;
                case 5:
                    btnField5.Text = symbol.ToString();
                    break;
                case 6:
                    btnField6.Text = symbol.ToString();
                    break;
                case 7:
                    btnField7.Text = symbol.ToString();
                    break;
                case 8:
                    btnField8.Text = symbol.ToString();
                    break;
                case 9:
                    btnField9.Text = symbol.ToString();
                    break;
                default:
                    break;
            }
            
        }

    }

    
}
