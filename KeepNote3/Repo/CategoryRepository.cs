using System;
using System.Collections.Generic;
using System.Linq;
using KeepNote_Step3.DAL;
using KeepNote3.Entities;


namespace DAL
{
    public class CategoryRepository : ICategoryRepository
    {
        private KeepDbContext _dbContext;
        public CategoryRepository(KeepDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Category CreateCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            return category;

        }

        public bool DeleteCategory(int categoryId)
        {
            var category = _dbContext.Categories.Find(categoryId);
            if (category != null)
            {
                _dbContext.Categories.Remove(category);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public List<Category> GetAllCategoriesByUserId(int userId)

        {
            var userCategories = _dbContext.Categories.Where(category => category.categoryId == userId).ToList();
            return userCategories;

        }

        public Category GetCategoryById(int categoryId)
        {
            var category = _dbContext.Categories.Find(categoryId);
            return category;
        }

        public bool UpdateCategory(Category category)
        {
            var existingcategory = _dbContext.Categories.Find(category.categoryId);
            if (existingcategory != null)
            {
                existingcategory.categoryId = category.categoryId;
                existingcategory.categoryName = category.categoryName;
                existingcategory.categoryCreationDate = category.categoryCreationDate;
                existingcategory.categoryDescription = category.categoryDescription;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
