using DataAccess;
using DataObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SLPProgramTest
{
    [TestClass]
    public class StudentTests
    {
        private IStudentManager _studentManager;
        private List<Students> _students;
        private StudentAccessorMock _mock;

        [TestInitialize]
        public void TestSetup()
        {
            _mock = new StudentAccessorMock();
            _studentManager = new StudentManager(_mock);
            _students = new List<Students>();
            _students = _studentManager.GetStudents();
        }

        /// <summary>
        /// Caitlin Abelson
        /// 
        /// Used when we need to make a very long string of text (i.e. notes)
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private string longString(int length)
        {
            string longString = "";
            for (int i = 0; i < length; i++)
            {
                longString += "i";
            }
            return longString;
        }

        DateTime birthday = DateTime.Now.AddYears(-10);
        DateTime iepDate = DateTime.Now.AddDays(10);

        [TestMethod]
        public void TestRetrieveAllStudents()
        {
            //Arrange
            List<Students> testStudents = null;

            //Act
            testStudents = _studentManager.GetStudents();

            //Assert
            CollectionAssert.Equals(testStudents, _students);
        }



        // START OF ALL CREATE STUDENT/IEP TESTS

        [TestMethod]
        public void TestCreateStudentValidInput()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "K7976L668";
            student.SchoolName = "Prairie Lake";
            student.NCESId = "A9787";
            student.Birthday = birthday;
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = "Peter";
            student.LastName = "Parker";
            student.IEPType = "Initial";
            student.IEPdate = iepDate;
            student.IEPLeaderFirstName = "Karen";
            student.IEPLeaderLastName = "Peterson";
            student.IEPNotes = "IEP notes.";
            student.Address = "123 Fake Street";
            student.City = "Fake City";
            student.State = "IA";
            student.ZipCode = "12345";
            student.Active = true;
            student.GoalType = "MLU";
            

            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);

            //Assert
            Assert.IsNotNull(_students.Find(x =>
                        x.StudentId == student.StudentId
                        && x.SchoolName == student.SchoolName
                        && x.NCESId == student.NCESId
                        && x.Birthday == student.Birthday
                        && x.TeacherID == student.TeacherID
                        && x.Grade == student.Grade
                        && x.FirstName == student.FirstName
                        && x.LastName == student.LastName
                        && x.IEPType == student.IEPType
                        && x.IEPdate == student.IEPdate
                        && x.IEPLeaderFirstName == student.IEPLeaderFirstName
                        && x.IEPLeaderLastName == student.IEPLeaderLastName
                        && x.IEPNotes == student.IEPNotes
                        && x.Address == student.Address
                        && x.City == student.City
                        && x.State == student.State
                        && x.ZipCode == student.ZipCode
                        && x.Active == student.Active
                        && x.GoalType == student.GoalType
             ));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidStudentIDEmptyString()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "";
            student.SchoolName = "Prairie Lake";
            student.NCESId = "A9787";
            student.Birthday = birthday;
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = "Peter";
            student.LastName = "Parker";
            student.IEPType = "Initial";
            student.IEPdate = iepDate;
            student.IEPLeaderFirstName = "Karen";
            student.IEPLeaderLastName = "Peterson";
            student.IEPNotes = "IEP notes.";
            student.Address = "123 Fake Street";
            student.City = "Fake City";
            student.State = "IA";
            student.ZipCode = "12345";
            student.Active = true;
            student.GoalType = "MLU";


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidStudentIDTooLong()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = longString(51);
            student.SchoolName = "Prairie Lake";
            student.NCESId = "A9787";
            student.Birthday = birthday;
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = "Peter";
            student.LastName = "Parker";
            student.IEPType = "Initial";
            student.IEPdate = iepDate;
            student.IEPLeaderFirstName = "Karen";
            student.IEPLeaderLastName = "Peterson";
            student.IEPNotes = "IEP notes.";
            student.Address = "123 Fake Street";
            student.City = "Fake City";
            student.State = "IA";
            student.ZipCode = "12345";
            student.Active = true;
            student.GoalType = "MLU";


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidInputSchoolNameNull()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "K7976L668";
            student.SchoolName = null;
            student.NCESId = "A9787";
            student.Birthday = birthday;
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = "Peter";
            student.LastName = "Parker";
            student.IEPType = "Initial";
            student.IEPdate = iepDate;
            student.IEPLeaderFirstName = "Karen";
            student.IEPLeaderLastName = "Peterson";
            student.IEPNotes = "IEP notes.";
            student.Address = "123 Fake Street";
            student.City = "Fake City";
            student.State = "IA";
            student.ZipCode = "12345";
            student.Active = true;
            student.GoalType = "MLU";


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);

            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidInputNCESIdEmptyString()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "K7976L668";
            student.SchoolName = "Prairie Lake";
            student.NCESId = "";
            student.Birthday = birthday;
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = "Peter";
            student.LastName = "Parker";
            student.IEPType = "Initial";
            student.IEPdate = iepDate;
            student.IEPLeaderFirstName = "Karen";
            student.IEPLeaderLastName = "Peterson";
            student.IEPNotes = "IEP notes.";
            student.Address = "123 Fake Street";
            student.City = "Fake City";
            student.State = "IA";
            student.ZipCode = "12345";
            student.Active = true;
            student.GoalType = "MLU";


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidInputNCESIdTooLong()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "K7976L668";
            student.SchoolName = "Prairie Lake";
            student.NCESId = longString(51);
            student.Birthday = birthday;
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = "Peter";
            student.LastName = "Parker";
            student.IEPType = "Initial";
            student.IEPdate = iepDate;
            student.IEPLeaderFirstName = "Karen";
            student.IEPLeaderLastName = "Peterson";
            student.IEPNotes = "IEP notes.";
            student.Address = "123 Fake Street";
            student.City = "Fake City";
            student.State = "IA";
            student.ZipCode = "12345";
            student.Active = true;
            student.GoalType = "MLU";


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidInputBirthdayFuture()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "K7976L668";
            student.SchoolName = "Prairie Lake";
            student.NCESId = "A9787";
            student.Birthday = DateTime.Now.AddDays(10);
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = "Peter";
            student.LastName = "Parker";
            student.IEPType = "Initial";
            student.IEPdate = iepDate;
            student.IEPLeaderFirstName = "Karen";
            student.IEPLeaderLastName = "Peterson";
            student.IEPNotes = "IEP notes.";
            student.Address = "123 Fake Street";
            student.City = "Fake City";
            student.State = "IA";
            student.ZipCode = "12345";
            student.Active = true;
            student.GoalType = "MLU";


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidInputBirthdayToday()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "K7976L668";
            student.SchoolName = "Prairie Lake";
            student.NCESId = "A9787";
            student.Birthday = DateTime.Now.Date;
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = "Peter";
            student.LastName = "Parker";
            student.IEPType = "Initial";
            student.IEPdate = iepDate;
            student.IEPLeaderFirstName = "Karen";
            student.IEPLeaderLastName = "Peterson";
            student.IEPNotes = "IEP notes.";
            student.Address = "123 Fake Street";
            student.City = "Fake City";
            student.State = "IA";
            student.ZipCode = "12345";
            student.Active = true;
            student.GoalType = "MLU";


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidInputGradeNull()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "K7976L668";
            student.SchoolName = "Prairie Lake";
            student.NCESId = "A9787";
            student.Birthday = birthday;
            student.TeacherID = "Karen.Prairie";
            student.Grade = null;
            student.FirstName = "Peter";
            student.LastName = "Parker";
            student.IEPType = "Initial";
            student.IEPdate = iepDate;
            student.IEPLeaderFirstName = "Karen";
            student.IEPLeaderLastName = "Peterson";
            student.IEPNotes = "IEP notes.";
            student.Address = "123 Fake Street";
            student.City = "Fake City";
            student.State = "IA";
            student.ZipCode = "12345";
            student.Active = true;
            student.GoalType = "MLU";


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidInputStudentFirstNameEmptyString()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "K7976L668";
            student.SchoolName = "Prairie Lake";
            student.NCESId = "A9787";
            student.Birthday = birthday;
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = "";
            student.LastName = "Parker";
            student.IEPType = "Initial";
            student.IEPdate = iepDate;
            student.IEPLeaderFirstName = "Karen";
            student.IEPLeaderLastName = "Peterson";
            student.IEPNotes = "IEP notes.";
            student.Address = "123 Fake Street";
            student.City = "Fake City";
            student.State = "IA";
            student.ZipCode = "12345";
            student.Active = true;
            student.GoalType = "MLU";


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidInputStudentFirstNameTooLong()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "K7976L668";
            student.SchoolName = "Prairie Lake";
            student.NCESId = "A9787";
            student.Birthday = birthday;
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = longString(51);
            student.LastName = "Parker";
            student.IEPType = "Initial";
            student.IEPdate = iepDate;
            student.IEPLeaderFirstName = "Karen";
            student.IEPLeaderLastName = "Peterson";
            student.IEPNotes = "IEP notes.";
            student.Address = "123 Fake Street";
            student.City = "Fake City";
            student.State = "IA";
            student.ZipCode = "12345";
            student.Active = true;
            student.GoalType = "MLU";


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidInputStudentFirstNameHasNums()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "K7976L668";
            student.SchoolName = "Prairie Lake";
            student.NCESId = "A9787";
            student.Birthday = birthday;
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = "Peter51";
            student.LastName = "Parker";
            student.IEPType = "Initial";
            student.IEPdate = iepDate;
            student.IEPLeaderFirstName = "Karen";
            student.IEPLeaderLastName = "Peterson";
            student.IEPNotes = "IEP notes.";
            student.Address = "123 Fake Street";
            student.City = "Fake City";
            student.State = "IA";
            student.ZipCode = "12345";
            student.Active = true;
            student.GoalType = "MLU";


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidInputStudentLastNameEmptyString()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "K7976L668";
            student.SchoolName = "Prairie Lake";
            student.NCESId = "A9787";
            student.Birthday = birthday;
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = "Peter";
            student.LastName = "";
            student.IEPType = "Initial";
            student.IEPdate = iepDate;
            student.IEPLeaderFirstName = "Karen";
            student.IEPLeaderLastName = "Peterson";
            student.IEPNotes = "IEP notes.";
            student.Address = "123 Fake Street";
            student.City = "Fake City";
            student.State = "IA";
            student.ZipCode = "12345";
            student.Active = true;
            student.GoalType = "MLU";


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidInputStudentLastNameTooLong()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "K7976L668";
            student.SchoolName = "Prairie Lake";
            student.NCESId = "A9787";
            student.Birthday = birthday;
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = "Peter";
            student.LastName = longString(101);
            student.IEPType = "Initial";
            student.IEPdate = iepDate;
            student.IEPLeaderFirstName = "Karen";
            student.IEPLeaderLastName = "Peterson";
            student.IEPNotes = "IEP notes.";
            student.Address = "123 Fake Street";
            student.City = "Fake City";
            student.State = "IA";
            student.ZipCode = "12345";
            student.Active = true;
            student.GoalType = "MLU";


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidInputStudentLastNameContainsNums()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "K7976L668";
            student.SchoolName = "Prairie Lake";
            student.NCESId = "A9787";
            student.Birthday = birthday;
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = "Peter";
            student.LastName = "Parker27";
            student.IEPType = "Initial";
            student.IEPdate = iepDate;
            student.IEPLeaderFirstName = "Karen";
            student.IEPLeaderLastName = "Peterson";
            student.IEPNotes = "IEP notes.";
            student.Address = "123 Fake Street";
            student.City = "Fake City";
            student.State = "IA";
            student.ZipCode = "12345";
            student.Active = true;
            student.GoalType = "MLU";


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidInputIEPTypeNull()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "K7976L668";
            student.SchoolName = "Prairie Lake";
            student.NCESId = "A9787";
            student.Birthday = birthday;
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = "Peter";
            student.LastName = "Parker";
            student.IEPType = null;
            student.IEPdate = iepDate;
            student.IEPLeaderFirstName = "Karen";
            student.IEPLeaderLastName = "Peterson";
            student.IEPNotes = "IEP notes.";
            student.Address = "123 Fake Street";
            student.City = "Fake City";
            student.State = "IA";
            student.ZipCode = "12345";
            student.Active = true;
            student.GoalType = "MLU";


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidInputIEPLeaderFirstNameEmptyString()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "K7976L668";
            student.SchoolName = "Prairie Lake";
            student.NCESId = "A9787";
            student.Birthday = birthday;
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = "Peter";
            student.LastName = "Parker";
            student.IEPType = "Initial";
            student.IEPdate = iepDate;
            student.IEPLeaderFirstName = "";
            student.IEPLeaderLastName = "Peterson";
            student.IEPNotes = "IEP notes.";
            student.Address = "123 Fake Street";
            student.City = "Fake City";
            student.State = "IA";
            student.ZipCode = "12345";
            student.Active = true;
            student.GoalType = "MLU";


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidInputIEPLeaderFirstNameTooLong()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "K7976L668";
            student.SchoolName = "Prairie Lake";
            student.NCESId = "A9787";
            student.Birthday = birthday;
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = "Peter";
            student.LastName = "Parker";
            student.IEPType = "Initial";
            student.IEPdate = iepDate;
            student.IEPLeaderFirstName = longString(51);
            student.IEPLeaderLastName = "Peterson";
            student.IEPNotes = "IEP notes.";
            student.Address = "123 Fake Street";
            student.City = "Fake City";
            student.State = "IA";
            student.ZipCode = "12345";
            student.Active = true;
            student.GoalType = "MLU";


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidInputIEPLeaderFirstNameContainsNums()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "K7976L668";
            student.SchoolName = "Prairie Lake";
            student.NCESId = "A9787";
            student.Birthday = birthday;
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = "Peter";
            student.LastName = "Parker";
            student.IEPType = "Initial";
            student.IEPdate = iepDate;
            student.IEPLeaderFirstName = "Karen73";
            student.IEPLeaderLastName = "Peterson";
            student.IEPNotes = "IEP notes.";
            student.Address = "123 Fake Street";
            student.City = "Fake City";
            student.State = "IA";
            student.ZipCode = "12345";
            student.Active = true;
            student.GoalType = "MLU";


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidInputIEPLeaderLastNameEmptyString()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "K7976L668";
            student.SchoolName = "Prairie Lake";
            student.NCESId = "A9787";
            student.Birthday = birthday;
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = "Peter";
            student.LastName = "Parker";
            student.IEPType = "Initial";
            student.IEPdate = iepDate;
            student.IEPLeaderFirstName = "Karen";
            student.IEPLeaderLastName = "";
            student.IEPNotes = "IEP notes.";
            student.Address = "123 Fake Street";
            student.City = "Fake City";
            student.State = "IA";
            student.ZipCode = "12345";
            student.Active = true;
            student.GoalType = "MLU";


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidInputIEPLeaderLastNameTooLong()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "K7976L668";
            student.SchoolName = "Prairie Lake";
            student.NCESId = "A9787";
            student.Birthday = birthday;
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = "Peter";
            student.LastName = "Parker";
            student.IEPType = "Initial";
            student.IEPdate = iepDate;
            student.IEPLeaderFirstName = "Karen";
            student.IEPLeaderLastName = longString(101);
            student.IEPNotes = "IEP notes.";
            student.Address = "123 Fake Street";
            student.City = "Fake City";
            student.State = "IA";
            student.ZipCode = "12345";
            student.Active = true;
            student.GoalType = "MLU";


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidInputIEPLeaderLastNameContainsNums()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "K7976L668";
            student.SchoolName = "Prairie Lake";
            student.NCESId = "A9787";
            student.Birthday = birthday;
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = "Peter";
            student.LastName = "Parker";
            student.IEPType = "Initial";
            student.IEPdate = iepDate;
            student.IEPLeaderFirstName = "Karen";
            student.IEPLeaderLastName = "Jones66";
            student.IEPNotes = "IEP notes.";
            student.Address = "123 Fake Street";
            student.City = "Fake City";
            student.State = "IA";
            student.ZipCode = "12345";
            student.Active = true;
            student.GoalType = "MLU";


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidInputIEPNotesTooLong()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "K7976L668";
            student.SchoolName = "Prairie Lake";
            student.NCESId = "A9787";
            student.Birthday = birthday;
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = "Peter";
            student.LastName = "Parker";
            student.IEPType = "Initial";
            student.IEPdate = iepDate;
            student.IEPLeaderFirstName = "Karen";
            student.IEPLeaderLastName = "Peterson";
            student.IEPNotes = longString(4001);
            student.Address = "123 Fake Street";
            student.City = "Fake City";
            student.State = "IA";
            student.ZipCode = "12345";
            student.Active = true;
            student.GoalType = "MLU";


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidInputAddressEmptyString()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "K7976L668";
            student.SchoolName = "Prairie Lake";
            student.NCESId = "A9787";
            student.Birthday = birthday;
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = "Peter";
            student.LastName = "Parker";
            student.IEPType = "Initial";
            student.IEPdate = iepDate;
            student.IEPLeaderFirstName = "Karen";
            student.IEPLeaderLastName = "Peterson";
            student.IEPNotes = "IEP notes.";
            student.Address = "";
            student.City = "Fake City";
            student.State = "IA";
            student.ZipCode = "12345";
            student.Active = true;
            student.GoalType = "MLU";


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidInputAddressTooLong()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "K7976L668";
            student.SchoolName = "Prairie Lake";
            student.NCESId = "A9787";
            student.Birthday = birthday;
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = "Peter";
            student.LastName = "Parker";
            student.IEPType = "Initial";
            student.IEPdate = iepDate;
            student.IEPLeaderFirstName = "Karen";
            student.IEPLeaderLastName = "Peterson";
            student.IEPNotes = "IEP notes.";
            student.Address = longString(31);
            student.City = "Fake City";
            student.State = "IA";
            student.ZipCode = "12345";
            student.Active = true;
            student.GoalType = "MLU";


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidInputCityEmptyString()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "K7976L668";
            student.SchoolName = "Prairie Lake";
            student.NCESId = "A9787";
            student.Birthday = birthday;
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = "Peter";
            student.LastName = "Parker";
            student.IEPType = "Initial";
            student.IEPdate = iepDate;
            student.IEPLeaderFirstName = "Karen";
            student.IEPLeaderLastName = "Peterson";
            student.IEPNotes = "IEP notes.";
            student.Address = "123 Fake Street";
            student.City = "";
            student.State = "IA";
            student.ZipCode = "12345";
            student.Active = true;
            student.GoalType = "MLU";


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidInputCityTooLong()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "K7976L668";
            student.SchoolName = "Prairie Lake";
            student.NCESId = "A9787";
            student.Birthday = birthday;
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = "Peter";
            student.LastName = "Parker";
            student.IEPType = "Initial";
            student.IEPdate = iepDate;
            student.IEPLeaderFirstName = "Karen";
            student.IEPLeaderLastName = "Peterson";
            student.IEPNotes = "IEP notes.";
            student.Address = "123 Fake Street";
            student.City = longString(31);
            student.State = "IA";
            student.ZipCode = "12345";
            student.Active = true;
            student.GoalType = "MLU";


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidInputStateNull()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "K7976L668";
            student.SchoolName = "Prairie Lake";
            student.NCESId = "A9787";
            student.Birthday = birthday;
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = "Peter";
            student.LastName = "Parker";
            student.IEPType = "Initial";
            student.IEPdate = iepDate;
            student.IEPLeaderFirstName = "Karen";
            student.IEPLeaderLastName = "Peterson";
            student.IEPNotes = "IEP notes.";
            student.Address = "123 Fake Street";
            student.City = "Fake City";
            student.State = null;
            student.ZipCode = "12345";
            student.Active = true;
            student.GoalType = "MLU";


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidInputZipCodeEmptyString()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "K7976L668";
            student.SchoolName = "Prairie Lake";
            student.NCESId = "A9787";
            student.Birthday = birthday;
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = "Peter";
            student.LastName = "Parker";
            student.IEPType = "Initial";
            student.IEPdate = iepDate;
            student.IEPLeaderFirstName = "Karen";
            student.IEPLeaderLastName = "Peterson";
            student.IEPNotes = "IEP notes.";
            student.Address = "123 Fake Street";
            student.City = "Fake City";
            student.State = "IA";
            student.ZipCode = "";
            student.Active = true;
            student.GoalType = "MLU";


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidInputZipCodeLessThanFour()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "K7976L668";
            student.SchoolName = "Prairie Lake";
            student.NCESId = "A9787";
            student.Birthday = birthday;
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = "Peter";
            student.LastName = "Parker";
            student.IEPType = "Initial";
            student.IEPdate = iepDate;
            student.IEPLeaderFirstName = "Karen";
            student.IEPLeaderLastName = "Peterson";
            student.IEPNotes = "IEP notes.";
            student.Address = "123 Fake Street";
            student.City = "Fake City";
            student.State = "IA";
            student.ZipCode = "123";
            student.Active = true;
            student.GoalType = "MLU";


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidInputZipCodeLessMoreThanSeven()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "K7976L668";
            student.SchoolName = "Prairie Lake";
            student.NCESId = "A9787";
            student.Birthday = birthday;
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = "Peter";
            student.LastName = "Parker";
            student.IEPType = "Initial";
            student.IEPdate = iepDate;
            student.IEPLeaderFirstName = "Karen";
            student.IEPLeaderLastName = "Peterson";
            student.IEPNotes = "IEP notes.";
            student.Address = "123 Fake Street";
            student.City = "Fake City";
            student.State = "IA";
            student.ZipCode = "12345678";
            student.Active = true;
            student.GoalType = "MLU";


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidInputZipCodeContainsLetters()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "K7976L668";
            student.SchoolName = "Prairie Lake";
            student.NCESId = "A9787";
            student.Birthday = birthday;
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = "Peter";
            student.LastName = "Parker";
            student.IEPType = "Initial";
            student.IEPdate = iepDate;
            student.IEPLeaderFirstName = "Karen";
            student.IEPLeaderLastName = "Peterson";
            student.IEPNotes = "IEP notes.";
            student.Address = "123 Fake Street";
            student.City = "Fake City";
            student.State = "IA";
            student.ZipCode = "12345abc";
            student.Active = true;
            student.GoalType = "MLU";


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidInputIEPDateToday()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "K7976L668";
            student.SchoolName = "Prairie Lake";
            student.NCESId = "A9787";
            student.Birthday = birthday;
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = "Peter";
            student.LastName = "Parker";
            student.IEPType = "Initial";
            student.IEPdate = DateTime.Now;
            student.IEPLeaderFirstName = "Karen";
            student.IEPLeaderLastName = "Peterson";
            student.IEPNotes = "IEP notes.";
            student.Address = "123 Fake Street";
            student.City = "Fake City";
            student.State = "IA";
            student.ZipCode = "12345";
            student.Active = true;
            student.GoalType = "MLU";


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidInputIEPDatePast()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "K7976L668";
            student.SchoolName = "Prairie Lake";
            student.NCESId = "A9787";
            student.Birthday = birthday;
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = "Peter";
            student.LastName = "Parker";
            student.IEPType = "Initial";
            student.IEPdate = DateTime.Now.AddDays(-15);
            student.IEPLeaderFirstName = "Karen";
            student.IEPLeaderLastName = "Peterson";
            student.IEPNotes = "IEP notes.";
            student.Address = "123 Fake Street";
            student.City = "Fake City";
            student.State = "IA";
            student.ZipCode = "12345";
            student.Active = true;
            student.GoalType = "MLU";


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidInputIepTypeNull()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "K7976L668";
            student.SchoolName = "Prairie Lake";
            student.NCESId = "A9787";
            student.Birthday = birthday;
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = "Peter";
            student.LastName = "Parker";
            student.IEPType = null;
            student.IEPdate = iepDate;
            student.IEPLeaderFirstName = "Karen";
            student.IEPLeaderLastName = "Peterson";
            student.IEPNotes = "IEP notes.";
            student.Address = "123 Fake Street";
            student.City = "Fake City";
            student.State = "IA";
            student.ZipCode = "12345";
            student.Active = true;
            student.GoalType = "MLU";


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateStudentInValidInputGoalTypeNull()
        {
            //Arrange
            Students student = new Students();

            student.StudentId = "K7976L668";
            student.SchoolName = "Prairie Lake";
            student.NCESId = "A9787";
            student.Birthday = birthday;
            student.TeacherID = "Karen.Prairie";
            student.Grade = "5th";
            student.FirstName = "Peter";
            student.LastName = "Parker";
            student.IEPType = "Initial";
            student.IEPdate = iepDate;
            student.IEPLeaderFirstName = "Karen";
            student.IEPLeaderLastName = "Peterson";
            student.IEPNotes = "IEP notes.";
            student.Address = "123 Fake Street";
            student.City = "Fake City";
            student.State = "IA";
            student.ZipCode = "12345";
            student.Active = true;
            student.GoalType = null;


            SLPUser slp = new SLPUser()
            {
                SLPID = "C1234"
            };

            TeacherUser teacher = new TeacherUser()
            {
                TeacherID = "Karen.Prairie"
            };

            //Act
            _studentManager.CreateNewStudent(student, slp, teacher);
        }

        // END OF CREATE TESTS


        ///////////////////////////////////////////////////////////////////////


        // START OF IEP UPDATE TESTS

        [TestMethod]
        public void TestUpdateIEPValidInput()
        {
            // Arrange
            bool expectedResult = false;
            bool actualResult;
            Students oldIEP = _students[0];
            Students newIEP = new Students();

            newIEP.StudentId = oldIEP.StudentId;
            newIEP.SchoolName = oldIEP.SchoolName;
            newIEP.NCESId = oldIEP.NCESId;
            newIEP.Birthday = oldIEP.Birthday;
            newIEP.TeacherID = oldIEP.TeacherID;
            newIEP.Grade = oldIEP.Grade;
            newIEP.FirstName = oldIEP.FirstName;
            newIEP.LastName = oldIEP.LastName;
            newIEP.IEPType = "Initial";
            newIEP.IEPdate = iepDate;
            newIEP.IEPLeaderFirstName = "Valid";
            newIEP.IEPLeaderLastName = "Valid";
            newIEP.IEPNotes = "These are valid notes.";
            newIEP.Address = oldIEP.Address;
            newIEP.City = oldIEP.City;
            newIEP.State = oldIEP.State;
            newIEP.ZipCode = oldIEP.ZipCode;
            newIEP.Active = oldIEP.Active;
            newIEP.GoalType = "Voice";


            // Act
            actualResult = _studentManager.EditIEP(oldIEP, newIEP);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// IEPType is a combobox so the only way it can be invalid is if it is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateIEPInValidInputIEPTypeNull()
        {
            // Arrange
            Students oldIEP = _students[0];
            Students newIEP = new Students();

            newIEP.StudentId = oldIEP.StudentId;
            newIEP.SchoolName = oldIEP.SchoolName;
            newIEP.NCESId = oldIEP.NCESId;
            newIEP.Birthday = oldIEP.Birthday;
            newIEP.TeacherID = oldIEP.TeacherID;
            newIEP.Grade = oldIEP.Grade;
            newIEP.FirstName = oldIEP.FirstName;
            newIEP.LastName = oldIEP.LastName;
            newIEP.IEPType = null;
            newIEP.IEPdate = iepDate;
            newIEP.IEPLeaderFirstName = "Valid";
            newIEP.IEPLeaderLastName = "Valid";
            newIEP.IEPNotes = "These are valid notes.";
            newIEP.Address = oldIEP.Address;
            newIEP.City = oldIEP.City;
            newIEP.State = oldIEP.State;
            newIEP.ZipCode = oldIEP.ZipCode;
            newIEP.Active = oldIEP.Active;
            newIEP.GoalType = "Voice";


            // Act
            _studentManager.EditIEP(oldIEP, newIEP);

        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateIEPInValidInputIEPLeaderFirstNameEmptyString()
        {
            // Arrange
            Students oldIEP = _students[0];
            Students newIEP = new Students();

            newIEP.StudentId = oldIEP.StudentId;
            newIEP.SchoolName = oldIEP.SchoolName;
            newIEP.NCESId = oldIEP.NCESId;
            newIEP.Birthday = oldIEP.Birthday;
            newIEP.TeacherID = oldIEP.TeacherID;
            newIEP.Grade = oldIEP.Grade;
            newIEP.FirstName = oldIEP.FirstName;
            newIEP.LastName = oldIEP.LastName;
            newIEP.IEPType = "Initial";
            newIEP.IEPdate = iepDate;
            newIEP.IEPLeaderFirstName = "";
            newIEP.IEPLeaderLastName = "Valid";
            newIEP.IEPNotes = "These are valid notes.";
            newIEP.Address = oldIEP.Address;
            newIEP.City = oldIEP.City;
            newIEP.State = oldIEP.State;
            newIEP.ZipCode = oldIEP.ZipCode;
            newIEP.Active = oldIEP.Active;
            newIEP.GoalType = "Voice";


            // Act
            _studentManager.EditIEP(oldIEP, newIEP);

        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateIEPInValidInputIEPLeaderFirstNameTooLong()
        {
            // Arrange
            Students oldIEP = _students[0];
            Students newIEP = new Students();

            newIEP.StudentId = oldIEP.StudentId;
            newIEP.SchoolName = oldIEP.SchoolName;
            newIEP.NCESId = oldIEP.NCESId;
            newIEP.Birthday = oldIEP.Birthday;
            newIEP.TeacherID = oldIEP.TeacherID;
            newIEP.Grade = oldIEP.Grade;
            newIEP.FirstName = oldIEP.FirstName;
            newIEP.LastName = oldIEP.LastName;
            newIEP.IEPType = "Initial";
            newIEP.IEPdate = iepDate;
            newIEP.IEPLeaderFirstName = longString(51);
            newIEP.IEPLeaderLastName = "Valid";
            newIEP.IEPNotes = "These are valid notes.";
            newIEP.Address = oldIEP.Address;
            newIEP.City = oldIEP.City;
            newIEP.State = oldIEP.State;
            newIEP.ZipCode = oldIEP.ZipCode;
            newIEP.Active = oldIEP.Active;
            newIEP.GoalType = "Voice";


            // Act
            _studentManager.EditIEP(oldIEP, newIEP);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateIEPInValidInputIEPLeaderLastNameEmptyString()
        {
            // Arrange
            Students oldIEP = _students[0];
            Students newIEP = new Students();

            newIEP.StudentId = oldIEP.StudentId;
            newIEP.SchoolName = oldIEP.SchoolName;
            newIEP.NCESId = oldIEP.NCESId;
            newIEP.Birthday = oldIEP.Birthday;
            newIEP.TeacherID = oldIEP.TeacherID;
            newIEP.Grade = oldIEP.Grade;
            newIEP.FirstName = oldIEP.FirstName;
            newIEP.LastName = oldIEP.LastName;
            newIEP.IEPType = "Initial";
            newIEP.IEPdate = iepDate;
            newIEP.IEPLeaderFirstName = "Valid";
            newIEP.IEPLeaderLastName = "";
            newIEP.IEPNotes = "These are valid notes.";
            newIEP.Address = oldIEP.Address;
            newIEP.City = oldIEP.City;
            newIEP.State = oldIEP.State;
            newIEP.ZipCode = oldIEP.ZipCode;
            newIEP.Active = oldIEP.Active;
            newIEP.GoalType = "Voice";


            // Act
            _studentManager.EditIEP(oldIEP, newIEP);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateIEPInValidInputIEPLeaderLastNameTooLong()
        {
            // Arrange
            Students oldIEP = _students[0];
            Students newIEP = new Students();

            newIEP.StudentId = oldIEP.StudentId;
            newIEP.SchoolName = oldIEP.SchoolName;
            newIEP.NCESId = oldIEP.NCESId;
            newIEP.Birthday = oldIEP.Birthday;
            newIEP.TeacherID = oldIEP.TeacherID;
            newIEP.Grade = oldIEP.Grade;
            newIEP.FirstName = oldIEP.FirstName;
            newIEP.LastName = oldIEP.LastName;
            newIEP.IEPType = "Initial";
            newIEP.IEPdate = iepDate;
            newIEP.IEPLeaderFirstName = "Valid";
            newIEP.IEPLeaderLastName = longString(101);
            newIEP.IEPNotes = "These are valid notes.";
            newIEP.Address = oldIEP.Address;
            newIEP.City = oldIEP.City;
            newIEP.State = oldIEP.State;
            newIEP.ZipCode = oldIEP.ZipCode;
            newIEP.Active = oldIEP.Active;
            newIEP.GoalType = "Voice";


            // Act
            _studentManager.EditIEP(oldIEP, newIEP);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateIEPInValidInputIEPDateInPast()
        {
            // Arrange
            Students oldIEP = _students[0];
            Students newIEP = new Students();

            newIEP.StudentId = oldIEP.StudentId;
            newIEP.SchoolName = oldIEP.SchoolName;
            newIEP.NCESId = oldIEP.NCESId;
            newIEP.Birthday = oldIEP.Birthday;
            newIEP.TeacherID = oldIEP.TeacherID;
            newIEP.Grade = oldIEP.Grade;
            newIEP.FirstName = oldIEP.FirstName;
            newIEP.LastName = oldIEP.LastName;
            newIEP.IEPType = "Initial";
            newIEP.IEPdate = DateTime.Now.AddDays(-20);
            newIEP.IEPLeaderFirstName = "Valid";
            newIEP.IEPLeaderLastName = "Valid";
            newIEP.IEPNotes = "These are valid notes.";
            newIEP.Address = oldIEP.Address;
            newIEP.City = oldIEP.City;
            newIEP.State = oldIEP.State;
            newIEP.ZipCode = oldIEP.ZipCode;
            newIEP.Active = oldIEP.Active;
            newIEP.GoalType = "Voice";


            // Act
            _studentManager.EditIEP(oldIEP, newIEP);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateIEPInValidInputIEPNotesTooLong()
        {
            // Arrange
            Students oldIEP = _students[0];
            Students newIEP = new Students();

            newIEP.StudentId = oldIEP.StudentId;
            newIEP.SchoolName = oldIEP.SchoolName;
            newIEP.NCESId = oldIEP.NCESId;
            newIEP.Birthday = oldIEP.Birthday;
            newIEP.TeacherID = oldIEP.TeacherID;
            newIEP.Grade = oldIEP.Grade;
            newIEP.FirstName = oldIEP.FirstName;
            newIEP.LastName = oldIEP.LastName;
            newIEP.IEPType = "Initial";
            newIEP.IEPdate = iepDate;
            newIEP.IEPLeaderFirstName = "Valid";
            newIEP.IEPLeaderLastName = "Valid";
            newIEP.IEPNotes = longString(5000);
            newIEP.Address = oldIEP.Address;
            newIEP.City = oldIEP.City;
            newIEP.State = oldIEP.State;
            newIEP.ZipCode = oldIEP.ZipCode;
            newIEP.Active = oldIEP.Active;
            newIEP.GoalType = "Voice";


            // Act
            _studentManager.EditIEP(oldIEP, newIEP);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUpdateIEPInValidInputGoalTypeNull()
        {
            // Arrange
            Students oldIEP = _students[0];
            Students newIEP = new Students();

            newIEP.StudentId = oldIEP.StudentId;
            newIEP.SchoolName = oldIEP.SchoolName;
            newIEP.NCESId = oldIEP.NCESId;
            newIEP.Birthday = oldIEP.Birthday;
            newIEP.TeacherID = oldIEP.TeacherID;
            newIEP.Grade = oldIEP.Grade;
            newIEP.FirstName = oldIEP.FirstName;
            newIEP.LastName = oldIEP.LastName;
            newIEP.IEPType = "Initial";
            newIEP.IEPdate = iepDate;
            newIEP.IEPLeaderFirstName = "Valid";
            newIEP.IEPLeaderLastName = "Valid";
            newIEP.IEPNotes = "These are valid notes.";
            newIEP.Address = oldIEP.Address;
            newIEP.City = oldIEP.City;
            newIEP.State = oldIEP.State;
            newIEP.ZipCode = oldIEP.ZipCode;
            newIEP.Active = oldIEP.Active;
            newIEP.GoalType = null;


            // Act
            _studentManager.EditIEP(oldIEP, newIEP);

        }

        // END OF IEP UPDATE TESTS


        /////////////////////////////////////////////////////////////////

        // START OF DEACTIVE STUDENT TESTS


        // END OF DEACTIVATE STUDENT TESTS

        ///////////////////////////////////////////////////////////////////

        // START OF DELETE STUDENT TESTS


        // END OF DELETE STUDENT TESTS

    }
}
