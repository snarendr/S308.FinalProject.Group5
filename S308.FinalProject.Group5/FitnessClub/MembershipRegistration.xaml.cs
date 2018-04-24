//MSN Logo Source: https://www.apk4now.com/apk/1424/msn-health-amp-fitness-workouts
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
    /// Interaction logic for MembershipRegistration.xaml
    /// </summary>
    public partial class MembershipRegistration : Window
    {
        public MembershipRegistration()
        {
            InitializeComponent();
        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu MainMenuWindow = new MainMenu();
            MainMenuWindow.Show();
            this.Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MembershipSales MemberShipSalesWindow = new MembershipSales();
            MemberShipSalesWindow.Show();
            this.Close();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string strFirstName, strLastName, strEmail, strCCNum, strPhone;
            int intAge, intWeight;

            //place inputs into variables

            strFirstName = txtFirstName.Text;
            strLastName = txtLastName.Text;
            strEmail = txtEmail.Text;
            strCCNum = txtCredCardNum.Text;
            strPhone = txtPhone.Text;
            

            //validate inputs
            if (strFirstName == "" || strLastName == "" || strEmail == "" || strCCNum == "" || strPhone == "") ;
            {
                MessageBox.Show("Please fill out all information (First Name, Last Name, Email, Phone, Credit Card Number");
                return;
            }

            if (!int.TryParse(txtAge.Text, out intAge)) ;
            {
                MessageBox.Show("Please enter a number for Age");
                return;
            }

            if (!int.TryParse(txtWeight.Text, out intWeight)) ;
            {
                MessageBox.Show("Please enter a number for Weight");
                return;
            }

            if (cmbCredCardType.SelectedIndex == -1) ;
            {
                MessageBox.Show("Please select a credit card type");
                return;
               
            }

            if (rdbMale.IsChecked == false && rdbFemale.IsChecked == false && rdbNotProvided.IsChecked == false);
            {
                MessageBox.Show("Please select a gender");
            }

            //add results to membership database

        }
    } }
