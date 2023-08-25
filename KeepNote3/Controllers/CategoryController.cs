using KeepNote3.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using KeepNote_Step3.DAL;

namespace KeepNote3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // POST: api/category
        [HttpPost]
        public IActionResult CreateCategory([FromBody] Category category)
        {
            try
            {
                var createdCategory = _categoryRepository.Create(category);
                return CreatedAtAction(nameof(GetCategoryById), new { id = createdCategory.CategoryId }, createdCategory);
            }
            catch (Exception ex)
            {
                // Handle exception and return appropriate response
                return BadRequest(new { error = "Failed to create category." });
            }
        }

        // GET: api/category/{id}
        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // GET: api/category
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryRepository.GetAll();
            return Ok(categories);
        }

        // PUT: api/category/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] Category category)
        {
            try
            {
                _categoryRepository.Update(id, category);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle exception and return appropriate response
                return BadRequest(new { error = "Failed to update category." });
            }
        }


        // DELETE: api/category/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                _categoryRepository.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle exception and return appropriate response
                return BadRequest(new { error = "Failed to delete category." });
            }
        }
    }
}