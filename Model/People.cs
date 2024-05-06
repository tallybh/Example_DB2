using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class People : BaseEntity
    {
        private string _fName;
        private string _lName;
        private DateTime _birthDate;
        private Gender _gender;
        private string _address;
        private City _city;

        public string FirstName { get => _fName; set => _fName = value; }
        public string LastName { get => _lName; set => _lName = value; }
        public Gender Gender { get => _gender; set => _gender = value; }
        public City City { get => _city; set => _city = value; }
        public string Address { get => _address; set => _address = value; }
        public DateTime BirthDate { get => _birthDate; set => _birthDate = value; }
    }
}
