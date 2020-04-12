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
    /// Interaction logic for BrowsePage.xaml
    /// </summary>
    public partial class BrowsePage : Page
    {
        int CurrentPage=0;
        int TotalPage=0;
        public BrowsePage()
        {
            InitializeComponent();
        }
        
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            var Obj = new DisciplinesBLL();
            lstbxBrowse.ItemsSource = Obj.GetAll();
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
                btnPreviousPage.Visibility = Visibility.Hidden;
                btnNextPage.Visibility = Visibility.Hidden;
            }
        }
        
        private void lstbxBrowse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TotalPage = grdBrowse.Items.Count / 10;
            CurrentPage = 1;
            btnPreviousPage.Visibility = Visibility.Visible;
            btnNextPage.Visibility = Visibility.Visible;
            display();
        }

        private void display()
        {
            
            var BrowseObj = new Document_DetailsBLL();

            var ListBrowseObj = lstbxBrowse.SelectedItem as Disciplines;
            try
            {
                grdBrowse.ItemsSource = BrowseObj.BrowseDocuments(ListBrowseObj.DisciplineId, CurrentPage);
            }
            catch (ELibException)
            {

                MessageBox.Show("Documents for " + ListBrowseObj.DisciplineName + " is not present");
            }
            catch (Exception)
            {

                MessageBox.Show("Please Select Discipline");
            }
        }
        
        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPage < TotalPage)
                CurrentPage++;
            display();
        }

        private void btnPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPage > 1)
                CurrentPage--;
            btnPreviousPage.IsEnabled = CurrentPage > 1;
            display();
        }

        private void grdBrowse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var obj = grdBrowse.SelectedItem as Document_Details;

            if (this.grdBrowse.SelectedItems.Count > 0)
            {
                grdBrowse.ItemsSource = null;
                this.NavigationService.Navigate(new DocumentDetails() { SelectedDocumentId = obj.DocumentId });
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

        private void Layout_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnhome_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("HomePage.xaml", UriKind.Relative));
        }
    }

}
