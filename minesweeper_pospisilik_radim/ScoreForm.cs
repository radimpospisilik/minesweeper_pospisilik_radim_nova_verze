using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minesweeper_pospisilik_radim
{
    /// <summary>
    /// Formulář pro zobrazení skóre a výsledků jednotlivých her.
    /// Načítá data z souboru scores.json a zobrazuje je v DataGridView.
    /// </summary>
    public partial class ScoreForm : Form
    {
        /// <summary>
        /// Konstruktor ScoreForm.
        /// Inicializuje komponenty formuláře.
        /// </summary>
        public ScoreForm()
        {
            InitializeComponent();
        }
        private void ScoreForm_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Načítá skóre ze souboru scores.json a zobrazuje je v tabulce.
        /// Pokud soubor neexistuje nebo je prázdný, zobrazí varovnou zprávu.
        /// </summary>
        private void LoadScores()
        {
            if (!File.Exists("scores.json"))
            {
                MessageBox.Show("Soubor neexistuje!");
                return;
            }

            string json = File.ReadAllText("scores.json");

            var scores = JsonSerializer.Deserialize<List<GameResult>>(json);

            if (scores == null || scores.Count == 0)
            {
                MessageBox.Show("Žádná data!");
                return;
            }

            dataGridView1.DataSource = scores;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        /// <summary>
        /// Zpracovává načtení formuláře.
        /// Při spuštění formuláře načte a zobrazí všechna skóre.
        /// </summary>
        private void ScoreForm_Load_1(object sender, EventArgs e)
        {
            LoadScores();
        }
    }
}
