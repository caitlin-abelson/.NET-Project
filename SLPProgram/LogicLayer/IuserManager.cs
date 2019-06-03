using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayer
{
    public interface IuserManager
    {
        SLPUser AuthenticateSLP(string username, string password);
        string SLPId(SLPUser user);
        ManagerUser AuthenticateManager(string username, string password);
        TeacherUser AuthenticateTeacher(string username, string password);
        bool UpdatePasswordSLP(string username, string oldPassword, string newPassword);
        bool UpdatePasswordManager(string username, string oldPassword, string newPassword);
        bool UpdatePasswordTeacher(string username, string oldPassword, string newPassword);
        void RefreshSLPUsers(SLPUser slpUser, string email);
        void RefreshManagerUsers(ManagerUser managerUser, string email);
        void RefreshTeacherUsers(TeacherUser teacherUser, string email);
        string HashSHA256(string source);
        bool FindSLP(string email);
        bool FindTeacher(string email);
        bool FindManager(string email);
        List<string> SelectSLPIds();
        List<SLPUser> RetrieveSLPs();
        List<TeacherUser> RetrieveTeachers();
    }
}
