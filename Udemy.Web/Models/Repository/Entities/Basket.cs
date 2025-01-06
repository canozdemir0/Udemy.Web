namespace Udemy.Web.Models.Repository.Entities
{
    public class Basket
    {
        public decimal TotalPrice { get; set; }
        public Guid UserId { get; set; }
        public List<BasketItem> Items { get; set; }
    }
    public class BasketItem:BaseEntity<int>
    {
        public Guid CourseId { get; set; } = default!;
        public string CourseTitle { get; set; } = default!;
        public decimal CoursePrice { get; set; } = default!;
        public string CoursePicture { get; set; }
        public Guid BasketId { get; set; }
        public Basket Basket { get; set; } = default!;
    }
}
