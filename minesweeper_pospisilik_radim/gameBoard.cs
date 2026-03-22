using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minesweeper_pospisilik_radim
{
    public class gameBoard
    {
        int Width;
        int Height;
        int MineCount;
        public Cells[,] Cells;

        public gameBoard(int width, int height, int mineCount)
        {
            Width = 4;
            Height = 4;
            MineCount = 4;
            Cells = new Cells[Width, Height];

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Cells[x, y] = new Cells();
                }
            }

            GenerateMines();


        }

        private void GenerateMines()
        {
            int minesPlaced = 0;
            Random random = new Random();
            while (minesPlaced < MineCount)
            {
                int x = random.Next(Width); 
                int y = random.Next(Height);

                if (!Cells[x, y].IsMine)
                {
                    Cells[x, y].IsMine = true;
                    minesPlaced++;
                    
                    
                }
            }
        }



    }
}
