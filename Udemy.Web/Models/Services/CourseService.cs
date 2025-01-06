using System.Security.Claims;
using Udemy.Web.Models.Repository;
using Udemy.Web.Models.Repository.Entities;
using Udemy.Web.Models.Services.View_Model;

namespace Udemy.Web.Models.Services
{
    public class CourseService (IGenericRepository<Course>courseRepository,IHttpContextAccessor httpContextAccessor)
    {
        public async Task<ServiceResult> CreateCourseAsync(CreateCourseViewModel model)
        {

            var userId = httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            var newCourse = new Course()
            {
                Title = model.Title,
                ShortDescription = model.ShortDescription,
                Description = model.Description,
                LearningGoal = model.LearningGoal,
                Price = model.Price,
                TotalHourTime = model.TotalHourTime,
                CategoryId = model.CategoryId,
                CreatedAt = DateTime.Now,
                CreatedBy = Guid.Parse(userId)
            };

            if (model.PictureFile is not null && model.PictureFile.Length > 0)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(model.PictureFile.FileName)}";

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pictures", "courses", fileName);

                await using var stream = new FileStream(path, FileMode.Create);

                await model.PictureFile.CopyToAsync(stream);


                newCourse.PictureFileName = fileName;
            }
            return ServiceResult.Success("Olumlu");
        }
    }
}