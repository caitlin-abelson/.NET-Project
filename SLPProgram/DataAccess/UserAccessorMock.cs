using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccess
{
    public class UserAccessorMock : IUserAccess
    {
        private List<SLPUser> _slp;
        private List<TeacherUser> _teacher;
        private List<ManagerUser> _manager;
        private List<string> _allSLPs;
        private List<string> _allTeachers;
        private List<string> _allManagers;

        public UserAccessorMock()
        {
            // SLP users for Mock
            _slp = new List<SLPUser>();
            _slp.Add(new SLPUser() { SLPID = "J15181", FirstName = "Jane", LastName = "Doe", ManagerId = "A51651", Email = "Jane@gmail.com" });
            _slp.Add(new SLPUser() { SLPID = "J89819", FirstName = "Jack", LastName = "Skellington", ManagerId = "A51651", Email = "Jack@gmail.com" });
            _slp.Add(new SLPUser() { SLPID = "L91568", FirstName = "Link", LastName = "Fairy", ManagerId = "A51651", Email = "Link@gmail.com" });

            _allSLPs = new List<string>();
            foreach (var slp in _slp)
            {
                _allSLPs.Add(slp.SLPID);
            }

            // Teacher users for Mock
            _teacher = new List<TeacherUser>();
            _teacher.Add(new TeacherUser() { TeacherID = "Brooks.Prairie", FirstName = "Brooks", LastName = "Steel", NCESID = "A45D15", Email = "Brooks@school.com" });
            _teacher.Add(new TeacherUser() { TeacherID = "Cher.Prairie", FirstName = "Cher", LastName = "Queen", NCESID = "A45D15", Email = "Cher@school.com" });
            _teacher.Add(new TeacherUser() { TeacherID = "Jenny.Prairie", FirstName = "Jenny", LastName = "Block", NCESID = "A45D15", Email = "Jenny@school.com" });

            _allTeachers = new List<string>();
            foreach (var teacher in _teacher)
            {
                _allTeachers.Add(teacher.TeacherID);
            }

            // Manager users for Mock
            _manager = new List<ManagerUser>();
            _manager.Add(new ManagerUser() { ManagerID = "G14818", FirstName = "George", LastName = "Hanson", Email = "George@gmail.com" });
            _manager.Add(new ManagerUser() { ManagerID = "G14818", FirstName = "George", LastName = "Hanson", Email = "George@gmail.com" });
            _manager.Add(new ManagerUser() { ManagerID = "G14818", FirstName = "George", LastName = "Hanson", Email = "George@gmail.com" });

            _allManagers = new List<string>();
            foreach (var manager in _manager)
            {
                _allTeachers.Add(manager.ManagerID);
            }

        }


        public ManagerUser GetManagerByEmail(string email)
        {
            ManagerUser manager = new ManagerUser();
            manager = _manager.Find(x => x.Email == email);
            if (manager == null)
            {
                throw new ArgumentException("Manager not found.");
            }

            return manager;
        }

        public SLPUser GetSLPByEmail(string email)
        {
            SLPUser slp = new SLPUser();
            slp = _slp.Find(x => x.Email == email);
            if (slp == null)
            {
                throw new ArgumentException("SLP not found.");
            }

            return slp;
        }

        public TeacherUser GetTeacherByEmail(string email)
        {
            TeacherUser teacher = new TeacherUser();
            teacher = _teacher.Find(x => x.Email == email);
            if (teacher == null)
            {
                throw new ArgumentException("Teacher not found.");
            }

            return teacher;
        }

        public ManagerUser RetrieveManagerByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public SLPUser RetrieveSLPByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public List<SLPUser> RetrieveSLPs()
        {
            throw new NotImplementedException();
        }

        public TeacherUser RetrieveTeacherByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public List<TeacherUser> RetrieveTeachers()
        {
            throw new NotImplementedException();
        }

        public List<string> SelectSLPIds()
        {
            List<string> list = new List<string>();
            try
            {
                
                foreach (var item in _slp)
                {
                    list.Add(item.SLPID);
                }
                return list;
            }
            catch
            {
                throw new ArgumentException("SLPID not found.");
            }
            

        }

        public int UpdatePasswordHashManager(string email, string oldPassword, string newPassword)
        {
            int result = 0;

            foreach (var manager in _manager)
            {
                if (manager.Email == email)
                {
                    
                }
            }


            return result;
        }

        public int UpdatePasswordHashSLP(string email, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public int UpdatePasswordHashTeacher(string email, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public int VerifyUsernamePasswordManager(string username, string password)
        {
            throw new NotImplementedException();
        }

        public int VerifyUsernamePasswordSLP(string username, string password)
        {
            throw new NotImplementedException();
        }

        public int VerifyUsernamePasswordTeacher(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
