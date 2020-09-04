﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLibrary.DataAccess;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCCoreUI.Models;

namespace MVCCoreUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentData _db;

        public HomeController(ILogger<HomeController> logger, IStudentData db)
        {
            _logger = logger;
            _db = db;
        }

        [Authorize(Roles = "Admin, User")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [Authorize(Roles = "Admin")]
        public IActionResult AddStudent(StudentDisplayModel student)
        {
            if (ModelState.IsValid)
            {
                StudentModel newStudent = new StudentModel
                {
                    StudentId = student.StudentId,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Email = student.Email
                };

                _db.InsertStudent(newStudent);

                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> ViewStudents()
        {
            var data = await _db.GetStudents();

            List<StudentDisplayModel> students = new List<StudentDisplayModel>();

            foreach (var row in data)
            {
                students.Add(new StudentDisplayModel
                {
                    StudentId = row.StudentId,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    Email = row.Email
                });
            }

            return View(students);
        }
    }
}
