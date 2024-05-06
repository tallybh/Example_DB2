using Model;
using System;
using System.Data.SqlClient;

namespace ViewModel
{
    public class CityDB
    {
        private string _connectionString = @"Data Source=DESKTOP-LEQ9VV2\SQLEXPRESS;Initial Catalog=TZ_DB_WPF;Integrated Security=True";
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;

        public CityDB()
        {
            _connection = new SqlConnection(_connectionString);
            _command = new SqlCommand();
            _command.Connection = _connection;
        }


        public CityList SelectAll()
        {
            _command.CommandText = "SELECT * FROM CityTbl ";
            CityList lst = Select();
            return lst;
        }

        public City SelectById(int id)
        {
            _command.CommandText = string.Format("SELECT * FROM CityTbl where CityID = {0}", id);
            CityList lst = Select();
            if (lst.Count > 0)
            {
                return lst[0];
            }
            return null;
        }


        public CityList Select()
        {
            CityList list = new CityList();
            try
            {
                _command.Connection = _connection;
                _connection.Open();

                _reader = _command.ExecuteReader(); ;
                City city;

                while (_reader.Read())
                {
                    city = new City();
                    city.Id = (int)_reader["CityID"];
                    city.Name = (string)_reader["CityName"].ToString();
                    list.Add(city);
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