using System.ComponentModel.DataAnnotations;


namespace 
CourseManagmentDAL.Entities

{
  
  public class CourseLevel
    
{
      
  public int Id { get; set; }
 
  [Required]
     
  public string Name { get; set; }
    
  public ICollection<Course> Courses { get; set; }

  public bool IsDeleted { get; set; } = false;
   
 }
}
