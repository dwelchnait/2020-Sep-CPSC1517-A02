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

            Console.ReadKey(); //when using the debugger your console window will remain open
        }
    }
}
