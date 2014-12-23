using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace rarTojpg
{
    public partial class FormMain : Form
    {
        private FileStream jpgFileStream = null;
        private FileStream rarFileStream = null;
        private FileStream outFileStream = null;

        private Packer packer;
        private Thread thread;

        private bool packing = false;

        private delegate void enableControlsDelegate(bool en);

        private delegate void refreshStatusDelegate(int round, int speed, double timeLeft);

        private enableControlsDelegate onEnableControls;

        private refreshStatusDelegate onRefreshStatus;


        public FormMain()
        {
            InitializeComponent();
            onEnableControls = new enableControlsDelegate(enableControls);
            onRefreshStatus = new refreshStatusDelegate(refreshStatus);
            try
            {
                this.jpgFileStream = new FileStream(@"./why.JPG",
                    FileMode.Open, FileAccess.Read);
                labelJpg.Text = "why.jpg";
            }
            catch
            {
                labelJpg.Text = "*.jpg";
            }
            try
            {
                this.rarFileStream = new FileStream(@"./null.rar",
                    FileMode.Open, FileAccess.Read);
                labelRar.Text = "null.rar";
            }
            catch
            {
                labelRar.Text = "*.rar";
            }
        }

        /// <summary>
        /// “选择图片”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonJpg_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择图片";
            ofd.Filter = "图片 (*.jpg; *.bmp; *.png; *.gif) |" +
                "*.jpg; *.jpeg; *.jpe; *.jfif; *.bmp; *.dib; *.png; *.gif";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                openJpg(ofd.FileName);
            }
        }

        /// <summary>
        /// 打开图片文件
        /// </summary>
        /// <param name="fileName"></param>
        private void openJpg(string fileName)
        {
            try
            {
                labelJpg.Text = "";
                if (this.jpgFileStream != null)
                {
                    this.jpgFileStream.Close();
                }
                this.jpgFileStream = new FileStream(fileName,
                    FileMode.Open, FileAccess.Read);
                labelJpg.Text = fileName;
            }
            catch
            {
                this.jpgFileStream = null;
                labelJpg.Text = "打开失败！";
            }
        }

        /// <summary>
        /// “选择压缩包”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择压缩文件";
            ofd.Filter = "压缩包 (*.rar; *.zip) |*.rar; *.zip";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                openRar(ofd.FileName);
            }
        }

        /// <summary>
        /// 打开压缩包
        /// </summary>
        /// <param name="fileName"></param>
        private void openRar(string fileName)
        {
            try
            {
                labelRar.Text = "";
                if (this.rarFileStream != null)
                {
                    this.rarFileStream.Close();
                }
                this.rarFileStream = new FileStream(fileName,
                    FileMode.Open, FileAccess.Read);
                labelRar.Text = fileName;
            }
            catch
            {
                this.rarFileStream = null;
                labelRar.Text = "打开失败！";
            }
        }

        /// <summary>
        /// “why”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("将压缩包与图片打包。\n请勿用于非法目的。\n" +
                "将扩展名jpg改为rar即可解压。\n重要：打包完成后请自行测试。\n" +
                "有的图片可能会失败，建议用jpg格式。\n如果反复失败请重启程序。");
        }

        /// <summary>
        /// “生成”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDo_Click(object sender, EventArgs e)
        {
            if (jpgFileStream == null || rarFileStream == null)
            {
                MessageBox.Show("请先选择要打包的文件。");
                return;
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "保存打包文件";
            sfd.Filter = "JPEG (*.jpg) |*.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                disableControls();
                this.toolStripProgressBar.Maximum =
                    (int)((jpgFileStream.Length + rarFileStream.Length) / Packer.MaxBytes) + 1;
                try
                {
                    if (outFileStream != null)
                    {
                        outFileStream.Close();
                    }
                    outFileStream = new FileStream(sfd.FileName,
                        FileMode.Create, FileAccess.Write);
                    this.packer = new Packer(jpgFileStream,
                        rarFileStream, outFileStream);
                    this.packer.OnPackFinished +=
                        new Packer.PackFinishedDelegate(packFinishedEventHandler);
                    this.packer.OnRoundFinished +=
                        new Packer.RoundFinishedDelegate(roundFinishedEventHandler);
                    this.thread = new Thread(new ThreadStart(packer.ThreadStart));
                    thread.Start();
                }
                catch
                {
                    MessageBox.Show("保存失败！");
                    enableControls();
                }
            }
        }

        /// <summary>
        /// “退出”
        /// /
        /// “取消”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonQuit_Click(object sender, EventArgs e)
        {
            if (!this.packing)
            {
                Application.Exit();
            }
            else
            {
                try
                {
                    if (thread.ThreadState == ThreadState.Running)
                    {
                        thread.Abort();
                    }
                }
                catch { }
                try
                {
                    if (this.outFileStream != null)
                    {
                        this.outFileStream.Close();
                    }
                }
                catch { }
                enableControls();
            }
        }

        /// <summary>
        /// 禁用控件，显示状态。
        /// 当正在进行文件打包时调用。
        /// </summary>
        private void disableControls()
        {
            enableControls(false);
        }

        /// <summary>
        /// 启用控件，隐藏状态。
        /// 当结束文件打包时调用。
        /// </summary>
        /// <param name="en">显示控件，隐藏状态</param>
        private void enableControls(bool en = true)
        {
            buttonJpg.Enabled = en;
            buttonRar.Enabled = en;
            buttonHelp.Enabled = en;
            buttonDo.Enabled = en;
            this.ControlBox = en;
            this.packing = !en;
            toolStripProgressBar.Visible = !en;
            toolStripStatusLabelSpeed.Visible = !en;
            toolStripStatusLabelTimeLeft.Visible = !en;
            if (en)
            {
                toolStripStatusLabelStatus.Text = "就绪";
                buttonQuit.Text = "退出(&X)";
            }
            else
            {
                toolStripStatusLabelStatus.Text = "正在打包...";
                buttonQuit.Text = "取消操作(&C)";
                toolStripProgressBar.Value = 0;
                toolStripStatusLabelSpeed.Text = "平均速度：正在计算...";
                toolStripStatusLabelTimeLeft.Text = "预计剩余时间：正在计算...";
            }
        }

        private void refreshStatus(int round, int speed, double timeLeft)
        {
            try
            {
                toolStripStatusLabelSpeed.Text =
                    string.Format("平均速度：{0:0,0.##}MB/秒", speed / 1024.0);
                string stringTimeLeft = string.Format("{0:0.##}秒", timeLeft % 60);
                if (timeLeft >= 60)
                {
                    stringTimeLeft =
                        string.Format("{0}分{1}", ((int)timeLeft / 60) % 60, stringTimeLeft);
                    if (timeLeft >= 3600)
                    {
                        stringTimeLeft =
                            string.Format("{0}小时{1}",
                            ((int)timeLeft / 3600) % 60, stringTimeLeft);
                    }
                }
                toolStripStatusLabelTimeLeft.Text =
                    string.Format("预计剩余时间：{0}", stringTimeLeft);
                toolStripProgressBar.Value = round;
            }
            catch { }
        }

        /// <summary>
        /// 文件打包完成，解除锁定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void packFinishedEventHandler(object sender, EventArgs e)
        {
            try
            {
                outFileStream.Close();
                MessageBox.Show("打包成功！");
            }
            catch { }
            this.BeginInvoke(onEnableControls, true);
        }

        /// <summary>
        /// 一轮操作完成，刷新显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">参数</param>
        private void roundFinishedEventHandler(object sender, RoundFinishedEventArgs e)
        {
            this.BeginInvoke(onRefreshStatus, new object[]{ e.round, (e.speed >> 10), e.timeLeft });
        }

        /// <summary>
        /// 拖入文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// 放下文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            string fileName = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            string extension = Path.GetExtension(fileName).ToLower();
            if (extension == ".jpg" || extension == ".bmp" || extension == ".png")
            {
                openJpg(fileName);
            }
            else if (extension == ".rar" || extension == ".zip")
            {
                openRar(fileName);
            }
        }
    }
}
