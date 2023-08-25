using System.ComponentModel.DataAnnotations.Schema;
namespace KeepNote3.Entities
{
    public class Note
    {
        public int noteId { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public bool status { get; set; }
        public DateTime createdDate { get; set; } = DateTime.Now;
        public Category category { get; set; }
        //[ForeignKey("createdBy")]
        //public User User { get; set; }
        //public Reminder Reminder { get; set; }

    }
}