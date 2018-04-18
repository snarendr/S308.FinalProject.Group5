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

namespace FitnessClub
{
    /// <summary>
    /// Interaction logic for MembershipSales.xaml
    /// </summary>
    public partial class MembershipSales : Window
    {
        public MembershipSales()
        {
            InitializeComponent();
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

            DateTime? datStartDate = dtpStart.SelectedDate;
            DateTime? datEndDate = dtpEnd.SelectedDate;

            //Validate that a start date was entered
            if (datStartDate == null)
            {
                MessageBox.Show("Please select a start date to generate a quote.");
                return;
            }
            //Validate that an end date was entered
            if (datEndDate == null)
            {
                MessageBox.Show("Please select an end date to generate a quote.");
                return;
            }
            //Validate that the end date is after the start date
            if (datStartDate > datEndDate)
            {
                MessageBox.Show("End date must be after the start date to generate a quote.");
                return;
            }

            //Identify the membership type selected and store in a string
            ComboBoxItem cbiSelectedItem = (ComboBoxItem)cmbMemType.SelectedItem;
            string strSelection = cbiSelectedItem.Content.ToString();

            //Identify any additional features selected for the quote
           

            


            //idk about these
            DateTime datTime1 = (DateTime)datStartDate;
            DateTime datTime2 = (DateTime)datEndDate;
            TimeSpan? tspInterval = datEndDate - datStartDate;

            
        }




        
    }
}
