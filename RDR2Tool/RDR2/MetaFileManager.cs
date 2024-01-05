using Common;
using Common.Steam;
using System;
using System.IO;
using System.Text;

namespace RDR2Tool
{
    public class MetaFileManager
    {
        //经过测试，用户权限也可以写文件到C盘的steam路径
        private static bool USE_CMD = false;
        public const string GAME_NAME = "Red Dead Redemption 2";
        public const string GAME_EXE = "RDR2.exe";
        public const int APPID = 1174180;
        public string GamePath { get; set; }
        private const string INI_FILE = "./rdr2tool.ini";
        private const string KEY_GAME_PATH = "game_path";
        private const string KEY_GAME_CODE = "game_code";
        private const string FILE_NAME = "startup.meta";
        public MetaFileManager()
        {
            GamePath = "./";
        }

        /// <summary>
        /// 读取设置
        /// </summary>
        public void Read()
        {
            string gamePath = IniHelper.Read(KEY_GAME_PATH, null, INI_FILE);
            if (gamePath == null || !gamePath.Contains(":") || !Directory.Exists(gamePath))
            {
                gamePath = SteamInstallationPathDetector.Instance.GetSteamInstallationPath("" + APPID, GAME_NAME, GAME_EXE);
                if (gamePath == null)
                {
                    gamePath = SteamUtil.FindDefaultGamePath(GAME_NAME, null);
                }
                IniHelper.Write(KEY_GAME_PATH, gamePath, INI_FILE);
            }
            GamePath = gamePath;
        }
        /// <summary>
        /// 保存游戏路径
        /// </summary>
        /// <param name="gamePath"></param>
        public void SaveGamePath(string gamePath)
        {
            if (gamePath != null && GamePath != gamePath && Directory.Exists(gamePath))
            {
                GamePath = gamePath;
                IniHelper.Write(KEY_GAME_PATH, gamePath, INI_FILE);
            }
        }
        /// <summary>
        /// 上次输入的卡单密码
        /// </summary>
        /// <returns>卡单密码</returns>
        public string ReadLastCode()
        {
            return IniHelper.Read(KEY_GAME_CODE, "", INI_FILE);
        }
        /// <summary>
        /// 保存最后输入的卡单密码
        /// </summary>
        /// <param name="code">卡单密码</param>
        public void SaveLastCode(string code)
        {
            IniHelper.Write(KEY_GAME_CODE, code, INI_FILE);
        }

        /// <summary>
        /// 读取游戏目录的卡单代码
        /// </summary>
        /// <returns>卡单代码</returns>
        public string ReadGameCode()
        {
            return ReadCode(GetMetaFile());
        }

        /// <summary>
        /// 仅支持meta文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool IsSupportFile(string path)
        {
            if(path == null)
            {
                return false;
            }
            string ex = Path.GetExtension(path);
            return ".meta".Equals(ex, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// 卡单文件的路径
        /// </summary>
        /// <returns></returns>
        private string GetMetaFile()
        {
            if(GamePath == null)
            {
                return Path.Combine("./x64", "data", FILE_NAME);
            }
            return Path.Combine(GamePath, "x64", "data", FILE_NAME);
             
        }

        public bool GenMetaFile(string code, string path)
        {
            string dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            //生成卡单文件
            try
            {
                File.Delete(path);
                using (var fs = File.OpenWrite(path))
                {
                    using (var writer = new BinaryWriter(fs))
                    {
                        writer.Write(Properties.Resources.startup);
                        writer.Write(Encoding.UTF8.GetBytes(code));
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 删除卡单文件
        /// </summary>
        public bool DeleteMetaFile()
        {
            //TODO cmd代替
            string metaFile = GetMetaFile();
            if (USE_CMD)
            {
                CommandUtil.Exec("cmd", "@echo off", "del /Q /F \"" + WrapperPath(metaFile) + "\"", "exit");
            } else
            {
                PathEx.DeleteFile(metaFile);
            }
            return !File.Exists(metaFile);
        }

        private bool CopyFile(string file, string dst_file)
        {
            //TODO cmd代替
            string dir = Path.GetDirectoryName(dst_file);
            if (!Directory.Exists(dir))
            {
                if (USE_CMD)
                {
                    CommandUtil.Exec("cmd", "@echo off", "mkdir \"" + WrapperPath(dir) + "\"", "exit");
                }
                else
                {
                    Directory.CreateDirectory(dir);
                }
            }
            //File.Copy(file, dst_file, true);
            if (USE_CMD)
            {
                CommandUtil.Exec("cmd", "@echo off", "copy /Y \"" + WrapperPath(file) + "\" \"" + WrapperPath(dst_file) + "\"", "exit");
            } else
            {
                File.Copy(file, dst_file, true);
            }
            return File.Exists(dst_file);
        }
        private string WrapperPath(string path)
        {
            return path.Replace("/", "\\");
        }
        private string ReadCode(string file)
        {
            if (File.Exists(file))
            {
                string text = File.ReadAllText(file, Encoding.UTF8);
                string prefix = "</CDataFileMgr__ContentsOfDataFileXml>";
                int index = text.IndexOf(prefix);
                if (index >= 0)
                {
                    return text.Substring(index + prefix.Length);
                }
            }
            return "";
        }

        //复制该文件去替换卡单文件
        public bool SetMetaFile(string file)
        {
            string dst_file = GetMetaFile();
            return CopyFile(file, dst_file);
        }
    }
}
