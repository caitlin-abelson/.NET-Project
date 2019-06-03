using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class TeacherUser
    {
        public string TeacherID { get;  set; }
        public string NCESID { get;  set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string Email { get; set; }
        public List<string> TeacherUsers { get;  set; }

        public TeacherUser(string teacherID, string ncesID, string firstName, string lastName, List<string> teacherUsers)
        {
            TeacherID = teacherID;
            NCESID = ncesID;
            FirstName = firstName;
            LastName = lastName;
            TeacherUsers = teacherUsers;
        }

        public TeacherUser(string teacherID, string firstName, string lastName)
        {
            TeacherID = teacherID;
            FirstName = firstName;
            LastName = lastName;
        }
        public TeacherUser()
        {

        }
    }
}
