using IlustraApp.Core.Entities;

namespace IlustraApp.Core.Bussiness.BProductCategory.Response
{
    public class CategoriesResponse
    {
        public List<CategoryClass> Categories { get; set; }
        public int Total { get; set; }
        public CategoriesResponse(List<ProductCategory> categories)
        {
            Categories = new();
            foreach (var category in categories)
            {
                Categories.Add(new CategoryClass(category));
            }
            Total = Categories.Count;
        }
    }

    public class CategoryClass
    {
        public int IdProductCategory { get; set; }
        public string Category { get; set; }
        public string? Description { get; set; } = null;
        public CategoryClass(ProductCategory category)
        {
            IdProductCategory = category.IdProductCategory;
            Category = category.Category;
            Description = category.Description;
        }
    }
}
