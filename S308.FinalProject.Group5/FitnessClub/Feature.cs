using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub
{
    class Feature
    {
        public string Type { get; set; }
        public double price { get; set; }

        public Feature()
        {
            Type = "";
            price = 0;
        }
    }
}
