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
    /// Interaction logic for SearchResultsPage.xaml
    /// </summary>
    public partial class SearchResultsPage : Page
    {
        public SearchResultsPage()
        {
            InitializeComponent();
            
        }
        
        private void Layout_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var obj = grdSearchResult.SelectedItem as Document_Details;

            if (this.grdSearchResult.SelectedItems.Count > 0)
            {
                this.NavigationService.Navigate(new DocumentDetails() { SelectedDocumentId = obj.DocumentId });
                
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Properties["User_ID"] != null)
            {
                if (Application.Current.Properties["User_Type"].ToString() == "Administrator")
                {
                    btnProfile.Visibility = Visibility.Collapsed;
                }
                btnlogout.Visibility = Visibility.Visible;
                lblname.Content = "Welcome " + Application.Current.Properties["User_Name"];
            }
            else
            {
                btnlogout.Visibility = Visibility.Collapsed;
                btnProfile.Visibility = Visibility.Collapsed;
            }
            try
            {
                var searchname = Name;
                var DocumentDetailsBLLObj = new Document_DetailsBLL();
                var DocumentsList = DocumentDetailsBLLObj.SearchByDocumentName(searchname);
               
                    grdSearchResult.ItemsSource = DocumentsList;
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
            this.NavigationService.Navigate(new Uri("EditProfile.xaml", UriKind.Relative));
        }

        private void btnhome_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("HomePage.xaml", UriKind.Relative));
        }
    }
}
