using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using GMS.GMSdatasetTableAdapters;
using GMS.管理员;
using Sunny.UI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using GMS.Properties;
using Sunny.UI.Win32;
using System.Globalization;
using System.Text.RegularExpressions;
using AntdUI;
using System.Web.UI.Design.WebControls;
using System.Drawing.Text;
using GMS;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Windows.Forms.DataVisualization.Charting;
using static Sunny.UI.SnowFlakeId;
namespace GMS.管理员
{
    public partial class frmAdmin : Form
    {
        public string thisid = "0000067035411";
        //数据库连接字符串
        string con = DBconn.connstring;
        BindingSource bindingSourceAdmin = new BindingSource();
        BindingSource bindingSourceUser = new BindingSource();
        BindingSource bindingSourceCoach = new BindingSource();
        BindingSource bindingSourceCourse = new BindingSource();
        BindingSource bindingSourceReserve = new BindingSource();
        DataSet gmsDataSet = new DataSet();
        SqlCommand sqlCommand;
        SqlDataAdapter sqlData;
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
        public string LoginUserId { get; set; }
        public string LoginUserPhone { get; set; }
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
        public frmAdmin()
        {
            InitializeComponent();
            calendar1.Value = DateTime.Now;
            // 初始化分页控件
            // adminBindingSource.Filter = "SELECT TOP 1 * FROM Admin";
        }
        public frmAdmin(string value, string logintype)
        {
            InitializeComponent();
            calendar1.Value = DateTime.Now;
            if (logintype == "Id")
            {
                thisid = value;
            }
            else if (logintype == "phone")
            {
                using (SqlConnection connection = new SqlConnection(con))
                {
                    connection.Open();

                    // 使用参数化查询来防止SQL注入
                    string query = "SELECT id FROM Login WHERE phone = @phone";
                    SqlCommand sqlCommand = new SqlCommand(query, connection);

                    // 添加参数
                    sqlCommand.Parameters.AddWithValue("@phone", value);

                    // 执行查询并读取结果
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())  // 检查是否有数据
                        {
                            string id1 = Convert.ToString(reader["id"]);
                            thisid = id1;
                        }
                        else
                        {
                            // 如果没有找到匹配的记录，可以在这里处理
                            MessageBox.Show("未找到与该手机号关联的用户ID。");
                        }
                    }
                }
            }

        }
        public void showAdminInfo()
        {
            // 创建 SqlConnection 对象并打开连接
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                string query = "SELECT Login.id AS [用户名], Users.name AS [姓名], Users.age AS [年龄], Users.sex AS [性别], " +
                               "Users.phone AS [手机号码], Users.IDcard AS [身份证], Users.email AS [邮箱], " +
                               "CONVERT(varchar, Users.birthday, 111) AS [出生日期] " +
                               "FROM Login INNER JOIN Users ON Login.id = Users.id " +
                               "WHERE (Login.usertype='管理员') " +
                               "ORDER BY Login.id ASC";
                sqlCommand = new SqlCommand(query, connection);
                sqlData = new SqlDataAdapter(sqlCommand);
                // 确保数据集中有一个名为 Admin 的 DataTable
                if (gmsDataSet.Tables["Admin"] == null)
                {
                    // 如果不存在，则创建一个新的 DataTable
                    DataTable adminTable = new DataTable("Admin");
                    gmsDataSet.Tables.Add(adminTable);

                }
                gmsDataSet.Tables["Admin"].Rows.Clear();
                // 使用 TableAdapter 填充数据集
                sqlData.Fill(gmsDataSet.Tables["Admin"]);

                // 设置 BindingSource 的 DataSource
                bindingSourceAdmin.DataSource = gmsDataSet.Tables["Admin"];

                // 计算总页数
                int totalRows = gmsDataSet.Tables["Admin"].Rows.Count;
                int pageCount = (int)Math.Ceiling((double)totalRows / uiPagination1.PageSize);

                // 设置总条目数
                uiPagination1.TotalCount = totalRows;

                // 设置数据源
                uiPagination1.DataSource = bindingSourceAdmin;

                // 设置初始页码
                uiPagination1.ActivePage = 1;

                // 如果分页控件有 PageDataSource，则设置 AdminTable 和 AdminData 的 DataSource
                if (uiPagination1.PageDataSource != null)
                {
                    AdminTable.DataSource = uiPagination1.PageDataSource;
                    // 添加 Binding 到 pagination1 控件

                    //AdminData.DataSource = uiPagination1.PageDataSource;
                }
                connection.Close();
            }
        }
        public void showUserInfo()
        {
            // 创建 SqlConnection 对象并打开连接
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                string query = "SELECT Login.id AS [用户名], Users.name AS [姓名], Users.age AS [年龄], Users.sex AS [性别], " +
                               "Users.phone AS [手机号码], Users.IDcard AS [身份证], Users.email AS [邮箱], " +
                               "CONVERT(varchar, Users.birthday, 111) AS [出生日期] " +
                               "FROM Login INNER JOIN Users ON Login.id = Users.id " +
                               "WHERE (Login.usertype='用户') " +
                               "ORDER BY Login.id ASC";
                sqlCommand = new SqlCommand(query, connection);
                sqlData = new SqlDataAdapter(sqlCommand);
                // 确保数据集中有一个名为 User 的 DataTable
                if (gmsDataSet.Tables["User"] == null)
                {
                    // 如果不存在，则创建一个新的 DataTable
                    DataTable UserTable = new DataTable("User");
                    gmsDataSet.Tables.Add(UserTable);

                }
                gmsDataSet.Tables["User"].Rows.Clear();
                // 使用 TableAdapter 填充数据集
                sqlData.Fill(gmsDataSet.Tables["User"]);

                // 设置 BindingSource 的 DataSource
                bindingSourceUser.DataSource = gmsDataSet.Tables["User"];

                // 计算总页数
                int totalRows = gmsDataSet.Tables["User"].Rows.Count;
                int pageCount = (int)Math.Ceiling((double)totalRows / UserPagination.PageSize);

                // 设置总条目数
                UserPagination.TotalCount = totalRows;

                // 设置数据源
                UserPagination.DataSource = bindingSourceUser;

                // 设置初始页码
                UserPagination.ActivePage = 1;

                // 如果分页控件有 PageDataSource，则设置 AdminTable 和 AdminData 的 DataSource
                if (UserPagination.PageDataSource != null)
                {
                    UserTable.DataSource = UserPagination.PageDataSource;
                    // 添加 Binding 到 pagination1 控件

                    //AdminData.DataSource = uiPagination1.PageDataSource;
                }
                connection.Close();
            }
        }
        public void showCoachInfo()
        {
            // 创建 SqlConnection 对象并打开连接
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                string query = "SELECT Login.id AS [用户名], Users.name AS [姓名], Users.age AS [年龄], Users.sex AS [性别], " +
                               "Users.phone AS [手机号码], Users.IDcard AS [身份证], Users.email AS [邮箱], " +
                               "CONVERT(varchar, Users.birthday, 111) AS [出生日期] " +
                               "FROM Login INNER JOIN Users ON Login.id = Users.id " +
                               "WHERE (Login.usertype='教练') " +
                               "ORDER BY Login.id ASC";
                sqlCommand = new SqlCommand(query, connection);
                sqlData = new SqlDataAdapter(sqlCommand);
                // 确保数据集中有一个名为 Admin 的 DataTable
                if (gmsDataSet.Tables["Coach"] == null)
                {
                    // 如果不存在，则创建一个新的 DataTable
                    DataTable CoachTable = new DataTable("Coach");
                    gmsDataSet.Tables.Add(CoachTable);

                }
                gmsDataSet.Tables["Coach"].Rows.Clear();
                // 使用 TableAdapter 填充数据集
                sqlData.Fill(gmsDataSet.Tables["Coach"]);

                // 设置 BindingSource 的 DataSource
                bindingSourceCoach.DataSource = gmsDataSet.Tables["Coach"];

                // 计算总页数
                int totalRows = gmsDataSet.Tables["Coach"].Rows.Count;
                int pageCount = (int)Math.Ceiling((double)totalRows / CoachPagination.PageSize);

                // 设置总条目数
                CoachPagination.TotalCount = totalRows;

                // 设置数据源
                CoachPagination.DataSource = bindingSourceCoach;

                // 设置初始页码
                CoachPagination.ActivePage = 1;

                // 如果分页控件有 PageDataSource，则设置 AdminTable 和 AdminData 的 DataSource
                if (CoachPagination.PageDataSource != null)
                {
                    CoachTable.DataSource = CoachPagination.PageDataSource;
                    // 添加 Binding 到 pagination1 控件

                    //AdminData.DataSource = uiPagination1.PageDataSource;
                }
                connection.Close();
            }
        }
        public void showCourseInfo()
        {
            // 创建 SqlConnection 对象并打开连接
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                string query = "SELECT  courseid AS [课程号], coursename AS [课程名称], coachid AS [教练], " +
                    "weekday AS [星期], start_time AS [上课时间], duration_hours AS [课程时长], maxstudent AS [最大学生数量]from Courses";
                sqlCommand = new SqlCommand(query, connection);
                sqlData = new SqlDataAdapter(sqlCommand);
                // 确保数据集中有一个名为 Admin 的 DataTable
                if (gmsDataSet.Tables["Course"] == null)
                {
                    // 如果不存在，则创建一个新的 DataTable
                    DataTable CourseTable = new DataTable("Course");
                    gmsDataSet.Tables.Add(CourseTable);

                }
                gmsDataSet.Tables["Course"].Rows.Clear();
                // 使用 TableAdapter 填充数据集
                sqlData.Fill(gmsDataSet.Tables["Course"]);

                // 设置 BindingSource 的 DataSource
                bindingSourceCourse.DataSource = gmsDataSet.Tables["Course"];

                // 计算总页数
                int totalRows = gmsDataSet.Tables["Course"].Rows.Count;
                int pageCount = (int)Math.Ceiling((double)totalRows / CoursePagination.PageSize);

                // 设置总条目数
                CoursePagination.TotalCount = totalRows;

                // 设置数据源
                CoursePagination.DataSource = bindingSourceCourse;

                // 设置初始页码
                CoursePagination.ActivePage = 1;

                // 如果分页控件有 PageDataSource，则设置 AdminTable 和 AdminData 的 DataSource
                if (CoursePagination.PageDataSource != null)
                {
                    CourseTable.DataSource = CoursePagination.PageDataSource;
                    // 添加 Binding 到 pagination1 控件

                    //AdminData.DataSource = uiPagination1.PageDataSource;
                }
                connection.Close();
            }
            // 获取所有不同的 coursename 并添加到 CourseName 下拉列表
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                // 查询 Courses 表中所有不同的 coursename，并按字典序排序
                string distinctQuery = "SELECT DISTINCT coursename FROM Courses ORDER BY coursename";
                SqlCommand distinctCommand = new SqlCommand(distinctQuery, connection);

                using (SqlDataReader reader = distinctCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string coursename = reader.GetString(0);
                        CourseName.Items.Add(coursename);
                    }
                }
            }
        }
        public void showReserveInfo()
        {
            // 创建 SqlConnection 对象并打开连接
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                // 基础查询
                string query = @"
                SELECT 
                    r.courseid AS [课程号],
                    c.coursename AS [课程名称],
                    r.stuid AS [学生ID],
                    u.name AS [学生姓名],
                    c.maxstudent AS [最大学生数量],
                    (c.maxstudent - ISNULL((SELECT COUNT(*) FROM CourseInfo ri WHERE ri.courseid = r.courseid), 0)) AS [剩余可选人数]
                FROM 
                    ReservationInfo r
                INNER JOIN 
                    Courses c ON r.courseid = c.courseid
                INNER JOIN 
                    Users u ON r.stuid = u.id
                ORDER BY 
                    r.courseid;";

                sqlCommand = new SqlCommand(query, connection);
                sqlData = new SqlDataAdapter(sqlCommand);

                // 确保数据集中有一个名为 Reserve 的 DataTable
                if (gmsDataSet.Tables["Reserve"] == null)
                {
                    // 如果不存在，则创建一个新的 DataTable
                    DataTable ReserveTable = new DataTable("Reserve");
                    gmsDataSet.Tables.Add(ReserveTable);
                }

                // 清除现有的行
                gmsDataSet.Tables["Reserve"].Rows.Clear();

                // 使用 TableAdapter 填充数据集
                sqlData.Fill(gmsDataSet.Tables["Reserve"]);

                // 设置 BindingSource 的 DataSource
                bindingSourceReserve.DataSource = gmsDataSet.Tables["Reserve"];

                // 计算总页数
                int totalRows = gmsDataSet.Tables["Reserve"].Rows.Count;
                int pageCount = (int)Math.Ceiling((double)totalRows / ReservePagination.PageSize);

                // 设置总条目数
                ReservePagination.TotalCount = totalRows;

                // 设置数据源
                ReservePagination.DataSource = bindingSourceReserve;

                // 设置初始页码
                ReservePagination.ActivePage = 1;

                // 如果分页控件有 PageDataSource，则设置 AdminTable 和 AdminData 的 DataSource
                if (ReservePagination.PageDataSource != null)
                {
                    ReserveTable.DataSource = ReservePagination.PageDataSource;
                    // 添加 Binding 到 pagination1 控件
                    //AdminData.DataSource = uiPagination1.PageDataSource;
                }
            }

            // 获取所有不同的 coursename 并添加到 ReserveName 下拉列表
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                // 查询 Courses 表中所有不同的 coursename，并按字典序排序
                string distinctQuery = "SELECT DISTINCT coursename FROM Courses ORDER BY coursename";
                SqlCommand distinctCommand = new SqlCommand(distinctQuery, connection);

                using (SqlDataReader reader = distinctCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string coursename = reader.GetString(0);
                        ReserveName.Items.Add(coursename);
                    }
                }
            }
        }
        public void showselfinfo()
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                // 使用参数化查询来防止SQL注入
                string query = "SELECT * FROM Users WHERE id = @thisid";
                SqlCommand sqlCommand = new SqlCommand(query, connection);

                // 添加参数
                sqlCommand.Parameters.AddWithValue("@thisid", this.thisid);

                // 执行查询并读取结果
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())  // 检查是否有数据
                    {
                        selfid.Text = Convert.ToString(reader["id"]);
                        selfname.Text = Convert.ToString(reader["name"]);
                        selfage.Value = Convert.ToInt32(reader["age"]);
                        selfphone.Text = Convert.ToString(reader["phone"]);
                        selfemail.Text = Convert.ToString(reader["email"]);
                        selfIDcard.Text = Convert.ToString(reader["IDcard"]);

                        // 正确处理 sex 字段
                        string sex = Convert.ToString(reader["sex"]);
                        if (sex == "男")
                        {
                            male.Checked = true;
                            female.Checked = false;
                        }
                        else if (sex == "女")
                        {
                            male.Checked = false;
                            female.Checked = true;
                        }

                        // 正确处理生日字段
                        if (reader["birthday"] != DBNull.Value)
                        {
                            selfbirthday.Value = Convert.ToDateTime(reader["birthday"]);
                        }
                        else
                        {
                            selfbirthday.Value = DateTime.Now; // 或者设置为默认值
                        }
                    }
                    else
                    {
                        // 如果没有找到匹配的记录，可以在这里处理
                        MessageBox.Show("未找到对应的用户名。");
                    }
                }
            }
        }
        public void viewUserDoughnutChart()
        {
            int count15_20 = 0;
            int count20_25 = 0;
            int count25_30 = 0;
            int count35_40 = 0;
            int countOver40 = 0;
            // 创建 SqlConnection 对象并打开连接
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                // 查询语句：只选择年龄字段
                string query = "SELECT Users.age FROM Login INNER JOIN Users ON Login.id = Users.id WHERE (Login.usertype='用户')";
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                // 遍历查询结果并统计每个年龄段的用户数
                while (reader.Read())
                {
                    int age = Convert.ToInt32(reader["age"]);

                    if (age >= 15 && age < 20) count15_20++;
                    else if (age >= 20 && age < 25) count20_25++;
                    else if (age >= 25 && age < 30) count25_30++;
                    else if (age >= 35 && age < 40) count35_40++;
                    else if (age >= 40) countOver40++;
                }

                // 关闭读取器
                reader.Close();
                connection.Close();
            }

            // 设置饼状图选项
            UIDoughnutOption userDoughnutOption = new UIDoughnutOption();
            userDoughnutOption.ToolTip.Visible = true;
            userDoughnutOption.Title = new UITitle { Text = "用户年龄情况" };

            // 创建饼状图系列
            UIDoughnutSeries userDoughnutSeries = new UIDoughnutSeries
            {
                Name = "年龄"
            };

            // 添加数据到系列
            userDoughnutSeries.AddData("15-20岁", count15_20);
            userDoughnutSeries.AddData("20-25岁", count20_25);
            userDoughnutSeries.AddData("25-30岁", count25_30);
            userDoughnutSeries.AddData("35-40岁", count35_40);
            userDoughnutSeries.AddData("40岁以上", countOver40);

            // 设置系列
            userDoughnutOption.AddSeries(userDoughnutSeries);

            // 更新配置
            UserDoughnutChart.SetOption(userDoughnutOption);
            // 更新显示信息
            UserDoughnutMarkLabel.Text = string.Format(
                "用户年龄分布如下:\n" +
                "15-20岁的用户数量: {0}人\n" +
                "20-25岁的用户数量: {1}人\n" +
                "25-30岁的用户数量: {2}人\n" +
                "35-40岁的用户数量: {3}人\n" +
                "40岁以上的用户数量: {4}人",
                count15_20, count20_25, count25_30, count35_40, countOver40);
        }
        public void viewUserBarChart()
        {
            int male = 0;
            int female = 0;

            // 创建 SqlConnection 对象并打开连接
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                // 查询语句：只选择性别字段
                string query = "SELECT Users.sex FROM Login INNER JOIN Users ON Login.id = Users.id WHERE (Login.usertype='用户')";
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                // 遍历查询结果并统计每个性别的用户数
                while (reader.Read())
                {
                    string sex = Convert.ToString(reader["sex"]);

                    if (sex == "男")
                    {
                        male++;
                    }
                    else if (sex == "女")
                    {
                        female++;
                    }
                }

                // 关闭读取器
                reader.Close();
                connection.Close();
            }

            try
            {
                // 配置参数
                UIBarOption option = new UIBarOption();

                // 配置标题
                option.Title = new UITitle
                {
                    Text = "用户性别情况", // 主标题
                };

                // 设置图例
                option.Legend = new UILegend
                {
                    Orient = UIOrient.Horizontal, // 图例水平布局
                    Top = UITopAlignment.Top, // 图例放置在左上角
                    Left = UILeftAlignment.Left
                };
                option.Legend.AddData("男性");
                option.Legend.AddData("女性");

                // 设置系列
                UIBarSeries series = new UIBarSeries
                {
                    Name = "人数"
                };

                // 添加数据到系列
                series.AddData("男性", male);
                series.AddData("女性", female);

                // 将系列添加到选项中
                option.Series.Add(series);

                // 设置横坐标内容
                option.XAxis.Data.Add("男性");
                option.XAxis.Data.Add("女性");

                // 辅助ToolTip是否可见
                option.ToolTip.Visible = true;

                // Y轴的刻度
                option.YAxis.Scale = true;

                // XY轴的单位
                option.XAxis.Name = "性别";
                option.YAxis.Name = "人数";

                // 更新配置
                UserBarChart.SetOption(option);
                UserBarMarkLabel.Text = string.Format($"本俱乐部目前拥有用户总数:{female + male}人\n男性用户数量：{male}人\n女性用户数量：{female}人");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发生错误: {ex.Message}");
            }
        }
        public void viewCoachBarChart()
        {
            int male = 0;
            int female = 0;

            // 创建 SqlConnection 对象并打开连接
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                // 查询语句：只选择性别字段
                string query = "SELECT Users.sex FROM Login INNER JOIN Users ON Login.id = Users.id WHERE (Login.usertype='教练')";
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                // 遍历查询结果并统计每个性别的用户数
                while (reader.Read())
                {
                    string sex = Convert.ToString(reader["sex"]);

                    if (sex == "男")
                    {
                        male++;
                    }
                    else if (sex == "女")
                    {
                        female++;
                    }
                }

                // 关闭读取器
                reader.Close();
                connection.Close();
            }

            try
            {
                // 配置参数
                UIBarOption option = new UIBarOption();

                // 配置标题
                option.Title = new UITitle
                {
                    Text = "教练性别情况", // 主标题
                };

                // 设置图例
                option.Legend = new UILegend
                {
                    Orient = UIOrient.Horizontal, // 图例水平布局
                    Top = UITopAlignment.Top, // 图例放置在左上角
                    Left = UILeftAlignment.Left
                };
                option.Legend.AddData("男性");
                option.Legend.AddData("女性");

                // 设置系列
                UIBarSeries series = new UIBarSeries
                {
                    Name = "人数"
                };

                // 添加数据到系列
                series.AddData("男性", male);
                series.AddData("女性", female);

                // 将系列添加到选项中
                option.Series.Add(series);

                // 设置横坐标内容
                option.XAxis.Data.Add("男性");
                option.XAxis.Data.Add("女性");

                // 辅助ToolTip是否可见
                option.ToolTip.Visible = true;

                // Y轴的刻度
                option.YAxis.Scale = true;

                // XY轴的单位
                option.XAxis.Name = "性别";
                option.YAxis.Name = "人数";

                // 更新配置
                CoachBarChart.SetOption(option);
                CoachBarMarkLabel.Text = string.Format($"本俱乐部目前拥有用户总数:{female + male}人\n男性用户数量：{male}人\n女性用户数量：{female}人");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发生错误: {ex.Message}");
            }
        }
        public void viewCoachDoughnutChart()
        {
            int count25_30 = 0;
            int count30_35 = 0;
            int count35_40 = 0;
            int count40_45 = 0;
            int countOver45 = 0;
            // 创建 SqlConnection 对象并打开连接
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                // 查询语句：只选择年龄字段
                string query = "SELECT Users.age FROM Login INNER JOIN Users ON Login.id = Users.id WHERE (Login.usertype='教练')";
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                // 遍历查询结果并统计每个年龄段的用户数
                while (reader.Read())
                {
                    int age = Convert.ToInt32(reader["age"]);

                    if (age >= 25 && age < 30) count25_30++;
                    else if (age >= 30 && age < 35) count30_35++;
                    else if (age >= 35 && age < 40) count35_40++;
                    else if (age >= 40 && age < 45) count40_45++;
                    else if (age >= 45) countOver45++;
                }

                // 关闭读取器
                reader.Close();
                connection.Close();
            }

            // 设置饼状图选项
            UIDoughnutOption CoachDoughnutOption = new UIDoughnutOption();
            CoachDoughnutOption.ToolTip.Visible = true;
            CoachDoughnutOption.Title = new UITitle { Text = "教练年龄情况" };

            // 创建饼状图系列
            UIDoughnutSeries CoachDoughnutSeries = new UIDoughnutSeries
            {
                Name = "年龄"
            };

            // 添加数据到系列
            CoachDoughnutSeries.AddData("25-30岁", count25_30);
            CoachDoughnutSeries.AddData("30-35岁", count30_35);
            CoachDoughnutSeries.AddData("35-40岁", count35_40);
            CoachDoughnutSeries.AddData("40-45岁", count40_45);
            CoachDoughnutSeries.AddData("45岁以上", countOver45);

            // 设置系列
            CoachDoughnutOption.AddSeries(CoachDoughnutSeries);

            // 更新配置
            CoachDoughnutChart.SetOption(CoachDoughnutOption);
            // 更新显示信息
            CoachDoughnutMarkLabel.Text = string.Format(
                "教练年龄分布如下:\n" +
                "25-30岁的用户数量: {0}人\n" +
                "30-35岁的用户数量: {1}人\n" +
                "35-40岁的用户数量: {2}人\n" +
                "40-45岁的用户数量: {3}人\n" +
                "45岁以上的用户数量: {4}人",
                count25_30, count30_35, count35_40, count40_45, countOver45);
        }
        public void viewCourseBarChart()
        {
            // 初始化每个星期的课程数量
            int monday = 0;
            int tuesday = 0;
            int wednesday = 0;
            int thursday = 0;
            int friday = 0;
            int saturday = 0;
            int sunday = 0;

            // 创建 SqlConnection 对象并打开连接
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                // 查询语句：统计 Courses 表中 weekday 属性在各个星期的课程个数
                string query = @"
            SELECT 
                weekday, 
                COUNT(*) AS course_count
            FROM 
                Courses
            GROUP BY 
                weekday";

                SqlCommand sqlCommand = new SqlCommand(query, connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                // 遍历查询结果并统计每个星期的课程数量
                while (reader.Read())
                {
                    string weekday = Convert.ToString(reader["weekday"]);
                    int courseCount = Convert.ToInt32(reader["course_count"]);

                    switch (weekday)
                    {
                        case "星期一":
                            monday = courseCount;
                            break;
                        case "星期二":
                            tuesday = courseCount;
                            break;
                        case "星期三":
                            wednesday = courseCount;
                            break;
                        case "星期四":
                            thursday = courseCount;
                            break;
                        case "星期五":
                            friday = courseCount;
                            break;
                        case "星期六":
                            saturday = courseCount;
                            break;
                        case "星期日":
                            sunday = courseCount;
                            break;
                    }
                }

                // 关闭读取器
                reader.Close();
                connection.Close();
            }

            try
            {
                // 配置参数
                UIBarOption option = new UIBarOption();

                // 配置标题
                option.Title = new UITitle
                {
                    Text = "各星期课程数量", // 主标题
                };

                // 设置图例
                option.Legend = new UILegend
                {
                    Orient = UIOrient.Horizontal, // 图例水平布局
                    Top = UITopAlignment.Top, // 图例放置在左上角
                    Left = UILeftAlignment.Left
                };
                option.Legend.AddData("课程数量");

                // 设置系列
                UIBarSeries series = new UIBarSeries
                {
                    Name = "课程数量"
                };

                // 添加数据到系列
                series.AddData("周一", monday);
                series.AddData("周二", tuesday);
                series.AddData("周三", wednesday);
                series.AddData("周四", thursday);
                series.AddData("周五", friday);
                series.AddData("周六", saturday);
                series.AddData("周日", sunday);

                // 将系列添加到选项中
                option.Series.Add(series);

                // 设置横坐标内容
                option.XAxis.Data.Add("周一");
                option.XAxis.Data.Add("周二");
                option.XAxis.Data.Add("周三");
                option.XAxis.Data.Add("周四");
                option.XAxis.Data.Add("周五");
                option.XAxis.Data.Add("周六");
                option.XAxis.Data.Add("周日");

                // 辅助ToolTip是否可见
                option.ToolTip.Visible = true;

                // Y轴的刻度
                option.YAxis.Scale = true;

                // XY轴的单位
                option.XAxis.Name = null;
                option.YAxis.Name = "课程数量";

                // 更新配置
                CourseBarChart.SetOption(option);
                CourseBarMarkLabel.Text = string.Format($"总课程数量: {monday + tuesday + wednesday + thursday + friday + saturday + sunday}节\n" +
                                                        $"周一: {monday}节\n" +
                                                        $"周二: {tuesday}节\n" +
                                                        $"周三: {wednesday}节\n" +
                                                        $"周四: {thursday}节\n" +
                                                        $"周五: {friday}节\n" +
                                                        $"周六: {saturday}节\n" +
                                                        $"周日: {sunday}节");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发生错误: {ex.Message}");
            }
        }
        public void viewCourseBarChart11()
        {
            // 初始化每个星期的课程数量和课堂填充率
            int monday = 0, tuesday = 0, wednesday = 0, thursday = 0, friday = 0, saturday = 0, sunday = 0;
            int mondaytotal = 0, tuesdaytotal = 0, wednesdaytotal = 0, thursdaytotal = 0, fridaytotal = 0, saturdaytotal = 0, sundaytotal = 0;
            double mondayFillRate = 0.0, tuesdayFillRate = 0.0, wednesdayFillRate = 0.0, thursdayFillRate = 0.0, fridayFillRate = 0.0, saturdayFillRate = 0.0, sundayFillRate = 0.0;

            // 创建 SqlConnection 对象并打开连接
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                // 查询语句：统计 Courses 表中 weekday 属性在各个星期的课程个数及 maxstudent 总和
                string query = @"
            SELECT 
                weekday, 
                COUNT(*) AS course_count,
                SUM(maxstudent) AS total_maxstudent
            FROM 
                Courses
            GROUP BY 
                weekday";

                SqlCommand sqlCommand = new SqlCommand(query, connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                // 存储每个星期的课程ID列表
                Dictionary<string, List<int>> courseIdsByWeekday = new Dictionary<string, List<int>>();

                // 遍历查询结果并统计每个星期的课程数量和 maxstudent 总和
                while (reader.Read())
                {
                    string weekday = Convert.ToString(reader["weekday"]);
                    int courseCount = Convert.ToInt32(reader["course_count"]);
                    int totalMaxStudent = Convert.ToInt32(reader["total_maxstudent"]);

                    switch (weekday)
                    {
                        case "星期一":
                            monday = courseCount;
                            mondaytotal = totalMaxStudent;
                            break;
                        case "星期二":
                            tuesday = courseCount;
                            tuesdaytotal = totalMaxStudent;
                            break;
                        case "星期三":
                            wednesday = courseCount;
                            wednesdaytotal = totalMaxStudent;
                            break;
                        case "星期四":
                            thursday = courseCount;
                            thursdaytotal = totalMaxStudent;
                            break;
                        case "星期五":
                            friday = courseCount;
                            fridaytotal = totalMaxStudent;
                            break;
                        case "星期六":
                            saturday = courseCount;
                            saturdaytotal = totalMaxStudent;
                            break;
                        case "星期日":
                            sunday = courseCount;
                            sundaytotal = totalMaxStudent;
                            break;
                    }
                }

                reader.Close(); // 关闭 reader

                // 获取每个星期的所有课程ID
                string allCourseIdsQuery = @"
            SELECT weekday, courseid 
            FROM Courses";

                SqlCommand allCourseIdsCommand = new SqlCommand(allCourseIdsQuery, connection);
                using (SqlDataReader allCourseIdsReader = allCourseIdsCommand.ExecuteReader())
                {
                    while (allCourseIdsReader.Read())
                    {
                        string weekday = Convert.ToString(allCourseIdsReader["weekday"]);
                        int courseId = Convert.ToInt32(allCourseIdsReader["courseid"]);

                        if (courseIdsByWeekday.ContainsKey(weekday))
                        {
                            courseIdsByWeekday[weekday].Add(courseId);
                        }
                        else
                        {
                            courseIdsByWeekday[weekday] = new List<int> { courseId };
                        }
                    }
                }

                // 计算每个星期的课堂填充率
                foreach (var kvp in courseIdsByWeekday)
                {
                    string weekday = kvp.Key;
                    List<int> courseIds = kvp.Value;

                    // 查询 CourseInfo 表中对应课程ID的记录总数
                    string attendanceQuery = @"
                SELECT COUNT(*) AS student_count
                FROM CourseInfo
                WHERE courseid IN (" + string.Join(",", courseIds) + ")";

                    SqlCommand attendanceCommand = new SqlCommand(attendanceQuery, connection);
                    int studentCount = (int)attendanceCommand.ExecuteScalar();

                    // 计算课堂填充率
                    int totalMaxStudent = 0;
                    switch (weekday)
                    {
                        case "星期一":
                            totalMaxStudent = mondaytotal;
                            mondayFillRate = totalMaxStudent > 0 ? (double)studentCount / totalMaxStudent : 0.0;
                            break;
                        case "星期二":
                            totalMaxStudent = tuesdaytotal;
                            tuesdayFillRate = totalMaxStudent > 0 ? (double)studentCount / totalMaxStudent : 0.0;
                            break;
                        case "星期三":
                            totalMaxStudent = wednesdaytotal;
                            wednesdayFillRate = totalMaxStudent > 0 ? (double)studentCount / totalMaxStudent : 0.0;
                            break;
                        case "星期四":
                            totalMaxStudent = thursdaytotal;
                            thursdayFillRate = totalMaxStudent > 0 ? (double)studentCount / totalMaxStudent : 0.0;
                            break;
                        case "星期五":
                            totalMaxStudent = fridaytotal;
                            fridayFillRate = totalMaxStudent > 0 ? (double)studentCount / totalMaxStudent : 0.0;
                            break;
                        case "星期六":
                            totalMaxStudent = saturdaytotal;
                            saturdayFillRate = totalMaxStudent > 0 ? (double)studentCount / totalMaxStudent : 0.0;
                            break;
                        case "星期日":
                            totalMaxStudent = sundaytotal;
                            sundayFillRate = totalMaxStudent > 0 ? (double)studentCount / totalMaxStudent : 0.0;
                            break;
                    }
                }
            }

            try
            {
                // 配置参数
                UIBarOption option = new UIBarOption();

                // 配置标题
                option.Title = new UITitle
                {
                    Text = "课堂填充率", // 主标题
                };

                // 设置图例
                option.Legend = new UILegend
                {
                    Orient = UIOrient.Horizontal, // 图例水平布局
                    Top = UITopAlignment.Top, // 图例放置在左上角
                    Left = UILeftAlignment.Left
                };
                option.Legend.AddData("课堂填充率");

                // 设置系列
                UIBarSeries series = new UIBarSeries
                {
                    Name = "课堂填充率"
                };

                // 添加数据到系列
                series.AddData("周一", mondayFillRate * 100); // 将课堂填充率转换为百分比
                series.AddData("周二", tuesdayFillRate * 100);
                series.AddData("周三", wednesdayFillRate * 100);
                series.AddData("周四", thursdayFillRate * 100);
                series.AddData("周五", fridayFillRate * 100);
                series.AddData("周六", saturdayFillRate * 100);
                series.AddData("周日", sundayFillRate * 100);

                // 将系列添加到选项中
                option.Series.Add(series);

                // 设置横坐标内容
                option.XAxis.Data.Add("周一");
                option.XAxis.Data.Add("周二");
                option.XAxis.Data.Add("周三");
                option.XAxis.Data.Add("周四");
                option.XAxis.Data.Add("周五");
                option.XAxis.Data.Add("周六");
                option.XAxis.Data.Add("周日");

                // 辅助ToolTip是否可见
                option.ToolTip.Visible = true;

                // Y轴的刻度
                option.YAxis.Scale = true;

                // XY轴的单位
                option.XAxis.Name = null;
                option.YAxis.Name = "课堂填充率 (%)";

                // 更新配置
                CourseBarChart1.SetOption(option);

                // 构建 Label 文字说明
                int totalActualStudents = (int)(mondaytotal * mondayFillRate + tuesdaytotal * tuesdayFillRate + wednesdaytotal * wednesdayFillRate + thursdaytotal * thursdayFillRate + fridaytotal * fridayFillRate + saturdaytotal * saturdayFillRate + sundaytotal * sundayFillRate);

                string labelText = $"总课程数量: {monday + tuesday + wednesday + thursday + friday + saturday + sunday}节\n" +
                                   $"总最大上课人数: {mondaytotal + tuesdaytotal + wednesdaytotal + thursdaytotal + fridaytotal + saturdaytotal + sundaytotal}\n" +
                                   $"实际报名人数: {totalActualStudents}\n" +
                                   $"周一:课堂填充率: {mondayFillRate * 100:0.00}%, 总最大上课人数: {mondaytotal}, 实际报名人数: {mondaytotal * mondayFillRate}\n" +
                                   $"周二:课堂填充率: {tuesdayFillRate * 100:0.00}%, 总最大上课人数: {tuesdaytotal}, 实际报名人数: {tuesdaytotal * tuesdayFillRate}\n" +
                                   $"周三:课堂填充率: {wednesdayFillRate * 100:0.00}%, 总最大上课人数: {wednesdaytotal}, 实际报名人数: {wednesdaytotal * wednesdayFillRate}\n" +
                                   $"周四:课堂填充率: {thursdayFillRate * 100:0.00}%, 总最大上课人数: {thursdaytotal}, 实际报名人数: {thursdaytotal * thursdayFillRate}\n" +
                                   $"周五:课堂填充率: {fridayFillRate * 100:0.00}%, 总最大上课人数: {fridaytotal}, 实际报名人数: {fridaytotal * fridayFillRate}\n" +
                                   $"周六:课堂填充率: {saturdayFillRate * 100:0.00}%, 总最大上课人数: {saturdaytotal}, 实际报名人数: {saturdaytotal * saturdayFillRate}\n" +
                                   $"周日:课堂填充率: {sundayFillRate * 100:0.00}%, 总最大上课人数: {sundaytotal}, 实际报名人数: {sundaytotal * sundayFillRate}";

                // 设置 Label 文字
                CourseDoughnutMarkLabel.Text = labelText;

                // 调试信息
                Console.WriteLine(labelText);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发生错误: {ex.Message}");
            }
        }
        //绑定menu的选项到对应的PageControl界面
        private void Menu_selectChange(object sender, AntdUI.MenuSelectEventArgs e)
        {
            if (menu.Items[0].Select)
            {
                PageControl.SelectTab(0);
            }
            if (menu.Items[1].Select)
            {
                showselfinfo();
                PageControl.SelectTab(10);
            }
            if (menu.Items[2].Select)
            {
                showAdminInfo();
                PageControl.SelectTab(1);
            }
            if (menu.Items[3].Select)
            {
                if (menu.Items[3].Sub[0].Select)
                {
                    showUserInfo();
                    PageControl.SelectTab(2);
                }
                else if (menu.Items[3].Sub[1].Select)
                {
                    showCoachInfo();
                    PageControl.SelectTab(3);
                }
                else if (menu.Items[3].Sub[2].Select)
                {
                    showCourseInfo();
                    PageControl.SelectTab(4);
                }
                else if (menu.Items[3].Sub[3].Select)
                {
                    showReserveInfo();
                    PageControl.SelectTab(5);
                }
            }
            if (menu.Items[4].Select)
            {
                if (menu.Items[4].Sub[0].Select)
                {
                    viewUserDoughnutChart();
                    viewUserBarChart();
                    PageControl.SelectTab(6);
                }
                else if (menu.Items[4].Sub[1].Select)
                {
                    viewCoachDoughnutChart();
                    viewCoachBarChart();
                    PageControl.SelectTab(7);
                }
                else if (menu.Items[4].Sub[2].Select)
                {
                    viewCourseBarChart();
                    viewCourseBarChart11();
                    //viewCourseDoughnutChart();
                    PageControl.SelectTab(8);
                }
            }
            if (menu.Items[5].Select)
            {
                PageControl.SelectTab(9);
            }
            if (menu.Items[6].Select)
            {
                // 显示一个消息框，询问用户是否要退出程序
                DialogResult result = MessageBox.Show(
                    "确认退出系统？",
                    "退出确认",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                // 根据用户的选择决定是否退出程序
                if (result == DialogResult.Yes)
                {
                    Application.Exit(); // 用户选择“是”，退出程序
                }
            }
        }
        //设置无框体移动
        private void PageControl_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        //设置无框体移动
        private void panelLogo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        //设置无框体移动
        private void Titile_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        //退出系统
        private void button2_Click(object sender, EventArgs e)
        {
            // 显示一个消息框，询问用户是否要退出程序
            DialogResult result = MessageBox.Show(
                "您确定要退出程序吗？",
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
        //最小化
        private void button3_Click(object sender, EventArgs e)
        {
            // 使用 AnimateWindow 函数来最小化窗体
            AnimateWindow(this.Handle, 500, AnimateWindowFlags.AW_HIDE | AnimateWindowFlags.AW_BLEND);

            // 设置窗体状态为最小化
            this.WindowState = FormWindowState.Minimized;
        }
        private void frmAdmin_Load(object sender, EventArgs e)
        {

            // 获取当前日期
            DateTime today = DateTime.Now;
            string greeting = "";

            // 判断当前时间段
            if (today.Hour >= 5 && today.Hour < 12)
            {
                // 早上
                greeting = "早上好，管理员";
            }
            else if (today.Hour >= 11 && today.Hour < 13)
            {
                // 中午
                greeting = "中午好，管理员";
            }
            else if (today.Hour >= 13 && today.Hour < 18)
            {
                // 下午
                greeting = "下午好，管理员";
            }
            else if (today.Hour >= 18 && today.Hour < 22)
            {
                // 晚上
                greeting = "晚上好，管理员";
            }
            else
            {
                // 深夜
                greeting = "太晚啦，早点休息";
            }
            HelloLabel.Text = greeting;
            // 判断今天是否是星期几
            switch (today.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    Weekday_pic.SelectIndex = 0;
                    break;
                case DayOfWeek.Tuesday:
                    Weekday_pic.SelectIndex = 1;
                    break;
                case DayOfWeek.Wednesday:
                    Weekday_pic.SelectIndex = 2;
                    break;
                case DayOfWeek.Thursday:
                    Weekday_pic.SelectIndex = 3;
                    break;
                case DayOfWeek.Friday:
                    Weekday_pic.SelectIndex = 4;
                    break;
                case DayOfWeek.Saturday:
                    Weekday_pic.SelectIndex = 5;
                    break;
                case DayOfWeek.Sunday:
                    Weekday_pic.SelectIndex = 6;
                    break;
                default:
                    // 默认情况下，如果出现意外情况，可以选择一个默认值
                    Weekday_pic.SelectIndex = 0;
                    break;
            }
        }
        private void uiLinkLabel1_Click(object sender, EventArgs e)
        {
            try
            {
                // 指定要打开的网站URL
                string url = "http://www.yyf040810.cn:1782";

                // 使用 Process.Start 打开网站
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                // 处理可能发生的异常
                MessageBox.Show($"无法打开网站: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //分页页面变化事件
        private void uiPagination1_ActivePageChanged(object sender, object pagingSource, int pageIndex, int count)
        {
            // 检查数据源是否为空
            if (gmsDataSet.Tables["Admin"] == null || gmsDataSet.Tables["Admin"].Rows.Count == 0)
            {
                return;
            }

            // 计算分页的起始索引和结束索引
            int startIndex = (pageIndex - 1) * count;
            int endIndex = Math.Min(startIndex + count, gmsDataSet.Tables["Admin"].Rows.Count);

            // 确保索引在有效范围内
            if (startIndex < 0 || endIndex > gmsDataSet.Tables["Admin"].Rows.Count)
            {
                MessageBox.Show("分页参数无效！");
                return;
            }
            AdminTable.DataSource = uiPagination1.PageDataSource;
        }
        private void UserPagination_ActivePageChanged(object sender, object pagingSource, int pageIndex, int count)
        {
            // 检查数据源是否为空
            if (gmsDataSet.Tables["User"] == null || gmsDataSet.Tables["User"].Rows.Count == 0)
            {
                return;
            }

            // 计算分页的起始索引和结束索引
            int startIndex = (pageIndex - 1) * count;
            int endIndex = Math.Min(startIndex + count, gmsDataSet.Tables["User"].Rows.Count);

            // 确保索引在有效范围内
            if (startIndex < 0 || endIndex > gmsDataSet.Tables["User"].Rows.Count)
            {
                MessageBox.Show("分页参数无效！");
                return;
            }
            UserTable.DataSource = UserPagination.PageDataSource;
        }
        private void CoachPagination_ActivePageChanged(object sender, object pagingSource, int pageIndex, int count)
        {
            // 检查数据源是否为空
            if (gmsDataSet.Tables["Coach"] == null || gmsDataSet.Tables["Coach"].Rows.Count == 0)
            {
                return;
            }

            // 计算分页的起始索引和结束索引
            int startIndex = (pageIndex - 1) * count;
            int endIndex = Math.Min(startIndex + count, gmsDataSet.Tables["Coach"].Rows.Count);

            // 确保索引在有效范围内
            if (startIndex < 0 || endIndex > gmsDataSet.Tables["Coach"].Rows.Count)
            {
                MessageBox.Show("分页参数无效！");
                return;
            }
            CoachTable.DataSource = CoachPagination.PageDataSource;
        }
        private void CoursePagination_ActivePageChanged(object sender, object pagingSource, int pageIndex, int count)
        {
            // 检查数据源是否为空
            if (gmsDataSet.Tables["Course"] == null || gmsDataSet.Tables["Course"].Rows.Count == 0)
            {
                return;
            }

            // 计算分页的起始索引和结束索引
            int startIndex = (pageIndex - 1) * count;
            int endIndex = Math.Min(startIndex + count, gmsDataSet.Tables["Course"].Rows.Count);

            // 确保索引在有效范围内
            if (startIndex < 0 || endIndex > gmsDataSet.Tables["Course"].Rows.Count)
            {
                MessageBox.Show("分页参数无效！");
                return;
            }
            CourseTable.DataSource = CoursePagination.PageDataSource;
        }
        private void ReservePagination_ActivePageChanged(object sender, object pagingSource, int pageIndex, int count)
        {
            // 检查数据源是否为空
            if (gmsDataSet.Tables["Reserve"] == null || gmsDataSet.Tables["Reserve"].Rows.Count == 0)
            {
                return;
            }

            // 计算分页的起始索引和结束索引
            int startIndex = (pageIndex - 1) * count;
            int endIndex = Math.Min(startIndex + count, gmsDataSet.Tables["Reserve"].Rows.Count);

            // 确保索引在有效范围内
            if (startIndex < 0 || endIndex > gmsDataSet.Tables["Reserve"].Rows.Count)
            {
                MessageBox.Show("分页参数无效！");
                return;
            }
            ReserveTable.DataSource = ReservePagination.PageDataSource;
        }
        //搜索按钮
        private void button4_Click(object sender, EventArgs e)
        {
            // 创建 SqlConnection 对象并打开连接
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                string query = "SELECT Login.id AS [用户名], Users.name AS [姓名], Users.age AS [年龄], Users.sex AS [性别], " +
                                "Users.phone AS [手机号码], Users.IDcard AS [身份证], Users.email AS [邮箱], " +
                                "CONVERT(varchar, Users.birthday, 111) AS [出生日期] " +
                                "FROM Login INNER JOIN Users ON Login.id = Users.id " +
                                "WHERE (Login.usertype='管理员')";

                // 添加搜索条件
                List<string> conditions = new List<string>();
                List<SqlParameter> parameters = new List<SqlParameter>();

                if (!string.IsNullOrEmpty(SearchAdminByid.Text.Trim()))
                {
                    conditions.Add("Login.id LIKE @SearchAdminByid");
                    parameters.Add(new SqlParameter("@SearchAdminByid", "%" + SearchAdminByid.Text.Trim() + "%"));
                }
                if (!string.IsNullOrEmpty(SearchAdminByname.Text.Trim()))
                {
                    conditions.Add("Users.name LIKE @SearchAdminByname");
                    parameters.Add(new SqlParameter("@SearchAdminByname", "%" + SearchAdminByname.Text.Trim() + "%"));
                }
                if (!string.IsNullOrEmpty(SearchAdminByphone.Text.Trim()))
                {
                    conditions.Add("Users.phone LIKE @SearchAdminByphone");
                    parameters.Add(new SqlParameter("@SearchAdminByphone", "%" + SearchAdminByphone.Text.Trim() + "%"));
                }

                if (conditions.Count > 0)
                {
                    // 如果有搜索条件，将它们添加到 WHERE 子句中
                    query += " AND (" + string.Join(" AND ", conditions) + ")";
                }

                // 添加 ORDER BY 子句
                query += " ORDER BY Login.id ASC";

                // 创建 SqlCommand 对象
                SqlCommand sqlCommand = new SqlCommand(query, connection);

                // 添加参数
                foreach (var param in parameters)
                {
                    sqlCommand.Parameters.Add(param);
                }

                // 使用 SqlCommand 创建 SqlDataAdapter
                SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

                // 确保数据集中有一个名为 Admin 的 DataTable
                if (gmsDataSet.Tables["Admin"] == null)
                {
                    // 如果不存在，则创建一个新的 DataTable
                    DataTable adminTable = new DataTable("Admin");
                    gmsDataSet.Tables.Add(adminTable);
                }
                else
                {
                    // 清除现有数据
                    gmsDataSet.Tables["Admin"].Rows.Clear();
                }

                // 使用 SqlDataAdapter 填充数据集中的 Admin 表
                int rowsAffected = sqlData.Fill(gmsDataSet.Tables["Admin"]);

                // 设置 BindingSource 的 DataSource
                bindingSourceAdmin.DataSource = gmsDataSet.Tables["Admin"];

                // 检查是否找到了数据
                if (rowsAffected == 0)
                {

                    // 清空 AdminTable 的数据源
                    AdminTable.DataSource = null;

                    // 重置分页控件
                    uiPagination1.TotalCount = 0;
                    uiPagination1.ActivePage = 1;
                    //uiPagination1.PageDataSource = null; // 如果 PageDataSource 是一个属性，请确保这里正确设置
                }
                else
                {
                    // 计算总页数
                    int totalRows = gmsDataSet.Tables["Admin"].Rows.Count;
                    int pageCount = (int)Math.Ceiling((double)totalRows / uiPagination1.PageSize);

                    // 设置总条目数
                    uiPagination1.TotalCount = totalRows;

                    // 设置数据源
                    uiPagination1.DataSource = bindingSourceAdmin;

                    // 设置初始页码
                    uiPagination1.ActivePage = 1;

                    // 如果分页控件有 PageDataSource，则设置 AdminTable 的 DataSource
                    if (uiPagination1.PageDataSource != null)
                    {
                        AdminTable.DataSource = uiPagination1.PageDataSource;
                    }
                }
                connection.Close();
            }
        }
        private void SearchUser_Click(object sender, EventArgs e)
        {
            // 创建 SqlConnection 对象并打开连接
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                string query = "SELECT Login.id AS [用户名], Users.name AS [姓名], Users.age AS [年龄], Users.sex AS [性别], " +
                                "Users.phone AS [手机号码], Users.IDcard AS [身份证], Users.email AS [邮箱], " +
                                "CONVERT(varchar, Users.birthday, 111) AS [出生日期] " +
                                "FROM Login INNER JOIN Users ON Login.id = Users.id " +
                                "WHERE (Login.usertype='用户')";

                // 添加搜索条件
                List<string> conditions = new List<string>();
                List<SqlParameter> parameters = new List<SqlParameter>();

                if (!string.IsNullOrEmpty(SearchUserByid.Text.Trim()))
                {
                    conditions.Add("Login.id LIKE @SearchAdminByid");
                    parameters.Add(new SqlParameter("@SearchAdminByid", "%" + SearchUserByid.Text.Trim() + "%"));
                }
                if (!string.IsNullOrEmpty(SearchUserByname.Text.Trim()))
                {
                    conditions.Add("Users.name LIKE @SearchAdminByname");
                    parameters.Add(new SqlParameter("@SearchAdminByname", "%" + SearchUserByname.Text.Trim() + "%"));
                }
                if (!string.IsNullOrEmpty(SearchUserByphone.Text.Trim()))
                {
                    conditions.Add("Users.phone LIKE @SearchAdminByphone");
                    parameters.Add(new SqlParameter("@SearchAdminByphone", "%" + SearchUserByphone.Text.Trim() + "%"));
                }

                if (conditions.Count > 0)
                {
                    // 如果有搜索条件，将它们添加到 WHERE 子句中
                    query += " AND (" + string.Join(" AND ", conditions) + ")";
                }

                // 添加 ORDER BY 子句
                query += " ORDER BY Login.id ASC";

                // 创建 SqlCommand 对象
                SqlCommand sqlCommand = new SqlCommand(query, connection);

                // 添加参数
                foreach (var param in parameters)
                {
                    sqlCommand.Parameters.Add(param);
                }

                // 使用 SqlCommand 创建 SqlDataAdapter
                SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

                // 确保数据集中有一个名为 Admin 的 DataTable
                if (gmsDataSet.Tables["User"] == null)
                {
                    // 如果不存在，则创建一个新的 DataTable
                    DataTable UserTable = new DataTable("User");
                    gmsDataSet.Tables.Add(UserTable);
                }
                else
                {
                    // 清除现有数据
                    gmsDataSet.Tables["User"].Rows.Clear();
                }

                // 使用 SqlDataAdapter 填充数据集中的 Admin 表
                int rowsAffected = sqlData.Fill(gmsDataSet.Tables["User"]);

                // 设置 BindingSource 的 DataSource
                bindingSourceUser.DataSource = gmsDataSet.Tables["User"];

                // 检查是否找到了数据
                if (rowsAffected == 0)
                {

                    // 清空 AdminTable 的数据源
                    UserTable.DataSource = null;

                    // 重置分页控件
                    UserPagination.TotalCount = 0;
                    UserPagination.ActivePage = 1;
                    //uiPagination1.PageDataSource = null; // 如果 PageDataSource 是一个属性，请确保这里正确设置
                }
                else
                {
                    // 计算总页数
                    int totalRows = gmsDataSet.Tables["User"].Rows.Count;
                    int pageCount = (int)Math.Ceiling((double)totalRows / UserPagination.PageSize);

                    // 设置总条目数
                    UserPagination.TotalCount = totalRows;

                    // 设置数据源
                    UserPagination.DataSource = bindingSourceUser;

                    // 设置初始页码
                    UserPagination.ActivePage = 1;

                    // 如果分页控件有 PageDataSource，则设置 AdminTable 的 DataSource
                    if (UserPagination.PageDataSource != null)
                    {
                        UserTable.DataSource = UserPagination.PageDataSource;
                    }
                }
                connection.Close();
            }
        }
        private void SearchCoach_Click(object sender, EventArgs e)
        {
            // 创建 SqlConnection 对象并打开连接
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                string query = "SELECT Login.id AS [用户名], Users.name AS [姓名], Users.age AS [年龄], Users.sex AS [性别], " +
                                "Users.phone AS [手机号码], Users.IDcard AS [身份证], Users.email AS [邮箱], " +
                                "CONVERT(varchar, Users.birthday, 111) AS [出生日期] " +
                                "FROM Login INNER JOIN Users ON Login.id = Users.id " +
                                "WHERE (Login.usertype='教练')";

                // 添加搜索条件
                List<string> conditions = new List<string>();
                List<SqlParameter> parameters = new List<SqlParameter>();

                if (!string.IsNullOrEmpty(SearchCoachByid.Text.Trim()))
                {
                    conditions.Add("Login.id LIKE @SearchAdminByid");
                    parameters.Add(new SqlParameter("@SearchAdminByid", "%" + SearchCoachByid.Text.Trim() + "%"));
                }
                if (!string.IsNullOrEmpty(SearchCoachByname.Text.Trim()))
                {
                    conditions.Add("Users.name LIKE @SearchAdminByname");
                    parameters.Add(new SqlParameter("@SearchAdminByname", "%" + SearchCoachByname.Text.Trim() + "%"));
                }
                if (!string.IsNullOrEmpty(SearchCoachByphone.Text.Trim()))
                {
                    conditions.Add("Users.phone LIKE @SearchAdminByphone");
                    parameters.Add(new SqlParameter("@SearchAdminByphone", "%" + SearchCoachByphone.Text.Trim() + "%"));
                }

                if (conditions.Count > 0)
                {
                    // 如果有搜索条件，将它们添加到 WHERE 子句中
                    query += " AND (" + string.Join(" AND ", conditions) + ")";
                }

                // 添加 ORDER BY 子句
                query += " ORDER BY Login.id ASC";

                // 创建 SqlCommand 对象
                SqlCommand sqlCommand = new SqlCommand(query, connection);

                // 添加参数
                foreach (var param in parameters)
                {
                    sqlCommand.Parameters.Add(param);
                }

                // 使用 SqlCommand 创建 SqlDataAdapter
                SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

                // 确保数据集中有一个名为 Admin 的 DataTable
                if (gmsDataSet.Tables["Coach"] == null)
                {
                    // 如果不存在，则创建一个新的 DataTable
                    DataTable CoachTable = new DataTable("Coach");
                    gmsDataSet.Tables.Add(CoachTable);
                }
                else
                {
                    // 清除现有数据
                    gmsDataSet.Tables["Coach"].Rows.Clear();
                }

                // 使用 SqlDataAdapter 填充数据集中的 Admin 表
                int rowsAffected = sqlData.Fill(gmsDataSet.Tables["Coach"]);

                // 设置 BindingSource 的 DataSource
                bindingSourceCoach.DataSource = gmsDataSet.Tables["Coach"];

                // 检查是否找到了数据
                if (rowsAffected == 0)
                {

                    // 清空 AdminTable 的数据源
                    CoachTable.DataSource = null;

                    // 重置分页控件
                    CoachPagination.TotalCount = 0;
                    CoachPagination.ActivePage = 1;
                    //uiPagination1.PageDataSource = null; // 如果 PageDataSource 是一个属性，请确保这里正确设置
                }
                else
                {
                    // 计算总页数
                    int totalRows = gmsDataSet.Tables["Coach"].Rows.Count;
                    int pageCount = (int)Math.Ceiling((double)totalRows / CoachPagination.PageSize);

                    // 设置总条目数
                    CoachPagination.TotalCount = totalRows;

                    // 设置数据源
                    CoachPagination.DataSource = bindingSourceCoach;

                    // 设置初始页码
                    CoachPagination.ActivePage = 1;

                    // 如果分页控件有 PageDataSource，则设置 AdminTable 的 DataSource
                    if (CoachPagination.PageDataSource != null)
                    {
                        CoachTable.DataSource = CoachPagination.PageDataSource;
                    }
                }
                connection.Close();
            }
        }
        private void SearchCourse_Click(object sender, EventArgs e)
        {
            // 创建 SqlConnection 对象并打开连接
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                string query = "SELECT  courseid AS [课程号], coursename AS [课程名称], coachid AS [教练], " +
                    "weekday AS [星期], start_time AS [上课时间], duration_hours AS [课程时长], " +
                    "maxstudent AS [最大学生数量]from Courses where duration_hours < 20";
                // 添加搜索条件
                List<string> conditions = new List<string>();
                List<SqlParameter> parameters = new List<SqlParameter>();
                if (!string.IsNullOrEmpty(CourseName.Text.Trim()))
                {
                    conditions.Add("coursename=@CourseName");
                    parameters.Add(new SqlParameter("@CourseName", CourseName.Text.Trim()));
                }
                if (!string.IsNullOrEmpty(CourseTime.Text.Trim()))
                {
                    // 尝试解析用户输入的时间
                    if (TimeSpan.TryParse(CourseTime.Text, out TimeSpan startTime))
                    {
                        // 添加条件到查询
                        conditions.Add(" start_time = @CourseTime");

                        // 添加参数
                        parameters.Add(new SqlParameter("@CourseTime", SqlDbType.Time)
                        {
                            Value = startTime
                        });
                    }
                    else
                    {
                        // 处理无效的时间输入
                        MessageBox.Show("请输入有效的时间格式（例如 17:00）。");
                    }
                }
                if (!string.IsNullOrEmpty(CourseCoachid.Text.Trim()))
                {
                    conditions.Add("coachid LIKE @CourseCoachid");
                    parameters.Add(new SqlParameter("@CourseCoachid", "%" + CourseCoachid.Text.Trim() + "%"));
                }
                if (!string.IsNullOrEmpty(dayofweek.Text.Trim()))
                {
                    conditions.Add("weekday=@dayofweek");
                    parameters.Add(new SqlParameter("@dayofweek", dayofweek.Text.Trim()));
                }

                if (conditions.Count > 0)
                {
                    // 如果有搜索条件，将它们添加到 WHERE 子句中
                    query += " AND (" + string.Join(" AND ", conditions) + ")";
                }

                // 添加 ORDER BY 子句
                query += " ORDER BY courseid ASC";

                // 创建 SqlCommand 对象
                SqlCommand sqlCommand = new SqlCommand(query, connection);

                // 添加参数
                foreach (var param in parameters)
                {
                    sqlCommand.Parameters.Add(param);
                }

                // 使用 SqlCommand 创建 SqlDataAdapter
                SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

                // 确保数据集中有一个名为 Admin 的 DataTable
                if (gmsDataSet.Tables["Course"] == null)
                {
                    // 如果不存在，则创建一个新的 DataTable
                    DataTable CourseTable = new DataTable("Course");
                    gmsDataSet.Tables.Add(CourseTable);
                }
                else
                {
                    // 清除现有数据
                    gmsDataSet.Tables["Course"].Rows.Clear();
                }

                // 使用 SqlDataAdapter 填充数据集中的 Admin 表
                int rowsAffected = sqlData.Fill(gmsDataSet.Tables["Course"]);

                // 设置 BindingSource 的 DataSource
                bindingSourceCourse.DataSource = gmsDataSet.Tables["Course"];

                // 检查是否找到了数据
                if (rowsAffected == 0)
                {

                    // 清空 AdminTable 的数据源
                    CourseTable.DataSource = null;

                    // 重置分页控件
                    CoursePagination.TotalCount = 0;
                    CoursePagination.ActivePage = 1;
                    //uiPagination1.PageDataSource = null; // 如果 PageDataSource 是一个属性，请确保这里正确设置
                }
                else
                {
                    // 计算总页数
                    int totalRows = gmsDataSet.Tables["Course"].Rows.Count;
                    int pageCount = (int)Math.Ceiling((double)totalRows / CoursePagination.PageSize);

                    // 设置总条目数
                    CoursePagination.TotalCount = totalRows;

                    // 设置数据源
                    CoursePagination.DataSource = bindingSourceCourse;

                    // 设置初始页码
                    CoursePagination.ActivePage = 1;

                    // 如果分页控件有 PageDataSource，则设置 AdminTable 的 DataSource
                    if (CoursePagination.PageDataSource != null)
                    {
                        CourseTable.DataSource = CoursePagination.PageDataSource;
                    }
                }
            }
        }
        private void SearchReseveCourse_Click(object sender, EventArgs e)
        {
            // 创建 SqlConnection 对象并打开连接
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                // 基础查询
                string query = @"
                SELECT 
                    r.courseid AS [课程号],
                    c.coursename AS [课程名称],
                    r.stuid AS [学生ID],
                    u.name AS [学生姓名],
                    c.maxstudent AS [最大学生数量],
                    (c.maxstudent - ISNULL((SELECT COUNT(*) FROM ReservationInfo ri WHERE ri.courseid = r.courseid), 0)) AS [剩余可选人数]
                FROM 
                    ReservationInfo r
                INNER JOIN 
                    Courses c ON r.courseid = c.courseid
                INNER JOIN 
                    Users u ON r.stuid = u.id
                ORDER BY 
                    r.courseid;";

                // 添加搜索条件
                List<string> conditions = new List<string>();
                List<SqlParameter> parameters = new List<SqlParameter>();

                if (!string.IsNullOrEmpty(ReserveName.Text.Trim()))
                {
                    conditions.Add("c.coursename=@ReserveName");
                    parameters.Add(new SqlParameter("@ReserveName", ReserveName.Text.Trim()));
                }

                if (!string.IsNullOrEmpty(ReserveCoachid.Text.Trim()))
                {
                    conditions.Add("c.coachid LIKE @ReserveCoachid");
                    parameters.Add(new SqlParameter("@ReserveCoachid", "%" + ReserveCoachid.Text.Trim() + "%"));
                }

                if (!string.IsNullOrEmpty(ReserveUserid.Text.Trim()))
                {
                    conditions.Add("r.stuid LIKE @ReserveUserid");
                    parameters.Add(new SqlParameter("@ReserveUserid", "%" + ReserveUserid.Text.Trim() + "%"));
                }

                if (!string.IsNullOrEmpty(ReseveDayOfWeek.Text.Trim()))
                {
                    conditions.Add("c.weekday=@ReseveDayOfWeek");
                    parameters.Add(new SqlParameter("@ReseveDayOfWeek", ReseveDayOfWeek.Text.Trim()));
                }

                if (conditions.Count > 0)
                {
                    // 如果有搜索条件，将它们添加到 WHERE 子句中
                    query += " WHERE " + string.Join(" AND ", conditions);
                }

                // 添加 ORDER BY 子句
                query += " ORDER BY r.courseid ASC";

                // 创建 SqlCommand 对象
                SqlCommand sqlCommand = new SqlCommand(query, connection);

                // 添加参数
                foreach (var param in parameters)
                {
                    sqlCommand.Parameters.Add(param);
                }

                // 使用 SqlCommand 创建 SqlDataAdapter
                SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

                // 确保数据集中有一个名为 Reserve 的 DataTable
                if (gmsDataSet.Tables["Reserve"] == null)
                {
                    // 如果不存在，则创建一个新的 DataTable
                    DataTable ReserveTable = new DataTable("Reserve");
                    gmsDataSet.Tables.Add(ReserveTable);
                }
                else
                {
                    // 清除现有数据
                    gmsDataSet.Tables["Reserve"].Rows.Clear();
                }

                // 使用 SqlDataAdapter 填充数据集中的 Reserve 表
                int rowsAffected = sqlData.Fill(gmsDataSet.Tables["Reserve"]);

                // 设置 BindingSource 的 DataSource
                bindingSourceReserve.DataSource = gmsDataSet.Tables["Reserve"];

                // 检查是否找到了数据
                if (rowsAffected == 0)
                {
                    // 清空 ReserveTable 的数据源
                    ReserveTable.DataSource = null;

                    // 重置分页控件
                    ReservePagination.TotalCount = 0;
                    ReservePagination.ActivePage = 1;
                    //uiPagination1.PageDataSource = null; // 如果 PageDataSource 是一个属性，请确保这里正确设置
                }
                else
                {
                    // 计算总页数
                    int totalRows = gmsDataSet.Tables["Reserve"].Rows.Count;
                    int pageCount = (int)Math.Ceiling((double)totalRows / ReservePagination.PageSize);

                    // 设置总条目数
                    ReservePagination.TotalCount = totalRows;

                    // 设置数据源
                    ReservePagination.DataSource = bindingSourceReserve;

                    // 设置初始页码
                    ReservePagination.ActivePage = 1;

                    // 如果分页控件有 PageDataSource，则设置 ReserveTable 的 DataSource
                    if (ReservePagination.PageDataSource != null)
                    {
                        ReserveTable.DataSource = ReservePagination.PageDataSource;
                    }
                }
            }
        }
        private void deleteAdmin_Click(object sender, EventArgs e)
        {
            // 检查是否有选中的行
            if (AdminTable.SelectedIndex != -1)
            {
                // 获取选中的行索引
                int index = AdminTable.SelectedIndex - 1;

                // 确保索引在有效范围内
                if (index >= 0 && index < uiPagination1.TotalCount)
                {
                    // 获取选中行的数据
                    DataRow selectedRow = gmsDataSet.Tables["Admin"].Rows[index + (uiPagination1.ActivePage - 1) * uiPagination1.PageSize];

                    // 获取用户名（或其他唯一标识）
                    string userId = selectedRow["用户名"].ToString();

                    // 创建 SqlConnection 对象并打开连接
                    using (SqlConnection connection = new SqlConnection(con))
                    {
                        connection.Open();

                        // 使用事务来确保数据一致性
                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                // 创建删除命令
                                string deleteQuery = @"DELETE FROM Users WHERE id = @UserId;
                        DELETE FROM Login WHERE id = @UserId;";

                                SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection, transaction);
                                deleteCommand.Parameters.AddWithValue("@UserId", userId);

                                // 执行删除命令
                                int rowsAffected = deleteCommand.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    // 如果删除成功，从数据表中移除该行
                                    gmsDataSet.Tables["Admin"].Rows.Remove(selectedRow);

                                    // 提交事务
                                    transaction.Commit();

                                    // 更新 DataGridView 的数据源
                                    AdminTable.DataSource = gmsDataSet.Tables["Admin"];

                                    // 重新计算分页控件
                                    int totalRows = gmsDataSet.Tables["Admin"].Rows.Count;
                                    uiPagination1.TotalCount = totalRows;

                                    // 如果删除后数据表为空，显示提示
                                    if (totalRows == 0)
                                    {
                                        AdminTable.DataSource = null; // 清空 DataGridView
                                        uiPagination1.ActivePage = 1; // 重置到第一页
                                    }
                                    else
                                    {
                                        // 如果还有数据，重置到第一页
                                        uiPagination1.ActivePage = 1;
                                    }

                                    // 提示删除成功
                                    MessageBox.Show("管理员删除成功！");
                                }
                                else
                                {
                                    // 提示删除失败
                                    MessageBox.Show("管理员删除失败！");
                                }
                            }
                            catch (Exception ex)
                            {
                                // 发生异常时回滚事务
                                transaction.Rollback();
                                MessageBox.Show("删除操作失败: " + ex.Message);
                            }
                        }
                        connection.Close();
                    }
                }
                else
                {
                    // 提示索引超出范围
                    MessageBox.Show(string.Format("选中的行索引超出范围，请重新选择。"));
                }
            }
            else
            {
                // 提示没有选中的行
                MessageBox.Show("请先选择要删除的管理员！");
            }
        }
        private void deleteUser_Click(object sender, EventArgs e)
        {
            // 检查是否有选中的行
            if (UserTable.SelectedIndex != -1)
            {
                // 获取选中的行索引
                int index = UserTable.SelectedIndex - 1;

                // 确保索引在有效范围内
                if (index >= 0 && index < UserPagination.TotalCount)
                {
                    // 获取选中行的数据
                    DataRow selectedRow = gmsDataSet.Tables["User"].Rows[index + (UserPagination.ActivePage - 1) * UserPagination.PageSize];

                    // 获取用户名（或其他唯一标识）
                    string userId = selectedRow["用户名"].ToString();

                    // 创建 SqlConnection 对象并打开连接
                    using (SqlConnection connection = new SqlConnection(con))
                    {
                        connection.Open();

                        // 使用事务来确保数据一致性
                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                // 创建删除命令
                                string deleteQuery = @"DELETE FROM Users WHERE id = @UserId;
                        DELETE FROM Login WHERE id = @UserId;";

                                SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection, transaction);
                                deleteCommand.Parameters.AddWithValue("@UserId", userId);

                                // 执行删除命令
                                int rowsAffected = deleteCommand.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    // 提交事务
                                    transaction.Commit();
                                    // 如果删除成功，从数据表中移除该行
                                    gmsDataSet.Tables["User"].Rows.Remove(selectedRow);

                                    // 更新 DataGridView 的数据源
                                    UserTable.DataSource = gmsDataSet.Tables["User"];

                                    // 重新计算分页控件
                                    int totalRows = gmsDataSet.Tables["User"].Rows.Count;
                                    UserPagination.TotalCount = totalRows;

                                    // 如果删除后数据表为空，显示提示
                                    if (totalRows == 0)
                                    {
                                        UserTable.DataSource = null; // 清空 DataGridView
                                        UserPagination.ActivePage = 1; // 重置到第一页
                                    }
                                    else
                                    {
                                        // 如果还有数据，重置到第一页
                                        UserPagination.ActivePage = 1;
                                    }

                                    // 提示删除成功
                                    MessageBox.Show("用户删除成功！");
                                }
                                else
                                {
                                    // 提示删除失败
                                    MessageBox.Show("用户删除失败！");
                                }
                            }
                            catch (Exception ex)
                            {
                                // 发生异常时回滚事务
                                transaction.Rollback();
                                MessageBox.Show("删除操作失败: " + ex.Message);
                            }
                        }
                        connection.Close();
                    }
                }
                else
                {
                    // 提示索引超出范围
                    MessageBox.Show(string.Format("选中的行索引超出范围，请重新选择。"));
                }
            }
            else
            {
                // 提示没有选中的行
                MessageBox.Show("请先选择要删除的用户！");
            }
        }
        private void deleteCoach_Click(object sender, EventArgs e)
        {
            // 检查是否有选中的行
            if (CoachTable.SelectedIndex != -1)
            {
                // 获取选中的行索引
                int index = CoachTable.SelectedIndex - 1;

                // 确保索引在有效范围内
                if (index >= 0 && index < CoachPagination.TotalCount)
                {
                    // 获取选中行的数据
                    DataRow selectedRow = gmsDataSet.Tables["Coach"].Rows[index + (CoachPagination.ActivePage - 1) * CoachPagination.PageSize];

                    // 获取用户名（或其他唯一标识）
                    string userId = selectedRow["用户名"].ToString();

                    // 创建 SqlConnection 对象并打开连接
                    using (SqlConnection connection = new SqlConnection(con))
                    {
                        connection.Open();

                        // 使用事务来确保数据一致性
                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                // 创建删除命令
                                string deleteQuery = @"DELETE FROM Users WHERE id = @UserId;
                        DELETE FROM Login WHERE id = @UserId;";

                                SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection, transaction);
                                deleteCommand.Parameters.AddWithValue("@UserId", userId);

                                // 执行删除命令
                                int rowsAffected = deleteCommand.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    // 提交事务
                                    transaction.Commit();
                                    // 如果删除成功，从数据表中移除该行
                                    gmsDataSet.Tables["Coach"].Rows.Remove(selectedRow);

                                    // 更新 DataGridView 的数据源
                                    CoachTable.DataSource = gmsDataSet.Tables["Coach"];

                                    // 重新计算分页控件
                                    int totalRows = gmsDataSet.Tables["Coach"].Rows.Count;
                                    CoachPagination.TotalCount = totalRows;

                                    // 如果删除后数据表为空，显示提示
                                    if (totalRows == 0)
                                    {
                                        CoachTable.DataSource = null; // 清空 DataGridView
                                        CoachPagination.ActivePage = 1; // 重置到第一页
                                    }
                                    else
                                    {
                                        // 如果还有数据，重置到第一页
                                        CoachPagination.ActivePage = 1;
                                    }

                                    // 提示删除成功
                                    MessageBox.Show("教练删除成功！");
                                }
                                else
                                {
                                    // 提示删除失败
                                    MessageBox.Show("教练删除失败！");
                                }
                            }
                            catch (Exception ex)
                            {
                                // 发生异常时回滚事务
                                transaction.Rollback();
                                MessageBox.Show("删除操作失败: " + ex.Message);
                            }
                        }
                        connection.Close();
                    }
                }
                else
                {
                    // 提示索引超出范围
                    MessageBox.Show(string.Format("选中的行索引超出范围，请重新选择。"));
                }
            }
            else
            {
                // 提示没有选中的行
                MessageBox.Show("请先选择要删除的教练！");
            }
        }
        private void deleteCourse_Click(object sender, EventArgs e)
        {
            // 检查是否有选中的行
            if (CourseTable.SelectedIndex != -1)
            {
                // 获取选中的行索引
                int index = CourseTable.SelectedIndex - 1;

                // 确保索引在有效范围内
                if (index >= 0 && index < CoursePagination.TotalCount)
                {
                    // 获取选中行的数据
                    DataRow selectedRow = gmsDataSet.Tables["Course"].Rows[index + (CoursePagination.ActivePage - 1) * CoursePagination.PageSize];

                    // 获取用户名（或其他唯一标识）
                    string CourseId = selectedRow["课程号"].ToString();

                    // 创建 SqlConnection 对象并打开连接
                    using (SqlConnection connection = new SqlConnection(con))
                    {
                        connection.Open();

                        // 使用事务来确保数据一致性
                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                // 创建删除命令
                                string deleteQuery = @"DELETE FROM CourseInfo WHERE courseid = @CourseId;
                        DELETE FROM ReservationInfo WHERE courseid = @CourseId;
                        DELETE FROM Courses WHERE courseid = @CourseId;";

                                SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection, transaction);
                                deleteCommand.Parameters.AddWithValue("@CourseId", CourseId);

                                // 执行删除命令
                                int rowsAffected = deleteCommand.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    // 提交事务
                                    transaction.Commit();
                                    // 如果删除成功，从数据表中移除该行
                                    gmsDataSet.Tables["Course"].Rows.Remove(selectedRow);

                                    // 更新 DataGridView 的数据源
                                    CourseTable.DataSource = gmsDataSet.Tables["Course"];

                                    // 重新计算分页控件
                                    int totalRows = gmsDataSet.Tables["Course"].Rows.Count;
                                    CoursePagination.TotalCount = totalRows;

                                    // 如果删除后数据表为空，显示提示
                                    if (totalRows == 0)
                                    {
                                        CourseTable.DataSource = null; // 清空 DataGridView
                                        CoursePagination.ActivePage = 1; // 重置到第一页
                                    }
                                    else
                                    {
                                        // 如果还有数据，重置到第一页
                                        CoursePagination.ActivePage = 1;
                                    }

                                    // 提示删除成功
                                    MessageBox.Show("课程删除成功！");
                                }
                                else
                                {
                                    // 提示删除失败
                                    MessageBox.Show("课程删除失败！");
                                }
                            }
                            catch (Exception ex)
                            {
                                // 发生异常时回滚事务
                                transaction.Rollback();
                                MessageBox.Show("删除操作失败: " + ex.Message);
                            }
                        }
                        connection.Close();
                    }
                }
                else
                {
                    // 提示索引超出范围
                    MessageBox.Show(string.Format("选中的行索引超出范围，请重新选择。"));
                }
            }
            else
            {
                // 提示没有选中的行
                MessageBox.Show("请先选择要删除的课程！");
            }
        }
        private void AlterAdmin_Click(object sender, EventArgs e)
        {
            // 显式调用 EndEdit 方法，确保所有更改都已提交
            if (bindingSourceAdmin != null && bindingSourceAdmin.Count > 0)
            {
                for (int i = 0; i < bindingSourceAdmin.Count; i++)
                {
                    bindingSourceAdmin.Position = i;
                    if (bindingSourceAdmin.Current is DataRowView dataRowView)
                    {
                        DataRow row = dataRowView.Row;
                        if (row.RowState == DataRowState.Modified || row.RowState == DataRowState.Added)
                        {
                            row.EndEdit(); // 提交当前行的更改
                        }
                    }
                }
            }
            UpdateAdminValue();
            // 重新加载数据以反映更改
            showAdminInfo();
        }
        private void AlterUser_Click(object sender, EventArgs e)
        {
            // 显式调用 EndEdit 方法，确保所有更改都已提交
            if (bindingSourceUser != null && bindingSourceUser.Count > 0)
            {
                for (int i = 0; i < bindingSourceUser.Count; i++)
                {
                    bindingSourceUser.Position = i;
                    if (bindingSourceUser.Current is DataRowView dataRowView)
                    {
                        DataRow row = dataRowView.Row;
                        if (row.RowState == DataRowState.Modified || row.RowState == DataRowState.Added)
                        {
                            row.EndEdit(); // 提交当前行的更改
                        }
                    }
                }
            }
            UpdateUserValue();
            // 重新加载数据以反映更改
            showUserInfo();
        }
        private void AlterCoach_Click(object sender, EventArgs e)
        {
            // 显式调用 EndEdit 方法，确保所有更改都已提交
            if (bindingSourceCoach != null && bindingSourceCoach.Count > 0)
            {
                for (int i = 0; i < bindingSourceCoach.Count; i++)
                {
                    bindingSourceCoach.Position = i;
                    if (bindingSourceCoach.Current is DataRowView dataRowView)
                    {
                        DataRow row = dataRowView.Row;
                        if (row.RowState == DataRowState.Modified || row.RowState == DataRowState.Added)
                        {
                            row.EndEdit(); // 提交当前行的更改
                        }
                    }
                }
            }
            UpdateCoachValue();
            // 重新加载数据以反映更改
            showCoachInfo();
        }
        private void AlterCourse_Click(object sender, EventArgs e)
        {
            // 显式调用 EndEdit 方法，确保所有更改都已提交
            if (bindingSourceCourse != null && bindingSourceCourse.Count > 0)
            {
                for (int i = 0; i < bindingSourceCourse.Count; i++)
                {
                    bindingSourceCourse.Position = i;
                    if (bindingSourceCourse.Current is DataRowView dataRowView)
                    {
                        DataRow row = dataRowView.Row;
                        if (row.RowState == DataRowState.Modified || row.RowState == DataRowState.Added)
                        {
                            row.EndEdit(); // 提交当前行的更改
                        }
                    }
                }
            }
            UpdateCourseValue();
            // 重新加载数据以反映更改
            showCourseInfo();
        }
        private void AddAdmin_Click(object sender, EventArgs e)
        {
            AlterAdmin.Visible = false;
            deleteAdmin.Visible = false;
            VerityAddAdmin.Visible = true;
            //MessageBox.Show($"当前是第{uiPagination1.ActivePage}页,现在选中第{AdminTable.SelectedIndex}行，一共有{gmsDataSet.Tables["Admin"].Rows.Count}条数据");
            // 新增一行
            DataRow newRow = gmsDataSet.Tables["Admin"].NewRow();

            // 为新行设置值（如果需要）
            // 为新行设置初始值
            newRow["用户名"] = null; // 或者可以设置一个默认值，例如：newRow["用户名"] = "默认用户名";
            newRow["姓名"] = null;
            newRow["年龄"] = DBNull.Value; // 使用 DBNull.Value 表示数据库中的 NULL 值
            newRow["性别"] = null;
            newRow["手机号码"] = null;
            newRow["身份证"] = null;
            newRow["邮箱"] = null;
            newRow["出生日期"] = DBNull.Value;

            // 将新行添加到 DataTable
            gmsDataSet.Tables["Admin"].Rows.Add(newRow);

            // 提交当前编辑
            bindingSourceAdmin.EndEdit();

            // 接受更改
            gmsDataSet.Tables["Admin"].AcceptChanges();
            // 跳转到最后一页

            // 计算总页数
            int totalRows = gmsDataSet.Tables["Admin"].Rows.Count;
            // 设置总条目数
            uiPagination1.TotalCount = totalRows;
            int totalPages = (int)Math.Ceiling((double)totalRows / uiPagination1.PageSize);
            uiPagination1.ActivePage = totalPages;
            int startIndex = (totalPages - 1) * uiPagination1.PageSize;
            int endIndex = Math.Min(startIndex + uiPagination1.PageSize, totalRows);
            AdminTable.SelectedIndex = endIndex - startIndex;
            //MessageBox.Show($"当前是第{uiPagination1.ActivePage}页,现在选中第{AdminTable.SelectedIndex}行，一共有{totalRows}条数据,startIndex={startIndex},count={count}");
            uiPagination1.ActivePage = totalPages;
            MessageBox.Show("在新的一行填入新增管理员信息，并点击确认新增按钮");
            AdminTable.DataSource = uiPagination1.PageDataSource;
        }
        private void AddUser_Click(object sender, EventArgs e)
        {
            AlterUser.Visible = false;
            deleteUser.Visible = false;
            VerityAddUser.Visible = true;
            //MessageBox.Show($"当前是第{uiPagination1.ActivePage}页,现在选中第{AdminTable.SelectedIndex}行，一共有{gmsDataSet.Tables["Admin"].Rows.Count}条数据");
            // 新增一行
            DataRow newRow = gmsDataSet.Tables["User"].NewRow();

            // 为新行设置值（如果需要）
            // 为新行设置初始值
            newRow["用户名"] = null; // 或者可以设置一个默认值，例如：newRow["用户名"] = "默认用户名";
            newRow["姓名"] = null;
            newRow["年龄"] = DBNull.Value; // 使用 DBNull.Value 表示数据库中的 NULL 值
            newRow["性别"] = null;
            newRow["手机号码"] = null;
            newRow["身份证"] = null;
            newRow["邮箱"] = null;
            newRow["出生日期"] = DBNull.Value;

            // 将新行添加到 DataTable
            gmsDataSet.Tables["User"].Rows.Add(newRow);

            // 提交当前编辑
            bindingSourceUser.EndEdit();

            // 接受更改
            gmsDataSet.Tables["User"].AcceptChanges();
            // 跳转到最后一页

            // 计算总页数
            int totalRows = gmsDataSet.Tables["User"].Rows.Count;
            // 设置总条目数
            UserPagination.TotalCount = totalRows;
            int totalPages = (int)Math.Ceiling((double)totalRows / UserPagination.PageSize);
            UserPagination.ActivePage = totalPages;
            int startIndex = (totalPages - 1) * UserPagination.PageSize;
            int endIndex = Math.Min(startIndex + UserPagination.PageSize, totalRows);
            UserTable.SelectedIndex = endIndex - startIndex;
            //MessageBox.Show($"当前是第{uiPagination1.ActivePage}页,现在选中第{AdminTable.SelectedIndex}行，一共有{totalRows}条数据,startIndex={startIndex},count={count}");
            UserPagination.ActivePage = totalPages;
            MessageBox.Show("在新的一行填入新增用户信息，并点击确认新增按钮");
            UserTable.DataSource = UserPagination.PageDataSource;
        }
        private void AddCoach_Click(object sender, EventArgs e)
        {
            AlterCoach.Visible = false;
            deleteCoach.Visible = false;
            VerityAddCoach.Visible = true;
            //MessageBox.Show($"当前是第{uiPagination1.ActivePage}页,现在选中第{CoachTable.SelectedIndex}行，一共有{gmsDataSet.Tables["Coach"].Rows.Count}条数据");
            // 新增一行
            DataRow newRow = gmsDataSet.Tables["Coach"].NewRow();

            // 为新行设置值（如果需要）
            // 为新行设置初始值
            newRow["用户名"] = null; // 或者可以设置一个默认值，例如：newRow["用户名"] = "默认用户名";
            newRow["姓名"] = null;
            newRow["年龄"] = DBNull.Value; // 使用 DBNull.Value 表示数据库中的 NULL 值
            newRow["性别"] = null;
            newRow["手机号码"] = null;
            newRow["身份证"] = null;
            newRow["邮箱"] = null;
            newRow["出生日期"] = DBNull.Value;

            // 将新行添加到 DataTable
            gmsDataSet.Tables["Coach"].Rows.Add(newRow);

            // 提交当前编辑
            bindingSourceCoach.EndEdit();

            // 接受更改
            gmsDataSet.Tables["Coach"].AcceptChanges();
            // 跳转到最后一页

            // 计算总页数
            int totalRows = gmsDataSet.Tables["Coach"].Rows.Count;
            // 设置总条目数
            CoachPagination.TotalCount = totalRows;
            int totalPages = (int)Math.Ceiling((double)totalRows / CoachPagination.PageSize);
            CoachPagination.ActivePage = totalPages;
            int startIndex = (totalPages - 1) * CoachPagination.PageSize;
            int endIndex = Math.Min(startIndex + CoachPagination.PageSize, totalRows);
            CoachTable.SelectedIndex = endIndex - startIndex;
            //MessageBox.Show($"当前是第{CoachPagination.ActivePage}页,现在选中第{CoachTable.SelectedIndex}行，一共有{totalRows}条数据,startIndex={startIndex},count={count}");
            CoachPagination.ActivePage = totalPages;
            MessageBox.Show("在新的一行填入新增教练信息，并点击确认新增按钮");
            CoachTable.DataSource = CoachPagination.PageDataSource;
        }
        private void AddCourse_Click(object sender, EventArgs e)
        {
            // 隐藏其他按钮，显示确认新增按钮
            AlterCourse.Visible = false;
            deleteCourse.Visible = false;
            VerityAddCourse.Visible = true;

            // 新增一行
            DataRow newRow = gmsDataSet.Tables["Course"].NewRow();

            // 为新行设置初始值（可以设置默认值或留空）
            newRow["课程号"] = DBNull.Value;
            newRow["课程名称"] = null;
            newRow["教练"] = null;
            newRow["星期"] = null;
            newRow["上课时间"] = DBNull.Value;
            newRow["课程时长"] = DBNull.Value;
            newRow["最大学生数量"] = DBNull.Value;

            // 将新行添加到 DataTable
            gmsDataSet.Tables["Course"].Rows.Add(newRow);

            // 提交当前编辑
            bindingSourceCourse.EndEdit();

            // 接受更改
            gmsDataSet.Tables["Course"].AcceptChanges();

            // 计算总页数
            int totalRows = gmsDataSet.Tables["Course"].Rows.Count;
            CoursePagination.TotalCount = totalRows;
            int totalPages = (int)Math.Ceiling((double)totalRows / CoursePagination.PageSize);
            CoursePagination.ActivePage = totalPages;

            // 跳转到最后一页
            int startIndex = (totalPages - 1) * CoursePagination.PageSize;
            int endIndex = Math.Min(startIndex + CoursePagination.PageSize, totalRows);
            CourseTable.SelectedIndex = endIndex - startIndex;

            // 更新数据源
            CourseTable.DataSource = CoursePagination.PageDataSource;

            // 显示提示信息
            MessageBox.Show("在新的一行填入新增课程信息，并点击确认新增按钮");
        }
        private void UpdateAdminValue()
        {
            // 遍历所有的行
            foreach (DataRow row in gmsDataSet.Tables["Admin"].Rows)
            {
                if (row.RowState == DataRowState.Modified) // 检查行是否被修改
                {
                    string errorMessage = string.Empty;
                    // 获取用户输入
                    string oldid = (string)row["用户名", DataRowVersion.Original]; // 获取原始的 id
                    string id = row["用户名"] as string ?? string.Empty; // 用户名
                    string name = row["姓名"] as string ?? string.Empty; // 姓名
                    int age = (int)row["年龄"]; // 年龄
                    string sex = row["性别"] as string ?? string.Empty; // 性别
                    string phone = row["手机号码"] as string ?? string.Empty; // 手机号
                    string idCard = row["身份证"] as string ?? string.Empty; // 身份证号码
                    string email = row["邮箱"] as string ?? string.Empty; // 邮箱
                    string birthday = row["出生日期"] as string ?? string.Empty; // 出生日期
                    DateTime birthDate = DateTime.MinValue; // 初始化为最小值

                    // 检查输入是否为空，并显示具体的错误信息
                    if (string.IsNullOrEmpty(id))
                    {
                        errorMessage = "用户名不能为空！";
                    }
                    else if (id.Length > 20)
                    {
                        errorMessage = "用户名不能超过20个字符！";
                    }

                    string pattern = @"^[a-zA-Z0-9_]+$";

                    // 使用正则表达式进行匹配
                    if (!Regex.IsMatch(id, pattern))
                    {
                        errorMessage = "账号只能包含字母、数字和下划线！";
                    }

                    if (string.IsNullOrEmpty(phone))
                    {
                        errorMessage = "手机号不能为空！";
                    }
                    else if (phone.Length != 11)
                    {
                        errorMessage = "请输入合法的手机号！";
                    }

                    if (string.IsNullOrEmpty(name))
                    {
                        errorMessage = "姓名不能为空！";
                    }

                    // 获取并验证年龄
                    if (row["年龄"] is DBNull || !int.TryParse(row["年龄"].ToString(), out age))
                    {
                        errorMessage = "请输入有效的年龄！";
                    }
                    else if (age <= 0 || age > 120)
                    {
                        errorMessage = "年龄输入不切实际！";
                    }

                    if (string.IsNullOrEmpty(email))
                    {
                        errorMessage = "邮箱不能为空！";
                    }

                    if (string.IsNullOrEmpty(idCard))
                    {
                        errorMessage = "身份证信息不能为空！";
                    }
                    else if (idCard.Length != 18)
                    {
                        errorMessage = "请输入合法的身份证信息！";
                    }

                    // 检查年龄与出生日期的一致性
                    try
                    {
                        if (!DateTime.TryParseExact(birthday, "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate))
                        {
                            errorMessage = "请输入合法的出生日期！";
                        }
                        else
                        {
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
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessage = "出生日期解析失败: " + ex.Message;
                    }

                    // 如果有错误信息，则显示并跳过该行
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        MessageBox.Show($"修改用户名为{id}的信息出现错误: {errorMessage}");
                        continue;
                    }
                    // 更新数据库
                    UpdateDatabase(oldid, id, name, age, sex, phone, idCard, email, birthDate);
                }
            }
        }
        private void UpdateUserValue()
        {
            // 遍历所有的行
            foreach (DataRow row in gmsDataSet.Tables["User"].Rows)
            {
                if (row.RowState == DataRowState.Modified) // 检查行是否被修改
                {
                    string errorMessage = string.Empty;
                    // 获取用户输入
                    string oldid = (string)row["用户名", DataRowVersion.Original]; // 获取原始的 id
                    string id = row["用户名"] as string ?? string.Empty; // 用户名
                    string name = row["姓名"] as string ?? string.Empty; // 姓名
                    int age = (int)row["年龄"]; // 年龄
                    string sex = row["性别"] as string ?? string.Empty; // 性别
                    string phone = row["手机号码"] as string ?? string.Empty; // 手机号
                    string idCard = row["身份证"] as string ?? string.Empty; // 身份证号码
                    string email = row["邮箱"] as string ?? string.Empty; // 邮箱
                    string birthday = row["出生日期"] as string ?? string.Empty; // 出生日期
                    DateTime birthDate = DateTime.MinValue; // 初始化为最小值

                    // 检查输入是否为空，并显示具体的错误信息
                    if (string.IsNullOrEmpty(id))
                    {
                        errorMessage = "用户名不能为空！";
                    }
                    else if (id.Length > 20)
                    {
                        errorMessage = "用户名不能超过20个字符！";
                    }

                    string pattern = @"^[a-zA-Z0-9_]+$";

                    // 使用正则表达式进行匹配
                    if (!Regex.IsMatch(id, pattern))
                    {
                        errorMessage = "账号只能包含字母、数字和下划线！";
                    }

                    if (string.IsNullOrEmpty(phone))
                    {
                        errorMessage = "手机号不能为空！";
                    }
                    else if (phone.Length != 11)
                    {
                        errorMessage = "请输入合法的手机号！";
                    }

                    if (string.IsNullOrEmpty(name))
                    {
                        errorMessage = "姓名不能为空！";
                    }

                    // 获取并验证年龄
                    if (row["年龄"] is DBNull || !int.TryParse(row["年龄"].ToString(), out age))
                    {
                        errorMessage = "请输入有效的年龄！";
                    }
                    else if (age <= 0 || age > 120)
                    {
                        errorMessage = "年龄输入不切实际！";
                    }

                    if (string.IsNullOrEmpty(email))
                    {
                        errorMessage = "邮箱不能为空！";
                    }

                    if (string.IsNullOrEmpty(idCard))
                    {
                        errorMessage = "身份证信息不能为空！";
                    }
                    else if (idCard.Length != 18)
                    {
                        errorMessage = "请输入合法的身份证信息！";
                    }

                    // 检查年龄与出生日期的一致性
                    try
                    {
                        if (!DateTime.TryParseExact(birthday, "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate))
                        {
                            errorMessage = "请输入合法的出生日期！";
                        }
                        else
                        {
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
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessage = "出生日期解析失败: " + ex.Message;
                    }

                    // 如果有错误信息，则显示并跳过该行
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        MessageBox.Show($"修改用户名为{id}的信息出现错误: {errorMessage}");
                        continue;
                    }
                    // 更新数据库
                    UpdateDatabase(oldid, id, name, age, sex, phone, idCard, email, birthDate);
                }
            }
        }
        private void UpdateCoachValue()
        {
            // 遍历所有的行
            foreach (DataRow row in gmsDataSet.Tables["Coach"].Rows)
            {
                if (row.RowState == DataRowState.Modified) // 检查行是否被修改
                {
                    string errorMessage = string.Empty;
                    // 获取用户输入
                    string oldid = (string)row["用户名", DataRowVersion.Original]; // 获取原始的 id
                    string id = row["用户名"] as string ?? string.Empty; // 用户名
                    string name = row["姓名"] as string ?? string.Empty; // 姓名
                    int age = (int)row["年龄"]; // 年龄
                    string sex = row["性别"] as string ?? string.Empty; // 性别
                    string phone = row["手机号码"] as string ?? string.Empty; // 手机号
                    string idCard = row["身份证"] as string ?? string.Empty; // 身份证号码
                    string email = row["邮箱"] as string ?? string.Empty; // 邮箱
                    string birthday = row["出生日期"] as string ?? string.Empty; // 出生日期
                    DateTime birthDate = DateTime.MinValue; // 初始化为最小值

                    // 检查输入是否为空，并显示具体的错误信息
                    if (string.IsNullOrEmpty(id))
                    {
                        errorMessage = "用户名不能为空！";
                    }
                    else if (id.Length > 20)
                    {
                        errorMessage = "用户名不能超过20个字符！";
                    }

                    string pattern = @"^[a-zA-Z0-9_]+$";

                    // 使用正则表达式进行匹配
                    if (!Regex.IsMatch(id, pattern))
                    {
                        errorMessage = "账号只能包含字母、数字和下划线！";
                    }

                    if (string.IsNullOrEmpty(phone))
                    {
                        errorMessage = "手机号不能为空！";
                    }
                    else if (phone.Length != 11)
                    {
                        errorMessage = "请输入合法的手机号！";
                    }

                    if (string.IsNullOrEmpty(name))
                    {
                        errorMessage = "姓名不能为空！";
                    }

                    // 获取并验证年龄
                    if (row["年龄"] is DBNull || !int.TryParse(row["年龄"].ToString(), out age))
                    {
                        errorMessage = "请输入有效的年龄！";
                    }
                    else if (age <= 0 || age > 120)
                    {
                        errorMessage = "年龄输入不切实际！";
                    }

                    if (string.IsNullOrEmpty(email))
                    {
                        errorMessage = "邮箱不能为空！";
                    }

                    if (string.IsNullOrEmpty(idCard))
                    {
                        errorMessage = "身份证信息不能为空！";
                    }
                    else if (idCard.Length != 18)
                    {
                        errorMessage = "请输入合法的身份证信息！";
                    }

                    // 检查年龄与出生日期的一致性
                    try
                    {
                        if (!DateTime.TryParseExact(birthday, "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate))
                        {
                            errorMessage = "请输入合法的出生日期！";
                        }
                        else
                        {
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
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessage = "出生日期解析失败: " + ex.Message;
                    }

                    // 如果有错误信息，则显示并跳过该行
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        MessageBox.Show($"修改用户名为{id}的信息出现错误: {errorMessage}");
                        continue;
                    }
                    // 更新数据库
                    UpdateDatabase(oldid, id, name, age, sex, phone, idCard, email, birthDate);
                }
            }
        }
        private void UpdateCourseValue()
        {
            // 遍历所有的行
            foreach (DataRow row in gmsDataSet.Tables["Course"].Rows)
            {
                if (row.RowState == DataRowState.Modified) // 检查行是否被修改
                {
                    string errorMessage = string.Empty;

                    // 获取用户输入
                    int oldCourseId = (int)row["课程号", DataRowVersion.Original]; // 获取原始的 courseid
                    int newCourseId = (int)row["课程号"]; // 获取新的 courseid
                    string coursename = row["课程名称"] as string ?? string.Empty;
                    string coachid = row["教练"] as string ?? string.Empty;
                    string weekday = row["星期"] as string ?? string.Empty;
                    TimeSpan? startTime = row["上课时间"] as TimeSpan?;
                    int? durationHours = row["课程时长"] as int?;
                    int? maxStudent = row["最大学生数量"] as int?;

                    // 检查输入是否为空，并显示具体的错误信息
                    if (string.IsNullOrEmpty(coursename))
                    {
                        errorMessage = "课程名称不能为空！";
                    }

                    if (string.IsNullOrEmpty(coachid))
                    {
                        errorMessage = "教练ID不能为空！";
                    }

                    if (string.IsNullOrEmpty(weekday))
                    {
                        errorMessage = "星期不能为空！";
                    }

                    if (!startTime.HasValue)
                    {
                        errorMessage = "上课时间不能为空！";
                    }

                    if (!durationHours.HasValue || durationHours <= 0)
                    {
                        errorMessage = "课程时长必须大于0小时！";
                    }

                    if (!maxStudent.HasValue || maxStudent <= 0)
                    {
                        errorMessage = "最大学生数量必须大于0！";
                    }

                    // 如果有错误信息，则显示并跳过该行
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        MessageBox.Show($"修改课程ID为{oldCourseId}的信息出现错误: {errorMessage}");
                        continue;
                    }

                    // 更新数据库
                    UpdateCourseDatabase(oldCourseId, newCourseId, coursename, coachid, weekday, startTime.Value, durationHours.Value, maxStudent.Value);
                }
            }
        }
        private void UpdateDatabase(string oldId, string newId, string name, int age, string sex, string phone, string idCard, string email, DateTime birthday)
        {
            // 检查新ID是否为空
            if (string.IsNullOrEmpty(newId))
            {
                MessageBox.Show("新的用户ID不能为空！");
                return;
            }

            // 检查当前ID是否为空
            if (string.IsNullOrEmpty(oldId))
            {
                MessageBox.Show("当前用户ID不能为空！");
                return;
            }

            using (SqlConnection connection = new SqlConnection(con))
            {
                try
                {
                    connection.Open();

                    // 开始事务
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // 创建 SqlCommand 对象
                        SqlCommand command = new SqlCommand();
                        command.Connection = connection;
                        command.Transaction = transaction;

                        // 更新 Users 表中除 id 以外的信息
                        string updateQuery = "UPDATE Users SET name=@name, age=@age, sex=@sex, phone=@phone, IDcard=@idCard, email=@email, birthday=@birthday WHERE id=@oldId";
                        command.CommandText = updateQuery;
                        command.Parameters.AddWithValue("@oldId", oldId);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@age", age);
                        command.Parameters.AddWithValue("@sex", sex);
                        command.Parameters.AddWithValue("@phone", phone);
                        command.Parameters.AddWithValue("@idCard", idCard);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@birthday", birthday);
                        command.ExecuteNonQuery();
                        command.Parameters.Clear(); // 清空参数
                        MessageBox.Show("更新成功");

                        // 如果新的ID与旧的ID不同，则需要更新所有相关表
                        if (newId != oldId)
                        {
                            // 更新 Login 表
                            updateQuery = string.Format("UPDATE Login SET id='{0}' WHERE id='{1}'", newId, oldId);
                            command.CommandText = updateQuery;
                            command.ExecuteNonQuery();
                        }

                        // 提交事务
                        transaction.Commit();
                        MessageBox.Show($"修改用户名为{newId}的信息成功");
                    }
                    catch (Exception ex)
                    {
                        // 回滚事务
                        transaction.Rollback();
                        MessageBox.Show($"数据更新失败: {ex.Message}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"数据库连接错误: {ex.Message}");
                }
            }
        }
        private void UpdateCourseDatabase(int oldCourseId, int newCourseId, string coursename, string coachid, string weekday, TimeSpan startTime, int durationHours, int maxStudent)
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                try
                {
                    connection.Open();

                    // 开始事务
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // 创建 SqlCommand 对象
                        SqlCommand command = new SqlCommand();
                        command.Connection = connection;
                        command.Transaction = transaction;

                        // 更新 Courses 表中的信息
                        string updateQuery = @"
                    UPDATE Courses 
                    SET courseid = @NewCourseId, coursename = @Coursename, coachid = @Coachid, weekday = @Weekday, start_time = @StartTime, duration_hours = @DurationHours, maxstudent = @MaxStudent
                    WHERE courseid = @OldCourseId;";

                        command.CommandText = updateQuery;
                        command.Parameters.AddWithValue("@OldCourseId", oldCourseId);
                        command.Parameters.AddWithValue("@NewCourseId", newCourseId);
                        command.Parameters.AddWithValue("@Coursename", coursename);
                        command.Parameters.AddWithValue("@Coachid", coachid);
                        command.Parameters.AddWithValue("@Weekday", weekday);
                        command.Parameters.AddWithValue("@StartTime", startTime);
                        command.Parameters.AddWithValue("@DurationHours", durationHours);
                        command.Parameters.AddWithValue("@MaxStudent", maxStudent);

                        int n = command.ExecuteNonQuery();
                        command.Parameters.Clear(); // 清空参数

                        // 提交事务
                        transaction.Commit();
                        MessageBox.Show($"修改课程ID为{oldCourseId}的信息成功");

                    }
                    catch (Exception ex)
                    {
                        // 回滚事务
                        transaction.Rollback();
                        MessageBox.Show($"数据更新失败: {ex.Message}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"数据库连接错误: {ex.Message}");
                }
            }
        }
        private static bool TryGetValue<T>(object value, out T result)
        {
            if (value is DBNull)
            {
                result = default(T);
                return false;
            }

            if (value is T typedValue)
            {
                result = typedValue;
                return true;
            }

            try
            {
                result = (T)Convert.ChangeType(value, typeof(T));
                return true;
            }
            catch (InvalidCastException)
            {
                result = default(T);
                return false;
            }
            catch (FormatException)
            {
                result = default(T);
                return false;
            }
            catch (OverflowException)
            {
                result = default(T);
                return false;
            }
        }
        private bool CheckAdminInput(out string errorMessage)
        {
            DataRow row = gmsDataSet.Tables["Admin"].Rows[gmsDataSet.Tables["Admin"].Rows.Count - 1]; // 最后一行是新增的行
            // 获取用户输入
            string ID = row["用户名"] as string ?? string.Empty; // 用户名
            string name = row["姓名"] as string ?? string.Empty; // 姓名
            string sex = row["性别"] as string ?? string.Empty; // 性别
            string phone = row["手机号码"] as string ?? string.Empty; // 手机号
            string IDCard = row["身份证"] as string ?? string.Empty; // 身份证号码
            string email = row["邮箱"] as string ?? string.Empty; // 邮箱
            string birthday = row["出生日期"] as string ?? string.Empty; // 出生日期
            DateTime birthDate; // 初始化为最小值

            // 检查输入是否为空，并显示具体的错误信息
            if (string.IsNullOrEmpty(ID))
            {
                errorMessage = "用户名不能为空！";
                return false;
            }
            else if (ID.Length > 20)
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
            if (string.IsNullOrEmpty(name))
            {
                errorMessage = "姓名不能为空！";
                return false;
            }
            int age;
            if (!TryGetValue<int>(row["年龄"], out age))
            {
                errorMessage = "年龄必须为有效的整数！";
                return false;
            }
            if (age == null)
            {
                errorMessage = "请输入有效的年龄！";
                return false;
            }
            else if (age <= 0 || age > 120)
            {
                errorMessage = "年龄输入不切实际！";
                return false;
            }
            if (sex != "男" && sex != "女")
            {
                errorMessage = "性别输入有误！";
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
            if (string.IsNullOrEmpty(email))
            {
                errorMessage = "邮箱不能为空！";
                return false;
            }

            if (string.IsNullOrEmpty(IDCard))
            {
                errorMessage = "身份证信息不能为空！";
                return false;
            }
            else if (IDCard.Length != 18)
            {
                errorMessage = "请输入合法的身份证信息！";
                return false;
            }

            // 检查年龄与出生日期的一致性
            try
            {
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
            // 如果所有检查都通过
            errorMessage = null;
            return true;
        }
        private bool CheckUserInput(out string errorMessage)
        {
            DataRow row = gmsDataSet.Tables["User"].Rows[gmsDataSet.Tables["User"].Rows.Count - 1]; // 最后一行是新增的行
            // 获取用户输入
            string ID = row["用户名"] as string ?? string.Empty; // 用户名
            string name = row["姓名"] as string ?? string.Empty; // 姓名
            string sex = row["性别"] as string ?? string.Empty; // 性别
            string phone = row["手机号码"] as string ?? string.Empty; // 手机号
            string IDCard = row["身份证"] as string ?? string.Empty; // 身份证号码
            string email = row["邮箱"] as string ?? string.Empty; // 邮箱
            string birthday = row["出生日期"] as string ?? string.Empty; // 出生日期
            DateTime birthDate; // 初始化为最小值

            // 检查输入是否为空，并显示具体的错误信息
            if (string.IsNullOrEmpty(ID))
            {
                errorMessage = "用户名不能为空！";
                return false;
            }
            else if (ID.Length > 20)
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
            if (string.IsNullOrEmpty(name))
            {
                errorMessage = "姓名不能为空！";
                return false;
            }
            if (sex != "男" && sex != "女")
            {
                errorMessage = "性别输入有误！";
                return false;
            }
            int age;
            if (!TryGetValue<int>(row["年龄"], out age))
            {
                errorMessage = "年龄必须为有效的整数！";
                return false;
            }
            if (age == null)
            {
                errorMessage = "请输入有效的年龄！";
                return false;
            }
            else if (age <= 0 || age > 120)
            {
                errorMessage = "年龄输入不切实际！";
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
            if (string.IsNullOrEmpty(email))
            {
                errorMessage = "邮箱不能为空！";
                return false;
            }

            if (string.IsNullOrEmpty(IDCard))
            {
                errorMessage = "身份证信息不能为空！";
                return false;
            }
            else if (IDCard.Length != 18)
            {
                errorMessage = "请输入合法的身份证信息！";
                return false;
            }

            // 检查年龄与出生日期的一致性
            try
            {
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
            // 如果所有检查都通过
            errorMessage = null;
            return true;
        }
        private bool CheckCoachInput(out string errorMessage)
        {
            DataRow row = gmsDataSet.Tables["Coach"].Rows[gmsDataSet.Tables["Coach"].Rows.Count - 1]; // 最后一行是新增的行
            // 获取用户输入
            string ID = row["用户名"] as string ?? string.Empty; // 用户名
            string name = row["姓名"] as string ?? string.Empty; // 姓名
            string sex = row["性别"] as string ?? string.Empty; // 性别
            string phone = row["手机号码"] as string ?? string.Empty; // 手机号
            string IDCard = row["身份证"] as string ?? string.Empty; // 身份证号码
            string email = row["邮箱"] as string ?? string.Empty; // 邮箱
            string birthday = row["出生日期"] as string ?? string.Empty; // 出生日期
            DateTime birthDate; // 初始化为最小值

            // 检查输入是否为空，并显示具体的错误信息
            if (string.IsNullOrEmpty(ID))
            {
                errorMessage = "用户名不能为空！";
                return false;
            }
            else if (ID.Length > 20)
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
            if (string.IsNullOrEmpty(name))
            {
                errorMessage = "姓名不能为空！";
                return false;
            }
            if (sex != "男" && sex != "女")
            {
                errorMessage = "性别输入有误！";
                return false;
            }
            int age;
            if (!TryGetValue<int>(row["年龄"], out age))
            {
                errorMessage = "年龄必须为有效的整数！";
                return false;
            }
            if (age == null)
            {
                errorMessage = "请输入有效的年龄！";
                return false;
            }
            else if (age <= 0 || age > 120)
            {
                errorMessage = "年龄输入不切实际！";
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
            if (string.IsNullOrEmpty(email))
            {
                errorMessage = "邮箱不能为空！";
                return false;
            }

            if (string.IsNullOrEmpty(IDCard))
            {
                errorMessage = "身份证信息不能为空！";
                return false;
            }
            else if (IDCard.Length != 18)
            {
                errorMessage = "请输入合法的身份证信息！";
                return false;
            }

            // 检查年龄与出生日期的一致性
            try
            {
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
            // 如果所有检查都通过
            errorMessage = null;
            return true;
        }
        private void VerityAddAdmin_Click(object sender, EventArgs e)
        {
            // 调用 CheckInput 方法进行输入验证
            if (!CheckAdminInput(out string errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }
            DataRow row = gmsDataSet.Tables["Admin"].Rows[gmsDataSet.Tables["Admin"].Rows.Count - 1]; // 最后一行是新增的行
            string pwd = "123456";
            // 获取用户输入
            string id = row["用户名"] as string ?? string.Empty; // 用户名
            string name = row["姓名"] as string ?? string.Empty; // 姓名
            int age; // 年龄
            string ageStr = row["年龄"] as string ?? string.Empty; // 年龄
            string sex = row["性别"] as string ?? string.Empty; // 性别
            string phone = row["手机号码"] as string ?? string.Empty; // 手机号
            string idCard = row["身份证"] as string ?? string.Empty; // 身份证号码
            string email = row["邮箱"] as string ?? string.Empty; // 邮箱
            string birthday = row["出生日期"] as string ?? string.Empty; // 出生日期
            string usertype = "管理员";
            DateTime birthDate = DateTime.MinValue; // 初始化为最小值
            int.TryParse(ageStr, out age);

            using (SqlConnection connection = new SqlConnection(con))
            {

                // 开始事务
                SqlTransaction transaction = null;
                try
                {
                    connection.Open();

                    // 开始事务
                    transaction = connection.BeginTransaction();

                    // 检查账号是否已存在
                    SqlCommand cmdCheckID = new SqlCommand("SELECT COUNT(*) FROM Login WHERE id = @id", connection, transaction);
                    cmdCheckID.Parameters.AddWithValue("@id", id);

                    int accountCount = (int)cmdCheckID.ExecuteScalar();
                    if (accountCount > 0)
                    {
                        MessageBox.Show("新增失败，该账号已存在！");
                        transaction.Rollback();
                        return;
                    }

                    // 检查手机号是否已存在
                    SqlCommand cmdCheckPhone = new SqlCommand("SELECT COUNT(*) FROM Login WHERE phone = @Phone", connection, transaction);
                    cmdCheckPhone.Parameters.AddWithValue("@Phone", phone);

                    int phoneCount = (int)cmdCheckPhone.ExecuteScalar();
                    if (phoneCount > 0)
                    {
                        MessageBox.Show("新增失败，该手机号已存在！");
                        transaction.Rollback();
                        return;
                    }
                    SqlCommand cmdCheckIDcard= new SqlCommand("SELECT COUNT(*) FROM Users WHERE IDcard = @IDcard", connection, transaction);
                    cmdCheckIDcard.Parameters.AddWithValue("@IDcard", idCard);

                    int IDcardCount = (int)cmdCheckIDcard.ExecuteScalar();
                    if (IDcardCount > 0)
                    {
                        MessageBox.Show("新增失败，该身份证已存在！");
                        transaction.Rollback();
                        return;
                    }
                    SqlCommand cmdCheckemail = new SqlCommand("SELECT COUNT(*) FROM Users WHERE email = @email", connection, transaction);
                    cmdCheckemail.Parameters.AddWithValue("@email", email);

                    int emailCount = (int)cmdCheckemail.ExecuteScalar();
                    if (emailCount > 0)
                    {
                        MessageBox.Show("新增失败，该邮箱已存在！");
                        transaction.Rollback();
                        return;
                    }
                    // 插入新的登录记录
                    SqlCommand cmdInsertLogin = new SqlCommand(
                        "INSERT INTO Login(id, pwd, phone, usertype) VALUES(@id, @pwd, @phone, @usertype)",
                        connection, transaction);
                    cmdInsertLogin.Parameters.AddWithValue("@id", id);
                    cmdInsertLogin.Parameters.AddWithValue("@pwd", pwd);
                    cmdInsertLogin.Parameters.AddWithValue("@phone", phone);
                    cmdInsertLogin.Parameters.AddWithValue("@usertype", usertype);

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
                    cmdInsertUser.Parameters.AddWithValue("@IDcard", idCard);
                    cmdInsertUser.Parameters.AddWithValue("@phone", phone);
                    cmdInsertUser.Parameters.AddWithValue("@email", email);
                    cmdInsertUser.Parameters.AddWithValue("@id", id);

                    cmdInsertUser.ExecuteNonQuery();

                    // 提交事务
                    transaction.Commit();
                    MessageBox.Show("新增成功！");
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
            showAdminInfo();
            AlterAdmin.Visible = true;
            deleteAdmin.Visible = true;
            VerityAddAdmin.Visible = false;
        }
        private void VerityAddUser_Click(object sender, EventArgs e)
        {
            // 调用 CheckInput 方法进行输入验证
            if (!CheckUserInput(out string errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }
            DataRow row = gmsDataSet.Tables["User"].Rows[gmsDataSet.Tables["User"].Rows.Count - 1]; // 最后一行是新增的行
            string pwd = "123456";
            // 获取用户输入
            string id = row["用户名"] as string ?? string.Empty; // 用户名
            string name = row["姓名"] as string ?? string.Empty; // 姓名
            int age; // 年龄
            string ageStr = row["年龄"] as string ?? string.Empty; // 年龄
            string sex = row["性别"] as string ?? string.Empty; // 性别
            string phone = row["手机号码"] as string ?? string.Empty; // 手机号
            string idCard = row["身份证"] as string ?? string.Empty; // 身份证号码
            string email = row["邮箱"] as string ?? string.Empty; // 邮箱
            string birthday = row["出生日期"] as string ?? string.Empty; // 出生日期
            string usertype = "用户";
            DateTime birthDate = DateTime.MinValue; // 初始化为最小值
            int.TryParse(ageStr, out age);

            using (SqlConnection connection = new SqlConnection(con))
            {

                // 开始事务
                SqlTransaction transaction = null;
                try
                {
                    connection.Open();

                    // 开始事务
                    transaction = connection.BeginTransaction();

                    // 检查账号是否已存在
                    SqlCommand cmdCheckID = new SqlCommand("SELECT COUNT(*) FROM Login WHERE id = @id", connection, transaction);
                    cmdCheckID.Parameters.AddWithValue("@id", id);

                    int accountCount = (int)cmdCheckID.ExecuteScalar();
                    if (accountCount > 0)
                    {
                        MessageBox.Show("新增失败，该账号已存在！");
                        transaction.Rollback();
                        return;
                    }

                    // 检查手机号是否已存在
                    SqlCommand cmdCheckPhone = new SqlCommand("SELECT COUNT(*) FROM Login WHERE phone = @Phone", connection, transaction);
                    cmdCheckPhone.Parameters.AddWithValue("@Phone", phone);

                    int phoneCount = (int)cmdCheckPhone.ExecuteScalar();
                    if (phoneCount > 0)
                    {
                        MessageBox.Show("新增失败，该手机号已存在！");
                        transaction.Rollback();
                        return;
                    }
                    SqlCommand cmdCheckIDcard = new SqlCommand("SELECT COUNT(*) FROM Users WHERE IDcard = @IDcard", connection, transaction);
                    cmdCheckIDcard.Parameters.AddWithValue("@IDcard", idCard);

                    int IDcardCount = (int)cmdCheckIDcard.ExecuteScalar();
                    if (IDcardCount > 0)
                    {
                        MessageBox.Show("新增失败，该身份证已存在！");
                        transaction.Rollback();
                        return;
                    }
                    SqlCommand cmdCheckemail = new SqlCommand("SELECT COUNT(*) FROM Users WHERE email = @email", connection, transaction);
                    cmdCheckemail.Parameters.AddWithValue("@email", email);

                    int emailCount = (int)cmdCheckemail.ExecuteScalar();
                    if (emailCount > 0)
                    {
                        MessageBox.Show("新增失败，该邮箱已存在！");
                        transaction.Rollback();
                        return;
                    }
                    // 插入新的登录记录
                    SqlCommand cmdInsertLogin = new SqlCommand(
                        "INSERT INTO Login(id, pwd, phone, usertype) VALUES(@id, @pwd, @phone, @usertype)",
                        connection, transaction);
                    cmdInsertLogin.Parameters.AddWithValue("@id", id);
                    cmdInsertLogin.Parameters.AddWithValue("@pwd", pwd);
                    cmdInsertLogin.Parameters.AddWithValue("@phone", phone);
                    cmdInsertLogin.Parameters.AddWithValue("@usertype", usertype);

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
                    cmdInsertUser.Parameters.AddWithValue("@IDcard", idCard);
                    cmdInsertUser.Parameters.AddWithValue("@phone", phone);
                    cmdInsertUser.Parameters.AddWithValue("@email", email);
                    cmdInsertUser.Parameters.AddWithValue("@id", id);

                    cmdInsertUser.ExecuteNonQuery();

                    // 提交事务
                    transaction.Commit();
                    MessageBox.Show("新增成功！");
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
            showUserInfo();
            AlterUser.Visible = true;
            deleteUser.Visible = true;
            VerityAddUser.Visible = false;
        }
        private void VerityAddCoach_Click(object sender, EventArgs e)
        {
            // 调用 CheckInput 方法进行输入验证
            if (!CheckCoachInput(out string errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }
            DataRow row = gmsDataSet.Tables["Coach"].Rows[gmsDataSet.Tables["Coach"].Rows.Count - 1]; // 最后一行是新增的行
            string pwd = "123456";
            // 获取用户输入
            string id = row["用户名"] as string ?? string.Empty; // 用户名
            string name = row["姓名"] as string ?? string.Empty; // 姓名
            int age; // 年龄
            string ageStr = row["年龄"] as string ?? string.Empty; // 年龄
            string sex = row["性别"] as string ?? string.Empty; // 性别
            string phone = row["手机号码"] as string ?? string.Empty; // 手机号
            string idCard = row["身份证"] as string ?? string.Empty; // 身份证号码
            string email = row["邮箱"] as string ?? string.Empty; // 邮箱
            string birthday = row["出生日期"] as string ?? string.Empty; // 出生日期
            string usertype = "教练";
            DateTime birthDate = DateTime.MinValue; // 初始化为最小值
            int.TryParse(ageStr, out age);

            using (SqlConnection connection = new SqlConnection(con))
            {

                // 开始事务
                SqlTransaction transaction = null;
                try
                {
                    connection.Open();

                    // 开始事务
                    transaction = connection.BeginTransaction();

                    // 检查账号是否已存在
                    SqlCommand cmdCheckID = new SqlCommand("SELECT COUNT(*) FROM Login WHERE id = @id", connection, transaction);
                    cmdCheckID.Parameters.AddWithValue("@id", id);

                    int accountCount = (int)cmdCheckID.ExecuteScalar();
                    if (accountCount > 0)
                    {
                        MessageBox.Show("新增失败，该账号已存在！");
                        transaction.Rollback();
                        return;
                    }

                    // 检查手机号是否已存在
                    SqlCommand cmdCheckPhone = new SqlCommand("SELECT COUNT(*) FROM Login WHERE phone = @Phone", connection, transaction);
                    cmdCheckPhone.Parameters.AddWithValue("@Phone", phone);

                    int phoneCount = (int)cmdCheckPhone.ExecuteScalar();
                    if (phoneCount > 0)
                    {
                        MessageBox.Show("新增失败，该手机号已存在！");
                        transaction.Rollback();
                        return;
                    }
                    SqlCommand cmdCheckIDcard = new SqlCommand("SELECT COUNT(*) FROM Users WHERE IDcard = @IDcard", connection, transaction);
                    cmdCheckIDcard.Parameters.AddWithValue("@IDcard", idCard);

                    int IDcardCount = (int)cmdCheckIDcard.ExecuteScalar();
                    if (IDcardCount > 0)
                    {
                        MessageBox.Show("新增失败，该身份证已存在！");
                        transaction.Rollback();
                        return;
                    }
                    SqlCommand cmdCheckemail = new SqlCommand("SELECT COUNT(*) FROM Users WHERE email = @email", connection, transaction);
                    cmdCheckemail.Parameters.AddWithValue("@email", email);

                    int emailCount = (int)cmdCheckemail.ExecuteScalar();
                    if (emailCount > 0)
                    {
                        MessageBox.Show("新增失败，该邮箱已存在！");
                        transaction.Rollback();
                        return;
                    }
                    // 插入新的登录记录
                    SqlCommand cmdInsertLogin = new SqlCommand(
                        "INSERT INTO Login(id, pwd, phone, usertype) VALUES(@id, @pwd, @phone, @usertype)",
                        connection, transaction);
                    cmdInsertLogin.Parameters.AddWithValue("@id", id);
                    cmdInsertLogin.Parameters.AddWithValue("@pwd", pwd);
                    cmdInsertLogin.Parameters.AddWithValue("@phone", phone);
                    cmdInsertLogin.Parameters.AddWithValue("@usertype", usertype);

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
                    cmdInsertUser.Parameters.AddWithValue("@IDcard", idCard);
                    cmdInsertUser.Parameters.AddWithValue("@phone", phone);
                    cmdInsertUser.Parameters.AddWithValue("@email", email);
                    cmdInsertUser.Parameters.AddWithValue("@id", id);

                    cmdInsertUser.ExecuteNonQuery();

                    // 提交事务
                    transaction.Commit();
                    MessageBox.Show("新增成功！");
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
            showCoachInfo();
            AlterCoach.Visible = true;
            deleteCoach.Visible = true;
            VerityAddCoach.Visible = false;
        }
        private void VerityAddCourse_Click(object sender, EventArgs e)
        {
            DataRow row = gmsDataSet.Tables["Course"].Rows[gmsDataSet.Tables["Course"].Rows.Count - 1];
            // 获取最后一行（新增的行）
            string errorMessage = string.Empty;
            // 获取用户输入
            int courseid;
            if (!TryGetValue<int>(row["课程号"], out courseid))
            {
                errorMessage = "课程号必须为不为空的整数！";
            }
            string coursename = row["课程名称"] as string ?? string.Empty;
            string coachid = row["教练"] as string ?? string.Empty;
            string weekday = row["星期"] as string ?? string.Empty;
            // 检查输入是否为空，并显示具体的错误信息
            if (string.IsNullOrEmpty(coursename))
            {
                errorMessage = "课程名称不能为空！";
            }
            else if (coursename.Length > 50)
            {
                errorMessage = "课程名称不能超过50个字符！";
            }
            if (string.IsNullOrEmpty(coachid))
            {
                errorMessage = "教练ID不能为空！";
            }

            if (string.IsNullOrEmpty(weekday))
            {
                errorMessage = "星期不能为空！";
            }
            TimeSpan startTime;
            if (!TryGetValue<TimeSpan>(row["上课时间"], out startTime))
            {
                errorMessage = "上课时间必须为有效的时间格式！";
            }
            int durationHours;
            if (!TryGetValue<int>(row["课程时长"], out durationHours))
            {
                errorMessage = "课程时长为不为空的整数！";
            }
            int maxStudent;
            if (!TryGetValue<int>(row["最大学生数量"], out maxStudent))
            {
                errorMessage = "最大学生数量为不为空的整数！";
            }

            if (durationHours <= 0)
            {
                errorMessage = "课程时长必须大于0小时！";
            }

            if (maxStudent <= 0)
            {
                errorMessage = "最大学生数量必须大于0！";
            }

            // 如果有错误信息，则显示并跳过该行
            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show($"新增课程的信息有误: {errorMessage}");
                return;
            }

            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                // 开始事务
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {

                    // 检查账号是否已存在
                    SqlCommand cmdCheckcourseid = new SqlCommand("SELECT COUNT(*) FROM Courses WHERE courseid = @courseid", connection, transaction);
                    cmdCheckcourseid.Parameters.AddWithValue("@courseid", courseid);

                    int accountCount = (int)cmdCheckcourseid.ExecuteScalar();
                    if (accountCount > 0)
                    {
                        MessageBox.Show("新增失败，该课程号已存在！");
                        transaction.Rollback();
                        return;
                    }
                    // 检查账号是否已存在
                    SqlCommand cmdCheckcoach = new SqlCommand("SELECT COUNT(*) FROM Login WHERE id = @coachid AND usertype='教练'", connection, transaction);
                    cmdCheckcoach.Parameters.AddWithValue("@coachid", coachid);

                    int accountCount1 = (int)cmdCheckcoach.ExecuteScalar();
                    if (accountCount1 == 0)
                    {
                        MessageBox.Show("新增失败，不存在该教练！");
                        transaction.Rollback();
                        return;
                    }

                    // 创建 SqlCommand 对象
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.Transaction = transaction;

                    // 构建 SQL 插入语句
                    string insertQuery = "INSERT INTO Courses (courseid, coursename, coachid, weekday, start_time, duration_hours, maxstudent) " +
                                         "VALUES (@courseid, @coursename, @coachid, @weekday, @startTime, @durationHours, @maxStudent)";
                    command.CommandText = insertQuery;

                    // 添加参数
                    command.Parameters.AddWithValue("@courseid", courseid);
                    command.Parameters.AddWithValue("@coursename", coursename);
                    command.Parameters.AddWithValue("@coachid", coachid);
                    command.Parameters.AddWithValue("@weekday", weekday);
                    command.Parameters.AddWithValue("@startTime", startTime);
                    command.Parameters.AddWithValue("@durationHours", durationHours);
                    command.Parameters.AddWithValue("@maxStudent", maxStudent);

                    // 执行插入语句
                    command.ExecuteNonQuery();

                    // 提交事务
                    transaction.Commit();
                    MessageBox.Show($"新增课程ID为 {courseid} 的课程信息成功");

                }
                catch (Exception ex)
                {
                    // 回滚事务
                    transaction.Rollback();
                    MessageBox.Show($"新增课程失败: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }

            // 重新显示其他控件
            showCourseInfo();
            AlterCourse.Visible = true;
            deleteCourse.Visible = true;
            VerityAddCourse.Visible = false;
        }
        private void NotReseveCourse_Click(object sender, EventArgs e)
        {
            // 检查是否有选中的行
            if (ReserveTable.SelectedIndex != -1)
            {
                // 获取选中的行索引
                int index = ReserveTable.SelectedIndex - 1;

                // 确保索引在有效范围内
                if (index >= 0 && index < ReservePagination.TotalCount)
                {
                    // 获取选中行的数据
                    DataRow selectedRow = gmsDataSet.Tables["Reserve"].Rows[index];

                    // 提取“课程号”和“学生ID”
                    string courseId = selectedRow["课程号"].ToString();
                    string studentId = selectedRow["学生ID"].ToString();

                    // 创建 SqlConnection 对象并打开连接
                    using (SqlConnection connection = new SqlConnection(con))
                    {
                        connection.Open();

                        // 使用事务来确保数据一致性
                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                // 删除 ReservationInfo 中相应的记录
                                string deleteQuery = "DELETE FROM ReservationInfo WHERE courseid = @CourseId AND stuid = @StudentId;";
                                SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection, transaction);
                                deleteCommand.Parameters.AddWithValue("@CourseId", courseId);
                                deleteCommand.Parameters.AddWithValue("@StudentId", studentId);

                                // 执行删除命令
                                int rowsAffected = deleteCommand.ExecuteNonQuery();

                                // 提交事务
                                transaction.Commit();

                                // 检查是否删除成功
                                if (rowsAffected > 0)
                                {
                                    // 提示拒绝预约成功
                                    MessageBox.Show("已拒绝预约请求！");
                                }
                                else
                                {
                                    // 提示没有找到要删除的记录
                                    MessageBox.Show("未找到要拒绝的预约请求！");
                                }

                                // 更新 DataGridView 的数据源
                                showReserveInfo();
                            }
                            catch (Exception ex)
                            {
                                // 发生异常时回滚事务
                                transaction.Rollback();
                                MessageBox.Show("拒绝预约请求操作失败: " + ex.Message);
                            }
                        }
                    }
                }
                else
                {
                    // 提示索引超出范围
                    MessageBox.Show(string.Format("选中的行索引超出范围，请重新选择。"));
                }
            }
            else
            {
                // 提示没有选中的行
                MessageBox.Show("请先选择要拒绝的预约请求！");
            }
        }
        private void AgreeReseveCourse_Click(object sender, EventArgs e)
        {
            // 检查是否有选中的行
            if (ReserveTable.SelectedIndex != -1)
            {
                // 获取选中的行索引
                int index = ReserveTable.SelectedIndex - 1;

                // 确保索引在有效范围内
                if (index >= 0 && index < ReservePagination.TotalCount)
                {
                    // 获取选中行的数据
                    DataRow selectedRow = gmsDataSet.Tables["Reserve"].Rows[index];

                    // 获取“剩余可选人数”的值
                    int remainingSlots = Convert.ToInt32(selectedRow["剩余可选人数"]);

                    // 检查剩余可选人数是否大于0
                    if (remainingSlots <= 0)
                    {
                        MessageBox.Show("该课程人数已满，不可再选！");
                        return;
                    }

                    // 提取“课程号”和“学生ID”
                    string courseId = selectedRow["课程号"].ToString();
                    string studentId = selectedRow["学生ID"].ToString();

                    // 创建 SqlConnection 对象并打开连接
                    using (SqlConnection connection = new SqlConnection(con))
                    {
                        connection.Open();

                        // 使用事务来确保数据一致性
                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                // 在CourseInfo 表中添加一个记录
                                string insertQuery = "INSERT INTO CourseInfo (courseid, stuid) VALUES (@ReserveId, @StudentId);";
                                SqlCommand insertCommand = new SqlCommand(insertQuery, connection, transaction);
                                insertCommand.Parameters.AddWithValue("@ReserveId", courseId);
                                insertCommand.Parameters.AddWithValue("@StudentId", studentId);

                                // 执行插入命令
                                insertCommand.ExecuteNonQuery();

                                // 删除 ReservationInfo 中相应的记录
                                string deleteQuery = "DELETE FROM ReservationInfo WHERE courseid = @ReserveId AND stuid = @StudentId;";
                                SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection, transaction);
                                deleteCommand.Parameters.AddWithValue("@ReserveId", courseId);
                                deleteCommand.Parameters.AddWithValue("@StudentId", studentId);

                                // 执行删除命令
                                deleteCommand.ExecuteNonQuery();

                                // 提交事务
                                transaction.Commit();

                                // 提示预约成功
                                MessageBox.Show("已接受预约请求！");
                            }
                            catch (Exception ex)
                            {
                                // 发生异常时回滚事务
                                transaction.Rollback();
                                MessageBox.Show("接受预约请求操作失败: " + ex.Message);
                            }
                        }
                    }
                }
                else
                {
                    // 提示索引超出范围
                    MessageBox.Show(string.Format("选中的行索引超出范围，请重新选择。"));
                }
            }
            else
            {
                // 提示没有选中的行
                MessageBox.Show("请先选择要预约的课程！");
            }
            showReserveInfo();
        }
        private string ValidateInput(string id, string name, int age, string phone, string idCard, string email, DateTime birthDate)
        {
            string errorMessage = string.Empty;

            // 检查输入是否为空，并显示具体的错误信息
            if (string.IsNullOrEmpty(id))
            {
                errorMessage = "用户名不能为空！";
            }
            else if (id.Length > 20)
            {
                errorMessage = "用户名不能超过20个字符！";
            }

            string pattern = @"^[a-zA-Z0-9_]+$";

            // 使用正则表达式进行匹配
            if (!Regex.IsMatch(id, pattern))
            {
                errorMessage = "账号只能包含字母、数字和下划线！";
            }

            if (string.IsNullOrEmpty(phone))
            {
                errorMessage = "手机号不能为空！";
            }
            else if (phone.Length != 11)
            {
                errorMessage = "请输入合法的手机号！";
            }

            if (string.IsNullOrEmpty(name))
            {
                errorMessage = "姓名不能为空！";
            }

            // 验证年龄
            if (age <= 0 || age > 120)
            {
                errorMessage = "年龄输入不切实际！";
            }

            if (string.IsNullOrEmpty(email))
            {
                errorMessage = "邮箱不能为空！";
            }

            if (string.IsNullOrEmpty(idCard))
            {
                errorMessage = "身份证信息不能为空！";
            }
            else if (idCard.Length != 18)
            {
                errorMessage = "请输入合法的身份证信息！";
            }

            // 检查年龄与出生日期的一致性
            try
            {
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
                }
            }
            catch (Exception ex)
            {
                errorMessage = "出生日期解析失败: " + ex.Message;
            }

            return errorMessage;
        }
        private void beginalterinfo_Click(object sender, EventArgs e)
        {
            selfid.Enabled = true;
            selfname.Enabled = true;
            selfage.Enabled = true;
            male.Enabled = true;
            female.Enabled = true;
            selfphone.Enabled = true;
            selfIDcard.Enabled = true;
            selfbirthday.Enabled = true;
            selfemail.Enabled = true;
            selfid.BorderWidth = 1;
            selfname.BorderWidth=1; 
            selfage.BorderWidth=1;
            selfphone.BorderWidth=1;
            selfbirthday.BorderWidth=1;
            selfemail.BorderWidth=1;
            selfIDcard.BorderWidth=1;
            beginalterinfo.Visible = false;
            verityalterinfo.Visible = true;
            MessageBox.Show("修改信息后点击确认即可保存修改！");
        }
        private void verityalterinfo_Click(object sender, EventArgs e)
        {
            // 获取用户输入
            string id = Convert.ToString(selfid.Text.Trim());
            string name = selfname.Text.Trim();
            int age = (int)selfage.Value;
            string sex = male.Checked ? "男" : "女";
            string phone = selfphone.Text.Trim();
            string idCard = selfIDcard.Text.Trim();
            string email = selfemail.Text.Trim();
            DateTime birthDate = selfbirthday.Value ?? DateTime.Now; // 使用 null 合并运算符

            // 验证输入
            string errorMessage = ValidateInput(id, name, age, phone, idCard, email, birthDate);

            // 如果有错误信息，则显示并返回
            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show($"修改信息时出现错误: {errorMessage}");
                return;
            }

            // 更新数据库
            UpdateDatabase(this.thisid,id, name, age, sex, phone, idCard, email, birthDate);
            // 更新当前的 thisid
            this.thisid = id; // 确保在这里更新 this.thisid
            selfid.Enabled = false;
            selfname.Enabled = false;
            selfage.Enabled = false;
            male.Enabled = false;
            female.Enabled = false;
            selfphone.Enabled = false;
            selfIDcard.Enabled = false;
            selfbirthday.Enabled = false;
            selfemail.Enabled = false;
            selfid.BorderWidth = 0;
            selfname.BorderWidth = 0;
            selfage.BorderWidth = 0;
            selfphone.BorderWidth = 0;
            selfbirthday.BorderWidth = 01;
            selfemail.BorderWidth = 0;
            selfIDcard.BorderWidth = 0;
            beginalterinfo.Visible = true;
            verityalterinfo.Visible = false;
        }
        private void verityalterpwd_Click(object sender, EventArgs e)
        {
            // 获取用户输入并去除前后空白
            string originalPassword = originpwd.Text.Trim();
            string newPassword = newpwd.Text.Trim();
            string confirmPassword = veritynewpwd.Text.Trim();

            // 检查输入是否为空
            if (string.IsNullOrEmpty(originalPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("密码字段不能为空！");
                return;
            }

            // 检查新密码是否为6位数
            if (newPassword.Length != 6)
            {
                MessageBox.Show("新密码必须是6位数！");
                return;
            }

            // 检查新密码和确认新密码是否相同
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("两次输入的新密码不同！");
                return;
            }

            // 检查当前用户的原始密码是否与数据库中的密码匹配
            using (SqlConnection connection = new SqlConnection(con))
            {
                try
                {
                    connection.Open();

                    // 使用参数化查询来防止SQL注入
                    string query = "SELECT pwd FROM Login WHERE id = @thisid";
                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    sqlCommand.Parameters.AddWithValue("@thisid", this.thisid);

                    // 执行查询并读取结果
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string dbPassword = reader["pwd"].ToString();

                            // 检查原始密码是否正确
                            if (originalPassword == dbPassword)
                            {
                                // 更新密码
                                UpdatePassword(this.thisid, newPassword);
                                originpwd.Text = null;
                                newpwd.Text = null;
                                veritynewpwd.Text = null;
                                MessageBox.Show("密码修改成功！");
                            }
                            else
                            {
                                MessageBox.Show("原始密码错误！");
                            }
                        }
                        else
                        {
                            MessageBox.Show("未找到对应的用户信息。");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"发生错误: {ex.Message}");
                }
            }
        }
        private void UpdatePassword(string userId, string newPassword)
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                try
                {
                    connection.Open();

                    // 使用参数化查询来防止SQL注入
                    string updateQuery = "UPDATE Login SET pwd = @newPassword WHERE id = @userId";
                    SqlCommand sqlCommand = new SqlCommand(updateQuery, connection);
                    sqlCommand.Parameters.AddWithValue("@userId", userId);
                    sqlCommand.Parameters.AddWithValue("@newPassword", newPassword);

                    // 执行更新操作
                    int rowsAffected = sqlCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // 成功更新
                    }
                    else
                    {
                        // 更新失败
                        MessageBox.Show("密码更新失败，请检查输入的数据。");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"发生错误: {ex.Message}");
                }
            }
        }
    }
}
