using System.ComponentModel.DataAnnotations;

namespace CourseManagmentDAL.Entities
{
    public class Session
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int DurationInMins { get; set; }
       
 public int CourseId { get; set; }

 public Course Course { get; set; }
        
public bool IsDeleted { get; set; } = false;
    
}
}
