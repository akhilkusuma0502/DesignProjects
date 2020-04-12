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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Elib_Management_System_Presentation_Layer
{
    using ElibManagementSystem_BusinessLogicLayer;
    using ElibManagementSystem_Entities;
    using ElibManagementSystem_Exceptions;
    /// <summary>
    /// Interaction logic for EditProfile.xaml
    /// </summary>
    public partial class EditProfile : Page
    {
        User_details userObj = new User_details();
        public EditProfile()
        {
            InitializeComponent();
        }

        private void Layout_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }
        
        private void EditProfile_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Application.Current.Properties["User_ID"] != null)
                {
                    userObj.UserId = Application.Current.Properties["User_ID"].ToString();
                    var editObj = new User_detailsBLL();
                    var DetailsObj = editObj.FindbyID(userObj.UserId);
                    txtFirstName.Text = DetailsObj.FirstName;
                    txtLastName.Text = DetailsObj.LastName;
                    dtpDateOfBirth.SelectedDate = DetailsObj.DateOfBirth;
                    txtAddress.Text = DetailsObj.Address;
                    txtLandlineNumber.Text = DetailsObj.LandLineNumber;
                    txtMobileNumber.Text = DetailsObj.MobileNumber;
                    var a = DetailsObj.AreaOfInterest;
                    if (a.Contains("Engineering"))
                    {
                        chkEngineering.IsChecked = true;
                    }
                    if (a.Contains("Medical"))
                    {
                        chkMedical.IsChecked = true;
                    }
                    if (a.Contains("Law"))
                    {
                        chkLaw.IsChecked = true;
                    }

                    if (DetailsObj.Gender == "M")
                        rbtnMale.IsChecked = true;
                    else
                        rbtnFemale.IsChecked = true;
                    if (DetailsObj.UserType == "Subscriber")
                    {
                        rbtnSubscriber.IsChecked = true;
                    }
                    else
                    {
                        rbtnNonSubscriber.IsChecked = true;
                    }
                }
                else
                    this.NavigationService.Navigate(new Uri("HomePage.xaml", UriKind.Relative));

            }
            catch(ELibException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnupdate_Click_1(object sender, RoutedEventArgs e)
        {
            User_details userObj = new User_details();
            userObj.UserId = Application.Current.Properties["User_ID"].ToString();
            userObj.FirstName = txtFirstName.Text;
            userObj.LastName = txtLastName.Text;
            userObj.DateOfBirth = Convert.ToDateTime(dtpDateOfBirth.Text);
            userObj.Address = txtAddress.Text;
            userObj.LandLineNumber = txtLandlineNumber.Text;
            userObj.MobileNumber = txtMobileNumber.Text;
            string strCheckValue = "";
            if (chkEngineering.IsChecked == true)
            {
                strCheckValue = strCheckValue + "," + chkEngineering.Content;
            }
            if (chkMedical.IsChecked == true)
            {
                strCheckValue = strCheckValue + "," + chkMedical.Content;
            }
            if (chkLaw.IsChecked == true)
            {
                strCheckValue = strCheckValue + "," + chkLaw.Content;
            }
            userObj.AreaOfInterest = strCheckValue;

            if (rbtnMale.IsChecked == true)
            {
                userObj.Gender = "M";
            }
            else if (rbtnFemale.IsChecked == true)
            {
                userObj.Gender = "F";
            }

            if (rbtnSubscriber.IsChecked == true)
            {
                userObj.UserType = "Subscriber";
            }
            else if (rbtnNonSubscriber.IsChecked == true)
            {
                userObj.UserType = "Non_subscriber";


            }
            var userBLL = new User_detailsBLL();
            var IsAddedUser = userBLL.UpdateUserDetails(userObj);
            if (IsAddedUser)
            {
                Application.Current.Properties["User_Name"] = userObj.FirstName + " " + userObj.LastName;
                MessageBox.Show("Updated!!!! ");
            }
            else

            {
                MessageBox.Show("Sorry!!!..Updation Failed.Try Again Later");
            }
        }

        private void btnlogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Properties["User_Type"] = null;
            Application.Current.Properties["User_ID"] = null;
            Application.Current.Properties["User_Name"] = null;
            this.NavigationService.Navigate(new Uri("LoginPage.xaml", UriKind.Relative));
        }

        private void btnhome_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("HomePage.xaml", UriKind.Relative));
        }
    }
}
