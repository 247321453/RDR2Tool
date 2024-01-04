using System.Runtime.InteropServices;
using System.Text;

namespace Common
{
    internal class IniHelper
    {
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defVal, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        /// <summary>    
        /// 读取INI文件    
        /// </summary>    
        /// <param name="section">项目名称(如 [section] )</param>    
        /// <param name="skey">键</param>   
        /// <param name="path">路径</param> 
        public static string Read(string section, string skey, string def, string path = "config.ini")
        {
            StringBuilder temp = new StringBuilder(500);
            int i = GetPrivateProfileString(section, skey, "__NULL__", temp, 500, PathEx.GetFullPath(path));
            string value = temp.ToString();
            if ("__NULL__".Equals(value)) {
                value = null;
            }
            if (value != null)
            {
                value = value.Trim(' ').Replace("\\n ", "\n").Replace("\\n", "\n");
            }
            if (value == null) {
                value = def;
            }
            return value;
        }

        public static string Read(string skey, string def = null, string path = "config.ini")
        {
            return Read("setting", skey, def, path);
        }

        public static void Write(string skey, string value, string path = "config.ini")
        {
            Write("setting", skey, value, path);
        }

        /// <summary>
        /// 写入ini文件
        /// </summary>
        /// <param name="section">项目名称</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="path">路径</param>
        public static void Write(string section, string key, string value, string path = "config.ini")
        {
            if (value != null)
            {
                value = value.Replace("\\n ", "\n").Replace("\\n", "\n").Replace("\n", "\\n ");
            }
            WritePrivateProfileString(section, key, value, PathEx.GetFullPath(path));
        }
    }
}
