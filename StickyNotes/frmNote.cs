using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace StickyNotes
{
  public partial class frmNote : Form
  {
    private const int cGrip = 16;      // Grip size
    private const int cCaption = 32;   // Caption bar height

    private bool isBack = false;
    private bool hasLoaded = false;
    public Note note;

    protected override void WndProc(ref Message m)
    {
      if (m.Msg == 0x84)
      {  // Trap WM_NCHITTEST
        Point pos = new Point(m.LParam.ToInt32());
        pos = this.PointToClient(pos);
        if (pos.Y < cCaption)
        {
          m.Result = (IntPtr)2;  // HTCAPTION
          return;
        }
        if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
        {
          m.Result = (IntPtr)17; // HTBOTTOMRIGHT
          return;
        }
      } else if (m.Msg == 0x46)
      {
        if (isBack)
        {
          Win32.WINDOWPOS mwp = (Win32.WINDOWPOS)Marshal.PtrToStructure(m.LParam, typeof(Win32.WINDOWPOS));
          mwp.flags = mwp.flags | Win32.SWP_NOZORDER;
          m.Result = IntPtr.Zero;
          Marshal.StructureToPtr(mwp, m.LParam, true);
        }

        base.WndProc(ref m);
      } else
      {
        base.WndProc(ref m);
      } 
    }

    public frmNote()
    {
      InitializeComponent();
      this.SetStyle(ControlStyles.ResizeRedraw, true);
    }

    private void frmNote_Load(object sender, EventArgs e)
    {
      this.noteText.Text = note.Text;
      this.Location = note.WindowLocation;
      this.Size = note.WindowSize;

      hasLoaded = true;
    }

    private void frmNote_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        Win32.ReleaseCapture();
        Win32.SendMessage(this.Handle, Win32.WM_NCLBUTTONDOWN, Win32.HT_CAPTION, 0);
      }
    }

    private void frmNote_Resize(object sender, EventArgs e)
    {
      noteText.Top = topPanel.Height + 5;
      noteText.Height = this.ClientSize.Height - noteText.Top - 5;
      noteText.Left = 5;
      noteText.Width = this.ClientSize.Width - 10;

      if (hasLoaded)
      {
        note.WindowSize = this.Size;
      }
    }

    private void frmNote_Shown(object sender, EventArgs e)
    {
      if (Win32.SetWindowPos(Handle, Win32.HWND_BOTTOM, 0, 0, 0, 0, Win32.SWP_NOMOVE | Win32.SWP_NOSIZE)) {
        isBack = true;
      }
    }

    private void frmNote_Move(object sender, EventArgs e)
    {
      if (hasLoaded)
      {
        note.WindowLocation = this.Location;
      }
    }

    private void noteText_TextChanged(object sender, EventArgs e)
    {
      if (hasLoaded)
      {
        note.Text = noteText.Text;
      }
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }
  }
}
