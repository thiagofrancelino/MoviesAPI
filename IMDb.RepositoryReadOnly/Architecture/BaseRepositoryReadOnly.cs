﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace IMDb.RepositoryReadOnly.Architecture
{
    public abstract class BaseRepositoryReadOnly
    {
        private readonly string _connectionString = "Password=yourStrong(!)Password;Persist Security Info=True;User ID=sa;Initial Catalog=Teste1;Data Source=localhost";        

        protected async Task<T> WithConnection<T>(Func<IDbConnection, Task<T>> getData)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    return await getData(connection);
                }
            }
            catch (TimeoutException ex)
            {
                throw new Exception(string.Format("{0}.WithConnection() experienced a SQL timeout", GetType().FullName), ex);
            }
            catch (SqlException ex)
            {
                throw new Exception(string.Format("{0}.WithConnection() experienced a SQL exception (not a timeout)", GetType().FullName), ex);
            }
        }
    }
}
