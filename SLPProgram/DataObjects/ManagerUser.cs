using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class ManagerUser
    {
        public string ManagerID { get;  set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string Email { get; set; }
        public List<string> ManagerUsers { get;  set; }

        public ManagerUser(string managerID, string firstName, string lastName, List<string> managerUsers)
        {
            ManagerID = managerID;
            FirstName = firstName;
            LastName = lastName;
            ManagerUsers = managerUsers;
        }

        public ManagerUser(string managerID, string firstName, string lastName)
        {
            ManagerID = managerID;
            FirstName = firstName;
            LastName = lastName;
        }

        public ManagerUser()
        {
           
        }
    }
}
