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

        private gameBoard board;
        private Button[,] buttons;

        private int gridSize = 4;
        private int mines = 4;

        int time = 0;
        int openedCells = 0;

        public GameForm()
        {

            InitializeComponent();
            board = new gameBoard(gridSize, gridSize, mines);
            progressBar1.Value = 0;
            progressBar1.Maximum = gridSize * gridSize - mines;
            timer1.Start();
            
            CreateButtons();


        }






        private void CreateButtons()
        {
            //buttons = new Button[4, 4];//
            // cells = new Cells[4, 4];//

            int buttonSize = 80;

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
                timer1.Stop();
                MessageBox.Show($"BOOM! Trefil jsi minu!");
                ResetGame();

            }
            else
            {
                btn.Text = "✓";

                openedCells++;
                progressBar1.Value = openedCells;

                // kontrola výhry
                if (openedCells == (gridSize * gridSize - mines))
                {
                    MessageBox.Show("Vyhrál jsi!");
                    ResetGame();
                }
            }
        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }

        private void ResetGame()
        {
            foreach (var btn in buttons)
            {
                this.Controls.Remove(btn);
            }

            openedCells = 0;

            // nastavení ProgressBaru
            progressBar1.Value = 0;
            progressBar1.Maximum = gridSize * gridSize - mines;

            time = 0;

            // vytvoří novou desku
            board = new gameBoard(gridSize, gridSize, mines);

            // vytvoří nové tlačítka
            CreateButtons();

            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Defaultní pole")
            {
                gridSize = 4;
                mines = 4;
            }
            else
            {
                int size;
                int mineCount;

                if (!int.TryParse(textBox1.Text, out size) ||
                    !int.TryParse(textBox2.Text, out mineCount))
                {
                    MessageBox.Show("Zadej platná čísla!");
                    return;
                }

                if (mineCount >= size * size)
                {
                    MessageBox.Show("Počet min je moc velký!");
                    return;
                }

                gridSize = size;
                mines = mineCount;
            }

            ResetGame();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool custom = comboBox1.SelectedItem.ToString() == "Vlastní pole";

            textBox1.Enabled = custom;
            textBox2.Enabled = custom;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            label1.Text = "Čas: " + time;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}








