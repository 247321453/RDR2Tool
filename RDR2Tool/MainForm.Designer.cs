namespace RDR2Tool
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label2 = new System.Windows.Forms.Label();
            this._ignore_ctrlbox = new MetroSet_UI.Controls.MetroSetControlBox();
            this.lb_code = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_enter_public = new MetroSet_UI.Controls.MetroSetButton();
            this.btn_choose_game_dir = new MetroSet_UI.Controls.MetroSetButton();
            this.btn_set_code = new MetroSet_UI.Controls.MetroSetButton();
            this.tb_game_dir = new MetroSet_UI.Controls.MetroSetTextBox();
            this.tb_code = new MetroSet_UI.Controls.MetroSetTextBox();
            this.metroSetLink1 = new MetroSet_UI.Controls.MetroSetLink();
            this.lb_code_now = new System.Windows.Forms.Label();
            this.tb_code_now = new MetroSet_UI.Controls.MetroSetTextBox();
            this.cb_show_pwd = new MetroSet_UI.Controls.MetroSetCheckBox();
            this.lb_title = new MetroSet_UI.Controls.MetroSetLabel();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 178);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(3);
            this.label2.Size = new System.Drawing.Size(62, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "游戏路径";
            // 
            // _ignore_ctrlbox
            // 
            this._ignore_ctrlbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._ignore_ctrlbox.CloseHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this._ignore_ctrlbox.CloseHoverForeColor = System.Drawing.Color.White;
            this._ignore_ctrlbox.CloseNormalForeColor = System.Drawing.Color.Gray;
            this._ignore_ctrlbox.DisabledForeColor = System.Drawing.Color.Silver;
            this._ignore_ctrlbox.Location = new System.Drawing.Point(559, 2);
            this._ignore_ctrlbox.MaximizeBox = false;
            this._ignore_ctrlbox.MaximizeHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this._ignore_ctrlbox.MaximizeHoverForeColor = System.Drawing.Color.Gray;
            this._ignore_ctrlbox.MaximizeNormalForeColor = System.Drawing.Color.Gray;
            this._ignore_ctrlbox.MinimizeBox = true;
            this._ignore_ctrlbox.MinimizeHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this._ignore_ctrlbox.MinimizeHoverForeColor = System.Drawing.Color.Gray;
            this._ignore_ctrlbox.MinimizeNormalForeColor = System.Drawing.Color.Gray;
            this._ignore_ctrlbox.Name = "_ignore_ctrlbox";
            this._ignore_ctrlbox.Size = new System.Drawing.Size(100, 25);
            this._ignore_ctrlbox.Style = MetroSet_UI.Design.Style.Dark;
            this._ignore_ctrlbox.StyleManager = null;
            this._ignore_ctrlbox.TabIndex = 6;
            this._ignore_ctrlbox.ThemeAuthor = "Narwin";
            this._ignore_ctrlbox.ThemeName = "MetroDark";
            // 
            // lb_code
            // 
            this.lb_code.AutoSize = true;
            this.lb_code.BackColor = System.Drawing.Color.Transparent;
            this.lb_code.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.lb_code.ForeColor = System.Drawing.Color.White;
            this.lb_code.Location = new System.Drawing.Point(3, 213);
            this.lb_code.Name = "lb_code";
            this.lb_code.Padding = new System.Windows.Forms.Padding(3);
            this.lb_code.Size = new System.Drawing.Size(62, 23);
            this.lb_code.TabIndex = 4;
            this.lb_code.Text = "战局密码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(367, 211);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(5);
            this.label4.Size = new System.Drawing.Size(198, 27);
            this.label4.TabIndex = 4;
            this.label4.Text = "把卡单文件拖到界面，会自动复制";
            // 
            // btn_enter_public
            // 
            this.btn_enter_public.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btn_enter_public.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btn_enter_public.DisabledForeColor = System.Drawing.Color.Gray;
            this.btn_enter_public.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.btn_enter_public.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btn_enter_public.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btn_enter_public.HoverTextColor = System.Drawing.Color.White;
            this.btn_enter_public.Location = new System.Drawing.Point(578, 210);
            this.btn_enter_public.Name = "btn_enter_public";
            this.btn_enter_public.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btn_enter_public.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btn_enter_public.NormalTextColor = System.Drawing.Color.White;
            this.btn_enter_public.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btn_enter_public.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btn_enter_public.PressTextColor = System.Drawing.Color.White;
            this.btn_enter_public.Size = new System.Drawing.Size(75, 28);
            this.btn_enter_public.Style = MetroSet_UI.Design.Style.Dark;
            this.btn_enter_public.StyleManager = null;
            this.btn_enter_public.TabIndex = 3;
            this.btn_enter_public.Text = "公开战局";
            this.btn_enter_public.ThemeAuthor = "Narwin";
            this.btn_enter_public.ThemeName = "MetroDark";
            this.btn_enter_public.Click += new System.EventHandler(this.OnButtonResetMetaFile_Click);
            // 
            // btn_choose_game_dir
            // 
            this.btn_choose_game_dir.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btn_choose_game_dir.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btn_choose_game_dir.DisabledForeColor = System.Drawing.Color.Gray;
            this.btn_choose_game_dir.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.btn_choose_game_dir.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btn_choose_game_dir.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btn_choose_game_dir.HoverTextColor = System.Drawing.Color.White;
            this.btn_choose_game_dir.Location = new System.Drawing.Point(578, 176);
            this.btn_choose_game_dir.Name = "btn_choose_game_dir";
            this.btn_choose_game_dir.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btn_choose_game_dir.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btn_choose_game_dir.NormalTextColor = System.Drawing.Color.White;
            this.btn_choose_game_dir.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btn_choose_game_dir.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btn_choose_game_dir.PressTextColor = System.Drawing.Color.White;
            this.btn_choose_game_dir.Size = new System.Drawing.Size(75, 28);
            this.btn_choose_game_dir.Style = MetroSet_UI.Design.Style.Dark;
            this.btn_choose_game_dir.StyleManager = null;
            this.btn_choose_game_dir.TabIndex = 0;
            this.btn_choose_game_dir.Text = "设置目录";
            this.btn_choose_game_dir.ThemeAuthor = "Narwin";
            this.btn_choose_game_dir.ThemeName = "MetroDark";
            this.btn_choose_game_dir.Click += new System.EventHandler(this.OnButtonChooseGamePath_Click);
            // 
            // btn_set_code
            // 
            this.btn_set_code.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btn_set_code.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btn_set_code.DisabledForeColor = System.Drawing.Color.Gray;
            this.btn_set_code.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.btn_set_code.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btn_set_code.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btn_set_code.HoverTextColor = System.Drawing.Color.White;
            this.btn_set_code.Location = new System.Drawing.Point(288, 210);
            this.btn_set_code.Name = "btn_set_code";
            this.btn_set_code.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btn_set_code.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btn_set_code.NormalTextColor = System.Drawing.Color.White;
            this.btn_set_code.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btn_set_code.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btn_set_code.PressTextColor = System.Drawing.Color.White;
            this.btn_set_code.Size = new System.Drawing.Size(75, 28);
            this.btn_set_code.Style = MetroSet_UI.Design.Style.Dark;
            this.btn_set_code.StyleManager = null;
            this.btn_set_code.TabIndex = 4;
            this.btn_set_code.Text = "生成文件";
            this.btn_set_code.ThemeAuthor = "Narwin";
            this.btn_set_code.ThemeName = "MetroDark";
            this.btn_set_code.Click += new System.EventHandler(this.OnButtonGenFile_Click);
            // 
            // tb_game_dir
            // 
            this.tb_game_dir.AutoCompleteCustomSource = null;
            this.tb_game_dir.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.tb_game_dir.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.tb_game_dir.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.tb_game_dir.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.tb_game_dir.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tb_game_dir.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tb_game_dir.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.tb_game_dir.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.tb_game_dir.Image = null;
            this.tb_game_dir.Lines = null;
            this.tb_game_dir.Location = new System.Drawing.Point(70, 176);
            this.tb_game_dir.MaxLength = 1024;
            this.tb_game_dir.Multiline = false;
            this.tb_game_dir.Name = "tb_game_dir";
            this.tb_game_dir.ReadOnly = false;
            this.tb_game_dir.Size = new System.Drawing.Size(502, 27);
            this.tb_game_dir.Style = MetroSet_UI.Design.Style.Dark;
            this.tb_game_dir.StyleManager = null;
            this.tb_game_dir.TabIndex = 1;
            this.tb_game_dir.Text = "请设置游戏路径";
            this.tb_game_dir.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_game_dir.ThemeAuthor = "Narwin";
            this.tb_game_dir.ThemeName = "MetroDark";
            this.tb_game_dir.UseSystemPasswordChar = false;
            this.tb_game_dir.WatermarkText = "";
            // 
            // tb_code
            // 
            this.tb_code.AutoCompleteCustomSource = null;
            this.tb_code.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.tb_code.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.tb_code.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.tb_code.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.tb_code.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tb_code.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tb_code.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.tb_code.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.tb_code.Image = null;
            this.tb_code.Lines = null;
            this.tb_code.Location = new System.Drawing.Point(70, 211);
            this.tb_code.MaxLength = 100;
            this.tb_code.Multiline = false;
            this.tb_code.Name = "tb_code";
            this.tb_code.ReadOnly = false;
            this.tb_code.Size = new System.Drawing.Size(210, 27);
            this.tb_code.Style = MetroSet_UI.Design.Style.Dark;
            this.tb_code.StyleManager = null;
            this.tb_code.TabIndex = 3;
            this.tb_code.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_code.ThemeAuthor = "Narwin";
            this.tb_code.ThemeName = "MetroDark";
            this.tb_code.UseSystemPasswordChar = true;
            this.tb_code.WatermarkText = "";
            // 
            // metroSetLink1
            // 
            this.metroSetLink1.AutoSize = true;
            this.metroSetLink1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroSetLink1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.metroSetLink1.LinkArea = new System.Windows.Forms.LinkArea(0, 8);
            this.metroSetLink1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.metroSetLink1.Location = new System.Drawing.Point(585, 30);
            this.metroSetLink1.Name = "metroSetLink1";
            this.metroSetLink1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.metroSetLink1.Size = new System.Drawing.Size(74, 22);
            this.metroSetLink1.Style = MetroSet_UI.Design.Style.Dark;
            this.metroSetLink1.StyleManager = null;
            this.metroSetLink1.TabIndex = 7;
            this.metroSetLink1.TabStop = true;
            this.metroSetLink1.Text = "Github源码";
            this.metroSetLink1.ThemeAuthor = "Narwin";
            this.metroSetLink1.ThemeName = "MetroLite";
            this.metroSetLink1.UseCompatibleTextRendering = true;
            this.metroSetLink1.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(157)))), ((int)(((byte)(205)))));
            this.metroSetLink1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnSourcesLabel_LinkClicked);
            // 
            // lb_code_now
            // 
            this.lb_code_now.AutoSize = true;
            this.lb_code_now.BackColor = System.Drawing.Color.Transparent;
            this.lb_code_now.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.lb_code_now.ForeColor = System.Drawing.Color.White;
            this.lb_code_now.Location = new System.Drawing.Point(3, 145);
            this.lb_code_now.Name = "lb_code_now";
            this.lb_code_now.Padding = new System.Windows.Forms.Padding(3);
            this.lb_code_now.Size = new System.Drawing.Size(62, 23);
            this.lb_code_now.TabIndex = 4;
            this.lb_code_now.Text = "当前战局";
            // 
            // tb_code_now
            // 
            this.tb_code_now.AutoCompleteCustomSource = null;
            this.tb_code_now.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.tb_code_now.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.tb_code_now.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.tb_code_now.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.tb_code_now.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tb_code_now.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tb_code_now.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.tb_code_now.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.tb_code_now.Image = null;
            this.tb_code_now.Lines = null;
            this.tb_code_now.Location = new System.Drawing.Point(70, 144);
            this.tb_code_now.MaxLength = 100;
            this.tb_code_now.Multiline = false;
            this.tb_code_now.Name = "tb_code_now";
            this.tb_code_now.ReadOnly = false;
            this.tb_code_now.Size = new System.Drawing.Size(210, 27);
            this.tb_code_now.Style = MetroSet_UI.Design.Style.Dark;
            this.tb_code_now.StyleManager = null;
            this.tb_code_now.TabIndex = 3;
            this.tb_code_now.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_code_now.ThemeAuthor = "Narwin";
            this.tb_code_now.ThemeName = "MetroDark";
            this.tb_code_now.UseSystemPasswordChar = true;
            this.tb_code_now.WatermarkText = "";
            // 
            // cb_show_pwd
            // 
            this.cb_show_pwd.BackColor = System.Drawing.Color.Transparent;
            this.cb_show_pwd.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cb_show_pwd.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.cb_show_pwd.Checked = false;
            this.cb_show_pwd.CheckSignColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.cb_show_pwd.CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
            this.cb_show_pwd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_show_pwd.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.cb_show_pwd.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.cb_show_pwd.Location = new System.Drawing.Point(288, 148);
            this.cb_show_pwd.Name = "cb_show_pwd";
            this.cb_show_pwd.SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
            this.cb_show_pwd.Size = new System.Drawing.Size(75, 16);
            this.cb_show_pwd.Style = MetroSet_UI.Design.Style.Dark;
            this.cb_show_pwd.StyleManager = null;
            this.cb_show_pwd.TabIndex = 8;
            this.cb_show_pwd.Text = "显示密码";
            this.cb_show_pwd.ThemeAuthor = "Narwin";
            this.cb_show_pwd.ThemeName = "MetroDark";
            this.cb_show_pwd.CheckedChanged += new MetroSet_UI.Controls.MetroSetCheckBox.CheckedChangedEventHandler(this.OnShowCode_CheckedChanged);
            // 
            // lb_title
            // 
            this.lb_title.AutoSize = true;
            this.lb_title.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_title.Location = new System.Drawing.Point(253, 2);
            this.lb_title.Name = "lb_title";
            this.lb_title.Size = new System.Drawing.Size(164, 22);
            this.lb_title.Style = MetroSet_UI.Design.Style.Dark;
            this.lb_title.StyleManager = null;
            this.lb_title.TabIndex = 9;
            this.lb_title.Text = "荒野大镖客2卡单工具";
            this.lb_title.ThemeAuthor = "Narwin";
            this.lb_title.ThemeName = "MetroDark";
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AllowResize = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.BackgroundImage = global::RDR2Tool.Properties.Resources.logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(662, 245);
            this.Controls.Add(this._ignore_ctrlbox);
            this.Controls.Add(this.lb_title);
            this.Controls.Add(this.cb_show_pwd);
            this.Controls.Add(this.metroSetLink1);
            this.Controls.Add(this.tb_code_now);
            this.Controls.Add(this.tb_code);
            this.Controls.Add(this.tb_game_dir);
            this.Controls.Add(this.btn_set_code);
            this.Controls.Add(this.btn_choose_game_dir);
            this.Controls.Add(this.btn_enter_public);
            this.Controls.Add(this.lb_code_now);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_code);
            this.Controls.Add(this.label4);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(12, 90, 12, 12);
            this.ShowLeftRect = false;
            this.ShowTitle = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Style = MetroSet_UI.Design.Style.Dark;
            this.Text = "荒野大镖客2线上卡单工具";
            this.TextColor = System.Drawing.Color.White;
            this.ThemeName = "MetroDark";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private MetroSet_UI.Controls.MetroSetControlBox _ignore_ctrlbox;
        private System.Windows.Forms.Label lb_code;
        private System.Windows.Forms.Label label4;
        private MetroSet_UI.Controls.MetroSetButton btn_enter_public;
        private MetroSet_UI.Controls.MetroSetButton btn_choose_game_dir;
        private MetroSet_UI.Controls.MetroSetButton btn_set_code;
        private MetroSet_UI.Controls.MetroSetTextBox tb_game_dir;
        private MetroSet_UI.Controls.MetroSetTextBox tb_code;
        private MetroSet_UI.Controls.MetroSetLink metroSetLink1;
        private System.Windows.Forms.Label lb_code_now;
        private MetroSet_UI.Controls.MetroSetTextBox tb_code_now;
        private MetroSet_UI.Controls.MetroSetCheckBox cb_show_pwd;
        private MetroSet_UI.Controls.MetroSetLabel lb_title;
    }
}

