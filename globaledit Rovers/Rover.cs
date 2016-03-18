using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace globaledit_Rovers
{
    public class Rover
    {
        public Coordinates coords { get; set; }
        public string direction { get; set; }
        public bool isLost { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Rover() { }

        /// <summary>
        /// Create rover with specfic coordinates for location
        /// </summary>
        /// <param name="coords"></param>
        public Rover(Coordinates coords)
        {
            this.coords = coords;
            this.isLost = false;

        }

        /// <summary>
        /// Create rover with x,y, and direction set
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="direction"></param>
        public Rover(int x, int y, string direction)
        {
            Coordinates coords = new Coordinates(x, y);
            this.coords = coords;
            this.direction = direction;
            this.isLost = false;
        }

        /// <summary>
        /// Move the rover foward
        /// </summary>
        /// <param name="scents"></param>
        public void MoveFoward(List<Coordinates> scents)
        {
            switch (direction.ToUpper())
            {
                case "N":       
                    coords.y += 1;
                    break;
                case "S":
                    coords.y -= 1;
                    break;
                case "E":
                    coords.x += 1;
                    break;
                case "W":
                    coords.x -= 1;
                    break;
            }
        }

        /// <summary>
        /// Move the rover 90 degrees to the right
        /// </summary>
        public void TurnRight()
        {
            switch (direction.ToUpper())
            {
                case "N":
                    direction = "E";
                    break;
                case "S":
                    direction = "W";
                    break;
                case "E":
                    direction = "S";
                    break;
                case "W":
                    direction = "N";
                    break;
            }
        }

        /// <summary>
        /// Move the rover 90 to the left
        /// </summary>
        public void TurnLeft()
        {
            switch (direction.ToUpper())
            {
                case "N":
                    direction = "W";
                    break;
                case "S":
                    direction = "E";
                    break;
                case "E":
                    direction = "N";
                    break;
                case "W":
                    direction = "S";
                    break;
            }
        }

    }
}
