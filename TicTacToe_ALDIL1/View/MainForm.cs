using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe_ALDIL1.Model;

namespace TicTacToe_ALDIL1
{
    public partial class MainForm : Form
    {

        public event EventHandler<int> btnClicked;

        public MainForm() => InitializeComponent();

        private void BtnClicked(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button b = (Button)sender;
                if (b.Tag.ToString() == "btnNewGame")
                    btnClicked?.Invoke(this, 0);
                if (b.Tag.ToString() == "btnField1")
                    btnClicked?.Invoke(this, 1);
                if (b.Tag.ToString() == "btnField2")
                    btnClicked?.Invoke(this, 2);
                if (b.Tag.ToString() == "btnField3")
                    btnClicked?.Invoke(this, 3);
                if (b.Tag.ToString() == "btnField4")
                    btnClicked?.Invoke(this, 4);
                if (b.Tag.ToString() == "btnField5")
                    btnClicked?.Invoke(this, 5);
                if (b.Tag.ToString() == "btnField6")
                    btnClicked?.Invoke(this, 6);
                if (b.Tag.ToString() == "btnField7")
                    btnClicked?.Invoke(this, 7);
                if (b.Tag.ToString() == "btnField8")
                    btnClicked?.Invoke(this, 8);
                if (b.Tag.ToString() == "btnField9")
                    btnClicked?.Invoke(this, 9);
            }
        }


        public void UpdatePlayground(Gamefield gf)
        {
            foreach (var f in gf.field)
            {
                switch (f.fieldNumber)
                {
                    case 0:
                        break;
                    case 1:
                        btnField1.Text = f.symbol.ToString();
                        break;
                    case 2:
                        btnField2.Text = f.symbol.ToString();
                        break;
                    case 3:
                        btnField3.Text = f.symbol.ToString();
                        break;
                    case 4:
                        btnField4.Text = f.symbol.ToString();
                        break;
                    case 5:
                        btnField5.Text = f.symbol.ToString();
                        break;
                    case 6:
                        btnField6.Text = f.symbol.ToString();
                        break;
                    case 7:
                        btnField7.Text = f.symbol.ToString();
                        break;
                    case 8:
                        btnField8.Text = f.symbol.ToString();
                        break;
                    case 9:
                        btnField9.Text = f.symbol.ToString();
                        break;
                    default:
                        break;
                }
            }
        }

        public void GameOver(int[] fields)
        {
            foreach (var field in fields)
            {
                switch (field)
                {
                    case 0:
                        break;
                    case 1:
                        btnField1.BackColor = Color.Green;
                        break;
                    case 2:
                        btnField2.BackColor = Color.Green;
                        break;
                    case 3:
                        btnField3.BackColor = Color.Green;
                        break;
                    case 4:
                        btnField4.BackColor = Color.Green;
                        break;
                    case 5:
                        btnField5.BackColor = Color.Green;
                        break;
                    case 6:
                        btnField6.BackColor = Color.Green;
                        break;
                    case 7:
                        btnField7.BackColor = Color.Green;
                        break;
                    case 8:
                        btnField8.BackColor = Color.Green;
                        break;
                    case 9:
                        btnField9.BackColor = Color.Green;
                        break;
                    default:
                        break;
                }
            }
        }

        public void InitializeGameField()
        {
            btnField1.BackColor = Color.LightGray;
            btnField2.BackColor = Color.LightGray;
            btnField3.BackColor = Color.LightGray;
            btnField4.BackColor = Color.LightGray;
            btnField5.BackColor = Color.LightGray;
            btnField6.BackColor = Color.LightGray;
            btnField7.BackColor = Color.LightGray;
            btnField8.BackColor = Color.LightGray;
            btnField9.BackColor = Color.LightGray;
        }

        public void UpdateLabel(string text)
        {
            lbOutput.Text = text;
        }
    }


}
