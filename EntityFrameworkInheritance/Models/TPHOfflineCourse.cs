using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameworkInheritance.Models
{
    public class TPHOfflineCourse: TPHCourse
    {
        public string Address { get; set; }
    }
}