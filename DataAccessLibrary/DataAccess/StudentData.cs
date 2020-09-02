using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
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


        public Task<List<StudentModel>> GetStudents()
        {
            string sql = @"select * from dbo.Student";

            return _db.LoadData<StudentModel, dynamic>(sql, new { });
        }


        public Task InsertStudent(StudentModel student)
        {
            string sql = @"insert into dbo.Student (StudentId, FirstName, LastName, Email)
                            values (@StudentId, @FirstName, @LastName, @Email);";

            return _db.SaveData<StudentModel>(sql, student);
        }
    }
}
