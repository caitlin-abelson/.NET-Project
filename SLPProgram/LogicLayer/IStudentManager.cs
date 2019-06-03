using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayer
{
    public interface IStudentManager
    {
        List<Students> GetStudentsBySlpId(string SLPId);
        List<Students> GetStudents();
        List<Students> GetStudentByTeacherID(string TeacherID);
        List<string> SelectAllStudentIEPTypes();
        List<string> SelectAllStates();
        List<string> RetrieveGrades();
        List<string> RetrieveSchools();
        List<string> RetrieveGoalTypes();
        List<States> States();
        bool CreateNewStudent(Students newStudent, SLPUser slp, TeacherUser teacher);
        bool EditIEP(Students oldIEP, Students newIEP);
        bool DeleteStudent(Students student, Students iep);
        Students SelectStudentIEP(string studentId);
        bool DeactivateIEP(Students iep);
        bool ActivateIEP(Students iep);
    }
}
