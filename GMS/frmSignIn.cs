using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMS
{
    
    public partial class frmSignIn : Form
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

        //AutoSizeFormClass autoSize = new AutoSizeFormClass();
        public frmSignIn()
        {

        InitializeComponent();
        }
       
        private void quitSign_Click(object sender, EventArgs e)
        {
            // 显示一个消息框，询问用户是否要退出程序
            DialogResult result = MessageBox.Show(
                "您确定要取消注册吗？",
                "取消确认",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // 根据用户的选择决定是否退出程序
            if (result == DialogResult.Yes)
            {
                this.Close(); // 用户选择“是”，退出注册窗体
            }
            // 如果用户选择“否”，则不执行任何操作，继续注册
        }
        private bool CheckInput(out string errorMessage)
        {
            
            // 获取用户输入
            string ID = idin.Text.Trim(); // 账号
            string phone = phonein.Text.Trim(); // 手机号
            string pwd = pwdin.Text.Trim(); // 密码
            string pwd2 = verpwdin.Text.Trim(); // 确认密码
            string name = namein.Text.Trim(); // 姓名
            string ageStr = agein.Text.Trim(); // 年龄
            int age; // 需要转换为整数
            string birthday = birthdayin.Text; // 出生日期
            string IDcard = IDcardin.Text.Trim(); // 身份证号码
            string email = emailin.Text.Trim(); // 邮箱
            string YanZhenmain = YanZhenMain.Text.Trim();//验证码
            // 检查输入是否为空，并显示具体的错误信息
            if (string.IsNullOrEmpty(ID))
            {
                errorMessage = "用户名不能为空！";
                return false;
            }
            else if (ID.Length >20)
            {
                errorMessage = "用户名不能超过20个字符！";
                return false;
            }
            string pattern = @"^[a-zA-Z0-9_]+$";

            // 使用正则表达式进行匹配
            if (!Regex.IsMatch(ID, pattern))
            {
                errorMessage = "账号只能包含字母、数字和下划线！";
                return false;
            }
            if (string.IsNullOrEmpty(phone))
            {
                errorMessage = "手机号不能为空！";
                return false;
            }
            else if (phone.Length != 11)
            {
                errorMessage = "请输入合法的手机号！";
                return false;
            }

            if (string.IsNullOrEmpty(name))
            {
                errorMessage = "姓名不能为空！";
                return false;
            }

            if (string.IsNullOrEmpty(ageStr) || !int.TryParse(ageStr, out age))
            {
                errorMessage = "请输入有效的年龄！";
                return false;
            }
            else if (age <= 0 || age > 120)
            {
                errorMessage = "年龄输入不切实际！";
                return false;
            }

            if (string.IsNullOrEmpty(email))
            {
                errorMessage = "邮箱不能为空！";
                return false;
            }

            if (string.IsNullOrEmpty(IDcard))
            {
                errorMessage = "身份证信息不能为空！";
                return false;
            }
            else if (IDcard.Length != 18)
            {
                errorMessage = "请输入合法的身份证信息！";
                return false;
            }

            if (string.IsNullOrEmpty(pwd))
            {
                errorMessage = "密码不能为空！";
                return false;
            }
            else if (pwd.Length != 6)
            {
                errorMessage = "请输入六位密码！";
                return false;
            }

            if (string.IsNullOrEmpty(pwd2))
            {
                errorMessage = "确认密码不能为空！";
                return false;
            }
            if (string.IsNullOrEmpty(YanZhenmain))
            {
                errorMessage = "请输入验证码！";
                return false;
            }
            // 检查两次输入的新密码是否一致
            if (pwd != pwd2)
            {
                errorMessage = "两次输入的密码不一致！";
                return false;
            }
            // 检查年龄与出生日期的一致性
            try
            {
                DateTime birthDate;
                if (!DateTime.TryParse(birthday, out birthDate))
                {
                    errorMessage = "请输入合法的出生日期！";
                    return false;
                }

                int currentYear = DateTime.Now.Year;
                int calculatedAge = currentYear - birthDate.Year;

                // 如果生日还没到，年龄需要减一
                if (birthDate > DateTime.Now.AddYears(-calculatedAge))
                {
                    calculatedAge--;
                }

                if (calculatedAge != age)
                {
                    errorMessage = "出生日期与年龄不符合！";
                    return false;
                }
            }
            catch (Exception ex)
            {
                errorMessage = "出生日期解析错误: " + ex.Message;
                return false;
            }
            if (YanZhenmain != uiVerificationCode1.Code)
            {
                errorMessage = "验证码错误，请点击重试！";
                return false;
            }
            // 如果所有检查都通过
            errorMessage = null;
            return true;
        }
        private void veritySign_Click(object sender, EventArgs e)
        {
            // 调用 CheckInput 方法进行输入验证
            if (!CheckInput(out string errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }
            // 获取用户输入
            string ID = idin.Text.Trim(); // 账号
            string phone = phonein.Text.Trim(); // 手机号
            string pwd = pwdin.Text.Trim(); // 密码
            string pwd2 = verpwdin.Text.Trim(); // 确认密码
            string name = namein.Text.Trim(); // 姓名
            string age = agein.Text.Trim(); // 年龄
            string sex; // 性别
            if (male.Checked)
            {
                sex = "男";
            }
            else
            {
                sex = "女";
            }
            string birthday = birthdayin.Text; // 出生日期
            string IDcard = IDcardin.Text.Trim(); // 身份证号码
            string email = emailin.Text.Trim(); // 邮箱

            // 使用事务来确保数据的一致性
            using (SqlConnection connection = new SqlConnection(DBconn.connstring))
            {
                SqlTransaction transaction = null; // 初始化 transaction 变量
                try
                {
                    connection.Open();

                    // 开始事务
                    transaction = connection.BeginTransaction();

                    // 检查账号是否已存在
                    SqlCommand cmdCheckID = new SqlCommand("SELECT COUNT(*) FROM Login WHERE id = @id", connection, transaction);
                    cmdCheckID.Parameters.AddWithValue("@id", ID);

                    int accountCount = (int)cmdCheckID.ExecuteScalar();
                    if (accountCount > 0)
                    {
                        MessageBox.Show("注册失败，该账号已被注册！");
                        transaction.Rollback();
                        return;
                    }

                    // 检查手机号是否已存在
                    SqlCommand cmdCheckPhone = new SqlCommand("SELECT COUNT(*) FROM Login WHERE phone = @Phone", connection, transaction);
                    cmdCheckPhone.Parameters.AddWithValue("@Phone", phone);

                    int phoneCount = (int)cmdCheckPhone.ExecuteScalar();
                    if (phoneCount > 0)
                    {
                        MessageBox.Show("注册失败，该手机号已被注册！");
                        transaction.Rollback();
                        return;
                    }

                    // 插入新的登录记录
                    SqlCommand cmdInsertLogin = new SqlCommand(
                        "INSERT INTO Login(id, pwd, phone, usertype) VALUES(@id, @pwd, @phone, @usertype)",
                        connection, transaction);
                    cmdInsertLogin.Parameters.AddWithValue("@id", ID);
                    cmdInsertLogin.Parameters.AddWithValue("@pwd", pwd);
                    cmdInsertLogin.Parameters.AddWithValue("@phone", phone);
                    cmdInsertLogin.Parameters.AddWithValue("@usertype", "用户");

                    cmdInsertLogin.ExecuteNonQuery();

                    // 获取 Users 表中 UserId 的最大值
                    SqlCommand cmdGetMaxUserId = new SqlCommand("SELECT ISNULL(MAX(UserId), 0) FROM Users", connection, transaction);
                    int maxUserId = (int)cmdGetMaxUserId.ExecuteScalar() + 1;

                    // 插入新的用户记录
                    SqlCommand cmdInsertUser = new SqlCommand(
                        "INSERT INTO Users(userId, name, age, sex, birthday, phone, IDcard, email, id) VALUES(@userId, @name, @age, @sex, @birthday, @phone, @IDcard, @email, @id)",
                        connection, transaction);
                    cmdInsertUser.Parameters.AddWithValue("@userid", maxUserId);
                    cmdInsertUser.Parameters.AddWithValue("@name", name);
                    cmdInsertUser.Parameters.AddWithValue("@age", age);
                    cmdInsertUser.Parameters.AddWithValue("@sex", sex);
                    cmdInsertUser.Parameters.AddWithValue("@birthday", DateTime.Parse(birthday));
                    cmdInsertUser.Parameters.AddWithValue("@IDcard", IDcard);
                    cmdInsertUser.Parameters.AddWithValue("@phone", phone);
                    cmdInsertUser.Parameters.AddWithValue("@email", email);
                    cmdInsertUser.Parameters.AddWithValue("@id", ID);

                    cmdInsertUser.ExecuteNonQuery();

                    // 提交事务
                    transaction.Commit();
                    MessageBox.Show("注册成功，请返回进行登陆！");
                    this.Close();
                }
                catch (Exception ex)
                {
                    // 回滚事务
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }

                    // 确保连接关闭
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }

                    MessageBox.Show("发生错误: " + ex.Message);
                }
            }

        }

        private void input1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Panel2MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            // 使用 AnimateWindow 函数来最小化窗体
            AnimateWindow(this.Handle, 500, AnimateWindowFlags.AW_HIDE | AnimateWindowFlags.AW_BLEND);

            // 设置窗体状态为最小化
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click_1(object sender, EventArgs e)
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
    }
}
