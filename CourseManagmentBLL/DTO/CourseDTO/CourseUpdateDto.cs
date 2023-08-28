using CourseManagmentBLL.DTO.SessionsDto;
using System.ComponentModel.DataAnnotations;

namespace CourseManagmentBLL.DTO.CourseDTO
{
    public class CourseUpdateDto
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        [Required]
        public int CourseTypeId { get; set; }
        [Required]
        [Range(100, 1000)]
        public int Price { get; set; }
        public int CourseLevelId { get; set; }
    }
}
