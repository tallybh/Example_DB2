using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ClassList : List<ClassData>
    {
        public ClassList()
        { }
        public ClassList(IEnumerable<ClassData> lst) : base(lst)
        { }
        public ClassList(IEnumerable<BaseEntity> lst) : base(lst.Cast<ClassData>().ToList())
        { }
    }
}
