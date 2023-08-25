using KeepNote3.Entities;
namespace KeepNote3.IRepo
{
    public interface INoteRepository
    {
        Note CreateNote(Note note);
        bool UpdateNote(Note note);
        bool DeleteNote(int noteId);
        Note GetNoteByNoteId(int noteId);
        List<Note> GetAllNotesByUserId(string userId);

    }
}
