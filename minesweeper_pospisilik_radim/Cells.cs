using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minesweeper_pospisilik_radim
{
    public class Cells
    {
        public bool IsMine { get; set; }
        public bool IsRevealed { get; set; }

        public Cells()
        {
            IsMine = false;
            IsRevealed = false;
        }
    }

   
}
