using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Student : People
    {
        private ClassData _class;
        private LessonList _lessons;

        public ClassData Class { get => _class; set => _class = value; }
        public LessonList Lessons { get => _lessons; set => _lessons = value; }
        public LessonList FinishedCourses
        {
            get
            {
                List<LessonData> lst = _lessons.FindAll(lesson => lesson.Grade >= 60).ToList();
                return new LessonList(lst);
            }
        }
    }
}
