using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.ServiceDemo.Api.Models
{
    public class Student:Person
    {
        public string School { get; set; }

        public int Score { get; set; } 

        public string Class { get; set; }
    }
}
