using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMS
{
    public partial class frmAdmininfo : Form
    {
        //无窗体拖拽
        [DllImport("user32.dll")]//拖动无窗体的控件
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;


        // 导入 user32.dll 库中的 AnimateWindow 函数
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool AnimateWindow(IntPtr hWnd, int dwTime, AnimateWindowFlags dwFlags);

        // 定义 AnimateWindowFlags 枚举
        [Flags]
        public enum AnimateWindowFlags
        {
            AW_HOR_POSITIVE = 0x00000001,
            AW_HOR_NEGATIVE = 0x00000002,
            AW_VER_POSITIVE = 0x00000004,
            AW_VER_NEGATIVE = 0x00000008,
            AW_CENTER = 0x00000010,
            AW_HIDE = 0x00010000,
            AW_ACTIVATE = 0x00020000,
            AW_SLIDE = 0x00040000,
            AW_BLEND = 0x00080000
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // 用双缓冲绘制窗口的所有子控件
                return cp;
            }
        }
        public frmAdmininfo()
        {
            InitializeComponent();
            // 设置窗体无边框
            //this.FormBorderStyle = FormBorderStyle.None;
            // 设置透明键和背景色
            this.TransparencyKey = Color.Fuchsia;
            this.BackColor = Color.Fuchsia;
            label1.BackColor=Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
        }

        private void frmAdmininfo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void quitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // 用户选择“是”，退出程序
            // 如果用户选择“否”，则不执行任何操作，程序继续运行
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 使用 AnimateWindow 函数来最小化窗体
            AnimateWindow(this.Handle, 500, AnimateWindowFlags.AW_HIDE | AnimateWindowFlags.AW_BLEND);

            // 设置窗体状态为最小化
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
