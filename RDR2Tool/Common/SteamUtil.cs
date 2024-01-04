using Microsoft.Win32;
using System;
using System.IO;

namespace Common
{
    internal static class SteamUtil
    {

        private static string FindPath(string suffix)
        {
            for (int i = 'C'; i <= 'K'; i++)
            {
                string path = ((char)i) + suffix;
                if (Directory.Exists(path))
                {
                    return path;
                }
            }
            return null;
        }

        public static string FindDefaultGamePath(string game)
        {
            //C:\Steam\steamapps\common\Monster Hunter World\MonsterHunterWorld.exe
            string result = FindPath(@":\Steam\steamapps\common\" + game);
            if(result != null)
            {
                return result;
            }
            result = FindPath(@":\SteamLibrary\steamapps\common\" + game);
            if (result != null)
            {
                return result;
            }
            result = FindPath(@":\Program Files (x86)\Steam\steamapps\common\" + game);
            if (result != null)
            {
                return result;
            }
            result = FindPath(@":\Epic\" + game);
            if (result != null)
            {
                return result;
            }
            result = FindPath(@":\EpicGames\" + game);
            if (result != null)
            {
                return result;
            }
            result = FindPath(@":\Game\" + game);
            if (result != null)
            {
                return result;
            }
            result = FindPath(@":\Games\" + game);
            if (result != null)
            {
                return result;
            }
            result = FindPath(@":\Program Files\Epic Games\" + game);
            if (result != null)
            {
                return result;
            }
            result = FindPath(@":\Program Files (x86)\Epic Games\" + game);
            if (result != null)
            {
                return result;
            }
            string steamPath = GetSteamRoot();
            if (steamPath != null) {
                string path = Path.Combine(steamPath, @"steamapps\common",  game);
                if (Directory.Exists(path)) {
                    return path;
                }
            }
            return null;
        }

        public static string GetSteamRoot()
        {
            string reg = Environment.Is64BitOperatingSystem ? @"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Valve\Steam" : @"HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Steam";
            object val = Registry.GetValue(reg, "InstallPath", null);

            if (val != null)
                return (string)val;
            else
                return null;
        }

        public static string FindDefaultGameSavePath(int appId, bool notNull)
        {
            //C:\Steam\steamapps\common\Monster Hunter World\MonsterHunterWorld.exe
            string root = GetSteamRoot();
            if (!Directory.Exists(root))
            {
                root = null;
                for (int i = 'C'; i <= 'H'; i++)
                {
                    string path = ((char)i) + @":\Program Files (x86)\Steam";
                    if (Directory.Exists(path))
                    {
                        root = path;
                        break;
                    }
                    path = ((char)i) + @":\Steam";
                    if (Directory.Exists(path))
                    {
                        root = path;
                        break;
                    }
                }
            }
            if (string.IsNullOrEmpty(root)) {
                return null;
            }
            string userdata = Path.Combine(root, "userdata");
            if (Directory.Exists(userdata))
            {
                var dir = new DirectoryInfo(userdata);
                DirectoryInfo[] dirs = dir.GetDirectories();
                if (dirs != null)
                {
                    foreach (DirectoryInfo d in dirs)
                    {
                        string save = Path.Combine(d.FullName, ""+appId);
                        if (Directory.Exists(save)) {
                        	return Path.Combine(save, "remote");
                        }
                        //return notNull?d.FullName:null;
                    }
                }
                return notNull?dir.FullName:null;
            }
            return notNull?root:null;
        }

    }
}
