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
    public class AddStudentModel : PageModel
    {
        private readonly IStudentData _data;

        public AddStudentModel(IStudentData data)
        {
            _data = data;
        }


        [BindProperty]
        public StudentDisplayModel Student { get; set; }
  
        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            StudentModel newStudent = new StudentModel
            {
                StudentId = Student.StudentId,
                FirstName = Student.FirstName,
                LastName = Student.LastName,
                Email = Student.Email
            };

            _data.InsertStudent(newStudent);

            Student = new StudentDisplayModel();

            return RedirectToPage("/Index");
        }
    }
}