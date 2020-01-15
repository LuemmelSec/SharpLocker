using System;
using System.Windows.Forms;

namespace  SharpLockerLib
{
    public static class Program
    {
        [STAThread]
        public static String Run()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            StrResult res = new StrResult();
            Form1 f = new Form1(ref res);
            Application.Run(f);
            return res.val;
        }


    }
}
