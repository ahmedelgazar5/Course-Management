using System.ComponentModel.DataAnnotations;

namespace CourseManagmentDAL.Entities
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(100, 1000)]
        public int Price { get; set; }
        [Required]
        public int CourseTypeId { get; set; }
        public CourseType CourseType { get; set; }
        public int CourseLevelId { get; set; }
        public CourseLevel CourseLevel { get; set; }
        public ICollection<Session> Session { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
