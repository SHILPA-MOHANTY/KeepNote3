using System.ComponentModel.DataAnnotations.Schema;
namespace KeepNote3.Entities
{
    public class Reminder
    {
        public int reminderId { get; set; }
        public string reminderName { get; set; }
        public string reminderDescription { get; set; } 
        public string remindrType { get; set; }
        [ForeignKey("ReminderCreatedBy")]
        public User User { get; set; }
        public DateTime ReminderCreationDate { get; set; } = DateTime.Now;
    }
}
