using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LessonData : BaseEntity
    {
        private Student _student;
        private Lecturer _lecturer;
        private CourseData _course;
        private int _grade;

        public Student Student { get => _student; set => _student = value; }
        public Lecturer Lecturer { get => _lecturer; set => _lecturer = value; }
        public CourseData Course { get => _course; set => _course = value; }
        public int Grade { get => _grade; set => _grade = value; }
    }
}
