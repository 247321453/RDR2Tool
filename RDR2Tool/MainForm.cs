using Common;
using MetroSet_UI.Forms;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RDR2Tool
{
    public partial class MainForm : MetroSetForm
    {
        private const string GAME_NAME = "Red Dead Redemption 2";
        private const string INI_FILE = "./rdr2tool.ini";
        private const string KEY_GAME_PATH = "game_path";
        private const string KEY_GAME_CODE = "game_code";
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                if (files != null && files.Length > 0)
                {
                    string ex = Path.GetExtension(files[0]);
                    if (".meta".Equals(ex, StringComparison.OrdinalIgnoreCase))
                    {
                        e.Effect = DragDropEffects.Link;
                        return;
                    }
                }
                e.Effect = DragDropEffects.None;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (files != null && files.Length > 0)
            {
                if (!CheckGamePath())
                {
                    MessageBox.Show("请先设置游戏路径");
                    return;
                }
                string path = tb_game_dir.Text.Trim();
                string file = files[0];
                string dst_file = Path.Combine(path, "x64", "data", "startup.meta");
                if (File.Exists(dst_file))
                {
                    if (MessageBox.Show("是否把startup.meta文件覆盖过去", "覆盖提示", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    {
                        return;
                    }
                }
                File.Copy(file, dst_file, true);
                if (!File.Exists(dst_file))
                {
                    MessageBox.Show("无法复制文件到游戏路径，请确保游戏路径是正确的,或者以管理员身份启动本工具");
                    return;
                }
                MessageBox.Show("卡单文件已经复制，你重启游戏即可进入该战局");
            }
        }

        private bool CheckGamePath()
        {
            string path = tb_game_dir.Text;
            return path != null && Directory.Exists(path);
        }

        private bool WriteFile(string code, string path)
        {
            //生成卡单文件
            try
            {
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
            catch {
                return false;
            }
        }

        private void Save()
        {
            string code = tb_code.Text.Trim();
            IniHelper.Write(KEY_GAME_CODE, code, INI_FILE);
            IniHelper.Write(KEY_GAME_PATH, tb_game_dir.Text, INI_FILE);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string gamePath = IniHelper.Read(KEY_GAME_PATH, SteamUtil.FindDefaultGamePath(GAME_NAME), INI_FILE);
            if (gamePath != null)
            {
                tb_game_dir.Text = gamePath;
            }
            tb_code.Text = IniHelper.Read(KEY_GAME_CODE, "", INI_FILE);
        }

        private void btn_enter_public_Click(object sender, EventArgs e)
        {
            if (!CheckGamePath())
            {
                MessageBox.Show("请先设置游戏路径");
                btn_choose_game_dir_Click(null, null);
                return;
            }

            string path = tb_game_dir.Text.Trim();
            string dst_file = Path.Combine(path, "x64", "data", "startup.meta");
            if (File.Exists(dst_file))
            {
                if (MessageBox.Show("是否删除startup.meta文件，以方便进入公开战局", "删除提示", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
                File.Delete(dst_file);
                //tb_code.Text = "";
                //Save();
                MessageBox.Show("文件已经删除，你重启游戏即可进入公开战局");
            }
            else
            {
                MessageBox.Show("你当前就是公开战局");
            }
            return;
        }

        private void btn_choose_game_dir_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "请选择" + GAME_NAME + "的游戏目录";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    tb_game_dir.Text = dlg.SelectedPath;
                    Save();
                }
            }
        }

        private void btn_set_code_Click(object sender, EventArgs e)
        {
            if (!CheckGamePath())
            {
                MessageBox.Show("请先设置游戏路径");
                btn_choose_game_dir_Click(null, null);
                return;
            }
            string code = tb_code.Text.Trim();
            string path = tb_game_dir.Text.Trim();
            string dst_file = Path.Combine(path, "x64", "data", "startup.meta");
            if (code.Length == 0)
            {
                if (File.Exists(dst_file))
                {
                    if (MessageBox.Show("是否删除startup.meta文件，以方便进入公开战局", "删除提示", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    {
                        return;
                    }
                    File.Delete(dst_file);
                    MessageBox.Show("文件已经删除，你重启游戏即可进入公开战局");
                }
                else
                {
                    MessageBox.Show("你当前就是公开战局");
                }
                return;
            }
            Save();
            if (!WriteFile(code, dst_file))
            {
                MessageBox.Show("无法保存文件到游戏路径，请确保游戏路径是正确的,或者以管理员身份启动本工具");
                return;
            }
            MessageBox.Show("卡单文件已经复制，你重启游戏即可进入该战局");
        }
    }
}
