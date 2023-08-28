namespace CourseManagmentBLL.DTO.CourseDTO
{
  
  public class CoursesQueryDto
  
  {
        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public int? Price { get; set; }

        public string? Name { get; set; }

        public int? CourseTypeId { get; set; }
    }
}
