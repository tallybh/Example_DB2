using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LessonList : List<LessonData>
    {
        public LessonList()
        { }
        public LessonList(IEnumerable<LessonData> lst) : base(lst)
        { }
        public LessonList(IEnumerable<BaseEntity> lst) : base(lst.Cast<LessonData>().ToList())
        { }

        public List<LessonData> OrderByGrade()
        {
            if (Count > 0)
            {
                return this.OrderBy(item => item.Grade).ToList();
            }
            return null;
        }
    }
}
