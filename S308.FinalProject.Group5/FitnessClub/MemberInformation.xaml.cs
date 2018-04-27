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
               
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error in import process: " + ex.Message);
            }

            return lstMembersInformation;


        }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

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
                //if no results were found in the query, notify the user
                if (lbxResults.Items.Count < 1)
                    MessageBox.Show("No one was found on your search.");

            }

        }
       
        private void lbxResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxResults.SelectedIndex > -1)
            {
                string strSelectedName = lbxResults.SelectedItem.ToString();

                List<MembersInformation> memberInformationSearch;

                memberInformationSearch = memberIndex.Where(m =>
                (m.LastName + ", " + m.FirstName + ", (" + m.Email + ")") == strSelectedName).ToList();


                foreach (MembersInformation m in memberInformationSearch)
                {
                    txtDetails.Text = m.ToString();
                    
                    if(Convert.ToDateTime(m.EndDate).Month <= DateTime.Now.Month)

                    {
                        txtDetails.Background = Brushes.LightPink;
                    }
                }


               

                //notes below
                //(m.Email.ToUpper().Contains(strEmail.ToUpper())) &&
                //(m.PhoneNumber.Contains(strPhoneNumber)) &&
                //(m.LastName.Contains(strLastName) && m.Email.Contains(strEmail)) &&
                //(m.LastName.Contains(strLastName) && m.Email.Contains(strEmail) && m.PhoneNumber.Contains(strPhoneNumber))).ToList();

                //MembersInformation memberSelected 
                //txtDetails.Text = memberSelected.ToString();
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
