using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMS
{
    public partial class frmForgetPwdByPhone : Form
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
        public frmForgetPwdByPhone()
        {
            InitializeComponent();
        }

        private void quitbtn2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void verifybtn_Click(object sender, EventArgs e)
        {

            // 调用 CheckInput 方法进行输入验证
            if (!CheckInput(out string errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }

            // 使用事务来确保数据的一致性
            using (SqlConnection connection = new SqlConnection(DBconn.connstring))
            {
                try
                {
                    // 打开数据库连接
                    connection.Open();

                    // 开始事务
                    SqlTransaction transaction = connection.BeginTransaction();

                    // 查找用户
                    SqlCommand cmdFindUser = new SqlCommand("SELECT id FROM Login WHERE usertype = '用户' AND phone = @FindId", connection, transaction);
                    cmdFindUser.Parameters.AddWithValue("@FindId", findid.Text.Trim());

                    object userId = cmdFindUser.ExecuteScalar();

                    if (userId == null)
                    {
                        // 用户未注册
                        MessageBox.Show("该用户尚未注册。");
                        return;
                    }

                    // 确保 userId 是字符串类型
                    string loginId = userId.ToString();

                    // 验证用户信息
                    SqlCommand cmdVerifyUser = new SqlCommand("SELECT 1 FROM Users WHERE id = @LoginID AND name = @FindName AND email = @FindEmail AND IDcard = @FindIDCard", connection, transaction);
                    cmdVerifyUser.Parameters.AddWithValue("@LoginID", loginId);
                    cmdVerifyUser.Parameters.AddWithValue("@FindName", findname.Text.Trim());
                    cmdVerifyUser.Parameters.AddWithValue("@FindEmail", findemail.Text.Trim());
                    cmdVerifyUser.Parameters.AddWithValue("@FindIDCard", findIDcard.Text.Trim());

                    int userCount = (int)cmdVerifyUser.ExecuteScalar();

                    if (userCount == 0)
                    {
                        // 用户信息不正确
                        MessageBox.Show("输入信息有误，身份验证未通过！");
                        return;
                    }

                    // 更新密码
                    SqlCommand cmdUpdatePassword = new SqlCommand("UPDATE Login SET pwd = @NewPassword WHERE id = @LoginID", connection, transaction);
                    cmdUpdatePassword.Parameters.AddWithValue("@NewPassword", findnewpwd.Text.Trim());
                    cmdUpdatePassword.Parameters.AddWithValue("@LoginID", loginId);

                    int rowsAffected = cmdUpdatePassword.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // 提交事务
                        transaction.Commit();
                        MessageBox.Show("修改密码成功，请返回重新登录！");
                        this.Close();
                    }
                    else
                    {
                        // 回滚事务
                        transaction.Rollback();
                        MessageBox.Show("密码重置失败，请稍后再试。");
                    }
                }
                catch (Exception ex)
                {
                    // 开始事务
                    SqlTransaction transaction = connection.BeginTransaction();
                    // 回滚事务
                    if (transaction != null)
                    {
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception rollbackEx)
                        {
                            // 记录回滚错误
                            MessageBox.Show("事务回滚失败: " + rollbackEx.Message);
                        }
                    }

                    // 关闭连接
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }

                    // 显示错误信息
                    MessageBox.Show("发生错误: " + ex.Message);
                }
                finally
                {
                    // 确保连接关闭
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }
        private bool CheckInput(out string errorMessage)
        {
            // 获取用户输入
            string findId = findid.Text.Trim(); // 账号或手机号
            string findName = findname.Text.Trim(); // 姓名
            string findEmail = findemail.Text.Trim(); // 邮箱
            string findIDCard = findIDcard.Text.Trim(); // 身份证号码
            string findPassword = findnewpwd.Text.Trim(); // 新密码
            string findPassword2 = findnewpwd2.Text.Trim(); // 确认新密码

            // 检查输入是否为空
            if (string.IsNullOrEmpty(findId))
            {
                errorMessage = "手机号不能为空！";
                return false;
            }
            else if (findId.Length != 11)// 使用正则表达式进行匹配
            {
                MessageBox.Show("请输入合法的手机号手机号！");
            }
            if (string.IsNullOrEmpty(findName))
            {
                errorMessage = "姓名不能为空！";
                return false;
            }
            if (string.IsNullOrEmpty(findEmail))
            {
                errorMessage = "邮箱不能为空！";
                return false;
            }
            if (string.IsNullOrEmpty(findIDCard))
            {
                errorMessage = "身份证信息不能为空！";
                return false;
            }
            else if (findIDCard.Length < 18)
            {
                errorMessage = "请输入合法的身份证信息！";
                return false;
            }
            if (string.IsNullOrEmpty(findPassword))
            {
                errorMessage = "新密码不能为空！";
                return false;
            }
            if (string.IsNullOrEmpty(findPassword2))
            {
                errorMessage = "确认新密码不能为空！";
                return false;
            }
            // 检查两次输入的新密码是否一致
            if (findPassword != findPassword2)
            {
                errorMessage = "两次输入的新密码不一致！";
                return false;
            }

            // 如果所有检查都通过
            errorMessage = null;
            return true;
        }

        private void frmForgetpwd_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 显示一个消息框，询问用户是否要退出程序
            DialogResult result = MessageBox.Show(
                "您确定要退出注册程序吗？",
                "退出确认",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // 根据用户的选择决定是否退出程序
            if (result == DialogResult.Yes)
            {
                this.Close(); // 用户选择“是”，退出程序
            }
            // 如果用户选择“否”，则不执行任何操作，程序继续运行
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 使用 AnimateWindow 函数来最小化窗体
            AnimateWindow(this.Handle, 500, AnimateWindowFlags.AW_HIDE | AnimateWindowFlags.AW_BLEND);

            // 设置窗体状态为最小化
            this.WindowState = FormWindowState.Minimized;
        }

        private void changeway_Click(object sender, EventArgs e)
        {
            this.Hide();
            // 创建并显示 frmForgetpwd 对话框
            using (frmForgetPwdByUsername pwdByUsername = new frmForgetPwdByUsername())
            {
                // 使用 ShowDialog 显示窗体，这样它将以模态对话框的形式出现
                pwdByUsername.ShowDialog(this);
            }
        }
    }
}
