using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace globaledit_Rovers
{
    class Program
    {
        // assumption the input is sent in a file
        static List<Coordinates> scents = new List<Coordinates>();
        static Int16 maxX = 0;
        static Int16 maxY = 0;

        /// <summary>
        /// Move Mars Rovers
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            StreamReader file = new StreamReader(@"..\..\input\small.in");
            TextWriter tw = new StreamWriter(@"..\..\output\output.txt");

            try
            {
                
                string upperRightCoordinates = file.ReadLine();

                if (!string.IsNullOrEmpty(upperRightCoordinates))
                {
                    // get coordiantes
                    string[] coords = upperRightCoordinates.Split(' ');
                    maxX = Convert.ToInt16(coords[0]);
                    maxY = Convert.ToInt16(coords[1]);

                    if (maxX == 0 && maxY == 0)
                    {
                        Console.WriteLine("The grid is too small");
                        tw.WriteLine("The grid is too small");
                    }
                    else 
                    {
                        // make grid
                        Grid roverGrid = new Grid(maxX, maxY);

                        while (!file.EndOfStream)
                        {
                            //initial rover data
                            string[] roverData = file.ReadLine().Split(' ');

                            if (roverData.Length == 3)
                            {
                                Int16 startPosX = Convert.ToInt16(roverData[0]);
                                Int16 startPosY = Convert.ToInt16(roverData[1]);
                                string direction = roverData[2];

                                Console.WriteLine("Creating new rover.....");
                                Rover rover = new Rover(startPosX, startPosY, direction);

                                //rover movements
                                char[] movements = file.ReadLine().ToArray();

                                //execute movements
                                ExecuteMovements(rover, movements, roverGrid);

                                // display current location
                                if (rover.isLost)
                                {
                                    //Console.WriteLine(rover.coords.x + " "+ rover.coords.y + " " + rover.direction  );
                                    tw.WriteLine(rover.coords.x + " " + rover.coords.y + " " + rover.direction + " LOST");
                                }
                                else
                                {
                                    //Console.WriteLine(rover.coords.x + " "+ rover.coords.y + " " + rover.direction  );
                                    tw.WriteLine(rover.coords.x + " " + rover.coords.y + " " + rover.direction);
                                }
                                
                            }
                            else
                            {
                                file.ReadLine();
                                Console.WriteLine("Bad Data! Please check your inputs." );
                                tw.WriteLine("Bad Data! Please check your inputs.");
                            }
                            
                        }    
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                tw.WriteLine("Error!!! " + e.Message);
            }
            finally
            {
                file.Close(); 
                tw.Close();
            }
        }

        /// <summary>
        /// Execute all movements
        /// </summary>
        /// <param name="rover"></param>
        /// <param name="movements"></param>
        /// <param name="roverGrid"></param>
        static void ExecuteMovements(Rover rover, char[] movements, Grid roverGrid )
        {
            foreach(char move in movements)
            {
                Coordinates oldLocation = new Coordinates(rover.coords.x,rover.coords.y);

                switch (move.ToString().ToUpper())
                {
                    case "F":
                        rover.MoveFoward(scents);
                        break;

                    case "R":
                        rover.TurnRight();
                        break;

                    case "L":
                        rover.TurnLeft();
                        break;
                }

                if(!OnGrid(rover.coords))
                {
                    if (scents.Contains(oldLocation))
                    {
                        // ignore the move
                        rover.coords = oldLocation;
                    }
                    else
                    {
                        // Add scent
                        AddScent(oldLocation);

                        // revert back to old location
                        rover.coords = oldLocation;

                        // set direction to lost
                        if (rover.coords.x >= roverGrid.maxX || rover.coords.y >= roverGrid.maxY)
                        {
                            rover.isLost = true;
                        }

                        //break out of for loop because you are lost
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Add scent
        /// </summary>
        /// <param name="coord"></param>
        static void AddScent(Coordinates coord)
        {
            // make sure not to add dupes
            if (!scents.Contains(coord))
            {
                scents.Add(coord);
            }
        }

        /// <summary>
        /// Check if rover is on the grid
        /// </summary>
        /// <param name="coords"></param>
        /// <returns></returns>
        static bool OnGrid(Coordinates coords)
        {
            return (coords.x >= 0) && (coords.x <= maxX) &&
                (coords.y >= 0) && (coords.y <= maxY);
        }
    }
}
