using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CG.DataAccess
{
    /// <inheritdoc/>
    public class DAL : IDAL
    {
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="DAL"/> class with the passed <paramref
        /// name="connectionString"/>.
        /// </summary>
        /// <param name="connectionString">
        /// The connection string to use for any <see cref="SqlConnection"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the passed <paramref name="connectionString"></paramref> is <see
        /// langword="null"/>.
        /// </exception>
        public DAL(string connectionString)
        {
            _connectionString =
                connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        /// <inheritdoc/>
        public void ExecuteStoredProcedure(
            string storedProcedureName,
            IDictionary<string, object> parameters
        )
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (
                SqlCommand command = new SqlCommand(storedProcedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure,
                }
            )
            {
                connection.Open();
                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
                command.ExecuteNonQuery();
            }
        }

        /// <inheritdoc/>
        public object GetValueFromStoredProcedure(
            string storedProcedureName,
            IDictionary<string, object> parameters
        )
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (
                SqlCommand command = new SqlCommand(storedProcedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                }
            )
            {
                connection.Open();
                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
                return command.ExecuteScalar();
            }
        }

        /// <inheritdoc/>
        public DataTable GetTableFromStoredProcedure(
            string storedProcedureName,
            IDictionary<string, object> parameters
        )
        {
            DataTable resultTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (
                SqlCommand command = new SqlCommand(storedProcedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                }
            )
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                connection.Open();
                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
                // Get the first DataTable in the result DataSet
                adapter.Fill(resultTable);
            }
            return resultTable;
        }
    }
}
