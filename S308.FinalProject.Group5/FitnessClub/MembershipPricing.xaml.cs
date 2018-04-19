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
            //Reset the the update price text box and the radio buttons. 
            txbUpdatePrice.Text = "";
            rdbOffered.IsChecked = false;
            rdbNotOffered.IsChecked = false;
        }
        //
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            //Reset the the update price text box and the radio buttons. 
            txbUpdatePrice.Text = "";
            rdbOffered.IsChecked = false;
            rdbNotOffered.IsChecked = false;

            //Validate that the user has a selected a memebership type
            if (cmbMembershipType.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a membership type to modify.");
                return;
            }

            //Store the comobo box selection in a string variable
            ComboBoxItem cbiMembershipType = (ComboBoxItem)cmbMembershipType.SelectedItem;
            string strMembershipType = cbiMembershipType.Content.ToString();

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
            
            //Query the membership data and find the membership type that matches the selection from the user                              
            var membershipQuery =
              from m in MembershipList
              where (m.Type) == "Individual 1 Month"
              select m;

            //For the membership type that matches the selection by the user, dispaly the current price to the user. Additionally select the radio button that matches the availability of the selected membership. 
            foreach (Membership m in membershipQuery)
            {
                txbCurrentPrice.Text = m.Price.ToString("C2");

                if (m.Available)
                {
                    rdbOffered.IsChecked = true;
                }
                else
                    rdbNotOffered.IsChecked = true;                          
            }

            //Display the selected membership type to the user
            txbSelectedMembership.Text = strMembershipType;

        }

        private void btnMainMenu_Click_1(object sender, RoutedEventArgs e)
        {
            MainMenu MainMenuWindow = new MainMenu();
            MainMenuWindow.Show();
            this.Close();
        }

        private void btnUpdatePrice_Click(object sender, RoutedEventArgs e)
        {

            ComboBoxItem cbiMembershipType;
            cbiMembershipType = (ComboBoxItem)cmbMembershipType.SelectedItem;
            string strMembershipType = cbiMembershipType.Content.ToString();

            double dblUpdatedPrice = Convert.ToDouble(txbUpdatePrice.Text);

            bool bolOffered;
            if (rdbOffered.IsChecked == true)
            {
                bolOffered = true;

            }
            else
                bolOffered = false;

            var membershipQuery =
             from m in MembershipList
             where (m.Type) == strMembershipType
             select m;

            foreach (Membership m in membershipQuery)
            {
                m.Price = dblUpdatedPrice;
                m.Available = bolOffered;
            }

            try
            {
                string jsonData = JsonConvert.SerializeObject(MembershipList);
                System.IO.File.WriteAllText(strFilePath, jsonData);
                MessageBox.Show(strMembershipType + " details have been updated.");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error in export process " + ex.Message);
            }

            var membershipQuery2 =
             from m in MembershipList
             where (m.Type) == strMembershipType
             select m;

            foreach (Membership m in membershipQuery2)
            {
                txbCurrentPrice.Text = m.Price.ToString("C2");

                if (m.Available)
                {
                    rdbOffered.IsChecked = true;
                }
                else
                    rdbNotOffered.IsChecked = true;
            }


        }
    }
}
