namespace RDR2Tool
{
    partial class Form1
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
            this.tb_game_dir = new System.Windows.Forms.TextBox();
            this.btn_choose_dir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_code = new System.Windows.Forms.TextBox();
            this.btn_code = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_game_dir
            // 
            this.tb_game_dir.Location = new System.Drawing.Point(81, 199);
            this.tb_game_dir.Name = "tb_game_dir";
            this.tb_game_dir.Size = new System.Drawing.Size(603, 21);
            this.tb_game_dir.TabIndex = 0;
            this.tb_game_dir.Text = "游戏路径";
            // 
            // btn_choose_dir
            // 
            this.btn_choose_dir.Location = new System.Drawing.Point(692, 197);
            this.btn_choose_dir.Name = "btn_choose_dir";
            this.btn_choose_dir.Size = new System.Drawing.Size(80, 26);
            this.btn_choose_dir.TabIndex = 2;
            this.btn_choose_dir.Text = "设置目录";
            this.btn_choose_dir.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 230);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5);
            this.label1.Size = new System.Drawing.Size(267, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "把startup.meta拖到图片，自动复制到游戏目录";
            // 
            // tb_code
            // 
            this.tb_code.Location = new System.Drawing.Point(384, 230);
            this.tb_code.Name = "tb_code";
            this.tb_code.Size = new System.Drawing.Size(300, 21);
            this.tb_code.TabIndex = 5;
            this.tb_code.Text = "这里输入卡单代码";
            // 
            // btn_code
            // 
            this.btn_code.Location = new System.Drawing.Point(692, 227);
            this.btn_code.Name = "btn_code";
            this.btn_code.Size = new System.Drawing.Size(80, 26);
            this.btn_code.TabIndex = 2;
            this.btn_code.Text = "输入代码";
            this.btn_code.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 198);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5);
            this.label2.Size = new System.Drawing.Size(63, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "游戏路径";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RDR2Tool.Properties.Resources.logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 261);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_code);
            this.Controls.Add(this.tb_game_dir);
            this.Controls.Add(this.btn_code);
            this.Controls.Add(this.btn_choose_dir);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "荒野大镖客2线上卡单工具";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_game_dir;
        private System.Windows.Forms.Button btn_choose_dir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_code;
        private System.Windows.Forms.Button btn_code;
        private System.Windows.Forms.Label label2;
    }
}

