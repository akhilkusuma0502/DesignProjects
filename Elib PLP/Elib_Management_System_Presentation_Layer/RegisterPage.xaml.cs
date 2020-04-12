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
//vj
namespace ElibManagementSystem_PresentationLayer
{
    using ElibManagementSystem_BusinessLogicLayer;
    using ElibManagementSystem_Entities;
    using ElibManagementSystem_Exceptions;
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }


        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User_details userObj = new User_details();
                userObj.UserId = txtUserId.Text;
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


                userObj.DateOfRegistration = Convert.ToDateTime(dtpDateOfRegistration.Text);
                userObj.Password = txtPassword.Password;

                //if Subscriber redirect to payment Window
                if (userObj.UserType == "Subscriber")
                {
                    var PaymentObj = new PaymentWindow(userObj);

                    PaymentObj.Show();
                  //  PaymentObj.Close();
                     
                  //  if(PaymentObj.DialogResult.Value==)
                    this.NavigationService.Navigate(new Uri("HomePage.xaml", UriKind.Relative));
                }
                else
                {
                    var userBLL = new User_detailsBLL();
                    var IsAddedUser = userBLL.Register(userObj);
                    if (IsAddedUser)
                    {
                        MessageBox.Show("Registration Successful as "+ userObj.UserType+"!!..Access Granted To documents!" );
                    }
                    else
                    {
                        MessageBox.Show("Sorry!!!..Registration Failed.Try Again Later");
                    }
                }

            }
            catch (ELibException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }
        }

        
    }
}
