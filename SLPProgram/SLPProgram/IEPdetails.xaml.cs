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
    /// Interaction logic for IEP.xaml
    /// </summary>
    public partial class IEPdetails : Window
    {
        private StudentManager _studentManager = new StudentManager();
        private Students _newStudent;
        private Students _oldStudents;
        private List<States> states = new List<States>();


        public IEPdetails(Students iep)
        {
            InitializeComponent();

            _oldStudents = iep;
            setupOldStudent();

            isReadOnly();
            this.Title = "Read IEP for " + _oldStudents.FirstName;
        }

        public IEPdetails()
        {
            InitializeComponent();
        }


        private void isReadOnly()
        {
            txtStudentID.IsReadOnly = true;
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



        private void setupOldStudent()
        {
            txtStudentID.Text = _oldStudents.StudentId.ToString();
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

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure?", "Leaving IEP Screen.", MessageBoxButton.YesNo,MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}
