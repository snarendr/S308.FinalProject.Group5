//MSN Logo Source: https://www.apk4now.com/apk/1424/msn-health-amp-fitness-workouts
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
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
    public partial class MemberInformation : Window
    {
        //Creating variable to store the membership information json file
        string strFilePath = @"..\..\..\Data\MembersInformation.json";
        //Creat membership information list based on the membership information class
        List<MembersInformation> memberInformationList = new List<MembersInformation>();

        
        public MemberInformation()
        {
            InitializeComponent();

            
        }


        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                //use System.IO.File to read the entire data file
                string jsonData = File.ReadAllText(strFilePath);

                //Not sure why this is throwing an error. 
                //serialize the json data to a list of campuses
                memberInformationList = JsonConvert.DeserializeObject<List<MembersInformation>>(jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in import process: " + ex.Message);
            }

            //List<MemberInformation> memberInformationList;

            string strLastName = txtLastNameInput.Text.Trim();

            string strEmail = txtEmailInput.Text.Trim();

            string strPhoneNumber = txtPhoneNumberInput.Text.Trim();

            //Start of query, not finished yet. 
            var membersInformationQuery =
                from m in memberInformationList
                where (m.LastName) == strLastName
                select m;

            foreach (MembersInformation m in membersInformationQuery)
            {
                //set the source of the datagrid and refresh
                dtgMember.ItemsSource = memberInformationList;
                dtgMember.Items.Refresh();
            }
        }
        
        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu MainMenuWindow = new MainMenu();
            MainMenuWindow.Show();
            this.Close();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtLastNameInput.Text = "";
            txtEmailInput.Text = "";
            txtPhoneNumberInput.Text = "";
        }
    }
}
