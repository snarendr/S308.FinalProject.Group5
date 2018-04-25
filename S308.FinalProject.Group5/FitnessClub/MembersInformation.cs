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

        public int Cost { get; set; }

        public int SubTotal { get; set; }

        public string Features { get; set; }

        public int TotalCost { get; set; }

        public string ExpirationDate { get; set; }

        public int PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public int Weight { get; set; }

        public MembersInformation()
        {

        }

        public MembersInformation(string type, string firstName, string lastName, string startDate, string endDate, int cost, int subTotal, string features, int totalCost, string expirationDate, int phoneNumber, string email, string gender, int weight)
        {
            Type = type;
            FirstName = firstName;
            LastName = lastName;
            StartDate = startDate;
            EndDate = endDate;
            Cost = cost;
            SubTotal = subTotal;
            Features = features;
            TotalCost = totalCost;
            ExpirationDate = expirationDate;
            PhoneNumber = phoneNumber;
            Email = email;
            Gender = gender;
            Weight = weight;

        }

        public override string ToString()
        {
            return "Memeber: " + Environment.NewLine
                + "Type: " + Type + Environment.NewLine
                + "First Name: " + FirstName + Environment.NewLine
                + "Last Name: " + LastName + Environment.NewLine
                + "Start Date: " + StartDate + Environment.NewLine
                + "End Date: " + EndDate + Environment.NewLine
                + "Cost: " + Cost.ToString() + Environment.NewLine
                + "Sub Total: " + SubTotal.ToString() + Environment.NewLine
                + "Features: " + Features + Environment.NewLine
                + "Total Cost: " + TotalCost.ToString() + Environment.NewLine
                + "Expiration Date: " + ExpirationDate + Environment.NewLine
                + "Phone Number " + PhoneNumber + Environment.NewLine
                + "Email " + Email + Environment.NewLine
                + "Gender " + Gender + Environment.NewLine
                + "Weight " + Weight.ToString();
        }

    }
}
