namespace minesweeper_pospisilik_radim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            GameForm gameForm = new GameForm();


            this.Hide();


            gameForm.ShowDialog();


            this.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();


            this.Hide();


            aboutForm.ShowDialog();


            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm();
            this.Hide();
            helpForm.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ScoreForm form = new ScoreForm();
            form.ShowDialog(); 

        }
    }
}
