using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub
{
    public class MembersInformation
    {
        public DateTime datRegistration { get; set; }
        public string Type { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public double SubTotal { get; set; }

        public bool Additional_Features_Training { get; set; }

        public bool Additional_Features_LockerRental { get; set; }

        public double TotalCost { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public int Weight { get; set; }

        public string Credit_Card_Number { get; set; }

        public bool PFG_AthleticPerformance { get; set; }

        public bool PFG_OverallHealth { get; set; }

        public bool PFG_StrengthTraining { get; set; }

        public bool PFG_WeightLoss { get; set; }

        public bool PFG_WeightManagment { get; set; }
        public override string ToString()
        {
        string strResults = "Type: " + Type + Environment.NewLine;
        strResults += "First Name: " + FirstName + Environment.NewLine;
        strResults += "Last Name: " + LastName + Environment.NewLine;
        strResults += "Start Date: " + StartDate + Environment.NewLine;
        strResults += "End Date: " + EndDate + Environment.NewLine;
        strResults += "Sub Total: " + SubTotal.ToString() + Environment.NewLine;
        strResults += "Addtional Feature Training: " + Additional_Features_Training + Environment.NewLine;
        strResults += "Addtional Feature Locker Rental: " + Additional_Features_LockerRental + Environment.NewLine;
        strResults += "Total Cost: " + TotalCost.ToString() + Environment.NewLine;
        strResults += "Phone Number: " + PhoneNumber + Environment.NewLine;
        strResults += "Email: " + Email + Environment.NewLine;
        strResults += "Gender: " + Gender + Environment.NewLine;
        strResults += "Weight: " + Weight.ToString() + Environment.NewLine;
        strResults += "Credit Card Number: " + Credit_Card_Number + Environment.NewLine;
        strResults += "Athletic Performance: " + PFG_AthleticPerformance + Environment.NewLine;
        strResults += "Overall Health: " + PFG_OverallHealth + Environment.NewLine;
        strResults += "Strength Training: " + PFG_StrengthTraining + Environment.NewLine;
        strResults += "Weight Loss: " + PFG_WeightManagment + Environment.NewLine;
        strResults += Environment.NewLine;

        return strResults;
        }


        public MembersInformation(DateTime datREgistration, string type, string firstName, string lastName, string startDate, string endDate, double subTotal, bool additional_Features_Training, bool additional_Features_LockerRental, double totalCost, string phoneNumber, string email, string gender, int weight, string credit_Card_Number, bool pFG_AthleticPerformance, bool pFG_OverallHealth, bool pFG_StrengthTraining, bool pFG_WeightLoss, bool pFG_WeightManagment)
        {
            datRegistration = datREgistration;
            Type = type;
            FirstName = firstName;
            LastName = lastName;
            StartDate = startDate;
            EndDate = endDate;
            SubTotal = subTotal;
            Additional_Features_Training = additional_Features_Training;
            Additional_Features_LockerRental = additional_Features_LockerRental;
            TotalCost = totalCost;
            PhoneNumber = phoneNumber;
            Email = email;
            Gender = gender;
            Weight = weight;
            Credit_Card_Number = credit_Card_Number;
            PFG_AthleticPerformance = pFG_AthleticPerformance;
            PFG_OverallHealth = pFG_OverallHealth;
            PFG_StrengthTraining = pFG_StrengthTraining;
            PFG_WeightLoss = pFG_WeightLoss;
            PFG_WeightManagment = pFG_WeightManagment;

        }

        public MembersInformation()
        {
            Type = "";
            FirstName = "";
            LastName = "";
            StartDate = "";
            EndDate = "";
            SubTotal = 0;
            Additional_Features_Training = false;
            Additional_Features_LockerRental = false;
            TotalCost = 0;
            PhoneNumber = "";
            Email = "";
            Gender = "";
            Weight = 0;
            Credit_Card_Number = "";
            PFG_AthleticPerformance = false;
            PFG_OverallHealth = false;
            PFG_StrengthTraining = false;
            PFG_WeightLoss = false;
            PFG_WeightManagment = false;
        }


        
        
                        



    }
}
