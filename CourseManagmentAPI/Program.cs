using CourseManagmentBLL.Managers.CourseLevelModule;
using CourseManagmentBLL.Managers.CourseModule;
using CourseManagmentBLL.Managers.CourseTypeModule;
using CourseManagmentBLL.Managers.SessionsModule;
using CourseManagmentDAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApplication16
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ICourseManager, CourseManager>();
            builder.Services.AddScoped<ICourseTypeManager, CourseTypeManager>();
            builder.Services.AddScoped<ICourseLevelManager, CourseLevelManager>();
            builder.Services.AddScoped<ISessionsManager, SessionsManager>();

            builder.Services.AddDbContext<CourseContext>();
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                            .AddEntityFrameworkStores<CourseContext>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Bearer";
            })
                 .AddJwtBearer(o =>
                 {
                  
                     o.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuerSigningKey = true,
                         ValidateIssuer = true,
                         ValidateAudience = true,
                         ValidateLifetime = false,
                         ClockSkew = TimeSpan.Zero,
                         ValidIssuer = "CourseApp",
                         ValidAudience = "user",
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Ez92utU5UA6ZZG3OmCeDdrcHvmewvNZA"))
                     };
                 });

            // allow cors for js
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CourseApi",
                    policy =>
                    {
                      
                        policy
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                    });
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("CourseApi");
            app.UseAuthentication(); 
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}