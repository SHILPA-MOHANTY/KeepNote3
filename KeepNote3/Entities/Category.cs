using System.ComponentModel.DataAnnotations.Schema;
namespace KeepNote3.Entities
{
    public class Category
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public string categoryDescription { get; set; }
        public DateTime categoryCreationDate { get; set; } = DateTime.Now;

        [ForeignKey("categoryCreatedBy")]
        public User user { get; set; }

    }
}