using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub
{
    //Create a feature class that will store the feature type in a string and the feature price as a double
    class Feature
    {
        public string Type { get; set; }
        public double price { get; set; }

        //Establish constructor for the feature class with default values
        public Feature()
        {
            Type = "";
            price = 0;
        }
    }
}
