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
        //Creaing the index to hold our members
        List<MembersInformation> memberIndex;

        public MemberInformation()
        {
            InitializeComponent();
            //Calling method that loads data from the JSON file to our index
            memberIndex = LoadData();
            
        }

        public List<MembersInformation> LoadData()
        {
            //Creating list to hold members 
            List<MembersInformation> lstMembersInformation = new List<MembersInformation>();

            //Our file path to holding members 
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
            //Returning our list 
            return lstMembersInformation;


        }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            //Setting background to white 
            txtDetails.Background = Brushes.White;

            //Declare variables to store last name, email, and phone number provided by the user
            string strLastName = txtLastNameInput.Text.Trim().ToUpper();
          
            string strEmail = txtEmailInput.Text.Trim().ToUpper();
           
            string strPhoneNumber = txtPhoneNumberInput.Text.Trim();
            
          if(strPhoneNumber == "" && strLastName =="" && strEmail == "")
            {
                MessageBox.Show("You must enter at least one search critera.");
                return;
            }

            txtDetails.Text = "";
            lbxResults.Items.Clear();

            //Declare list for information serach query
            List<MembersInformation> memberInformationSearch;

            //write query to find members that match any proivded information about the members last name, email, or phone number
            memberInformationSearch = memberIndex.Where(m =>
                (m.LastName.ToUpper().Contains(strLastName.ToUpper())) && 
                (m.Email.ToUpper().Contains(strEmail.ToUpper())) &&
                (m.PhoneNumber.Contains(strPhoneNumber)) &&
                (m.LastName.Contains(strLastName) && m.Email.Contains(strEmail)) &&
                (m.LastName.Contains(strLastName) && m.Email.Contains(strEmail) && m.PhoneNumber.Contains(strPhoneNumber))).ToList();
           
            //list the first name and last name of members that matched the query results 
           foreach (MembersInformation m in memberInformationSearch)
            {
                lbxResults.Items.Add((m.LastName + ", " +m.FirstName + ", (" + m.Email + ")").ToString());
            }

            //if no results were found in the query, notify the user
            if (lbxResults.Items.Count < 1)
            {
                MessageBox.Show("No one was found on your search.");
                return;
            }

        }
       
        private void lbxResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Turning background to white 
            txtDetails.Background = Brushes.White;
            //Validating that there is an item in our list box
            if (lbxResults.SelectedIndex > -1)
            {
                string strSelectedName = lbxResults.SelectedItem.ToString();

                List<MembersInformation> memberInformationSearch;
                //Query selecting the information about the member
                memberInformationSearch = memberIndex.Where(m =>
                (m.LastName + ", " + m.FirstName + ", (" + m.Email + ")") == strSelectedName).ToList();

                //Walking through the item selected
                foreach (MembersInformation m in memberInformationSearch)
                {   
                    //adding the information to the txt box
                    txtDetails.Text = m.ToString();
                    //if the end date of the selected membership is within 14 days (or already expired), display the text box in red
                    if ((Convert.ToDateTime(m.EndDate) - DateTime.Now).TotalDays <  14)

                    {
                        txtDetails.Background = Brushes.LightPink;
                    }
                }


            }


        }
        //Method to get back to the main menu 
        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu MainMenuWindow = new MainMenu();
            MainMenuWindow.Show();
            this.Close();
        }
        //Method to clear the window
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtLastNameInput.Text = "";
            txtEmailInput.Text = "";
            txtPhoneNumberInput.Text = "";
            txtDetails.Text = "";
            lbxResults.Items.Clear();
            txtDetails.Background = Brushes.White;

        }


    }
}
