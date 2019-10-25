using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameworkInheritance.Models
{
    public class TPCOnlineCourse: TPCCourse
    {
        public string URL { get; set; }
    }
}