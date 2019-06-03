using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccess;
using System.Security.Cryptography;

namespace LogicLayer
{
    public class userManager : IuserManager
    {
        private IUserAccess _userAccess;

        public userManager()
        {
            _userAccess = new UserAccess();
        }

        public SLPUser AuthenticateSLP(string username, string password)
        {
            SLPUser slpUser = null;

            password = HashSHA256(password);

            try
            {
                if(1 == _userAccess.VerifyUsernamePasswordSLP(username, password))
                {
                    slpUser = _userAccess.GetSLPByEmail(username);

                    if(password == HashSHA256("newuser"))
                    {
                        slpUser.SLPUsers.Add("New User");
                    }
                }
                else
                {
                    throw new ApplicationException("The SLP you requested was not found.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("User not validated.", ex);
            }

            return slpUser;
        }

        // want to make method to grab current user that is logged in
        //public string SLPId(SLPUser user)
        //{
        //    SLPUser slp = new SLPUser();

        //    foreach (var item in _userAccess.SelectSLPIds())
        //    {
        //        if(item.Equals(user.SLPID))
        //        {
        //            user.SLPID = slp.SLPID;
        //        }
        //    }

        //    return slp.SLPID;
        //}


        public List<string> SelectSLPIds()
        {
            List<string> slps = new List<string>();

            foreach (var item in _userAccess.SelectSLPIds())
            {
                slps.Add(item);
            }

            return slps;
        }

        public ManagerUser AuthenticateManager(string username, string password)
        {
            ManagerUser managerUser = null;

            password = HashSHA256(password);

            try
            {
                if (1 == _userAccess.VerifyUsernamePasswordManager(username, password))
                {
                    managerUser = _userAccess.GetManagerByEmail(username);

                    if (password == HashSHA256("newuser"))
                    {
                        managerUser.ManagerUsers.Add("New User");
                    }
                }
                else
                {
                    throw new ApplicationException("The Manager you requested was not found.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("User not validated.", ex);
            }

            return managerUser;
        }
        public TeacherUser AuthenticateTeacher(string username, string password)
        {
            TeacherUser teacherUser = null;

            password = HashSHA256(password);

            try
            {
                if (1 == _userAccess.VerifyUsernamePasswordTeacher(username, password))
                {
                    teacherUser = _userAccess.GetTeacherByEmail(username);

                    if (password == HashSHA256("newuser"))
                    {
                        teacherUser.TeacherUsers.Add("New User");
                    }
                }
                else
                {
                    throw new ApplicationException("The Teacher you requested was not found.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("User not validated.", ex);
            }

            return teacherUser;
        }

        public bool UpdatePasswordSLP(string username, string oldPassword, string newPassword)
        {
            bool result = false;

            newPassword = HashSHA256(newPassword);
            oldPassword = HashSHA256(oldPassword);

            try
            {
                result = (1 == _userAccess.UpdatePasswordHashSLP(username, oldPassword, newPassword));
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public bool UpdatePasswordManager(string username, string oldPassword, string newPassword)
        {
            bool result = false;

            newPassword = HashSHA256(newPassword);
            oldPassword = HashSHA256(oldPassword);

            try
            {
                result = (1 == _userAccess.UpdatePasswordHashManager(username, oldPassword, newPassword));
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public bool UpdatePasswordTeacher(string username, string oldPassword, string newPassword)
        {
            bool result = false;

            newPassword = HashSHA256(newPassword);
            oldPassword = HashSHA256(oldPassword);

            try
            {
                result = (1 == _userAccess.UpdatePasswordHashTeacher(username, oldPassword, newPassword));
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public void RefreshSLPUsers(SLPUser slpUser, string email)
        {
            try
            {
                List<string> emails = new List<string>();

                var slpUsers = _userAccess.GetSLPByEmail(email);

                foreach (var slp in emails)
                {
                    slpUsers.SLPUsers.Add(slp);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void RefreshManagerUsers(ManagerUser managerUser, string email)
        {
            try
            {
                List<string> emails = new List<string>();

                var managerUsers = _userAccess.GetManagerByEmail(email);

                foreach (var manager in emails)
                {
                    managerUsers.ManagerUsers.Add(manager);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void RefreshTeacherUsers(TeacherUser teacherUser, string email)
        {
            try
            {
                List<string> emails = new List<string>();

                var teacherUsers = _userAccess.GetTeacherByEmail(email);

                foreach (var teacher in emails)
                {
                    teacherUsers.TeacherUsers.Add(teacher);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool FindSLP(string email)
        {
            bool result = false;

            try
            {
                result = _userAccess.RetrieveSLPByEmail(email) != null;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public string HashSHA256(string source)
        {
            string result = "";

            byte[] data;

            using (SHA256 sha256hash = SHA256.Create())
            {
                data = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(source));
            }

            var s = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                s.Append(data[i].ToString("x2"));
            }

            result = s.ToString();
            return result;
        }

        public bool FindTeacher(string email)
        {
            bool result = false;

            try
            {
                result = _userAccess.RetrieveTeacherByEmail(email) != null;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public bool FindManager(string email)
        {
            bool result = false;

            try
            {
                result = _userAccess.RetrieveManagerByEmail(email) != null;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public string SLPId(SLPUser user)
        {
            throw new NotImplementedException();
        }

        public List<SLPUser> RetrieveSLPs()
        {
            List<SLPUser> slps = new List<SLPUser>();
            try
            {
                slps = _userAccess.RetrieveSLPs();
            }
            catch
            {
                throw;
            }
            return slps;
        }

        public List<TeacherUser> RetrieveTeachers()
        {
            List<TeacherUser> teachers = new List<TeacherUser>();
            try
            {
                teachers = _userAccess.RetrieveTeachers();
            }
            catch
            {
                throw;
            }
            return teachers;
        }
    }
}
