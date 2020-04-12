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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("LoginPage.xaml", UriKind.Relative));
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("RegisterPage.xaml", UriKind.Relative));
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("BrowsePage.xaml", UriKind.Relative));

        }

        private void Layout_Loaded(object sender, RoutedEventArgs e)
        {
            this.NavigationService.RemoveBackEntry();
            if (Application.Current.Properties["User_ID"] != null)
            {
                if (Application.Current.Properties["User_Type"].ToString() == "Administrator")
                {
                    btnProfile.Visibility = Visibility.Collapsed;
                }
                btnlogout.Visibility = Visibility.Visible;
                btnLogin.Visibility = Visibility.Collapsed;
                btnRegister.Visibility = Visibility.Collapsed;
                btnhome.Visibility = Visibility.Visible;
                lblname.Content = "Welcome " + Application.Current.Properties["User_Name"];
                this.NavigationService.RemoveBackEntry();
                
            }
            else
            {
                btnlogout.Visibility = Visibility.Collapsed;
                btnProfile.Visibility = Visibility.Collapsed;
                btnhome.Visibility = Visibility.Collapsed;
            }
        }



        private void btnSearch1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtSearch.Text.Length > 0)
                {
                    var SearchName = (txtSearch.Text);
                    var DocumentDetailsBLLObj = new Document_DetailsBLL();
                    var DocumentDetailsList = DocumentDetailsBLLObj.SearchByDocumentName(SearchName);
                    if (DocumentDetailsList != null)
                    {
                         this.NavigationService.Navigate(new SearchResultsPage() { Name = SearchName });
                    }
                    else
                    {
                        MessageBox.Show("Enter Proper Document Name");
                    }
                }
                else
                    MessageBox.Show("Enter a Document Name to Search");
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

        private void btnlogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Properties["User_Type"] = null;
            Application.Current.Properties["User_ID"] = null;
            Application.Current.Properties["User_Name"] = null;
            this.NavigationService.Navigate(new Uri("LoginPage.xaml", UriKind.Relative));
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("EditProfile.xaml",UriKind.Relative));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
               
        }

        private void btnhome_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("HomePage.xaml", UriKind.Relative));
        }
        }
}
