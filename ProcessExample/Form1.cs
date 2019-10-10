using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace ProcessExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            process1.StartInfo.FileName = "notepad.exe";
            //启动Notepad.exe 进程.
            process1.Start();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            //创建新的Process 组件的数组,并将它们与指定的进程名称（Notepad）的所有进程资源相关联.
            Process[] myprocesses;
            myprocesses = Process.GetProcessesByName("Notepad");
            foreach (Process instance in myprocesses)
            {
                //设置终止当前线程前等待1000 毫秒
                instance.WaitForExit(1000);
                instance.CloseMainWindow();
            }
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            //创建Process 类型的数组,并将它们与系统内所有进程相关联
            Process[] processes;
            processes = Process.GetProcesses();
            foreach (Process p in processes)
            {
                //Idle 指显示CPU 空闲率的进程名称
                //由于访问Idle 的StartTime 会出现异常，所以将其排除在外
                if (p.ProcessName != "Idle")
                {
                    //将每个进程名和进程开始时间加入listBox1 中
                    this.listBox1.Items.Add(
                    string.Format("{0,-30}{1:h:m:s}", p.ProcessName, p.StartTime));
                }
            }
        }
    }
}

