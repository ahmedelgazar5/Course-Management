using CourseManagmentBLL.DTO.SessionsDto;

namespace CourseManagmentBLL.DTO.CourseDTO
{
    public class CourseGetAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CourseType { get; set; }
        public int Price { get; set; }
        public string? CourseLevel { get; set; }
        public List<SessionsWithoutIdDto> Sessions { get; set; }

    }
}
