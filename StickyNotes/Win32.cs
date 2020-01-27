using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StickyNotes
{
  class Win32
  {
    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOWPOS
    {
      public IntPtr hwnd;
      public IntPtr hwndInsertAfter;
      public int x;
      public int y;
      public int cx;
      public int cy;
      public uint flags;
    }

    [Flags]
    public enum SendMessageTimeoutFlags : uint
    {
      SMTO_NORMAL = 0x0,
      SMTO_BLOCK = 0x1,
      SMTO_ABORTIFHUNG = 0x2,
      SMTO_NOTIMEOUTIFNOTHUNG = 0x8,
      SMTO_ERRORONEXIT = 0x20
    }

    public const int WM_NCLBUTTONDOWN = 0xA1;
    public const int HT_CAPTION = 0x2;

    public static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
    public static readonly UInt32 SWP_NOSIZE = 0x0001;
    public static readonly UInt32 SWP_NOMOVE = 0x0002;
    public static readonly UInt32 SWP_NOACTIVATE = 0x0010;
    public static readonly UInt32 SWP_NOZORDER = 0x0004;

    [DllImport("user32", SetLastError = false)]
    public static extern bool SetWindowPos(IntPtr hwnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

    [DllImport("user32", SetLastError = false)]
    public static extern IntPtr SetParent(IntPtr hwndChild, IntPtr hwndNewparent);

    [DllImport("user32", SetLastError = false)]
    public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string lclassName, string windowTitle);

    [DllImport("user32", SetLastError = false)]
    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32")]
    public static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
    [DllImport("user32")]
    public static extern bool ReleaseCapture();

    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessageTimeout(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam, SendMessageTimeoutFlags fuFlags, uint uTimeout, out IntPtr lpdwResult);

    public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

  }
}
