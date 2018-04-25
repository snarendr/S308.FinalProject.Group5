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

        public override string ToString()
        {
            return "Member: " + Environment.NewLine
                + "Type: " + Type + Environment.NewLine
                + "First Name: " + FirstName + Environment.NewLine
                + "Last Name: " + LastName + Environment.NewLine
                + "Start Date: " + StartDate + Environment.NewLine
                + "End Date: " + EndDate + Environment.NewLine
                + "Sub Total: " + SubTotal.ToString() + Environment.NewLine
                + "Addtional Feature Training: " + AddFeatures_Training + Environment.NewLine
                + "Addtional Feature Locker Rental: " + AddFeatures_LockerRental + Environment.NewLine
                + "Total Cost: " + TotalCost.ToString() + Environment.NewLine
                + "Phone Number " + PhoneNumber + Environment.NewLine
                + "Email " + Email + Environment.NewLine
                + "Gender " + Gender + Environment.NewLine
                + "Weight " + Weight.ToString();
        }

    }
}
