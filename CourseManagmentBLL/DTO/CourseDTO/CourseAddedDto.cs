using System.ComponentModel.DataAnnotations;

namespace CourseManagmentBLL.DTO.CourseDTO
{
    public class CourseAddedDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
    }
}
