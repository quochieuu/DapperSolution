using Dapper;
using DapperDemo.API.Entities;
using DapperDemo.API.Infrastructure;
using System.Data.SqlClient;

namespace DapperDemo.API.Bussiness
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IConfiguration _configuration;

        public CategoryRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<int> Add(Category entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedDate = DateTime.Now;
            var sql = "INSERT INTO Categories (Id, Name, ParentId, Status, CreatedDate) Values (@Id, @Name, @ParentId, @Status, @CreatedDate);";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                connection.Open();
                var affectedRows = await connection.ExecuteAsync(sql, entity);
                return affectedRows;
            }
        }

        public async Task<int> Delete(Guid id)
        {
            var sql = "DELETE FROM Categories WHERE Id = @Id;";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                connection.Open();
                var affectedRows = await connection.ExecuteAsync(sql, new { Id = id });
                return affectedRows;
            }
        }

        public async Task<Category> Get(Guid id)
        {
            var sql = "SELECT * FROM Categories WHERE Id = @Id;";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Category>(sql, new { Id = id });
                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var sql = "SELECT * FROM Categories;";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Category>(sql);
                return result;
            }
        }

        public async Task<int> Update(Category entity)
        {
            var sql = "UPDATE Categories SET Name = @Name, ParentId  = @ParentId, Status = @Status WHERE Id = @Id;";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                connection.Open();
                var affectedRows = await connection.ExecuteAsync(sql, entity);
                return affectedRows;
            }
        }
    }
}
