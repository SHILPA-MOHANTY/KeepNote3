using System;
using System.Collections.Generic;
using System.Linq;
using KeepNote3.Entities;

namespace DAL
{
    //Repository class is used to implement all Data access operations
    public class ReminderRepository : IReminderRepository
    {
        private KeepDbContext _dbContext;
        public ReminderRepository(KeepDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //This method should be used to save a new reminder.
        public Reminder CreateReminder(Reminder reminder)
        {
            _dbContext.Reminders.Add(reminder);
            _dbContext.SaveChanges();
            return reminder;
        }
        //This method should be used to delete an existing reminder.
        public bool DeletReminder(int reminderId)
        {
            var rem = _dbContext.Notes.Find(reminderId);
            if (rem != null)
            {
                _dbContext.Reminders.Remove(GetReminderById(reminderId));
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        //This method should be used to get all reminder by userId.
        public List<Reminder> GetAllRemindersByUserId(int userId)
        {
            var userReminder = _dbContext.Reminders.Where(reminder => reminder.reminderId == userId).ToList();
            return userReminder;
        }
        //This method should be used to get a reminder by reminderId.
        public Reminder GetReminderById(int reminderId)
        {
            var userReminder = _dbContext.Reminders.First(reminder => reminder.reminderId == reminderId);
            return userReminder;
        }
        // This method should be used to update a existing reminder.
        public bool UpdateReminder(Reminder reminder)
        {
            var existingReminder = _dbContext.Reminders.Find(reminder.reminderId);
            if (existingReminder != null)
            {
                existingReminder.reminderId = reminder.reminderId;
                existingReminder.reminderName = reminder.reminderName;
                existingReminder.reminderDescription = reminder.reminderDescription;
                existingReminder.remindrType = reminder.remindrType;
                existingReminder.reminderCreationDate = reminder.reminderCreationDate;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}


