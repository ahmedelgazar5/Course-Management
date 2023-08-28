using System.ComponentModel.DataAnnotations;

namespace CourseManagmentBLL.DTO.AccountDto
{
    public class CoursesLoginDto
    {
        [Required]
        //[EmailAddress]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
