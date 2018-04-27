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
        MemberInformation member;
        public MembershipRegistration(Quote q)
        {
            quote = q;
            InitializeComponent();
        }

       public MembershipRegistration(MemberInformation m, Quote q)
        {
            quote = q;
            member = m;
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

            strFirstName = txtFirstName.Text.Trim();
            strLastName = txtLastName.Text.Trim();
            strEmail = txtEmail.Text.Trim();
            strCCNum = txtCredCardNum.Text.Trim();
            strPhone = txtPhone.Text.Trim();
            strGender = "";
            intWeight = 0;
           
            //validate the user provided a first name
            if (strFirstName == "")
            {
                MessageBox.Show("Please provide a first name.");
                return;
            }

            //validate the user provided a last name
            if (strLastName == "")
            {
                MessageBox.Show("Please provide a last name.");
                return;
            }

            //validate the user selected a credit card type
            if (cmbCredCardType.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a credit card type");
                return;

            }

            //validate the user provided a credit card number
            if (strCCNum == "")
            {
                MessageBox.Show("Please provide a credit card number.");
                return;
            }

            //validate the credit card is 15 or 16 digits
            if (strCCNum.Length != 15 && strCCNum.Length != 16)
            {
                MessageBox.Show("Please enter a credit card number that is 15 or 16 digits.");
                return;
            }

            //validate the credit card is a valid number
                long lngCreditCard;
            if (!long.TryParse(strCCNum, out lngCreditCard))
            {
                MessageBox.Show("Please enter only numeric digits for the credit card. Please do not enter any alphanumeric characters or non-numeric characters.");
                return;
            }

            //validate the user provided a phone number
            if (strPhone == "")
            {
                MessageBox.Show("Please provide a phone number.");
                return;
            }

            //validate the phone number is 10 digits
            if(strPhone.Length != 10)
            {
                MessageBox.Show("Please enter a 10 digit phone number.");
                return;

            }

            //validate the phone number is all numeric
            long lngPhoneNumber;
            if (!long.TryParse(strPhone, out lngPhoneNumber))
            {
                MessageBox.Show("Please enter only numeric digits for the phone number. Please do not enter any alphanumeric characters or non-numeric characters.");
                return;
            }

            //validate the user provided an email
            if (strEmail == "")
            {
                MessageBox.Show("Please provide an email address.");
                return;
            }

            //Validate the email does not contain any spaces
            if (strEmail.Contains(" "))
            {
                MessageBox.Show("Please enter a valid email address that does contain spaces within the address.");
                return;
            }

            //Validate that the email contains an @ symbol
            if (!strEmail.Contains("@"))
            {
                MessageBox.Show("Please enter a valid email address that contains an @ symbol.");
                return;
            }
            //Validate that the email contains a period
            if (!strEmail.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address that contains a '.' (period) symbol.");
                return;
            }

            //Determine the index of the @ symbol and the period to test address valididity below
            int intSymbol = strEmail.Trim().IndexOf("@");
            int intPeriod = strEmail.Trim().IndexOf(".");

            //Validate that the @ symbol appears before the period 
            if (intSymbol - intPeriod > 0)
            {
                MessageBox.Show("Please enter a valid email address. The @ symbol must appear before the period.");
                return;
            }

            //Validate that at least one character is provided before the @ symbol
            if (intSymbol == 0)
            {
                MessageBox.Show("Please enter a valid email address. There must be at least one character before the @ symbol.");
                return;
            }

            //Validate that at least one character is present between the @ symbol and the period
            if (intPeriod - intSymbol == 1)
            {
                MessageBox.Show("Please enter a valid email address. There must be at least one character between the @ symbol and the period.");
                return;
            }

            //Determine the length of the email for futher validation below
            int intEmailLength = strEmail.Length;

            //Subtract the email length and the index of the period to determine if at least two characters appear after the period in the email address. 
            if (intEmailLength - intPeriod < 3)
            {
                MessageBox.Show("Please enter a valid email address. There must be at least two characters after the period.");
                return;
            }

            //validate a gender was provided
            if (rdbMale.IsChecked == false && rdbFemale.IsChecked == false && rdbNotProvided.IsChecked == false) 
            {
                MessageBox.Show("Please select a gender");
            }
            
            //store the selected gender type
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
            if(txtWeight.Text != "")
            {
                if (!int.TryParse(txtWeight.Text, out intWeight))
                {
                    MessageBox.Show("Please enter a number for Weight");
                    return;
                }
            }
                
            //start process to add new member to the membership json file
            //create a list store the members information
            //declare variable to store the file path of the membership json file
            List<MembersInformation> MemberList = new List<MembersInformation>();                    
            string strFilePath = @"..\..\Data\MembersInformation.json";

            //Read the json membership file and deserialize the information into the membership list
            try
            {
                string jsonData = File.ReadAllText(strFilePath);
                MemberList = JsonConvert.DeserializeObject<List<MembersInformation>>(jsonData);
            }
            //Catch any errors that occur and display an error message to the user
            catch (Exception ex)
            {
                MessageBox.Show("Error in reading membership information from memberships data file: " + ex.Message);
            }

            //set date time of registration
            DateTime datRegistration = DateTime.Now;

            //Add new member using the established signature
            MembersInformation MemberNew = new MembersInformation(datRegistration, quote.MembershipType, strFirstName, strLastName, quote.StartDate.ToString(), quote.EndDate.ToString(), quote.SubTotal, quote.AdditionalFeatures_Training, quote.AdditionalFeatures_LockerRental, quote.TotalCost, strPhone, strEmail, strGender, intWeight, strCCNum, chbAthPer.IsChecked.Value, chbOverHealth.IsChecked.Value, chbST.IsChecked.Value, chbWeightLoss.IsChecked.Value, chbWeightMgmt.IsChecked.Value);

            //Add the new member to the member list
            MemberList.Add(MemberNew);

            //Serialize the updated member list and overwrite the json file with the updated member information. Tell the user the member details have been updated. 
            try
            {
                string jsonData = JsonConvert.SerializeObject(MemberList);
                System.IO.File.WriteAllText(strFilePath, jsonData);
                MessageBox.Show("New member has been added.");
            }
            //If an export error occurs, notify the user with an error message. 
            catch (Exception ex)
            {
                MessageBox.Show("Error in export process " + ex.Message);
            }

        }
        private void btnExistingCustomer_Click(object sender, RoutedEventArgs e)
        {
            ExistingMemberSearch ExistingMemberWindow = new ExistingMemberSearch();
            ExistingMemberWindow.Show();
            this.Close();
        }
    } }
