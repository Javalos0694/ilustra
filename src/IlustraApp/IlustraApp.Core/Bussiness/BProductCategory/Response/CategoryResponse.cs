using IlustraApp.Core.Entities;

namespace IlustraApp.Core.Bussiness.BProductCategory.Response
{
    public class CategoryResponse
    {
        public int IdProductCategory { get; set; }
        public string Category { get; set; }
        public string? Description { get; set; } = null;
        public CategoryResponse(ProductCategory category)
        {
            IdProductCategory = category.IdProductCategory;
            Category = category.Category;
            Description = category.Description;
        }
    }
}
