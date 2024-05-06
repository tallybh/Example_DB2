using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class StudentDB
    {
        private string _connectionString = @"Data Source=DESKTOP-LEQ9VV2\SQLEXPRESS;Initial Catalog=TZ_DB_WPF;Integrated Security=True";
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;

        public StudentDB()
        {
            _connection = new SqlConnection(_connectionString);
            _command = new SqlCommand();
            _command.Connection = _connection;
        }

        public StudentList SelectALL()
        {
            _command.CommandText = "SELECT a.*, b.ClassId from PeopleTbl a join StudentTbl b on a.ID = b.ID";
            StudentList lst = Select();
            return lst;
        }

        public StudentList SelectByID(int id)
        {
            _command.CommandText = string.Format("SELECT a.*, b.ClassId from PeopleTbl a join StudentTbl b on a.ID = b.ID " +
                "WHERE a.id = {0}", id);
            StudentList lst = Select();
            return lst;
        }

        public StudentList SelectByName(string firstName, string lastName)
        {
            _command.CommandText = string.Format("SELECT a.*, b.ClassId from PeopleTbl a join StudentTbl b on a.ID = b.ID " +
                "WHERE a.FirstName = {0} and a.LastName = {1}", firstName, lastName);
            StudentList lst = Select();
            return lst;
        }

        public StudentList Select()
        {
            StudentList list = new StudentList();
            try
            {
                _command.Connection = _connection;
                _connection.Open();

                _reader = _command.ExecuteReader(); ;
                Student student;

                while (_reader.Read())
                {
                    student = new Student();
                    student.Id = (int)_reader["ID"];
                    student.FirstName = (string)_reader["FirstName"].ToString();
                    student.LastName = (string)_reader["LastName"].ToString();
                    string cc = "N/A";
                    if (_reader["city"] != DBNull.Value)
                    {
                        int city = (int)_reader["City"];
                        CityDB c = new CityDB();
                        student.City = c.SelectById(city);
                        cc = student.City.Name;
                    }
                    student.Address = (string)_reader["Address"].ToString() + " , " + cc;
                    if (_reader["ClassId"] != DBNull.Value)
                    {
                        int cls = (int)_reader["ClassId"];
                        ClassDB c = new ClassDB();
                        student.Class = c.SelectById(cls);
                    }

                    list.Add(student);
                }
            }
            catch (Exception ex) 
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (_reader != null)
                    _reader.Close();
                if(_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }

            return list;
        }
    }
}
