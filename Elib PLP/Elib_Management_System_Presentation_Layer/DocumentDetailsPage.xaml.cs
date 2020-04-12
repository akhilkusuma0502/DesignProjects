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
    using Microsoft.Win32;

    /// <summary>
    /// Interaction logic for DocumentDetails.xaml
    /// </summary>
    public partial class DocumentDetails : Page
    {
        public int SelectedDocumentId { get; set; }
        string type;
        bool saved;
        public DocumentDetails()
        {
            InitializeComponent();
        }
        
        
        private void Layout_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnDownload_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var document = grdDocumentDetails.SelectedItem as Document_Details;
                if (document == null)
                {
                    MessageBox.Show("Please Select the document to download");

                }
                else
                {
                    if (Application.Current.Properties["User_ID"] != null)
                    {
                        type = Application.Current.Properties["User_Type"].ToString();
                        if (document.DocumentTypeId.DocumentTypeId == 1)
                        {
                            if (type == "Subscriber")
                            {
                                Elib_Management_System_Presentation_Layer.Download Obj = new Elib_Management_System_Presentation_Layer.Download(document, 0.20m);
                                Obj.Show();

                            }
                            else if (type == "Non_Subscriber")
                            {
                                Elib_Management_System_Presentation_Layer.Download Obj = new Elib_Management_System_Presentation_Layer.Download(document, 0.0m);
                                Obj.Show();
                            }
                            else
                                freebie(document);
                        }
                        else
                            saved = freebie(document);
                        if (saved)
                            MessageBox.Show("Thank You For Downloading!!Please Visit Again");
                    }
                    else if (document.DocumentTypeId.DocumentTypeId == 2)
                    {
                        saved = freebie(document);
                        if (saved)
                            MessageBox.Show("Thank You For Downloading!!Please Visit Again");
                    }
                    else
                        MessageBox.Show("Sorry!!Please LogIn To Download Premium Documents.");
                }
            }
            catch (ELibException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
            
        public bool freebie(Document_Details document)
        {
            {
                var dialog = new SaveFileDialog();
                dialog.Filter = "PDF Files|*.pdf";
                dialog.AddExtension = true;
                if (dialog.ShowDialog().GetValueOrDefault() == true)
                {
                    using (var fs = new System.IO.FileStream(document.DocumentPath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    {
                        using (var sr = new System.IO.BinaryReader(fs))
                        {

                            var fs1 = new System.IO.FileStream(dialog.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                            var sw = new System.IO.BinaryWriter(fs1);

                            sw.Write(sr.ReadBytes((int)fs.Length - 1));

                            sw.Close();
                            fs1.Close();
                            sr.Close();
                            fs.Close();
                            return true;
                        }
                    }
                }
                else
                    return false;
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
                var DocumentDetailsBLLObj = new Document_DetailsBLL();
                var DocumentsList = DocumentDetailsBLLObj.SearchByDocumentId(SelectedDocumentId);
                grdDocumentDetails.ItemsSource = DocumentsList;
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
