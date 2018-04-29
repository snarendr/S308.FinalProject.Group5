using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub
{
    //Create a membership class that will store the membership type in a string, the membership price as a double, the availability as a bool. 
    class Membership
    {
        public string Type { get; set; }
        public double Price { get; set; }
        public bool Available { get; set; }

        //Establish constructor for the membership class with default values
        public Membership()
        {
            Type = "";
            Price = 0;
            Available = true;
        }
                
    }

}
