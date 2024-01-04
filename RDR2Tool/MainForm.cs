using Common;
using MetroSet_UI.Forms;
using System;
using System.CodeDom;
using System.Diagnostics;
using System.Drawing;
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
        private const string GITHUB_URL = "https://github.com/247321453/RDR2Tool";
        //显示战局密码输入
        private static bool SHOW_CODE_UI = true;
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
                string dir = Path.Combine(path, "x64", "data");
                string dst_file = Path.Combine(dir, "startup.meta");
                if (File.Exists(dst_file))
                {
                    if (MessageBox.Show("是否把该卡单文件替换游戏目录的文件", "覆盖提示", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    {
                        return;
                    }
                }
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                File.Copy(file, dst_file, true);
                if (!File.Exists(dst_file))
                {
                    MessageBox.Show("无法复制文件到游戏路径，请确保游戏路径是正确的,或者以管理员身份启动本工具");
                    return;
                }
                string code = ReadCode(file);
                tb_code.Text = code;
                Save();
                UpdateCurrentCode();
                MessageBox.Show("卡单文件已经复制，你重启游戏即可进入该战局");
            }
        }

        private bool CheckGamePath()
        {
            string path = tb_game_dir.Text;
            return path != null && Directory.Exists(path);
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
                } else
                {
                    return "无法识别的卡单文件";
                }
            }
            return "";
        }

        private bool WriteFile(string code, string path)
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
            catch {
                return false;
            }
        }

        private void Save()
        {
            if (tb_code.Visible)
            {
                string code = tb_code.Text.Trim();
                tb_code_now.Text = code;
                IniHelper.Write(KEY_GAME_CODE, code, INI_FILE);
            }
            IniHelper.Write(KEY_GAME_PATH, tb_game_dir.Text, INI_FILE);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cb_show_pwd.ForeColor = Color.Aqua;
            metroSetLink1.ForeColor = Color.Aqua;
            lb_title.ForeColor = Color.White;
            string gamePath = IniHelper.Read(KEY_GAME_PATH, null, INI_FILE);
            if(gamePath == null)
            {
                gamePath = SteamUtil.FindDefaultGamePath(GAME_NAME);
                Save();
            }
            if (gamePath != null)
            {
                tb_game_dir.Text = gamePath;
            }
            tb_code.Text = IniHelper.Read(KEY_GAME_CODE, "", INI_FILE);
            UpdateCurrentCode();

            if (!SHOW_CODE_UI)
            {
                //隐藏UI
                lb_code.Visible = false;
                lb_code_now.Visible = false;
                tb_code_now.Visible = false;
                cb_show_pwd.Visible = false;
                tb_code.Visible = false;
                btn_set_code.Visible = false;
            }
        }

        private void UpdateCurrentCode()
        {
            string path = tb_game_dir.Text.Trim();
            string dir = Path.Combine(path, "x64", "data");
            string dst_file = Path.Combine(dir, "startup.meta");
            string code = ReadCode(dst_file);
            tb_code_now.Text = code;
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
                if (MessageBox.Show("是否删除卡单文件，以方便进入公开战局", "删除提示", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
                File.Delete(dst_file);
                UpdateCurrentCode();
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
                dlg.Description = "请选择" + GAME_NAME + "的路径";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    tb_game_dir.Text = dlg.SelectedPath;
                    Save();
                    UpdateCurrentCode();
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
            if (!WriteFile(code, dst_file))
            {
                MessageBox.Show("无法保存文件到游戏路径，请确保游戏路径是正确的,或者以管理员身份启动本工具");
                return;
            }
            Save();
            UpdateCurrentCode();
            MessageBox.Show("卡单文件已经复制完成，你重启游戏即可进入该战局");
        }

        private void metroSetLink1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(GITHUB_URL);
        }

        private void cb_show_pwd_CheckedChanged(object sender)
        {
            tb_code_now.UseSystemPasswordChar = !cb_show_pwd.Checked;
        }
    }
}
