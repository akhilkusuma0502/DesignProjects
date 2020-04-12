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
using System.Windows.Shapes;

namespace Elib_Management_System_Presentation_Layer
{
    /// <summary>
    /// Interaction logic for Download.xaml
    /// </summary>
    using ElibManagementSystem_BusinessLogicLayer;
    using ElibManagementSystem_Entities;
    using ElibManagementSystem_Exceptions;
    using Microsoft.Win32;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Interaction logic for Download.xaml
    /// </summary>
    public partial class Download : Window
    {
        Document_Details DetailsObj = new Document_Details();

        public Download(Document_Details Obj,decimal discount)
        {
            InitializeComponent();
            DetailsObj = Obj;
            lbldocnameval.Content = DetailsObj.DocumentName;
            lbldocpriceval.Content = "Rs. "+((double)DetailsObj.Price) + "/- INR";
            lbltotalpriceval.Content = "Rs "+(Convert.ToDouble(DetailsObj.Price - (discount * DetailsObj.Price)))+"/- INR";
        }

        private bool ValidateCard()
        {
            var IsValid = true;
            var ErrorMessages = new StringBuilder();
            var RegExObj = new Regex("^[0-9]{15}$");
            var RegexCVV = new Regex("^[0-9]{3}");
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                IsValid = false;
            }
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                IsValid = false;
            }
            if (string.IsNullOrEmpty(txtCreditCardNumber.Text) || !RegExObj.IsMatch(txtCreditCardNumber.Text))
            {
                IsValid = false;
            }
            if (cmbExpirationDate.SelectedValue == null)
            {
                IsValid = false;
            }
            if (cmbExpirationDate1.SelectedValue == null)
            {
                IsValid = false;
            }
            if (string.IsNullOrEmpty(txtCode.Text) || !RegexCVV.IsMatch(txtCode.Text))
            {
                IsValid = false;
            }
            if (((rbtn.IsChecked == false) && (rbtn2.IsChecked == false) && (rbtn3.IsChecked == false) && (rbtn4.IsChecked == false)))
            {
                IsValid = false;
            }
            return IsValid;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (ValidateCard())
                {
                    var dialog = new SaveFileDialog();

                    dialog.Filter = "PDF Files (*.pdf)|*.pdf";
                    dialog.DefaultExt = "pdf";
                    dialog.AddExtension = true;
                    if (dialog.ShowDialog().GetValueOrDefault() == true)
                    {
                        using (var fs = new System.IO.FileStream(DetailsObj.DocumentPath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
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
                            }
                        }
                        MessageBox.Show("File Downloaded SuccessFully!");
                    }
                 }
                else
                {
                    MessageBox.Show("Enter Your Credit Card Details!!!");
                }
            }
            catch (ELibException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
