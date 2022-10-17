using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureTheFlag
{
    internal class ScreenCapture
    {
        [StructLayout(LayoutKind.Sequential)]
        struct CURSORINFO
        {
            public Int32 cbSize;
            public Int32 flags;
            public IntPtr hCursor;
            public POINTAPI ptScreenPos;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct POINTAPI
        {
            public int x;
            public int y;
        }

        [DllImport("user32.dll")]
        static extern bool GetCursorInfo(out CURSORINFO pci);
        [DllImport("user32.dll")]
        static extern bool DrawIcon(IntPtr hDC, int X, int Y, IntPtr hIcon);

        const Int32 CURSOR_SHOWING = 0x00000001;

        public static void doCaptureAndSave()
        {
            for (int i = 1; i <= Variables.getMonitorCount(); i++)
            {
                Bitmap screenBitmap = doScreenCapture(Variables.getCaptureCursor());
                saveCapturedFile(screenBitmap, i);
            }
        }
        private static Bitmap doScreenCapture(bool CaptureMouse)
        {
            Bitmap result = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format24bppRgb);

            try
            {
                using (Graphics g = Graphics.FromImage(result))
                {
                    g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);

                    if (CaptureMouse)
                    {
                        CURSORINFO pci;
                        pci.cbSize = Marshal.SizeOf(typeof(CURSORINFO));

                        if (GetCursorInfo(out pci))
                        {
                            if (pci.flags == CURSOR_SHOWING)
                            {
                                DrawIcon(g.GetHdc(), pci.ptScreenPos.x, pci.ptScreenPos.y, pci.hCursor);
                                g.ReleaseHdc();
                            }
                        }
                    }
                }
            }
            catch
            {
                result = null;
            }

            return result;
        }

        private static async void saveCapturedFile(Bitmap screenBitmap, int monitor)
        {
            try
            {
                screenBitmap.Save(combineSavePath(1));
                screenBitmap.Dispose();
            }
            catch { }
        }

        private static string combineSavePath(int monitor)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Variables.getSavePath());
            sb.Append("\\");
            sb.Append(monitor);
            sb.Append("\\");
            sb.Append(Util.getUnixTime());
            sb.Append(".jpg");

            return sb.ToString();
        }
    }
}
