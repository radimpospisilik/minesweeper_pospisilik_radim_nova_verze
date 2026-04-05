// Radim Pospíšilík
// 4.C
// PVA
// Minesweeper (hledání min)

namespace minesweeper_pospisilik_radim
{
    /// <summary>
    /// Form pro menu aplikace, zobrazuje smìrovací tlaèítka.
    /// </summary>
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Tlaèítko, které pøepíná mezi Menu a gameForm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            GameForm gameForm = new GameForm();
            this.Hide();
            gameForm.ShowDialog();
            this.Show();

        }
        /// <summary>
        /// Tlaèítko pro pøepínání mezi Menu a O aplikaci.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            this.Hide();
            aboutForm.ShowDialog();
        }

        /// <summary>
        /// Tlaèítko pro pøepínání mezi Menu a Nápovìdou.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm();
            this.Hide();
            helpForm.ShowDialog();
        }
        /// <summary>
        /// Tlaèítko pro pøepínání mezi Menu a Skore.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            ScoreForm form = new ScoreForm();
            form.ShowDialog();
        }
    }
}
