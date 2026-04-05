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
    /// <summary>
    /// Reprezentuje Form s informacemi o aplikaci, tvůrci atd.
    /// </summary>
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Tlačítko pro přepnutí zpátky do Menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            MenuForm form1 = new MenuForm();
            this.Hide();
            form1.ShowDialog();
        }
    }
}
