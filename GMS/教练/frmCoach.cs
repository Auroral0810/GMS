using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMS.GMSdatasetTableAdapters;
using GMS.教练;
using Sunny.UI;
namespace GMS.教练
{
    public partial class frmCoach : Form
    {
        public string thisid= "00000000000202117559";
        //数据库连接字符串
        string con = DBconn.connstring;
        BindingSource bindingSourceCoach = new BindingSource();
        BindingSource bindingSourceCourse = new BindingSource();
        BindingSource bindingSourceCourseStu = new BindingSource();
        BindingSource bindingSourceRecord = new BindingSource();
        DataSet gmsDataSet = new DataSet();
        //SqlCommand sqlCommand;
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
        private Timer timer;
        public frmCoach()
        {
            // 设置样式以减少闪烁
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景
            SetStyle(ControlStyles.DoubleBuffer, true); // 启用双缓冲

            // 初始化组件
            InitializeComponent();
        }
        public frmCoach(string value, string logintype)
        {
            InitializeComponent();
            calendar1.Value = DateTime.Now;
            if (logintype == "Id")
            {
                thisid = value;
                //uiLinkLabel2.Text = value;
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
                            //uiLinkLabel2.Text = id1;
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
        private void CoursePagination2_ActivePageChanged(object sender, object pagingSource, int pageIndex, int count)
        {
            // 检查数据源是否为空
            if (gmsDataSet.Tables["CourseStu"] == null || gmsDataSet.Tables["CourseStu"].Rows.Count == 0)
            {
                return;
            }

            // 计算分页的起始索引和结束索引
            int startIndex = (pageIndex - 1) * count;
            int endIndex = Math.Min(startIndex + count, gmsDataSet.Tables["CourseStu"].Rows.Count);

            // 确保索引在有效范围内
            if (startIndex < 0 || endIndex > gmsDataSet.Tables["CourseStu"].Rows.Count)
            {
                MessageBox.Show("分页参数无效！");
                return;
            }
            CourseStuTable2.DataSource = CoursePagination2.PageDataSource;
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
                        Application.Exit();
                    }
                }
            }
        }
        public void showCourseInfo()
        {
            // 创建 SqlConnection 对象并打开连接
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                // 修改查询以包含剩余可选人数的计算
                string query = @"
            SELECT 
                c.courseid AS [课程号],
                c.coursename AS [课程名称],
                c.weekday AS [星期],
                c.start_time AS [上课时间],
                c.duration_hours AS [课程时长],
                c.maxstudent AS [最大学生数量],
                (c.maxstudent - ISNULL((SELECT COUNT(*) FROM CourseInfo ci WHERE ci.courseid = c.courseid), 0)) AS [剩余可选人数]
            FROM 
                Courses c
            WHERE 
                c.coachid = @thisid
            ORDER BY 
                c.courseid;";

                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@thisid", this.thisid);

                SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

                // 确保数据集中有一个名为 Course 的 DataTable
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
            }

            // 获取所有不同的 coursename 并添加到 CourseName 下拉列表
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                // 查询 Courses 表中所有不同的 coursename，并按字典序排序
                string distinctQuery = "SELECT DISTINCT coursename FROM Courses where coachid = @thisid ORDER BY coursename";
                SqlCommand distinctCommand = new SqlCommand(distinctQuery, connection);
                distinctCommand.Parameters.AddWithValue("@thisid", this.thisid);
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
        public void showCourseStuInfo()
        {
            // 创建 SqlConnection 对象并打开连接
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                // 修改查询以包含剩余可选人数的计算，并获取学生信息
                string query = @"
            SELECT 
                c.courseid AS [课程号],
                c.coursename AS [课程名称],
                u.id AS [学生用户名],
                u.name AS [学生姓名],
                u.sex AS [性别],
                u.email AS [邮箱],
                u.phone AS [电话],
                c.weekday AS [星期]
            FROM 
                Courses c
            INNER JOIN 
                CourseInfo ci ON c.courseid = ci.courseid
            INNER JOIN 
                Users u ON ci.stuid = u.id
            WHERE 
                c.coachid = @thisid
            ORDER BY 
                c.courseid, u.name;";

                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@thisid", this.thisid);

                SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

                // 确保数据集中有一个名为 CourseStu 的 DataTable
                if (gmsDataSet.Tables["CourseStu"] == null)
                {
                    // 如果不存在，则创建一个新的 DataTable
                    DataTable CourseStuTable2 = new DataTable("CourseStu");
                    gmsDataSet.Tables.Add(CourseStuTable2);
                }

                gmsDataSet.Tables["CourseStu"].Rows.Clear();

                // 使用 TableAdapter 填充数据集
                sqlData.Fill(gmsDataSet.Tables["CourseStu"]);

                // 设置 BindingSource 的 DataSource
                bindingSourceCourseStu.DataSource = gmsDataSet.Tables["CourseStu"];

                // 计算总页数
                int totalRows = gmsDataSet.Tables["CourseStu"].Rows.Count;
                int pageCount = (int)Math.Ceiling((double)totalRows / CoursePagination2.PageSize);

                // 设置总条目数
                CoursePagination2.TotalCount = totalRows;

                // 设置数据源
                CoursePagination2.DataSource = bindingSourceCourseStu;

                // 设置初始页码
                CoursePagination2.ActivePage = 1;

                // 如果分页控件有 PageDataSource，则设置 AdminTable 和 AdminData 的 DataSource
                if (CoursePagination2.PageDataSource != null)
                {
                    CourseStuTable2.DataSource = CoursePagination2.PageDataSource;
                    // 添加 Binding 到 pagination1 控件

                    //AdminData.DataSource = uiPagination1.PageDataSource;
                }
            }

