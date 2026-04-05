using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;

namespace minesweeper_pospisilik_radim
{
    /// <summary>
    /// Formulář pro hru Minesweeper.
    /// Spravuje vytváření herní desky, zpracování kliknutí na tlačítka,
    /// načítání a ukládání her.
    /// </summary>
    public partial class GameForm : Form
    {
        /// <summary>Herní deska s minami a políčky.</summary>
        private gameBoard board;
        /// <summary>2D pole tlačítek reprezentující herní grid.</summary>
        private Button[,] buttons;
        /// <summary>Velikost herního gridu (počet polí v řádku/sloupci).</summary>
        private int gridSize = 4;
        /// <summary>Počet min na herní desce.</summary>
        private int mines = 4;
        /// <summary>Čas v sekundách od začátku hry.</summary>
        int time = 0;
        /// <summary>Počet odhalených políček bez min.</summary>
        int openedCells = 0;

        /// <summary>
        /// Konstruktor GameForm.
        /// Inicializuje herní desku, tlačítka a časovač.
        /// </summary>
        public GameForm()
        {

            InitializeComponent();
            board = new gameBoard(gridSize, gridSize, mines);
            progressBar1.Value = 0;
            progressBar1.Maximum = gridSize * gridSize - mines;
            timer1.Start();

            CreateButtons();
        }
        /// <summary>
        /// Vytváří a umisťuje tlačítka na formulář podle velikosti gridu.
        /// Každé tlačítko je ústředně zarovnáno a má přiřazenou click event.
        /// </summary>
        private void CreateButtons()
        {
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
                    btn.ForeColor = Color.Black;
                    btn.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                    this.Controls.Add(btn);
                    buttons[i, j] = btn;
                }
            }
        }

        /// <summary>
        /// Zpracovává kliknutí na tlačítko.
        /// Pokud je na políčku mina, hra skončí.
        /// Jinak se políčko odhalí a zvýší se počítadlo odhalených polí.
        /// </summary>
        /// <param name="sender">Tlačítko, na které bylo kliknutí.</param>
        /// <param name="e">Parametry kliknutí.</param>
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

                if (openedCells == (gridSize * gridSize - mines))
                {
                    timer1.Stop();
                    SaveScore();
                    MessageBox.Show($"Vyhrál jsi za {time}s!");
                    ResetGame();
                }
            }
        }

        /// <summary>
        /// Zpracovává načtení formuláře.
        /// Nastavuje výchozí hodnotu ComboBoxu.
        /// </summary>
        private void GameForm_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        /// <summary>
        /// Resetuje hru - odebere tlačítka, vytvoří novou desku a nová tlačítka.
        /// Resetuje časovač a progress bar.
        /// </summary>
        private void ResetGame()
        {
            foreach (var btn in buttons)
            {
                this.Controls.Remove(btn);
            }

            openedCells = 0;
            progressBar1.Value = 0;
            progressBar1.Maximum = gridSize * gridSize - mines;
            time = 0;
            board = new gameBoard(gridSize, gridSize, mines);

            CreateButtons();
            timer1.Start();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Povoluje/zakazuje vstupní pole podle vybraného typu hry.
        /// </summary>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool custom = comboBox1.SelectedItem.ToString() == "Vlastní hra";
            textBox1.Enabled = custom;
            textBox2.Enabled = custom;
        }
        /// <summary>
        /// Zvyšuje čas každou sekundu a aktualizuje label.
        /// </summary>
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

        /// <summary>
        /// Tlačítko pro uložení hry.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveGame();
        }

        /// <summary>
        /// Ukládá aktuální hru do souboru save.json.
        /// </summary>
        private void SaveGame()
        {
            GameResult result = new GameResult()
            {
                Time = time,
                GridSize = gridSize,
                Mines = mines
            };

            string json = JsonSerializer.Serialize(result);

            File.WriteAllText("save.json", json);

            MessageBox.Show("Uloženo!");
        }

        /// <summary>
        /// Načítá uloženou hru ze souboru save.json.
        /// </summary>
        private void LoadGame()
        {
            if (!File.Exists("save.json"))
            {
                MessageBox.Show("Soubor neexistuje!");
                return;
            }

            string json = File.ReadAllText("save.json");

            GameResult result = JsonSerializer.Deserialize<GameResult>(json);

            gridSize = result.GridSize;
            mines = result.Mines;
            time = result.Time;

            ResetGame();

            MessageBox.Show("Načteno!");
        }
        /// <summary>
        /// Tlačítko pro načtení hry.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            LoadGame();
        }

        /// <summary>
        /// Zpracovává start nové hry na základě vybraného obtížnosti.
        /// Validuje vstup pro vlastní hru.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem.ToString() == "Základní hra")
            {
                gridSize = 4;
                mines = 4;

            }
            else if (comboBox1.SelectedItem.ToString() == "Jednoduchá hra")
            {
                gridSize = 2;
                mines = 1;
            }
            else if (comboBox1.SelectedItem.ToString() == "Těžká hra")
            {
                gridSize = 5;
                mines = 12;
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

                if (size >= 6)
                {
                    MessageBox.Show("Maximální velikost pole je 5");
                    size = 5;
                }

                gridSize = size;
                mines = mineCount;
            }

            ResetGame();
        }

        /// <summary>
        /// Zpracovává klávesové zkratky:
        /// Ctrl+N = Nová hra
        /// Ctrl+S = Uložit hru
        /// </summary>
        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                ResetGame();
            }


            if (e.Control && e.KeyCode == Keys.S)
            {
                SaveGame();
            }
        }

        /// <summary>
        /// Ukládá výhru do souboru scores.json.
        /// Přidává nový výsledek do seznamu všech skóre.
        /// </summary>
        private void SaveScore()
        {
            List<GameResult> scores;

            if (File.Exists("scores.json"))
            {
                string json = File.ReadAllText("scores.json");
                scores = JsonSerializer.Deserialize<List<GameResult>>(json) ?? new List<GameResult>();
            }
            else
            {
                scores = new List<GameResult>();
            }

            scores.Add(new GameResult()
            {
                Time = time,
                GridSize = gridSize,
                Mines = mines,
                IsWin = true
            });

            string newJson = JsonSerializer.Serialize(scores);
            File.WriteAllText("scores.json", newJson);

        }
    }
}









