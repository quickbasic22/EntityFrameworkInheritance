using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameworkInheritance.Models
{
    public class TPTOfflineCourse: TPTCourse
    {
        public string Address { get; set; }
    }
}