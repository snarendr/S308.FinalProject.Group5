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
        string strFilePath = @"..\..\..\Data\membership.json";
        List<Membership> MembershipList = new List<Membership>();
        public MembershipPricing()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if(cmbMembershipType.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a membership type to modify.");
                return;
            }

            string strMembershipType = cmbMembershipType.SelectedItem.ToString();

            try
            {
                string jsonData = File.ReadAllText(strFilePath);
                MembershipList = JsonConvert.DeserializeObject<List<Membership>>(jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in import process: " + ex.Message);
            }

            var membershipQuery =
                from m in MembershipList
                where (m.Type.ToString() == strMembershipType)
                select m;
            
            foreach(Membership m in membershipQuery)
            {
                txbSelectedMembership.Text = m.Type;
            }

        }

        private void btnMainMenu_Click_1(object sender, RoutedEventArgs e)
        {
            MainMenu MainMenuWindow = new MainMenu();
            MainMenuWindow.Show();
            this.Close();
        }
    }
}
