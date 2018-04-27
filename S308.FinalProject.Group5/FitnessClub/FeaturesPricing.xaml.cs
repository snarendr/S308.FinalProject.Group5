﻿//MSN Logo Source: https://www.apk4now.com/apk/1424/msn-health-amp-fitness-workouts
//Locker Rental Image Source: https://www.disneybyage.com/typhoon-lagoon-blizzard-beach-disney-water-park/locker-map-icon/
//Personal Training Image Source: https://maxvo2.com/content/images/fitness-icons/personal-trainer-icon-med-black.svg
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
    /// Interaction logic for FeaturesPricing.xaml
    /// </summary>
    public partial class FeaturesPricing : Window
    {
        //Create variable to store the membership json file path
        string strFilePath = @"..\..\Data\feature.json";
        //Create membership list based on the feature class
        List<Feature> FeatureList = new List<Feature>();

        public FeaturesPricing()
        {
            InitializeComponent();
            //Call method to clear the form 
            ClearForm();
        }
        //Delcare method to reset the the update price text box and combo box.  
        private void ClearForm()
        {
            txbUpdatePrice.Text = "";
            cmbSelectFeatures.SelectedIndex = 0;
        }

        //User selects the submit button
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (cmbSelectFeatures.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a feature to change the price of.");
                return;
            }

            //Read feature json file to fill the feature list with the current feature data
            try
            {
                string jsonData = File.ReadAllText(strFilePath);
                FeatureList = JsonConvert.DeserializeObject<List<Feature>>(jsonData);
            }
            //Display an error message to the user if an error occurs during the import process
            catch (Exception ex)
            {
                MessageBox.Show("Error in import process: " + ex.Message);
            }

            //Store the comobo box selection in a string variable
            ComboBoxItem cbiFeatureType = (ComboBoxItem)cmbSelectFeatures.SelectedItem;
            string strFeatureType = cbiFeatureType.Content.ToString();

            //Query the feature list and find the feature type that matches the selection from the user                              
            var featureQuery =
              from f in FeatureList
              where (f.Type) == strFeatureType
              select f;

            //For the feature type that matches the selection by the user, display the current price to the user.
            foreach (Feature f in featureQuery)
            {
                txbSelectedFeature.Text = f.Type;
                txbCurrentPrice.Text = f.price.ToString("C2");
            }
        }




        //User selects update button
        private void btnUpdatePrice_Click(object sender, RoutedEventArgs e)
        {

            //Validate that the user has selected a membership type to modify
            if (cmbSelectFeatures.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a feature type to modify.");
                return;
            }

            //Find the selected feature type from the user and store the selected feature type as a string in a variable. 
            ComboBoxItem cbiFeatureType;
            cbiFeatureType = (ComboBoxItem)cmbSelectFeatures.SelectedItem;
            string strFeatureType = cbiFeatureType.Content.ToString();

            //Validate that the user has entered an updated price
            if (txbUpdatePrice.Text == "")
            {
                MessageBox.Show("Please enter an updated price.");
                return;
            }

            //Declare a double variable to store the updated price from the user
            double dblUpdatePrice = Convert.ToDouble(txbUpdatePrice.Text);

            //Run a qeuery to find the feature in the feature list that matches the feature selected by the user
            var featureQuery =
             from f in FeatureList
             where (f.Type) == strFeatureType
             select f;

            //For the membership selected by the user, update the availability as stored in the bool variable and the price as stored in the double variable. 
            foreach (Feature f in featureQuery)
            {
                f.price = dblUpdatePrice;
            }


            //Serialize the updated feature list and overwrite the json file with the updated feature information. Tell the user the feature details have been updated. 
            try
            {
                string jsonData = JsonConvert.SerializeObject(FeatureList);
                System.IO.File.WriteAllText(strFilePath, jsonData);
                MessageBox.Show(strFeatureType + " details have been updated. You will see the updated details after pressing ok.");
            }
            //If an export error occurs, notify the user with an error message. 
            catch (Exception ex)
            {
                MessageBox.Show("Error in export process " + ex.Message);
            }

            //Run query to find the membership that was updated from the membership list
            var featurepNewInformation =
             from f in FeatureList
             where (f.Type) == strFeatureType
             select f;

            //For the updated membership, display the now current price and availability to the user
            foreach (Feature f in featurepNewInformation)
            {
                txbSelectedFeature.Text = strFeatureType;
                txbCurrentPrice.Text = f.price.ToString("C2");
            }
            //Clear the update price textbox
            txbUpdatePrice.Text = "";

        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu MainMenuWindow = new MainMenu();
            MainMenuWindow.Show();
            this.Close();
        }
    }
}
