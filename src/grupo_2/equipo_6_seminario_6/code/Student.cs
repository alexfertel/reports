using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminario6_Lp
{
    public class Student
    {
        public string Name { get; set; }

        public int Group { get; set; }

        public Student(string name, int group)
        {
            Name = name;
            Group = group;
        }
    }
}
