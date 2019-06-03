using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataObjects
{
    public class Students
    {
        public Students()
        {
        }



        [Required]
        public string StudentId { get; set; }
        public string SchoolName { get; set; }
        public string NCESId { get; set; }
        public DateTime Birthday { get; set; }
        public string TeacherID { get; set; }
        public string Grade { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IEPType { get; set; }
        public DateTime IEPdate { get; set; }
        public string IEPLeaderFirstName { get; set; }
        public string IEPLeaderLastName { get; set; }
        public string IEPNotes { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public bool Active { get; set; }
        public string GoalType { get; set; }
        public string SLPID { get; set; }
        public int IEPID { get; set; }

    }
}
