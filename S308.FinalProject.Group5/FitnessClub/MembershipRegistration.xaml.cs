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
using System.IO;
using Newtonsoft.Json;

namespace FitnessClub
{
    /// <summary>
    /// Interaction logic for MembershipRegistration.xaml
    /// </summary>
    public partial class MembershipRegistration : Window
    {
        Quote quote;
        public MembershipRegistration(Quote q)
        {
            quote = q;
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
            string strFirstName, strLastName, strEmail, strCCNum, strPhone, strGender;
            int intAge, intWeight;

            //place inputs into variables

            strFirstName = txtFirstName.Text;
            strLastName = txtLastName.Text;
            strEmail = txtEmail.Text;
            strCCNum = txtCredCardNum.Text;
            strPhone = txtPhone.Text;

            //validate inputs
            if (strFirstName == "" || strLastName == "" || strEmail == "" || strCCNum == "" || strPhone == "") 
            {
                MessageBox.Show("Please fill out all information (First Name, Last Name, Email, Phone, Credit Card Number");
                return;
            }

            //if the user provided an age, validate it is a valid number
            if (txtAge.Text != "")
            {
                if (!int.TryParse(txtAge.Text, out intAge))
                {
                    MessageBox.Show("Please enter a number for Age");
                    return;
                }

            }
            //if the user provided a weight, validate it is a number
            if(txtAge.Text != "")
            {
                if (!int.TryParse(txtWeight.Text, out intWeight))
                {
                    MessageBox.Show("Please enter a number for Weight");
                    return;
                }
            }
            //validate the user selected a credit card type
            if (cmbCredCardType.SelectedIndex == -1) 
            {
                MessageBox.Show("Please select a credit card type");
                return;

            }

            if (rdbMale.IsChecked == false && rdbFemale.IsChecked == false && rdbNotProvided.IsChecked == false) ;
            {
                MessageBox.Show("Please select a gender");
            }

            if (rdbFemale.IsChecked == true) 
            {
                strGender = rdbFemale.Content.ToString();
            }

            if (rdbMale.IsChecked == true) 
            {
                strGender = rdbMale.Content.ToString();
            }

            if (rdbNotProvided.IsChecked == true) 
            {
                strGender = rdbNotProvided.Content.ToString();
            }

            //add results to membership database

            MembersInformation MemberNew = new MembersInformation(quote.MembershipType, strFirstName, strLastName, quote.StartDate.ToString(), quote.EndDate.ToString(), quote.SubTotal, quote.AdditionalFeatures_Training, quote.AdditionalFeatures_LockerRental, quote.TotalCost, strPhone, strEmail, strGender, intWeight);
            //newmemberinformation json file edits

            //read the membership file
            List<MembersInformation> MemberList;
            string strFilePath = @"../../Data.MembersInformation.json";
            try
            {
                StreamReader reader = new StreamReader(strFilePath);
                string jsonData = reader.ReadToEnd();
                reader.Close();

                MemberList = JsonConvert.DeserializeObject<List<MembersInformation>>(jsonData);


            }

            catch (Exception ex)
            {
                MessageBox.Show("Error in import process: " + ex.Message);
            }


            //writing back to file
            try
            {
                string jsonData = JsonConvert.SerializeObject(MemberList);
                System.IO.File.WriteAllText(strFilePath, jsonData);
                MessageBox.Show("New Member has been added");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in append file: " + ex.Message);
                return;
            }


        }

        private void btnExistingCustomer_Click(object sender, RoutedEventArgs e)
        {
            ExistingMemberSearch ExistingMemberWindow = new ExistingMemberSearch();
            ExistingMemberWindow.Show();
            this.Close();
        }
    } }
