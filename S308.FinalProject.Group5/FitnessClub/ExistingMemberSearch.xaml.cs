//MSN Logo Source: https://www.apk4now.com/apk/1424/msn-health-amp-fitness-workouts
//Working out picture source: https://classroomclipart.com/clipart/Clipart/Fitness_and_Exercise.htm
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FitnessClub
{

    public partial class ExistingMemberSearch : Window
    {
        //Establish list to store member information
        List<MembersInformation> memberIndex;
        //Reference quote data
        Quote q;

        public ExistingMemberSearch()
        {
            InitializeComponent();
            //Loading data to our member index
            memberIndex = LoadData();
        }
        public List<MembersInformation> LoadData()
        {
            //Create list to store member information
            List<MembersInformation> lstMembersInformation = new List<MembersInformation>();
            //Create variable to store file member of membership information json file
            string strFilePath = @"..\..\Data\MembersInformation.json";
            //Read membership json file and deserialize data to members information list
            try
            {
                string jsonData = File.ReadAllText(strFilePath);

                lstMembersInformation = JsonConvert.DeserializeObject<List<MembersInformation>>(jsonData);
            }
            //Catch any errors and display the errors to the user
            catch (Exception ex)
            {
                MessageBox.Show("Error in import process: " + ex.Message);
            }

            return lstMembersInformation;
        }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            //Getting input from Last name and validating
            string strLastName = txtLastNameInput.Text.Trim().ToUpper();

            //Getting input from email and validating
            string strEmail = txtEmailInput.Text.Trim().ToUpper();

            //Getting input from phone number and validating 
            string strPhoneNumber = txtPhoneNumberInput.Text.Trim().ToUpper();

            if (strPhoneNumber == "" && strLastName == "" && strEmail == "")
            {
                MessageBox.Show("You must enter at least one search critera.");
                return;
            }
            //Clear the items list
            lbxExistingMembers.Items.Clear();

            //Declare list for information serach query
            List<MembersInformation> filteredMembers;
            //write query to find members that match any proivded information about the members last name, email, or phone number
            filteredMembers = memberIndex.Where(m =>
                (m.LastName.ToUpper().Contains(strLastName.ToUpper())) &&
                (m.Email.ToUpper().Contains(strEmail.ToUpper())) &&
                (m.PhoneNumber.Contains(strPhoneNumber)) &&
                (m.LastName.Contains(strLastName) && m.Email.Contains(strEmail)) &&
                (m.LastName.Contains(strLastName) && m.Email.Contains(strEmail) && m.PhoneNumber.Contains(strPhoneNumber))).ToList();
          
            //Walking through each item added to filtered members 
            foreach (MembersInformation m in filteredMembers)
            {
                lbxExistingMembers.Items.Add((m.LastName + ", " + m.FirstName + ", (" + m.Email + ")").ToString());
            }
            //Tell the user if no records were found
            if (lbxExistingMembers.Items.Count < 1)
            {
                MessageBox.Show("No one was found on your search.");

            }
        }
        private void lbxresults_selectionchanged(object sender, SelectionChangedEventArgs e)
        {
            //Checking there is an item in our list box 
            if (lbxExistingMembers.SelectedIndex > -1)
            {
                string strSelectedName = lbxExistingMembers.SelectedItem.ToString();

                List<MembersInformation> filteredMembers;
                
                //Query that selects the members information chosen by the user
                filteredMembers = memberIndex.Where(m =>
                (m.LastName + ", " + m.FirstName + ", (" + m.Email + ")") == strSelectedName).ToList();

                foreach (MembersInformation m in filteredMembers)
                {
                    //Pulling the information of the existing user to pull to the next window
                    MembersInformation info = new MembersInformation(m.Type, m.FirstName.ToUpper(), m.LastName.ToUpper(), m.StartDate, m.EndDate, m.SubTotal, m.Additional_Features_Training, m.Additional_Features_LockerRental, m.TotalCost, m.PhoneNumber, m.Email, m.Gender, m.Age, m.Weight,m.Credit_Card_Type, m.Credit_Card_Number, m.PFG_AthleticPerformance, m.PFG_OverallHealth, m.PFG_StrengthTraining, m.PFG_WeightLoss, m.PFG_WeightManagment);

                    MembershipRegistration next = new MembershipRegistration(info, q);

                    next.Show();

                    this.Close();
                }
            }
        }
        //User selects button to return to the main menu
        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu MainMenuWindow = new MainMenu();
            MainMenuWindow.Show();
            this.Close();
        }
        //User selects clear search button
        private void btnClearSearch_Click(object sender, RoutedEventArgs e)
        {
            txtEmailInput.Text = "";
            txtLastNameInput.Text = "";
            txtPhoneNumberInput.Text = "";
        }
    }
}
