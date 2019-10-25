using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameworkInheritance.Models
{
    public class TPHOnlineCourse: TPHCourse
    {
        public string URL { get; set; }
    }
}