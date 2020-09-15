using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Room
    {
        //Composite Classes
        //is a mixture of data members/properties 
        //  of native datatypes and/or other classes

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Room must have a name.");
                }
                else
                {
                    _Name = value;
                }
            }
        }
        public List<Wall> Walls { get; set; }
        public List<Window> Windows { get; set; }
        public List<Door> Doors { get; set; }

        public Room()
        {
            Name = "Unknown";
        }
    }
}
