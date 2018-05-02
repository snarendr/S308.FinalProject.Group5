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
        //MemberInformation member;
        //Getter and Setter for information from exisiting members 
        public MembersInformation InfoFromPrevWindow { get; set; }
        public MembershipRegistration(Quote q)
        {
            quote = q;
            InitializeComponent();
            //Defalting blank member info for the default constructor
            InfoFromPrevWindow = new MembersInformation();

        }
        public MembershipRegistration(MembersInformation info, Quote q)
        {
            quote = q;
            InfoFromPrevWindow = info;
            InitializeComponent();
            string strMemType;
            bool addfeat_tr, addfeat_lr;
            double dblSubTotal, dblTotal;
            DateTime datStartDate, datEndDate;

            strMemType = quote.MembershipType;
            addfeat_lr = quote.AdditionalFeatures_LockerRental;
            addfeat_tr = quote.AdditionalFeatures_Training;
            dblSubTotal = quote.SubTotal;
            dblTotal = quote.TotalCost;
            datStartDate = quote.StartDate;
            datEndDate = quote.EndDate;
            DoSomethingWithInfo();

        }
        public void DoSomethingWithInfo()
        {
            //put existing information into regirstration screen
            string strGender; 

            txtFirstName.Text = InfoFromPrevWindow.FirstName;
            txtLastName.Text = InfoFromPrevWindow.LastName;
            txtCredCardNum.Text = InfoFromPrevWindow.Credit_Card_Number;
            txtPhone.Text = InfoFromPrevWindow.PhoneNumber;
            strGender = InfoFromPrevWindow.Gender;
            txtEmail.Text = InfoFromPrevWindow.Email;
            txtAge.Text = InfoFromPrevWindow.Age.ToString(); 
            txtWeight.Text = InfoFromPrevWindow.Weight.ToString();
            strGender = InfoFromPrevWindow.Gender;
            
            //assign credit card type to combobox
            if(InfoFromPrevWindow.Credit_Card_Type == "Visa")
            {
                cmbCredCardType.SelectedIndex = 1;
            }

            if (InfoFromPrevWindow.Credit_Card_Type == "MasterCard")
            {
                cmbCredCardType.SelectedIndex = 2;
            }

            if (InfoFromPrevWindow.Credit_Card_Type == "American Express")
            {
                cmbCredCardType.SelectedIndex = 3;
            }

            if (InfoFromPrevWindow.Credit_Card_Type == "Discover")
            {
                cmbCredCardType.SelectedIndex = 4;
            }

            //Checking correct radio button based upon the members gender 
            if (strGender == "Male")
            {
                rdbMale.IsChecked = true;
            }

            else if (strGender == "Female")
            {
                rdbFemale.IsChecked = true;
            }
            else
            {
                rdbNotProvided.IsChecked = true;
            }
            //Getting boolean from exisiting member search and if true, check box is checked, if false, check box is unchecked 
            chbAthPer.IsChecked = InfoFromPrevWindow.PFG_AthleticPerformance;
            if (chbAthPer.IsChecked.Value == true)
            {
                chbAthPer.SetCurrentValue(CheckBox.IsCheckedProperty, true);
            }


            chbOverHealth.IsChecked = InfoFromPrevWindow.PFG_OverallHealth;
            if (chbOverHealth.IsChecked.Value == true)
            {
                chbOverHealth.SetCurrentValue(CheckBox.IsCheckedProperty, true);
            }
            else
            {
                chbOverHealth.SetCurrentValue(CheckBox.IsCheckedProperty, false);
            }

            chbST.IsChecked = InfoFromPrevWindow.PFG_StrengthTraining;
            if (chbST.IsChecked.Value == true)
            {
                chbST.SetCurrentValue(CheckBox.IsCheckedProperty, true);
            }
            else
            {
                chbST.SetCurrentValue(CheckBox.IsCheckedProperty, false);
            }

            chbWeightLoss.IsChecked = InfoFromPrevWindow.PFG_WeightLoss;
            if (chbWeightLoss.IsChecked.Value == true)
            {
                chbWeightLoss.SetCurrentValue(CheckBox.IsCheckedProperty, true);
            }
            else
            {
                chbWeightLoss.SetCurrentValue(CheckBox.IsCheckedProperty, false);
            }

            chbWeightMgmt.IsChecked = InfoFromPrevWindow.PFG_WeightManagment;
            if (chbWeightMgmt.IsChecked.Value == true)
            {
                chbWeightMgmt.SetCurrentValue(CheckBox.IsCheckedProperty, true);
            }
            else
            {
                chbWeightMgmt.SetCurrentValue(CheckBox.IsCheckedProperty, false);
            }
        }
        //User selects button to return to the main menu
        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu MainMenuWindow = new MainMenu();
            MainMenuWindow.Show();
            this.Close();
        }
        //User wants  selects back button to return to original membership sales page
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MembershipSales MemberShipSalesWindow = new MembershipSales();
            MemberShipSalesWindow.Show();
            this.Close();
        }
        //User opens the existing member search window
        private void btnExistingCustomer_Click(object sender, RoutedEventArgs e)
        {
            Quote q;

            q = quote;
            string strMemType;

            strMemType = quote.MembershipType;


            ExistingMemberSearch ExistingMemberWindow = new ExistingMemberSearch(q);
            ExistingMemberWindow.Show();
            this.Close();
        }
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
           
            
            //declare variables to store first name, last name, email, cc number, phone, gender, age, and weight
            string strFirstName, strLastName, strEmail, strCCNum, strPhone, strGender, strCCType,strMemType;
            int intAge, intWeight;

            //place inputs into variables
            strFirstName = txtFirstName.Text.Trim();
            strLastName = txtLastName.Text.Trim();
            strEmail = txtEmail.Text.Trim();
            strCCNum = txtCredCardNum.Text.Trim();
            strPhone = txtPhone.Text.Trim();
            strCCType = ((ComboBoxItem)cmbCredCardType.SelectedItem).Content as string;
            strGender = "";
            intAge = 0;
            intWeight = 0;

           
            bool addfeat_tr, addfeat_lr;
            double dblSubTotal, dblTotal;
            DateTime datStartDate, datEndDate;

           
            strMemType = quote.MembershipType;
            
            
            addfeat_lr = quote.AdditionalFeatures_LockerRental;
            addfeat_tr = quote.AdditionalFeatures_Training;
            dblSubTotal = quote.SubTotal;
            dblTotal = quote.TotalCost;
            datStartDate = quote.StartDate;
            datEndDate = quote.EndDate;



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
            if (strPhone.Length != 10)
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
            if (txtWeight.Text != "")
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


            // MembersInformation MemberNew = new MembersInformation(quote.MembershipType, strFirstName.ToUpper(), strLastName.ToUpper(), quote.StartDate.ToShortDateString(), quote.EndDate.ToShortDateString(), quote.SubTotal, quote.AdditionalFeatures_Training, quote.AdditionalFeatures_LockerRental, quote.TotalCost, strPhone, strEmail.ToUpper(), strGender, intAge, intWeight, strCCType, strCCNum, chbAthPer.IsChecked.Value, chbOverHealth.IsChecked.Value, chbST.IsChecked.Value, chbWeightLoss.IsChecked.Value, chbWeightMgmt.IsChecked.Value);
            //alternative way to call new member incase it doesn't work ^^

            //call new member to write into json
            MembersInformation MemberNew = new MembersInformation(strMemType, strFirstName.ToUpper(), strLastName.ToUpper(),datStartDate.ToShortDateString(), datEndDate.ToShortDateString(), dblSubTotal, addfeat_tr, addfeat_lr, dblTotal, strPhone, strEmail.ToUpper(), strGender, intAge, intWeight, strCCType, strCCNum, chbAthPer.IsChecked.Value, chbOverHealth.IsChecked.Value, chbST.IsChecked.Value, chbWeightLoss.IsChecked.Value, chbWeightMgmt.IsChecked.Value);

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
            MessageBox.Show("Customer Added!" + Environment.NewLine + MemberNew.ToString());

        }
      

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            //Clearing all input in the form 
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtCredCardNum.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtWeight.Text = "";
            txtAge.Text = "";
            chbAthPer.IsChecked = false;
            chbOverHealth.IsChecked = false;
            chbST.IsChecked = false;
            chbWeightLoss.IsChecked = false;
            chbWeightMgmt.IsChecked = false;
            rdbMale.IsChecked = false;
            rdbFemale.IsChecked = false;
            rdbMale.IsChecked = false;
        }
    }
}