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


        

       

        private void SaveGame()
        {
            GameResult result = new GameResult()
            {
                Mines = Mines,
                Time = Time,
                GridSize = GridSize,
            };

            string json = JsonSerializer.Serialize(result);

            File.WriteAllText("save.json", json);

            MessageBox.Show("Uloženo!");
        }

        private void LoadGame()
        {
            if (!File.Exists("save.json"))
            {
                MessageBox.Show("Soubor neexistuje!");
                return;
            }

            string json = File.ReadAllText("save.json");

            GameResult result = JsonSerializer.Deserialize<GameResult>(json);

            // nastav hodnoty zpět
            GridSize = result.GridSize;
            Mines = result.Mines;
            Time = result.Time;

            

            MessageBox.Show("Načteno!");
        }

       
        
    }

   
    
}
