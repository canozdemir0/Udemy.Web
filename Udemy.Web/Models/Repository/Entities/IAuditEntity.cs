namespace Udemy.Web.Models.Repository.Entities
{
    public interface IAuditEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
