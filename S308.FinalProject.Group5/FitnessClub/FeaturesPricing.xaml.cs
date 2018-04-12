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

namespace FitnessClub
{
    /// <summary>
    /// Interaction logic for FeaturesPricing.xaml
    /// </summary>
    public partial class FeaturesPricing : Window
    {
        public FeaturesPricing()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if(cmbSelectFeatures.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a feature to change the price of.");
                return;
            }
        }
    }
}
