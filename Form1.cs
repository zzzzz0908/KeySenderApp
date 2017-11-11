using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeySenderApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBox2.Text);
            //IntPtr z = FindWindow(null, @"Безымянный - Paint");
            IntPtr z = FindWindow(null, @"ArcView GIS Версия 3.1");
            //MessageBox.Show(z.ToString());
            SetForegroundWindow(z);
            Thread.Sleep(1000);
           
            SetCursorPos(80, 400);
            Thread.Sleep(100);
            mouse_event(0x2, 0, 0, 0, 0);
            mouse_event(0x4, 0, 0, 0, 0);
            
            for (int i = 1; i <= n; i++)
            {
                SendKeys.SendWait(textBox1.Text);
                SendKeys.SendWait("{ENTER}");
            }

        }

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern void SetCursorPos(int x, int y);
        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, int dwExtraInfo);
    }
}
