using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelancr
{
    class Client
    {
        public Client(int xid, string xfname, string xlname, string xnumber, string xcompany)
        {
            this.id = xid;
            this.fname = xfname;
            this.lname = xlname;
            this.phonenumber = xnumber;
            this.company = xcompany;
        }

        public int id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string phonenumber { get; set; }
        public string company { get; set; }
    }
}
