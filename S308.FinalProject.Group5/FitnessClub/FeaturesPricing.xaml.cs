//MSN Logo Source: https://www.apk4now.com/apk/1424/msn-health-amp-fitness-workouts
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
            string strFeatureType = cbiSelectFeature.Content.ToString();

            //Query the membership data and find the membership type that matches the selection from the user                              
            var featureQuery =
              from f in FeatureList
              where (f.Type) == strFeatureType
              select f;

            //For the membership type that matches the selection by the user, display the current price to the user. Additionally display the availability to the user. 
            foreach (Feature f in featureQuery)
            {
                txbCurrentPrice.Text = f.price.ToString("C2");
            }
        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu MainMenuWindow = new MainMenu();
            MainMenuWindow.Show();
            this.Close();
        }
    }
}
