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
        string strFilePath1 = @"..\..\Data\membership.json";
        string strFilePath2 = @"..\..\Data\feature.json";
        List<Membership> MembershipList = new List<Membership>();
        List<Feature> featureList = new List<Feature>();


        public MembershipSales()
        {
            InitializeComponent();
            //Call the method to find the available memberships for the combo box
            AvailableMemberships();
        }

        //Create method to find the membership types that are currenlty available
        private void AvailableMemberships()
        {

            //Read membership json file to fill the membership list with the current membership data
            try
            {
                string jsonData = File.ReadAllText(strFilePath1);
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

            //Declare variable to store the start date
            DateTime? datStartDate = dtpStart.SelectedDate;

            //Validate that a start date was entered
            if (datStartDate == null)
            {
                MessageBox.Show("Please select a start date to generate a quote.");
                return;
            }
            //Identify the membership type selected and store in a string
            string strSelection = cmbMemType.SelectedItem.ToString();

            //Convert date and time
            DateTime datTime1 = (DateTime)datStartDate;
            DateTime datTime2 = (DateTime)datStartDate;

            //Cacluate the timespan for the selected membership
            if (strSelection == "Individual 12 Month" || strSelection == "Family 12 Month")
            {
                datTime2 = datTime1.AddYears(1);

            }
            else
            {
                datTime2 = datTime2.AddMonths(1);
            }

               
            TimeSpan tspInterval = datTime2 - datTime1;
            double dblIntvertval = tspInterval.Days;

                
            

            dblintvertval = dblintvertval / 30;
            dblintvertval = math.ceiling(dblIntvertval);

            double dblFeatureCost = 0
            string strFeatures = "";

            if(chbTraining.IsChecked == true)
            {
                try
                {
                    string jsonData = File.ReadAllText(strFilePath2);
                    featureList = JsonConvert.DeserializeObject<List<Feature>>(jsonData);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in reading available memberships from memberships data file: " + ex.Message);
                }

                //Query the membership list to find the selected membership type to quote                     
                var featureQuery =
                  from f in featureList
                  where f.Type == "Personal Training"
                  select f;

                foreach (Feature f in featureQuery)
                {
                    dblFeatureCost += f.price;
                    strFeatures += f.Type + " ($" + f.price + "/month)";

                }



                if (chbLockRental.IsChecked == true)
                {
                    try
                    {
                        string jsonData = File.ReadAllText(strFilePath2);
                        featureList = JsonConvert.DeserializeObject<List<Feature>>(jsonData);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error in reading available memberships from memberships data file: " + ex.Message);
                    }

                    //Query the membership list to find the selected membership type to quote                     
                    var featureQuery2 =
                      from f in featureList
                      where f.Type == "Locker Rental"
                      select f;

                    foreach (Feature f in featureQuery2)
                    {
                        dblFeatureCost += f.price;
                        strFeatures += Environment.NewLine + f.Type + " ($" + f.price + "/month)";
                    }
                }


               


                }


            //Find the details for the membership type

            //Read 
            try
            {
                string jsonData = File.ReadAllText(strFilePath1);
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
                lblMemTypeResult.Content = m.Type + " ($" + m.Price + ")";
                lblStartDateResult.Content = datTime1.ToShortDateString();
                lblEndDateResult.Content = datTime2.ToShortDateString();
                lblSubtotalResult.Content = (dblIntvertval * m.Price).ToString("C2");
                lblTotalResult.Content = ((dblIntvertval * m.Price) + (dblFeatureCost * dblIntvertval)).ToString("C2");

            }

            lblAddFeatResult.Content = strFeatures;














            //idk about these
          

            
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }


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

        private void btnApprove_Click(object sender, RoutedEventArgs e)
        {
            if(lblMemTypeResult.Content == "" || lblStartDate.Content == "" || lblEndDateResult.Content == "" || lblSubtotalResult.Content == "" || lblTotalResult.Content == "")
            {
                MessageBox.Show("A quote has not been fully generated. A full quote must be provided before approving the quote. Please ensure you have pressed the generate quote button prior to selecting the approve button.");
                return;
            }

            MembershipRegistration MembershipRegistrationWindow = new MembershipRegistration();
            MembershipRegistrationWindow.Show();
        }
    }
}
