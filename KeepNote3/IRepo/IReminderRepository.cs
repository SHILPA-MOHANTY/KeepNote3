using KeepNote3.Entities;
namespace KeepNote3.IRepo
{
    public interface IReminderRepository
    {
        Reminder CreateReminder(Reminder reminder);
        bool UpdateReminder(Reminder reminder);
        bool DeletReminder(int reminderId);
        Reminder GetReminderById(int reminderId);
        List<Reminder> GetAllRemindersByUserId(string userId);

    }
}
