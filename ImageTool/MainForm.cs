using Common;
using Common.Logging;
using MetroSet_UI.Forms;
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageTool
{
    public partial class MainForm : MetroSetForm
    {
        private const string INI_FILE = "./image_tool.ini";
        private const string KEY_DIR = "dir";

        public MainForm()
        {
            UIThread.Init();
            InitializeComponent();
            lb_title.Text += " v" + Program.VERSION;
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            tb_game_dir.Text = IniHelper.Read(KEY_DIR, Application.StartupPath, INI_FILE);
            Slog.Setup((msg) =>
            {
                UIThread.Post(() =>
                {
                    if (rb_log.TextLength >= 1024 * 1024)
                    {
                        rb_log.Clear();
                    }
                    rb_log.AppendText(msg);
                    rb_log.SelectionStart = int.MaxValue;
                    rb_log.SelectionLength = 1;
                    rb_log.ScrollToCaret();
                });
            },

#if DEBUG
            LogLevel.DEBUG,
#else
            LogLevel.INFO,
#endif
            "./log/" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss.ffff") + ".txt");
        }

        private void btn_choose_game_dir_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.ShowNewFolderButton = false;
                dlg.Description = "请选择需要读取的图片文件夹";
                dlg.SelectedPath = Application.StartupPath;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    tb_game_dir.Text = dlg.SelectedPath;
                    IniHelper.Write(KEY_DIR, dlg.SelectedPath, INI_FILE);
                }
            }
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (mRunning)
            {
                StopFileWatch();
                btn_start.Text = "开始";
            }
            else
            {
                btn_start.Text = "停止";
                IniHelper.Write(KEY_DIR, tb_game_dir.Text, INI_FILE);
                StartFileWatch(tb_game_dir.Text);
            }
        }

        private bool mRunning;
        private FileSystemWatcherEx FileWatcher;
        private Image LastImage;
        private string LastPath;

        private void StartFileWatch(string path)
        {
            if (FileWatcher == null)
            {
                if (!path.EndsWith("\\") && !path.EndsWith("/"))
                {
                    path += "\\";
                }
                mRunning = true;
                FileWatcher = new FileSystemWatcherEx(path, "*.png|*.jpg|*.bmp", true, "",
                    OnFileChanged, OnFileChanged,
                    OnFileChanged);
                FileWatcher.Start();
                Slog.i("文件观察者", "当前文件夹是:" + path);
            }
        }

        public void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == System.IO.WatcherChangeTypes.Created)
            {
                Slog.d("文件观察者", "OnFileChanged:" + e.ChangeType + ":" + e.FullPath);
                Task.Run(()=>{
                    Thread.Sleep(500);
                    UIThread.Post(() =>
                    {
                        try
                        {
                            LoadImage(e.FullPath);
                        }
                        catch { }
                    });
                });
            }
        }

        private void LoadImage(string path)
        {
            if (LastPath == path)
            {
                return;
            }
            if (!File.Exists(path))
            {
                return;
            }
            var fi = new FileInfo(path);
            //文件创建时间大于5秒就说明是老文件
            long sp;
            if((sp = ((DateTime.UtcNow.Ticks - fi.CreationTimeUtc.Ticks)/10000)) > 5000)
            {
                Slog.d("文件观察者", "跳过图片:" + Path.GetFileName(path)+" by " + sp);
                return;
            }
            Slog.i("文件观察者", "读取图片:" + Path.GetFileName(path));
            LastPath = path;
            if (LastImage != null)
            {
                LastImage.Dispose();
                LastImage = null;
            }
            //加载图片
            Image img = ImageHelper.FileToBitmapImage(path, true);
            LastImage = img;
            Clipboard.SetImage(img);
        }

        private void StopFileWatch()
        {
            mRunning = false;
            if (FileWatcher != null)
            {
                FileWatcher.Stop();
                FileWatcher = null;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopFileWatch();
        }
    }
}
