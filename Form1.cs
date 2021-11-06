using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Devil_Games
{

    public partial class Selector : Form
    {public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        bool Work;

        public Selector()
        {
            InitializeComponent();

            panel2.MouseEnter += async (s, a) => 
            {
                while (!Work && panel2.Location.X > panel1.Location.X + 40)
                {
                    Work = true;
                    await Task.Delay(1);
                    panel2.Location = new Point(panel2.Location.X- panel2.Location.X / 18, panel2.Location.Y);
                    Work = false;
                }
            };
            panel1.MouseEnter+= async (s, a) =>
            {
                while (!Work && panel2.Location.X < 755)
                {
                    Work = true;
                    await Task.Delay(1);
                    panel2.Location = new Point(panel2.Location.X+ (860 - panel2.Location.X) / 18, panel2.Location.Y); 
                    Work = false;
                }
            };
        }

        private void Selector_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void extBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
