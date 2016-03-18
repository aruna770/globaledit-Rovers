• An architecture & design overview describing your application design of the entire solution. Specifically we are interested in seeing:

The main architecture of the program is that there will be 3 classes.
	Coordinates: This class encapsulates the x and Y coordinates for each rover and for each position on the grid.

	Rover: This class encapsulates the coordinates, direction and movements of each rover.

	Grid: This sets up the boundaries of the grid as well as ensures the rovers are within the bounds of the grid as specified in the input.

The main program will create instances of the grid and all the rovers. It will then execute all the movements specified in the input by calling 
the rover's movement functions. If it goes out of bounds the scent is added to the list and the rover is deemed lost. Otherwise the rover keeps
going until there are no more movements then displays it's current location.
	

• List of assumptions that you made
	The inputs are passed in via a text file
	The inputs are separated by only one line not two
	There are always a list of movements followed by the initial position of the rover
	The board size is less than 2^32
	There are no blank or empty movements in the string


• An estimate of how long this would take if you were asked to build the entire solution for a customer
	Depends on how intricate they want the UI to be. If it requires actually showing a rover moving on a grid this could 
	take some time. So I will need more information on the scope.

• Source code (including any automated tests)

