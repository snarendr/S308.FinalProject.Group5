﻿//MSN Logo Source: https://www.apk4now.com/apk/1424/msn-health-amp-fitness-workouts
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
        List<MembersInformation> memberIndex;
        // List<MembersInformation> filteredMembers;
        // MemberInformation selectedMember;
        Quote q;


        public ExistingMemberSearch()
        {

            InitializeComponent();

            memberIndex = LoadData();
        }
        public List<MembersInformation> LoadData()
        {
            List<MembersInformation> lstMembersInformation = new List<MembersInformation>();


            string strFilePath = @"..\..\Data\MembersInformation.json";
            try
            {
                string jsonData = File.ReadAllText(strFilePath);

                lstMembersInformation = JsonConvert.DeserializeObject<List<MembersInformation>>(jsonData);
            }

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

            lbxExistingMembers.Items.Clear();

            //Declare list for information serach query
            List<MembersInformation> filteredMembers;
            filteredMembers = memberIndex.Where(m =>
                m.LastName == strLastName).ToList();

            foreach (MembersInformation m in filteredMembers)
            {
                lbxExistingMembers.Items.Add((m.LastName + ", " + m.FirstName + ", (" + m.Email + ")").ToString());
            }
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

                filteredMembers = memberIndex.Where(m =>
                (m.LastName + ", " + m.FirstName + ", (" + m.Email + ")") == strSelectedName).ToList();

                foreach (MembersInformation m in filteredMembers)
                {
                    MembersInformation info = new MembersInformation(m.Type, m.FirstName.ToUpper(), m.LastName.ToUpper(), m.StartDate, m.EndDate, m.SubTotal, m.Additional_Features_Training, m.Additional_Features_LockerRental, m.TotalCost, m.PhoneNumber, m.Email, m.Gender, m.Age, m.Weight, m.Credit_Card_Number, m.PFG_AthleticPerformance, m.PFG_OverallHealth, m.PFG_StrengthTraining, m.PFG_WeightLoss, m.PFG_WeightManagment);

                    MembershipRegistration next = new MembershipRegistration(info, q);

                    next.Show();

                    this.Close();
                }



            }
        }


        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu MainMenuWindow = new MainMenu();
            MainMenuWindow.Show();
            this.Close();
        }

        private void btnClearSearch_Click(object sender, RoutedEventArgs e)
        {
            txtEmailInput.Text = "";
            txtLastNameInput.Text = "";
            txtPhoneNumberInput.Text = "";
        }

        private void bttnSelect_Click(object sender, RoutedEventArgs e)
        {
            //MembershipRegistration m = new MembershipRegistration(selectedMember, q);

            //  MembershipRegistration MembershipRegistrationWindow = new MembershipRegistration();
            //  MembershipRegistrationWindow.Show();
            //  this.Close();

        }
    }
}
