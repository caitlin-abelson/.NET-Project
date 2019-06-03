using DataAccess;
using DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LogicLayer
{
    public class StudentManager : IStudentManager
    {
        private IStudentAccessor _studentAccessor;

        public StudentManager()
        {
            _studentAccessor = new StudentAccessor();
        }

        public StudentManager(StudentAccessorMock studentAccessorMock)
        {
            _studentAccessor = studentAccessorMock;
        }

        /// <summary>
        /// Caitlin Abelson
        /// 
        /// This method checks all of the other validation methods to see if they are valid.
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public bool isValid(Students student)
        {
            if(validateStudentID(student.StudentId) && validateNCESID(student.NCESId) && validateStudentBirthday(student.Birthday) && validateGrade(student.Grade)
                && validateStudentFirstName(student.FirstName) && validateStudentLastName(student.LastName) && validateSchoolName(student.SchoolName) && validateState(student.State)
                && validateIEPDate(student.IEPdate) && validateIEPType(student.IEPType) && validateIEPLeaderFirstName(student.IEPLeaderFirstName) && validateIEPLeaderLastName(student.IEPLeaderLastName)
                && validateIEPNotes(student.IEPNotes) && validateAddress(student.Address) && validateCity(student.City) && validateZipCode(student.ZipCode) && validateIEPGoalType(student.GoalType))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Caitlin Abelson
        /// 
        /// Validates the studentID
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public bool validateStudentID(string studentID)
        {
            if(studentID.Length < 1 || studentID.Length > 50 || studentID == "")
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Caitlin Abelson
        /// 
        /// Validates that a birthday was set in the past. 
        /// 
        /// The random number generator was created in order to add a number of random days
        /// to the current day to represent the future. If the date that is input for the
        /// birthday is equal to the furture day, then it will be false.
        /// </summary>
        /// <param name="birthday"></param>
        /// <returns></returns>
        public bool validateStudentBirthday(DateTime birthday)
        {
            if(birthday == DateTime.Now.Date || birthday > DateTime.Now)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Caitlin Abelson
        /// 
        /// Validates the NCESID "school ID" length
        /// </summary>
        /// <param name="ncesID"></param>
        /// <returns></returns>
        public bool validateNCESID(string ncesID)
        {
            if(ncesID.Length < 1 || ncesID.Length > 20 || ncesID == "")
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Caitlin Abelson
        /// 
        /// Validates that the combo box for Grade chosen from.
        /// </summary>
        /// <param name="grade"></param>
        /// <returns></returns>
        public bool validateGrade(string grade)
        {
            if(grade == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Caitlin Abelson
        /// 
        /// Validates the student's first name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool validateStudentFirstName(string name)
        {
            if(name.Length < 1 || name.Length > 50 || name == "")
            {
                return false;
            }
            if (name.Contains('0') || name.Contains('1') || name.Contains('2') || name.Contains('3')
                || name.Contains('4') || name.Contains('5') || name.Contains('6') || name.Contains('7')
                || name.Contains('8') || name.Contains('9'))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Caitlin Abelson
        /// 
        /// Validate the student's last name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool validateStudentLastName(string name)
        {
            if (name.Length < 1 || name.Length > 100 || name == "")
            {
                return false;
            }
            if (name.Contains('0') || name.Contains('1') || name.Contains('2') || name.Contains('3')
                || name.Contains('4') || name.Contains('5') || name.Contains('6') || name.Contains('7')
                || name.Contains('8') || name.Contains('9'))
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// Caitlin Abelson
        /// 
        /// Validates the Student's home address
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public bool validateAddress(string address)
        {
            if(address.Length < 1 || address.Length > 30 || address == "")
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Caitlin Abelson
        /// 
        /// Validates the city name in which the Student lives in
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public bool validateCity(string city)
        {
            if (city.Length < 1 || city.Length > 30 || city == "")
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Caitlin Abelson
        /// 
        /// Validates the ZipCode for the Student's address and makes sure there are no
        /// letters in the ZipCode.
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        public bool validateZipCode(string zipCode)
        {
            if(zipCode.Length < 4 || zipCode.Length > 7 || zipCode == "")
            {
                return false;
            }
            if(zipCode.Contains('a') || zipCode.Contains('b') || zipCode.Contains('c') || zipCode.Contains('d')
                || zipCode.Contains('e') || zipCode.Contains('f') || zipCode.Contains('g') || zipCode.Contains('h')
                || zipCode.Contains('i') || zipCode.Contains('j') || zipCode.Contains('k') || zipCode.Contains('l')
                || zipCode.Contains('m') || zipCode.Contains('n') || zipCode.Contains('o') || zipCode.Contains('p')
                || zipCode.Contains('q') || zipCode.Contains('r') || zipCode.Contains('s') || zipCode.Contains('t')
                || zipCode.Contains('u') || zipCode.Contains('u') || zipCode.Contains('v') || zipCode.Contains('w')
                || zipCode.Contains('x') || zipCode.Contains('y') || zipCode.Contains('z'))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Caitlin Abelson
        /// 
        /// Validates that the combo box for the School Name was chosen from.
        /// </summary>
        /// <param name="school"></param>
        /// <returns></returns>
        public bool validateSchoolName(string school)
        {
            if(school == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Caitlin Abelson
        /// 
        /// Validates the IEPdate for an IEP
        /// </summary>
        /// <param name="iepDate"></param>
        /// <returns></returns>
        public bool validateIEPDate(DateTime iepDate)
        {
            if(iepDate < DateTime.Now || iepDate == DateTime.Now || iepDate == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Caitlin Abelson
        /// 
        /// Validates that the combo box for the IEP Type was chosen from.
        /// </summary>
        /// <param name="iepType"></param>
        /// <returns></returns>
        public bool validateIEPType(string iepType)
        {
            if (iepType == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Caitlin Abelson
        /// 
        /// Validates that the combo box for goal type was chosen from.
        /// </summary>
        /// <param name="goalType"></param>
        /// <returns></returns>
        public bool validateIEPGoalType(string goalType)
        {
            if(goalType == null)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// Caitlin Abelson
        /// 
        /// Validates the length of the IEP Leader's first name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool validateIEPLeaderFirstName(string name)
        {
            if (name.Length < 1 || name.Length > 50 || name == "")
            {
                return false;
            }
            if (name.Contains('0') || name.Contains('1') || name.Contains('2') || name.Contains('3')
                || name.Contains('4') || name.Contains('5') || name.Contains('6') || name.Contains('7')
                || name.Contains('8') || name.Contains('9'))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Caitlin Abelson
        /// 
        /// Validates the length of the last name for the IEP Leader.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool validateIEPLeaderLastName(string name)
        {
            if (name.Length < 1 || name.Length > 100 || name == "")
            {
                return false;
            }
            if (name.Contains('0') || name.Contains('1') || name.Contains('2') || name.Contains('3')
                || name.Contains('4') || name.Contains('5') || name.Contains('6') || name.Contains('7')
                || name.Contains('8') || name.Contains('9'))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Caitlin Abelson
        /// 
        /// Validates the length of the notes for an IEP
        /// </summary>
        /// <param name="notes"></param>
        /// <returns></returns>
        public bool validateIEPNotes(string notes)
        {
            if(notes.Length > 4000)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Caitlin Abelson
        /// 
        /// Makes sure that the combo box for the state was chosen from.
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool validateState(string state)
        {
            if (state == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// This is getting the list of students assigned to the individual SLP
        /// </summary>
        /// <param name="SLPId"></param>
        /// <returns></returns>
        public List<Students> GetStudentsBySlpId(string SLPId)
        {
            List<Students> students = null;

            try
            {
                students = _studentAccessor.SelectStudentsBySLPID(SLPId);
            }
            catch (Exception)
            {
                throw;
            }

            return students;

        }

        /// <summary>
        /// This is getting the students for the manager.
        /// </summary>
        /// <returns></returns>
        public List<Students> GetStudents()
        {
            List<Students> students = null;

            try
            {
                students = _studentAccessor.SelectStudents();
            }
            catch (Exception)
            {
                throw;
            }

            return students;

        }

        /// <summary>
        /// This is the list of students that is assigned to the individual teacher.
        /// </summary>
        /// <param name="TeacherID"></param>
        /// <returns></returns>
        public List<Students> GetStudentByTeacherID(string TeacherID)
        {
            List<Students> students = null;

            try
            {
                students = _studentAccessor.SelectStudentsByTeacherID(TeacherID);
            }
            catch (Exception)
            {
                throw;
            }

            return students;
        }

        /// <summary>
        /// Retrieving the student IEP for the teacher to read or for the SLP to read/edit
        /// </summary>
        /// <returns></returns>
        public List<string> SelectAllStudentIEPTypes()
        {
            List<string> studentIEP = null;
            try
            {
                studentIEP = _studentAccessor.SelectAllStudentIEPTypes();
            }
            catch (Exception)
            {
                throw;
            }
            return studentIEP;
        }

        /// <summary>
        /// This is for the combo dropdown box.
        /// </summary>
        /// <returns></returns>
        public List<string> RetrieveGrades()
        {
            List<string> grades = null;
            try
            {
                grades = _studentAccessor.SelectAllGrades();
            }
            catch (Exception)
            {
                throw;
            }
            return grades;
        }

        /// <summary>
        /// This is for a combo dropdown box
        /// </summary>
        /// <returns></returns>
        public List<string> RetrieveSchools()
        {
            List<string> schools = null;
            try
            {
                schools = _studentAccessor.SelectSchools();
            }
            catch (Exception)
            {
                throw;
            }
            return schools;
        }

        /// <summary>
        /// This is for a combo dropdown box
        /// </summary>
        /// <returns></returns>
        public List<string> RetrieveGoalTypes()
        {
            List<string> goaltypes = null;
            try
            {
                goaltypes = _studentAccessor.SelectGoalTypes();
            }
            catch (Exception)
            {
                throw;
            }
            return goaltypes;
        }

        /// <summary>
        /// This is for a combo dropdown box
        /// </summary>
        /// <returns></returns>
        public List<States> States()
        {
            List<States> states = new List<States>();
            try
            {
                states = _studentAccessor.RetrieveStates();

                return states;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Creating a new student. In order for a student to be created, they also need some of the information
        /// from the SLP and Teacher to be passed as well since every student is associated with a teacher and an SLP
        /// </summary>
        /// <param name="newStudent">The student information that is needed</param>
        /// <param name="slp">Every student is associated with an SLP</param>
        /// <param name="teacher">Every student is associated with a teacher</param>
        /// <returns></returns>
        public bool CreateNewStudent(Students newStudent, SLPUser slp, TeacherUser teacher)
        {
            bool result = false;
            try
            {
                if (!isValid(newStudent))
                {
                    throw new ArgumentException("Invalid data for new student.");
                }
                result = _studentAccessor.CreateNewStudent(newStudent, slp, teacher);

            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        /// <summary>
        /// This is for editing an IEP for a student.
        /// </summary>
        /// <param name="oldIEP"></param>
        /// <param name="newIEP"></param>
        /// <returns></returns>
        public bool EditIEP(Students oldIEP, Students newIEP)
        {
            bool result = false;

            try
            {
                if (!isValid(newIEP))
                {
                    throw new ArgumentException("Invalid data for student IEP.");
                }
                result = (1 == _studentAccessor.UpdateIEP(oldIEP, newIEP));
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        /// <summary>
        /// This is for deleting a student from a roster.
        /// </summary>
        /// <param name="student"></param>
        /// <param name="iep"></param>
        /// <returns></returns>
        public bool DeleteStudent(Students student, Students iep)
        {
            bool result = false;

            try
            {
                result = (1 == _studentAccessor.DeleteStudent(student, iep));
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }


        public List<Students> SelectStudentsBySLPID(string slpID)
        {
            List<Students> students = null;
            try
            {
                students = _studentAccessor.SelectStudentsBySLPID(slpID);
            }
            catch (Exception)
            {
                throw;
            }
            return students;
        }

        public Students SelectStudentIEP(string studentID)
        {
            
            try
            {
                return _studentAccessor.SelectStudentIEP(studentID);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public List<string> SelectAllStates()
        {
            List<string> states = null;

            try
            {
                states = _studentAccessor.SelectAllStates();
            }
            catch (Exception)
            {
                throw;
            }
            return states;
        }

        public bool DeactivateIEP(Students iep)
        {
            try
            {
                return (1 == _studentAccessor.DeactivateIEP(iep));
            }
            catch (Exception)
            {
                throw;
            }

        }


        public bool ActivateIEP(Students iep)
        {
            try
            {
                return (1 == _studentAccessor.ActivateIEP(iep));
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
