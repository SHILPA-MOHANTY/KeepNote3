using System.Collections.Generic;
using System.Linq;
using KeepNote3.Entities;

namespace DAL
{
    //Repository class is used to implement all Data access operations
    public class NoteRepository : INoteRepository
    {
        private KeepDbContext _dbContext;
        public NoteRepository(KeepDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // This method should be used to save a new note.
        public Note CreateNote(Note note)
        {
            _dbContext.Notes.Add(note);
            _dbContext.SaveChanges();
            return note;
        }


        /* This method should be used to delete an existing note. */
        public bool DeleteNote(int noteId)
        {
            var note = _dbContext.Notes.Find(noteId);
            if (note != null)
            {
                _dbContext.Notes.Remove(GetNoteByNoteId(noteId));
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }


        //* This method should be used to get all note by userId.
        public List<Note> GetAllNotesByUserId(int userId)
        {
            var userNotes = _dbContext.Notes.Where(note => note.noteId == userId).ToList();
            return userNotes;
        }
        //This method should be used to get a note by noteId.
        public Note GetNoteByNoteId(int noteId)
        {
            var note = _dbContext.Notes.Find(noteId);
            return note;
        }
        //This method should be used to update a existing note.
        public bool UpdateNote(Note note)
        {
            var existingNote = _dbContext.Notes.Find(note.noteId);
            if (existingNote != null)
            {
                existingNote.noteId = note.noteId;
                existingNote.title = note.title;
                existingNote.content = note.content;
                existingNote.status = note.status;
                existingNote.createdDate = note.createdDate;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}