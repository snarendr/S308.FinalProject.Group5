using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub
{
    public class Quote
    {
        public string MembershipType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool AdditionalFeatures_Training { get; set; }

        public bool AdditionalFeatures_LockerRental { get; set; }

        public Quote(string membershipType,DateTime startDate, DateTime endDate, bool addFeatTraining, bool addFeatLR)
        {
            MembershipType = membershipType;
            StartDate = startDate;
            EndDate = endDate;
            AdditionalFeatures_Training = addFeatTraining;
            AdditionalFeatures_LockerRental = addFeatLR;
        }
    }
}
