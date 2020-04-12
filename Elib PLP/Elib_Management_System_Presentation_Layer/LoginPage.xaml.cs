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

namespace ElibManagementSystem_PresentationLayer
{
    using ElibManagementSystem_BusinessLogicLayer;
    using ElibManagementSystem_Entities;
    using ElibManagementSystem_Exceptions;
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Layout_Loaded(object sender, RoutedEventArgs e)
        {
           
        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User_details userObj = new User_details();
                userObj.UserId = txtuserid.Text;
                userObj.Password = txtpassword.Password;
                var userBLL = new User_detailsBLL();
                var Obj = userBLL.LogIn(userObj);
                
                if (Obj.UserType == "Administrator")
                {
                    Application.Current.Properties["User_Type"] = Obj.UserType;
                    Application.Current.Properties["User_ID"] = userObj.UserId;
                    Application.Current.Properties["User_Name"] = Obj.FirstName + " " + Obj.LastName;
                    this.NavigationService.Navigate(new Uri("AdminPage.xaml", UriKind.Relative));
                    
                }
                else if (Obj.UserType == "Subscriber" || Obj.UserType == "Non_subscriber")
                {
                    Application.Current.Properties["User_Type"] = Obj.UserType;
                    Application.Current.Properties["User_ID"] = userObj.UserId;
                    Application.Current.Properties["User_Name"] = Obj.FirstName +" "+ Obj.LastName;
                    this.NavigationService.Navigate(new Uri("HomePage.xaml", UriKind.Relative));
                }
                else
                {
                    MessageBox.Show("Enter Proper Credentials");
                }
                
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
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

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            
            this.NavigationService.Navigate(new Uri("RegisterPage.xaml", UriKind.Relative));

        }
    }
}
