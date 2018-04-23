//MSN Logo Source: https://www.apk4now.com/apk/1424/msn-health-amp-fitness-workouts
//Price Quote Image Source: https://needtshirtsnow.com/T-shirt-Price-Quote
using System;
using System.Collections.Generic;
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
using System.IO;
using Newtonsoft.Json;


namespace FitnessClub
{
    /// <summary>
    /// Interaction logic for MembershipSales.xaml
    /// </summary>
    public partial class MembershipSales : Window
    {
        string strFilePath = @"..\..\Data\membership.json";
        List<Membership> MembershipList = new List<Membership>();

        public MembershipSales()
        {
            InitializeComponent();
            //Call the method to find the available memberships for the combo box.
            AvailableMemberships();
        }

        //create method to find the membership types that are currenlty available
        private void AvailableMemberships()
        {

            //Read membership json file to fill the membership list with the current membership data
            try
            {
                string jsonData = File.ReadAllText(strFilePath);
                MembershipList = JsonConvert.DeserializeObject<List<Membership>>(jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in reading available memberships from memberships data file: " + ex.Message);
            }

            //Query the membership list to find the memberships that are available                       
            var membershipQuery =
              from m in MembershipList
              where m.Available 
              select m;

            //For the membership types that are available, add them to the combo box. 
            foreach (Membership m in membershipQuery)
            {
                cmbMemType.Items.Add(m.Type);
            }

        }
        //Allow user to go back to the Main Menu
        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu MainMenuWindow = new MainMenu();
            MainMenuWindow.Show();
            this.Close();
        }

        //Begin the quote measurement
        private void btnQuote_Click(object sender, RoutedEventArgs e)
        {
            //Validate that a membership type was selected

            if (cmbMemType.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a membership type to generate a quote.");
                return;
            }

            DateTime? datStartDate = dtpStart.SelectedDate;
            DateTime? datEndDate = dtpEnd.SelectedDate;

            //Validate that a start date was entered
            if (datStartDate == null)
            {
                MessageBox.Show("Please select a start date to generate a quote.");
                return;
            }
            //Validate that an end date was entered
            if (datEndDate == null)
            {
                MessageBox.Show("Please select an end date to generate a quote.");
                return;
            }
            //Validate that the end date is after the start date
            if (datStartDate > datEndDate)
            {
                MessageBox.Show("End date must be after the start date to generate a quote.");
                return;
            }

            //Identify the membership type selected and store in a string

            string strSelection = cmbMemType.SelectedItem.Content.ToString();

            //Cacluate the timespan


            //Find the details for the membership type

            //Read 
            try
            {
                string jsonData = File.ReadAllText(strFilePath);
                MembershipList = JsonConvert.DeserializeObject<List<Membership>>(jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in reading available memberships from memberships data file: " + ex.Message);
            }

            //Query the membership list to find the selected membership type to quote                     
            var membershipQuery =
              from m in MembershipList
              where m.Type == strSelection
              select m;

            //For the membership types that are available, add them to the combo box. 
            foreach (Membership m in membershipQuery)
            {
                lblMemTypeResult.Content = m.Type + "($" + m.Price + ")";
                lblStartDateResult.Content = datStartDate.ToString();
                lblEndDateResult.Content = datStartDate.ToString();
            }














            //idk about these
            DateTime datTime1 = (DateTime)datStartDate;
            DateTime datTime2 = (DateTime)datEndDate;
            TimeSpan? tspInterval = datEndDate - datStartDate;

            
        }




        
    }
}
