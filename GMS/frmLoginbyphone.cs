using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using GMS.管理员;
using GMS.教练;
using GMS.用户;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;

namespace GMS
{
    public partial class frmLoginbyphone : Form
    {
        public string LoginType = "phone";
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // 用双缓冲绘制窗口的所有子控件
                return cp;
            }
        }
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
        //AutoSizeFormClass autoSize = new AutoSizeFormClass();
        public frmLoginbyphone()
        {
            InitializeComponent();
            // 设置窗体的大小
            //this.Size = new Size(1258, 910);
            //this.WindowState = FormWindowState.Maximized; // 设置窗体为全屏
            // 设置窗体无边框
            //this.FormBorderStyle = FormBorderStyle.None;

            Signin.LinkBehavior = LinkBehavior.NeverUnderline; // 设置注册账号的链接行为
            Admininfo.LinkBehavior = LinkBehavior.NeverUnderline; // 设置忘记密码的链接行为
            Forgetpwd.LinkBehavior = LinkBehavior.NeverUnderline; // 设置管理员联系方式的链接行为
                                                                  //uiPanel2.BackColor = Color.Transparent;
                                                                  // 加载背景图片
                                                                  // 如果尚未订阅 Paint 事件，现在进行订阅
                                                                  //uiPanel2.Paint += new PaintEventHandler(uiPanel2_Paint);

        }
        private bool usercheck()
        {
            bool f = false;
            // 连接数据库对象
            using (SqlConnection conn = new SqlConnection(DBconn.connstring))
            {
                string phone = phoneinput.Text.Trim();
                string password = pwdinput1.Text.Trim();
                string userType = typelist.Text.Trim();

                try
                {
                    conn.Open();

                    // 构建查询语句
                    string sqlstr = "SELECT COUNT(*) FROM Login WHERE phone = @Phone AND pwd = @Password AND usertype = @UserType";

                    // 创建命令对象
                    using (SqlCommand sqlcmd = new SqlCommand(sqlstr, conn))
                    {
                        // 添加参数
                        sqlcmd.Parameters.AddWithValue("@Phone", phone);
                        sqlcmd.Parameters.AddWithValue("@Password", password);
                        sqlcmd.Parameters.AddWithValue("@UserType", userType);

                        // 执行查询
                        int n = (int)sqlcmd.ExecuteScalar();

                        if (n == 0)
                        {
                            MessageBox.Show("手机号或密码错误！");
                        }
                        else
                        {
                            f = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // 处理异常
                    MessageBox.Show("数据库不能正常访问！" + ex.Message);
                }
            }
            return f;
        }

        private bool inputCheck()
        {
            bool b = false;
            if (string.IsNullOrEmpty(this.phoneinput.Text) || string.IsNullOrEmpty(this.pwdinput1.Text) || this.phoneinput.Text == "手机号")
            {
                MessageBox.Show("手机号或密码还未输入！");
            }
            else if (this.phoneinput.Text.Length!=11)// 使用正则表达式进行匹配
            {
                MessageBox.Show("请输入合法的手机号手机号！");
            }
            else if (typelist.Text == "请选择登录用户类型：")
            {
                MessageBox.Show("没有选择用户类型！");
            }
            else b = true;
            return b;
        }


        private void ShowForgetPasswordForm()
        {
            // 隐藏当前的 frmLogin 窗口
            this.Hide();

            // 创建并显示 frmForgetpwd 对话框
            using (frmForgetPwdByUsername forgetpwd = new frmForgetPwdByUsername())
            {
                // 使用 ShowDialog 显示窗体，这样它将以模态对话框的形式出现
                forgetpwd.ShowDialog(this);

                // 当 frmForgetpwd 关闭后，重新显示 frmLogin 窗口
                this.Show();
            }
        }

        private void ShowSignInForm()
        {
            // 隐藏当前的 frmLogin 窗口
            this.Hide();

            // 创建并显示 frmForgetpwd 对话框
            using (frmSignIn signIn = new frmSignIn())
            {
                // 使用 ShowDialog 显示窗体，这样它将以模态对话框的形式出现
                signIn.ShowDialog(this);

                // 当 frmForgetpwd 关闭后，重新显示 frmLogin 窗口
                this.Show();
            }
        }


        private void exitbtn_Click(object sender, EventArgs e)
        {
            // 显示一个消息框，询问用户是否要退出程序
            DialogResult result = MessageBox.Show(
                "您确定要退出健身房管理系统吗？",
                "退出确认",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // 根据用户的选择决定是否退出程序
            if (result == DialogResult.Yes)
            {
                Application.Exit(); // 用户选择“是”，退出程序
            }
            // 如果用户选择“否”，则不执行任何操作，程序继续运行
        }

        private void Signin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //注册部分
            ShowSignInForm();
        }

        private void Forgetpwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //忘记密码部分
            ShowForgetPasswordForm();
        }

        private void Admininfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAdmininfo frmadmininfo = new frmAdmininfo();
            //frmadmininfo.FormClosed += (s, args) => this.Show(); // 当 frmAdmininfo 关闭时，重新显示 frmLogin
            frmadmininfo.Show();
            //this.Close();
        }

        private void uiPanel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void quitbtn_Click_1(object sender, EventArgs e)
        {
            // 显示一个消息框，询问用户是否要退出程序
            DialogResult result = MessageBox.Show(
                "您确定要退出健身房管理系统吗？",
                "退出确认",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // 根据用户的选择决定是否退出程序
            if (result == DialogResult.Yes)
            {
                Application.Exit(); // 用户选择“是”，退出程序
            }
            // 如果用户选择“否”，则不执行任何操作，程序继续运行
        }
        // 添加一个委托用于传递事件数据
        public delegate void LoadingCompletedEventHandler(object sender, EventArgs e);

        // 添加一个事件用于通知主窗口加载已完成
        public event LoadingCompletedEventHandler LoadingCompleted;
        private void Loginbtn_Click(object sender, EventArgs e)
        {
            // 检查输入
            if (this.inputCheck())
            {
                // 检查账号密码
                if (this.usercheck())
                {
                    string phone = phoneinput.Text.Trim();
                    Timer timer = new Timer();
                    timer.Interval = 800; // 200毫秒
                    Loginbtn.Loading = true;
                    timer.Tick += async (s, ev) =>
                    {
                        timer.Stop(); // 停止 Timer
                                      // 停止加载动画
                        Loginbtn.Loading = false;
                        //条件判断用户类型来打开不同的界面
                        if (typelist.Text == "管理员")
                        {
                            MessageBox.Show("登录成功！欢迎进入管理员界面！");
                            AntdUIProgress.Visible = true;
                            // 异步运行 Loading() 方法
                            await Loading();
                            // 创建并显示 frmAdmin 窗体
                            frmAdmin frmadmin = new frmAdmin(phone,LoginType);
                            // 关闭当前的 frmLogin 窗口
                            this.Hide();
                            frmadmin.Show();

                        }
                        else if (typelist.Text == "用户")
                        {
                            MessageBox.Show("登录成功！欢迎进入用户界面！");
                            AntdUIProgress.Visible = true;
                            // 异步运行 Loading() 方法
                            await Loading();
                            // 创建并显示 frmAdmin 窗体
                            frmUser user = new frmUser(phone, LoginType);
                            // 关闭当前的 frmLogin 窗口
                            this.Hide();
                            // 创建并显示 frmAdmin 窗体
                            user.ShowDialog();


                        }
                        else if (typelist.Text == "教练")
                        {
                            MessageBox.Show("登录成功！欢迎进入教练界面！");
                            AntdUIProgress.Visible = true;
                            // 异步运行 Loading() 方法
                            await Loading();
                            frmCoach coach = new frmCoach(phone, LoginType);
                            // 关闭当前的 frmLogin 窗口
                            this.Hide();
                            coach.ShowDialog();

                        }

                    };
                    timer.Start(); // 启动计时器
                }
                else
                {
                    MessageBox.Show("账号或密码错误，请重试。");
                }
            }
            else
            {
                MessageBox.Show("输入信息有误，请检查后重试。");
            }
        }
        // 将 async 关键字移至外部方法
        private DateTime startTime;

        private async Task Loading()
        {
            Timer timer1 = new Timer();
            // 设置计时器间隔为 100 毫秒
            timer1.Interval = 20; // 100毫秒

            // 使用 lambda 表达式订阅 Tick 事件
            timer1.Tick += (s, ev) =>
            {
                // 计算当前时间经过了多少个 100 毫秒
                int elapsedMilliseconds = (int)(DateTime.Now - startTime).TotalMilliseconds;

                // 如果已经过了 5000 毫秒（即 5 秒），则停止计时器
                if (elapsedMilliseconds >= 1000)
                {
                    timer1.Stop();

                    // 根据需要添加后续逻辑
                    // 例如，可以在这里调用另一个异步方法或更新UI
                }
                else
                {
                    // 计算当前进度
                    float currentProgress = elapsedMilliseconds / 1000f;

                    // 更新进度条的值
                    AntdUIProgress.Value += currentProgress;
                }
            };

            // 记录开始时间
            startTime = DateTime.Now;
            timer1.Start(); // 启动计时器

            // 等待计时器结束
            while (timer1.Enabled)
            {
                await Task.Delay(1); // 休眠一段时间以避免忙等待
            }
        }
        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }



        /// <summary>
        /// 最小化窗体按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiHeaderButton1_Click(object sender, EventArgs e)
        {
            // 使用 AnimateWindow 函数来最小化窗体
            AnimateWindow(this.Handle, 500, AnimateWindowFlags.AW_HIDE | AnimateWindowFlags.AW_BLEND);

            // 设置窗体状态为最小化
            this.WindowState = FormWindowState.Minimized;
        }

        private void phoneSign_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            // 创建并显示 frmForgetpwd 对话框
            using (frmLoginbyid loginbyid = new frmLoginbyid())
            {
                // 使用 ShowDialog 显示窗体，这样它将以模态对话框的形式出现
                loginbyid.ShowDialog(this);
            }
        }
    }
}
