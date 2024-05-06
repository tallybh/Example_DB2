using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ClassData : BaseEntity
    {
        private string _className;
        private int _roomNumber;

        public int RoomNumber { get => _roomNumber; set => _roomNumber = value; }
        public string ClassName { get => _className; set => _className = value; }
    }
}
