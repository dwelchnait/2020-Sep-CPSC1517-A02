using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    // a class represents the defined characteristics of an item
    // an item can be a physical thing (cellphone), concept (student),
    //   a collection of data
    // visual studio creates your clas without a specific access type
    // the default type for a class is private
    // code outside of a private class cannot use the contents of the private class???
    // for the class to be used by an outside user (code) it must be public
    public class Window
    {
        //Private Data Members
        //these are variables that are known ONLY within the class
        //will be used for Fully Implemented Properties
        //will be used for local class only data
        private string _Manufacturer;
        private decimal _Height;

        //Public Data Members
        //these are variables that are known within the class and outside of the class
        //public data members can be altered by code within and without side the class
        //it is preferred to use Properties instead of public data members

        //Properties
        //optional
        //properties can be implemented in two ways
        //a) Fully Implemented property
        //  used because there is additional code/logic use
        //  in processing the data
        //b) Auto implemented property
        //  used when there is no need for addtional code/logic
        //  when the data is simply saved/stored

        //Fully Implemented Property
        public string Manufacturer
        {
            //assume the Manufacturer is a nullable string
            //3 possiblities
            //  a) there are characters
            //  b) string has no data (null)
            //  c) there is a physical string BUT NO characters
            //there will be additional code/logic to ensure ONLY a and b
            //  exists for the data
            //this requires a private data member to hold the data
            //  and a property to manage the data content
            get
            {
                //returns data via the property to the outside user
                //  of the property
                //a get operates on the right side of an equal sign (assignment statement)
                return _Manufacturer;
            }
            set
            {
                //the set takes incoming data and places that data
                //  into a private data member
                //internal to the property, incoming data will be placed
                //  in a common local variable called value
                //a property is associated with a single data member
                //a property has NO  parameter list
                //a set operates on the left side of an equal sign (assignment statement)
                if (string.IsNullOrEmpty(value))
                {
                    //ensure a null is stored in the private data member
                    //  eliminate the c possibility
                    _Manufacturer = null;  //case b
                }
                else
                {
                    //ensure the value is stored in the private data member
                    _Manufacturer = value;  //case a
                }

                //alternative coding
                //syntax    recieving field = condition(s) ? true value : false;
                // _Manufacturer = string.IsNullOrEmpty(value) ? null : value;

            }


        }
        public decimal Height
        {
            //Height must be greater that 0
            get { return _Height; }
            set
            {
                // the m indicates the value is a decimal
                if (value <= 0.0m)
                {
                    throw new Exception("Height can not be 0 or less than 0.");
                }
                else
                {
                    _Height = value;
                }
            }
        }

        //Auto Implemented Property
        //  auto implemented properties can be used when there is NO NEED
        //      for additional processing against the incomin data
        //  NO internal private data member is required for this property
        //  the system WILL internally generate a data rea for the data
        //  accessing the stored data (get, set) CAN ONLY be done
        //      via the property
        public decimal Width { get; set; }

        //one can still code auto implemented properties as fully implemented properties
        //private decimal _Width;
        //public decimal Width 
        //{
        //    get { return _Width; }
        //    set { _Width = value; } 
        //}

        //what about nullable Numerics
        //Do we need to test for a null value to be used for missing incoming data
        //NO, you do not have to code a fully implemented property for a nullable numeric
        //Numerics have a default of zero.
        //NUmerics CAN ONLY store a numeric (unless nullable)
        //Numerics CAN BE NULL if declared as nullable
        //IF the numeric has additional criteria THEN you can
        //    code the properties as a Fully Implemented property
        public int? NumberOfPanes { get; set; }

        //Constructors
        //a constructor is "a method" that quarantees that the newly
        //  created instance of this class will ALWAYS be created in
        //  "a known state"

        //syntax
        //public constructorname([list of parameters])
        //{
        //      your code
        //}

        //constructors are OPTIONAL
        //IF a class DOES NOT have a constructor then the system
        //  will generate the class instance using the datatype defaults
        //  for your private data members and auto implemented properties
        //this situation of no constructor(s) is often referred to as
        //  using a "system" constructor

        //IF you code a constructor, you MUST code any and all constructor(s)
        //  needed by your class

        //Behaviours
    }
}
