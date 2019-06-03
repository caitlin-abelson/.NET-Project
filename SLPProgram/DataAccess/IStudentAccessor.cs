using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccess
{
    public interface IStudentAccessor
    {
        List<Students> SelectStudents();
        List<Students> SelectStudentsByTeacherID(string teacherID);
        Students SelectStudentIEP(string studentId);
        List<string> SelectAllStudentIEPTypes();
        List<string> SelectAllStates();
        List<string> SelectAllGrades();
        List<string> SelectSchools();
        List<string> SelectGoalTypes();
        List<string> SelectTeacherName();
        List<States> RetrieveStates();
        bool CreateNewStudent(Students student, SLPUser slp, TeacherUser teacher);
        int DeleteStudent(Students student, Students iep);
        int CreateNewStudentIEP(Students student, SLPUser slp);
        int UpdateIEP(Students oldIEP, Students newIEP);
        List<Students> SelectStudentsBySLPID(string slpID);
        int DeactivateIEP(Students iep);
        int ActivateIEP(Students iep);
    }
}
