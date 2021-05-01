using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataAccess
{
    public class StudentData : IStudentData
    {
        private readonly ISqlDataAccess _db;

        public StudentData(ISqlDataAccess db)
        {
            _db = db;
        }


        public async Task<List<StudentModel>> GetStudents()
        {
            string sql = @"select * from dbo.Student";

            var results = await _db.LoadData<StudentModel, dynamic>(sql, new { });

            return results;
        }


        public async Task InsertStudent(StudentModel student)
        {
            string sql = @"insert into dbo.Student (StudentId, FirstName, LastName, Email)
                            values (@StudentId, @FirstName, @LastName, @Email);";

            await _db.SaveData(sql, student);
        }


        public async Task<StudentModel> GetStudentById(int studentId)
        {
            string sql = @"select * from dbo.Student where StudentId = @studentId";

            var results = await _db.LoadData<StudentModel, dynamic>(sql, new { studentId });

            return results.FirstOrDefault();
        }
    }
}
