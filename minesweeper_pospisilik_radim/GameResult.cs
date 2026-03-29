using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Drawing.Text;

namespace minesweeper_pospisilik_radim
{


    public class GameResult
    {
        public int Time { get; set; }
        public int GridSize { get; set; }
        public int Mines { get; set; }
    }



}
