using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class School
    {
        //        [NCESID] [nvarchar] (20)			  NOT NULL,

        //        [Name]          [nvarchar] (50)			  NOT NULL,

        //        [Address]       [nvarchar] (30)			  NOT NULL,

        //        [City]          [nvarchar] (30)			  NOT NULL,

        //        [State]         [nvarchar] (2)			  NOT NULL,

        //        [ZipCode]       [int]					  NOT NULL,


        public string NCESID { get; set; }
        public string SchoolName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
    }
}
