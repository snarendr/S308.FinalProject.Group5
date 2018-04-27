//MSN Logo Source: https://www.apk4now.com/apk/1424/msn-health-amp-fitness-workouts
//Value Pricing Image Source: http://spcmechanical.com/value-engineering-2/
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
    /// Interaction logic for MembershipPricing.xaml
    /// </summary>
    public partial class MembershipPricing : Window
    {
        //Create variable to store the membership json file path
        string strFilePath = @"..\..\Data\membership.json";
        //Create membership list based on the membership class
        List<Membership> MembershipList = new List<Membership>();
        
        public MembershipPricing()
        {
            InitializeComponent();
            //Call method to clear the form 
            ClearForm();
        }
        //Delcare method to reset the the update price text box, combo box, and the radio buttons. 
        private void ClearForm()
        {
            txbUpdatePrice.Text = "";
            rdbOffered.IsChecked = false;
            rdbNotOffered.IsChecked = false;
            cmbMembershipType.SelectedIndex = 0;
        }
        //Display the current price and availability the membership selected by the user. 
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
 
            //Validate that the user has a selected a memebership type
            if (cmbMembershipType.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a membership type to modify.");
                return;
            }

            //Read membership json file to fill the membership list with the current membership data
            try
            {
                string jsonData = File.ReadAllText(strFilePath);
                MembershipList = JsonConvert.DeserializeObject<List<Membership>>(jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in import process: " + ex.Message);
            }

            //Store the comobo box selection in a string variable
            ComboBoxItem cbiMembershipType = (ComboBoxItem)cmbMembershipType.SelectedItem;
            string strMembershipType = cbiMembershipType.Content.ToString();

            //Query the membership data and find the membership type that matches the selection from the user                              
            var membershipQuery =
              from m in MembershipList
              where (m.Type) == strMembershipType
              select m;

            //For the membership type that matches the selection by the user, display the current price to the user. Additionally display the availability to the user. 
            foreach (Membership m in membershipQuery)
            {
                txbCurrentPrice.Text = m.Price.ToString("C2");

                if (m.Available)
                {
                    txbCurrentAvailability.Text = "Available";
                }
                else
                    txbCurrentAvailability.Text = "Not Available";                        
            }

            //Display the selected membership type to the user
            txbSelectedMembership.Text = strMembershipType;

            //Clear any update information that is currently in the form
            txbUpdatePrice.Text = "";
            rdbOffered.IsChecked = false;
            rdbNotOffered.IsChecked = false;

        }

        //User selects update membership button
        private void btnUpdatePrice_Click(object sender, RoutedEventArgs e)
        {
            //Validate that the user has selected a membership type to modify
            if (cmbMembershipType.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a membership type to modify.");
                return;
            }

            //Find the selected membership type from the user and store the selected membership type as a string in a variable. 
            ComboBoxItem cbiMembershipType;
            cbiMembershipType = (ComboBoxItem)cmbMembershipType.SelectedItem;
            string strMembershipType = cbiMembershipType.Content.ToString();

            //Validate that the user has entered an updated price and/or selected an availability option
            if (txbUpdatePrice.Text == "" && rdbOffered.IsChecked == false && rdbNotOffered.IsChecked == false)
            {
                MessageBox.Show("Please enter a price or select an availability option.");
                return;
            }

            //Read membership json file to fill the membership list with the current membership data
            try
            {
                string jsonData = File.ReadAllText(strFilePath);
                MembershipList = JsonConvert.DeserializeObject<List<Membership>>(jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in import process: " + ex.Message);
            }

            //If user has updated the price and selected an availability option, execute the below code
            if (txbUpdatePrice.Text != "" && (rdbOffered.IsChecked == true || rdbNotOffered.IsChecked == true))
            {
                //Declare double variable and store the updated price from the user. 
                double dblUpdatePrice = Convert.ToDouble(txbUpdatePrice.Text);
                
                //Create bool variable to store the user selection for memebership availability
                bool bolOffered;
                //If the offered option was checked, set the bool variable as true, otherwise set the bool variable as false
                if (rdbOffered.IsChecked == true)
                {
                    bolOffered = true;

                }
                else
                    bolOffered = false;
                
                //Run a qeuery to find the membership in the membership list that matches the membership selected by the user
                var membershipQuery =
                 from m in MembershipList
                 where (m.Type) == strMembershipType
                 select m;

                //For the membership selected by the user, update the availability as stored in the bool variable and the price as stored in the double variable. 
                foreach (Membership m in membershipQuery)
                {
                    m.Available = bolOffered;
                    m.Price = dblUpdatePrice;
                }

            }
            //If the user has not entered an updated price, an availability option must have been selected based on previous validation. Run the below code to update the membership availability. 
            if (txbUpdatePrice.Text == "")
            {
                //Create bool variable to store the user selection for memebership availability
                bool bolOffered;
                //If the offered option was checked, set the bool variable as true, otherwise set the bool variable as false
                if (rdbOffered.IsChecked == true)
                {
                    bolOffered = true;

                }
                else
                    bolOffered = false;

                //Run a qeuery to find the membership in the membership list that matches the membership selected by the user
                var membershipQuery =
                 from m in MembershipList
                 where (m.Type) == strMembershipType
                 select m;
                //For the membership selected by the user, update the availability as stored in the bool variable. 
                foreach (Membership m in membershipQuery)
                {
                    m.Available = bolOffered;
                }

            }

            //If the user selected an availability option, an update price must have been entered based on previous validation. Execute the following code to only update the price. 
            if (rdbOffered.IsChecked == false && rdbNotOffered.IsChecked == false)
            {
                //Declare double variable and store the updated price from the user. 
                double dblUpdatePrice = Convert.ToDouble(txbUpdatePrice.Text);

                //Run a qeuery to find the membership in the membership list that matches the membership selected by the user
                var membershipQuery =
                 from m in MembershipList
                 where (m.Type) == strMembershipType
                 select m;

                //For the membership selected by the user, update the update as stored the price variable. 
                foreach (Membership m in membershipQuery)
                {
                    m.Price = dblUpdatePrice;

                }
            }
            
            //Serialize the updated membership list and overwrite the json file with the updated membership information. Tell the user the membership details have been updated. 
            try
            {
                string jsonData = JsonConvert.SerializeObject(MembershipList);
                System.IO.File.WriteAllText(strFilePath, jsonData);
                MessageBox.Show(strMembershipType + " details have been updated. You will see the updated details in current price and availability box after pressing ok.");
            }
            //If an export error occurs, notify the user with an error message. 
            catch (Exception ex)
            {
                MessageBox.Show("Error in export process " + ex.Message);
            }

            //Run query to find the membership that was updated from the membership list
            var membershipNewInformation =
             from m in MembershipList
             where (m.Type) == strMembershipType
             select m;

            //For the updated membership, display the now current price and availability to the user
            foreach (Membership m in membershipNewInformation)
            {
                txbSelectedMembership.Text = strMembershipType;
                txbCurrentPrice.Text = m.Price.ToString("C2");

                if (m.Available)
                {
                txbCurrentAvailability.Text = "Available";
                }
                else
                txbCurrentAvailability.Text = "Not Available";
            }
            //Reset the update price and availability options
            txbUpdatePrice.Text = "";
            rdbNotOffered.IsChecked = false;
            rdbOffered.IsChecked = false;
        }

        //Return the user to the main menu
        private void btnMainMenu_Click_1(object sender, RoutedEventArgs e)
        {
            MainMenu MainMenuWindow = new MainMenu();
            MainMenuWindow.Show();
            this.Close();
        }
    }
}
