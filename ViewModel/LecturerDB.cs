using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class LecturerDB
    {
        private string _connectionString = @"Data Source=DESKTOP-LEQ9VV2\SQLEXPRESS;Initial Catalog=TZ_DB_WPF;Integrated Security=True";
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;

        public LecturerDB()
        {
            _connection = new SqlConnection(_connectionString);
            _command = new SqlCommand();
            _command.Connection = _connection;
        }

        public LecturerList SelectALL()
        {
            _command.CommandText = "SELECT a.*, b.Experience from PeopleTbl a join LecturerTbl b on a.ID = b.ID";
            LecturerList lst = Select();
            return lst;
        }

        public LecturerList SelectByID(int id)
        {
            _command.CommandText = string.Format("SELECT a.*, b.Experience from PeopleTbl a join LecturerTbl b on a.ID = b.ID " +
                "WHERE a.id = {0}", id);
            LecturerList lst = Select();
            return lst;
        }

        public LecturerList SelectByName(string firstName, string lastName)
        {
            _command.CommandText = string.Format("SELECT a.*, b.Experience from PeopleTbl a join LecturerTbl b on a.ID = b.ID " +
                "WHERE a.FirstName = {0} and a.LastName = {1}", firstName, lastName);
            LecturerList lst = Select();
            return lst;
        }

        public LecturerList Select()
        {
            LecturerList list = new LecturerList();
            try
            {
                _command.Connection = _connection;
                _connection.Open();

                _reader = _command.ExecuteReader(); ;
                Lecturer Lecturer;

                while (_reader.Read())
                {
                    Lecturer = new Lecturer();
                    Lecturer.Id = (int)_reader["ID"];
                    Lecturer.FirstName = (string)_reader["FirstName"].ToString();
                    Lecturer.LastName = (string)_reader["LastName"].ToString();
                    string cc = "N/A";
                    if (_reader["city"] != DBNull.Value)
                    {
                        int city = (int)_reader["City"];
                        CityDB c = new CityDB();
                        Lecturer.City = c.SelectById(city);
                        cc = Lecturer.City.Name;
                    }
                    Lecturer.Address = (string)_reader["Address"].ToString() + " , " + cc;
                    if (_reader["Experience"] != DBNull.Value)
                        Lecturer.Experience = (double)_reader["Experience"];

                    list.Add(Lecturer);
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
