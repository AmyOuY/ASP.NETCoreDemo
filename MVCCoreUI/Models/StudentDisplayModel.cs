using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreUI.Models
{
    public class StudentDisplayModel
    {
        [Required]
        [Range(100000, 999999, ErrorMessage = "You need to enter a Valid Student Id.")]
        public int StudentId { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "First Name is between 2 to 20 letters.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Last Name is between 2 to 20 letters.")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
