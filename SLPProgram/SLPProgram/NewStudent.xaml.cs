using DataObjects;
using LogicLayer;
using System;
using System.Collections;
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
    /// Interaction logic for NewStudent.xaml
    /// </summary>
    public partial class NewStudent : Window
    {
        private List<States> states = new List<States>();
        StudentManager _studentManager = new StudentManager();
        userManager _userManager = new userManager();
        private List<Students> _students;
        Students _studentInfo = new Students();
        private Students _newStudent = new Students();
        private Students _oldStudents;
        SLPUser _user = null;
        private TeacherUser _teacher = new TeacherUser();

        bool result = false;
        private Enumeration _enumeration;

        public NewStudent(SLPUser user) // constructor for create
        {
            InitializeComponent();
            _user = user;
            btnPrimary.Visibility = Visibility.Hidden;
            btnSecondary.Visibility = Visibility.Hidden;
            this.Title = "Create a new Student record.";
        }

        public NewStudent(Students iep) // constructor for edit
        {
            InitializeComponent();
            _oldStudents = iep;
            setupOldStudent();

            isReadOnly();
            btnSubmit.Visibility = Visibility.Hidden;
            btnSecondary.Visibility = Visibility.Hidden;
            btnPrimary.Content = "Edit IEP";
            btnSecondary.Content = "Submit IEP";
            this.Title = "Edit IEP for " + _oldStudents.FirstName;

        }

        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {

                List<string> stateNames = new List<string>();

                states = _studentManager.States();

                foreach (var item in states)
                {
                    stateNames.Add(item.UnitedStates);
                } 

                cbxState.ItemsSource = stateNames;

                // for the various drop downs and lists in the create a new student.
                cbxIEPType.ItemsSource = _studentManager.SelectAllStudentIEPTypes();
                cbxGrade.ItemsSource = _studentManager.RetrieveGrades();
                cbxSchool.ItemsSource = _studentManager.RetrieveSchools();
                cbxIEPGoal.ItemsSource = _studentManager.RetrieveGoalTypes();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void setupOldStudent()
        {
            // Reads the various information from each textbox, combobox and date picker.

            //txtStudentID.Text = _oldStudents.StudentId.ToString();
            cbxSchool.SelectedItem = _oldStudents.SchoolName;
            dateBirthday.SelectedDate = _oldStudents.Birthday;
            cbxGrade.SelectedItem = _oldStudents.Grade;
            txtFirstName.Text = _oldStudents.FirstName;
            txtLastName.Text = _oldStudents.LastName;
            cbxIEPType.SelectedItem = _oldStudents.IEPType;
            dateIEPDate.SelectedDate = _oldStudents.IEPdate.Date;
            txtFirstNameLeader.Text = _oldStudents.IEPLeaderFirstName;
            txtLastNameLeader.Text = _oldStudents.IEPLeaderLastName;
            txtNotes.Text = _oldStudents.IEPNotes;
            cbxIEPGoal.SelectedItem = _oldStudents.GoalType;
            txtAddress.Text = _oldStudents.Address;
            cbxState.SelectedItem = _oldStudents.State;
            txtCity.Text = _oldStudents.City;
            txtZipcode.Text = _oldStudents.ZipCode;
            chbkActive.IsChecked = _oldStudents.Active;

        }

        private void isReadOnly()
        {
            // This method sets up what functions on the screen are read only. 

            //txtStudentID.IsReadOnly = true;
            txtFirstName.IsReadOnly = true;
            txtLastName.IsReadOnly = true;
            txtFirstNameLeader.IsReadOnly = true;
            txtLastNameLeader.IsReadOnly = true;
            txtNotes.IsReadOnly = true;
            txtAddress.IsReadOnly = true;
            txtCity.IsReadOnly = true;
            txtZipcode.IsReadOnly = true;


            cbxState.IsEnabled = false;
            dateBirthday.IsEnabled = false;
            cbxGrade.IsEnabled = false;
            cbxIEPType.IsEnabled = false;
            dateIEPDate.IsEnabled = false;
            cbxSchool.IsEnabled = false;
            cbxIEPGoal.IsEnabled = false;
            chbkActive.IsEnabled = false;

        }

        private void canEdit()
        {
            // This method sets up what functions on the screen can be edited. 

            txtFirstNameLeader.IsReadOnly = false;
            txtLastNameLeader.IsReadOnly = false;
            txtNotes.IsReadOnly = false;
            cbxSchool.IsReadOnly = false;

            cbxIEPType.IsEnabled = true;
            dateIEPDate.IsEnabled = true;
            cbxIEPGoal.IsEnabled = true;
            chbkActive.IsEnabled = true;

        }

        private void createNewIEP()
        {
            if (txtFirstName.Text.Length <= 0 || txtFirstName.Text.Length > 50)
            {
                MessageBox.Show("Invalid Student First Name. Please try agan.");
                txtFirstName.Focus();
                txtFirstName.SelectAll();
                return;
            }

            if (txtLastName.Text.Length <= 0 || txtLastName.Text.Length > 50)
            {
                MessageBox.Show("Invalid Student Last Name. Please try agan.");
                txtLastName.Focus();
                txtLastName.SelectAll();
                return;
            }

            if (cbxGrade.SelectedItem.Equals(null))
            {
                MessageBox.Show("Invalid Student Grade. Please select a Grade and try again.");
                cbxGrade.Focus();
                return;
            }

            if (txtAddress.Text.Length <= 0 || txtAddress.Text.Length > 30)
            {
                MessageBox.Show("Invalid Student Address. Please try agan.");
                txtAddress.Focus();
                txtAddress.SelectAll();
                return;
            }

            if (txtCity.Text.Length <= 0 || txtCity.Text.Length > 30)
            {
                MessageBox.Show("Invalid City name. Please try agan.");
                txtCity.Focus();
                txtCity.SelectAll();
                return;
            }

            if (cbxState.SelectedItem.Equals(null))
            {
                MessageBox.Show("Invalid State. Please select a State and try again.");
                cbxState.Focus();
                return;
            }

            if (txtZipcode.Text.ToString().Length <= 0 || txtZipcode.Text.ToString().Length > 10)
            {
                MessageBox.Show("Invalid Zip Code. Please try agan.");
                txtZipcode.Focus();
                txtZipcode.SelectAll();
                return;
            }

            if (dateBirthday.SelectedDate >= DateTime.Now)
            {
                MessageBox.Show("Invalid Birthday. Please select a date earlier than today and try agan.");
                dateBirthday.Focus();
                return;
            }

            if (cbxSchool.SelectedItem.Equals(null))
            {
                MessageBox.Show("Invalid School. Please select a School and try again.");
                cbxSchool.Focus();
                return;
            }

            if (txtFirstNameLeader.Text.Length <= 0 || txtFirstNameLeader.Text.Length > 50)
            {
                MessageBox.Show("Invalid IEP Leader First Name. Please try agan.");
                txtFirstNameLeader.Focus();
                txtFirstNameLeader.SelectAll();
                return;
            }

            if (txtLastNameLeader.Text.Length <= 0 || txtLastNameLeader.Text.Length > 50)
            {
                MessageBox.Show("Invalid IEP Leader Last Name. Please try agan.");
                txtLastNameLeader.Focus();
                txtLastNameLeader.SelectAll();
                return;
            }

            if (dateIEPDate.SelectedDate <= DateTime.Now)
            {
                MessageBox.Show("Invalid IEP Date. Please select a date in the future and try agan.");
                dateIEPDate.Focus();
                return;
            }

            if (cbxIEPGoal.SelectedItem == null)
            {
                MessageBox.Show("Invalid IEP Goal. Please select at least one goal for this student.");
                cbxIEPGoal.Focus();
                return;
            }

            if (cbxIEPType.SelectedItem.Equals(null))
            {
                MessageBox.Show("Invalid IEP Type. Please select an IEP Type and try again.");
                cbxIEPType.Focus();
                return;
            }

            //_newStudent = new Students()
            //{
            //    StudentId = int.Parse(txtStudentID.Text),
            //    SchoolName = cbxSchool.SelectedItem.ToString(),
            //    Birthday = (DateTime)dateBirthday.SelectedDate,
            //    Grade = cbxGrade.SelectedItem.ToString(),
            //    FirstName = txtFirstName.Text,
            //    LastName = txtLastName.Text,
            //    IEPType = cbxIEPType.SelectedItem.ToString(),
            //    IEPdate = (DateTime)dateIEPDate.SelectedDate,
            //    IEPLeaderFirstName = txtFirstNameLeader.Text,
            //    IEPLeaderLastName = txtLastNameLeader.Text,
            //    IEPNotes = txtNotes.Text,
            //    Address = txtAddress.Text,
            //    City = txtCity.Text,
            //    State = cbxState.SelectedItem.ToString(),
            //    ZipCode = txtZipcode.Text,
            //    GoalType = cbxIEPGoal.SelectedItem.ToString()
            //};

            //_newStudent.StudentId = int.Parse(txtStudentID.Text);
            _newStudent.SchoolName = cbxSchool.SelectedItem.ToString();
            _newStudent.Birthday = dateBirthday.SelectedDate.Value;
            _newStudent.Grade = cbxGrade.SelectedItem.ToString();
            _newStudent.FirstName = txtFirstName.Text;
            _newStudent.LastName = txtLastName.Text;
            _newStudent.IEPType = cbxIEPType.SelectedItem.ToString();
            _newStudent.IEPdate = dateIEPDate.SelectedDate.Value;
            _newStudent.IEPLeaderFirstName = txtFirstNameLeader.Text;
            _newStudent.IEPLeaderLastName = txtLastNameLeader.Text;
            _newStudent.IEPNotes = txtNotes.Text;
            _newStudent.Address = txtAddress.Text;
            _newStudent.City = txtCity.Text;
            _newStudent.State = cbxState.SelectedItem.ToString();
            _newStudent.ZipCode = txtZipcode.Text;
            _newStudent.Active = (bool)chbkActive.IsChecked;
            _newStudent.GoalType = cbxIEPGoal.SelectedItem.ToString();



        }

        private void createNewStudent()
        {
            if (txtFirstName.Text.Length <= 0 || txtFirstName.Text.Length > 50)
            {
                MessageBox.Show("Invalid Student First Name. Please try agan.");
                txtFirstName.Focus();
                txtFirstName.SelectAll();
                return;
            }

            if (txtLastName.Text.Length <= 0 || txtLastName.Text.Length > 50)
            {
                MessageBox.Show("Invalid Student Last Name. Please try agan.");
                txtLastName.Focus();
                txtLastName.SelectAll();
                return;
            }

            if (cbxGrade.SelectedItem.Equals(null))
            {
                MessageBox.Show("Invalid Student Grade. Please select a Grade and try again.");
                cbxGrade.Focus();
                return;
            }

            if (txtAddress.Text.Length <= 0 || txtAddress.Text.Length > 30)
            {
                MessageBox.Show("Invalid Student Address. Please try agan.");
                txtAddress.Focus();
                txtAddress.SelectAll();
                return;
            }

            if (txtCity.Text.Length <= 0 || txtCity.Text.Length > 30)
            {
                MessageBox.Show("Invalid City name. Please try agan.");
                txtCity.Focus();
                txtCity.SelectAll();
                return;
            }

            if (cbxState.SelectedItem.Equals(null))
            {
                MessageBox.Show("Invalid State. Please select a State and try again.");
                cbxState.Focus();
                return;
            }

            if (txtZipcode.Text.ToString().Length <= 0 || txtZipcode.Text.ToString().Length > 10)
            {
                MessageBox.Show("Invalid Zip Code. Please try agan.");
                txtZipcode.Focus();
                txtZipcode.SelectAll();
                return;
            }

            if (dateBirthday.SelectedDate >= DateTime.Now)
            {
                MessageBox.Show("Invalid Birthday. Please select a date earlier than today and try agan.");
                dateBirthday.Focus();
                return;
            }

            if (cbxSchool.SelectedItem.Equals(null))
            {
                MessageBox.Show("Invalid School. Please select a School and try again.");
                cbxSchool.Focus();
                return;
            }

            if (txtFirstNameLeader.Text.Length <= 0 || txtFirstNameLeader.Text.Length > 50)
            {
                MessageBox.Show("Invalid IEP Leader First Name. Please try agan.");
                txtFirstNameLeader.Focus();
                txtFirstNameLeader.SelectAll();
                return;
            }

            if (txtLastNameLeader.Text.Length <= 0 || txtLastNameLeader.Text.Length > 50)
            {
                MessageBox.Show("Invalid IEP Leader Last Name. Please try agan.");
                txtLastNameLeader.Focus();
                txtLastNameLeader.SelectAll();
                return;
            }

            if (dateIEPDate.SelectedDate <= DateTime.Now)
            {
                MessageBox.Show("Invalid IEP Date. Please select a date in the future and try agan.");
                dateIEPDate.Focus();
                return;
            }

            if (cbxIEPGoal.SelectedItem == null)
            {
                MessageBox.Show("Invalid IEP Goal. Please select at least one goal for this student.");
                cbxIEPGoal.Focus();
                return;
            }

            if (cbxIEPType.SelectedItem.Equals(null))
            {
                MessageBox.Show("Invalid IEP Type. Please select an IEP Type and try again.");
                cbxIEPType.Focus();
                return;
            }
            try
            {

                _studentInfo.SchoolName = cbxSchool.SelectedItem.ToString();
                _studentInfo.NCESId = _studentInfo.NCESId;
                _studentInfo.Birthday = dateBirthday.SelectedDate.Value;
                _studentInfo.Grade = cbxGrade.SelectedItem.ToString();
                _studentInfo.FirstName = txtFirstName.Text;
                _studentInfo.LastName = txtLastName.Text;
                _studentInfo.IEPType = cbxIEPType.SelectedItem.ToString();
                _studentInfo.IEPdate = dateIEPDate.SelectedDate.Value;
                _studentInfo.IEPLeaderFirstName = txtFirstNameLeader.Text;
                _studentInfo.IEPLeaderLastName = txtLastNameLeader.Text;
                _studentInfo.IEPNotes = txtNotes.Text;
                _studentInfo.Address = txtAddress.Text;
                _studentInfo.City = txtCity.Text;
                _studentInfo.State = cbxState.SelectedItem.ToString();
                _studentInfo.ZipCode = txtZipcode.Text;
                _studentInfo.Active = (bool)chbkActive.IsChecked;
                _studentInfo.GoalType = cbxIEPGoal.SelectedItem.ToString();



                if (_studentInfo.SchoolName == "Wright Elementary School")
                {
                    _studentInfo.NCESId = "190654000268";
                    _studentInfo.TeacherID = "DeGeneres.Wright";
                   // _studentInfo.TeacherID = _teacher.TeacherID;
                }
                else if (_studentInfo.SchoolName == "Lovely Lane")
                {
                    _studentInfo.NCESId = "A0301593";
                    _studentInfo.TeacherID = "Turring.Lovely";
                   // _studentInfo.TeacherID = _teacher.TeacherID;
                }
                else if (_studentInfo.SchoolName == "Summit")
                {
                    _studentInfo.NCESId = "T749601";
                    _studentInfo.TeacherID = "Glasgow.Summit";
                   // _studentInfo.TeacherID = _teacher.TeacherID;
                }



                _studentManager.CreateNewStudent(_studentInfo, _user, _teacher);

                //_studentManager.CreateNewStudentIEP(_studentInfo, _user);
                //_userManager.SLPId(_user);

                MessageBox.Show("Your new student has been created.");

                result = true;
                if (result == true)
                {
                    this.DialogResult = true;
                }

                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }


        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            createNewStudent();

        }

        private void BtnSecondary_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                createNewIEP();
                var result = _studentManager.EditIEP(_oldStudents, _newStudent);
                if (result == true)
                {
                    this.DialogResult = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "IEP Update Failed.");
            }
        }

        private void BtnPrimary_Click(object sender, RoutedEventArgs e)
        {
            if (btnPrimary.Content.ToString() == "Edit IEP")
            {
                canEdit();

                btnSecondary.Visibility = Visibility.Visible;


            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure?", "Leaving IEP Screen.", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}
