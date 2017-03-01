using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace Win10LockScreenImageExtractTool
{
    public partial class MainForm : Form
    {
        private delegate void UpdateShowEventHandler(string str, int value);
        private event UpdateShowEventHandler UpdateShow;
        private delegate void UpdateProgressEventHandler(bool show);
        private event UpdateProgressEventHandler UpdateProgress;

        private Thread background;
        private List<FileInfo> pathes = new List<FileInfo>();

        public MainForm()
        {
            if (Environment.OSVersion.Version.Major != 10)
            {
                if (DialogResult.OK == MessageBox.Show("此工具仅支持Win10操作系统，其它系统不支持！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error))
                {
                    Environment.Exit(0x00);
                }
            }
            else
            {
                InitializeComponent();
            }
        }

        private void OnUpdateShow(string str, int value)
        {
            this.Invoke(new Action(delegate
                 {
                     label_Info.Text = str;
                     progressBar.Value = value;
                 }));
        }

        private void OnUpdateProgress(bool show)
        {
            this.Invoke(new Action(delegate 
                {
                    if (show)//显示进度条，功能不可用
                    {
                        progressBar.Visible = true; 
                        textBox_Target.Enabled = false;
                        OK.Enabled = false;
                        Browse.Enabled = false;
                        checkBox.Enabled = false;
                    }
                    else
                    {
                        progressBar.Visible = false;
                        textBox_Target.Enabled = true;
                        OK.Enabled = true;
                        Browse.Enabled = true;
                        checkBox.Enabled = true;
                    }
                }));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            background = new Thread(CheckAndBuildList);
            background.Start();
        }

        private void CheckAndBuildList()
        {
            UpdateShow += OnUpdateShow;
            UpdateProgress += OnUpdateProgress;
            UpdateProgress.Invoke(true);

            // 设置锁屏文件的文件夹路径
            string Folder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            Folder += @"\AppData\Local\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets";


            if (Directory.Exists(Folder))
            {

                DirectoryInfo folder = new DirectoryInfo(Folder);
                FileInfo[] files = folder.GetFiles();

                int AllFilesCount = files.Count();

                UpdateShow.Invoke(string.Format("共检测到{0}个文件，准备开始分析", AllFilesCount), 0);

                int index = 0;

                foreach (FileInfo info in files)
                {
                    index++;
                    UpdateShow.Invoke(string.Format("正在分析第{0}个文件...", index), (int)(((double)index * 100) / AllFilesCount));
                    if (info.Length > 100000)
                    {
                        pathes.Add(info);
                    }
                }

                UpdateShow.Invoke(string.Format("共检测到{0}个有效文件，请先选择导出文件夹，再点击“导出”进行导出", pathes.Count()), 100);
                Thread.Sleep(500);

                UpdateProgress.Invoke(false);
            }
            else
            {
                MessageBox.Show("无法检测到指定路径，可能您的系统尚未打开或不支持该功能，运行错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateShow -= OnUpdateShow;
            UpdateProgress -= OnUpdateProgress;
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (DialogResult.OK == dlg.ShowDialog())
            {
                textBox_Target.Text = dlg.SelectedPath;
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            background = new Thread(ExtractFiles);
            background.Start();
        }


        private void ExtractFiles()
        {
            UpdateShow += OnUpdateShow;
            UpdateProgress += OnUpdateProgress;
            UpdateProgress.Invoke(true);

            if (Directory.Exists(textBox_Target.Text))
            {
                StreamReader sr;
                StreamWriter sw;

                UpdateShow.Invoke("开始导出文件", 0);

                string Folder = textBox_Target.Text + "\\";
                int index = 0;
                int fail = 0;
                string TargetPath;

                foreach (FileInfo info in pathes)
                {
                    index++;
                    UpdateShow.Invoke(string.Format("正在提取第{0}个文件，文件大小为：{1}KB", index, info.Length / 1024),
                        (int)(((double)index * 100) / pathes.Count()));

                    TargetPath = Folder + index.ToString("D8") + ".jpg";
                    try
                    {
                        File.Copy(info.FullName, TargetPath);
                    }
                    catch(IOException e)
                    {
                        fail++;
                    }
                }

                UpdateShow.Invoke(string.Format("成功导出{0}个文件，失败{1}个！", pathes.Count() - fail, fail), 100);
                    Thread.Sleep(500);

                    if (checkBox.Checked)
                    {
                        System.Diagnostics.Process.Start("explorer.exe", Folder);
                    }
            }
            else
            {
                MessageBox.Show("无法检测到目标路径，运行错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateProgress.Invoke(false);

            UpdateShow += OnUpdateShow;
            UpdateProgress += OnUpdateProgress;
        }
    }
}
