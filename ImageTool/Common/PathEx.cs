using System;
using System.Collections.Generic;
using System.IO;

namespace Common
{
	
	public static class PathEx
	{

		public static long GetLength(string path)
        {
            if (File.Exists(path))
            {
				return new FileInfo(path).Length;
            }
			return -1;
        }

		public static void FindFiles(List<string> fileList, List<string> dirList, string path, string root)
		{
			if (Directory.Exists(path))
			{
				if (dirList != null)
				{
					dirList.Add(root);
				}
				var dir = new DirectoryInfo(path);
				var fs = dir.GetFiles();
				if (fs != null)
				{
					foreach (var f in fs)
					{
						string name = root.Length > 0 ? root + "/" + f.Name : f.Name;
						fileList.Add(WrapperPathSep(name));
					}
				}
				DirectoryInfo[] dirs = dir.GetDirectories();
				if (dirs != null)
				{
					foreach (var d in dirs)
					{
						string name = root.Length > 0 ? root + "/" + d.Name : d.Name;
						FindFiles(fileList, dirList, d.FullName, name);
					}
				}
			}
		}

		public static bool CheckPath(string path)
		{
			try
			{
				Path.Combine(path, "1.jpg");
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static string GetLitePath(string _fullpath, string _parent)
		{
			if (_fullpath == null || string.IsNullOrEmpty(_parent))
			{
				return _fullpath;
			}

			string fullpath = WrapperPathSep(Path.GetFullPath(_fullpath));
			string parent = WrapperPathSep(Path.GetFullPath(_parent));
			if (fullpath.Length == parent.Length)
			{
				string path = fullpath.Replace(parent, "");
				if (string.IsNullOrEmpty(path))
				{
					return "/";
				}
				return path;
			}
			else
			{
				string path = fullpath.Replace(parent + "/", "");
				if (string.IsNullOrEmpty(path))
				{
					return "/";
				}
				return path;
			}
		}

		public static string WrapperPathSep(string path)
		{
			return path != null ? path.Replace('\\', '/') : "";
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="path"></param>
		/// <param name="start">开始截取</param>
		/// <param name="c"></param>
		/// <param name="subStart">开始查找</param>
		/// <param name="def"></param>
		/// <returns></returns>
		public static string GetPathFirstPart(string path, int start, char c, string def = null, int subStart = -1)
		{
			try
			{
				if (subStart < 0)
				{
					subStart = start;
				}
				int i = path.IndexOf(c, start);
				if (i >= subStart)
				{
					return path.Substring(subStart, i - subStart);
				}
			}
			// disable once EmptyGeneralCatchClause
			catch
			{
			}
			return def;
		}

		private static string RootPath = Environment.CurrentDirectory;

		public static void SetRoot(string path)
		{
			RootPath = path;
		}

		public static void mkdirs(string dir)
		{
			if (string.IsNullOrEmpty(dir)) return;
			if (!Directory.Exists(dir))
			{
				if (File.Exists(dir))
				{
					File.Delete(dir);
				}
				Directory.CreateDirectory(dir);
			}
		}
		public static bool MoveStubFilesTo(string src, string path)
		{
			var dir = new DirectoryInfo(src);
			if (dir.Exists)
			{
				try
				{
					MoveStubFilesTo(dir, path);
					return true;
				}
				catch
				{
					return false;
				}
			}
			return false;
		}

        public static bool MoveStubFilesTo(string[] files, string path)
        {
            if (files != null)
            {
                foreach (var file in files)
                {
                    var dst_path = Path.Combine(path, Path.GetFileName(file));
                    PathEx.MoveFile(file, dst_path);
                }
				return true;
            }
            return false;
        }

        public static bool IsMatchExtension(this string path, string ex){
			return Path.GetExtension(path).EndsWith(ex, StringComparison.OrdinalIgnoreCase);
		}
		
		public static List<string> MoveStubFilesTo(DirectoryInfo src, string path)
		{
			if (!Directory.Exists(path))
			{
				PathEx.mkdirs(path);
			}
			var list = new List<string>();
			FileInfo[] files = src.GetFiles();
			if (files != null)
			{
				foreach (var file in files)
				{
					var full_path = Path.Combine(path, file.Name);
					list.Add(file.FullName);
					PathEx.MoveFile(file.FullName, full_path);
				}
			}
			DirectoryInfo[] dirs = src.GetDirectories();
			if (dirs != null)
			{
				foreach (var dir in dirs)
				{
					var full_path = Path.Combine(path, dir.Name);
					list.AddRange(MoveStubFilesTo(dir, full_path));
				}
			}
			return list;
		}

		public static bool MoveFile(string src, string dst)
		{
			try
			{
				if (!File.Exists(src))
				{
					return false;
				}
				if (File.Exists(dst))
				{
					PathEx.DeleteFile(dst);
				}
				else if (Directory.Exists(dst))
				{
					PathEx.DeleteDir(dst);
				}
				string dir = Path.GetDirectoryName(dst);
				mkdirs(dir);
				File.Move(src, dst);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static string GetFullPath(string path)
		{
			if (path == null)
			{
				return RootPath;
			}
			if (path.StartsWith("/") || path.StartsWith("\\"))
			{
				return Path.Combine(RootPath, path.Substring(1));
			}
			if (path.StartsWith("./") || path.StartsWith(".\\"))
			{
				return Path.Combine(RootPath, path.Substring(2));
			}
			if (path.StartsWith("../") || path.StartsWith("..\\"))
			{
				return Path.GetFullPath(Path.Combine(RootPath, path.Substring(3)));
			}
			if (!path.Contains(":"))
			{
				return Path.Combine(RootPath, path);
			}
			return Path.GetFullPath(path);
		}

		public static string WrapperName(string name, char sp = '_')
		{
			//<>,/,\,|,:,"",*,?
			char[] sps = { '<', '>', '/', '\\', '|', ':', '"', '"', '*', '?' };
			foreach (char c in sps)
			{
				name = name.Replace(c, sp);
			}
			return name;
		}

		public static bool DeleteFile(string path)
		{
			if (File.Exists(path))
			{
				try
				{
					File.Delete(path);
					return true;
				}
				catch
				{
					return false;
				}
			}
			return true;
		}

		public static void DeleteDir(string path)
		{
			if (Directory.Exists(path))
			{
				try
				{
					Directory.Delete(path, true);
				}
				// disable once EmptyGeneralCatchClause
				catch
				{

				}
			}
		}
		public static bool DeleteEmptyDir(string dir, bool keepSelf=false)
		{
			return string.IsNullOrEmpty(dir) || DeleteEmptyDir(new DirectoryInfo(dir), keepSelf);
		}

		public static bool DeleteEmptyDir(DirectoryInfo dir, bool keepSelf = false)
		{
			if (dir.Exists)
			{
				var fs = dir.GetFiles();
				bool deleteSelf = !keepSelf;
				if (deleteSelf && fs != null && fs.Length > 0)
				{
					//Console.WriteLine("ignore by has file " + dir.FullName);
					deleteSelf = false;
				}
				var dirs = dir.GetDirectories();
				if (dirs != null)
				{
					foreach (var d in dirs)
					{
						if (!DeleteEmptyDir(d))
						{
							//Console.WriteLine("ignore by has not empty dir " + dir.FullName);
							deleteSelf = false;
						}
					}
				}
				if (deleteSelf)
				{
					try
					{
						//Console.WriteLine("delete empty dir " + dir.FullName);
						dir.Delete();
						return true;
					}
					catch
					{
						return false;
					}
				}
			}
			return true;
		}

		public static string GetFileSize(long filesize)
		{
			if (filesize < 0)
			{
				return "0";
			}
			else if (filesize >= 1024 * 1024 * 1024) //文件大小大于或等于1024MB
			{
				return string.Format("{0:0.00} GB", (double)filesize / (1024 * 1024 * 1024));
			}
			else if (filesize >= 1024 * 1024) //文件大小大于或等于1024KB
			{
				return string.Format("{0:0.00} MB", (double)filesize / (1024 * 1024));
			}
			else if (filesize >= 1024) //文件大小大于等于1024bytes
			{
				return string.Format("{0:0.00} KB", (double)filesize / 1024);
			}
			else
			{
				return string.Format("{0:0.00} bytes", filesize);
			}
		}

		public static long GetDirectoryLength(string file)
		{
			if (Directory.Exists(file))
			{
				var dir = new DirectoryInfo(file);
				return GetLength(dir);
			}
			return -1;
		}

		public static long GetLength(DirectoryInfo dir)
		{
			long length = 0;
			var files = dir.GetFiles();
			if (files != null)
			{
				foreach (var f in files)
				{
					length += f.Length;
				}
			}
			var dirs = dir.GetDirectories();
			if (dirs != null)
			{
				foreach (var d in dirs)
				{
					length += GetLength(d);
				}
			}
			return length;
		}
	}
}
