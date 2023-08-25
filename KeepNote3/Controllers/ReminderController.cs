using Microsoft.AspNetCore.Mvc;
using System;

namespace KeepNote3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReminderController : ControllerBase
    {
        private readonly IReminderRepository _reminderRepository;

        public ReminderController(IReminderRepository reminderRepository)
        {
            _reminderRepository = reminderRepository;
        }

        // POST: api/reminder
        [HttpPost]
        public IActionResult CreateReminder([FromBody] Reminder reminder)
        {
            try
            {
                var createdReminder = _reminderRepository.Create(reminder);
                return CreatedAtAction(nameof(GetReminderById), new { id = createdReminder.ReminderId }, createdReminder);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = "Failed to create reminder." });
            }
        }

        // GET: api/reminder/{id}
        [HttpGet("{id}")]
        public IActionResult GetReminderById(int id)
        {
            var reminder = _reminderRepository.GetById(id);
            if (reminder == null)
            {
                return NotFound();
            }
            return Ok(reminder);
        }

        // GET: api/reminder
        [HttpGet]
        public IActionResult GetAllReminders()
        {
            var reminders = _reminderRepository.GetAll();
            return Ok(reminders);
        }

        // PUT: api/reminder/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateReminder(int id, [FromBody] Reminder reminder)
        {
            try
            {
                _reminderRepository.Update(id, reminder);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = "Failed to update reminder." });
            }
        }

        // DELETE: api/reminder/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteReminder(int id)
        {
            try
            {
                _reminderRepository.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = "Failed to delete reminder." });
            }
        }
    }
}
