using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minesweeper_pospisilik_radim
{
    /// <summary>
    /// Reprezentuje jedno políčko na herní desce Minesweeper.
    /// Obsahuje informace o tom, zda je tam mina a zda bylo políčko odhaleno.
    /// </summary>
    public class Cells
    {
     /// <summary>
     /// Určuje, zda se na tomto políčku nachází mina.
     /// </summary>
        public bool IsMine { get; set; }
        /// <summary>
        /// Určuje, zda bylo toto políčko odhaleno (kliknutí na něj).
        /// </summary>
        public bool IsRevealed { get; set; }

        /// <summary>
        /// Konstruktor třídy Cells.
        /// Inicializuje nové políčko bez miny a neodhaleného.
        /// </summary>
        public Cells()
        {
            IsMine = false;
            IsRevealed = false;
        }
    }

   
}
