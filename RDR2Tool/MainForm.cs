using Common;
using MetroSet_UI.Forms;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RDR2Tool
{
    public partial class MainForm : MetroSetForm
    {

        private const string GITHUB_URL = "https://github.com/247321453/RDR2Tool";
        private MetaFileManager metaFileManager = new MetaFileManager();
        //显示战局密码输入
        private static bool SHOW_CODE_UI = true;
        public MainForm()
        {
            InitializeComponent();
            cb_show_pwd.ForeColor = Color.Aqua;
            metroSetLink1.ForeColor = Color.Aqua;
            lb_title.ForeColor = Color.White;

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

        #region drop
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                if (files != null && files.Length > 0)
                {
                    if (metaFileManager.IsSupportFile(files[0]))
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
                CopyFile(files[0]);
            }
        }
        #endregion


        private bool CheckGamePath()
        {
            string path = metaFileManager.GamePath;
            return path != null && Directory.Exists(path);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            metaFileManager.Read();
            //读取数据
            tb_game_dir.Text = metaFileManager.GamePath;
            tb_code.Text = metaFileManager.ReadLastCode();
            tb_code_now.Text = metaFileManager.ReadGameCode();
        }

        private void OnButtonResetMetaFile_Click(object sender, EventArgs e)
        {
            if (!CheckGamePath())
            {
                MessageBox.Show("请先设置游戏路径");
                OnButtonChooseGamePath_Click(null, null);
                return;
            }
            //保存用户手动输入的游戏路径
            metaFileManager.SaveGamePath(tb_game_dir.Text);
            //还原文件
            ResetMetaFile();
        }

        private void OnButtonChooseGamePath_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.ShowNewFolderButton = false;
                dlg.Description = "请选择" + MetaFileManager.GAME_NAME + "的路径";
                //dlg.SelectedPath = SteamUtil.FindDefaultGamePath(MetaFileManager.GAME_NAME);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string name = Path.GetFileName(dlg.SelectedPath);
                    if("Desktop".Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        return;
                    }
                    if(!MetaFileManager.GAME_NAME.Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("警告：你选择的路径不是" + MetaFileManager.GAME_NAME);
                    }
                    tb_game_dir.Text = dlg.SelectedPath;
                    metaFileManager.SaveGamePath(dlg.SelectedPath);
                    tb_code_now.Text = metaFileManager.ReadGameCode();
                }
            }
        }

        private void OnButtonGenFile_Click(object sender, EventArgs e)
        {
            if (!CheckGamePath())
            {
                MessageBox.Show("请先设置游戏路径");
                OnButtonChooseGamePath_Click(null, null);
                return;
            }
            //保存用户手动输入的游戏路径
            metaFileManager.SaveGamePath(tb_game_dir.Text);
            string code = tb_code.Text.Trim();
            if (code.Length == 0)
            {
                //还原文件
                ResetMetaFile();
                return;
            }
            string temp_file = PathEx.GetFullPath("./startup_" + DateTime.Now.Ticks + ".meta");
            //生成本地卡单文件
            if (!metaFileManager.GenMetaFile(code, temp_file))
            {
                MessageBox.Show("生成卡单文件失败");
                return;
            }
            metaFileManager.SaveLastCode(code);
            //复制卡单文件
            CopyFile(temp_file, true);
        }

        private void CopyFile(string file, bool delete = false)
        {
            //复制卡单文件
            if (metaFileManager.SetMetaFile(file))
            {
                tb_code_now.Text = metaFileManager.ReadGameCode();
                MessageBox.Show("卡单文件已经复制到游戏目录，重启游戏即可进入该战局");
            }
            else
            {
                MessageBox.Show("无法保存文件到游戏路径，请确保游戏路径是正确的");
            }
            if (delete)
            {
                PathEx.DeleteFile(file);
            }
        }

        private void OnSourcesLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("查看工具的源代码，需要跳转到github.com", "跳转提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Process.Start(GITHUB_URL);
            }
        }

        private void OnShowCode_CheckedChanged(object sender)
        {
            tb_code_now.UseSystemPasswordChar = !cb_show_pwd.Checked;
        }


        private void ResetMetaFile()
        {
            if (tb_code_now.Text.Length > 0)
            {
                if (MessageBox.Show("是否删除卡单文件，以方便进入公开战局", "删除提示", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
                if (metaFileManager.DeleteMetaFile())
                {
                    tb_code_now.Text = metaFileManager.ReadGameCode();
                    MessageBox.Show("卡单文件已经删除，重启游戏即可进入公开战局");
                }
                else
                {
                    MessageBox.Show("没权限删除卡单文件，请不要把游戏安装在C盘");
                }
            }
            else
            {
                tb_code_now.Text = metaFileManager.ReadGameCode();
                MessageBox.Show("当前就是公开战局");
            }
        }

    }
}
