using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace globaledit_Rovers
{
    public class Grid
    {
        public int maxX { get; set; }
        public int maxY { get; set; }

        /// <summary>
        /// Defualt constructor
        /// </summary>
        public Grid() { }

        /// <summary>
        /// Create grid
        /// </summary>
        /// <param name="x">width</param>
        /// <param name="y">height</param>
        public Grid(int x, int y) 
        {
            this.maxX = x;
            this.maxY = y;
        }


    }
}
