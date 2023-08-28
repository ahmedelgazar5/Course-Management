using CourseManagmentBLL.DTO.LookUpDTO;
using CourseManagmentBLL.DTO.SessionsDto;
using System.ComponentModel.DataAnnotations;

namespace CourseManagmentBLL.DTO.CourseDTO
{
    public class CourseDetailsDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        [Range(100, 1000)]
        public int Price { get; set; }

        [Required]
        public LookUpDto CourseType { get; set; }

        [Required]
        public LookUpDto CourseLevel { get; set; }
        //public List<SessionsWithoutIdDto> Sessions { get; set; }
    }
}

