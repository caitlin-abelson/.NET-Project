using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccess
{
    public interface IUserAccess
    {
        int VerifyUsernamePasswordSLP(string username, string password);
        int VerifyUsernamePasswordManager(string username, string password);
        int VerifyUsernamePasswordTeacher(string username, string password);
        SLPUser GetSLPByEmail(string email);
        ManagerUser GetManagerByEmail(string email);
        TeacherUser GetTeacherByEmail(string email);
        List<string> SelectSLPIds();
        int UpdatePasswordHashSLP(string email, string oldPassword, string newPassword);
        int UpdatePasswordHashManager(string email, string oldPassword, string newPassword);
        int UpdatePasswordHashTeacher(string email, string oldPassword, string newPassword);
        SLPUser RetrieveSLPByEmail(string email);
        TeacherUser RetrieveTeacherByEmail(string email);
        ManagerUser RetrieveManagerByEmail(string email);
        List<SLPUser> RetrieveSLPs();
        List<TeacherUser> RetrieveTeachers();
    }
}
