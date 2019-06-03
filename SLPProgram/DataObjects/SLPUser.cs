using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    //Data Transfer class
    public class SLPUser
    {
        public string SLPID { get;  set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string Email { get; set; }
        public string ManagerId { get;  set; }
        public List<string> SLPUsers { get;  set; }


        public SLPUser(string slpID, string firstName, string lastName, string managerId, List<string> slpUsers)
        {
            SLPID = slpID;
            FirstName = firstName;
            LastName = lastName;
            ManagerId = managerId;
            SLPUsers = slpUsers;
        }

        public SLPUser(string slpID, string firstName, string lastName)
        {
            SLPID = slpID;
            FirstName = firstName;
            LastName = lastName;
        }

        public SLPUser()
        {

        }
    }
}
