//MSN Logo Source: https://www.apk4now.com/apk/1424/msn-health-amp-fitness-workouts
using System;
using System.Collections.Generic;
using System.IO;
//using Newtonsoft.Json;
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
    /// Interaction logic for MemberInformation.xaml
    /// </summary>
    public partial class MemberInformation : Window
    {

        //ist<MemberInformation> memberList;
        public MemberInformation()
        {
            InitializeComponent();
        }
        /*
            //instantiate a list to hold the members 
            memberList = new List<MembersInformation>();

            ImportMemberData();
        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu MainMenuWindow = new MainMenu();
            MainMenuWindow.Show();
            this.Close();
        }

        private void ImportMemberData()
        {
            string strFilePath = @"..\..\..\Data\MembersInformation.json";

            try
            {
                //use System.IO.File to read the entire data file
                string jsonData = File.ReadAllText(strFilePath);

                //serialize the json data to a list of campuses
                memberList = JsonConvert.DeserializeObject<List<MembersInformation>>(jsonData);

                if (memberList.Count >= 0)
                    MessageBox.Show(memberList.Count + " Campuses have been imported.");
                else
                    MessageBox.Show("No Campuses has been imported. Please check your file.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in import process: " + ex.Message);
            }

            //set the source of the datagrid and refresh
            dtgMember.ItemsSource = memberList;
            dtgMember.Items.Refresh();
        }
        private MembersInformation ConvertToNumber(string strLine)
        {
            //declare a string array to hold the data 
            string[] rawData;
            //split on the delimiter into the array
            rawData = strLine.Split(',');
            int Cost, SubTotal, TotalCost, PhoneNumber, Weight;



            //check the data to make sure it is valid and convert enrollment text to a number
            if (!Int32.TryParse(rawData[5].Trim(), out Cost))
            {
                MessageBox.Show("Data Error when converting " + strLine);
                return new MembersInformation();
            }
            if (!Int32.TryParse(rawData[6].Trim(), out SubTotal))
            {
                MessageBox.Show("Data Error when converting " + strLine);
                return new MembersInformation();
            }

            if (!Int32.TryParse(rawData[8].Trim(), out TotalCost))
            {
                MessageBox.Show("Data Error when converting " + strLine);
                return new MembersInformation();
            }
            if (!Int32.TryParse(rawData[10].Trim(), out PhoneNumber))
            {
                MessageBox.Show("Data Error when converting " + strLine);
                return new MembersInformation();
            }
            if (!Int32.TryParse(rawData[10].Trim(), out Weight))
            {
                MessageBox.Show("Data Error when converting " + strLine);
                return new MembersInformation();
            }
            //create a campus from the data
            MembersInformation MemberNew = new MembersInformation(rawData[0], rawData[1], rawData[2], rawData[3], rawData[4], Cost, SubTotal, rawData[7], TotalCost, rawData[9], PhoneNumber, rawData[11], rawData[12], Weight);
            return MemberNew;
        }


        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string strFilePath = @"..\..\..\Data\MembersInformation.txt";
            int Cost, SubTotal, TotalCost, PhoneNumber, Weight;

            //validate the input
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("You must provide a name.");
                return;
            }

            if (!Int32.TryParse(txtEnrollment.Text.Trim(), out enrollment))
            {
                MessageBox.Show("You must provide a number for Enrollment.");
                return;
            }

            //instantiate a new Campus from the input and add it to the list
            MembersInformation campusNew = new MembersInformation(txtName.Text.Trim(), enrollment);
            memberList.Add(MemberNew);

            try
            {
                //serialize the new list of campuses to json format
                string jsonData = JsonConvert.SerializeObject(memberList);

                //use System.IO.File to write over the file with the json data
                System.IO.File.WriteAllText(strFilePath, jsonData);

                MessageBox.Show(memberList.Count + " Cusomters have been exported.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in export process: " + ex.Message);
            }

            MessageBox.Show("Campus Added!" + Environment.NewLine + MemberNew.ToString());
        */
        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu MainMenuWindow = new MainMenu();
            MainMenuWindow.Show();
            this.Close();
        }
    }
}
