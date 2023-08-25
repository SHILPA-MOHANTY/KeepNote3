using KeepNote3.Entities;
namespace KeepNote_Step3.DAL
{
    public interface ICategoryRepository
    {
        Category CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int categoryId);
        Category GetCategoryById(int categoryId);
        List<Category> GetAllCategoriesByUserId(string userId);

    }
}
