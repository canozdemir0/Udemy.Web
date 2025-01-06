namespace Udemy.Web.Models.Repository.Entities
{
    public class Course:BaseEntity<Guid>,IAuditEntity, IAuditSoftDelete
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string? PictureFileName { get; set; }
        public string LearningGoal { get; set; } = default!;
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public int TotalHourTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public Guid CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;
    }
}
