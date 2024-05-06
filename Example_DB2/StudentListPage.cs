using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Example_DB2
{
    internal partial class StudentListPage : PeopleListPage
    {
        public StudentListPage()
        {
            this.Title.Text = "StudentList";
            this.ExpCol.Width = 0;
        }
        protected override List<People> GetList()
        {
            StudentDB db = new StudentDB();
            StudentList list = db.SelectALL();
            return list.Cast<People>().ToList();
        }
    }
}
