using CleanArchitucture.Application.Interfaces;
using CleanArchitucture.Domain.Entities;
using CleanArchitucture.Sql.Queries;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitucture.Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _dbConnection;

        public ContactRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbConnection = _configuration.GetConnectionString("DBConnection")!;
        }
        public async Task<IReadOnlyList<Contact>> GetAllAsync()
        {
            using (IDbConnection connection = new SqlConnection(_dbConnection))
            {
                connection.Open();
                var result = await connection.QueryAsync<Contact>(ContactQueries.AllContact);
                return result.ToList();
            }
        }
        public async Task<Contact> GetByIdAsync(int id)
        {
            using (IDbConnection connection = new SqlConnection(_dbConnection))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Contact>(ContactQueries.ContactById, new { ContactId = id });
                return result;
            }
        }

        public async Task<string> AddAsync(Contact entity)
        {
            using (IDbConnection connection = new SqlConnection(_dbConnection))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(ContactQueries.AddContact, entity);
                return result.ToString();
            }
        }

        public async Task<string> UpdateAsync(Contact entity)
        {
            using (IDbConnection connection = new SqlConnection(_dbConnection))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(ContactQueries.UpdateContact, entity);
                return result.ToString();
            }
        }

        public async Task<string> DeleteAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(_dbConnection))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(ContactQueries.DeleteContact, new { ContactId = id });
                return result.ToString();
            }
        }

      
    }
}
