using Model;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace ViewModel
{
    public class CityDB:BaseDB
    {
        

        public CityDB():base("tbl_Users") 
        {
            
        }


        public CityList SelectAll()
        {
            _command.CommandText = $"SELECT * FROM {_tableName} ";
            CityList lst = Select();
            return lst;
        }

        public City SelectById(int id)
        {
            _command.CommandText = $"SELECT * FROM {_tableName} where CityID = {id}";
            CityList lst = Select();
            return lst.FirstOrDefault();
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
                    city.Name = _reader["CityName"].ToString();
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