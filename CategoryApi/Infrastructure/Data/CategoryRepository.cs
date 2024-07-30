using Core.Entities;
using Core.Interfaces;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly string _connectionString;

        public CategoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.QueryAsync<Category>("SELECT * FROM Categories");
            }
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<Category>("SELECT * FROM Categories WHERE Id = @Id", new { Id = id });
            }
        }

        public async Task AddAsync(Category category)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var sql = "INSERT INTO Categories (Name, Description) VALUES (@Name, @Description)";
                await connection.ExecuteAsync(sql, category);
            }
        }

        public async Task UpdateAsync(Category category)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var sql = "UPDATE Categories SET Name = @Name, Description = @Description WHERE Id = @Id";
                await connection.ExecuteAsync(sql, category);
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var sql = "DELETE FROM Categories WHERE Id = @Id";
                await connection.ExecuteAsync(sql, new { Id = id });
            }
        }
    }
}