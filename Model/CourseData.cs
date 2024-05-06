using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CourseData : BaseEntity
    {
        private string _courseName;

        public string CourseName { get => _courseName; set => _courseName = value; }
    }
}
