using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //create an instance of the Window class using the defualt constructor
            //the system calls your class constructor, your code NEVER calls the constructor
            //  directly
            //the "new" will use the indicated constructor
            //the "new" actually makes the call to the constructor and returns the
            //  instance of the class

            //call to the Default constructor
            Window myInstance = new Window();

            //results of the constructor
            Console.WriteLine($"Width {myInstance.Width}; Height {myInstance.Height};" +
                $"Panes {myInstance.NumberOfPanes}; Manufacturer >{myInstance.Manufacturer}<"
                );

            //to place data within the new instance (object) of the class 
            //  use the properties
            //to reference a property within an instance, use the dot operator
            myInstance.Width = 1.2m;
            myInstance.Height = 1.2m;
            myInstance.NumberOfPanes = 3;
            myInstance.Manufacturer = "All-Weather Windows";

            Console.WriteLine($"Width {myInstance.Width}; Height {myInstance.Height};" +
               $"Panes {myInstance.NumberOfPanes}; Manufacturer >{myInstance.Manufacturer}<"
               );

            Window myGreedyInstance = new Window(1.6m, 3.3m, 3, "Fancy Windows");

            Console.WriteLine($"Width {myGreedyInstance.Width}; Height {myGreedyInstance.Height};" +
              $"Panes {myGreedyInstance.NumberOfPanes}; Manufacturer >{myGreedyInstance.Manufacturer}<"
              );

            Door theDoor = new Door(1.2m, 1.9m, "L", "wood");
            Console.WriteLine($"Width {theDoor.Width}; Height {theDoor.Height};" +
              $"R or L {theDoor.RightOrLeft}; Material >{theDoor.Material}<"
              );

            Console.WriteLine("\n\n");

            UsingClasses();
            Console.ReadKey(); //when using the debugger your console window will remain open
        }

        static void UsingClasses()
        {
            //the purpose of this method is to calculate the cost
            //  of painting a room
            //the room will have several windows and walls with a single door
            //all data for windows, walls and doors will be collected and
            //  store in an instance of room.

            //What does Room need
            //declare a set of List<T> for the components of the Room
            List<Wall> walls = new List<Wall>();
            List<Door> doors = new List<Door>();
            List<Window> windows = new List<Window>();
            Room room = new Room(); //Default constructor

            //create a reusable pointer variable to each component of the Room
            //these pointers are created outside of the loop

            Wall wall = null;
            Door door = null;
            Window window = null;

            //collect the data for all of the walls in the room
            //loop of prompt/input/validating for each wall

            // after validation of data, create an instance of your class
            wall = new Wall();
            // load the incoming data into the instance of your class
            wall.Width = 6.6m;
            wall.Height = 3.1m;
            // add the new instance into your collection (List<T>) to save the data
            walls.Add(wall);

            //end of loop

            //assume the loop collected and stored the following
            //pass 2
            wall = new Wall();
            // load the incoming data into the instance of your class
            wall.Width = 6.6m;
            wall.Height = 3.1m;
            // add the new instance into your collection (List<T>) to save the data
            walls.Add(wall);

            //pass 3
            wall = new Wall();
            // load the incoming data into the instance of your class
            wall.Width = 5.6m;
            wall.Height = 3.1m;
            // add the new instance into your collection (List<T>) to save the data
            walls.Add(wall);

            //pass 4
            wall = new Wall();
            // load the incoming data into the instance of your class
            wall.Width = 5.6m;
            wall.Height = 3.1m;
            // add the new instance into your collection (List<T>) to save the data
            walls.Add(wall);

            //door loop
            //prompt/input/validate
            //store
            //assume in this example that the literials were actually in variables
            //door = new Door(inputWidth, inputHeight, inputRL, inputMaterial);
            door = new Door(0.85m, 2.0m, "R", "Composite Pressed Wood");
            doors.Add(door);
            //end of loop

            //window loop
            //prompt/input/validate
            //store
            window = new Window(1.3m, 1.3m, 2, "Fancy Windows");
            windows.Add(window);
            //end of loop

            //pass 2
            window = new Window(1.3m, 1.3m, 2, "Fancy Windows");
            windows.Add(window);

            //at this point your would have 3 lists to load to the Room
            //Room is a composite class
            room.Doors = doors;  //load the complete List<T>
            room.Walls = walls;  //load the complete List<T>
            room.Windows = windows;  //load the complete List<T>
            room.Name = "Master Bedroom";

           
        }
    }
}
