using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Lecturer : People
    {
        private double _experience;

        public double Experience { get => _experience; set => _experience = value; }
    }
}
