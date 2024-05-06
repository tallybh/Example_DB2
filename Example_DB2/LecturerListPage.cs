using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Example_DB2
{
    internal partial class LecturerListPage : PeopleListPage
    {
        public LecturerListPage()
        {
            this.Title.Text = "LecturerList";
            this.ClsCol.Width = 0;
        }
        protected override List<People> GetList()
        {
            LecturerDB db = new LecturerDB();
            LecturerList list = db.SelectALL();
            return list.Cast<People>().ToList();
        }
    }
}
