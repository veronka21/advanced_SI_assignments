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
using System.Text.RegularExpressions;

namespace RegexInAction
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string phoneNumber = txtPhone.Text;
            string email = txtEmail.Text;
            bool successfulSave = true;
            if (!isValidName(name))
            {
                MessageBox.Show("The name is invalid (only alphabetical characters are allowed)");
                successfulSave = false;
            }
            if (!isValidPhoneNumber(phoneNumber))
            {
                MessageBox.Show("The given phone number is not valid (please enter a mobile number without spaces, e.g. 06201234567)");
                successfulSave = false;
            }
            if (!isValidEmailAddress(email))
            {
                MessageBox.Show("The given email address is not valid (please enter a valid format, e.g. example@xyz.com)");
                successfulSave = false;
            }
            if (successfulSave)
            {
                MessageBox.Show("Your data was successfully saved!");
            }
        }

        private bool isValidName(string name)
        {
            string nameRegex = "^[A-Za-z]+\\s[A-Za-z]+\\s*[A-Za-z]*$";
            bool isValid = Regex.IsMatch(name, nameRegex);
            return isValid;   
        }

        private bool isValidPhoneNumber(string phoneNumber)
        {
            string phoneRegex = "^06\\d{9}$";
            bool isValid = Regex.IsMatch(phoneNumber, phoneRegex);
            return isValid;
        }

        private bool isValidEmailAddress(string email)
        {
            string emailRegex = "^[A-Za-z\\d]+@[A-Za-z\\d]+[.][A-Za-z]{2,3}$";
            bool isValid = Regex.IsMatch(email, emailRegex);
            return isValid;
        }
    }
}
