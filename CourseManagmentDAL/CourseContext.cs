using CourseManagmentDAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CourseManagmentDAL
{
    public class CourseContext: IdentityDbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseType> CourseTypes { get; set; }
        public DbSet<CourseLevel> CourseLevels { get; set; }
        public DbSet<Session> Sessions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                ("Server=.;Database=CoursesProject;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //fluent apis
            modelBuilder.Entity<Course>().Property(c => c.Name).HasMaxLength(150);
            modelBuilder.Entity<Course>().Property(c => c.Description).HasMaxLength(250);

   
            modelBuilder.Entity<CourseType>()
                       .HasMany(c => c.Courses)
                       .WithOne(c => c.CourseType)
                       .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CourseLevel>()
                      .HasMany(c => c.Courses)
                      .WithOne(c => c.CourseLevel)
                      .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Course>()
                      .HasMany(c => c.Session)
                      .WithOne(c => c.Course)
                      .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);

        }

    }

}
