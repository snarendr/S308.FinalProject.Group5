//MSN Logo Source: https://www.apk4now.com/apk/1424/msn-health-amp-fitness-workouts
//Working out picture source: https://classroomclipart.com/clipart/Clipart/Fitness_and_Exercise.htm

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
    /// Interaction logic for ExistingMemberSearch.xaml
    /// </summary>
    public partial class ExistingMemberSearch : Window
    {
        public ExistingMemberSearch()
        {
            InitializeComponent();
        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu MainMenuWindow = new MainMenu();
            MainMenuWindow.Show();
            this.Close();
        }

        private void btnClearSearch_Click(object sender, RoutedEventArgs e)
        {
            txtEmailInput.Text = "";
            txtLastNameInput.Text = "";
            txtPhoneNumberInput.Text = "";
        }
    }
}
