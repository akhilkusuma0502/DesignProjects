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

namespace ElibManagementSystem_PresentationLayer
{
    using ElibManagementSystem_BusinessLogicLayer;
    using ElibManagementSystem_Entities;
    using ElibManagementSystem_Exceptions;
    using System.Text.RegularExpressions;
    /// <summary>
    /// Interaction logic for PaymentWindow.xaml
    /// </summary>
    public partial class PaymentWindow : Window
    {
        User_details Obj = new User_details();
        
        public PaymentWindow(User_details obj)
        {
            InitializeComponent();
            Obj = obj;
            
        }
        public PaymentWindow()
        {
            InitializeComponent();
        }
        //VALIDATIONS FOR CREDITCARD
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
        
        private void btnSubmit_Click_1(object sender, RoutedEventArgs e)
        {

            var IsAdded = false;
            try
            {
                var subscriberBll = new User_detailsBLL();
                if (ValidateCard())
                {
                    IsAdded = subscriberBll.Register(Obj);
                    if (IsAdded)
                    {
                        MessageBox.Show("Thankyou Subscribing!You are a Subsciber");
                    }
                    else
                    {
                        MessageBox.Show("Sorry,Subscription Failed");

                    }
                }
                else
                {
                    Obj.UserType = "Non_subscriber";
                    IsAdded = subscriberBll.Register(Obj);
                    if (IsAdded)
                    {
                        MessageBox.Show("You are a Non Subsciber");
                        
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Sorry,Subscription Failed");

                    }
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
