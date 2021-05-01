using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataAccess
{
    public interface IStudentData
    {
        Task<List<StudentModel>> GetStudents();
        Task InsertStudent(StudentModel student);
        Task<StudentModel> GetStudentById(int studentId);
    }
}