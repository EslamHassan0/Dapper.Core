using Dapper.Core.Interfaces;
using Dapper.Core.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Infrastructure.Repositories
{
    public class ProductRepositories : IProductRepsoitory
    {

        private readonly IConfiguration _configuration;

        public ProductRepositories(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> AddAsync(Product entity)
        {
            entity.ModifiedOn = DateTime.Now;
            var sql = "Insert into Products (Name,Description,Barcode,Rate,AddedOn , ModifiedOn) VALUES (@Name,@Description,@Barcode,@Rate,@AddedOn , @ModifiedOn)";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"))) // Free in connection close 
            {
                

                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            };
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "Delete FROM Products where Id =@Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))// Free in connection close 
            {
                var result = await connection.ExecuteAsync(sql,new { Id = id });
                return result;
            } 
        }

        public async Task<IReadOnlyList<Product>> GetAllAsync()
        {
            var sql = "Select * From Products";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))// Free in connection close 
            {
                
                var result = await connection.QueryAsync<Product>(sql);
                return result.ToList() ;
            }
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Products WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))// Free in connection close 
            {
               
                var result = await connection.QueryFirstOrDefaultAsync<Product>(sql , new {Id = id});
                return result;
            }

        }

        public async Task<int> UpdateAsync(Product entity)
        {
            var sql = "UPDATE Products SET Name = @Name, Description = @Description, Barcode = @Barcode, Rate = @Rate, ModifiedOn = @ModifiedOn  WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))// Free in connection close 
            {
               
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
