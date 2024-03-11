using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session2.Model
{
    public class Person
    {
        public int personCode { get; set; }

        public string personRole { get; set; }

        public int lastSecurityPointNumber { get; set; }

        public string lastSecurityPointDirection { get; set; }

        public DateTime lastSecurityPointTime { get; set; }
    }
}
