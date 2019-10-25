using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameworkInheritance.Models
{
    public class TPCOfflineCourse: TPCCourse
    {
        public string Address { get; set; }
    }
}