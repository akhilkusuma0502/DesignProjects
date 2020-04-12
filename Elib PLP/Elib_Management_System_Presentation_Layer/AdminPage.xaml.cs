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
using Microsoft.Win32;
namespace ElibManagementSystem_PresentationLayer
{
    using ElibManagementSystem_BusinessLogicLayer;
    using ElibManagementSystem_Entities;
    using ElibManagementSystem_Exceptions; 
      
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {

        string path;
        FileDialog dialog1;
        public AdminPage()
        {
            InitializeComponent();
            var Obj = new DisciplinesBLL();
            cmbDisciplineName.ItemsSource = Obj.GetAll();
            cmbDisciplineIdUpdate.ItemsSource = Obj.GetAll();
            var Obj1 = new Document_Type_DetailsBLL();
            cmbDocumentTypeName.ItemsSource = Obj1.GetAll();
            cmbDocumentTypeIdUpdate.ItemsSource = Obj1.GetAll();
        }
        
        private void btnDocumentPathUpload_Click(object sender, RoutedEventArgs e)
        {
            if (txtDocumentNameUpload.Text.Length <= 0)
            {
                MessageBox.Show("Enter Document Name Before Uploading");
                return;
            }
            var dialog = new OpenFileDialog();
            dialog1 = dialog;
            if (dialog.ShowDialog().GetValueOrDefault() == true)
            {
                lblpath.Content = dialog.FileName;
            }
        }

        public void File(FileDialog dialog)
        {
            using (var fs = new System.IO.FileStream(dialog.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                using (var sr = new System.IO.BinaryReader(fs))
                {
                    var DocID = new DocumentDetails();
                    
                    var ext = System.IO.Path.GetExtension(dialog.FileName);
                    var savepath = "..\\..\\Documents\\" + txtDocumentNameUpload.Text+ext;
                    var fs1 = new System.IO.FileStream(savepath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                    var sw = new System.IO.BinaryWriter(fs1);

                    sw.Write(sr.ReadBytes((int)fs.Length - 1));

                    path = savepath;
                    sw.Close();
                    fs1.Close();
                    sr.Close();
                    fs.Close();
                    txtDocumentNameUpload.IsEnabled = false;
                }
            }
        }

        public void UpdateFile(FileDialog dialog)
        {
            using (var fs = new System.IO.FileStream(dialog.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                using (var sr = new System.IO.BinaryReader(fs))
                {
                    var DocID = new DocumentDetails();
                    
                    var ext = System.IO.Path.GetExtension(dialog.FileName);
                    var savepath = "..\\..\\Documents\\" + txtDocumentNameUpdate.Text+ext;
                    var fs1 = new System.IO.FileStream(savepath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                    var sw = new System.IO.BinaryWriter(fs1);

                    sw.Write(sr.ReadBytes((int)fs.Length - 1));

                    path = savepath;
                    sw.Close();
                    fs1.Close();
                    sr.Close();
                    fs.Close();
                    txtDocumentNameUpdate.IsEnabled = false;
                }
            }
        }

        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
               try
            {
            
                var dd = cmbDisciplineName.SelectedItem as Disciplines;
                Document_Details DocumentObj = new Document_Details();
                var dd1 = cmbDocumentTypeName.SelectedItem as Document_Type_Details;
                
                DocumentObj.DocumentName = txtDocumentNameUpload.Text;
                DocumentObj.DocumentDescription = txtDocumentDescriptionUpload.Text;
                DocumentObj.DocumentTypeId.DocumentTypeId = dd1.DocumentTypeId;
                DocumentObj.DisciplineId.DisciplineId = dd.DisciplineId;
                DocumentObj.Title = txtTitleUpload.Text;
                DocumentObj.Author = txtAuthorUpload.Text;
                DocumentObj.Price = Convert.ToDecimal(txtPriceUpload.Text);
                File(dialog1);
                DocumentObj.DocumentPath = path;
         
                var DocumentBLLObj = new Document_DetailsBLL();
                var IsAdded = DocumentBLLObj.UploadDocument(DocumentObj);
                if (IsAdded )
                {
                    MessageBox.Show("Document Details added");

                }
                else
                    MessageBox.Show("Document Details not added");
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
                MessageBox.Show("All Fields are Mandatory", "Error", MessageBoxButton.OK);
            }
            
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var dd = cmbDisciplineIdUpdate.SelectedItem as Disciplines;
                var DocumentBLLObj = new Document_DetailsBLL();
                var dd1 = cmbDocumentTypeIdUpdate.SelectedItem as Document_Type_Details;
                var Id = Convert.ToInt32(txtDocumentIDUpdate.Text);
                var DocumentObj = DocumentBLLObj.SearchByDocumentId(Id).First();
               
                txtDocumentIDUpdate.Visibility = Visibility.Hidden;
                txtDocumentNameUpdate.Text = DocumentObj.DocumentName;
                txtDocumentDescriptionUpdate.Text = DocumentObj.DocumentDescription;
               
                cmbDocumentTypeIdUpdate.Text = DocumentObj.DocumentTypeId.DocumentTypeName;
                cmbDisciplineIdUpdate.Text = DocumentObj.DisciplineId.DisciplineName;
                txtTitleUpdate.Text = DocumentObj.Title;
                txtAuthorUpdate.Text = DocumentObj.Author;
                dtpUploadDateUpdate.SelectedDate = DocumentObj.UploadDate;
                txtPriceUpdate.Text = Convert.ToString(DocumentObj.Price);
                lblpathUpdate.Content = DocumentObj.DocumentPath;

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

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dd = cmbDisciplineIdUpdate.SelectedItem as Disciplines;
                Document_Details DocumentObj = new Document_Details();
                var dd1 = cmbDocumentTypeIdUpdate.SelectedItem as Document_Type_Details;
                DocumentObj.DocumentId = Convert.ToInt32(txtDocumentIDUpdate.Text);
                DocumentObj.DocumentName = txtDocumentNameUpdate.Text;
                DocumentObj.DocumentDescription = txtDocumentDescriptionUpdate.Text;
                DocumentObj.DocumentTypeId.DocumentTypeId = dd1.DocumentTypeId;
                DocumentObj.DisciplineId.DisciplineId = dd.DisciplineId;
                DocumentObj.Title = txtTitleUpdate.Text;
                DocumentObj.Author = txtAuthorUpdate.Text;
                DocumentObj.Price = Convert.ToDecimal(txtPriceUpdate.Text);
                UpdateFile(dialog1);
                DocumentObj.DocumentPath = path;
                var DocumentBLLObj = new Document_DetailsBLL();
                var IsUpdated = DocumentBLLObj.UpdateDocument(DocumentObj);
                if (IsUpdated)
                {
                    MessageBox.Show("Document Details updated");

                }
                else
                    MessageBox.Show("Document Details not updated");
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

        private void btnDocumentPathUpdate_Click(object sender, RoutedEventArgs e)
        {

            if (txtDocumentNameUpdate.Text.Length <= 0)
            {
                MessageBox.Show("Enter Document Name Before Updating");
                return;
            }
            var dialog = new OpenFileDialog();
            dialog1 = dialog;
            if (dialog.ShowDialog().GetValueOrDefault() == true)
            {
                lblpathUpdate.Content = dialog.FileName;
            }
        }

        private void btnlogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Properties["User_Type"] = null;
            Application.Current.Properties["User_ID"] = null;
            Application.Current.Properties["User_Name"] = null;
            this.NavigationService.Navigate(new Uri("LoginPage.xaml", UriKind.Relative));
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Properties["User_ID"] != null)
            {
                this.NavigationService.RemoveBackEntry();
            }
        }

        private void Layout_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

    }
}
