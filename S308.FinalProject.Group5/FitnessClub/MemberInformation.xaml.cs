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

        List<MemberInformation> membersIndex;
        public MemberInformation()
        {
            InitializeComponent();


            //load members list from json file
            membersIndex = ImportMemberData();
        }

        public List<MemberInformation> ImportMemberData()
        {
            List<MemberInformation> memberList = new List<MemberInformation>();

            string strFilePath = @"..\..\..\Data\MembersInformation.json";

            try
            {
                //use System.IO.File to read the entire data file
                string jsonData = File.ReadAllText(strFilePath);

                //Not sure why this is throwing an error. 
                //serialize the json data to a list of campuses
                memberList = JsonConvert.DeserializeObject<List<MemberInformation>>(jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading Pokemon from file: " + ex.Message);
            }

            return memberList;


        }



        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            //    List<MemberInformation> membersSearch;

            //    string strLastName = txtLastNameInput.Text.Trim();

            //    string strEmail= txtEmailInput.Text.Trim();

            //    string strPhoneNumber = txtPhoneNumberInput.Text.Trim();

            //    //Start of query, not finished yet. 
            //    membersSearch = membersIndex.Where


            //    //set the source of the datagrid and refresh
            //    //dtgMember.ItemsSource = membersSearch;
            //    //dtgMember.Items.Refresh();

            //    //instantiate a new Campus from the input and add it to the list
            //    MembersInformation campusNew = new MembersInformation(txtName.Text.Trim(), enrollment);
            //    memberList.Add(MemberNew);

            //    try
            //    {
            //        //serialize the new list of campuses to json format
            //        string jsonData = JsonConvert.SerializeObject(memberList);

            //        //use System.IO.File to write over the file with the json data
            //        System.IO.File.WriteAllText(strFilePath, jsonData);

            //        MessageBox.Show(memberList.Count + " Cusomters have been exported.");
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Error in export process: " + ex.Message);
            //    }

            //    MessageBox.Show("Campus Added!" + Environment.NewLine + MemberNew.ToString());


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
            //txtPhoneNumberInput = "";
        }
    }
}