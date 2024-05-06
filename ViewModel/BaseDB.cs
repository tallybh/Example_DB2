using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public abstract class BaseDB
    {
        protected string _connectionString = @"Data Source=DESKTOP-LEQ9VV2\SQLEXPRESS;Initial Catalog=TZ_DB_WPF;Integrated Security=True";
        protected SqlConnection _connection;
        protected SqlCommand _command;
        protected SqlDataReader _reader;
        protected string _tableName;

        public BaseDB(string tableName)
        {
            _tableName = tableName;
            _connection = new SqlConnection(_connectionString);
            _command = new SqlCommand();
            _command.Connection = _connection;
        }
    }
}
