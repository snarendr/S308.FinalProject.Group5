//Team 5: Suhas Narendrula, Michael O'Hara, Nathan Jobst
//MSN Logo Source: https://www.apk4now.com/apk/1424/msn-health-amp-fitness-workouts
//Fitness Center Image Source: https://www.canstockphoto.com/illustration/fitness-center.html
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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnMembershipSales_Click(object sender, RoutedEventArgs e)
        {
            MembershipSales MemberShipSalesWindow = new MembershipSales();
            MemberShipSalesWindow.Show();
            this.Close();
        }

        private void btnMemberInformation_Click(object sender, RoutedEventArgs e)
        {
            MemberInformation MemberInformationWindow = new MemberInformation();
            MemberInformationWindow.Show();
            this.Close();
        }

        private void btnMembershipPricing_Click(object sender, RoutedEventArgs e)
        {
            MembershipPricing MembershipPricingWindow = new MembershipPricing();
            MembershipPricingWindow.Show();
            this.Close();
        }

        private void btnFeaturesPricing_Click(object sender, RoutedEventArgs e)
        {
            FeaturesPricing FeaturesPricingWindow = new FeaturesPricing();
            FeaturesPricingWindow.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
