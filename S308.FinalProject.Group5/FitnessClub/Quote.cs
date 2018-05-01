using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub
{//Establish attirbutes needed for quote class
    public class Quote
    {
        public string MembershipType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool AdditionalFeatures_Training { get; set; }

        public bool AdditionalFeatures_LockerRental { get; set; }

        public double SubTotal { get; set; }

        public double TotalCost { get; set; }

        //Create signature to pass in information for quote from membership sales page in order to construct instance of quote class
        public Quote(string membershipType,DateTime startDate, DateTime endDate, bool addFeatTraining, bool addFeatLR,double subTotal, double totalCost)
        {
            MembershipType = membershipType;
            StartDate = startDate;
            EndDate = endDate;
            AdditionalFeatures_Training = addFeatTraining;
            AdditionalFeatures_LockerRental = addFeatLR;
            SubTotal = subTotal;
            TotalCost = totalCost;
        }
    }
}