            // 获取所有不同的 coursename 并添加到 CourseName 下拉列表
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                // 查询 Courses 表中所有不同的 coursename，并按字典序排序
                string distinctQuery = "SELECT DISTINCT coursename FROM Courses where coachid = @thisid ORDER BY coursename";
                SqlCommand distinctCommand = new SqlCommand(distinctQuery, connection);
                distinctCommand.Parameters.AddWithValue("@thisid", this.thisid);
                using (SqlDataReader reader = distinctCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string coursename = reader.GetString(0);
                        CourseName2.Items.Add(coursename);
                    }
                }
            }
        }
        public void showFitnessRecords()
        {
            // 创建 SqlConnection 对象并打开连接
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                // 查询 UserRecord 表中的信息，并根据 courseid 在 Courses 表中查找课程名称
                string query = @"
            SELECT 
                ur.courseid AS [课程号],
                c.coursename AS [课程名称],
                ur.userid AS [学生账号],
                u.name AS [学生名],
                c.weekday AS [星期],
                ur.rank AS [分数],
                ur.addtime AS [添加时间]
            FROM 
                UserRecord ur
            INNER JOIN 
                Courses c ON ur.courseid = c.courseid
            INNER JOIN
                Users u ON ur.userid = u.id
            WHERE 
                ur.coachid = @thisid";

                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@thisid", thisid);

                SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

                // 确保数据集中有一个名为 Record 的 DataTable
                if (gmsDataSet.Tables["Record"] == null)
                {
                    // 如果不存在，则创建一个新的 DataTable
                    DataTable fitnessRecordsTable = new DataTable("Record");
                    gmsDataSet.Tables.Add(fitnessRecordsTable);
                }

                // 清除现有的行
                gmsDataSet.Tables["Record"].Rows.Clear();

                // 使用 TableAdapter 填充数据集
                sqlData.Fill(gmsDataSet.Tables["Record"]);

                // 设置 BindingSource 的 DataSource
                bindingSourceRecord.DataSource = gmsDataSet.Tables["Record"];

                // 计算总页数
                int totalRows = gmsDataSet.Tables["Record"].Rows.Count;
                int pageCount = (int)Math.Ceiling((double)totalRows / RecordPagination.PageSize);

                // 设置总条目数
                RecordPagination.TotalCount = totalRows;

                // 设置数据源
                RecordPagination.DataSource = bindingSourceRecord;

                // 设置初始页码
                RecordPagination.ActivePage = 1;

                // 如果分页控件有 PageDataSource，则设置 AdminTable 和 AdminData 的 DataSource
                if (RecordPagination.PageDataSource != null)
                {
                    RecordTable.DataSource = RecordPagination.PageDataSource;
                    // 添加 Binding 到 pagination1 控件

                    //AdminData.DataSource = uiPagination1.PageDataSource;
                }
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
                        CourseName3.Items.Add(coursename);
                    }
                }
            }
        }
        public void viewBarChart()
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
            where coachid = @thisid
            GROUP BY 
                weekday";

                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@thisid", this.thisid);
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
                    Text = "一周课程数量总览", // 主标题
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
                option.YAxis.Name = null;

                // 更新配置
                CoachfrmBarChart.SetOption(option);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发生错误: {ex.Message}");
            }
        }
        public void viewDoughnutChart()
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

                // 查询语句：选择符合条件的学生的年龄
                string query = @"
            SELECT u.age
            FROM Courses c
            INNER JOIN CourseInfo ci ON c.courseid = ci.courseid
            INNER JOIN Users u ON ci.stuid = u.id
            WHERE c.coachid = @thisid";

                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@thisid", this.thisid);

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
            }

            // 设置饼状图选项
            UIDoughnutOption userDoughnutOption = new UIDoughnutOption();
            userDoughnutOption.ToolTip.Visible = true;
            userDoughnutOption.Title = new UITitle { Text = "学员年龄情况" };

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
            CoachfrmDoughnutChart.SetOption(userDoughnutOption);
        }
        public void viewpieChart()
        {
            int male = 0;
            int female = 0;

            // 创建 SqlConnection 对象并打开连接
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                // 查询语句：选择符合条件的学生的性别
                string query = @"
            SELECT u.sex
            FROM Courses c
            INNER JOIN CourseInfo ci ON c.courseid = ci.courseid
            INNER JOIN Users u ON ci.stuid = u.id
            WHERE c.coachid = @thisid";

                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@thisid", this.thisid);

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
            }

            try
            {
                // 配置参数
                UIPieOption option = new UIPieOption(); // 假设使用的是饼状图选项类

                // 配置标题
                option.Title = new UITitle
                {
                    Text = "学员性别情况", // 主标题
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
                UIPieSeries series = new UIPieSeries
                {
                    Name = "人数"
                };

                // 添加数据到系列
                series.AddData("男性", male);
                series.AddData("女性", female);

                // 将系列添加到选项中
                option.Series.Add(series);

                // 辅助ToolTip是否可见
                option.ToolTip.Visible = true;

                // 更新配置
                CoachfrmPieChart.SetOption(option); // 假设这是设置饼状图选项的方法
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发生错误: {ex.Message}");
            }
        }
        public void viewLineChart11()
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
            WHERE 
                coachid = @thisid
            GROUP BY 
                weekday";

                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@thisid", this.thisid);

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
            FROM Courses
            WHERE coachid = @thisid";

                SqlCommand allCourseIdsCommand = new SqlCommand(allCourseIdsQuery, connection);
                allCourseIdsCommand.Parameters.AddWithValue("@thisid", this.thisid);
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
                UILineOption option = new UILineOption();

                // 设置工具提示
                option.ToolTip.Visible = true;

                // 设置标题
                option.Title = new UITitle
                {
                    Text = "课堂填充率",
                };

                // 横坐标数据类型
                option.XAxisType = UIAxisType.Category;

                // 设置横坐标数据
                option.XAxis.Data.Add("周一");
                option.XAxis.Data.Add("周二");
                option.XAxis.Data.Add("周三");
                option.XAxis.Data.Add("周四");
                option.XAxis.Data.Add("周五");
                option.XAxis.Data.Add("周六");
                option.XAxis.Data.Add("周日");

                // 设置系列
                var series = option.AddSeries(new UILineSeries("课堂填充率"));

                // 添加数据到系列
                series.Add("周一", mondayFillRate * 100); // 将课堂填充率转换为百分比
                series.Add("周二", tuesdayFillRate * 100);
                series.Add("周三", wednesdayFillRate * 100);
                series.Add("周四", thursdayFillRate * 100);
                series.Add("周五", fridayFillRate * 100);
                series.Add("周六", saturdayFillRate * 100);
                series.Add("周日", sundayFillRate * 100);

                // 点的图标
                series.Symbol = UILinePointSymbol.Square;
                // 图标大小
                series.SymbolSize = 4;
                // 折线宽度
                series.SymbolLineWidth = 2;
                // 图标颜色
                series.SymbolColor = Color.Red;

                // 平滑曲线
                series.Smooth = true;

                // 设置纵坐标上限红线
                option.GreaterWarningArea = new UILineWarningArea( 100); // 假设100%为上限
                                                                       // 设置纵坐标下限黄线
                option.LessWarningArea = new UILineWarningArea(20, Color.Red); // 假设20%为下限

                option.YAxisScaleLines.Add(new UIScaleLine() { Color = Color.Green, Name = "上限", Value = 100 });
                option.YAxisScaleLines.Add(new UIScaleLine() { Color = Color.Red, Name = "下限", Value = 20 });

                // 更新配置
                CoachfrmLineChart.SetOption(option); 
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
                CourseT.SelectTab(0);
            }
            if (menu.Items[1].Select)
            {
                showselfinfo();
                CourseT.SelectTab(1);
            }
            if (menu.Items[2].Select)
            {

                if (menu.Items[2].Sub[0].Select )
                {
                    showCourseInfo();
                    CourseT.SelectTab(2);
                }
                else if (menu.Items[2].Sub[1].Select)
                {
                    showCourseStuInfo();
                    CourseT.SelectTab(3);
                }
            }
            if (menu.Items[3].Select)
            {
                showFitnessRecords();
                CourseT.SelectTab(4);
            }
            if (menu.Items[4].Select)
            {
                viewBarChart();
                viewDoughnutChart();
                viewpieChart();
                viewLineChart11();
                CourseT.SelectTab(5);
            }
            if (menu.Items[5].Select)
            {
                CourseT.SelectTab(6);
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
        private void button2_Click(object sender, EventArgs e)
        {
            // 显示一个消息框，询问用户是否要退出程序
            DialogResult result = MessageBox.Show(
                "确认退出系统？？",
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
        private void frmCoach_Load(object sender, EventArgs e)
        {
            // 获取当前日期
            DateTime today = DateTime.Now;
            string greeting = "";

            // 判断当前时间段
            if (today.Hour >= 5 && today.Hour < 12)
            {
                // 早上
                greeting = "早上好，教练";
            }
            else if (today.Hour >= 11 && today.Hour < 13)
            {
                // 中午
                greeting = "中午好，教练";
            }
            else if (today.Hour >= 13 && today.Hour < 18)
            {
                // 下午
                greeting = "下午好，教练";
            }
            else if (today.Hour >= 18 && today.Hour < 22)
            {
                // 晚上
                greeting = "晚上好，教练";
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
            selfname.BorderWidth = 1;
            selfage.BorderWidth = 1;
            selfphone.BorderWidth = 1;
            selfbirthday.BorderWidth = 1;
            selfemail.BorderWidth = 1;
            selfIDcard.BorderWidth = 1;
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
            UpdateDatabase(this.thisid, id, name, age, sex, phone, idCard, email, birthDate);
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
        private void zhuxiaobtn_Click(object sender, EventArgs e)
        {
            // 检查 thisid 是否为空
            if (string.IsNullOrEmpty(this.thisid))
            {
                MessageBox.Show("用户ID不能为空！");
                return;
            }

            // 显示确认提示框
            DialogResult result = MessageBox.Show("您确定要注销吗？此操作不可逆。", "确认注销", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // 如果用户点击“是”
            if (result == DialogResult.Yes)
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
                            // 获取需要删除的 courseid 列表
                            List<string> courseIdsToDelete = GetCourseIdsToDelete(connection, this.thisid, transaction);

                            // 删除 CourseInfo 表中对应 courseid 的数据
                            foreach (string courseId in courseIdsToDelete)
                            {
                                DeleteFromTable(connection, "CourseInfo", "courseid", courseId, transaction);
                            }
                            // 删除 ReservationInfo 表中对应 courseid 的数据
                            foreach (string courseId in courseIdsToDelete)
                            {
                                DeleteFromTable(connection, "ReservationInfo", "courseid", courseId, transaction);
                            }
                            // 删除 Courses 表中 coachid 等于 thisid 的数据
                            DeleteFromTable(connection, "Courses", "coachid", this.thisid, transaction);

                            // 删除 Users 表中 id 等于 thisid 的数据
                            DeleteFromTable(connection, "Users", "id", this.thisid, transaction);
                            DeleteFromTable(connection, "Login", "id", this.thisid, transaction);

                            // 提交事务
                            transaction.Commit();
                            MessageBox.Show("注销成功！即将退出系统……");
                            Application.Exit();
                        }
                        catch (Exception ex)
                        {
                            // 回滚事务
                            transaction.Rollback();
                            MessageBox.Show($"发生错误: {ex.Message}");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"数据库连接错误: {ex.Message}");
                    }
                }
            }
            else
            {
                // 用户点击“否”，取消操作
                MessageBox.Show("注销已取消。");
            }
        }
        private List<string> GetCourseIdsToDelete(SqlConnection connection, string thisid, SqlTransaction transaction)
        {
            List<string> courseIds = new List<string>();

            // 使用参数化查询来防止SQL注入
            string query = "SELECT courseid FROM Courses WHERE coachid = @thisid";
            SqlCommand sqlCommand = new SqlCommand(query, connection, transaction);
            sqlCommand.Parameters.AddWithValue("@thisid", thisid);

            // 执行查询并读取结果
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    courseIds.Add(reader["courseid"].ToString());
                }
            }

            return courseIds;
        }
        private void DeleteFromTable(SqlConnection connection, string tableName, string columnName, string value, SqlTransaction transaction)
        {
            // 使用参数化查询来防止SQL注入
            string deleteQuery = $"DELETE FROM {tableName} WHERE {columnName} = @value";
            SqlCommand sqlCommand = new SqlCommand(deleteQuery, connection, transaction);
            sqlCommand.Parameters.AddWithValue("@value", value);

            // 执行删除操作
            int rowsAffected = sqlCommand.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                // 成功删除
            }
            else
            {
                // 删除失败
                throw new Exception($"删除 {tableName} 表中 {columnName} 为 {value} 的数据失败。");
            }
        }
        private void SearchCourse_Click(object sender, EventArgs e)
        {
            // 创建 SqlConnection 对象并打开连接
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                string query = @"
            SELECT 
                c.courseid AS [课程号],
                c.coursename AS [课程名称],
                c.weekday AS [星期],
                c.start_time AS [上课时间],
                c.duration_hours AS [课程时长],
                c.maxstudent AS [最大学生数量],
                (c.maxstudent - ISNULL((SELECT COUNT(*) FROM CourseInfo ci WHERE ci.courseid = c.courseid), 0)) AS [剩余可选人数]
            FROM 
                Courses c
            WHERE 
                c.coachid = @thisid";

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
                query += " ORDER BY c.courseid ASC";
                // 创建 SqlCommand 对象
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@thisid",this.thisid);
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
        private void SearchCourse2_Click(object sender, EventArgs e)
        {
            // 创建 SqlConnection 对象并打开连接
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                // 基础查询
                string query = @"
            SELECT 
                c.courseid AS [课程号],
                c.coursename AS [课程名称],
                u.id AS [学生用户名],
                u.name AS [学生姓名],
                u.sex AS [性别],
                u.email AS [邮箱],
                u.phone AS [电话],
                c.weekday AS [星期]
            FROM 
                Courses c
            INNER JOIN 
                CourseInfo ci ON c.courseid = ci.courseid
            INNER JOIN 
                Users u ON ci.stuid = u.id
            WHERE 
                c.coachid = @thisid";

                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@thisid", this.thisid);

                // 添加搜索条件
                List<string> conditions = new List<string>();
                List<SqlParameter> parameters = new List<SqlParameter>();

                if (!string.IsNullOrEmpty(CourseName2.Text.Trim()))
                {
                    conditions.Add("c.coursename = @CourseName");
                    parameters.Add(new SqlParameter("@CourseName", CourseName2.Text.Trim()));
                }

                if (!string.IsNullOrEmpty(CourseStuName.Text.Trim()))
                {
                    
                    conditions.Add("u.name like @CourseStuName");
                    parameters.Add(new SqlParameter("@CourseStuName", "%" + CourseStuName.Text.Trim() + "%"));
                }

                if (!string.IsNullOrEmpty(dayofweek2.Text.Trim()))
                {
                    conditions.Add("c.weekday = @dayofweek");
                    parameters.Add(new SqlParameter("@dayofweek", dayofweek2.Text.Trim()));
                }

                if (conditions.Count > 0)
                {
                    // 如果有搜索条件，将它们添加到 WHERE 子句中
                    query += " AND (" + string.Join(" AND ", conditions) + ")";
                }

                // 添加 ORDER BY 子句
                query += " ORDER BY c.courseid ASC";

                // 重新创建 SqlCommand 对象
                sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@thisid", this.thisid);

                // 添加参数
                foreach (var param in parameters)
                {
                    sqlCommand.Parameters.Add(param);
                }

                // 使用 SqlCommand 创建 SqlDataAdapter
                SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

                // 确保数据集中有一个名为 CourseStu 的 DataTable
                if (gmsDataSet.Tables["CourseStu"] == null)
                {
                    // 如果不存在，则创建一个新的 DataTable
                    DataTable CourseStuTable2 = new DataTable("CourseStu");
                    gmsDataSet.Tables.Add(CourseStuTable2);
                }
                else
                {
                    // 清除现有数据
                    gmsDataSet.Tables["CourseStu"].Rows.Clear();
                }

                // 使用 SqlDataAdapter 填充数据集中的 CourseStu 表
                int rowsAffected = sqlData.Fill(gmsDataSet.Tables["CourseStu"]);

                // 设置 BindingSource 的 DataSource
                bindingSourceCourseStu.DataSource = gmsDataSet.Tables["CourseStu"];

                // 检查是否找到了数据
                if (rowsAffected == 0)
                {
                    // 清空 CourseStuTable2 的数据源
                    CourseStuTable2.DataSource = null;

                    // 重置分页控件
                    CoursePagination2.TotalCount = 0;
                    CoursePagination2.ActivePage = 1;
                }
                else
                {
                    // 计算总页数
                    int totalRows = gmsDataSet.Tables["CourseStu"].Rows.Count;
                    int pageCount = (int)Math.Ceiling((double)totalRows / CoursePagination2.PageSize);

                    // 设置总条目数
                    CoursePagination2.TotalCount = totalRows;

                    // 设置数据源
                    CoursePagination2.DataSource = bindingSourceCourseStu;

                    // 设置初始页码
                    CoursePagination2.ActivePage = 1;

                    // 如果分页控件有 PageDataSource，则设置 CourseStuTable2 的 DataSource
                    if (CoursePagination2.PageDataSource != null)
                    {
                        CourseStuTable2.DataSource = CoursePagination2.PageDataSource;
                    }
                }
            }
        }
        private void searchRecordCoach_Click(object sender, EventArgs e)
        {
            // 创建 SqlConnection 对象并打开连接
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                // 基础查询
                string query = @"
            SELECT 
                ur.courseid AS [课程号],
                c.coursename AS [课程名称],
                ur.userid AS [学生账号],
                u.name AS [学生名],
                c.weekday AS [星期],
                ur.rank AS [分数],
                ur.addtime AS [添加时间]
            FROM 
                UserRecord ur
            INNER JOIN 
                Courses c ON ur.courseid = c.courseid
            INNER JOIN
                Users u ON ur.userid = u.id
            WHERE 
                ur.coachid = @thisid";

                // 添加搜索条件
                List<string> conditions = new List<string>();
                List<SqlParameter> parameters = new List<SqlParameter>();

                if (!string.IsNullOrEmpty(CourseName3.Text.Trim()))
                {
                    conditions.Add("c.coursename LIKE @CourseName3");
                    parameters.Add(new SqlParameter("@CourseName3", "%" + CourseName3.Text.Trim() + "%"));
                }

                if (!string.IsNullOrEmpty(UserName3.Text.Trim()))
                {
                    conditions.Add("ur.userid LIKE @UserName3");
                    parameters.Add(new SqlParameter("@UserName3", "%" + UserName3.Text.Trim() + "%"));
                }

                if (CourseTime3.Value.HasValue) // 检查是否有值
                {
                    DateTime addTime = CourseTime3.Value.Value; // 获取实际的 DateTime 值
                                                                // 比较 addtime 的日期部分
                    conditions.Add("CONVERT(date, ur.addtime) = @CourseTime3");
                    parameters.Add(new SqlParameter("@CourseTime3", addTime.Date));
                }

                if (!string.IsNullOrEmpty(dayofweek3.Text.Trim()))
                {
                    conditions.Add("c.weekday = @dayofweek3");
                    parameters.Add(new SqlParameter("@dayofweek3", dayofweek3.Text.Trim()));
                }

                // 如果有搜索条件，将它们添加到 WHERE 子句中
                if (conditions.Count > 0)
                {
                    query += " AND " + string.Join(" AND ", conditions);
                }

                // 添加 ORDER BY 子句
                query += " ORDER BY ur.addtime DESC";

                // 创建 SqlCommand 对象
                SqlCommand sqlCommand = new SqlCommand(query, connection);

                // 添加参数
                sqlCommand.Parameters.AddWithValue("@thisid", thisid); // 添加 thisid 参数
                foreach (var param in parameters)
                {
                    sqlCommand.Parameters.Add(param);
                }

                // 使用 SqlCommand 创建 SqlDataAdapter
                SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

                // 确保数据集中有一个名为 Record 的 DataTable
                if (gmsDataSet.Tables["Record"] == null)
                {
                    // 如果不存在，则创建一个新的 DataTable
                    DataTable recordTable = new DataTable("Record");
                    gmsDataSet.Tables.Add(recordTable);
                }
                else
                {
                    // 清除现有数据
                    gmsDataSet.Tables["Record"].Rows.Clear();
                }

                // 使用 SqlDataAdapter 填充数据集中的 Record 表
                int rowsAffected = sqlData.Fill(gmsDataSet.Tables["Record"]);

                // 设置 BindingSource 的 DataSource
                bindingSourceRecord.DataSource = gmsDataSet.Tables["Record"];

                // 检查是否找到了数据
                if (rowsAffected == 0)
                {
                    // 清空 RecordTable 的数据源
                    RecordTable.DataSource = null;

                    // 重置分页控件
                    RecordPagination.TotalCount = 0;
                    RecordPagination.ActivePage = 1;
                }
                else
                {
                    // 计算总页数
                    int totalRows = gmsDataSet.Tables["Record"].Rows.Count;
                    int pageCount = (int)Math.Ceiling((double)totalRows / RecordPagination.PageSize);

                    // 设置总条目数
                    RecordPagination.TotalCount = totalRows;

                    // 设置数据源
                    RecordPagination.DataSource = bindingSourceRecord;

                    // 设置初始页码
                    RecordPagination.ActivePage = 1;

                    // 如果分页控件有 PageDataSource，则设置 RecordTable 的 DataSource
                    if (RecordPagination.PageDataSource != null)
                    {
                        RecordTable.DataSource = RecordPagination.PageDataSource;
                    }
                }
            }
         }

        private void deleteRecord_Click(object sender, EventArgs e)
        {
            // 检查是否有选中的行
            if (RecordTable.SelectedIndex != -1)
            {
                // 获取选中的行索引
                int index = RecordTable.SelectedIndex;

                // 确保索引在有效范围内
                if (index >= 0 && index < RecordPagination.TotalCount)
                {
                    // 获取选中行的数据
                    DataRow selectedRow = gmsDataSet.Tables["Record"].Rows[index + (RecordPagination.ActivePage - 1) * RecordPagination.PageSize-1];

                    // 提取所需属性
                    string courseId = selectedRow["课程号"].ToString();
                    string coachId = thisid; // 假设 thisid 是当前教练的 ID
                    string studentId = selectedRow["学生账号"].ToString();
                    DateTime addTime = (DateTime)selectedRow["添加时间"];

                    // 提示用户是否确认删除
                    DialogResult result = MessageBox.Show("确定要删除这条记录吗？", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
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
                                    string deleteQuery = @"
                                DELETE FROM UserRecord 
                                WHERE courseid = @CourseId 
                                  AND coachid = @CoachId 
                                  AND userid = @StudentId 
                                  AND addtime = @AddTime;";

                                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection, transaction);
                                    deleteCommand.Parameters.AddWithValue("@CourseId", courseId);
                                    deleteCommand.Parameters.AddWithValue("@CoachId", coachId);
                                    deleteCommand.Parameters.AddWithValue("@StudentId", studentId);
                                    deleteCommand.Parameters.AddWithValue("@AddTime", addTime);

                                    // 执行删除命令
                                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        // 提交事务
                                        transaction.Commit();

                                        // 如果删除成功，从数据表中移除该行
                                        gmsDataSet.Tables["Record"].Rows.Remove(selectedRow);

                                        // 更新 DataGridView 的数据源
                                        RecordTable.DataSource = gmsDataSet.Tables["Record"];

                                        // 重新计算分页控件
                                        int totalRows = gmsDataSet.Tables["Record"].Rows.Count;
                                        RecordPagination.TotalCount = totalRows;

                                        // 如果删除后数据表为空，显示提示
                                        if (totalRows == 0)
                                        {
                                            RecordTable.DataSource = null; // 清空 DataGridView
                                            RecordPagination.ActivePage = 1; // 重置到第一页
                                        }
                                        else
                                        {
                                            // 如果还有数据，重置到第一页
                                            RecordPagination.ActivePage = 1;
                                        }

                                        // 提示删除成功
                                        MessageBox.Show("记录删除成功！");
                                    }
                                    else
                                    {
                                        // 提示删除失败
                                        MessageBox.Show("记录删除失败！没有找到匹配的记录。");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    // 发生异常时回滚事务
                                    transaction.Rollback();
                                    MessageBox.Show("删除操作失败: " + ex.Message);
                                }
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
                MessageBox.Show("请先选择要删除的记录！");
            }
        }

        private void AlterRecord_Click(object sender, EventArgs e)
        {
            // 显式调用 EndEdit 方法，确保所有更改都已提交
            if (bindingSourceRecord != null && bindingSourceRecord.Count > 0)
            {
                for (int i = 0; i < bindingSourceRecord.Count; i++)
                {
                    bindingSourceRecord.Position = i;
                    if (bindingSourceRecord.Current is DataRowView dataRowView)
                    {
                        DataRow row = dataRowView.Row;
                        if (row.RowState == DataRowState.Modified)
                        {
                            row.EndEdit(); // 提交当前行的更改
                        }
                    }
                }
            }

            UpdateRecordValue();
            // 重新加载数据以反映更改
            showFitnessRecords();
        }

        private void UpdateRecordValue()
        {
            // 遍历所有的行
            foreach (DataRow row in gmsDataSet.Tables["Record"].Rows)
            {
                if (row.RowState == DataRowState.Modified) // 检查行是否被修改
                {
                    string errorMessage = string.Empty;

                    // 获取原始值和新值
                    int originalCourseId = (int)row["课程号", DataRowVersion.Original];
                    int newCourseId = (int)row["课程号"];

                    string originalUserId = (string)row["学生账号", DataRowVersion.Original];
                    string newUserId = row["学生账号"] as string ?? string.Empty;

                    int? originalRank = (int?)row["分数", DataRowVersion.Original];
                    int? newRank = (int?)row["分数"];

                    DateTime? originalAddTime = (DateTime?)row["添加时间", DataRowVersion.Original];
                    DateTime? newAddTime = (DateTime?)row["添加时间"];

                    string originalWeekday = (string)row["星期", DataRowVersion.Original];
                    string newWeekday = row["星期"] as string ?? string.Empty;

                    // 检查课程号、学生账号和星期是否被修改
                    if (originalCourseId != newCourseId || originalUserId != newUserId || originalWeekday != newWeekday)
                    {
                        errorMessage = "课程号、学生账号和星期不能修改！只能修改分数和添加时间。";
                    }

                    // 如果添加时间被修改，检查新的添加时间的星期是否与星期列的值相同
                    if (newAddTime.HasValue && newAddTime.Value.Date != originalAddTime.Value.Date)
                    {
                        string newAddTimeWeekday = newAddTime.Value.ToString("dddd", CultureInfo.GetCultureInfo("zh-CN"));
                        if (newAddTimeWeekday != newWeekday)
                        {
                            errorMessage = "新的添加时间的星期与星期列的值不匹配！";
                        }
                    }

                    // 如果有错误信息，则显示并跳过该行
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        MessageBox.Show($"修改记录时出现错误: {errorMessage}");
                        continue;
                    }

                    // 更新数据库
                    UpdateRecordDatabase(originalCourseId, newUserId, this.thisid, newRank, originalAddTime, newAddTime);
                }
            }
        }

        private void UpdateRecordDatabase(int courseId, string userId,string coachId, int? newRank, DateTime? originalAddTime, DateTime? newAddTime)
        {
            // 创建 SqlConnection 对象并打开连接
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                // 使用事务来确保数据一致性
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 创建更新命令
                        string updateQuery = @"
                    UPDATE UserRecord 
                    SET rank = @NewRank, addtime = @NewAddTime
                    WHERE courseid = @CourseId
                      AND userid = @UserId
                      AND coachid = @CoachId
                      AND addtime = @OriginalAddTime;";

                        SqlCommand updateCommand = new SqlCommand(updateQuery, connection, transaction);
                        updateCommand.Parameters.AddWithValue("@CourseId", courseId);
                        updateCommand.Parameters.AddWithValue("@UserId", userId);
                        updateCommand.Parameters.AddWithValue("@CoachId", coachId);
                        updateCommand.Parameters.AddWithValue("@NewRank", newRank);
                        updateCommand.Parameters.AddWithValue("@OriginalAddTime", originalAddTime);
                        updateCommand.Parameters.AddWithValue("@NewAddTime", newAddTime);

                        // 执行更新命令
                        int rowsAffected = updateCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // 提交事务
                            transaction.Commit();
                            MessageBox.Show("记录更新成功！");
                        }
                        else
                        {
                            // 提示更新失败
                            MessageBox.Show("记录更新失败！没有找到匹配的记录。");
                        }
                    }
                    catch (Exception ex)
                    {
                        // 发生异常时回滚事务
                        transaction.Rollback();
                        MessageBox.Show("更新操作失败: " + ex.Message);
                    }
                }
            }
        }
    }
}
