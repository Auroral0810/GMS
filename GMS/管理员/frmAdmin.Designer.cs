using System.Windows.Forms;
using System;

namespace GMS.管理员
{
    partial class frmAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            AntdUI.MenuItem menuItem1 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem2 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem3 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem4 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem5 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem6 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem7 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem8 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem9 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem10 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem11 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem12 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem13 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem14 = new AntdUI.MenuItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdmin));
            AntdUI.CarouselItem carouselItem1 = new AntdUI.CarouselItem();
            AntdUI.CarouselItem carouselItem2 = new AntdUI.CarouselItem();
            AntdUI.CarouselItem carouselItem3 = new AntdUI.CarouselItem();
            AntdUI.CarouselItem carouselItem4 = new AntdUI.CarouselItem();
            AntdUI.CarouselItem carouselItem5 = new AntdUI.CarouselItem();
            AntdUI.CarouselItem carouselItem6 = new AntdUI.CarouselItem();
            AntdUI.CarouselItem carouselItem7 = new AntdUI.CarouselItem();
            AntdUI.StepsItem stepsItem1 = new AntdUI.StepsItem();
            AntdUI.StepsItem stepsItem2 = new AntdUI.StepsItem();
            AntdUI.StepsItem stepsItem3 = new AntdUI.StepsItem();
            AntdUI.StepsItem stepsItem4 = new AntdUI.StepsItem();
            this.panelMenu = new AntdUI.Panel();
            this.uiSwitch1 = new Sunny.UI.UISwitch();
            this.menu = new AntdUI.Menu();
            this.divider1 = new AntdUI.Divider();
            this.panelLogo = new AntdUI.Panel();
            this.avatar1 = new AntdUI.Avatar();
            this.panelTitleBar = new AntdUI.Panel();
            this.signal1 = new AntdUI.Signal();
            this.button3 = new AntdUI.Button();
            this.button2 = new AntdUI.Button();
            this.Title = new AntdUI.Label();
            this.panel4 = new AntdUI.Panel();
            this.PageControl = new Sunny.UI.UITabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new AntdUI.Panel();
            this.Weekday_pic = new AntdUI.Carousel();
            this.HelloLabel = new Sunny.UI.UILabel();
            this.panel1 = new AntdUI.Panel();
            this.image3D1 = new AntdUI.Image3D();
            this.flowLayoutPanel1 = new AntdUI.In.FlowLayoutPanel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.label2 = new AntdUI.Label();
            this.rate1 = new AntdUI.Rate();
            this.label1 = new AntdUI.Label();
            this.rate2 = new AntdUI.Rate();
            this.label3 = new AntdUI.Label();
            this.rate3 = new AntdUI.Rate();
            this.uiListBox1 = new Sunny.UI.UIListBox();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.ZongZhi = new Sunny.UI.UILabel();
            this.Step_ZZ = new AntdUI.Steps();
            this.calendar1 = new AntdUI.Calendar();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel14 = new AntdUI.Panel();
            this.AdminTable = new AntdUI.Table();
            this.panel13 = new AntdUI.Panel();
            this.uiPagination1 = new Sunny.UI.UIPagination();
            this.adminBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gMSdataset = new GMS.GMSdataset();
            this.panel12 = new AntdUI.Panel();
            this.deleteAdmin = new AntdUI.Button();
            this.VerityAddAdmin = new AntdUI.Button();
            this.AddAdmin = new AntdUI.Button();
            this.AlterAdmin = new AntdUI.Button();
            this.panel16 = new AntdUI.Panel();
            this.button4 = new AntdUI.Button();
            this.label4 = new AntdUI.Label();
            this.label5 = new AntdUI.Label();
            this.label6 = new AntdUI.Label();
            this.SearchAdminByname = new AntdUI.Input();
            this.SearchAdminByid = new AntdUI.Input();
            this.SearchAdminByphone = new AntdUI.Input();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.UserTable = new AntdUI.Table();
            this.panel20 = new AntdUI.Panel();
            this.UserPagination = new Sunny.UI.UIPagination();
            this.panel15 = new AntdUI.Panel();
            this.VerityAddUser = new AntdUI.Button();
            this.deleteUser = new AntdUI.Button();
            this.AddUser = new AntdUI.Button();
            this.AlterUser = new AntdUI.Button();
            this.panel17 = new AntdUI.Panel();
            this.SearchUser = new AntdUI.Button();
            this.label7 = new AntdUI.Label();
            this.label8 = new AntdUI.Label();
            this.label9 = new AntdUI.Label();
            this.SearchUserByname = new AntdUI.Input();
            this.SearchUserByid = new AntdUI.Input();
            this.SearchUserByphone = new AntdUI.Input();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.CoachTable = new AntdUI.Table();
            this.panel21 = new AntdUI.Panel();
            this.CoachPagination = new Sunny.UI.UIPagination();
            this.panel18 = new AntdUI.Panel();
            this.VerityAddCoach = new AntdUI.Button();
            this.deleteCoach = new AntdUI.Button();
            this.AddCoach = new AntdUI.Button();
            this.AlterCoach = new AntdUI.Button();
            this.panel19 = new AntdUI.Panel();
            this.SearchCoach = new AntdUI.Button();
            this.label10 = new AntdUI.Label();
            this.label11 = new AntdUI.Label();
            this.label12 = new AntdUI.Label();
            this.SearchCoachByname = new AntdUI.Input();
            this.SearchCoachByid = new AntdUI.Input();
            this.SearchCoachByphone = new AntdUI.Input();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.CourseTable = new AntdUI.Table();
            this.panel37 = new AntdUI.Panel();
            this.CoursePagination = new Sunny.UI.UIPagination();
            this.panel35 = new AntdUI.Panel();
            this.VerityAddCourse = new AntdUI.Button();
            this.deleteCourse = new AntdUI.Button();
            this.AddCourse = new AntdUI.Button();
            this.AlterCourse = new AntdUI.Button();
            this.panel36 = new AntdUI.Panel();
            this.dayofweek = new AntdUI.Select();
            this.CourseTime = new AntdUI.Select();
            this.CourseName = new AntdUI.Select();
            this.SearchCourse = new AntdUI.Button();
            this.label13 = new AntdUI.Label();
            this.label19 = new AntdUI.Label();
            this.label14 = new AntdUI.Label();
            this.label15 = new AntdUI.Label();
            this.CourseCoachid = new AntdUI.Input();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.ReserveTable = new AntdUI.Table();
            this.panel38 = new AntdUI.Panel();
            this.AgreeReseveCourse = new AntdUI.Button();
            this.NotReseveCourse = new AntdUI.Button();
            this.panel39 = new AntdUI.Panel();
            this.ReseveDayOfWeek = new AntdUI.Select();
            this.ReserveName = new AntdUI.Select();
            this.SearchReseveCourse = new AntdUI.Button();
            this.ReserveUserid = new AntdUI.Input();
            this.label16 = new AntdUI.Label();
            this.label17 = new AntdUI.Label();
            this.label18 = new AntdUI.Label();
            this.label20 = new AntdUI.Label();
            this.ReserveCoachid = new AntdUI.Input();
            this.panel40 = new AntdUI.Panel();
            this.ReservePagination = new Sunny.UI.UIPagination();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.panel22 = new AntdUI.Panel();
            this.panel25 = new AntdUI.Panel();
            this.panel29 = new AntdUI.Panel();
            this.UserDoughnutChart = new Sunny.UI.UIDoughnutChart();
            this.panel27 = new AntdUI.Panel();
            this.UserDoughnutMarkLabel = new Sunny.UI.UIMarkLabel();
            this.panel23 = new AntdUI.Panel();
            this.panel26 = new AntdUI.Panel();
            this.UserBarChart = new Sunny.UI.UIBarChart();
            this.panel24 = new AntdUI.Panel();
            this.UserBarMarkLabel = new Sunny.UI.UIMarkLabel();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.panel32 = new AntdUI.Panel();
            this.panel33 = new AntdUI.Panel();
            this.CoachDoughnutChart = new Sunny.UI.UIDoughnutChart();
            this.panel34 = new AntdUI.Panel();
            this.CoachDoughnutMarkLabel = new Sunny.UI.UIMarkLabel();
            this.panel28 = new AntdUI.Panel();
            this.panel30 = new AntdUI.Panel();
            this.CoachBarChart = new Sunny.UI.UIBarChart();
            this.panel31 = new AntdUI.Panel();
            this.CoachBarMarkLabel = new Sunny.UI.UIMarkLabel();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.panel44 = new AntdUI.Panel();
            this.panel45 = new AntdUI.Panel();
            this.CourseBarChart1 = new Sunny.UI.UIBarChart();
            this.panel46 = new AntdUI.Panel();
            this.CourseDoughnutMarkLabel = new Sunny.UI.UIMarkLabel();
            this.panel41 = new AntdUI.Panel();
            this.panel42 = new AntdUI.Panel();
            this.CourseBarChart = new Sunny.UI.UIBarChart();
            this.panel43 = new AntdUI.Panel();
            this.CourseBarMarkLabel = new Sunny.UI.UIMarkLabel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel6 = new AntdUI.Panel();
            this.flowLayoutPanel2 = new AntdUI.In.FlowLayoutPanel();
            this.uiSmoothLabel1 = new Sunny.UI.UISmoothLabel();
            this.uiLine1 = new Sunny.UI.UILine();
            this.uiSymbolLabel1 = new Sunny.UI.UISymbolLabel();
            this.uiSymbolLabel2 = new Sunny.UI.UISymbolLabel();
            this.uiSymbolLabel3 = new Sunny.UI.UISymbolLabel();
            this.uiSymbolLabel4 = new Sunny.UI.UISymbolLabel();
            this.uiSymbolLabel5 = new Sunny.UI.UISymbolLabel();
            this.uiSymbolLabel6 = new Sunny.UI.UISymbolLabel();
            this.uiSymbolLabel7 = new Sunny.UI.UISymbolLabel();
            this.panel8 = new AntdUI.Panel();
            this.panel11 = new AntdUI.Panel();
            this.image3D2 = new AntdUI.Image3D();
            this.panel10 = new AntdUI.Panel();
            this.panel9 = new AntdUI.Panel();
            this.panel7 = new AntdUI.Panel();
            this.uiLinkLabel1 = new Sunny.UI.UILinkLabel();
            this.panel5 = new AntdUI.Panel();
            this.panel3 = new AntdUI.Panel();
            this.tabPage13 = new System.Windows.Forms.TabPage();
            this.panel48 = new AntdUI.Panel();
            this.verityalterpwd = new AntdUI.Button();
            this.originpwd = new AntdUI.Input();
            this.newpwd = new AntdUI.Input();
            this.veritynewpwd = new AntdUI.Input();
            this.uiSmoothLabel3 = new Sunny.UI.UISmoothLabel();
            this.panel47 = new AntdUI.Panel();
            this.selfbirthday = new AntdUI.DatePicker();
            this.selfage = new AntdUI.InputNumber();
            this.female = new AntdUI.Radio();
            this.male = new AntdUI.Radio();
            this.selfemail = new AntdUI.Input();
            this.selfphone = new AntdUI.Input();
            this.selfIDcard = new AntdUI.Input();
            this.selfname = new AntdUI.Input();
            this.selfid = new AntdUI.Input();
            this.verityalterinfo = new AntdUI.Button();
            this.beginalterinfo = new AntdUI.Button();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiSmoothLabel2 = new Sunny.UI.UISmoothLabel();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.用户名DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.姓名DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.年龄DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.性别DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.手机号码DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.身份证DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.邮箱DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出生日期DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adminTableAdapter = new GMS.GMSdatasetTableAdapters.AdminTableAdapter();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.panel4.SuspendLayout();
            this.PageControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.uiPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adminBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gMSdataset)).BeginInit();
            this.panel12.SuspendLayout();
            this.panel16.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel17.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.panel21.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel19.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.panel37.SuspendLayout();
            this.panel35.SuspendLayout();
            this.panel36.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.panel38.SuspendLayout();
            this.panel39.SuspendLayout();
            this.panel40.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.panel22.SuspendLayout();
            this.panel25.SuspendLayout();
            this.panel29.SuspendLayout();
            this.panel27.SuspendLayout();
            this.panel23.SuspendLayout();
            this.panel26.SuspendLayout();
            this.panel24.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.panel32.SuspendLayout();
            this.panel33.SuspendLayout();
            this.panel34.SuspendLayout();
            this.panel28.SuspendLayout();
            this.panel30.SuspendLayout();
            this.panel31.SuspendLayout();
            this.tabPage11.SuspendLayout();
            this.panel44.SuspendLayout();
            this.panel45.SuspendLayout();
            this.panel46.SuspendLayout();
            this.panel41.SuspendLayout();
            this.panel42.SuspendLayout();
            this.panel43.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tabPage13.SuspendLayout();
            this.panel48.SuspendLayout();
            this.panel47.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Back = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(160)))), ((int)(((byte)(202)))));
            this.panelMenu.Controls.Add(this.uiSwitch1);
            this.panelMenu.Controls.Add(this.menu);
            this.panelMenu.Controls.Add(this.divider1);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Radius = 0;
            this.panelMenu.Size = new System.Drawing.Size(236, 1153);
            this.panelMenu.TabIndex = 0;
            this.panelMenu.Text = "panel1";
            // 
            // uiSwitch1
            // 
            this.uiSwitch1.ActiveText = "浅色";
            this.uiSwitch1.BackColor = System.Drawing.Color.Transparent;
            this.uiSwitch1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSwitch1.InActiveText = "深色";
            this.uiSwitch1.Location = new System.Drawing.Point(35, 1058);
            this.uiSwitch1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSwitch1.Name = "uiSwitch1";
            this.uiSwitch1.Size = new System.Drawing.Size(166, 59);
            this.uiSwitch1.TabIndex = 39;
            this.uiSwitch1.Text = "uiSwitch1";
            // 
            // menu
            // 
            this.menu.AutoCollapse = true;
            this.menu.BackActive = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            this.menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(160)))), ((int)(((byte)(202)))));
            this.menu.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(154)))), ((int)(((byte)(224)))));
            this.menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menu.HandCursor = System.Windows.Forms.Cursors.Arrow;
            this.menu.Indent = true;
            menuItem1.Expand = false;
            menuItem1.Font = new System.Drawing.Font("楷体", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            menuItem1.PARENTITEM = null;
            menuItem1.Select = false;
            menuItem1.Text = "主界面";
            menuItem2.Font = new System.Drawing.Font("楷体", 10.875F, System.Drawing.FontStyle.Bold);
            menuItem2.PARENTITEM = null;
            menuItem2.Select = false;
            menuItem2.Text = "个人信息";
            menuItem3.Expand = false;
            menuItem3.Font = new System.Drawing.Font("楷体", 10.875F, System.Drawing.FontStyle.Bold);
            menuItem3.PARENTITEM = null;
            menuItem3.Select = false;
            menuItem3.Text = "管理员信息";
            menuItem4.Expand = false;
            menuItem4.Font = new System.Drawing.Font("楷体", 10.875F, System.Drawing.FontStyle.Bold);
            menuItem4.PARENTITEM = null;
            menuItem4.Select = false;
            menuItem5.Font = new System.Drawing.Font("楷体", 10.125F);
            menuItem5.PARENTITEM = menuItem4;
            menuItem5.Select = false;
            menuItem5.Text = "用户管理";
            menuItem6.Font = new System.Drawing.Font("楷体", 10.125F);
            menuItem6.PARENTITEM = menuItem4;
            menuItem6.Select = false;
            menuItem6.Text = "教练管理";
            menuItem7.Font = new System.Drawing.Font("楷体", 10.125F);
            menuItem7.PARENTITEM = menuItem4;
            menuItem7.Select = false;
            menuItem7.Text = "课程管理";
            menuItem8.Font = new System.Drawing.Font("楷体", 10.125F);
            menuItem8.PARENTITEM = menuItem4;
            menuItem8.Select = false;
            menuItem8.Text = "预约管理";
            menuItem4.Sub.Add(menuItem5);
            menuItem4.Sub.Add(menuItem6);
            menuItem4.Sub.Add(menuItem7);
            menuItem4.Sub.Add(menuItem8);
            menuItem4.Text = "信息管理";
            menuItem9.Expand = false;
            menuItem9.Font = new System.Drawing.Font("楷体", 10.875F, System.Drawing.FontStyle.Bold);
            menuItem9.PARENTITEM = null;
            menuItem9.Select = false;
            menuItem10.Font = new System.Drawing.Font("楷体", 10.125F);
            menuItem10.PARENTITEM = menuItem9;
            menuItem10.Select = false;
            menuItem10.Text = "用户可视化";
            menuItem11.Font = new System.Drawing.Font("楷体", 10.125F);
            menuItem11.PARENTITEM = menuItem9;
            menuItem11.Select = false;
            menuItem11.Text = "教练可视化";
            menuItem12.Font = new System.Drawing.Font("楷体", 10.125F);
            menuItem12.PARENTITEM = menuItem9;
            menuItem12.Select = false;
            menuItem12.Text = "课程可视化";
            menuItem9.Sub.Add(menuItem10);
            menuItem9.Sub.Add(menuItem11);
            menuItem9.Sub.Add(menuItem12);
            menuItem9.Text = "信息可视化";
            menuItem13.Expand = false;
            menuItem13.Font = new System.Drawing.Font("楷体", 10.875F, System.Drawing.FontStyle.Bold);
            menuItem13.PARENTITEM = null;
            menuItem13.Select = false;
            menuItem13.Text = "帮助";
            menuItem14.Expand = false;
            menuItem14.Font = new System.Drawing.Font("楷体", 10.875F, System.Drawing.FontStyle.Bold);
            menuItem14.PARENTITEM = null;
            menuItem14.Select = false;
            menuItem14.Text = "退出系统";
            this.menu.Items.Add(menuItem1);
            this.menu.Items.Add(menuItem2);
            this.menu.Items.Add(menuItem3);
            this.menu.Items.Add(menuItem4);
            this.menu.Items.Add(menuItem9);
            this.menu.Items.Add(menuItem13);
            this.menu.Items.Add(menuItem14);
            this.menu.Location = new System.Drawing.Point(0, 134);
            this.menu.Name = "menu";
            this.menu.Radius = 30;
            this.menu.Round = true;
            this.menu.Size = new System.Drawing.Size(236, 1019);
            this.menu.TabIndex = 0;
            this.menu.Unique = true;
            this.menu.SelectChanged += new AntdUI.SelectEventHandler(this.Menu_selectChange);
            // 
            // divider1
            // 
            this.divider1.BackColor = System.Drawing.Color.Transparent;
            this.divider1.ColorSplit = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.divider1.Dock = System.Windows.Forms.DockStyle.Top;
            this.divider1.ForeColor = System.Drawing.Color.IndianRed;
            this.divider1.Location = new System.Drawing.Point(0, 117);
            this.divider1.Name = "divider1";
            this.divider1.Size = new System.Drawing.Size(236, 17);
            this.divider1.TabIndex = 2;
            this.divider1.Text = "";
            this.divider1.TextPadding = 0F;
            this.divider1.Thickness = 3F;
            // 
            // panelLogo
            // 
            this.panelLogo.Back = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(160)))), ((int)(((byte)(202)))));
            this.panelLogo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelLogo.Controls.Add(this.avatar1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Radius = 0;
            this.panelLogo.Size = new System.Drawing.Size(236, 117);
            this.panelLogo.TabIndex = 1;
            this.panelLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelLogo_MouseDown);
            // 
            // avatar1
            // 
            this.avatar1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.avatar1.BorderWidth = 2F;
            this.avatar1.Image = ((System.Drawing.Image)(resources.GetObject("avatar1.Image")));
            this.avatar1.Location = new System.Drawing.Point(46, 12);
            this.avatar1.Name = "avatar1";
            this.avatar1.Radius = 30;
            this.avatar1.Round = true;
            this.avatar1.Size = new System.Drawing.Size(127, 94);
            this.avatar1.TabIndex = 0;
            this.avatar1.Text = "";
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.Back = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(160)))), ((int)(((byte)(202)))));
            this.panelTitleBar.Controls.Add(this.signal1);
            this.panelTitleBar.Controls.Add(this.button3);
            this.panelTitleBar.Controls.Add(this.button2);
            this.panelTitleBar.Controls.Add(this.Title);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(236, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Radius = 0;
            this.panelTitleBar.ShadowAlign = AntdUI.TAlignMini.Top;
            this.panelTitleBar.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelTitleBar.ShadowOpacity = 0F;
            this.panelTitleBar.ShadowOpacityAnimation = true;
            this.panelTitleBar.ShadowOpacityHover = 0F;
            this.panelTitleBar.Size = new System.Drawing.Size(1897, 85);
            this.panelTitleBar.TabIndex = 1;
            this.panelTitleBar.Text = "panel3";
            // 
            // signal1
            // 
            this.signal1.BackColor = System.Drawing.Color.Transparent;
            this.signal1.Location = new System.Drawing.Point(1663, 0);
            this.signal1.Name = "signal1";
            this.signal1.Size = new System.Drawing.Size(107, 82);
            this.signal1.TabIndex = 14;
            this.signal1.Value = 4;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button3.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button3.Icon = ((System.Drawing.Image)(resources.GetObject("button3.Icon")));
            this.button3.IconRatio = 1.1F;
            this.button3.Location = new System.Drawing.Point(1776, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 51);
            this.button3.TabIndex = 26;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button2.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button2.Icon = ((System.Drawing.Image)(resources.GetObject("button2.Icon")));
            this.button2.IconRatio = 1.1F;
            this.button2.Location = new System.Drawing.Point(1832, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 51);
            this.button2.TabIndex = 27;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Title.Font = new System.Drawing.Font("方正舒体", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.Title.Location = new System.Drawing.Point(0, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(1897, 85);
            this.Title.TabIndex = 0;
            this.Title.Text = "欢迎使用健身房管理系统";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Title.TooltipConfig = null;
            this.Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Titile_MouseDown);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.PageControl);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(236, 85);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1897, 1068);
            this.panel4.TabIndex = 2;
            this.panel4.Text = "panel4";
            // 
            // PageControl
            // 
            this.PageControl.Controls.Add(this.tabPage1);
            this.PageControl.Controls.Add(this.tabPage2);
            this.PageControl.Controls.Add(this.tabPage4);
            this.PageControl.Controls.Add(this.tabPage5);
            this.PageControl.Controls.Add(this.tabPage6);
            this.PageControl.Controls.Add(this.tabPage7);
            this.PageControl.Controls.Add(this.tabPage9);
            this.PageControl.Controls.Add(this.tabPage10);
            this.PageControl.Controls.Add(this.tabPage11);
            this.PageControl.Controls.Add(this.tabPage3);
            this.PageControl.Controls.Add(this.tabPage13);
            this.PageControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PageControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.PageControl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PageControl.ForbidCtrlTab = false;
            this.PageControl.ItemSize = new System.Drawing.Size(0, 1);
            this.PageControl.Location = new System.Drawing.Point(0, 0);
            this.PageControl.MainPage = "主界面";
            this.PageControl.Name = "PageControl";
            this.PageControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PageControl.SelectedIndex = 0;
            this.PageControl.Size = new System.Drawing.Size(1897, 1068);
            this.PageControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.PageControl.Style = Sunny.UI.UIStyle.Custom;
            this.PageControl.TabIndex = 0;
            this.PageControl.TabVisible = false;
            this.PageControl.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PageControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PageControl_MouseDown);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.uiListBox1);
            this.tabPage1.Controls.Add(this.uiPanel1);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1897, 1068);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "主界面";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderWidth = 1F;
            this.panel2.Controls.Add(this.Weekday_pic);
            this.panel2.Controls.Add(this.HelloLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(531, 0);
            this.panel2.Name = "panel2";
            this.panel2.Radius = 0;
            this.panel2.Size = new System.Drawing.Size(690, 1068);
            this.panel2.TabIndex = 35;
            this.panel2.Text = "panel2";
            // 
            // Weekday_pic
            // 
            this.Weekday_pic.BackColor = System.Drawing.Color.White;
            this.Weekday_pic.Dock = System.Windows.Forms.DockStyle.Fill;
            carouselItem1.Img = ((System.Drawing.Image)(resources.GetObject("carouselItem1.Img")));
            carouselItem2.Img = ((System.Drawing.Image)(resources.GetObject("carouselItem2.Img")));
            carouselItem3.Img = ((System.Drawing.Image)(resources.GetObject("carouselItem3.Img")));
            carouselItem4.Img = ((System.Drawing.Image)(resources.GetObject("carouselItem4.Img")));
            carouselItem5.Img = ((System.Drawing.Image)(resources.GetObject("carouselItem5.Img")));
            carouselItem6.Img = ((System.Drawing.Image)(resources.GetObject("carouselItem6.Img")));
            carouselItem7.Img = ((System.Drawing.Image)(resources.GetObject("carouselItem7.Img")));
            this.Weekday_pic.Image.Add(carouselItem1);
            this.Weekday_pic.Image.Add(carouselItem2);
            this.Weekday_pic.Image.Add(carouselItem3);
            this.Weekday_pic.Image.Add(carouselItem4);
            this.Weekday_pic.Image.Add(carouselItem5);
            this.Weekday_pic.Image.Add(carouselItem6);
            this.Weekday_pic.Image.Add(carouselItem7);
            this.Weekday_pic.Location = new System.Drawing.Point(2, 123);
            this.Weekday_pic.Name = "Weekday_pic";
            this.Weekday_pic.Size = new System.Drawing.Size(686, 943);
            this.Weekday_pic.TabIndex = 33;
            this.Weekday_pic.Text = "carousel1";
            // 
            // HelloLabel
            // 
            this.HelloLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HelloLabel.Font = new System.Drawing.Font("黑体", 25.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HelloLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.HelloLabel.Location = new System.Drawing.Point(2, 2);
            this.HelloLabel.Name = "HelloLabel";
            this.HelloLabel.Size = new System.Drawing.Size(686, 121);
            this.HelloLabel.TabIndex = 32;
            this.HelloLabel.Text = "早上好，管理员";
            this.HelloLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BadgeOffsetY = 0;
            this.panel1.Controls.Add(this.image3D1);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(531, 1068);
            this.panel1.TabIndex = 34;
            this.panel1.Text = "panel1";
            // 
            // image3D1
            // 
            this.image3D1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.image3D1.Image = ((System.Drawing.Image)(resources.GetObject("image3D1.Image")));
            this.image3D1.Location = new System.Drawing.Point(0, 0);
            this.image3D1.Name = "image3D1";
            this.image3D1.Size = new System.Drawing.Size(531, 534);
            this.image3D1.TabIndex = 35;
            this.image3D1.Text = "image3D1";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.uiLabel1);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.rate1);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.rate2);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.rate3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 534);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(531, 534);
            this.flowLayoutPanel1.TabIndex = 33;
            // 
            // uiLabel1
            // 
            this.uiLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uiLabel1.Font = new System.Drawing.Font("隶书", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel1.Location = new System.Drawing.Point(3, 0);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(528, 124);
            this.uiLabel1.TabIndex = 33;
            this.uiLabel1.Text = "工作状态自评";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(510, 37);
            this.label2.TabIndex = 34;
            this.label2.Text = "专注度";
            this.label2.TooltipConfig = null;
            // 
            // rate1
            // 
            this.rate1.AllowClear = true;
            this.rate1.AllowHalf = true;
            this.rate1.Character = "⚪";
            this.rate1.Fill = System.Drawing.Color.DeepSkyBlue;
            this.rate1.Location = new System.Drawing.Point(3, 170);
            this.rate1.Name = "rate1";
            this.rate1.Size = new System.Drawing.Size(510, 85);
            this.rate1.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 261);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(510, 37);
            this.label1.TabIndex = 34;
            this.label1.Text = "服务热情";
            this.label1.TooltipConfig = null;
            // 
            // rate2
            // 
            this.rate2.AllowClear = true;
            this.rate2.AllowHalf = true;
            this.rate2.Character = "⚪";
            this.rate2.Fill = System.Drawing.Color.DeepSkyBlue;
            this.rate2.Location = new System.Drawing.Point(3, 304);
            this.rate2.Name = "rate2";
            this.rate2.Size = new System.Drawing.Size(510, 85);
            this.rate2.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(3, 395);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(510, 37);
            this.label3.TabIndex = 34;
            this.label3.Text = "工作效率";
            this.label3.TooltipConfig = null;
            // 
            // rate3
            // 
            this.rate3.AllowClear = true;
            this.rate3.AllowHalf = true;
            this.rate3.Character = "⚪";
            this.rate3.Fill = System.Drawing.Color.DeepSkyBlue;
            this.rate3.Location = new System.Drawing.Point(3, 438);
            this.rate3.Name = "rate3";
            this.rate3.Size = new System.Drawing.Size(510, 85);
            this.rate3.TabIndex = 32;
            // 
            // uiListBox1
            // 
            this.uiListBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiListBox1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.uiListBox1.ItemSelectForeColor = System.Drawing.Color.White;
            this.uiListBox1.Location = new System.Drawing.Point(-266, -155);
            this.uiListBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiListBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiListBox1.Name = "uiListBox1";
            this.uiListBox1.Padding = new System.Windows.Forms.Padding(2);
            this.uiListBox1.ShowText = false;
            this.uiListBox1.Size = new System.Drawing.Size(270, 180);
            this.uiListBox1.TabIndex = 30;
            this.uiListBox1.Text = "uiListBox1";
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.ZongZhi);
            this.uiPanel1.Controls.Add(this.Step_ZZ);
            this.uiPanel1.Controls.Add(this.calendar1);
            this.uiPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.uiPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.uiPanel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel1.Location = new System.Drawing.Point(1221, 0);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.RectColor = System.Drawing.Color.Transparent;
            this.uiPanel1.Size = new System.Drawing.Size(676, 1068);
            this.uiPanel1.TabIndex = 14;
            this.uiPanel1.Text = null;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ZongZhi
            // 
            this.ZongZhi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ZongZhi.Font = new System.Drawing.Font("方正舒体", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ZongZhi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ZongZhi.Location = new System.Drawing.Point(0, 868);
            this.ZongZhi.Name = "ZongZhi";
            this.ZongZhi.Size = new System.Drawing.Size(676, 98);
            this.ZongZhi.TabIndex = 6;
            this.ZongZhi.Text = "我们的宗旨";
            this.ZongZhi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Step_ZZ
            // 
            this.Step_ZZ.BackColor = System.Drawing.Color.Transparent;
            this.Step_ZZ.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Step_ZZ.Current = 4;
            this.Step_ZZ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Step_ZZ.Font = new System.Drawing.Font("宋体", 9F);
            this.Step_ZZ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(177)))), ((int)(((byte)(238)))));
            stepsItem1.Title = "活力";
            stepsItem2.Title = "塑性";
            stepsItem3.Title = "专业";
            stepsItem4.Title = "健康";
            this.Step_ZZ.Items.Add(stepsItem1);
            this.Step_ZZ.Items.Add(stepsItem2);
            this.Step_ZZ.Items.Add(stepsItem3);
            this.Step_ZZ.Items.Add(stepsItem4);
            this.Step_ZZ.Location = new System.Drawing.Point(0, 966);
            this.Step_ZZ.Name = "Step_ZZ";
            this.Step_ZZ.Size = new System.Drawing.Size(676, 102);
            this.Step_ZZ.Status = AntdUI.TStepState.Wait;
            this.Step_ZZ.TabIndex = 5;
            this.Step_ZZ.Text = "steps1";
            // 
            // calendar1
            // 
            this.calendar1.BackColor = System.Drawing.Color.Black;
            this.calendar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.calendar1.Location = new System.Drawing.Point(0, 0);
            this.calendar1.Name = "calendar1";
            this.calendar1.Radius = 0;
            this.calendar1.ShowChinese = true;
            this.calendar1.Size = new System.Drawing.Size(676, 868);
            this.calendar1.TabIndex = 0;
            this.calendar1.Text = "calendar1";
            this.calendar1.Value = new System.DateTime(2024, 10, 1, 0, 0, 0, 0);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel14);
            this.tabPage2.Controls.Add(this.panel13);
            this.tabPage2.Controls.Add(this.panel12);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1897, 1068);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "管理员信息";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.AdminTable);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel14.Location = new System.Drawing.Point(0, 161);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(1897, 872);
            this.panel14.TabIndex = 12;
            this.panel14.Text = "panel14";
            // 
            // AdminTable
            // 
            this.AdminTable.AllowDrop = true;
            this.AdminTable.AutoSizeColumnsMode = AntdUI.ColumnsMode.Fill;
            this.AdminTable.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.AdminTable.Bordered = true;
            this.AdminTable.ColumnBack = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(183)))), ((int)(((byte)(255)))));
            this.AdminTable.ColumnFont = new System.Drawing.Font("楷体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AdminTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AdminTable.EditMode = AntdUI.TEditMode.Click;
            this.AdminTable.EmptyHeader = true;
            this.AdminTable.EmptyText = "";
            this.AdminTable.Location = new System.Drawing.Point(0, 0);
            this.AdminTable.Name = "AdminTable";
            this.AdminTable.RowSelectedBg = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.AdminTable.RowSelectedFore = System.Drawing.Color.Black;
            this.AdminTable.Size = new System.Drawing.Size(1897, 872);
            this.AdminTable.TabIndex = 10;
            this.AdminTable.Text = "table1";
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.uiPagination1);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel13.Location = new System.Drawing.Point(0, 1033);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(1897, 35);
            this.panel13.TabIndex = 11;
            this.panel13.Text = "panel13";
            // 
            // uiPagination1
            // 
            this.uiPagination1.ButtonFillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(204)))));
            this.uiPagination1.ButtonStyleInherited = false;
            this.uiPagination1.DataSource = this.adminBindingSource;
            this.uiPagination1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPagination1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPagination1.Location = new System.Drawing.Point(0, 0);
            this.uiPagination1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPagination1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPagination1.Name = "uiPagination1";
            this.uiPagination1.PageSize = 9;
            this.uiPagination1.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiPagination1.ShowText = false;
            this.uiPagination1.Size = new System.Drawing.Size(1897, 35);
            this.uiPagination1.TabIndex = 10;
            this.uiPagination1.Text = "uiPagination1";
            this.uiPagination1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPagination1.TotalCount = 0;
            this.uiPagination1.PageChanged += new Sunny.UI.UIPagination.OnPageChangeEventHandler(this.uiPagination1_ActivePageChanged);
            // 
            // adminBindingSource
            // 
            this.adminBindingSource.DataMember = "Admin";
            this.adminBindingSource.DataSource = this.gMSdataset;
            this.adminBindingSource.Filter = "";
            this.adminBindingSource.Sort = "用户名 ASC";
            // 
            // gMSdataset
            // 
            this.gMSdataset.DataSetName = "GMSdataset";
            this.gMSdataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel12
            // 
            this.panel12.Back = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.panel12.BackColor = System.Drawing.Color.Gainsboro;
            this.panel12.Controls.Add(this.deleteAdmin);
            this.panel12.Controls.Add(this.VerityAddAdmin);
            this.panel12.Controls.Add(this.AddAdmin);
            this.panel12.Controls.Add(this.AlterAdmin);
            this.panel12.Controls.Add(this.panel16);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Radius = 0;
            this.panel12.Size = new System.Drawing.Size(1897, 161);
            this.panel12.TabIndex = 1;
            this.panel12.Text = "panel12";
            // 
            // deleteAdmin
            // 
            this.deleteAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.deleteAdmin.BadgeOffsetX = 0;
            this.deleteAdmin.BadgeOffsetY = 0;
            this.deleteAdmin.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.deleteAdmin.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deleteAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.deleteAdmin.Location = new System.Drawing.Point(1238, 83);
            this.deleteAdmin.Name = "deleteAdmin";
            this.deleteAdmin.Radius = 5;
            this.deleteAdmin.Size = new System.Drawing.Size(168, 57);
            this.deleteAdmin.TabIndex = 49;
            this.deleteAdmin.Text = "删除";
            this.deleteAdmin.WaveSize = 0;
            this.deleteAdmin.Click += new System.EventHandler(this.deleteAdmin_Click);
            // 
            // VerityAddAdmin
            // 
            this.VerityAddAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.VerityAddAdmin.BadgeOffsetX = 0;
            this.VerityAddAdmin.BadgeOffsetY = 0;
            this.VerityAddAdmin.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.VerityAddAdmin.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.VerityAddAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.VerityAddAdmin.Location = new System.Drawing.Point(1693, 80);
            this.VerityAddAdmin.Name = "VerityAddAdmin";
            this.VerityAddAdmin.Radius = 5;
            this.VerityAddAdmin.Size = new System.Drawing.Size(169, 60);
            this.VerityAddAdmin.TabIndex = 50;
            this.VerityAddAdmin.Text = "确认添加";
            this.VerityAddAdmin.Visible = false;
            this.VerityAddAdmin.WaveSize = 0;
            this.VerityAddAdmin.Click += new System.EventHandler(this.VerityAddAdmin_Click);
            // 
            // AddAdmin
            // 
            this.AddAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.AddAdmin.BadgeOffsetX = 0;
            this.AddAdmin.BadgeOffsetY = 0;
            this.AddAdmin.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.AddAdmin.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AddAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.AddAdmin.Location = new System.Drawing.Point(1465, 80);
            this.AddAdmin.Name = "AddAdmin";
            this.AddAdmin.Radius = 5;
            this.AddAdmin.Size = new System.Drawing.Size(169, 60);
            this.AddAdmin.TabIndex = 50;
            this.AddAdmin.Text = "新增";
            this.AddAdmin.WaveSize = 0;
            this.AddAdmin.Click += new System.EventHandler(this.AddAdmin_Click);
            // 
            // AlterAdmin
            // 
            this.AlterAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.AlterAdmin.BadgeOffsetX = 0;
            this.AlterAdmin.BadgeOffsetY = 0;
            this.AlterAdmin.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.AlterAdmin.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AlterAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.AlterAdmin.Location = new System.Drawing.Point(1693, 80);
            this.AlterAdmin.Name = "AlterAdmin";
            this.AlterAdmin.Radius = 5;
            this.AlterAdmin.Size = new System.Drawing.Size(169, 60);
            this.AlterAdmin.TabIndex = 51;
            this.AlterAdmin.Text = "修改";
            this.AlterAdmin.WaveSize = 0;
            this.AlterAdmin.Click += new System.EventHandler(this.AlterAdmin_Click);
            // 
            // panel16
            // 
            this.panel16.Back = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel16.Controls.Add(this.button4);
            this.panel16.Controls.Add(this.label4);
            this.panel16.Controls.Add(this.label5);
            this.panel16.Controls.Add(this.label6);
            this.panel16.Controls.Add(this.SearchAdminByname);
            this.panel16.Controls.Add(this.SearchAdminByid);
            this.panel16.Controls.Add(this.SearchAdminByphone);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel16.Location = new System.Drawing.Point(0, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(1897, 74);
            this.panel16.TabIndex = 47;
            this.panel16.Text = "panel16";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.button4.BadgeOffsetX = 0;
            this.button4.BadgeOffsetY = 0;
            this.button4.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.button4.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button4.Location = new System.Drawing.Point(1693, 9);
            this.button4.Name = "button4";
            this.button4.Radius = 5;
            this.button4.Size = new System.Drawing.Size(169, 59);
            this.button4.TabIndex = 48;
            this.button4.Text = "搜索";
            this.button4.WaveSize = 0;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(588, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 70);
            this.label4.TabIndex = 47;
            this.label4.Text = "姓名:";
            this.label4.TooltipConfig = null;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(1112, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 70);
            this.label5.TabIndex = 47;
            this.label5.Text = "手机号:";
            this.label5.TooltipConfig = null;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(36, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 63);
            this.label6.TabIndex = 47;
            this.label6.Text = "用户名:";
            this.label6.TooltipConfig = null;
            // 
            // SearchAdminByname
            // 
            this.SearchAdminByname.Location = new System.Drawing.Point(680, 0);
            this.SearchAdminByname.Name = "SearchAdminByname";
            this.SearchAdminByname.PlaceholderText = "请输入";
            this.SearchAdminByname.Size = new System.Drawing.Size(391, 70);
            this.SearchAdminByname.TabIndex = 48;
            // 
            // SearchAdminByid
            // 
            this.SearchAdminByid.Location = new System.Drawing.Point(158, 0);
            this.SearchAdminByid.Name = "SearchAdminByid";
            this.SearchAdminByid.PlaceholderText = "请输入";
            this.SearchAdminByid.Size = new System.Drawing.Size(358, 70);
            this.SearchAdminByid.TabIndex = 48;
            // 
            // SearchAdminByphone
            // 
            this.SearchAdminByphone.Location = new System.Drawing.Point(1238, 3);
            this.SearchAdminByphone.Name = "SearchAdminByphone";
            this.SearchAdminByphone.PlaceholderText = "请输入";
            this.SearchAdminByphone.Size = new System.Drawing.Size(421, 65);
            this.SearchAdminByphone.TabIndex = 48;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.UserTable);
            this.tabPage4.Controls.Add(this.panel20);
            this.tabPage4.Controls.Add(this.panel15);
            this.tabPage4.Location = new System.Drawing.Point(0, 40);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1897, 1028);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "用户信息";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // UserTable
            // 
            this.UserTable.AllowDrop = true;
            this.UserTable.AutoSizeColumnsMode = AntdUI.ColumnsMode.Fill;
            this.UserTable.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.UserTable.Bordered = true;
            this.UserTable.ColumnBack = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(183)))), ((int)(((byte)(255)))));
            this.UserTable.ColumnFont = new System.Drawing.Font("楷体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserTable.EditMode = AntdUI.TEditMode.Click;
            this.UserTable.EmptyHeader = true;
            this.UserTable.EmptyText = "";
            this.UserTable.Location = new System.Drawing.Point(0, 161);
            this.UserTable.Name = "UserTable";
            this.UserTable.RowSelectedBg = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.UserTable.RowSelectedFore = System.Drawing.Color.Black;
            this.UserTable.Size = new System.Drawing.Size(1897, 832);
            this.UserTable.TabIndex = 13;
            this.UserTable.Text = "table1";
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.UserPagination);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel20.Location = new System.Drawing.Point(0, 993);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(1897, 35);
            this.panel20.TabIndex = 12;
            this.panel20.Text = "panel20";
            // 
            // UserPagination
            // 
            this.UserPagination.ButtonFillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(204)))));
            this.UserPagination.ButtonStyleInherited = false;
            this.UserPagination.DataSource = this.adminBindingSource;
            this.UserPagination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserPagination.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserPagination.Location = new System.Drawing.Point(0, 0);
            this.UserPagination.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UserPagination.MinimumSize = new System.Drawing.Size(1, 1);
            this.UserPagination.Name = "UserPagination";
            this.UserPagination.PageSize = 9;
            this.UserPagination.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.UserPagination.ShowText = false;
            this.UserPagination.Size = new System.Drawing.Size(1897, 35);
            this.UserPagination.TabIndex = 10;
            this.UserPagination.Text = "uiPagination2";
            this.UserPagination.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.UserPagination.TotalCount = 0;
            this.UserPagination.PageChanged += new Sunny.UI.UIPagination.OnPageChangeEventHandler(this.UserPagination_ActivePageChanged);
            // 
            // panel15
            // 
            this.panel15.Back = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.panel15.BackColor = System.Drawing.Color.Gainsboro;
            this.panel15.Controls.Add(this.VerityAddUser);
            this.panel15.Controls.Add(this.deleteUser);
            this.panel15.Controls.Add(this.AddUser);
            this.panel15.Controls.Add(this.AlterUser);
            this.panel15.Controls.Add(this.panel17);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel15.Location = new System.Drawing.Point(0, 0);
            this.panel15.Name = "panel15";
            this.panel15.Radius = 0;
            this.panel15.Size = new System.Drawing.Size(1897, 161);
            this.panel15.TabIndex = 2;
            this.panel15.Text = "panel15";
            // 
            // VerityAddUser
            // 
            this.VerityAddUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.VerityAddUser.BadgeOffsetX = 0;
            this.VerityAddUser.BadgeOffsetY = 0;
            this.VerityAddUser.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.VerityAddUser.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.VerityAddUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.VerityAddUser.Location = new System.Drawing.Point(1693, 83);
            this.VerityAddUser.Name = "VerityAddUser";
            this.VerityAddUser.Radius = 5;
            this.VerityAddUser.Size = new System.Drawing.Size(169, 60);
            this.VerityAddUser.TabIndex = 51;
            this.VerityAddUser.Text = "确认添加";
            this.VerityAddUser.Visible = false;
            this.VerityAddUser.WaveSize = 0;
            this.VerityAddUser.Click += new System.EventHandler(this.VerityAddUser_Click);
            // 
            // deleteUser
            // 
            this.deleteUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.deleteUser.BadgeOffsetX = 0;
            this.deleteUser.BadgeOffsetY = 0;
            this.deleteUser.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.deleteUser.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deleteUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.deleteUser.Location = new System.Drawing.Point(1238, 83);
            this.deleteUser.Name = "deleteUser";
            this.deleteUser.Radius = 5;
            this.deleteUser.Size = new System.Drawing.Size(168, 57);
            this.deleteUser.TabIndex = 49;
            this.deleteUser.Text = "删除";
            this.deleteUser.WaveSize = 0;
            this.deleteUser.Click += new System.EventHandler(this.deleteUser_Click);
            // 
            // AddUser
            // 
            this.AddUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.AddUser.BadgeOffsetX = 0;
            this.AddUser.BadgeOffsetY = 0;
            this.AddUser.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.AddUser.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AddUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.AddUser.Location = new System.Drawing.Point(1473, 80);
            this.AddUser.Name = "AddUser";
            this.AddUser.Radius = 5;
            this.AddUser.Size = new System.Drawing.Size(169, 60);
            this.AddUser.TabIndex = 50;
            this.AddUser.Text = "新增";
            this.AddUser.WaveSize = 0;
            this.AddUser.Click += new System.EventHandler(this.AddUser_Click);
            // 
            // AlterUser
            // 
            this.AlterUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.AlterUser.BadgeOffsetX = 0;
            this.AlterUser.BadgeOffsetY = 0;
            this.AlterUser.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.AlterUser.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AlterUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.AlterUser.Location = new System.Drawing.Point(1693, 83);
            this.AlterUser.Name = "AlterUser";
            this.AlterUser.Radius = 5;
            this.AlterUser.Size = new System.Drawing.Size(158, 59);
            this.AlterUser.TabIndex = 51;
            this.AlterUser.Text = "修改";
            this.AlterUser.WaveSize = 0;
            this.AlterUser.Click += new System.EventHandler(this.AlterUser_Click);
            // 
            // panel17
            // 
            this.panel17.Back = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel17.Controls.Add(this.SearchUser);
            this.panel17.Controls.Add(this.label7);
            this.panel17.Controls.Add(this.label8);
            this.panel17.Controls.Add(this.label9);
            this.panel17.Controls.Add(this.SearchUserByname);
            this.panel17.Controls.Add(this.SearchUserByid);
            this.panel17.Controls.Add(this.SearchUserByphone);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel17.Location = new System.Drawing.Point(0, 0);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(1897, 74);
            this.panel17.TabIndex = 47;
            this.panel17.Text = "panel17";
            // 
            // SearchUser
            // 
            this.SearchUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.SearchUser.BadgeOffsetX = 0;
            this.SearchUser.BadgeOffsetY = 0;
            this.SearchUser.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.SearchUser.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SearchUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.SearchUser.Location = new System.Drawing.Point(1693, 9);
            this.SearchUser.Name = "SearchUser";
            this.SearchUser.Radius = 5;
            this.SearchUser.Size = new System.Drawing.Size(169, 59);
            this.SearchUser.TabIndex = 48;
            this.SearchUser.Text = "搜索";
            this.SearchUser.WaveSize = 0;
            this.SearchUser.Click += new System.EventHandler(this.SearchUser_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label7.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(588, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 70);
            this.label7.TabIndex = 47;
            this.label7.Text = "姓名:";
            this.label7.TooltipConfig = null;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label8.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(1112, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 70);
            this.label8.TabIndex = 47;
            this.label8.Text = "手机号:";
            this.label8.TooltipConfig = null;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label9.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(36, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 63);
            this.label9.TabIndex = 47;
            this.label9.Text = "用户名:";
            this.label9.TooltipConfig = null;
            // 
            // SearchUserByname
            // 
            this.SearchUserByname.Location = new System.Drawing.Point(680, 0);
            this.SearchUserByname.Name = "SearchUserByname";
            this.SearchUserByname.PlaceholderText = "请输入";
            this.SearchUserByname.Size = new System.Drawing.Size(391, 70);
            this.SearchUserByname.TabIndex = 48;
            // 
            // SearchUserByid
            // 
            this.SearchUserByid.Location = new System.Drawing.Point(158, 0);
            this.SearchUserByid.Name = "SearchUserByid";
            this.SearchUserByid.PlaceholderText = "请输入";
            this.SearchUserByid.Size = new System.Drawing.Size(358, 70);
            this.SearchUserByid.TabIndex = 48;
            // 
            // SearchUserByphone
            // 
            this.SearchUserByphone.Location = new System.Drawing.Point(1238, 3);
            this.SearchUserByphone.Name = "SearchUserByphone";
            this.SearchUserByphone.PlaceholderText = "请输入";
            this.SearchUserByphone.Size = new System.Drawing.Size(421, 65);
            this.SearchUserByphone.TabIndex = 48;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.CoachTable);
            this.tabPage5.Controls.Add(this.panel21);
            this.tabPage5.Controls.Add(this.panel18);
            this.tabPage5.Location = new System.Drawing.Point(0, 0);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1897, 1068);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "教练信息";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // CoachTable
            // 
            this.CoachTable.AllowDrop = true;
            this.CoachTable.AutoSizeColumnsMode = AntdUI.ColumnsMode.Fill;
            this.CoachTable.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CoachTable.Bordered = true;
            this.CoachTable.ColumnBack = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(183)))), ((int)(((byte)(255)))));
            this.CoachTable.ColumnFont = new System.Drawing.Font("楷体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CoachTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CoachTable.EditMode = AntdUI.TEditMode.Click;
            this.CoachTable.EmptyHeader = true;
            this.CoachTable.EmptyText = "";
            this.CoachTable.Location = new System.Drawing.Point(0, 161);
            this.CoachTable.Name = "CoachTable";
            this.CoachTable.RowSelectedBg = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.CoachTable.RowSelectedFore = System.Drawing.Color.Black;
            this.CoachTable.Size = new System.Drawing.Size(1897, 872);
            this.CoachTable.TabIndex = 13;
            this.CoachTable.Text = "table1";
            // 
            // panel21
            // 
            this.panel21.Controls.Add(this.CoachPagination);
            this.panel21.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel21.Location = new System.Drawing.Point(0, 1033);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(1897, 35);
            this.panel21.TabIndex = 12;
            this.panel21.Text = "panel21";
            // 
            // CoachPagination
            // 
            this.CoachPagination.ButtonFillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(204)))));
            this.CoachPagination.ButtonStyleInherited = false;
            this.CoachPagination.DataSource = this.adminBindingSource;
            this.CoachPagination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CoachPagination.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CoachPagination.Location = new System.Drawing.Point(0, 0);
            this.CoachPagination.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CoachPagination.MinimumSize = new System.Drawing.Size(1, 1);
            this.CoachPagination.Name = "CoachPagination";
            this.CoachPagination.PageSize = 9;
            this.CoachPagination.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.CoachPagination.ShowText = false;
            this.CoachPagination.Size = new System.Drawing.Size(1897, 35);
            this.CoachPagination.TabIndex = 10;
            this.CoachPagination.Text = "uiPagination3";
            this.CoachPagination.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.CoachPagination.TotalCount = 0;
            this.CoachPagination.PageChanged += new Sunny.UI.UIPagination.OnPageChangeEventHandler(this.CoachPagination_ActivePageChanged);
            // 
            // panel18
            // 
            this.panel18.Back = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.panel18.BackColor = System.Drawing.Color.Gainsboro;
            this.panel18.Controls.Add(this.VerityAddCoach);
            this.panel18.Controls.Add(this.deleteCoach);
            this.panel18.Controls.Add(this.AddCoach);
            this.panel18.Controls.Add(this.AlterCoach);
            this.panel18.Controls.Add(this.panel19);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel18.Location = new System.Drawing.Point(0, 0);
            this.panel18.Name = "panel18";
            this.panel18.Radius = 0;
            this.panel18.Size = new System.Drawing.Size(1897, 161);
            this.panel18.TabIndex = 2;
            this.panel18.Text = "panel18";
            // 
            // VerityAddCoach
            // 
            this.VerityAddCoach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.VerityAddCoach.BadgeOffsetX = 0;
            this.VerityAddCoach.BadgeOffsetY = 0;
            this.VerityAddCoach.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.VerityAddCoach.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.VerityAddCoach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.VerityAddCoach.Location = new System.Drawing.Point(1693, 80);
            this.VerityAddCoach.Name = "VerityAddCoach";
            this.VerityAddCoach.Radius = 5;
            this.VerityAddCoach.Size = new System.Drawing.Size(169, 60);
            this.VerityAddCoach.TabIndex = 52;
            this.VerityAddCoach.Text = "确认添加";
            this.VerityAddCoach.Visible = false;
            this.VerityAddCoach.WaveSize = 0;
            this.VerityAddCoach.Click += new System.EventHandler(this.VerityAddCoach_Click);
            // 
            // deleteCoach
            // 
            this.deleteCoach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.deleteCoach.BadgeOffsetX = 0;
            this.deleteCoach.BadgeOffsetY = 0;
            this.deleteCoach.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.deleteCoach.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deleteCoach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.deleteCoach.Location = new System.Drawing.Point(1238, 83);
            this.deleteCoach.Name = "deleteCoach";
            this.deleteCoach.Radius = 5;
            this.deleteCoach.Size = new System.Drawing.Size(168, 57);
            this.deleteCoach.TabIndex = 49;
            this.deleteCoach.Text = "删除";
            this.deleteCoach.WaveSize = 0;
            this.deleteCoach.Click += new System.EventHandler(this.deleteCoach_Click);
            // 
            // AddCoach
            // 
            this.AddCoach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.AddCoach.BadgeOffsetX = 0;
            this.AddCoach.BadgeOffsetY = 0;
            this.AddCoach.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.AddCoach.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AddCoach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.AddCoach.Location = new System.Drawing.Point(1468, 80);
            this.AddCoach.Name = "AddCoach";
            this.AddCoach.Radius = 5;
            this.AddCoach.Size = new System.Drawing.Size(169, 60);
            this.AddCoach.TabIndex = 50;
            this.AddCoach.Text = "新增";
            this.AddCoach.WaveSize = 0;
            this.AddCoach.Click += new System.EventHandler(this.AddCoach_Click);
            // 
            // AlterCoach
            // 
            this.AlterCoach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.AlterCoach.BadgeOffsetX = 0;
            this.AlterCoach.BadgeOffsetY = 0;
            this.AlterCoach.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.AlterCoach.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AlterCoach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.AlterCoach.Location = new System.Drawing.Point(1693, 83);
            this.AlterCoach.Name = "AlterCoach";
            this.AlterCoach.Radius = 5;
            this.AlterCoach.Size = new System.Drawing.Size(158, 59);
            this.AlterCoach.TabIndex = 51;
            this.AlterCoach.Text = "修改";
            this.AlterCoach.WaveSize = 0;
            this.AlterCoach.Click += new System.EventHandler(this.AlterCoach_Click);
            // 
            // panel19
            // 
            this.panel19.Back = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel19.Controls.Add(this.SearchCoach);
            this.panel19.Controls.Add(this.label10);
            this.panel19.Controls.Add(this.label11);
            this.panel19.Controls.Add(this.label12);
            this.panel19.Controls.Add(this.SearchCoachByname);
            this.panel19.Controls.Add(this.SearchCoachByid);
            this.panel19.Controls.Add(this.SearchCoachByphone);
            this.panel19.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel19.Location = new System.Drawing.Point(0, 0);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(1897, 74);
            this.panel19.TabIndex = 47;
            this.panel19.Text = "panel19";
            // 
            // SearchCoach
            // 
            this.SearchCoach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.SearchCoach.BadgeOffsetX = 0;
            this.SearchCoach.BadgeOffsetY = 0;
            this.SearchCoach.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.SearchCoach.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SearchCoach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.SearchCoach.Location = new System.Drawing.Point(1693, 9);
            this.SearchCoach.Name = "SearchCoach";
            this.SearchCoach.Radius = 5;
            this.SearchCoach.Size = new System.Drawing.Size(169, 59);
            this.SearchCoach.TabIndex = 48;
            this.SearchCoach.Text = "搜索";
            this.SearchCoach.WaveSize = 0;
            this.SearchCoach.Click += new System.EventHandler(this.SearchCoach_Click);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label10.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(588, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 70);
            this.label10.TabIndex = 47;
            this.label10.Text = "姓名:";
            this.label10.TooltipConfig = null;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label11.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(1112, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(120, 70);
            this.label11.TabIndex = 47;
            this.label11.Text = "手机号:";
            this.label11.TooltipConfig = null;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label12.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(36, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 63);
            this.label12.TabIndex = 47;
            this.label12.Text = "用户名:";
            this.label12.TooltipConfig = null;
            // 
            // SearchCoachByname
            // 
            this.SearchCoachByname.Location = new System.Drawing.Point(680, 0);
            this.SearchCoachByname.Name = "SearchCoachByname";
            this.SearchCoachByname.PlaceholderText = "请输入";
            this.SearchCoachByname.Size = new System.Drawing.Size(391, 70);
            this.SearchCoachByname.TabIndex = 48;
            // 
            // SearchCoachByid
            // 
            this.SearchCoachByid.Location = new System.Drawing.Point(158, 0);
            this.SearchCoachByid.Name = "SearchCoachByid";
            this.SearchCoachByid.PlaceholderText = "请输入";
            this.SearchCoachByid.Size = new System.Drawing.Size(358, 70);
            this.SearchCoachByid.TabIndex = 48;
            // 
            // SearchCoachByphone
            // 
            this.SearchCoachByphone.Location = new System.Drawing.Point(1238, 3);
            this.SearchCoachByphone.Name = "SearchCoachByphone";
            this.SearchCoachByphone.PlaceholderText = "请输入";
            this.SearchCoachByphone.Size = new System.Drawing.Size(421, 65);
            this.SearchCoachByphone.TabIndex = 48;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.CourseTable);
            this.tabPage6.Controls.Add(this.panel37);
            this.tabPage6.Controls.Add(this.panel35);
            this.tabPage6.Location = new System.Drawing.Point(0, 0);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1897, 1068);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "课程信息";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // CourseTable
            // 
            this.CourseTable.AllowDrop = true;
            this.CourseTable.AutoSizeColumnsMode = AntdUI.ColumnsMode.Fill;
            this.CourseTable.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CourseTable.Bordered = true;
            this.CourseTable.ColumnBack = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(183)))), ((int)(((byte)(255)))));
            this.CourseTable.ColumnFont = new System.Drawing.Font("楷体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CourseTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CourseTable.EditMode = AntdUI.TEditMode.Click;
            this.CourseTable.EmptyHeader = true;
            this.CourseTable.EmptyText = "";
            this.CourseTable.Location = new System.Drawing.Point(0, 161);
            this.CourseTable.Name = "CourseTable";
            this.CourseTable.RowSelectedBg = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.CourseTable.RowSelectedFore = System.Drawing.Color.Black;
            this.CourseTable.Size = new System.Drawing.Size(1897, 872);
            this.CourseTable.TabIndex = 14;
            this.CourseTable.Text = "table1";
            // 
            // panel37
            // 
            this.panel37.Controls.Add(this.CoursePagination);
            this.panel37.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel37.Location = new System.Drawing.Point(0, 1033);
            this.panel37.Name = "panel37";
            this.panel37.Size = new System.Drawing.Size(1897, 35);
            this.panel37.TabIndex = 13;
            this.panel37.Text = "panel37";
            // 
            // CoursePagination
            // 
            this.CoursePagination.ButtonFillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(204)))));
            this.CoursePagination.ButtonStyleInherited = false;
            this.CoursePagination.DataSource = this.adminBindingSource;
            this.CoursePagination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CoursePagination.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CoursePagination.Location = new System.Drawing.Point(0, 0);
            this.CoursePagination.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CoursePagination.MinimumSize = new System.Drawing.Size(1, 1);
            this.CoursePagination.Name = "CoursePagination";
            this.CoursePagination.PageSize = 9;
            this.CoursePagination.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.CoursePagination.ShowText = false;
            this.CoursePagination.Size = new System.Drawing.Size(1897, 35);
            this.CoursePagination.TabIndex = 10;
            this.CoursePagination.Text = "uiPagination3";
            this.CoursePagination.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.CoursePagination.TotalCount = 0;
            this.CoursePagination.PageChanged += new Sunny.UI.UIPagination.OnPageChangeEventHandler(this.CoursePagination_ActivePageChanged);
            // 
            // panel35
            // 
            this.panel35.Back = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.panel35.BackColor = System.Drawing.Color.Gainsboro;
            this.panel35.Controls.Add(this.VerityAddCourse);
            this.panel35.Controls.Add(this.deleteCourse);
            this.panel35.Controls.Add(this.AddCourse);
            this.panel35.Controls.Add(this.AlterCourse);
            this.panel35.Controls.Add(this.panel36);
            this.panel35.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel35.Location = new System.Drawing.Point(0, 0);
            this.panel35.Name = "panel35";
            this.panel35.Radius = 0;
            this.panel35.Size = new System.Drawing.Size(1897, 161);
            this.panel35.TabIndex = 3;
            this.panel35.Text = "panel35";
            // 
            // VerityAddCourse
            // 
            this.VerityAddCourse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.VerityAddCourse.BadgeOffsetX = 0;
            this.VerityAddCourse.BadgeOffsetY = 0;
            this.VerityAddCourse.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.VerityAddCourse.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.VerityAddCourse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.VerityAddCourse.Location = new System.Drawing.Point(1693, 80);
            this.VerityAddCourse.Name = "VerityAddCourse";
            this.VerityAddCourse.Radius = 5;
            this.VerityAddCourse.Size = new System.Drawing.Size(169, 60);
            this.VerityAddCourse.TabIndex = 52;
            this.VerityAddCourse.Text = "确认添加";
            this.VerityAddCourse.Visible = false;
            this.VerityAddCourse.WaveSize = 0;
            this.VerityAddCourse.Click += new System.EventHandler(this.VerityAddCourse_Click);
            // 
            // deleteCourse
            // 
            this.deleteCourse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.deleteCourse.BadgeOffsetX = 0;
            this.deleteCourse.BadgeOffsetY = 0;
            this.deleteCourse.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.deleteCourse.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deleteCourse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.deleteCourse.Location = new System.Drawing.Point(1238, 83);
            this.deleteCourse.Name = "deleteCourse";
            this.deleteCourse.Radius = 5;
            this.deleteCourse.Size = new System.Drawing.Size(168, 57);
            this.deleteCourse.TabIndex = 49;
            this.deleteCourse.Text = "删除";
            this.deleteCourse.WaveSize = 0;
            this.deleteCourse.Click += new System.EventHandler(this.deleteCourse_Click);
            // 
            // AddCourse
            // 
            this.AddCourse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.AddCourse.BadgeOffsetX = 0;
            this.AddCourse.BadgeOffsetY = 0;
            this.AddCourse.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.AddCourse.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AddCourse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.AddCourse.Location = new System.Drawing.Point(1468, 80);
            this.AddCourse.Name = "AddCourse";
            this.AddCourse.Radius = 5;
            this.AddCourse.Size = new System.Drawing.Size(169, 60);
            this.AddCourse.TabIndex = 50;
            this.AddCourse.Text = "新增";
            this.AddCourse.WaveSize = 0;
            this.AddCourse.Click += new System.EventHandler(this.AddCourse_Click);
            // 
            // AlterCourse
            // 
            this.AlterCourse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.AlterCourse.BadgeOffsetX = 0;
            this.AlterCourse.BadgeOffsetY = 0;
            this.AlterCourse.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.AlterCourse.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AlterCourse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.AlterCourse.Location = new System.Drawing.Point(1693, 83);
            this.AlterCourse.Name = "AlterCourse";
            this.AlterCourse.Radius = 5;
            this.AlterCourse.Size = new System.Drawing.Size(158, 59);
            this.AlterCourse.TabIndex = 51;
            this.AlterCourse.Text = "修改";
            this.AlterCourse.WaveSize = 0;
            this.AlterCourse.Click += new System.EventHandler(this.AlterCourse_Click);
            // 
            // panel36
            // 
            this.panel36.Back = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel36.Controls.Add(this.dayofweek);
            this.panel36.Controls.Add(this.CourseTime);
            this.panel36.Controls.Add(this.CourseName);
            this.panel36.Controls.Add(this.SearchCourse);
            this.panel36.Controls.Add(this.label13);
            this.panel36.Controls.Add(this.label19);
            this.panel36.Controls.Add(this.label14);
            this.panel36.Controls.Add(this.label15);
            this.panel36.Controls.Add(this.CourseCoachid);
            this.panel36.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel36.Location = new System.Drawing.Point(0, 0);
            this.panel36.Name = "panel36";
            this.panel36.Size = new System.Drawing.Size(1897, 74);
            this.panel36.TabIndex = 47;
            this.panel36.Text = "panel36";
            // 
            // dayofweek
            // 
            this.dayofweek.Items.AddRange(new object[] {
            "星期一",
            "星期二",
            "星期三",
            "星期四",
            "星期五",
            "星期六",
            "星期日"});
            this.dayofweek.Location = new System.Drawing.Point(1426, 6);
            this.dayofweek.Name = "dayofweek";
            this.dayofweek.PlaceholderText = "请选择";
            this.dayofweek.Size = new System.Drawing.Size(195, 68);
            this.dayofweek.TabIndex = 15;
            // 
            // CourseTime
            // 
            this.CourseTime.Items.AddRange(new object[] {
            "09:00:00",
            "10:00:00",
            "11:00:00",
            "12:00:00",
            "13:00:00",
            "14:00:00",
            "15:00:00",
            "16:00:00",
            "17:00:00",
            "18:00:00",
            "19:00:00",
            "20:00:00"});
            this.CourseTime.Location = new System.Drawing.Point(630, 3);
            this.CourseTime.Name = "CourseTime";
            this.CourseTime.PlaceholderText = "请选择";
            this.CourseTime.Size = new System.Drawing.Size(276, 68);
            this.CourseTime.TabIndex = 15;
            // 
            // CourseName
            // 
            this.CourseName.Location = new System.Drawing.Point(148, 3);
            this.CourseName.Name = "CourseName";
            this.CourseName.PlaceholderText = "请选择";
            this.CourseName.Size = new System.Drawing.Size(263, 68);
            this.CourseName.TabIndex = 15;
            // 
            // SearchCourse
            // 
            this.SearchCourse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.SearchCourse.BadgeOffsetX = 0;
            this.SearchCourse.BadgeOffsetY = 0;
            this.SearchCourse.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.SearchCourse.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SearchCourse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.SearchCourse.Location = new System.Drawing.Point(1693, 9);
            this.SearchCourse.Name = "SearchCourse";
            this.SearchCourse.Radius = 5;
            this.SearchCourse.Size = new System.Drawing.Size(169, 59);
            this.SearchCourse.TabIndex = 48;
            this.SearchCourse.Text = "搜索";
            this.SearchCourse.WaveSize = 0;
            this.SearchCourse.Click += new System.EventHandler(this.SearchCourse_Click);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label13.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(485, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(139, 70);
            this.label13.TabIndex = 47;
            this.label13.Text = "上课时间:";
            this.label13.TooltipConfig = null;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label19.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(1306, 12);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(147, 64);
            this.label19.TabIndex = 47;
            this.label19.Text = "星期几：";
            this.label19.TooltipConfig = null;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label14.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(968, 7);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 70);
            this.label14.TabIndex = 47;
            this.label14.Text = "教练：";
            this.label14.TooltipConfig = null;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label15.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(36, 7);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(116, 63);
            this.label15.TabIndex = 47;
            this.label15.Text = "课程名:";
            this.label15.TooltipConfig = null;
            // 
            // CourseCoachid
            // 
            this.CourseCoachid.Location = new System.Drawing.Point(1055, 6);
            this.CourseCoachid.Name = "CourseCoachid";
            this.CourseCoachid.PlaceholderText = "请输入";
            this.CourseCoachid.Size = new System.Drawing.Size(203, 65);
            this.CourseCoachid.TabIndex = 48;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.ReserveTable);
            this.tabPage7.Controls.Add(this.panel38);
            this.tabPage7.Controls.Add(this.panel40);
            this.tabPage7.Location = new System.Drawing.Point(0, 0);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(1897, 1068);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "预约信息";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // ReserveTable
            // 
            this.ReserveTable.AllowDrop = true;
            this.ReserveTable.AutoSizeColumnsMode = AntdUI.ColumnsMode.Fill;
            this.ReserveTable.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ReserveTable.Bordered = true;
            this.ReserveTable.ColumnBack = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(183)))), ((int)(((byte)(255)))));
            this.ReserveTable.ColumnFont = new System.Drawing.Font("楷体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ReserveTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReserveTable.EmptyHeader = true;
            this.ReserveTable.EmptyText = "";
            this.ReserveTable.Location = new System.Drawing.Point(0, 161);
            this.ReserveTable.Name = "ReserveTable";
            this.ReserveTable.RowSelectedBg = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.ReserveTable.RowSelectedFore = System.Drawing.Color.Black;
            this.ReserveTable.Size = new System.Drawing.Size(1897, 872);
            this.ReserveTable.TabIndex = 16;
            this.ReserveTable.Text = "table2";
            // 
            // panel38
            // 
            this.panel38.Back = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.panel38.BackColor = System.Drawing.Color.Gainsboro;
            this.panel38.Controls.Add(this.AgreeReseveCourse);
            this.panel38.Controls.Add(this.NotReseveCourse);
            this.panel38.Controls.Add(this.panel39);
            this.panel38.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel38.Location = new System.Drawing.Point(0, 0);
            this.panel38.Name = "panel38";
            this.panel38.Radius = 0;
            this.panel38.Size = new System.Drawing.Size(1897, 161);
            this.panel38.TabIndex = 15;
            this.panel38.Text = "panel38";
            // 
            // AgreeReseveCourse
            // 
            this.AgreeReseveCourse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.AgreeReseveCourse.BadgeOffsetX = 0;
            this.AgreeReseveCourse.BadgeOffsetY = 0;
            this.AgreeReseveCourse.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.AgreeReseveCourse.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AgreeReseveCourse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.AgreeReseveCourse.Location = new System.Drawing.Point(1693, 83);
            this.AgreeReseveCourse.Name = "AgreeReseveCourse";
            this.AgreeReseveCourse.Radius = 5;
            this.AgreeReseveCourse.Size = new System.Drawing.Size(169, 60);
            this.AgreeReseveCourse.TabIndex = 52;
            this.AgreeReseveCourse.Text = "同意预约";
            this.AgreeReseveCourse.WaveSize = 0;
            this.AgreeReseveCourse.Click += new System.EventHandler(this.AgreeReseveCourse_Click);
            // 
            // NotReseveCourse
            // 
            this.NotReseveCourse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.NotReseveCourse.BadgeOffsetX = 0;
            this.NotReseveCourse.BadgeOffsetY = 0;
            this.NotReseveCourse.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.NotReseveCourse.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NotReseveCourse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.NotReseveCourse.Location = new System.Drawing.Point(1453, 86);
            this.NotReseveCourse.Name = "NotReseveCourse";
            this.NotReseveCourse.Radius = 5;
            this.NotReseveCourse.Size = new System.Drawing.Size(168, 57);
            this.NotReseveCourse.TabIndex = 49;
            this.NotReseveCourse.Text = "拒绝预约";
            this.NotReseveCourse.WaveSize = 0;
            this.NotReseveCourse.Click += new System.EventHandler(this.NotReseveCourse_Click);
            // 
            // panel39
            // 
            this.panel39.Back = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel39.Controls.Add(this.ReseveDayOfWeek);
            this.panel39.Controls.Add(this.ReserveName);
            this.panel39.Controls.Add(this.SearchReseveCourse);
            this.panel39.Controls.Add(this.ReserveUserid);
            this.panel39.Controls.Add(this.label16);
            this.panel39.Controls.Add(this.label17);
            this.panel39.Controls.Add(this.label18);
            this.panel39.Controls.Add(this.label20);
            this.panel39.Controls.Add(this.ReserveCoachid);
            this.panel39.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel39.Location = new System.Drawing.Point(0, 0);
            this.panel39.Name = "panel39";
            this.panel39.Size = new System.Drawing.Size(1897, 74);
            this.panel39.TabIndex = 47;
            this.panel39.Text = "panel39";
            // 
            // ReseveDayOfWeek
            // 
            this.ReseveDayOfWeek.Items.AddRange(new object[] {
            "星期一",
            "星期二",
            "星期三",
            "星期四",
            "星期五",
            "星期六",
            "星期日"});
            this.ReseveDayOfWeek.Location = new System.Drawing.Point(1426, 6);
            this.ReseveDayOfWeek.Name = "ReseveDayOfWeek";
            this.ReseveDayOfWeek.PlaceholderText = "请选择";
            this.ReseveDayOfWeek.Size = new System.Drawing.Size(195, 68);
            this.ReseveDayOfWeek.TabIndex = 15;
            // 
            // ReserveName
            // 
            this.ReserveName.Location = new System.Drawing.Point(148, 3);
            this.ReserveName.Name = "ReserveName";
            this.ReserveName.PlaceholderText = "请选择";
            this.ReserveName.Size = new System.Drawing.Size(263, 68);
            this.ReserveName.TabIndex = 15;
            // 
            // SearchReseveCourse
            // 
            this.SearchReseveCourse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.SearchReseveCourse.BadgeOffsetX = 0;
            this.SearchReseveCourse.BadgeOffsetY = 0;
            this.SearchReseveCourse.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.SearchReseveCourse.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SearchReseveCourse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.SearchReseveCourse.Location = new System.Drawing.Point(1693, 9);
            this.SearchReseveCourse.Name = "SearchReseveCourse";
            this.SearchReseveCourse.Radius = 5;
            this.SearchReseveCourse.Size = new System.Drawing.Size(169, 59);
            this.SearchReseveCourse.TabIndex = 48;
            this.SearchReseveCourse.Text = "搜索";
            this.SearchReseveCourse.WaveSize = 0;
            this.SearchReseveCourse.Click += new System.EventHandler(this.SearchReseveCourse_Click);
            // 
            // ReserveUserid
            // 
            this.ReserveUserid.Location = new System.Drawing.Point(567, 6);
            this.ReserveUserid.Name = "ReserveUserid";
            this.ReserveUserid.PlaceholderText = "请输入";
            this.ReserveUserid.Size = new System.Drawing.Size(346, 65);
            this.ReserveUserid.TabIndex = 48;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label16.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(468, 6);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(93, 70);
            this.label16.TabIndex = 47;
            this.label16.Text = "用户:";
            this.label16.TooltipConfig = null;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label17.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(1306, 12);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(147, 64);
            this.label17.TabIndex = 47;
            this.label17.Text = "星期几：";
            this.label17.TooltipConfig = null;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label18.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(968, 7);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(96, 70);
            this.label18.TabIndex = 47;
            this.label18.Text = "教练：";
            this.label18.TooltipConfig = null;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label20.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(36, 7);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(116, 63);
            this.label20.TabIndex = 47;
            this.label20.Text = "课程名:";
            this.label20.TooltipConfig = null;
            // 
            // ReserveCoachid
            // 
            this.ReserveCoachid.Location = new System.Drawing.Point(1055, 6);
            this.ReserveCoachid.Name = "ReserveCoachid";
            this.ReserveCoachid.PlaceholderText = "请输入";
            this.ReserveCoachid.Size = new System.Drawing.Size(203, 65);
            this.ReserveCoachid.TabIndex = 48;
            // 
            // panel40
            // 
            this.panel40.Controls.Add(this.ReservePagination);
            this.panel40.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel40.Location = new System.Drawing.Point(0, 1033);
            this.panel40.Name = "panel40";
            this.panel40.Size = new System.Drawing.Size(1897, 35);
            this.panel40.TabIndex = 14;
            this.panel40.Text = "panel40";
            // 
            // ReservePagination
            // 
            this.ReservePagination.ButtonFillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(204)))));
            this.ReservePagination.ButtonStyleInherited = false;
            this.ReservePagination.DataSource = this.adminBindingSource;
            this.ReservePagination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReservePagination.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ReservePagination.Location = new System.Drawing.Point(0, 0);
            this.ReservePagination.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ReservePagination.MinimumSize = new System.Drawing.Size(1, 1);
            this.ReservePagination.Name = "ReservePagination";
            this.ReservePagination.PageSize = 9;
            this.ReservePagination.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.ReservePagination.ShowText = false;
            this.ReservePagination.Size = new System.Drawing.Size(1897, 35);
            this.ReservePagination.TabIndex = 10;
            this.ReservePagination.Text = "uiPagination3";
            this.ReservePagination.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.ReservePagination.TotalCount = 0;
            this.ReservePagination.PageChanged += new Sunny.UI.UIPagination.OnPageChangeEventHandler(this.ReservePagination_ActivePageChanged);
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.panel22);
            this.tabPage9.Location = new System.Drawing.Point(0, 0);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(1897, 1068);
            this.tabPage9.TabIndex = 8;
            this.tabPage9.Text = "用户群体";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // panel22
            // 
            this.panel22.Controls.Add(this.panel25);
            this.panel22.Controls.Add(this.panel23);
            this.panel22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel22.Location = new System.Drawing.Point(0, 0);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(1897, 1068);
            this.panel22.TabIndex = 5;
            this.panel22.Text = "panel22";
            // 
            // panel25
            // 
            this.panel25.Controls.Add(this.panel29);
            this.panel25.Controls.Add(this.panel27);
            this.panel25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel25.Location = new System.Drawing.Point(965, 0);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(932, 1068);
            this.panel25.TabIndex = 0;
            this.panel25.Text = "panel25";
            // 
            // panel29
            // 
            this.panel29.Controls.Add(this.UserDoughnutChart);
            this.panel29.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel29.Location = new System.Drawing.Point(0, 0);
            this.panel29.Name = "panel29";
            this.panel29.Size = new System.Drawing.Size(932, 677);
            this.panel29.TabIndex = 6;
            this.panel29.Text = "panel29";
            // 
            // UserDoughnutChart
            // 
            this.UserDoughnutChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserDoughnutChart.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserDoughnutChart.LegendFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserDoughnutChart.Location = new System.Drawing.Point(0, 0);
            this.UserDoughnutChart.MinimumSize = new System.Drawing.Size(1, 1);
            this.UserDoughnutChart.Name = "UserDoughnutChart";
            this.UserDoughnutChart.Size = new System.Drawing.Size(932, 677);
            this.UserDoughnutChart.SubFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserDoughnutChart.TabIndex = 3;
            this.UserDoughnutChart.Text = "UserDoughnutChart";
            // 
            // panel27
            // 
            this.panel27.Controls.Add(this.UserDoughnutMarkLabel);
            this.panel27.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel27.Location = new System.Drawing.Point(0, 677);
            this.panel27.Name = "panel27";
            this.panel27.Size = new System.Drawing.Size(932, 391);
            this.panel27.TabIndex = 4;
            this.panel27.Text = "panel27";
            // 
            // UserDoughnutMarkLabel
            // 
            this.UserDoughnutMarkLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserDoughnutMarkLabel.Font = new System.Drawing.Font("华文行楷", 16.125F);
            this.UserDoughnutMarkLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.UserDoughnutMarkLabel.Location = new System.Drawing.Point(0, 0);
            this.UserDoughnutMarkLabel.Name = "UserDoughnutMarkLabel";
            this.UserDoughnutMarkLabel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.UserDoughnutMarkLabel.Size = new System.Drawing.Size(932, 391);
            this.UserDoughnutMarkLabel.TabIndex = 1;
            // 
            // panel23
            // 
            this.panel23.Controls.Add(this.panel26);
            this.panel23.Controls.Add(this.panel24);
            this.panel23.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel23.Location = new System.Drawing.Point(0, 0);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(965, 1068);
            this.panel23.TabIndex = 9;
            this.panel23.Text = "panel23";
            // 
            // panel26
            // 
            this.panel26.Controls.Add(this.UserBarChart);
            this.panel26.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel26.Location = new System.Drawing.Point(0, 0);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(965, 677);
            this.panel26.TabIndex = 5;
            this.panel26.Text = "panel26";
            // 
            // UserBarChart
            // 
            this.UserBarChart.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.adminBindingSource, "用户名", true));
            this.UserBarChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserBarChart.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserBarChart.LegendFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserBarChart.Location = new System.Drawing.Point(0, 0);
            this.UserBarChart.MinimumSize = new System.Drawing.Size(1, 1);
            this.UserBarChart.Name = "UserBarChart";
            this.UserBarChart.Size = new System.Drawing.Size(965, 677);
            this.UserBarChart.SubFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserBarChart.TabIndex = 4;
            this.UserBarChart.Text = "UserBarChart";
            // 
            // panel24
            // 
            this.panel24.Controls.Add(this.UserBarMarkLabel);
            this.panel24.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel24.Location = new System.Drawing.Point(0, 677);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(965, 391);
            this.panel24.TabIndex = 0;
            this.panel24.Text = "panel24";
            // 
            // UserBarMarkLabel
            // 
            this.UserBarMarkLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserBarMarkLabel.Font = new System.Drawing.Font("华文行楷", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserBarMarkLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.UserBarMarkLabel.Location = new System.Drawing.Point(0, 0);
            this.UserBarMarkLabel.Name = "UserBarMarkLabel";
            this.UserBarMarkLabel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.UserBarMarkLabel.Size = new System.Drawing.Size(965, 391);
            this.UserBarMarkLabel.TabIndex = 0;
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.panel32);
            this.tabPage10.Controls.Add(this.panel28);
            this.tabPage10.Location = new System.Drawing.Point(0, 0);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(1897, 1068);
            this.tabPage10.TabIndex = 9;
            this.tabPage10.Text = "教练资源";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // panel32
            // 
            this.panel32.Controls.Add(this.panel33);
            this.panel32.Controls.Add(this.panel34);
            this.panel32.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel32.Location = new System.Drawing.Point(941, 0);
            this.panel32.Name = "panel32";
            this.panel32.Size = new System.Drawing.Size(956, 1068);
            this.panel32.TabIndex = 11;
            this.panel32.Text = "panel32";
            // 
            // panel33
            // 
            this.panel33.Controls.Add(this.CoachDoughnutChart);
            this.panel33.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel33.Location = new System.Drawing.Point(0, 0);
            this.panel33.Name = "panel33";
            this.panel33.Size = new System.Drawing.Size(956, 677);
            this.panel33.TabIndex = 6;
            this.panel33.Text = "panel33";
            // 
            // CoachDoughnutChart
            // 
            this.CoachDoughnutChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CoachDoughnutChart.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CoachDoughnutChart.LegendFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CoachDoughnutChart.Location = new System.Drawing.Point(0, 0);
            this.CoachDoughnutChart.MinimumSize = new System.Drawing.Size(1, 1);
            this.CoachDoughnutChart.Name = "CoachDoughnutChart";
            this.CoachDoughnutChart.Size = new System.Drawing.Size(956, 677);
            this.CoachDoughnutChart.SubFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CoachDoughnutChart.TabIndex = 3;
            this.CoachDoughnutChart.Text = "uiDoughnutChart1";
            // 
            // panel34
            // 
            this.panel34.Controls.Add(this.CoachDoughnutMarkLabel);
            this.panel34.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel34.Location = new System.Drawing.Point(0, 677);
            this.panel34.Name = "panel34";
            this.panel34.Size = new System.Drawing.Size(956, 391);
            this.panel34.TabIndex = 4;
            this.panel34.Text = "panel34";
            // 
            // CoachDoughnutMarkLabel
            // 
            this.CoachDoughnutMarkLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CoachDoughnutMarkLabel.Font = new System.Drawing.Font("华文行楷", 16.125F);
            this.CoachDoughnutMarkLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.CoachDoughnutMarkLabel.Location = new System.Drawing.Point(0, 0);
            this.CoachDoughnutMarkLabel.Name = "CoachDoughnutMarkLabel";
            this.CoachDoughnutMarkLabel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.CoachDoughnutMarkLabel.Size = new System.Drawing.Size(956, 391);
            this.CoachDoughnutMarkLabel.TabIndex = 1;
            // 
            // panel28
            // 
            this.panel28.Controls.Add(this.panel30);
            this.panel28.Controls.Add(this.panel31);
            this.panel28.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel28.Location = new System.Drawing.Point(0, 0);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(941, 1068);
            this.panel28.TabIndex = 10;
            this.panel28.Text = "panel28";
            // 
            // panel30
            // 
            this.panel30.Controls.Add(this.CoachBarChart);
            this.panel30.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel30.Location = new System.Drawing.Point(0, 0);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(941, 677);
            this.panel30.TabIndex = 5;
            this.panel30.Text = "panel30";
            // 
            // CoachBarChart
            // 
            this.CoachBarChart.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.adminBindingSource, "用户名", true));
            this.CoachBarChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CoachBarChart.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CoachBarChart.LegendFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CoachBarChart.Location = new System.Drawing.Point(0, 0);
            this.CoachBarChart.MinimumSize = new System.Drawing.Size(1, 1);
            this.CoachBarChart.Name = "CoachBarChart";
            this.CoachBarChart.Size = new System.Drawing.Size(941, 677);
            this.CoachBarChart.SubFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CoachBarChart.TabIndex = 4;
            this.CoachBarChart.Text = "uiBarChart1";
            // 
            // panel31
            // 
            this.panel31.Controls.Add(this.CoachBarMarkLabel);
            this.panel31.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel31.Location = new System.Drawing.Point(0, 677);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(941, 391);
            this.panel31.TabIndex = 0;
            this.panel31.Text = "panel31";
            // 
            // CoachBarMarkLabel
            // 
            this.CoachBarMarkLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CoachBarMarkLabel.Font = new System.Drawing.Font("华文行楷", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CoachBarMarkLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.CoachBarMarkLabel.Location = new System.Drawing.Point(0, 0);
            this.CoachBarMarkLabel.Name = "CoachBarMarkLabel";
            this.CoachBarMarkLabel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.CoachBarMarkLabel.Size = new System.Drawing.Size(941, 391);
            this.CoachBarMarkLabel.TabIndex = 0;
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.panel44);
            this.tabPage11.Controls.Add(this.panel41);
            this.tabPage11.Location = new System.Drawing.Point(0, 0);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Size = new System.Drawing.Size(1897, 1068);
            this.tabPage11.TabIndex = 10;
            this.tabPage11.Text = "课程信息";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // panel44
            // 
            this.panel44.Controls.Add(this.panel45);
            this.panel44.Controls.Add(this.panel46);
            this.panel44.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel44.Location = new System.Drawing.Point(849, 0);
            this.panel44.Name = "panel44";
            this.panel44.Size = new System.Drawing.Size(1048, 1068);
            this.panel44.TabIndex = 12;
            this.panel44.Text = "panel44";
            // 
            // panel45
            // 
            this.panel45.Controls.Add(this.CourseBarChart1);
            this.panel45.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel45.Location = new System.Drawing.Point(0, 0);
            this.panel45.Name = "panel45";
            this.panel45.Size = new System.Drawing.Size(1048, 677);
            this.panel45.TabIndex = 6;
            this.panel45.Text = "panel45";
            // 
            // CourseBarChart1
            // 
            this.CourseBarChart1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.adminBindingSource, "用户名", true));
            this.CourseBarChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CourseBarChart1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CourseBarChart1.LegendFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CourseBarChart1.Location = new System.Drawing.Point(0, 0);
            this.CourseBarChart1.MinimumSize = new System.Drawing.Size(1, 1);
            this.CourseBarChart1.Name = "CourseBarChart1";
            this.CourseBarChart1.Size = new System.Drawing.Size(1048, 677);
            this.CourseBarChart1.SubFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CourseBarChart1.TabIndex = 5;
            this.CourseBarChart1.Text = "uiBarChart1";
            // 
            // panel46
            // 
            this.panel46.Controls.Add(this.CourseDoughnutMarkLabel);
            this.panel46.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel46.Location = new System.Drawing.Point(0, 677);
            this.panel46.Name = "panel46";
            this.panel46.Size = new System.Drawing.Size(1048, 391);
            this.panel46.TabIndex = 4;
            this.panel46.Text = "panel46";
            // 
            // CourseDoughnutMarkLabel
            // 
            this.CourseDoughnutMarkLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CourseDoughnutMarkLabel.Font = new System.Drawing.Font("华文行楷", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CourseDoughnutMarkLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.CourseDoughnutMarkLabel.Location = new System.Drawing.Point(0, 0);
            this.CourseDoughnutMarkLabel.Name = "CourseDoughnutMarkLabel";
            this.CourseDoughnutMarkLabel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.CourseDoughnutMarkLabel.Size = new System.Drawing.Size(1048, 391);
            this.CourseDoughnutMarkLabel.TabIndex = 1;
            // 
            // panel41
            // 
            this.panel41.Controls.Add(this.panel42);
            this.panel41.Controls.Add(this.panel43);
            this.panel41.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel41.Location = new System.Drawing.Point(0, 0);
            this.panel41.Name = "panel41";
            this.panel41.Size = new System.Drawing.Size(849, 1068);
            this.panel41.TabIndex = 10;
            this.panel41.Text = "panel41";
            // 
            // panel42
            // 
            this.panel42.Controls.Add(this.CourseBarChart);
            this.panel42.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel42.Location = new System.Drawing.Point(0, 0);
            this.panel42.Name = "panel42";
            this.panel42.Size = new System.Drawing.Size(849, 677);
            this.panel42.TabIndex = 5;
            this.panel42.Text = "panel42";
            // 
            // CourseBarChart
            // 
            this.CourseBarChart.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.adminBindingSource, "用户名", true));
            this.CourseBarChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CourseBarChart.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CourseBarChart.LegendFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CourseBarChart.Location = new System.Drawing.Point(0, 0);
            this.CourseBarChart.MinimumSize = new System.Drawing.Size(1, 1);
            this.CourseBarChart.Name = "CourseBarChart";
            this.CourseBarChart.Size = new System.Drawing.Size(849, 677);
            this.CourseBarChart.SubFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CourseBarChart.TabIndex = 4;
            this.CourseBarChart.Text = "uiBarChart1";
            // 
            // panel43
            // 
            this.panel43.Controls.Add(this.CourseBarMarkLabel);
            this.panel43.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel43.Location = new System.Drawing.Point(0, 677);
            this.panel43.Name = "panel43";
            this.panel43.Size = new System.Drawing.Size(849, 391);
            this.panel43.TabIndex = 0;
            this.panel43.Text = "panel43";
            // 
            // CourseBarMarkLabel
            // 
            this.CourseBarMarkLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CourseBarMarkLabel.Font = new System.Drawing.Font("华文行楷", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CourseBarMarkLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.CourseBarMarkLabel.Location = new System.Drawing.Point(0, 0);
            this.CourseBarMarkLabel.Name = "CourseBarMarkLabel";
            this.CourseBarMarkLabel.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.CourseBarMarkLabel.Size = new System.Drawing.Size(849, 391);
            this.CourseBarMarkLabel.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel6);
            this.tabPage3.Controls.Add(this.panel5);
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Location = new System.Drawing.Point(0, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1897, 1068);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "帮助";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.flowLayoutPanel2);
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(297, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1369, 1068);
            this.panel6.TabIndex = 5;
            this.panel6.Text = "panel6";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.uiSmoothLabel1);
            this.flowLayoutPanel2.Controls.Add(this.uiLine1);
            this.flowLayoutPanel2.Controls.Add(this.uiSymbolLabel1);
            this.flowLayoutPanel2.Controls.Add(this.uiSymbolLabel2);
            this.flowLayoutPanel2.Controls.Add(this.uiSymbolLabel3);
            this.flowLayoutPanel2.Controls.Add(this.uiSymbolLabel4);
            this.flowLayoutPanel2.Controls.Add(this.uiSymbolLabel5);
            this.flowLayoutPanel2.Controls.Add(this.uiSymbolLabel6);
            this.flowLayoutPanel2.Controls.Add(this.uiSymbolLabel7);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 318);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1369, 692);
            this.flowLayoutPanel2.TabIndex = 39;
            // 
            // uiSmoothLabel1
            // 
            this.uiSmoothLabel1.Font = new System.Drawing.Font("华文行楷", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSmoothLabel1.Location = new System.Drawing.Point(3, 0);
            this.uiSmoothLabel1.Name = "uiSmoothLabel1";
            this.uiSmoothLabel1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uiSmoothLabel1.Size = new System.Drawing.Size(1366, 54);
            this.uiSmoothLabel1.TabIndex = 2;
            this.uiSmoothLabel1.Text = "动感地带健身俱乐部管理系统";
            this.uiSmoothLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLine1
            // 
            this.uiLine1.BackColor = System.Drawing.Color.Transparent;
            this.uiLine1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine1.Location = new System.Drawing.Point(3, 57);
            this.uiLine1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(1354, 44);
            this.uiLine1.TabIndex = 0;
            this.uiLine1.Text = "系统信息";
            // 
            // uiSymbolLabel1
            // 
            this.uiSymbolLabel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolLabel1.Location = new System.Drawing.Point(3, 107);
            this.uiSymbolLabel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolLabel1.Name = "uiSymbolLabel1";
            this.uiSymbolLabel1.Size = new System.Drawing.Size(1366, 65);
            this.uiSymbolLabel1.Symbol = 57440;
            this.uiSymbolLabel1.SymbolOffset = new System.Drawing.Point(0, 5);
            this.uiSymbolLabel1.SymbolSize = 40;
            this.uiSymbolLabel1.TabIndex = 1;
            this.uiSymbolLabel1.Text = "版本号：v1.0.0";
            this.uiSymbolLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiSymbolLabel2
            // 
            this.uiSymbolLabel2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolLabel2.Location = new System.Drawing.Point(3, 178);
            this.uiSymbolLabel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolLabel2.Name = "uiSymbolLabel2";
            this.uiSymbolLabel2.Size = new System.Drawing.Size(1366, 65);
            this.uiSymbolLabel2.Symbol = 57440;
            this.uiSymbolLabel2.SymbolOffset = new System.Drawing.Point(0, 5);
            this.uiSymbolLabel2.SymbolSize = 40;
            this.uiSymbolLabel2.TabIndex = 1;
            this.uiSymbolLabel2.Text = "发布日期：2024-10-10";
            this.uiSymbolLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiSymbolLabel3
            // 
            this.uiSymbolLabel3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolLabel3.Location = new System.Drawing.Point(3, 249);
            this.uiSymbolLabel3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolLabel3.Name = "uiSymbolLabel3";
            this.uiSymbolLabel3.Size = new System.Drawing.Size(1366, 65);
            this.uiSymbolLabel3.Symbol = 57440;
            this.uiSymbolLabel3.SymbolOffset = new System.Drawing.Point(0, 5);
            this.uiSymbolLabel3.SymbolSize = 40;
            this.uiSymbolLabel3.TabIndex = 1;
            this.uiSymbolLabel3.Text = "版权所有 © 2024 动感地带健身俱乐部";
            this.uiSymbolLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiSymbolLabel4
            // 
            this.uiSymbolLabel4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolLabel4.Location = new System.Drawing.Point(3, 320);
            this.uiSymbolLabel4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolLabel4.Name = "uiSymbolLabel4";
            this.uiSymbolLabel4.Size = new System.Drawing.Size(1366, 65);
            this.uiSymbolLabel4.Symbol = 57440;
            this.uiSymbolLabel4.SymbolOffset = new System.Drawing.Point(0, 5);
            this.uiSymbolLabel4.SymbolSize = 40;
            this.uiSymbolLabel4.TabIndex = 1;
            this.uiSymbolLabel4.Text = "企业名称：动感地带健身俱乐部";
            this.uiSymbolLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiSymbolLabel5
            // 
            this.uiSymbolLabel5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolLabel5.Location = new System.Drawing.Point(3, 391);
            this.uiSymbolLabel5.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolLabel5.Name = "uiSymbolLabel5";
            this.uiSymbolLabel5.Size = new System.Drawing.Size(1366, 65);
            this.uiSymbolLabel5.Symbol = 57440;
            this.uiSymbolLabel5.SymbolOffset = new System.Drawing.Point(0, 5);
            this.uiSymbolLabel5.SymbolSize = 40;
            this.uiSymbolLabel5.TabIndex = 1;
            this.uiSymbolLabel5.Text = "联系方式：222090140@nau.edu.cn";
            this.uiSymbolLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiSymbolLabel6
            // 
            this.uiSymbolLabel6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolLabel6.Location = new System.Drawing.Point(3, 462);
            this.uiSymbolLabel6.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolLabel6.Name = "uiSymbolLabel6";
            this.uiSymbolLabel6.Size = new System.Drawing.Size(1366, 65);
            this.uiSymbolLabel6.Symbol = 57440;
            this.uiSymbolLabel6.SymbolOffset = new System.Drawing.Point(0, 5);
            this.uiSymbolLabel6.SymbolSize = 40;
            this.uiSymbolLabel6.TabIndex = 1;
            this.uiSymbolLabel6.Text = "许可证：MIT License";
            this.uiSymbolLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiSymbolLabel7
            // 
            this.uiSymbolLabel7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolLabel7.Location = new System.Drawing.Point(3, 533);
            this.uiSymbolLabel7.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolLabel7.Name = "uiSymbolLabel7";
            this.uiSymbolLabel7.Size = new System.Drawing.Size(1366, 65);
            this.uiSymbolLabel7.Symbol = 57440;
            this.uiSymbolLabel7.SymbolOffset = new System.Drawing.Point(0, 5);
            this.uiSymbolLabel7.SymbolSize = 40;
            this.uiSymbolLabel7.TabIndex = 1;
            this.uiSymbolLabel7.Text = "系统要求：Windows 10 或更高版本";
            this.uiSymbolLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel11);
            this.panel8.Controls.Add(this.panel10);
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1369, 318);
            this.panel8.TabIndex = 38;
            this.panel8.Text = "panel8";
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.image3D2);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(474, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(406, 318);
            this.panel11.TabIndex = 2;
            this.panel11.Text = "panel11";
            // 
            // image3D2
            // 
            this.image3D2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.image3D2.Image = ((System.Drawing.Image)(resources.GetObject("image3D2.Image")));
            this.image3D2.ImageFit = AntdUI.TFit.Fill;
            this.image3D2.Location = new System.Drawing.Point(0, 0);
            this.image3D2.Name = "image3D2";
            this.image3D2.Size = new System.Drawing.Size(406, 318);
            this.image3D2.TabIndex = 36;
            this.image3D2.Text = "image3D2";
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(880, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(489, 318);
            this.panel10.TabIndex = 1;
            this.panel10.Text = "panel10";
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(474, 318);
            this.panel9.TabIndex = 0;
            this.panel9.Text = "panel9";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.uiLinkLabel1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 1010);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1369, 58);
            this.panel7.TabIndex = 37;
            this.panel7.Text = "panel7";
            // 
            // uiLinkLabel1
            // 
            this.uiLinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiLinkLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLinkLabel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLinkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.uiLinkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiLinkLabel1.Location = new System.Drawing.Point(0, 0);
            this.uiLinkLabel1.Name = "uiLinkLabel1";
            this.uiLinkLabel1.Size = new System.Drawing.Size(1369, 58);
            this.uiLinkLabel1.TabIndex = 0;
            this.uiLinkLabel1.TabStop = true;
            this.uiLinkLabel1.Text = "了解更多关于我们的管理系统";
            this.uiLinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLinkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.uiLinkLabel1.Click += new System.EventHandler(this.uiLinkLabel1_Click);
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(1666, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(231, 1068);
            this.panel5.TabIndex = 4;
            this.panel5.Text = "panel5";
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(297, 1068);
            this.panel3.TabIndex = 3;
            this.panel3.Text = "panel3";
            // 
            // tabPage13
            // 
            this.tabPage13.Controls.Add(this.panel48);
            this.tabPage13.Controls.Add(this.panel47);
            this.tabPage13.Location = new System.Drawing.Point(0, 0);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Size = new System.Drawing.Size(1897, 1068);
            this.tabPage13.TabIndex = 12;
            this.tabPage13.Text = "个人信息";
            this.tabPage13.UseVisualStyleBackColor = true;
            // 
            // panel48
            // 
            this.panel48.Controls.Add(this.verityalterpwd);
            this.panel48.Controls.Add(this.originpwd);
            this.panel48.Controls.Add(this.newpwd);
            this.panel48.Controls.Add(this.veritynewpwd);
            this.panel48.Controls.Add(this.uiSmoothLabel3);
            this.panel48.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel48.Location = new System.Drawing.Point(900, 0);
            this.panel48.Name = "panel48";
            this.panel48.Size = new System.Drawing.Size(997, 1068);
            this.panel48.TabIndex = 5;
            this.panel48.Text = "panel48";
            // 
            // verityalterpwd
            // 
            this.verityalterpwd.BackActive = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(204)))));
            this.verityalterpwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.verityalterpwd.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.verityalterpwd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.verityalterpwd.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.verityalterpwd.Font = new System.Drawing.Font("华文楷体", 10.875F, System.Drawing.FontStyle.Bold);
            this.verityalterpwd.LoadingWaveColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(70)))), ((int)(((byte)(125)))));
            this.verityalterpwd.LoadingWaveCount = 10;
            this.verityalterpwd.LoadingWaveValue = 11F;
            this.verityalterpwd.Location = new System.Drawing.Point(189, 717);
            this.verityalterpwd.Name = "verityalterpwd";
            this.verityalterpwd.Shape = AntdUI.TShape.Round;
            this.verityalterpwd.Size = new System.Drawing.Size(546, 91);
            this.verityalterpwd.TabIndex = 40;
            this.verityalterpwd.Text = "确认修改";
            this.verityalterpwd.Click += new System.EventHandler(this.verityalterpwd_Click);
            // 
            // originpwd
            // 
            this.originpwd.AllowClear = true;
            this.originpwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.originpwd.BackExtend = "0";
            this.originpwd.Badge = "";
            this.originpwd.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.originpwd.BorderWidth = 3F;
            this.originpwd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.originpwd.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.originpwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.originpwd.HandCursor = System.Windows.Forms.Cursors.IBeam;
            this.originpwd.IconRatio = 1.5F;
            this.originpwd.Location = new System.Drawing.Point(175, 262);
            this.originpwd.MaxLength = 6;
            this.originpwd.Name = "originpwd";
            this.originpwd.PasswordCopy = true;
            this.originpwd.PasswordPaste = false;
            this.originpwd.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(105)))), ((int)(((byte)(113)))));
            this.originpwd.PlaceholderText = "输入原密码";
            this.originpwd.Round = true;
            this.originpwd.SelectionColor = System.Drawing.Color.Blue;
            this.originpwd.Size = new System.Drawing.Size(560, 114);
            this.originpwd.TabIndex = 20;
            this.originpwd.WaveSize = 6;
            // 
            // newpwd
            // 
            this.newpwd.AllowClear = true;
            this.newpwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.newpwd.BackExtend = "0";
            this.newpwd.Badge = "";
            this.newpwd.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.newpwd.BorderWidth = 3F;
            this.newpwd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.newpwd.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.newpwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.newpwd.HandCursor = System.Windows.Forms.Cursors.IBeam;
            this.newpwd.IconRatio = 1.5F;
            this.newpwd.Location = new System.Drawing.Point(175, 415);
            this.newpwd.MaxLength = 6;
            this.newpwd.Name = "newpwd";
            this.newpwd.PasswordChar = '·';
            this.newpwd.PasswordCopy = true;
            this.newpwd.PasswordPaste = false;
            this.newpwd.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(105)))), ((int)(((byte)(113)))));
            this.newpwd.PlaceholderText = "输入新密码";
            this.newpwd.Round = true;
            this.newpwd.SelectionColor = System.Drawing.Color.Blue;
            this.newpwd.Size = new System.Drawing.Size(560, 113);
            this.newpwd.TabIndex = 20;
            this.newpwd.UseSystemPasswordChar = true;
            this.newpwd.WaveSize = 6;
            // 
            // veritynewpwd
            // 
            this.veritynewpwd.AllowClear = true;
            this.veritynewpwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.veritynewpwd.BackExtend = "0";
            this.veritynewpwd.Badge = "";
            this.veritynewpwd.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.veritynewpwd.BorderWidth = 3F;
            this.veritynewpwd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.veritynewpwd.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.veritynewpwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.veritynewpwd.HandCursor = System.Windows.Forms.Cursors.IBeam;
            this.veritynewpwd.IconRatio = 1.5F;
            this.veritynewpwd.Location = new System.Drawing.Point(175, 570);
            this.veritynewpwd.MaxLength = 6;
            this.veritynewpwd.Name = "veritynewpwd";
            this.veritynewpwd.PasswordChar = '·';
            this.veritynewpwd.PasswordCopy = true;
            this.veritynewpwd.PasswordPaste = false;
            this.veritynewpwd.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(105)))), ((int)(((byte)(113)))));
            this.veritynewpwd.PlaceholderText = "再次确认新密码";
            this.veritynewpwd.Round = true;
            this.veritynewpwd.SelectionColor = System.Drawing.Color.Blue;
            this.veritynewpwd.Size = new System.Drawing.Size(560, 109);
            this.veritynewpwd.TabIndex = 21;
            this.veritynewpwd.UseSystemPasswordChar = true;
            this.veritynewpwd.WaveSize = 6;
            // 
            // uiSmoothLabel3
            // 
            this.uiSmoothLabel3.Font = new System.Drawing.Font("华文行楷", 22.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSmoothLabel3.Location = new System.Drawing.Point(164, 143);
            this.uiSmoothLabel3.Name = "uiSmoothLabel3";
            this.uiSmoothLabel3.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uiSmoothLabel3.Size = new System.Drawing.Size(577, 101);
            this.uiSmoothLabel3.TabIndex = 3;
            this.uiSmoothLabel3.Text = "修改密码";
            this.uiSmoothLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel47
            // 
            this.panel47.Controls.Add(this.selfbirthday);
            this.panel47.Controls.Add(this.selfage);
            this.panel47.Controls.Add(this.female);
            this.panel47.Controls.Add(this.male);
            this.panel47.Controls.Add(this.selfemail);
            this.panel47.Controls.Add(this.selfphone);
            this.panel47.Controls.Add(this.selfIDcard);
            this.panel47.Controls.Add(this.selfname);
            this.panel47.Controls.Add(this.selfid);
            this.panel47.Controls.Add(this.verityalterinfo);
            this.panel47.Controls.Add(this.beginalterinfo);
            this.panel47.Controls.Add(this.uiLabel5);
            this.panel47.Controls.Add(this.uiLabel4);
            this.panel47.Controls.Add(this.uiLabel9);
            this.panel47.Controls.Add(this.uiLabel8);
            this.panel47.Controls.Add(this.uiLabel7);
            this.panel47.Controls.Add(this.uiLabel6);
            this.panel47.Controls.Add(this.uiLabel3);
            this.panel47.Controls.Add(this.uiLabel2);
            this.panel47.Controls.Add(this.uiSmoothLabel2);
            this.panel47.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel47.Location = new System.Drawing.Point(0, 0);
            this.panel47.Name = "panel47";
            this.panel47.Size = new System.Drawing.Size(900, 1068);
            this.panel47.TabIndex = 4;
            this.panel47.Text = "panel47";
            // 
            // selfbirthday
            // 
            this.selfbirthday.BorderWidth = 0F;
            this.selfbirthday.Enabled = false;
            this.selfbirthday.Location = new System.Drawing.Point(277, 610);
            this.selfbirthday.Name = "selfbirthday";
            this.selfbirthday.Size = new System.Drawing.Size(522, 69);
            this.selfbirthday.TabIndex = 48;
            // 
            // selfage
            // 
            this.selfage.BorderWidth = 0F;
            this.selfage.Enabled = false;
            this.selfage.Location = new System.Drawing.Point(239, 367);
            this.selfage.MaxLength = 3;
            this.selfage.Name = "selfage";
            this.selfage.Size = new System.Drawing.Size(560, 65);
            this.selfage.TabIndex = 47;
            this.selfage.Text = "0";
            // 
            // female
            // 
            this.female.AutoCheck = true;
            this.female.Cursor = System.Windows.Forms.Cursors.Hand;
            this.female.Enabled = false;
            this.female.Font = new System.Drawing.Font("隶书", 12F);
            this.female.Location = new System.Drawing.Point(534, 307);
            this.female.Name = "female";
            this.female.Size = new System.Drawing.Size(230, 49);
            this.female.TabIndex = 44;
            this.female.Text = "女";
            // 
            // male
            // 
            this.male.AutoCheck = true;
            this.male.Checked = true;
            this.male.Cursor = System.Windows.Forms.Cursors.Hand;
            this.male.Enabled = false;
            this.male.Font = new System.Drawing.Font("隶书", 12F);
            this.male.Location = new System.Drawing.Point(239, 312);
            this.male.Name = "male";
            this.male.Size = new System.Drawing.Size(221, 49);
            this.male.TabIndex = 45;
            this.male.Text = "男";
            // 
            // selfemail
            // 
            this.selfemail.BorderWidth = 0F;
            this.selfemail.Enabled = false;
            this.selfemail.Location = new System.Drawing.Point(239, 685);
            this.selfemail.MaxLength = 50;
            this.selfemail.Name = "selfemail";
            this.selfemail.Size = new System.Drawing.Size(560, 71);
            this.selfemail.TabIndex = 41;
            // 
            // selfphone
            // 
            this.selfphone.BorderWidth = 0F;
            this.selfphone.Enabled = false;
            this.selfphone.Location = new System.Drawing.Point(239, 447);
            this.selfphone.MaxLength = 11;
            this.selfphone.Name = "selfphone";
            this.selfphone.Size = new System.Drawing.Size(560, 71);
            this.selfphone.TabIndex = 41;
            // 
            // selfIDcard
            // 
            this.selfIDcard.BorderWidth = 0F;
            this.selfIDcard.Enabled = false;
            this.selfIDcard.Location = new System.Drawing.Point(239, 533);
            this.selfIDcard.MaxLength = 18;
            this.selfIDcard.Name = "selfIDcard";
            this.selfIDcard.Size = new System.Drawing.Size(560, 71);
            this.selfIDcard.TabIndex = 41;
            // 
            // selfname
            // 
            this.selfname.BorderWidth = 0F;
            this.selfname.Enabled = false;
            this.selfname.Location = new System.Drawing.Point(239, 230);
            this.selfname.MaxLength = 50;
            this.selfname.Name = "selfname";
            this.selfname.Size = new System.Drawing.Size(560, 71);
            this.selfname.TabIndex = 41;
            // 
            // selfid
            // 
            this.selfid.BorderWidth = 0F;
            this.selfid.Enabled = false;
            this.selfid.Location = new System.Drawing.Point(239, 143);
            this.selfid.MaxLength = 20;
            this.selfid.Name = "selfid";
            this.selfid.Size = new System.Drawing.Size(560, 71);
            this.selfid.TabIndex = 41;
            // 
            // verityalterinfo
            // 
            this.verityalterinfo.BackActive = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(204)))));
            this.verityalterinfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.verityalterinfo.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.verityalterinfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.verityalterinfo.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.verityalterinfo.Font = new System.Drawing.Font("华文楷体", 10.875F, System.Drawing.FontStyle.Bold);
            this.verityalterinfo.LoadingWaveColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(70)))), ((int)(((byte)(125)))));
            this.verityalterinfo.LoadingWaveCount = 10;
            this.verityalterinfo.LoadingWaveValue = 11F;
            this.verityalterinfo.Location = new System.Drawing.Point(277, 818);
            this.verityalterinfo.Name = "verityalterinfo";
            this.verityalterinfo.Shape = AntdUI.TShape.Round;
            this.verityalterinfo.Size = new System.Drawing.Size(303, 96);
            this.verityalterinfo.TabIndex = 40;
            this.verityalterinfo.Text = "确认修改";
            this.verityalterinfo.Visible = false;
            this.verityalterinfo.Click += new System.EventHandler(this.verityalterinfo_Click);
            // 
            // beginalterinfo
            // 
            this.beginalterinfo.BackActive = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(204)))));
            this.beginalterinfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.beginalterinfo.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.beginalterinfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.beginalterinfo.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.beginalterinfo.Font = new System.Drawing.Font("华文楷体", 10.875F, System.Drawing.FontStyle.Bold);
            this.beginalterinfo.LoadingWaveColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(70)))), ((int)(((byte)(125)))));
            this.beginalterinfo.LoadingWaveCount = 10;
            this.beginalterinfo.LoadingWaveValue = 11F;
            this.beginalterinfo.Location = new System.Drawing.Point(277, 818);
            this.beginalterinfo.Name = "beginalterinfo";
            this.beginalterinfo.Shape = AntdUI.TShape.Round;
            this.beginalterinfo.Size = new System.Drawing.Size(303, 96);
            this.beginalterinfo.TabIndex = 40;
            this.beginalterinfo.Text = "修改基本信息";
            this.beginalterinfo.Click += new System.EventHandler(this.beginalterinfo_Click);
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("隶书", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel5.Location = new System.Drawing.Point(84, 386);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(171, 44);
            this.uiLabel5.TabIndex = 4;
            this.uiLabel5.Text = "年龄：";
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("隶书", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel4.Location = new System.Drawing.Point(84, 312);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(171, 44);
            this.uiLabel4.TabIndex = 4;
            this.uiLabel4.Text = "性别：";
            // 
            // uiLabel9
            // 
            this.uiLabel9.Font = new System.Drawing.Font("隶书", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel9.Location = new System.Drawing.Point(84, 620);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(224, 44);
            this.uiLabel9.TabIndex = 4;
            this.uiLabel9.Text = "出生日期：";
            // 
            // uiLabel8
            // 
            this.uiLabel8.Font = new System.Drawing.Font("隶书", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel8.Location = new System.Drawing.Point(84, 697);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(171, 44);
            this.uiLabel8.TabIndex = 4;
            this.uiLabel8.Text = "邮箱：";
            // 
            // uiLabel7
            // 
            this.uiLabel7.Font = new System.Drawing.Font("隶书", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel7.Location = new System.Drawing.Point(84, 544);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(171, 44);
            this.uiLabel7.TabIndex = 4;
            this.uiLabel7.Text = "身份证：";
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("隶书", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel6.Location = new System.Drawing.Point(84, 242);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(171, 44);
            this.uiLabel6.TabIndex = 4;
            this.uiLabel6.Text = "姓名：";
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("隶书", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel3.Location = new System.Drawing.Point(84, 461);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(171, 44);
            this.uiLabel3.TabIndex = 4;
            this.uiLabel3.Text = "手机号：";
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("隶书", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel2.Location = new System.Drawing.Point(84, 163);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(171, 38);
            this.uiLabel2.TabIndex = 4;
            this.uiLabel2.Text = "用户名：";
            // 
            // uiSmoothLabel2
            // 
            this.uiSmoothLabel2.Font = new System.Drawing.Font("华文行楷", 22.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSmoothLabel2.Location = new System.Drawing.Point(173, 24);
            this.uiSmoothLabel2.Name = "uiSmoothLabel2";
            this.uiSmoothLabel2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uiSmoothLabel2.Size = new System.Drawing.Size(577, 101);
            this.uiSmoothLabel2.TabIndex = 3;
            this.uiSmoothLabel2.Text = "个人基本信息";
            this.uiSmoothLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // 序号
            // 
            this.序号.HeaderText = "序号";
            this.序号.MinimumWidth = 10;
            this.序号.Name = "序号";
            this.序号.ReadOnly = true;
            this.序号.Width = 200;
            // 
            // 用户名DataGridViewTextBoxColumn
            // 
            this.用户名DataGridViewTextBoxColumn.DataPropertyName = "用户名";
            this.用户名DataGridViewTextBoxColumn.HeaderText = "用户名";
            this.用户名DataGridViewTextBoxColumn.MinimumWidth = 10;
            this.用户名DataGridViewTextBoxColumn.Name = "用户名DataGridViewTextBoxColumn";
            this.用户名DataGridViewTextBoxColumn.Width = 200;
            // 
            // 姓名DataGridViewTextBoxColumn
            // 
            this.姓名DataGridViewTextBoxColumn.DataPropertyName = "姓名";
            this.姓名DataGridViewTextBoxColumn.HeaderText = "姓名";
            this.姓名DataGridViewTextBoxColumn.MinimumWidth = 10;
            this.姓名DataGridViewTextBoxColumn.Name = "姓名DataGridViewTextBoxColumn";
            this.姓名DataGridViewTextBoxColumn.Width = 200;
            // 
            // 年龄DataGridViewTextBoxColumn
            // 
            this.年龄DataGridViewTextBoxColumn.DataPropertyName = "年龄";
            this.年龄DataGridViewTextBoxColumn.HeaderText = "年龄";
            this.年龄DataGridViewTextBoxColumn.MinimumWidth = 10;
            this.年龄DataGridViewTextBoxColumn.Name = "年龄DataGridViewTextBoxColumn";
            this.年龄DataGridViewTextBoxColumn.Width = 200;
            // 
            // 性别DataGridViewTextBoxColumn
            // 
            this.性别DataGridViewTextBoxColumn.DataPropertyName = "性别";
            this.性别DataGridViewTextBoxColumn.HeaderText = "性别";
            this.性别DataGridViewTextBoxColumn.MinimumWidth = 10;
            this.性别DataGridViewTextBoxColumn.Name = "性别DataGridViewTextBoxColumn";
            this.性别DataGridViewTextBoxColumn.Width = 200;
            // 
            // 手机号码DataGridViewTextBoxColumn
            // 
            this.手机号码DataGridViewTextBoxColumn.DataPropertyName = "手机号码";
            this.手机号码DataGridViewTextBoxColumn.HeaderText = "手机号码";
            this.手机号码DataGridViewTextBoxColumn.MinimumWidth = 10;
            this.手机号码DataGridViewTextBoxColumn.Name = "手机号码DataGridViewTextBoxColumn";
            this.手机号码DataGridViewTextBoxColumn.Width = 200;
            // 
            // 身份证DataGridViewTextBoxColumn
            // 
            this.身份证DataGridViewTextBoxColumn.DataPropertyName = "身份证";
            this.身份证DataGridViewTextBoxColumn.HeaderText = "身份证";
            this.身份证DataGridViewTextBoxColumn.MinimumWidth = 10;
            this.身份证DataGridViewTextBoxColumn.Name = "身份证DataGridViewTextBoxColumn";
            this.身份证DataGridViewTextBoxColumn.Width = 200;
            // 
            // 邮箱DataGridViewTextBoxColumn
            // 
            this.邮箱DataGridViewTextBoxColumn.DataPropertyName = "邮箱";
            this.邮箱DataGridViewTextBoxColumn.HeaderText = "邮箱";
            this.邮箱DataGridViewTextBoxColumn.MinimumWidth = 10;
            this.邮箱DataGridViewTextBoxColumn.Name = "邮箱DataGridViewTextBoxColumn";
            this.邮箱DataGridViewTextBoxColumn.Width = 200;
            // 
            // 出生日期DataGridViewTextBoxColumn
            // 
            this.出生日期DataGridViewTextBoxColumn.DataPropertyName = "出生日期";
            this.出生日期DataGridViewTextBoxColumn.HeaderText = "出生日期";
            this.出生日期DataGridViewTextBoxColumn.MinimumWidth = 10;
            this.出生日期DataGridViewTextBoxColumn.Name = "出生日期DataGridViewTextBoxColumn";
            this.出生日期DataGridViewTextBoxColumn.ReadOnly = true;
            this.出生日期DataGridViewTextBoxColumn.Width = 200;
            // 
            // adminTableAdapter
            // 
            this.adminTableAdapter.ClearBeforeFill = true;
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(2133, 1153);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.Font = new System.Drawing.Font("宋体", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "管理员界面";
            this.Load += new System.EventHandler(this.frmAdmin_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelTitleBar.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.PageControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.uiPanel1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.adminBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gMSdataset)).EndInit();
            this.panel12.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.panel20.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.panel21.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.panel37.ResumeLayout(false);
            this.panel35.ResumeLayout(false);
            this.panel36.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.panel38.ResumeLayout(false);
            this.panel39.ResumeLayout(false);
            this.panel40.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.panel22.ResumeLayout(false);
            this.panel25.ResumeLayout(false);
            this.panel29.ResumeLayout(false);
            this.panel27.ResumeLayout(false);
            this.panel23.ResumeLayout(false);
            this.panel26.ResumeLayout(false);
            this.panel24.ResumeLayout(false);
            this.tabPage10.ResumeLayout(false);
            this.panel32.ResumeLayout(false);
            this.panel33.ResumeLayout(false);
            this.panel34.ResumeLayout(false);
            this.panel28.ResumeLayout(false);
            this.panel30.ResumeLayout(false);
            this.panel31.ResumeLayout(false);
            this.tabPage11.ResumeLayout(false);
            this.panel44.ResumeLayout(false);
            this.panel45.ResumeLayout(false);
            this.panel46.ResumeLayout(false);
            this.panel41.ResumeLayout(false);
            this.panel42.ResumeLayout(false);
            this.panel43.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.tabPage13.ResumeLayout(false);
            this.panel48.ResumeLayout(false);
            this.panel47.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Panel panelMenu;
        private AntdUI.Avatar avatar1;
        private AntdUI.Panel panelTitleBar;
        private AntdUI.Panel panel4;
        private AntdUI.Divider divider1;
        private AntdUI.Menu menu;
        private AntdUI.Label Title;
        private Sunny.UI.UITabControl PageControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private TabPage tabPage7;
        private TabPage tabPage9;
        private TabPage tabPage10;
        private TabPage tabPage11;
        private TabPage tabPage3;
        private AntdUI.Button button3;
        private AntdUI.Button button2;
        private AntdUI.Panel panelLogo;
        private AntdUI.Calendar calendar1;
        private AntdUI.Signal signal1;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UILabel ZongZhi;
        private AntdUI.Steps Step_ZZ;
        private Sunny.UI.UIListBox uiListBox1;
        private Sunny.UI.UISwitch uiSwitch1;
        private AntdUI.Rate rate1;
        private AntdUI.In.FlowLayoutPanel flowLayoutPanel1;
        private Sunny.UI.UILabel uiLabel1;
        private AntdUI.Label label1;
        private AntdUI.Label label2;
        private AntdUI.Rate rate2;
        private AntdUI.Label label3;
        private AntdUI.Rate rate3;
        private AntdUI.Panel panel1;
        private AntdUI.Image3D image3D1;
        private AntdUI.Panel panel2;
        private AntdUI.Carousel Weekday_pic;
        private Sunny.UI.UILabel HelloLabel;
        private AntdUI.Panel panel3;
        private AntdUI.Panel panel5;
        private AntdUI.Panel panel6;
        private AntdUI.In.FlowLayoutPanel flowLayoutPanel2;
        private Sunny.UI.UISmoothLabel uiSmoothLabel1;
        private Sunny.UI.UILine uiLine1;
        private Sunny.UI.UISymbolLabel uiSymbolLabel1;
        private Sunny.UI.UISymbolLabel uiSymbolLabel2;
        private Sunny.UI.UISymbolLabel uiSymbolLabel3;
        private Sunny.UI.UISymbolLabel uiSymbolLabel4;
        private Sunny.UI.UISymbolLabel uiSymbolLabel5;
        private Sunny.UI.UISymbolLabel uiSymbolLabel6;
        private Sunny.UI.UISymbolLabel uiSymbolLabel7;
        private AntdUI.Panel panel8;
        private AntdUI.Panel panel11;
        private AntdUI.Image3D image3D2;
        private AntdUI.Panel panel10;
        private AntdUI.Panel panel9;
        private AntdUI.Panel panel7;
        private Sunny.UI.UILinkLabel uiLinkLabel1;
        //private GMSDataSet gMSDataSet;
       // private BindingSource adminBindingSource;
        //private GMSDataSetTableAdapters.AdminTableAdapter adminTableAdapter;
        private AntdUI.Panel panel12;
        private DataGridViewTextBoxColumn 序号;
        private DataGridViewTextBoxColumn 用户名DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 姓名DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 年龄DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 性别DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 手机号码DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 身份证DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 邮箱DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 出生日期DataGridViewTextBoxColumn;
        private GMSdataset gMSdataset;
        private BindingSource adminBindingSource;
        private GMSdatasetTableAdapters.AdminTableAdapter adminTableAdapter;
        private Sunny.UI.UIPagination uiPagination1;
        private AntdUI.Panel panel14;
        private AntdUI.Table AdminTable;
        private AntdUI.Panel panel13;
        private AntdUI.Panel panel16;
        private AntdUI.Button button4;
        private AntdUI.Label label4;
        private AntdUI.Label label5;
        private AntdUI.Label label6;
        private AntdUI.Input SearchAdminByname;
        private AntdUI.Input SearchAdminByid;
        private AntdUI.Input SearchAdminByphone;
        private AntdUI.Button deleteAdmin;
        private AntdUI.Button AddAdmin;
        private AntdUI.Button AlterAdmin;
        private AntdUI.Table UserTable;
        private AntdUI.Panel panel20;
        private Sunny.UI.UIPagination UserPagination;
        private AntdUI.Panel panel15;
        private AntdUI.Button deleteUser;
        private AntdUI.Button AddUser;
        private AntdUI.Button AlterUser;
        private AntdUI.Panel panel17;
        private AntdUI.Button SearchUser;
        private AntdUI.Label label7;
        private AntdUI.Label label8;
        private AntdUI.Label label9;
        private AntdUI.Input SearchUserByname;
        private AntdUI.Input SearchUserByid;
        private AntdUI.Input SearchUserByphone;
        private AntdUI.Panel panel21;
        private Sunny.UI.UIPagination CoachPagination;
        private AntdUI.Panel panel18;
        private AntdUI.Button deleteCoach;
        private AntdUI.Button AddCoach;
        private AntdUI.Button AlterCoach;
        private AntdUI.Panel panel19;
        private AntdUI.Button SearchCoach;
        private AntdUI.Label label10;
        private AntdUI.Label label11;
        private AntdUI.Label label12;
        private AntdUI.Input SearchCoachByname;
        private AntdUI.Input SearchCoachByid;
        private AntdUI.Input SearchCoachByphone;
        private AntdUI.Table CoachTable;
        private AntdUI.Button VerityAddAdmin;
        private AntdUI.Button VerityAddUser;
        private AntdUI.Button VerityAddCoach;
        private AntdUI.Panel panel22;
        private AntdUI.Panel panel25;
        private Sunny.UI.UIDoughnutChart UserDoughnutChart;
        private AntdUI.Panel panel29;
        private AntdUI.Panel panel27;
        private Sunny.UI.UIMarkLabel UserDoughnutMarkLabel;
        private AntdUI.Panel panel32;
        private AntdUI.Panel panel33;
        private Sunny.UI.UIDoughnutChart CoachDoughnutChart;
        private AntdUI.Panel panel34;
        private Sunny.UI.UIMarkLabel CoachDoughnutMarkLabel;
        private AntdUI.Panel panel28;
        private AntdUI.Panel panel30;
        private Sunny.UI.UIBarChart CoachBarChart;
        private AntdUI.Panel panel31;
        private Sunny.UI.UIMarkLabel CoachBarMarkLabel;
        private AntdUI.Panel panel35;
        private AntdUI.Button VerityAddCourse;
        private AntdUI.Button deleteCourse;
        private AntdUI.Button AddCourse;
        private AntdUI.Button AlterCourse;
        private AntdUI.Panel panel36;
        private AntdUI.Button SearchCourse;
        private AntdUI.Label label13;
        private AntdUI.Label label14;
        private AntdUI.Label label15;
        private AntdUI.Table CourseTable;
        private AntdUI.Panel panel37;
        private Sunny.UI.UIPagination CoursePagination;
        private AntdUI.Panel panel40;
        private Sunny.UI.UIPagination ReservePagination;
        private AntdUI.Select CourseTime;
        private AntdUI.Select CourseName;
        private AntdUI.Select dayofweek;
        private AntdUI.Label label19;
        private AntdUI.Input CourseCoachid;
        private AntdUI.Table ReserveTable;
        private AntdUI.Panel panel38;
        private AntdUI.Button AgreeReseveCourse;
        private AntdUI.Button NotReseveCourse;
        private AntdUI.Panel panel39;
        private AntdUI.Select ReseveDayOfWeek;
        private AntdUI.Select ReserveName;
        private AntdUI.Button SearchReseveCourse;
        private AntdUI.Label label16;
        private AntdUI.Label label17;
        private AntdUI.Label label18;
        private AntdUI.Label label20;
        private AntdUI.Input ReserveCoachid;
        private AntdUI.Panel panel23;
        private AntdUI.Panel panel26;
        private Sunny.UI.UIBarChart UserBarChart;
        private AntdUI.Panel panel24;
        private Sunny.UI.UIMarkLabel UserBarMarkLabel;
        private AntdUI.Panel panel44;
        private AntdUI.Panel panel45;
        private AntdUI.Panel panel46;
        private Sunny.UI.UIMarkLabel CourseDoughnutMarkLabel;
        private AntdUI.Panel panel41;
        private AntdUI.Panel panel42;
        private Sunny.UI.UIBarChart CourseBarChart;
        private AntdUI.Panel panel43;
        private Sunny.UI.UIMarkLabel CourseBarMarkLabel;
        private AntdUI.Input ReserveUserid;
        private Sunny.UI.UIBarChart CourseBarChart1;
        private TabPage tabPage13;
        private Sunny.UI.UISmoothLabel uiSmoothLabel2;
        private AntdUI.Panel panel48;
        private Sunny.UI.UISmoothLabel uiSmoothLabel3;
        private AntdUI.Panel panel47;
        private AntdUI.Input newpwd;
        private AntdUI.Input veritynewpwd;
        private AntdUI.Input originpwd;
        private AntdUI.Button verityalterpwd;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel2;
        private AntdUI.Input selfname;
        private AntdUI.Input selfid;
        private AntdUI.Button beginalterinfo;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UILabel uiLabel6;
        private AntdUI.Input selfemail;
        private AntdUI.Input selfphone;
        private AntdUI.Input selfIDcard;
        private AntdUI.Radio female;
        private AntdUI.Radio male;
        private AntdUI.Button verityalterinfo;
        private AntdUI.DatePicker selfbirthday;
        private AntdUI.InputNumber selfage;
        private BindingSource bindingSource1;
    }
}