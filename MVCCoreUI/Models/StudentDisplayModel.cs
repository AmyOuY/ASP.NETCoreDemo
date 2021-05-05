using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreUI.Models
{
    public class StudentDisplayModel
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [Display(Name = "Student ID")]
        [Range(100000, 999999, ErrorMessage = "You need to enter a Valid Student Id.")]
        public int StudentId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "First Name is between 2 to 20 letters.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Last Name is between 2 to 20 letters.")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
