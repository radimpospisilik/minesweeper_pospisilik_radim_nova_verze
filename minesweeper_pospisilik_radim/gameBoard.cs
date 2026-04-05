using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minesweeper_pospisilik_radim
{

    /// <summary>
    /// Reprezentuje herní desku a stará se o generování min.
    /// </summary>
    public class gameBoard
    {
        int Width;
        int Height;
        int MineCount;
        public Cells[,] Cells;

        /// <summary>
        /// Inicializuje novou herní desku.
        /// </summary>
        /// <param name="width">Šířka hrací plochy</param>
        /// <param name="height">Výška hrací plochy</param>
        /// <param name="mineCount">Počet min</param>

        public gameBoard(int width, int height, int mineCount)
        {
            Width = width;
            Height = height;
            MineCount = mineCount;
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

        /// <summary>
        /// Náhodně rozmístí miny na hrací ploše.
        /// </summary>
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
