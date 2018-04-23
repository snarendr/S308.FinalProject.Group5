using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub
{
    class Membership
    {
        public string Type { get; set; }
        public double Price { get; set; }
        public bool Available { get; set; }

        public Membership()
        {
            Type = "";
            Price = 0;
            Available = true;
        }

           

        
    }


   

}
