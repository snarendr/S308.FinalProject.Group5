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

        //Declare strings variables to store the file paths for the membership and feature json files
        string strFilePathMembership = @"..\..\Data\membership.json";
        string strFilePathFeature = @"..\..\Data\feature.json";

        //Create lists for the membership and the feature information and brings in information from Quote class
        List<Membership> MembershipList = new List<Membership>();
        List<Feature> featureList = new List<Feature>();
        Quote quote;

        public MembershipSales()
        {
            InitializeComponent();
            //Call the method to find the available memberships to display in the combo box
            AvailableMemberships();
        }

        //Create method to find the membership types that are currently available
        private void AvailableMemberships()
        {
            //Read membership json file to fill the membership list with the current membership data
            try
            {
                string jsonData = File.ReadAllText(strFilePathMembership);
                MembershipList = JsonConvert.DeserializeObject<List<Membership>>(jsonData);
            }
            //Alert the user if there is an error that occurs during the read process
            catch (Exception ex)
            {
                MessageBox.Show("Error in reading available memberships from memberships data file: " + ex.Message);
            }

            //Query the membership list to find the memberships that are available                       
            var membershipAvailableQuery =
              from m in MembershipList
              where m.Available
              select m;

            //For the membership types that are available, add them to the combo box. 
            foreach (Membership m in membershipAvailableQuery)
            {
                cmbMemType.Items.Add(m.Type);
            }
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

            //Validate that a start date was entered
            if (dtpStart.SelectedDate == null)
            {
                MessageBox.Show("Please select a start date to generate a quote.");
                return;
            }

            //Declare variable to store the start date
            DateTime datStartDate = dtpStart.SelectedDate.Value;

            //Validate the start date is not in the past
            if (datStartDate < DateTime.Today)
            {
                MessageBox.Show("Please select a start date that is not before the present date.");
                return;
            }

            //Identify the membership type selected and store in a string variable
            string strSelection = cmbMemType.SelectedItem.ToString();

            //Declare End Date Variable
            DateTime datEndTime;

            //Declare variable to store number of membership months
            byte bytMonths = 0;

            //Cacluate the timespan for the selected membership - Either add 1 year or 1 month to the start time based on the selected membership. Store the equivalent number of months in a byte variable for usage in calculating additional feature costs. 
            if (strSelection == "Individual 12 Month" || strSelection == "Family 12 Month")
            {
                //Since user is selecting a 12 month option, add 1 year to the start date to get the end date
                datEndTime = datStartDate.AddYears(1);
                //Store 12 months in byte variable for calcuation of any feature costs
                bytMonths = 12;

            }
            else
            {
                //Since user is selecting a 1 month option, add 1 month to the start date to get the end date
                datEndTime = datStartDate.AddMonths(1);
                //Store 1 months in byte variable for calcuation of any feature costs
                bytMonths = 1;
            }

            //Declare variables to store the feature cost and the feature names/details of the selected features
            double dblFeatureCost = 0;
            string strFeatures = "";

            //If the user selected the personal training feature, read the json feature file to find the price of training
            if (chbTraining.IsChecked == true)
            {
                //Read the json feature file and deserialize the information into the feature list
                try
                {
                    string jsonData = File.ReadAllText(strFilePathFeature);
                    featureList = JsonConvert.DeserializeObject<List<Feature>>(jsonData);
                }
                //Catch any errors that occur and display an error message to the user
                catch (Exception ex)
                {
                    MessageBox.Show("Error in reading available memberships from memberships data file: " + ex.Message);
                }

                //Query the feature list to find information pertaining to personal training               
                var featureQuery =
                  from f in featureList
                  where f.Type == "Personal Training Plan"
                  select f;

                //Find the price of the price of personal training and add the cost to the feature cost variable and add the feature name and cost to the feature string. 
                foreach (Feature f in featureQuery)
                {
                    dblFeatureCost += f.price;
                    strFeatures += f.Type + " ($" + f.price + "/month)" + Environment.NewLine;

                }
            }

            //If the user selected the locker rental feature, read the json feature file to find the price of locker rentals
            if (chbLockRental.IsChecked == true)
            {
                //Read the json feature file and deserialize the information into the feature list
                try
                {
                    string jsonData = File.ReadAllText(strFilePathFeature);
                    featureList = JsonConvert.DeserializeObject<List<Feature>>(jsonData);
                }
                //Catch any errors that occur and display an error message to the user
                catch (Exception ex)
                {
                    MessageBox.Show("Error in reading available memberships from memberships data file: " + ex.Message);
                }

                //Query the feature list to find information pertaining to locker rentals                    
                var featureQuery2 =
                  from f in featureList
                  where f.Type == "Locker Rental"
                  select f;

                //Find the price of the price of locker rentals and add the cost to the current cost in the feature cost variable and add the feature name and cost to the feature string. 
                foreach (Feature f in featureQuery2)
                {
                    dblFeatureCost += f.price;
                    strFeatures += f.Type + " ($" + f.price + "/month)";
                }
            }

            //Find cost information for the selected the membership type
            //Read the json feature file and deserialize the information into the membership list
            try
            {
                string jsonData = File.ReadAllText(strFilePathMembership);
                MembershipList = JsonConvert.DeserializeObject<List<Membership>>(jsonData);
            }

            //Catch any errors that occur and display an error message to the user
            catch (Exception ex)
            {
                MessageBox.Show("Error in reading available memberships from memberships data file: " + ex.Message);
            }

            //Query the membership list to find the selected membership type                     
            var membershipQuery =
              from member in MembershipList
              where member.Type == strSelection
              select member;

            Membership m = membershipQuery.First();

            //Store the subtotal as the price of the selected membership
            double dblSubTotal = m.Price;
            //Cacluate the total cost by adding the membership cost to the total feauture cost. The total feature cost is calculated by multiplying the costs per month of the selected features by the number of months for the selected membership type. 
            double dblFinalTotal = (m.Price + (dblFeatureCost * bytMonths));
            //Display the selected membership type and its associated price to the user
            lblMemTypeResult.Content = m.Type + " ($" + m.Price + ")";
            //Display the membership start date to the user in short date format
            lblStartDateResult.Content = datStartDate.ToShortDateString();
            //Display the membership end date to the user in short date format
            lblEndDateResult.Content = datEndTime.ToShortDateString();
            //Dispaly the subtotal to the user in currency format
            lblSubtotalResult.Content = dblSubTotal.ToString("C2");
            //Dispaly the the total cost to the user in currency format
            lblTotalResult.Content = (dblFinalTotal).ToString("C2");
            //Display the selected feature content to the user
            lblAddFeatResult.Content = strFeatures;

            quote = new Quote(strSelection, datStartDate, datEndTime, chbTraining.IsChecked.Value, chbLockRental.IsChecked.Value, dblSubTotal, dblFinalTotal);
        }

        //Call clear form method is user selects clear button
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        //Clear all form content and reset user selection options
        private void ClearForm()
        {
            cmbMemType.SelectedIndex = 0;
            chbLockRental.IsChecked = false;
            chbTraining.IsChecked = false;
            dtpStart.SelectedDate = null;
            lblMemTypeResult.Content = "";
            lblStartDateResult.Content = "";
            lblEndDateResult.Content = "";
            lblSubtotalResult.Content = "";
            lblAddFeatResult.Content = "";
            lblTotalResult.Content = "";
        }

        //User selects approve quote button
        private void btnApprove_Click(object sender, RoutedEventArgs e)
        {
            //Validate that all needed content for the quote was displayed to the user prior to allowing the user to proceed with the registration process
            if (lblMemTypeResult.Content == "" || lblStartDate.Content == "" || lblEndDateResult.Content == "" || lblSubtotalResult.Content == "" || lblTotalResult.Content == "")
            {
                MessageBox.Show("A quote has not been fully generated. A full quote must be provided before approving the quote. Please ensure you have pressed the generate quote button prior to selecting the approve button.");
                return;
            }
            //If the quote was properly generated, open the window for membership registration and pass in the needed information from the quote
            MembershipRegistration MembershipRegistrationWindow = new MembershipRegistration(quote);
            MembershipRegistrationWindow.Show();
            this.Close();
        }

        //Allow user to go back to the Main Menu
        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu MainMenuWindow = new MainMenu();
            MainMenuWindow.Show();
            this.Close();
        }
    }
}
