using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccess
{
    public class StudentAccessorMock : IStudentAccessor
    {
        List<Students> _students;
        List<string> _allStudents;

        private List<SLPUser> _slp;
        private List<string> _allSLPs;
        private List<string> _grades;
        private List<States> _statesCSV;
        private List<string> _states;
        private List<string> _teachers;
        private List<string> _iepTypes;
        private List<string> _goals;
        private List<string> _schools;

        DateTime birthday = new DateTime(2001, 03, 12);
        DateTime iepDate = DateTime.Now.AddDays(10);

        public StudentAccessorMock()
        {
            _students = new List<Students>();
            _students.Add(new Students()
            {
                StudentId = "K7976L668",
                SchoolName = "Prairie Lake",
                NCESId = "A9787",
                Birthday = birthday,
                TeacherID = "Karen.Prairie",
                Grade = "5th",
                FirstName = "Peter",
                LastName = "Parker",
                IEPType = "Initial",
                IEPdate = iepDate,
                IEPLeaderFirstName = "Karen",
                IEPLeaderLastName = "Peterson",
                IEPNotes = "IEP notes.",
                Address = "123 Fake Street",
                City = "Fake City",
                State = "IA",
                ZipCode = "12345",
                Active = true,
                GoalType = "MLU"
            });
            _students.Add(new Students()
            {
                StudentId = "J891P4415",
                SchoolName = "Prairie Lake",
                NCESId = "A9787",
                Birthday = birthday,
                TeacherID = "Karen.Prairie",
                Grade = "5th",
                FirstName = "Jill",
                LastName = "Patterson",
                IEPType = "Initial",
                IEPdate = iepDate,
                IEPLeaderFirstName = "Karen",
                IEPLeaderLastName = "Peterson",
                IEPNotes = "IEP notes.",
                Address = "456 Fake Ave",
                City = "Fake Town",
                State = "IA",
                ZipCode = "45678",
                Active = true,
                GoalType = "Phonology"
            });

            _allStudents = new List<string>();
            foreach (var student in _students)
            {
                _allStudents.Add(student.StudentId);
            }


            _slp = new List<SLPUser>();
            _slp.Add(new SLPUser() { SLPID = "J15181", FirstName = "Jane", LastName = "Doe", ManagerId = "A51651", Email = "Jane@gmail.com" });
            _slp.Add(new SLPUser() { SLPID = "J89819", FirstName = "Jack", LastName = "Skellington", ManagerId = "A51651", Email = "Jack@gmail.com" });
            _slp.Add(new SLPUser() { SLPID = "L91568", FirstName = "Link", LastName = "Fairy", ManagerId = "A51651", Email = "Link@gmail.com" });

            _allSLPs = new List<string>();
            foreach (var slp in _slp)
            {
                _allSLPs.Add(slp.SLPID);
            }

        }

        public int ActivateIEP(Students iep)
        {
            throw new NotImplementedException();
        }

        public bool CreateNewStudent(Students student, SLPUser slp, TeacherUser teacher)
        {
            bool result = false;
            _students.Add(student);
            if (_students.Contains(student))
            {
                result = true;
            }
            return result;
        }

        public int CreateNewStudentIEP(Students student, SLPUser slp)
        {
            int result = 0;
            _students.Add(student);
            if (_students.Contains(student))
            {
                result = 1;
            }
            return result;
        }

        public int DeactivateIEP(Students iep)
        {
            throw new NotImplementedException();
        }

        public int DeleteStudent(Students student, Students iep)
        {
            int result = 0;
            Students students = new Students();
            Students ieps = new Students();

            students = _students.Find(x => x.StudentId.Equals(student));
            iep = _students.Find(x => x.StudentId.Equals(iep));

            if (students == null && iep == null)
            {
                throw new ArgumentException("IDs did not match.");
            }
            else
            {
                result = 1;
            }

            return result;
        }

        // for combo box for the WPF
        public List<States> RetrieveStates()
        {
            return _statesCSV;
        }

        // for combo box
        public List<string> SelectAllGrades()
        {
            return _grades;
        }

        // combo box for the MVC Web Application
        public List<string> SelectAllStates()
        {
            return _states;
        }

        public List<string> SelectAllStudentIEPTypes()
        {
            return _iepTypes;
        }

        // for combo box
        public List<string> SelectGoalTypes()
        {
            return _goals;
        }

        // for combo box
        public List<string> SelectSchools()
        {
            return _schools;
        }

        public Students SelectStudentIEP(string studentId)
        {
            return _students.Find(x => x.StudentId == studentId);
        }

        public List<Students> SelectStudents()
        {
            return _students;
        }

        public List<Students> SelectStudentsBySLPID(string slpID)
        {
            throw new NotImplementedException();
        }

        public List<Students> SelectStudentsByTeacherID(string teacherID)
        {
            List<Students> student = new List<Students>();
            foreach (var item in _students)
            {
                if (item.TeacherID == teacherID)
                {
                    student.Add(_students.Find(x => x.TeacherID == teacherID));
                }
            }

            return student;
        }

        public List<string> SelectTeacherName()
        {
            return _teachers; 
        }

        public int UpdateIEP(Students oldIEP, Students newIEP)
        {
            int result = 0;
            foreach (var student in _students)
            {
                if (oldIEP.StudentId == newIEP.StudentId)
                {
                    student.IEPType = newIEP.IEPType;
                    student.IEPdate = newIEP.IEPdate;
                    student.IEPLeaderFirstName = newIEP.IEPLeaderFirstName;
                    student.IEPLeaderLastName = newIEP.IEPLeaderLastName;
                    student.GoalType = newIEP.GoalType;
                    student.IEPNotes = newIEP.IEPNotes;
                    student.Active = newIEP.Active;

                    result++;
                }

                if (result == 0)
                {
                    throw new ArgumentException("Student not found.");
                }
            }

            return result;
        }
    }
}
