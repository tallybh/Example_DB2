using Model;
using System.Data.SqlClient;
using System;

namespace ViewModel
{
    internal class ClassDB
    {
        private string _connectionString = @"Data Source=DESKTOP-LEQ9VV2\SQLEXPRESS;Initial Catalog=TZ_DB_WPF;Integrated Security=True";
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;

        public ClassDB()
        {
            _connection = new SqlConnection(_connectionString);
            _command = new SqlCommand();
            _command.Connection = _connection;
        }


        public ClassList SelectAll()
        {
            _command.CommandText = "SELECT * FROM ClassTbl ";
            ClassList lst = Select();
            return lst;
        }

        public ClassData SelectById(int id)
        {
            _command.CommandText = string.Format("SELECT * FROM ClassTbl where ClassId = {0}", id);
            ClassList lst = Select();
            if (lst.Count > 0)
            {
                return lst[0];
            }
            return null;
        }


        public ClassList Select()
        {
            ClassList list = new ClassList();
            try
            {
                _command.Connection = _connection;
                _connection.Open();

                _reader = _command.ExecuteReader(); ;
                ClassData classData;

                while (_reader.Read())
                {
                    classData = new ClassData();
                    classData.Id = (int)_reader["ClassId"];
                    classData.ClassName = (string)_reader["ClassName"].ToString();
                    classData.RoomNumber = (int)_reader["RoomNumber"];
                    list.Add(classData);
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
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }

            return list;
        }
    }
}