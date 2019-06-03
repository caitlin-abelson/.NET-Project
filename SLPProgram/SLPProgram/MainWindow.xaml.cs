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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SLPProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SLPUser _slpUser;
        private ManagerUser _managerUser;
        private TeacherUser _teacherUser;
        private IEPdetails _iep;
        private userManager _userManager = new userManager();
        private StudentManager _studentManager = new StudentManager();
        private List<Students> _students;
        private List<Students> _currentStudents;
        private Students _studentsInfo;
        private Students _studentsInformation;

        private bool dataUpdateFlag = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void resetWindow()
        {
            _slpUser = null;
            _managerUser = null;
            _teacherUser = null;
            _currentStudents = null;
            btnLogin.Content = "Log in";
            txtUsername.Visibility = Visibility.Visible;
            pwdPassword.Visibility = Visibility.Visible;
            cbxUserType.Visibility = Visibility.Visible;
            txtUsername.Text = "Email Address";
            pwdPassword.Password = "Password";
            Message.Content = "Welcome";
            Alert.Content = "You must log in to view students";
            cbxUserType.SelectedItem = "Show All";
            txtUsername.Focus();
            txtUsername.SelectAll();
            tabStudents.Visibility = Visibility.Collapsed;
            tabMyStudents.Visibility = Visibility.Collapsed;
            tabManageStudents.Visibility = Visibility.Collapsed;
            dgStudents.Visibility = Visibility.Collapsed;
            dgManageStudents.Visibility = Visibility.Collapsed;
            dgTeachersStudents.Visibility = Visibility.Collapsed;
            hideTabs();
            btnFilter.Visibility = Visibility.Hidden;
            cbxSchool.Visibility = Visibility.Hidden;
            lblSchoolName.Visibility = Visibility.Hidden;
            
        }

        private void hideTabs()
        {
            

            foreach (var item in tabsetMain.Items)
            {
                ((TabItem)item).Visibility = Visibility.Hidden;
            }
        }

        private void setupWindow()
        {
            btnLogin.Content = "Log out";
            txtUsername.Visibility = Visibility.Hidden;
            pwdPassword.Visibility = Visibility.Hidden;
            cbxUserType.Visibility = Visibility.Hidden;
            tabStudents.Visibility = Visibility.Visible;
            dgStudents.Visibility = Visibility.Visible;

            if (cbxManagerUser.IsSelected == true)
            {
                // These are the conditions for the buttons and tabs for a Manager

                string name = _managerUser.FirstName + " " + _managerUser.LastName;
                Message.Content = name;
                Alert.Content = "You are logged in as a Manager";
                dgManageStudents.Visibility = Visibility.Visible;
                tabManageStudents.Visibility = Visibility.Visible;
                btnSelect.Visibility = Visibility.Visible;
                cbxSchool.Visibility = Visibility.Visible;
                btnFilter.Visibility = Visibility.Visible;
                lblSchoolName.Visibility = Visibility.Visible;
            }
            else if(cbxSLPUser.IsSelected == true)
            {
                // These are the conditions for the buttons for an SLP
                
                string name = _slpUser.FirstName + " " + _slpUser.LastName;
                Message.Content = name;
                Alert.Content = "You are logged in as an SLP";
                btnSelect.Visibility = Visibility.Visible;
                cbxSchool.Visibility = Visibility.Visible;
                btnFilter.Visibility = Visibility.Visible;
                lblSchoolName.Visibility = Visibility.Visible;
                btnCreate.Visibility = Visibility.Visible;
            }
            else if(cbxTeacherUser.IsSelected == true)
            {
                // These are the conditions for the buttons for a Teacher

                string name = _teacherUser.FirstName + " " + _teacherUser.LastName;
                Message.Content = name;
                Alert.Content = "You are logged in as a Teacher";
                btnSelect.Visibility = Visibility.Visible;
                dgTeachersStudents.Visibility = Visibility.Visible;
            }

            showTabs();
        }

        private void showTabs()
        {
            if(cbxSLPUser.IsSelected == true)
            {
                tabStudents.Visibility = Visibility.Visible;
                tabManageStudents.Visibility = Visibility.Hidden;
                tabMyStudents.Visibility = Visibility.Hidden;
                tabStudents.IsSelected = true;
            }
            else if(cbxTeacherUser.IsSelected == true)
            {
                tabMyStudents.Visibility = Visibility.Visible;
                tabStudents.Visibility = Visibility.Hidden;
                tabManageStudents.Visibility = Visibility.Hidden;
                tabMyStudents.IsSelected = true;
            }
            else if(cbxManagerUser.IsSelected == true)
            {
                tabManageStudents.Visibility = Visibility.Visible;
                tabMyStudents.Visibility = Visibility.Hidden;
                tabStudents.Visibility = Visibility.Hidden;
                tabManageStudents.IsSelected = true;
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // The button to login for the various users.



            // This checks to see if any of the users are null
            // If they are not null, then the window is reset
            if(this._slpUser != null)
            {
                resetWindow();
                return;
            }
            if (this._teacherUser != null)
            {
                resetWindow();
                return;
            }
            if (this._managerUser != null)
            {
                resetWindow();
                return;
            }


            // Checking to see if the users are new users when they first log in
            try
            {
                string username = txtUsername.Text;
                string password = pwdPassword.Password;
                bool isNewUser = pwdPassword.Password == "newuser";

                if (username.Length < 7 || username.Length > 255)
                {
                    MessageBox.Show("Your Username must the right length of characters. " +
                        "Please try again.");
                    txtUsername.Focus();
                    return;
                }
                if(password.Length < 6)
                {
                    MessageBox.Show("Your password must be longer than 6 characters." +
                        "Please try again.");
                    pwdPassword.Focus();
                    return;
                }

                if(cbxSLPUser.IsSelected == true)
                {
                    _slpUser = _userManager.AuthenticateSLP(username, password);
                }
                else if(cbxTeacherUser.IsSelected == true)
                {
                    _teacherUser = _userManager.AuthenticateTeacher(username, password);
                }
                else if(cbxManagerUser.IsSelected == true)
                {
                    _managerUser = _userManager.AuthenticateManager(username, password);
                }
                else if(cbxUserSelect.IsSelected == true)
                {
                    MessageBox.Show("You must select a user. Please select one and try logging in again.");
                }
                
                if(_slpUser != null)
                {
                    MessageBox.Show("Welcome back, " + _slpUser.FirstName + ", authentication successful.");

                    if(isNewUser)
                    {
                        this.Alert.Content = _slpUser.FirstName + ", this is your first login. You must change your password.";

                        var frmPassword = new frmUpdatePassword(_slpUser, _userManager, _teacherUser, _managerUser, true);
                        if (frmPassword.ShowDialog() == true)
                        {
                            MessageBox.Show("Password successful.");
                        }
                    }
                    setupWindow();
                    return;
                }
                else if (_teacherUser != null)
                {
                    if (_teacherUser != null)
                    {
                        MessageBox.Show("Welcome back, " + _teacherUser.FirstName + ", authentication successful.");

                        if (isNewUser)
                        {
                            this.Alert.Content = _teacherUser.FirstName + ", this is your first login. You must change your password.";

                            var frmPassword = new frmUpdatePassword(_slpUser, _userManager, _teacherUser, _managerUser, true);
                            if (frmPassword.ShowDialog() == true)
                            {
                                MessageBox.Show("Password successful.");
                            }
                        }
                        setupWindow();
                        return;
                    }
                }
                else if (_managerUser != null)
                {
                    if (_managerUser != null)
                    {
                        MessageBox.Show("Welcome back, " + _managerUser.FirstName + ", authentication successful.");

                        if (isNewUser)
                        {
                            this.Alert.Content = _managerUser.FirstName + ", this is your first login. You must change your password.";

                            var frmPassword = new frmUpdatePassword(_slpUser, _userManager, _teacherUser, _managerUser, true);
                            if (frmPassword.ShowDialog() == true)
                            {
                                MessageBox.Show("Password successful.");
                            }
                        }
                        setupWindow();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Your username or password were incorrect. Please try again.");
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\n" + ex.InnerException.Message);
            }
        }

        private void txtUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            txtUsername.SelectAll();
        }

        private void pwdPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            pwdPassword.SelectAll();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hideTabs();
            txtUsername.Focus();
            btnCreate.Visibility = Visibility.Hidden;
            btnFilter.Visibility = Visibility.Hidden;
            cbxSchool.Visibility = Visibility.Hidden;
            lblSchoolName.Visibility = Visibility.Hidden;
            btnSelect.Visibility = Visibility.Hidden;
            tabStudents.Visibility = Visibility.Collapsed;
            dgStudents.Visibility = Visibility.Collapsed;
        }

        // this entire method is hiding columns that don't need to be seen by the user
        // but are a part of the student object
        private void dgStudents_AutoColumns(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(DateTime))
            {
                (e.Column as DataGridTextColumn).Binding.StringFormat = "MM/dd/yy";
            }

            string headername = e.Column.Header.ToString();

            if (headername == "NCESId")
            {
                e.Cancel = true;
            }
            if (headername == "IEPType")
            {
                e.Cancel = true;
            }
            if (headername == "IEPdate")
            {
                e.Cancel = true;
            }
            if (headername == "IEPLeaderFirstName")
            {
                e.Cancel = true;
            }
            if (headername == "IEPLeaderLastName")
            {
                e.Cancel = true;
            }
            if (headername == "IEPNotes")
            {
                e.Cancel = true;
            }
            if (headername == "GoalType")
            {
                e.Cancel = true;
            }
            if (headername == "TeacherID")
            {
                e.Cancel = true;
            }
            if (headername == "TeacherName")
            {
                e.Cancel = true;
            }


            if (headername == "StudentId")
            {
                e.Column.Header = "StudentId";
            }
            else if (headername == "SchoolName")
            {
                e.Column.Header = "School Name";
            }
            else if (headername == "Birthday")
            {
                e.Column.Header = "Date of Birth";
            }
            else if (headername == "Grade")
            {
                e.Column.Header = "Grade";
            }
            else if (headername == "FirstName")
            {
                e.Column.Header = "First Name";
            }
            else if (headername == "LastName")
            {
                e.Column.Header = "Last Name";
            }
            else if (headername == "Address")
            {
                e.Column.Header = "Address";
            }
            else if (headername == "City")
            {
                e.Column.Header = "City";
            }
            else if (headername == "State")
            {
                e.Column.Header = "State";
            }
            else if (headername == "ZipCode")
            {
                e.Column.Header = "Zip Code";
            }
            else if (headername == "Active")
            {
                e.Column.Header = "Active";
            }
        }



        /*
         * SLP functions and tabs ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
         * 
         */
        private void tabStudents_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                // this is the tab for when the SLP is logged in and wants to
                // see their current student roster
                _students = _studentManager.GetStudentsBySlpId(_slpUser.SLPID);
                if (_currentStudents == null)
                {
                    _currentStudents = _students;
                    dataUpdateFlag = false;
                }

                dgStudents.ItemsSource = _currentStudents;

                if (cbxSchool.Items.Count == 0)
                {
                    cbxSchool.Items.Add("Show All");
                    var schools = _studentManager.RetrieveSchools();
                    foreach (var school in schools)
                    {
                        cbxSchool.Items.Add(school);
                    }
                    cbxSchool.SelectedItem = "Show All";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            // selecting a student as an SLP
            var iep = (Students)dgStudents.SelectedItem;

            var details = new NewStudent(iep);

            var result = details.ShowDialog();

            if (result == true)
            {

                // refreshs the view of the students once one has been edited
                _currentStudents = null;
                _students = _studentManager.GetStudentsBySlpId(_slpUser.SLPID);
                if (_currentStudents == null)
                {
                    _currentStudents = _students;
                }

                dgStudents.ItemsSource = _currentStudents;
            }
            else
            {
                MessageBox.Show(result.ToString());
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            // only an SLP can create a student and add then to their roster
            var create = new NewStudent(_slpUser);

            var newStudent = create.ShowDialog();

            if (newStudent == true)
            {
                try
                {
                    _currentStudents = null;

                    _students = _studentManager.GetStudentsBySlpId(_slpUser.SLPID);

                    if (_currentStudents == null)
                    {
                        _students = _studentManager.GetStudentsBySlpId(_slpUser.SLPID);
                        _currentStudents = _students;
                    }

                    dgStudents.ItemsSource = _currentStudents;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DgStudents_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_currentStudents == null)
                {
                    _currentStudents = _students;
                }
                dgStudents.ItemsSource = _currentStudents;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BtnFilter_Click(object sender, RoutedEventArgs e)
        {
            // you can filter the students by the school that they attend
            // this can only be done by an SLP or a manager because they have students
            // at multiple schools
            try
            {
                if (cbxSchool.SelectedItem.ToString() != "Show All")
                {
                    _currentStudents = _currentStudents.FindAll(s => s.SchoolName == cbxSchool.SelectedItem.ToString());
                }
                else
                {
                    _currentStudents = _students;
                }

                dgStudents.ItemsSource = _currentStudents;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DgStudents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // selecting a student as an SLP
            var iep = (Students)dgStudents.SelectedItem;

            var details = new NewStudent(iep);

            var result = details.ShowDialog();

            if (result == true)
            {

                // refreshs the view of the students once one has been edited
                _currentStudents = null;
                _students = _studentManager.GetStudentsBySlpId(_slpUser.SLPID);
                if (_currentStudents == null)
                {
                    _currentStudents = _students;
                }

                dgStudents.ItemsSource = _currentStudents;
            }
            else
            {
                MessageBox.Show(result.ToString());
            }
        }




        /*
         * Teacher functions and tabs ////////////////////////////////////////////////////////////////////////////////////////
         * 
         */
        private void BtnSelectStudent_Click(object sender, RoutedEventArgs e)
        {
            // selecting a student as a teacher

            var iep = (Students)dgTeachersStudents.SelectedItem;

            var details = new IEPdetails(iep);

            var result = details.ShowDialog();

            MessageBox.Show(result.ToString());
        }

        private void DgTeachersStudents_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_currentStudents == null)
                {
                    _currentStudents = _students;
                }
                dgTeachersStudents.ItemsSource = _currentStudents;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DgTeachersStudents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // selecting a student as a teacher with a double click

            var iep = (Students)dgTeachersStudents.SelectedItem;

            var details = new IEPdetails(iep);

            var result = details.ShowDialog();

            MessageBox.Show(result.ToString());
        }

        private void TabMyStudents_GotFocus(object sender, RoutedEventArgs e)
        {
            // this is refresh the student list and to call the logic layer to 
            // get the list to view in the first place

            try
            {
                // this is the tab for when the teacher is logged in and wants to
                // see their current students with an IEP
                _students = _studentManager.GetStudentByTeacherID(_teacherUser.TeacherID);
                if (_currentStudents == null)
                {
                    _currentStudents = _students;
                }

                dgTeachersStudents.ItemsSource = _currentStudents;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        /*
         * Manager functions and tabs //////////////////////////////////////////////////////////////////////////////////
         * 
         */

        private void BtnFilterSchools_Click(object sender, RoutedEventArgs e)
        {
            // filter for the manager

            // you can filter the students by the school that they attend
            // this can only be done by an SLP or a manager because they have students
            // at multiple schools
            try
            {
                if (cbxSchools.SelectedItem.ToString() != "Show All")
                {
                    _currentStudents = _currentStudents.FindAll(s => s.SchoolName == cbxSchools.SelectedItem.ToString());
                }
                else
                {
                    _currentStudents = _students;
                }

                dgManageStudents.ItemsSource = _currentStudents;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TabManageStudents_GotFocus(object sender, RoutedEventArgs e)
        {
            // this is refresh the student list and to call the logic layer to 
            // get the list to view in the first place

            try
            {
                // this is the tab for when the Manager is logged in and wants to
                // see their current student roster for the SLP
                _students = _studentManager.GetStudents();
                if (_currentStudents == null)
                {
                    _currentStudents = _students;
                    dataUpdateFlag = false;
                }

                dgManageStudents.ItemsSource = _currentStudents;

                if (cbxSchools.Items.Count == 0)
                {
                    cbxSchools.Items.Add("Show All");
                    var schools = _studentManager.RetrieveSchools();
                    foreach (var school in schools)
                    {
                        cbxSchools.Items.Add(school);
                    }
                    cbxSchools.SelectedItem = "Show All";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void DgManageStudents_GotFocus(object sender, RoutedEventArgs e)
        {

            try
            {
                if (_currentStudents == null)
                {
                    _currentStudents = _students;
                }
                dgManageStudents.ItemsSource = _currentStudents;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DgManageStudents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // selecting a student as a manager with a double click

            var iep = (Students)dgManageStudents.SelectedItem;

            var details = new IEPDetailsManage(iep);

            var result = details.ShowDialog();

            if (result == true)
            {

                // refreshs the view of the students once one has been deleted
                _currentStudents = null;
                _students = _studentManager.GetStudents();
                if (_currentStudents == null)
                {
                    _currentStudents = _students;
                }

                dgManageStudents.ItemsSource = _currentStudents;
            }
            else
            {
                MessageBox.Show(result.ToString());
            }
        }

        private void BtnManageSelect_Click(object sender, RoutedEventArgs e)
        {
            // selecting a student as a manager with the select button

            var iep = (Students)dgManageStudents.SelectedItem;

            var details = new IEPDetailsManage(iep);

            var result = details.ShowDialog();

            MessageBox.Show(result.ToString());
        }
    }
}
