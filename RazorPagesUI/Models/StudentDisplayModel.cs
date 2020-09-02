using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesUI.Models
{
    public class StudentDisplayModel
    {
        [Required]
        [Range(100000, 999999, ErrorMessage = "You need to enter a valid Id.")]
        public int StudentId { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "You need to provide a long enough First Name.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "You need to provide a long enough Last Name.")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
