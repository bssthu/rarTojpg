namespace rarTojpg
{
    partial class FormMain
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonJpg = new System.Windows.Forms.Button();
            this.buttonRar = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonDo = new System.Windows.Forms.Button();
            this.labelJpg = new System.Windows.Forms.Label();
            this.labelRar = new System.Windows.Forms.Label();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabelSpeed = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTimeLeft = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonJpg
            // 
            this.buttonJpg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonJpg.Location = new System.Drawing.Point(372, 4);
            this.buttonJpg.Name = "buttonJpg";
            this.buttonJpg.Size = new System.Drawing.Size(99, 23);
            this.buttonJpg.TabIndex = 2;
            this.buttonJpg.Text = "选择图片(&J)";
            this.buttonJpg.UseVisualStyleBackColor = true;
            this.buttonJpg.Click += new System.EventHandler(this.buttonJpg_Click);
            // 
            // buttonRar
            // 
            this.buttonRar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonRar.Location = new System.Drawing.Point(372, 35);
            this.buttonRar.Name = "buttonRar";
            this.buttonRar.Size = new System.Drawing.Size(99, 23);
            this.buttonRar.TabIndex = 3;
            this.buttonRar.Text = "选择压缩包(&R)";
            this.buttonRar.UseVisualStyleBackColor = true;
            this.buttonRar.Click += new System.EventHandler(this.buttonRar_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonHelp.Location = new System.Drawing.Point(12, 64);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(75, 23);
            this.buttonHelp.TabIndex = 4;
            this.buttonHelp.Text = "(&W)hy";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // buttonDo
            // 
            this.buttonDo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDo.Location = new System.Drawing.Point(93, 64);
            this.buttonDo.Name = "buttonDo";
            this.buttonDo.Size = new System.Drawing.Size(273, 23);
            this.buttonDo.TabIndex = 5;
            this.buttonDo.Text = "生成(&S)";
            this.buttonDo.UseVisualStyleBackColor = true;
            this.buttonDo.Click += new System.EventHandler(this.buttonDo_Click);
            // 
            // labelJpg
            // 
            this.labelJpg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelJpg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelJpg.Location = new System.Drawing.Point(12, 4);
            this.labelJpg.Name = "labelJpg";
            this.labelJpg.Size = new System.Drawing.Size(354, 23);
            this.labelJpg.TabIndex = 6;
            this.labelJpg.Text = "*.jpg";
            // 
            // labelRar
            // 
            this.labelRar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelRar.Location = new System.Drawing.Point(12, 35);
            this.labelRar.Name = "labelRar";
            this.labelRar.Size = new System.Drawing.Size(354, 23);
            this.labelRar.TabIndex = 7;
            this.labelRar.Text = "*.rar";
            // 
            // buttonQuit
            // 
            this.buttonQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonQuit.Location = new System.Drawing.Point(372, 64);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(99, 23);
            this.buttonQuit.TabIndex = 5;
            this.buttonQuit.Text = "退出(&X)";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelStatus,
            this.toolStripProgressBar,
            this.toolStripStatusLabelSpeed,
            this.toolStripStatusLabelTimeLeft});
            this.statusStrip.Location = new System.Drawing.Point(0, 94);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(483, 22);
            this.statusStrip.TabIndex = 8;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabelStatus
            // 
            this.toolStripStatusLabelStatus.Name = "toolStripStatusLabelStatus";
            this.toolStripStatusLabelStatus.Size = new System.Drawing.Size(31, 17);
            this.toolStripStatusLabelStatus.Text = "就绪";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar.Value = 50;
            this.toolStripProgressBar.Visible = false;
            // 
            // toolStripStatusLabelSpeed
            // 
            this.toolStripStatusLabelSpeed.Name = "toolStripStatusLabelSpeed";
            this.toolStripStatusLabelSpeed.Size = new System.Drawing.Size(31, 17);
            this.toolStripStatusLabelSpeed.Text = "速度";
            this.toolStripStatusLabelSpeed.Visible = false;
            // 
            // toolStripStatusLabelTimeLeft
            // 
            this.toolStripStatusLabelTimeLeft.Name = "toolStripStatusLabelTimeLeft";
            this.toolStripStatusLabelTimeLeft.Size = new System.Drawing.Size(55, 17);
            this.toolStripStatusLabelTimeLeft.Text = "剩余时间";
            this.toolStripStatusLabelTimeLeft.Visible = false;
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 116);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.labelRar);
            this.Controls.Add(this.labelJpg);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.buttonDo);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.buttonRar);
            this.Controls.Add(this.buttonJpg);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(277, 147);
            this.Name = "FormMain";
            this.Text = "打包工具";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonJpg;
        private System.Windows.Forms.Button buttonRar;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Button buttonDo;
        private System.Windows.Forms.Label labelJpg;
        private System.Windows.Forms.Label labelRar;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatus;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSpeed;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTimeLeft;
    }
}

