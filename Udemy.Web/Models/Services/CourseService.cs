using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Udemy.Web.Models.Repository;
using Udemy.Web.Models.Repository.Entities;
using Udemy.Web.Models.Services.View_Model;
using Udemy.Web.Models.Services.ViewModel;

namespace Udemy.Web.Models.Services
{
    public class CourseService (IGenericRepository<Category> categoryRepository, /*CourseRepository courseRepository,*/IHttpContextAccessor httpContextAccessor, /*IUnitOfWork unitOfWork,*/ UserManager<AppUser> userManager)
    {
        public async Task<ServiceResult> CreateCourseAsync(CreateCourseViewModel model)
        {

            var userId = httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            var newCourse = new Course()
            {
                Id = Guid.NewGuid(),
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


            /*
             await courseRepository.AddAsync(newCourse);
            await unitOfWork.CommitAsync();
            */

            return ServiceResult.Success("Kurs başarıyla oluşturulmuştur.");
        }

        public async Task<CreateCourseViewModel> LoadCreateCourseAsync()
        {
            var createCourseViewModel = new CreateCourseViewModel();


            var categories = await categoryRepository.GetAllAsync();


            createCourseViewModel.CategoryList = new SelectList(categories, "Id", "Name");

            return createCourseViewModel;
        }

        public async Task<CreateCourseViewModel> LoadCreateCourseAsync(CreateCourseViewModel model)
        {
            var categories = await categoryRepository.GetAllAsync();


            model.CategoryList = new SelectList(categories, "Id", "Name");

            return model;
        }

        public async Task<ServiceResult<IEnumerable<CourseViewModel>>> GetAllCoursesByUserIdAsync()
        {
            var userId = httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            var userIdAsGuid = Guid.Parse(userId);

            /*  var courses = await courseRepository.GetAllCoursesByUserId(userIdAsGuid);*/

            if (!courses.Any())
            {
                return ServiceResult<IEnumerable<CourseViewModel>>.Success(new List<CourseViewModel>());
            }


            var courseViewModels = courses.Select(course => new CourseViewModel
            {
                Id = course.Id,
                IsActive = true,
                IsDeleted = false,
                Title = course.Title,
                ShortDescription = course.ShortDescription,
                PictureFileName = course.PictureFileName,
                Price = course.Price.ToString("C"),
                TotalHourTime = course.TotalHourTime,
                CreatedAt = course.CreatedAt.ToLongDateString(),
                CategoryName = course.Category.Name // Assuming Category is loaded
            });

            return ServiceResult<IEnumerable<CourseViewModel>>.Success(courseViewModels);
        }
    }
}