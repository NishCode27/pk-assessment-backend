using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PkAssessmentAPI.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        protected readonly string _connectionString;
        protected readonly string _tableName;

        protected GenericRepository(IConfiguration configuration, string tableName)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") 
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            _tableName = tableName;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string query, object? parameters = null)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(query, connection);
            AddParameters(command, parameters);

            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();
            return MapToList(reader);
        }

        public async Task<T?> GetFirstOrDefaultAsync(string query, object? parameters = null)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(query, connection);
            AddParameters(command, parameters);

            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();
            return MapToList(reader).FirstOrDefault();
        }

        public async Task<int> ExecuteAsync(string query, object? parameters = null)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(query, connection);
            AddParameters(command, parameters);

            await connection.OpenAsync();
            return await command.ExecuteNonQueryAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            var query = $"SELECT * FROM {_tableName}";
            return await GetAllAsync(query);
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            var query = $"SELECT * FROM {_tableName} WHERE Id = @Id";
            return await GetFirstOrDefaultAsync(query, new { Id = id });
        }

        public abstract Task<int> AddAsync(T entity);
        public abstract Task<int> UpdateAsync(T entity);

        public virtual async Task<int> DeleteAsync(int id)
        {
            var query = $"DELETE FROM {_tableName} WHERE Id = @Id";
            return await ExecuteAsync(query, new { Id = id });
        }

        protected void AddParameters(SqlCommand command, object? parameters)
        {
            if (parameters == null) return;

            foreach (var prop in parameters.GetType().GetProperties())
            {
                command.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(parameters) ?? DBNull.Value);
            }
        }

        protected List<T> MapToList(IDataReader reader)
        {
            var list = new List<T>();
            var properties = typeof(T).GetProperties();

            while (reader.Read())
            {
                var item = new T();
                foreach (var prop in properties)
                {
                    try
                    {
                        var ordinal = reader.GetOrdinal(prop.Name);
                        if (!reader.IsDBNull(ordinal))
                        {
                            prop.SetValue(item, reader.GetValue(ordinal));
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        // Column not found in reader, skip
                    }
                }
                list.Add(item);
            }
            return list;
        }
    }
}
