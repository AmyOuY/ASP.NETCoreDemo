using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLibrary.DataAccess;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesUI.Models;

namespace RazorPagesUI.Pages.Forms
{
    public class ViewStudentsModel : PageModel
    {
        private readonly IStudentData _data;

        public ViewStudentsModel(IStudentData data)
        {
            _data = data;
        }


        [BindProperty]
        public List<StudentDisplayModel> Students { get; set; } = new List<StudentDisplayModel>();
        public async Task<IActionResult> OnGet()
        {
            List<StudentModel> allStudents = await _data.GetStudents();

            foreach (var row in allStudents)
            {
                Students.Add(new StudentDisplayModel
                {
                    StudentId = row.StudentId,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    Email = row.Email
                });
            }

            return Page();
        }
    }
}