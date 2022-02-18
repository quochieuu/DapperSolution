using DapperDemo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DapperDemo.API.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var shoeCategoryId = new Guid("1b60fd43-a1b5-4214-9ccc-d239f0f4c97b");
            var clothingCategoryId = new Guid("1b60fd43-a1b5-4214-9ccc-d239f0f4c97c");

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = shoeCategoryId,
                    Name = "Shoes",
                    ParentId = null,
                    Status = true,
                },
                 new Category()
                 {
                     Id = clothingCategoryId,
                     Name = "Clothing",
                     ParentId = null,
                     Status = true,
                 });

        }
    }
}
