using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StickyNotes
{
  static class Program
  {
    /// <summary>
    /// Der Haupteinstiegspunkt für die Anwendung.
    /// </summary>
    [STAThread]
    static void Main()
    {
      var settings = Settings.LoadFromFile("./notes.xml");

      Dictionary<string, frmNote> Forms = new Dictionary<string, frmNote>();

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      
      if (settings.Notes.Count <= 0)
      {
        settings.Notes.Add(new Note("Hallo!"));
      }

      foreach (var note in settings.Notes)
      {
        var newNoteForm = new frmNote();
        newNoteForm.noteText.ForeColor = settings.ForegroundColor;
        newNoteForm.noteText.BackColor = settings.BackgroundColor;
        newNoteForm.noteText.Font = new System.Drawing.Font(settings.FontName, settings.FontSize);
        newNoteForm.BackColor = settings.BackgroundColor;
        newNoteForm.note = note;

        Forms.Add(note.ID, newNoteForm);
        newNoteForm.Show();
      }

      foreach (var note in settings.Notes)
      {
        void updateSetting(object sender, EventArgs e)
        {
          frmNote form;
          if (sender.GetType() == typeof(frmNote))
          {
            form = (frmNote)sender;
          } else
          {
            form = (frmNote)((RichTextBox)sender).Parent;
          }

          var idx = settings.Notes.FindIndex(n => n.ID == form.note.ID);
          if (idx != -1)
          {
            settings.Notes[idx] = form.note;
          }

          settings.SaveToFile("./notes.xml");
        }

        var newNoteForm = Forms[note.ID];
        newNoteForm.ResizeEnd += updateSetting;
        newNoteForm.noteText.TextChanged += updateSetting;

        
      }
      
      Application.Run(Forms[settings.Notes[0].ID]);
    }
  }
}
