using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub
{
    public class MembersInformation
    {
        public string Type { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public double SubTotal { get; set; }

        public bool AddFeatures_Training { get; set; }

        public bool AddFeatures_LockerRental { get; set; }

        public double TotalCost { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public int Weight { get; set; }


        public override string ToString()
        {
            string strResults = "Type: " + Type + Environment.NewLine;
            strResults += "First Name: " + FirstName + Environment.NewLine;
            strResults += "Last Name: " + LastName + Environment.NewLine;
            strResults += "Start Date: " + StartDate + Environment.NewLine;
            strResults += "End Date: " + EndDate + Environment.NewLine;
            strResults += "Sub Total: " + SubTotal.ToString() + Environment.NewLine;
            strResults += "Addtional Feature Training: " + AddFeatures_Training + Environment.NewLine;
            strResults += "Addtional Feature Locker Rental: " + AddFeatures_LockerRental + Environment.NewLine;
            strResults += "Total Cost: " + TotalCost.ToString() + Environment.NewLine;
            strResults += "Phone Number: " + PhoneNumber + Environment.NewLine;
            strResults += "Email: " + Email + Environment.NewLine;
            strResults += "Gender: " + Gender + Environment.NewLine;
            strResults += "Weight: " + Weight.ToString();
            strResults += Environment.NewLine;

            return strResults;
        }
        
        public MembersInformation()
       {

        }

        public MembersInformation(string type, string firstName, string lastName, string startDate, string endDate, double subTotal, bool addFeat_Training,bool addFeat_LR, double totalCost, string phoneNumber, string email, string gender, int weight)
        {
            Type = type;
            FirstName = firstName;
            LastName = lastName;
            StartDate = startDate;
            EndDate = endDate;
            SubTotal = subTotal;
            AddFeatures_Training = addFeat_Training;
            AddFeatures_LockerRental = addFeat_LR;
            TotalCost = totalCost;
            PhoneNumber = phoneNumber;
            Email = email;
            Gender = gender;
            Weight = weight;

        }
                        



    }
}
