using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace minesweeper_pospisilik_radim
{
    
    
        public class GameResult
        {
            public int Time { get; set; }
            public int GridSize { get; set; }
            public int Mines { get; set; }


       

        private void SaveGame()
        {

            GameResult result = new GameResult()
            {
                Time = Time,
                GridSize = GridSize,
                Mines = Mines
            };
            string json = JsonSerializer.Serialize(result);

            File.WriteAllText("save.json", json);

            MessageBox.Show("Uloženo!");
        }
    }
    
}
