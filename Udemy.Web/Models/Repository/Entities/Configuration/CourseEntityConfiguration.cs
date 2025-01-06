﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Udemy.Web.Models.Repository.Entities.Configuration
{
    public class CourseEntityConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Title).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.ShortDescription).HasMaxLength(300).IsRequired();
            builder.Property(x => x.LearningGoal).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Description).IsRequired(); ;
            builder.Property(x => x.TotalHourTime).IsRequired();
            builder.Property(x => x.PictureFileName).HasMaxLength(200).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.CategoryId).IsRequired();
            builder.HasOne(x => x.Category).WithMany(x => x.Courses).HasForeignKey(x => x.CategoryId);
        }
    }
}
