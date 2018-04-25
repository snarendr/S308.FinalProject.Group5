//MSN Logo Source: https://www.apk4now.com/apk/1424/msn-health-amp-fitness-workouts
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
    
    public partial class MemberInformation : Window
    {
        List<MembersInformation> memberIndex;

        public MemberInformation()
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
                if (lstMembersInformation.Count >= 0)
                    MessageBox.Show(lstMembersInformation.Count + " members have been imported.");
                else
                    MessageBox.Show("No members imported.");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error in import process: " + ex.Message);
            }

            return lstMembersInformation;


        }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

            List<MembersInformation> memberInformationSearch;

            //Getting input from Last name and validating
            string strLastName = txtLastNameInput.Text.Trim();
            if (strLastName == "")
            {
                MessageBox.Show("Please enter a last name");
            }
            //Getting input from email and validating
            string strEmail = txtEmailInput.Text.Trim();
            if (strEmail == "")
            {
                MessageBox.Show("Your search will be better with a correctly formatted email");
            }
            //Getting input from phone number and validating 
            string strPhoneNumber = txtPhoneNumberInput.Text.Trim();
            if (strPhoneNumber == "")
            {
                MessageBox.Show("Your seach will be better with a correctly formated phone number");
            }
            //Further validating
          //  if((txtEmailInput.Text.Trim() == "") && (txtLastNameInput.Text.Trim() = "") && (txtPhoneNumberInput.Text.Trim() = ""))
          //  {
            //    MessageBox.Show("You need to enter atleast 1 of the criteria");

           // }
            txtDetails.Text = "";
            lbxResults.Items.Clear();

            memberInformationSearch = memberIndex.Where(m =>
                m.LastName == strLastName ||
                m.Email == strEmail ||
                m.PhoneNumber == strPhoneNumber).ToList();
             
           foreach (MembersInformation m in memberInformationSearch)
            {
                lbxResults.Items.Add(m.LastName.ToString());
                if (lbxResults.Items.Count < 1)
                    MessageBox.Show("No one was found on your search.");

            }

        }


        private void lbxResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxResults.SelectedIndex > -1)
            {
                string strSelectedName = lbxResults.SelectedItem.ToString();

                MembersInformation memberSelected = memberIndex.Where(m => m.LastName == strSelectedName).FirstOrDefault();
                txtDetails.Text = memberSelected.ToString();
            }


        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu MainMenuWindow = new MainMenu();
            MainMenuWindow.Show();
            this.Close();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtLastNameInput.Text = "";
            txtEmailInput.Text = "";
            txtPhoneNumberInput.Text = "";
            txtDetails.Text = "";
            lbxResults.Items.Clear();

        }


    }
}
