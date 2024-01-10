using System;
using System.Windows.Forms;

namespace ImageTool
{
    internal static class Program
    {
        public const string VERSION = "1.2";
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            CosturaUtility.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
