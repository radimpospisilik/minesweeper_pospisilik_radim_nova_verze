using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minesweeper_pospisilik_radim
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
            board = new gameBoard(4, 4, 4);
            CreateButtons();
        }
        private gameBoard board;
        private Button[,] buttons;


        private void CreateButtons()
        {
            buttons = new Button[4, 4];

            int buttonSize = 80;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Button btn = new Button();
                    btn.Width = buttonSize;
                    btn.Height = buttonSize;
                    btn.Left = i * buttonSize;
                    btn.Top = j * buttonSize;

                    btn.BackColor = Color.Transparent;
                    btn.ForeColor = Color.Black;
                    btn.Font = new Font("Segoe UI", 14, FontStyle.Bold);





                    btn.Tag = new int[] { i, j };
                    btn.Click += Button_Click;

                    this.Controls.Add(btn);
                    buttons[i, j] = btn;
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int[] coords = (int[])btn.Tag;
            int x = coords[0];
            int y = coords[1];

            // Tady se bude zpracovávat klik na políčko
            if (board.Cells[x, y].IsMine)
            {
                MessageBox.Show("BOOM! Trefil jsi minu!");
            }
            else
            {
                btn.Text = "✓";
            }
        }


    }
}








