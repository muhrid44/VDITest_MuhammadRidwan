using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using VDITest_MuhammadRidwan._1._Data.IRepository;
using VDITest_MuhammadRidwan.Models;

namespace VDITest_MuhammadRidwan._1._Data.Repository
{
    public class MemberRepository : IMemberRepository
    {

        public async Task<List<MemberModel>> GetAll()
        {
            using (var db = new NpgsqlConnection(HelperClass.connectionString))
            {
                var query = await db.QueryAsync<MemberModel>(@"SELECT * FROM ""member""");
                return query.ToList();
            }
        }
        public async Task<MemberModel> GetById(int id)
        {
            using (var db = new NpgsqlConnection(HelperClass.connectionString))
            {
                var query = await db.QueryAsync<MemberModel>($@"SELECT * FROM ""member"" WHERE ""id"" = '{id}' ");
                return query.FirstOrDefault();
            }
        }
        public async Task Create(MemberModel model)
        {
            using (var db = new NpgsqlConnection(HelperClass.connectionString))
            {
                await db.ExecuteAsync(
                    @"INSERT INTO ""member"" 
                    (""name"", ""address"", ""phone"", ""birthplace"", ""birthdate"", ""nik"", ""avatarurl"") 
                    VALUES
                    (@Name, @Address, @Phone, @BirthPlace, @BirthDate, @NIK, @AvatarUrl)
                    ", model);
            }
        }
        public async Task Update(MemberModel model)
        {
            using (var db = new NpgsqlConnection(HelperClass.connectionString))
            {
                await db.ExecuteAsync(
                     @"UPDATE ""member"" SET
                    ""name"" = @Name,
                    ""address"" = @Address,
                    ""phone"" = @Phone,
                    ""birthplace"" = @BirthPlace,
                    ""birthdate"" = @BirthDate,
                    ""nik"" = @NIK,
                    ""avatarurl"" = @AvatarUrl
                    WHERE ""id"" = @Id", model);
            }
        }
        public async Task DeleteById(int id)
        {
            using (var db = new NpgsqlConnection(HelperClass.connectionString))
            {
                await db.ExecuteAsync($@"DELETE FROM ""member""
                    WHERE ""id"" = '{id}' ;");
            }
        }
    }
}
