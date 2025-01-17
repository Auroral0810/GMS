using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMS.用户;
using Sunny.UI;
namespace GMS.用户
{
    public partial class frmUser : Form
    {
        public string thisid= "00000000000660388069";
        private Button currentButton;
        private Random random;
        private int tempIndex;
        string con = DBconn.connstring;
        BindingSource bindingSourceCourse = new BindingSource();
        BindingSource bindingSourceReserve = new BindingSource();
        BindingSource bindingSourceRecord = new BindingSource();
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
        public string LoginUserId { get; set; }
        public string LoginUserPhone { get; set; }
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
        public frmUser()
        {
            InitializeComponent();
            random = new Random();
        }
        public frmUser(string value, string logintype)
        {
            InitializeComponent();
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
                string query = "SELECT  c.courseid AS [课程号], c.coursename AS [课程名称], c.coachid AS [教练], " +
                    "c.weekday AS [星期], c.start_time AS [上课时间], c.duration_hours AS [课程时长], c.maxstudent AS [最大学生数量], " +
                    " (c.maxstudent - ISNULL((SELECT COUNT(*) FROM CourseInfo ci WHERE ci.courseid = c.courseid), 0)) AS [剩余可选人数] from Courses c";
                sqlCommand = new SqlCommand(query, connection);
                sqlData = new SqlDataAdapter(sqlCommand);
                // 确保数据集中有一个名为 Admin 的 DataTable
                if (gmsDataSet.Tables["Course"] == null)
                {
                    // 如果不存在，则创建一个新的 DataTable
                    DataTable ReserveTable = new DataTable("Course");
                    gmsDataSet.Tables.Add(ReserveTable);

                }
                gmsDataSet.Tables["Course"].Rows.Clear();
                // 使用 TableAdapter 填充数据集
                sqlData.Fill(gmsDataSet.Tables["Course"]);

                // 设置 BindingSource 的 DataSource
                bindingSourceCourse.DataSource = gmsDataSet.Tables["Course"];

                // 计算总页数
                int totalRows = gmsDataSet.Tables["Course"].Rows.Count;
                int pageCount = (int)Math.Ceiling((double)totalRows / ReservePagination.PageSize);

                // 设置总条目数
                ReservePagination.TotalCount = totalRows;

                // 设置数据源
                ReservePagination.DataSource = bindingSourceCourse;

                // 设置初始页码
                ReservePagination.ActivePage = 1;

                // 如果分页控件有 PageDataSource，则设置 AdminTable 和 AdminData 的 DataSource
                if (ReservePagination.PageDataSource != null)
                {
                    ReserveTable.DataSource = ReservePagination.PageDataSource;
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

                // 查询 Courses 表中的信息，并根据 CourseInfo 和 ReservationInfo 表中的 stuid 来确定状态
                string query = @"
            SELECT 
                c.courseid AS [课程号],
                c.coursename AS [课程名称],
                c.coachid AS [教练],
                c.weekday AS [星期],
                c.start_time AS [上课时间],
                c.duration_hours AS [课程时长],
                 (c.maxstudent - ISNULL((SELECT COUNT(*) FROM CourseInfo ci WHERE ci.courseid = c.courseid), 0)) AS [剩余可选人数],
                CASE 
                    WHEN ci.courseid IS NOT NULL THEN '已选'
                    WHEN ri.courseid IS NOT NULL THEN '已预约'
                    ELSE '未知'
                END AS [状态]
            FROM 
                Courses c
            LEFT JOIN 
                CourseInfo ci ON c.courseid = ci.courseid AND ci.stuid = @thisid
            LEFT JOIN 
                ReservationInfo ri ON c.courseid = ri.courseid AND ri.stuid = @thisid
            WHERE 
                ci.courseid IS NOT NULL OR ri.courseid IS NOT NULL";

                sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@thisid", thisid);

                sqlData = new SqlDataAdapter(sqlCommand);

                // 确保数据集中有一个名为 Course 的 DataTable
                if (gmsDataSet.Tables["Reserve"] == null)
                {
                    // 如果不存在，则创建一个新的 DataTable
                    DataTable courseTable = new DataTable("Reserve");
                    gmsDataSet.Tables.Add(courseTable);
                }

                // 清除现有的行
                gmsDataSet.Tables["Reserve"].Rows.Clear();

                // 使用 TableAdapter 填充数据集
                sqlData.Fill(gmsDataSet.Tables["Reserve"]);

                // 设置 BindingSource 的 DataSource
                bindingSourceReserve.DataSource = gmsDataSet.Tables["Reserve"];

                // 计算总页数
                int totalRows = gmsDataSet.Tables["Reserve"].Rows.Count;
                int pageCount = (int)Math.Ceiling((double)totalRows / SelectedCoursePagination.PageSize);

                // 设置总条目数
                SelectedCoursePagination.TotalCount = totalRows;

                // 设置数据源
                SelectedCoursePagination.DataSource = bindingSourceReserve;

                // 设置初始页码
                SelectedCoursePagination.ActivePage = 1;

                // 如果分页控件有 PageDataSource，则设置 AdminTable 和 AdminData 的 DataSource
                if (SelectedCoursePagination.PageDataSource != null)
                {
                    SelectedCourseTable.DataSource = SelectedCoursePagination.PageDataSource;
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
                        CourseName1.Items.Add(coursename);
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
                ur.coachid AS [教练号],
                u.name AS [教练],
                c.weekday AS [星期],
                ur.rank AS [分数],
                ur.addtime AS [添加时间]
            FROM 
                UserRecord ur
            INNER JOIN 
                Courses c ON ur.courseid = c.courseid
            INNER JOIN
                Users u ON ur.coachid = u.id
            WHERE 
                ur.userid = @thisid";

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
                        CourseName2.Items.Add(coursename);
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

                // 查询语句：获取 stuid 为 thisid 的所有 courseid
                string query1 = @"
            SELECT courseid 
            FROM CourseInfo 
            WHERE stuid = @thisid";

                SqlCommand sqlCommand1 = new SqlCommand(query1, connection);
                sqlCommand1.Parameters.AddWithValue("@thisid", thisid);

                // 执行查询并获取结果
                List<int> courseIds = new List<int>();
                using (SqlDataReader reader1 = sqlCommand1.ExecuteReader())
                {
                    while (reader1.Read())
                    {
                        courseIds.Add(Convert.ToInt32(reader1["courseid"]));
                    }
                }

                // 如果没有找到任何课程，则直接返回
                if (courseIds.Count == 0)
                {
                    MessageBox.Show("未找到该学生的任何课程。");
                    return;
                }

                // 查询语句：统计 Courses 表中 weekday 属性在各个星期的课程个数
                string query2 = @"
            SELECT 
                weekday, 
                COUNT(*) AS course_count
            FROM 
                Courses
            WHERE 
                courseid IN (" + string.Join(",", courseIds) + @")
            GROUP BY 
                weekday";

                SqlCommand sqlCommand2 = new SqlCommand(query2, connection);
                using (SqlDataReader reader2 = sqlCommand2.ExecuteReader())
                {
                    // 遍历查询结果并统计每个星期的课程数量
                    while (reader2.Read())
                    {
                        string weekday = Convert.ToString(reader2["weekday"]);
                        int courseCount = Convert.ToInt32(reader2["course_count"]);

                        switch (weekday)
                        {
                            case "星期一":
                                monday += courseCount;
                                break;
                            case "星期二":
                                tuesday += courseCount;
                                break;
                            case "星期三":
                                wednesday += courseCount;
                                break;
                            case "星期四":
                                thursday += courseCount;
                                break;
                            case "星期五":
                                friday += courseCount;
                                break;
                            case "星期六":
                                saturday += courseCount;
                                break;
                            case "星期日":
                                sunday += courseCount;
                                break;
                        }
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
                UserfrmBarChart.SetOption(option);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发生错误: {ex.Message}");
            }
        }
        public void viewDoughnutChart()
        {
            // 创建一个字典来存储每个课程名称及其对应的上课节数
            Dictionary<string, int> courseCounts = new Dictionary<string, int>();

            // 创建 SqlConnection 对象并打开连接
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                // 查询语句：选择符合条件的课程名称及其记录数（即上课节数）
                string query = @"
            SELECT c.coursename, COUNT(ur.courseid) AS [Count]
            FROM UserRecord ur
            INNER JOIN Courses c ON ur.courseid = c.courseid
            WHERE ur.userid = @thisid
            GROUP BY c.coursename";

                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@thisid", this.thisid);

                // 执行查询并获取结果
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string coursename = Convert.ToString(reader["coursename"]);
                        int count = Convert.ToInt32(reader["Count"]);

                        if (!courseCounts.ContainsKey(coursename))
                        {
                            courseCounts[coursename] = 0;
                        }
                        courseCounts[coursename] = count;
                    }
                }
            }

            // 设置饼状图选项
            UIDoughnutOption userDoughnutOption = new UIDoughnutOption();
            userDoughnutOption.ToolTip.Visible = true;
            userDoughnutOption.Title = new UITitle { Text = "课程上课节数" };

            // 创建饼状图系列
            UIDoughnutSeries userDoughnutSeries = new UIDoughnutSeries
            {
                Name = "课程"
            };

            // 添加数据到系列
            foreach (var kvp in courseCounts)
            {
                userDoughnutSeries.AddData(kvp.Key, kvp.Value);
            }

            // 设置系列
            userDoughnutOption.AddSeries(userDoughnutSeries);

            // 更新配置
            UserfrmDoughnutChart.SetOption(userDoughnutOption);
        }
        public void viewPieChart()
        {
            int morningCount = 0;
            int afternoonCount = 0;

            // 创建 SqlConnection 对象并打开连接
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                // 查询语句：选择符合条件的课程的 start_time
                string query = @"
            SELECT c.start_time
            FROM Courses c
            INNER JOIN UserRecord ur ON c.courseid = ur.courseid
            WHERE ur.userid = @thisid";

                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@thisid", this.thisid);

                // 执行查询并获取结果
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TimeSpan startTime = reader.GetTimeSpan(reader.GetOrdinal("start_time"));

                        // 判断是上午还是下午
                        if (startTime < TimeSpan.FromHours(12))
                        {
                            morningCount++;
                        }
                        else
                        {
                            afternoonCount++;
                        }
                    }
                }
            }

            try
            {
                // 配置参数
                UIPieOption option = new UIPieOption(); // 假设使用的是饼状图选项类

                // 配置标题
                option.Title = new UITitle
                {
                    Text = "健身课程时间分布", // 主标题
                };

                // 设置图例
                option.Legend = new UILegend
                {
                    Orient = UIOrient.Horizontal, // 图例水平布局
                    Top = UITopAlignment.Top, // 图例放置在左上角
                    Left = UILeftAlignment.Left
                };
                option.Legend.AddData("上午");
                option.Legend.AddData("下午");

                // 设置系列
                UIPieSeries series = new UIPieSeries
                {
                    Name = "时间段"
                };

                // 添加数据到系列
                series.AddData("上午", morningCount);
                series.AddData("下午", afternoonCount);

                // 将系列添加到选项中
                option.Series.Add(series);

                // 辅助ToolTip是否可见
                option.ToolTip.Visible = true;

                // 更新配置
                UserfrmPieChart.SetOption(option); // 假设这是设置饼状图选项的方法
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发生错误: {ex.Message}");
            }
        }
        public void viewRecordBarChart()
        {
            // 初始化每个月份的课程总分
            Dictionary<int, int> monthlyScores = new Dictionary<int, int>();
            for (int month = 1; month <= 12; month++)
            {
                monthlyScores[month] = 0;
            }

            // 创建 SqlConnection 对象并打开连接
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                // 查询语句：获取 userid 为 thisid 的所有记录，并按月份统计 rank 总分
                string query = @"
            SELECT 
                MONTH(addtime) AS [Month], 
                SUM(rank) AS [TotalScore]
            FROM 
                UserRecord
            WHERE 
                YEAR(addtime) = 2023 AND 
                userid = @thisid
            GROUP BY 
                MONTH(addtime)";

                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@thisid", thisid);

                // 执行查询并获取结果
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int month = Convert.ToInt32(reader["Month"]);
                        int totalScore = Convert.ToInt32(reader["TotalScore"]);

                        if (monthlyScores.ContainsKey(month))
                        {
                            monthlyScores[month] = totalScore;
                        }
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
                    Text = "2023年每月课程总分", // 主标题
                };

                // 设置图例
                option.Legend = new UILegend
                {
                    Orient = UIOrient.Horizontal, // 图例水平布局
                    Top = UITopAlignment.Top, // 图例放置在左上角
                    Left = UILeftAlignment.Left
                };
                option.Legend.AddData("课程总分");

                // 设置系列
                UIBarSeries series = new UIBarSeries
                {
                    Name = "课程总分"
                };

                // 添加数据到系列
                for (int month = 1; month <= 12; month++)
                {
                    series.AddData($"月{month}", monthlyScores[month]);
                }

                // 将系列添加到选项中
                option.Series.Add(series);

                // 设置横坐标内容
                for (int month = 1; month <= 12; month++)
                {
                    option.XAxis.Data.Add($"{month}月");
                }

                // 辅助ToolTip是否可见
                option.ToolTip.Visible = true;

                // Y轴的刻度
                option.YAxis.Scale = true;

                // XY轴的单位
                option.XAxis.Name = null;
                option.YAxis.Name = "总分";

                // 更新配置
                RecordBarChart.SetOption(option);
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
               PageControl.SelectTab(1);
            }
            if (menu.Items[2].Select)
            {
                if (menu.Items[2].Sub[0].Select)
                {
                    showCourseInfo();
                    PageControl.SelectTab(2);
                }
                else if (menu.Items[2].Sub[1].Select)
                {
                    showReserveInfo();
                    PageControl.SelectTab(3);
                }
            }
            if (menu.Items[3].Select)
            {
                showFitnessRecords();
              PageControl.SelectTab(4);
            }
            if (menu.Items[4].Select)
            {
                viewBarChart();
                viewDoughnutChart();
                viewPieChart();
                viewRecordBarChart();
                PageControl.SelectTab(5);
            }
            if (menu.Items[5].Select)
            {
                PageControl.SelectTab(6);
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
                MessageBox.Show("用户名不能为空！");
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
                            // 获取需要删除的 stuid 列表
                            List<string> courseIdsToDelete = GetCourseIdsToDelete(connection, this.thisid, transaction);

                            // 删除 CourseInfo 表中对应 stuid 的数据
                            foreach (string courseId in courseIdsToDelete)
                            {
                                DeleteFromTable(connection, "CourseInfo", "stuid", courseId, transaction);
                            }
                            // 删除 ReservationInfo 表中对应 stuid 的数据
                            foreach (string courseId in courseIdsToDelete)
                            {
                                DeleteFromTable(connection, "ReservationInfo", "stuid", courseId, transaction);
                            }

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
            string query = "SELECT stuid FROM Courses WHERE coachid = @thisid";
            SqlCommand sqlCommand = new SqlCommand(query, connection, transaction);
            sqlCommand.Parameters.AddWithValue("@thisid", thisid);

            // 执行查询并读取结果
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    courseIds.Add(reader["stuid"].ToString());
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
                // 基础查询
                string query = @"
                SELECT 
                    c.courseid AS [课程号],
                    c.coursename AS [课程名称],
                    c.coachid AS [教练], 
                    c.weekday AS [星期], 
                    c.start_time AS [上课时间], 
                    c.duration_hours AS [课程时长], 
                    c.maxstudent AS [最大学生数量],
                    (c.maxstudent - ISNULL((SELECT COUNT(*) FROM ReservationInfo ri WHERE ri.courseid = c.courseid), 0)) AS [剩余可选人数]
                FROM 
                    Courses c";

                // 添加搜索条件
                List<string> conditions = new List<string>();
                List<SqlParameter> parameters = new List<SqlParameter>();

                if (!string.IsNullOrEmpty(CourseName.Text.Trim()))
                {
                    conditions.Add("c.coursename=@CourseName");
                    parameters.Add(new SqlParameter("@CourseName", CourseName.Text.Trim()));
                }

                if (!string.IsNullOrEmpty(CourseCoachid.Text.Trim()))
                {
                    conditions.Add("c.coachid LIKE @CourseCoachid");
                    parameters.Add(new SqlParameter("@CourseCoachid", "%" + CourseCoachid.Text.Trim() + "%"));
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
                    conditions.Add("c.weekday=@dayofweek");
                    parameters.Add(new SqlParameter("@dayofweek", dayofweek.Text.Trim()));
                }

                if (conditions.Count > 0)
                {
                    // 如果有搜索条件，将它们添加到 WHERE 子句中
                    query += " WHERE " + string.Join(" AND ", conditions);
                }

                // 添加 ORDER BY 子句
                query += " ORDER BY c.courseid ASC";

                // 创建 SqlCommand 对象
                SqlCommand sqlCommand = new SqlCommand(query, connection);

                // 添加参数
                foreach (var param in parameters)
                {
                    sqlCommand.Parameters.Add(param);
                }

                // 使用 SqlCommand 创建 SqlDataAdapter
                SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);

                // 确保数据集中有一个名为 Course 的 DataTable
                if (gmsDataSet.Tables["Course"] == null)
                {
                    // 如果不存在，则创建一个新的 DataTable
                    DataTable ReserveTable = new DataTable("Course");
                    gmsDataSet.Tables.Add(ReserveTable);
                }
                else
                {
                    // 清除现有数据
                    gmsDataSet.Tables["Course"].Rows.Clear();
                }

                // 使用 SqlDataAdapter 填充数据集中的 Course 表
                int rowsAffected = sqlData.Fill(gmsDataSet.Tables["Course"]);

                // 设置 BindingSource 的 DataSource
                bindingSourceReserve.DataSource = gmsDataSet.Tables["Course"];

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
                    int totalRows = gmsDataSet.Tables["Course"].Rows.Count;
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
        private void reserveCourse_Click(object sender, EventArgs e)
        {
            // 检查是否有选中的行
            if (ReserveTable.SelectedIndex != -1)
            {
                // 获取选中的行索引
                int index = ReserveTable.SelectedIndex;

                // 确保索引在有效范围内
                if (index >= 0 && index < gmsDataSet.Tables["Course"].Rows.Count)
                {
                    // 获取选中行的数据
                    DataRow selectedRow = gmsDataSet.Tables["Course"].Rows[index + (ReservePagination.ActivePage - 1) * ReservePagination.PageSize-1];

                    // 获取课程号、剩余可选人数、星期和上课时间
                    int courseId = Convert.ToInt32(selectedRow["课程号"]);
                    int remainingSlots = Convert.ToInt32(selectedRow["剩余可选人数"]);
                    string weekday = selectedRow["星期"].ToString();
                    TimeSpan startTime = (TimeSpan)selectedRow["上课时间"];

                    // 检查是否有剩余名额
                    if (remainingSlots > 0)
                    {
                        // 插入数据到 ReservationInfo 表
                        InsertIntoReservationInfo(courseId, this.thisid, weekday, startTime);
                    }
                    else
                    {
                        // 提示课程已满
                        MessageBox.Show("该课程已选满，请选择其他课程。");
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
                MessageBox.Show("请先选择要预订的课程！");
            }
        }
        private void InsertIntoReservationInfo(int courseId, string stuid, string weekday, TimeSpan startTime)
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                // 打开数据库连接
                connection.Open();

                // 检查用户是否已经在当前时间段有课程
                string checkExistingTimeSlotQuery = @"
            SELECT 1
            FROM (
                SELECT c.courseid
                FROM CourseInfo ci
                JOIN Courses c ON ci.courseid = c.courseid
                WHERE ci.stuid = @stuid
                UNION ALL
                SELECT r.courseid
                FROM ReservationInfo r
                JOIN Courses c ON r.courseid = c.courseid
                WHERE r.stuid = @stuid
            ) AS combined
            JOIN Courses c ON combined.courseid = c.courseid
            WHERE c.weekday = @weekday AND c.start_time = @starttime";

                using (SqlCommand checkExistingTimeSlotCommand = new SqlCommand(checkExistingTimeSlotQuery, connection))
                {
                    checkExistingTimeSlotCommand.Parameters.AddWithValue("@stuid", stuid);
                    checkExistingTimeSlotCommand.Parameters.AddWithValue("@weekday", weekday);
                    checkExistingTimeSlotCommand.Parameters.AddWithValue("@starttime", startTime);

                    object result = checkExistingTimeSlotCommand.ExecuteScalar();
                    if (result != null && (int)result > 0)
                    {
                        MessageBox.Show("您已经在该时间段选择了课程，请选择其他时间。");
                        return;
                    }
                }

                // 插入数据到 ReservationInfo 表
                string insertQuery = "INSERT INTO ReservationInfo (courseid, stuid) VALUES (@courseid, @stuid)";
                using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                {
                    insertCommand.Parameters.AddWithValue("@courseid", courseId);
                    insertCommand.Parameters.AddWithValue("@stuid", stuid);

                    insertCommand.ExecuteNonQuery();
                    MessageBox.Show("课程预订成功！");
                }
            }
        }
        private void SearchNowCourse_Click(object sender, EventArgs e)
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
                c.coachid AS [教练],
                c.weekday AS [星期],
                c.start_time AS [上课时间],
                c.duration_hours AS [课程时长],
                (c.maxstudent - ISNULL((SELECT COUNT(*) FROM CourseInfo ci WHERE ci.courseid = c.courseid), 0)) AS [剩余可选人数],
                CASE 
                    WHEN ci.courseid IS NOT NULL THEN '已选'
                    WHEN ri.courseid IS NOT NULL THEN '已预约'
                    ELSE '未知'
                END AS [状态]
            FROM 
                Courses c
            LEFT JOIN 
                CourseInfo ci ON c.courseid = ci.courseid AND ci.stuid = @thisid
            LEFT JOIN 
                ReservationInfo ri ON c.courseid = ri.courseid AND ri.stuid = @thisid
            WHERE 
                (ci.courseid IS NOT NULL OR ri.courseid IS NOT NULL) AND 1=1 ";  // 使用 1=1 作为初始条件，以便后续可以使用 AND 添加更多条件

                // 添加搜索条件
                List<string> conditions = new List<string>();
                List<SqlParameter> parameters = new List<SqlParameter>();

                if (!string.IsNullOrEmpty(CourseName1.Text.Trim()))
                {
                    conditions.Add("c.coursename=@CourseName");
                    parameters.Add(new SqlParameter("@CourseName", CourseName1.Text.Trim()));
                }

                if (!string.IsNullOrEmpty(Coachinput.Text.Trim()))
                {
                    conditions.Add("c.coachid LIKE @Coachinput");
                    parameters.Add(new SqlParameter("@Coachinput", "%" + Coachinput.Text.Trim() + "%"));
                }

                if (!string.IsNullOrEmpty(CourseTime1.Text.Trim()))
                {
                    // 尝试解析用户输入的时间
                    if (TimeSpan.TryParse(CourseTime1.Text, out TimeSpan startTime))
                    {
                        // 添加条件到查询
                        conditions.Add("c.start_time = @CourseTime");

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
                        return;
                    }
                }

                if (!string.IsNullOrEmpty(dayofweek1.Text.Trim()))
                {
                    conditions.Add("c.weekday=@dayofweek1");
                    parameters.Add(new SqlParameter("@dayofweek1", dayofweek1.Text.Trim()));
                }

                // 如果有搜索条件，将它们添加到 WHERE 子句中
                if (conditions.Count > 0)
                {
                    query += " AND " + string.Join(" AND ", conditions);
                }

                // 添加 ORDER BY 子句
                query += " ORDER BY c.courseid ASC";

                // 创建 SqlCommand 对象
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@thisid", thisid);

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
                    gmsDataSet.Tables["Reserve"].Clear();  // 清空 DataTable
                    bindingSourceReserve.ResetBindings(false);  // 重置 BindingSource

                    // 重置分页控件
                    SelectedCoursePagination.TotalCount = 0;
                    SelectedCoursePagination.ActivePage = 1;

                    // 重置相关控件的数据源
                    SelectedCourseTable.DataSource = null;  // 如果 SelectedCourseTable 是 DataGridView 或其他控件，请设置为 null
                }
                else
                {
                    // 计算总页数
                    int totalRows = gmsDataSet.Tables["Reserve"].Rows.Count;
                    int pageCount = (int)Math.Ceiling((double)totalRows / SelectedCoursePagination.PageSize);

                    // 设置总条目数
                    SelectedCoursePagination.TotalCount = totalRows;

                    // 设置数据源
                    SelectedCoursePagination.DataSource = bindingSourceReserve;

                    // 设置初始页码
                    SelectedCoursePagination.ActivePage = 1;

                    // 如果分页控件有 PageDataSource，则设置 ReserveTable 的 DataSource
                    if (SelectedCoursePagination.PageDataSource != null)
                    {
                        SelectedCourseTable.DataSource = SelectedCoursePagination.PageDataSource;
                    }
                }
            }
        }
        private void quitReserve_Click(object sender, EventArgs e)
        {
            // 检查是否有选中的行
            if (SelectedCourseTable.SelectedIndex != -1)
            {
                // 获取选中的行索引
                int selectedIndex = SelectedCourseTable.SelectedIndex;

                // 确保索引在有效范围内
                if (selectedIndex >= 0 && selectedIndex <= gmsDataSet.Tables["Reserve"].Rows.Count)
                {
                    // 获取选中行的数据
                    DataRow selectedRow = gmsDataSet.Tables["Reserve"].Rows[selectedIndex + (SelectedCoursePagination.ActivePage - 1) * SelectedCoursePagination.PageSize-1];

                    // 获取课程号和状态
                    int courseid = Convert.ToInt32(selectedRow["课程号"]);
                    string status = selectedRow["状态"].ToString();

                    // 显示确认对话框
                    DialogResult result = MessageBox.Show("您确定要取消该课程的预约吗？", "确认取消", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // 创建 SqlConnection 对象并打开连接
                        using (SqlConnection connection = new SqlConnection(con))
                        {
                            connection.Open();

                            // 根据状态决定删除操作
                            if (status == "已选")
                            {
                                // 删除 CourseInfo 表中的记录
                                string deleteQuery = "DELETE FROM CourseInfo WHERE courseid = @courseid AND stuid = @stuid";
                                SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                                deleteCommand.Parameters.AddWithValue("@courseid", courseid);
                                deleteCommand.Parameters.AddWithValue("@stuid", thisid);

                                int rowsAffected = deleteCommand.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("已成功取消选课。");
                                }
                                else
                                {
                                    MessageBox.Show("取消选课失败。");
                                }
                            }
                            else if (status == "已预约")
                            {
                                // 删除 ReservationInfo 表中的记录
                                string deleteQuery = "DELETE FROM ReservationInfo WHERE courseid = @courseid AND stuid = @stuid";
                                SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                                deleteCommand.Parameters.AddWithValue("@courseid", courseid);
                                deleteCommand.Parameters.AddWithValue("@stuid", thisid);

                                int rowsAffected = deleteCommand.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("已成功取消预约。");
                                }
                                else
                                {
                                    MessageBox.Show("取消预约失败。");
                                }
                            }
                            else
                            {
                                MessageBox.Show("无法取消未知状态的课程。");
                                return;
                            }

                            // 更新数据集
                            SearchNowCourse_Click(sender, e);  // 重新执行搜索以更新显示
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
                MessageBox.Show("请先选择要取消的课程！");
            }
        }
        private void SearchRecord_Click(object sender, EventArgs e)
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
                ur.coachid AS [教练号],
                u.name AS [教练],
                c.weekday AS [星期],
                ur.rank AS [分数],
                ur.addtime AS [添加时间]
            FROM 
                UserRecord ur
            INNER JOIN 
                Courses c ON ur.courseid = c.courseid
            INNER JOIN
                Users u ON ur.coachid = u.id
            WHERE 
                ur.userid = @thisid";

                // 添加搜索条件
                List<string> conditions = new List<string>();
                List<SqlParameter> parameters = new List<SqlParameter>();

                if (!string.IsNullOrEmpty(CourseName2.Text.Trim()))
                {
                    conditions.Add("c.coursename LIKE @CourseName2");
                    parameters.Add(new SqlParameter("@CourseName2", "%" + CourseName2.Text.Trim() + "%"));
                }

                if (!string.IsNullOrEmpty(CoachSearch2.Text.Trim()))
                {
                    conditions.Add("ur.coachid LIKE @CoachSearch2");
                    parameters.Add(new SqlParameter("@CoachSearch2", "%" + CoachSearch2.Text.Trim() + "%"));
                }

                if (CourseTime2.Value.HasValue) // 检查是否有值
                {
                    DateTime addTime = CourseTime2.Value.Value; // 获取实际的 DateTime 值
                                                                // 比较 addtime 的日期部分
                    conditions.Add("CONVERT(date, ur.addtime) = @CourseTime2");
                    parameters.Add(new SqlParameter("@CourseTime2", addTime.Date));
                }

                if (!string.IsNullOrEmpty(dayofweek2.Text.Trim()))
                {
                    conditions.Add("c.weekday = @RecordWeekday");
                    parameters.Add(new SqlParameter("@RecordWeekday", dayofweek2.Text.Trim()));
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

        private void CoursePagination(object sender, object pagingSource, int pageIndex, int count)
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
            SelectedCourseTable.DataSource = SelectedCoursePagination.PageDataSource;
        }

        private void ReservePagination_pageChanged(object sender, object pagingSource, int pageIndex, int count)
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
            ReserveTable.DataSource = ReservePagination.PageDataSource;
        }

        private void RecordPagination_PageChanged(object sender, object pagingSource, int pageIndex, int count)
        {
            // 检查数据源是否为空
            if (gmsDataSet.Tables["Record"] == null || gmsDataSet.Tables["Record"].Rows.Count == 0)
            {
                return;
            }

            // 计算分页的起始索引和结束索引
            int startIndex = (pageIndex - 1) * count;
            int endIndex = Math.Min(startIndex + count, gmsDataSet.Tables["Record"].Rows.Count);

            // 确保索引在有效范围内
            if (startIndex < 0 || endIndex > gmsDataSet.Tables["Record"].Rows.Count)
            {
                MessageBox.Show("分页参数无效！");
                return;
            }
            RecordTable.DataSource = RecordPagination.PageDataSource;
        }
    }
}
