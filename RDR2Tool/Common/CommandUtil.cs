using System.Diagnostics;
using System;

namespace Common
{
    public class CommandUtil
    {

        public static string Exec(string exe, params string[] cmdlines)
        {
            using (Process p = new Process())
            {
                p.StartInfo.FileName = exe;
                p.StartInfo.UseShellExecute = false; //是否使用操作系统shell启动
                p.StartInfo.RedirectStandardInput = true; //接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardOutput = true; //由调用程序获取输出信息
                p.StartInfo.RedirectStandardError = true; //重定向标准错误输出
                p.StartInfo.CreateNoWindow = true; //不显示程序窗口

                var pp = p.Start();//启动程序
                foreach (string line in cmdlines)
                {
                    p.StandardInput.WriteLine(line);
                }
                //p.StandardInput.WriteLine("exit");
                p.StandardInput.AutoFlush = true;

                //获取cmd窗口的输出信息
                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();//等待程序执行完退出进程
                p.Close();
#if DEBUG
                Console.WriteLine(output);
#endif
                return output;
            }

        }
    }
}
