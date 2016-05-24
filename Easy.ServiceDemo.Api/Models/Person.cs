using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.ServiceDemo.Api.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }

        public float Height { get; set; }

        public float Weight { get; set; }

        public string Occupation { get; set; }
    }
}
