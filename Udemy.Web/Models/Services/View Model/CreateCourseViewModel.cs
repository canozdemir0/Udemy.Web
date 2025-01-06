using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Udemy.Web.Models.Repository.Entities;

namespace Udemy.Web.Models.Services.View_Model
{
    public record CreateCourseViewModel
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; } = default!;
        public string Description { get; set; } = default!;
        public IFormFile? PictureFile { get; set; }
        public string LearningGoal { get; set; } = default!;
        public decimal Price { get; set; } = default!;
        public int TotalHourTime { get; set; }
        public int CategoryId { get; set; }

        [ValidateNever] public SelectList CategoryList { get; set; }
    }
}
