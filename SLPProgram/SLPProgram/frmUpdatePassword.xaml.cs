using DataObjects;
using LogicLayer;
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

namespace SLPProgram
{
    /// <summary>
    /// Interaction logic for frmUpdatePassword.xaml
    /// </summary>
    public partial class frmUpdatePassword : Window
    {
        private SLPUser _slpUser;
        private ManagerUser _managerUser;
        private TeacherUser _teacherUser;
        private userManager _userManager;
        private bool _newUser;
        public frmUpdatePassword(SLPUser slpUser, userManager userManager, TeacherUser teacherUser, ManagerUser managerUser, bool newUser = false)
        {
            this._managerUser = managerUser;
            this._userManager = userManager;
            this._teacherUser = teacherUser;
            this._slpUser = slpUser;
            this._newUser = newUser;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (_newUser && _slpUser != null)
            {
                tbkMessage.Text = _slpUser.FirstName + " as a new user, please " + tbkMessage.Text;
            }
            else if (_newUser && _teacherUser != null)
            {
                tbkMessage.Text = _teacherUser.FirstName + " as a new user, please " + tbkMessage.Text;
            }
            else if (_newUser && _managerUser != null)
            {
                tbkMessage.Text = _managerUser.FirstName + " as a new user, please " + tbkMessage.Text;
            }
            else
            {
                tbkMessage.Text = "You can use this dialog to " + tbkMessage.Text;
            }
            txtEmail.Focus();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmail.Text.Length < 7 || txtEmail.Text.Length > 250)
            {
                MessageBox.Show("The email you submitted was invalid. Please try again.");
                txtEmail.Focus();
                txtEmail.SelectAll();
                return;
            }

            if (pwdOldPassword.Password.Length < 6)
            {
                MessageBox.Show("The old password you submitted was invalid. Please try again.");
                pwdOldPassword.Focus();
                pwdOldPassword.SelectAll();
                return;
            }

            if (pwdNewPassword.Password.Length < 6)
            {
                MessageBox.Show("The new password you submitted was invalid. Please try again.");
                pwdNewPassword.Focus();
                pwdNewPassword.SelectAll();
                return;
            }

            if (string.Compare(pwdNewPassword.Password.ToString(), pwdRetypePassword.Password.ToString()) != 0)
            {
                MessageBox.Show("New Password and Retyped Password must match. Please try again.");
                pwdRetypePassword.Password = " ";
                pwdNewPassword.Focus();
                pwdNewPassword.SelectAll();
                return;
            }

            string oldPassword = pwdOldPassword.Password;
            string newPassword = pwdNewPassword.Password;
            string username = txtEmail.Text;
            try
            {
                if (_userManager.UpdatePasswordSLP(username, oldPassword, newPassword))
                {
                    MessageBox.Show("Password Updated.");
                    _userManager.RefreshSLPUsers(_slpUser, username);
                    this.DialogResult = true;
                }
                else if (_userManager.UpdatePasswordTeacher(username, oldPassword, newPassword))
                {
                    MessageBox.Show("Password Updated.");
                    _userManager.RefreshTeacherUsers(_teacherUser, username);
                    this.DialogResult = true;
                }
                else if (_userManager.UpdatePasswordManager(username, oldPassword, newPassword))
                {
                    MessageBox.Show("Password Updated.");
                    _userManager.RefreshManagerUsers(_managerUser, username);
                    this.DialogResult = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
