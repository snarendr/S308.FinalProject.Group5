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
        List<MembersInformation> memberIndex;
        List<MembersInformation> filteredMembers;
        MemberInformation selectedMember;
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
            /*
            // 1. get index of listbox
                //MembersInformation memberSelected = memberIndex.Where(m => m.LastName == strSelectedName).ToList()[lbxExistingMembers.SelectedIndex];

                //Convert.ToDateTime(m.EndDate).Day - DateTime.Now.Day < 14
                //notes below
                //(m.Email.ToUpper().Contains(strEmail.ToUpper())) &&
                //(m.PhoneNumber.Contains(strPhoneNumber)) &&
                //(m.LastName.Contains(strLastName) && m.Email.Contains(strEmail)) &&
                //(m.LastName.Contains(strLastName) && m.Email.Contains(strEmail) && m.PhoneNumber.Contains(strPhoneNumber))).ToList();

                //MembersInformation memberSelected 
                //filteredMembers = memberSelected.ToString();

            if (lbxExistingMembers.SelectedIndex > -1)
            {
                string strSelectedName = lbxExistingMembers.SelectedItem.ToString();

                List<MembersInformation> selectedMember;

                selectedMember = memberIndex.Where(m =>
                (m.LastName + ", " + m.FirstName + ", (" + m.Email + ")") == strSelectedName).ToList();

                foreach (MembersInformation m in selectedMember)
                {
                    MembersInformation info = new MembersInformation(quote.MembershipType, strFirstName.ToUpper(), strLastName.ToUpper(), quote.StartDate.ToShortDateString(), quote.EndDate.ToShortDateString(), quote.SubTotal, quote.AdditionalFeatures_Training, quote.AdditionalFeatures_LockerRental, quote.TotalCost, strPhone, strEmail.ToUpper(), strGender, intWeight, strCCNum, chbAthPer.IsChecked.Value, chbOverHealth.IsChecked.Value, chbST.IsChecked.Value, chbWeightLoss.IsChecked.Value, chbWeightMgmt.IsChecked.Value);
                    MembershipRegistration next = new MembershipRegistration(info, q);




                    // 2. filter list of customers by criteria and index by index in step 1
                    //selectedMember = filteredMembers[lbxExistingMembers.SelectedIndex];
                    //if the end date of the selected membership is within 14 days (or already expired), display the text box in red
                   // if ((Convert.ToDateTime(m.EndDate) - DateTime.Now).TotalDays < 14)
          */
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
