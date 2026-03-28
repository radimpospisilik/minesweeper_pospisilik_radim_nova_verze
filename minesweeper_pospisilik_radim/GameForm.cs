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
        private Cells[,] cells;


        private void CreateButtons()
        {
            //buttons = new Button[4, 4];//
            // cells = new Cells[4, 4];//

            int buttonSize = 80;

            int gridSize = 4;


            buttons = new Button[gridSize, gridSize];

            int totalWidth = gridSize * buttonSize;
            int totalHeight = gridSize * buttonSize;

            int startX = (this.ClientSize.Width - totalWidth) / 2;
            int startY = (this.ClientSize.Height - totalHeight) / 2;


            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    Button btn = new Button();
                    btn.Width = buttonSize;
                    btn.Height = buttonSize;

                    btn.Left = startX + i * buttonSize;
                    btn.Top = startY + j * buttonSize;

                    btn.Tag = new int[] { i, j };
                    btn.Click += Button_Click;

                    btn.BackColor = Color.Transparent;
                    btn.ForeColor = Color.Blue;
                    btn.Font = new Font("Segoe UI", 14, FontStyle.Bold);

                    this.Controls.Add(btn);
                    buttons[i, j] = btn;
                }
            }





            /* for (int i = 0; i < 4; i++)
             {
                 for (int j = 0; j < 4; j++)
                 {
                     Button btn = new Button();
                     btn.Width = buttonSize;
                     btn.Height = buttonSize;
                     btn.Left = i * buttonSize;
                     btn.Top = j * buttonSize;
                     btn.BackColor = Color.Transparent;
                     btn.ForeColor = Color.Blue;
                     btn.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                     btn.Tag = new int[] { i, j };
                     btn.Click += Button_Click;
                     this.Controls.Add(btn);
                     buttons[i, j] = btn;



                 }
             } 
            */
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
                MessageBox.Show($"BOOM! Trefil jsi minu!");
                ResetGame();

            }
            else
            {
                btn.Text = "✓";
            }
        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }

        private void ResetGame()
        {
            // 1. vytvoří novou herní desku


            // 2. smaže stará tlačítka
            


            // 3. znovu vytvoří tlačítka
            CreateButtons();
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}








