using System;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DAL.Repository
{
    public class BaseRepository
    {
        internal SqlConnection _connection;//{ get => CreateConnection(); }

        IConfiguration _config;
        private string _connectionString;

        public BaseRepository(IConfiguration config)
        {
            _config = config;

            _connectionString = _config.GetConnectionString("Default");
            _connection = CreateConnection();
        }

        protected SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
