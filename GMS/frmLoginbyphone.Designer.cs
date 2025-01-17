namespace GMS
{
    partial class frmLoginbyphone
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoginbyphone));
            this.exitbtn = new Sunny.UI.UIHeaderButton();
            this.uiPanel2 = new Sunny.UI.UIPanel();
            this.Admininfo = new System.Windows.Forms.LinkLabel();
            this.phoneSign = new System.Windows.Forms.LinkLabel();
            this.Signin = new System.Windows.Forms.LinkLabel();
            this.Forgetpwd = new System.Windows.Forms.LinkLabel();
            this.Loginbtn = new AntdUI.Button();
            this.quitbtn = new AntdUI.Button();
            this.typelist = new AntdUI.Select();
            this.pwdinput1 = new AntdUI.Input();
            this.phoneinput = new AntdUI.Input();
            this.uiSmoothLabel1 = new Sunny.UI.UISmoothLabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiHeaderButton1 = new Sunny.UI.UIHeaderButton();
            this.label = new System.Windows.Forms.Label();
            this.AntdUIProgress = new AntdUI.Progress();
            this.uiPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // exitbtn
            // 
            this.exitbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitbtn.BackColor = System.Drawing.Color.Transparent;
            this.exitbtn.CircleColor = System.Drawing.Color.Transparent;
            this.exitbtn.CircleHoverColor = System.Drawing.Color.Transparent;
            this.exitbtn.FillColor = System.Drawing.Color.Transparent;
            this.exitbtn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.exitbtn.Location = new System.Drawing.Point(1464, 8);
            this.exitbtn.MinimumSize = new System.Drawing.Size(1, 1);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Padding = new System.Windows.Forms.Padding(0, 8, 0, 3);
            this.exitbtn.Radius = 0;
            this.exitbtn.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.exitbtn.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.exitbtn.Size = new System.Drawing.Size(72, 61);
            this.exitbtn.Symbol = 61453;
            this.exitbtn.SymbolColor = System.Drawing.Color.Tomato;
            this.exitbtn.SymbolSize = 64;
            this.exitbtn.TabIndex = 15;
            this.exitbtn.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // uiPanel2
            // 
            this.uiPanel2.BackColor = System.Drawing.Color.Transparent;
            this.uiPanel2.Controls.Add(this.Admininfo);
            this.uiPanel2.Controls.Add(this.phoneSign);
            this.uiPanel2.Controls.Add(this.Signin);
            this.uiPanel2.Controls.Add(this.Forgetpwd);
            this.uiPanel2.Controls.Add(this.Loginbtn);
            this.uiPanel2.Controls.Add(this.quitbtn);
            this.uiPanel2.Controls.Add(this.typelist);
            this.uiPanel2.Controls.Add(this.pwdinput1);
            this.uiPanel2.Controls.Add(this.phoneinput);
            this.uiPanel2.Controls.Add(this.uiSmoothLabel1);
            this.uiPanel2.FillColor = System.Drawing.Color.Transparent;
            this.uiPanel2.FillColor2 = System.Drawing.Color.Gray;
            this.uiPanel2.FillColorGradientDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.uiPanel2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel2.Location = new System.Drawing.Point(46, 222);
            this.uiPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel2.Name = "uiPanel2";
            this.uiPanel2.Radius = 40;
            this.uiPanel2.RectColor = System.Drawing.Color.White;
            this.uiPanel2.Size = new System.Drawing.Size(648, 666);
            this.uiPanel2.TabIndex = 14;
            this.uiPanel2.Text = null;
            this.uiPanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Admininfo
            // 
            this.Admininfo.AutoSize = true;
            this.Admininfo.BackColor = System.Drawing.Color.Transparent;
            this.Admininfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Admininfo.Font = new System.Drawing.Font("华文楷体", 10.5F, System.Drawing.FontStyle.Bold);
            this.Admininfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.Admininfo.LinkColor = System.Drawing.Color.Lavender;
            this.Admininfo.Location = new System.Drawing.Point(49, 608);
            this.Admininfo.Name = "Admininfo";
            this.Admininfo.Size = new System.Drawing.Size(159, 31);
            this.Admininfo.TabIndex = 14;
            this.Admininfo.TabStop = true;
            this.Admininfo.Text = "联系管理员";
            this.Admininfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Admininfo_LinkClicked);
            // 
            // phoneSign
            // 
            this.phoneSign.AutoSize = true;
            this.phoneSign.BackColor = System.Drawing.Color.Transparent;
            this.phoneSign.Cursor = System.Windows.Forms.Cursors.Hand;
            this.phoneSign.Font = new System.Drawing.Font("华文楷体", 10.5F, System.Drawing.FontStyle.Bold);
            this.phoneSign.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.phoneSign.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.phoneSign.LinkColor = System.Drawing.Color.Lavender;
            this.phoneSign.Location = new System.Drawing.Point(349, 608);
            this.phoneSign.Name = "phoneSign";
            this.phoneSign.Size = new System.Drawing.Size(217, 31);
            this.phoneSign.TabIndex = 14;
            this.phoneSign.TabStop = true;
            this.phoneSign.Text = "使用用户名登录";
            this.phoneSign.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.phoneSign_LinkClicked);
            // 
            // Signin
            // 
            this.Signin.AutoSize = true;
            this.Signin.BackColor = System.Drawing.Color.Transparent;
            this.Signin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Signin.Font = new System.Drawing.Font("华文楷体", 10.5F, System.Drawing.FontStyle.Bold);
            this.Signin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.Signin.LinkColor = System.Drawing.Color.Lavender;
            this.Signin.Location = new System.Drawing.Point(49, 546);
            this.Signin.Name = "Signin";
            this.Signin.Size = new System.Drawing.Size(130, 31);
            this.Signin.TabIndex = 14;
            this.Signin.TabStop = true;
            this.Signin.Text = "注册账号";
            this.Signin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Signin_LinkClicked);
            // 
            // Forgetpwd
            // 
            this.Forgetpwd.AutoSize = true;
            this.Forgetpwd.BackColor = System.Drawing.Color.Transparent;
            this.Forgetpwd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Forgetpwd.Font = new System.Drawing.Font("华文楷体", 10.5F, System.Drawing.FontStyle.Bold);
            this.Forgetpwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.Forgetpwd.LinkColor = System.Drawing.Color.Lavender;
            this.Forgetpwd.Location = new System.Drawing.Point(436, 546);
            this.Forgetpwd.Name = "Forgetpwd";
            this.Forgetpwd.Size = new System.Drawing.Size(130, 31);
            this.Forgetpwd.TabIndex = 14;
            this.Forgetpwd.TabStop = true;
            this.Forgetpwd.Text = "忘记密码";
            this.Forgetpwd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Forgetpwd_LinkClicked);
            // 
            // Loginbtn
            // 
            this.Loginbtn.BackActive = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(204)))));
            this.Loginbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.Loginbtn.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.Loginbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Loginbtn.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.Loginbtn.Font = new System.Drawing.Font("华文楷体", 10.875F, System.Drawing.FontStyle.Bold);
            this.Loginbtn.LoadingWaveColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(70)))), ((int)(((byte)(125)))));
            this.Loginbtn.LoadingWaveCount = 10;
            this.Loginbtn.LoadingWaveValue = 11F;
            this.Loginbtn.Location = new System.Drawing.Point(368, 418);
            this.Loginbtn.Name = "Loginbtn";
            this.Loginbtn.Shape = AntdUI.TShape.Round;
            this.Loginbtn.Size = new System.Drawing.Size(225, 83);
            this.Loginbtn.TabIndex = 14;
            this.Loginbtn.Text = "登录";
            this.Loginbtn.Click += new System.EventHandler(this.Loginbtn_Click);
            // 
            // quitbtn
            // 
            this.quitbtn.BackActive = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(126)))), ((int)(((byte)(128)))));
            this.quitbtn.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(172)))), ((int)(((byte)(175)))));
            this.quitbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.quitbtn.Font = new System.Drawing.Font("华文楷体", 10.875F, System.Drawing.FontStyle.Bold);
            this.quitbtn.LoadingWaveColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(70)))), ((int)(((byte)(125)))));
            this.quitbtn.LoadingWaveCount = 10;
            this.quitbtn.LoadingWaveValue = 11F;
            this.quitbtn.Location = new System.Drawing.Point(33, 418);
            this.quitbtn.Name = "quitbtn";
            this.quitbtn.Shape = AntdUI.TShape.Round;
            this.quitbtn.Size = new System.Drawing.Size(225, 83);
            this.quitbtn.TabIndex = 14;
            this.quitbtn.Text = "退出";
            this.quitbtn.Click += new System.EventHandler(this.quitbtn_Click_1);
            // 
            // typelist
            // 
            this.typelist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.typelist.BorderColor = System.Drawing.Color.White;
            this.typelist.BorderWidth = 3F;
            this.typelist.FocusExpandDropdown = false;
            this.typelist.Font = new System.Drawing.Font("隶书", 12F);
            this.typelist.IconRatio = 1.3F;
            this.typelist.Items.AddRange(new object[] {
            "用户",
            "管理员",
            "教练"});
            this.typelist.Location = new System.Drawing.Point(33, 317);
            this.typelist.Name = "typelist";
            this.typelist.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(105)))), ((int)(((byte)(113)))));
            this.typelist.PlaceholderText = "用户类型";
            this.typelist.Prefix = ((System.Drawing.Image)(resources.GetObject("typelist.Prefix")));
            this.typelist.Round = true;
            this.typelist.Size = new System.Drawing.Size(560, 82);
            this.typelist.TabIndex = 14;
            // 
            // pwdinput1
            // 
            this.pwdinput1.AllowClear = true;
            this.pwdinput1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pwdinput1.BackExtend = "0";
            this.pwdinput1.Badge = "";
            this.pwdinput1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pwdinput1.BorderWidth = 3F;
            this.pwdinput1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pwdinput1.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pwdinput1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pwdinput1.HandCursor = System.Windows.Forms.Cursors.IBeam;
            this.pwdinput1.IconRatio = 1.5F;
            this.pwdinput1.Location = new System.Drawing.Point(33, 205);
            this.pwdinput1.MaxLength = 6;
            this.pwdinput1.Name = "pwdinput1";
            this.pwdinput1.PasswordChar = '·';
            this.pwdinput1.PasswordCopy = true;
            this.pwdinput1.PasswordPaste = false;
            this.pwdinput1.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(105)))), ((int)(((byte)(113)))));
            this.pwdinput1.PlaceholderText = "密码";
            this.pwdinput1.Prefix = ((System.Drawing.Image)(resources.GetObject("pwdinput1.Prefix")));
            this.pwdinput1.Round = true;
            this.pwdinput1.SelectionColor = System.Drawing.Color.Blue;
            this.pwdinput1.Size = new System.Drawing.Size(560, 91);
            this.pwdinput1.TabIndex = 15;
            this.pwdinput1.UseSystemPasswordChar = true;
            this.pwdinput1.WaveSize = 6;
            // 
            // phoneinput
            // 
            this.phoneinput.AllowClear = true;
            this.phoneinput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.phoneinput.BackExtend = "0";
            this.phoneinput.Badge = "";
            this.phoneinput.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.phoneinput.BorderWidth = 3F;
            this.phoneinput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.phoneinput.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.phoneinput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.phoneinput.HandCursor = System.Windows.Forms.Cursors.IBeam;
            this.phoneinput.IconRatio = 1.5F;
            this.phoneinput.Location = new System.Drawing.Point(33, 92);
            this.phoneinput.MaxLength = 11;
            this.phoneinput.Name = "phoneinput";
            this.phoneinput.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(105)))), ((int)(((byte)(113)))));
            this.phoneinput.PlaceholderText = "手机号";
            this.phoneinput.Prefix = ((System.Drawing.Image)(resources.GetObject("phoneinput.Prefix")));
            this.phoneinput.Round = true;
            this.phoneinput.SelectionColor = System.Drawing.Color.Indigo;
            this.phoneinput.Size = new System.Drawing.Size(560, 91);
            this.phoneinput.TabIndex = 15;
            this.phoneinput.WaveSize = 6;
            // 
            // uiSmoothLabel1
            // 
            this.uiSmoothLabel1.Font = new System.Drawing.Font("Lucida Handwriting", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSmoothLabel1.Location = new System.Drawing.Point(186, 29);
            this.uiSmoothLabel1.Name = "uiSmoothLabel1";
            this.uiSmoothLabel1.RectColor = System.Drawing.Color.Aqua;
            this.uiSmoothLabel1.Size = new System.Drawing.Size(300, 60);
            this.uiSmoothLabel1.TabIndex = 15;
            this.uiSmoothLabel1.Text = "Welcome！";
            // 
            // uiLabel1
            // 
            this.uiLabel1.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel1.Font = new System.Drawing.Font("Times New Roman", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLabel1.ForeColor = System.Drawing.Color.White;
            this.uiLabel1.Location = new System.Drawing.Point(387, 1029);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(728, 45);
            this.uiLabel1.TabIndex = 18;
            this.uiLabel1.Text = "Copyright © 2024 Yu Yunfeng. All rights reserved.";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiHeaderButton1
            // 
            this.uiHeaderButton1.BackColor = System.Drawing.Color.Transparent;
            this.uiHeaderButton1.CircleHoverColor = System.Drawing.Color.Transparent;
            this.uiHeaderButton1.CircleSize = 0;
            this.uiHeaderButton1.FillColor = System.Drawing.Color.Transparent;
            this.uiHeaderButton1.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiHeaderButton1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiHeaderButton1.Location = new System.Drawing.Point(1360, 34);
            this.uiHeaderButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiHeaderButton1.Name = "uiHeaderButton1";
            this.uiHeaderButton1.Padding = new System.Windows.Forms.Padding(0, 8, 0, 3);
            this.uiHeaderButton1.Radius = 0;
            this.uiHeaderButton1.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.uiHeaderButton1.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiHeaderButton1.Size = new System.Drawing.Size(81, 44);
            this.uiHeaderButton1.Symbol = 61544;
            this.uiHeaderButton1.SymbolColor = System.Drawing.Color.Tomato;
            this.uiHeaderButton1.SymbolSize = 64;
            this.uiHeaderButton1.TabIndex = 17;
            this.uiHeaderButton1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiHeaderButton1.Click += new System.EventHandler(this.uiHeaderButton1_Click);
            // 
            // label
            // 
            this.label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label.AutoSize = true;
            this.label.BackColor = System.Drawing.Color.Transparent;
            this.label.Font = new System.Drawing.Font("华文彩云", 31.875F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label.ForeColor = System.Drawing.Color.Cyan;
            this.label.Location = new System.Drawing.Point(404, 61);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(639, 88);
            this.label.TabIndex = 16;
            this.label.Text = "健身房管理系统";
            // 
            // AntdUIProgress
            // 
            this.AntdUIProgress.Back = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(250)))), ((int)(((byte)(244)))));
            this.AntdUIProgress.BackColor = System.Drawing.Color.Transparent;
            this.AntdUIProgress.ContainerControl = this;
            this.AntdUIProgress.Fill = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.AntdUIProgress.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AntdUIProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(214)))));
            this.AntdUIProgress.HandCursor = System.Windows.Forms.Cursors.Default;
            this.AntdUIProgress.Loading = true;
            this.AntdUIProgress.LoadingFull = true;
            this.AntdUIProgress.Location = new System.Drawing.Point(46, 945);
            this.AntdUIProgress.Name = "AntdUIProgress";
            this.AntdUIProgress.Shape = AntdUI.TShapeProgress.Steps;
            this.AntdUIProgress.ShowInTaskbar = true;
            this.AntdUIProgress.Size = new System.Drawing.Size(1435, 67);
            this.AntdUIProgress.Steps = 42;
            this.AntdUIProgress.TabIndex = 19;
            this.AntdUIProgress.Text = "正在加载";
            this.AntdUIProgress.Value = 0.4F;
            this.AntdUIProgress.ValueRatio = 1F;
            this.AntdUIProgress.Visible = false;
            // 
            // frmLoginbyphone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1555, 1077);
            this.Controls.Add(this.AntdUIProgress);
            this.Controls.Add(this.exitbtn);
            this.Controls.Add(this.uiPanel2);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.uiHeaderButton1);
            this.Controls.Add(this.label);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLoginbyphone";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseDown);
            this.uiPanel2.ResumeLayout(false);
            this.uiPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UIHeaderButton exitbtn;
        private Sunny.UI.UIPanel uiPanel2;
        private System.Windows.Forms.LinkLabel Admininfo;
        private System.Windows.Forms.LinkLabel Signin;
        private System.Windows.Forms.LinkLabel Forgetpwd;
        private AntdUI.Button Loginbtn;
        private AntdUI.Button quitbtn;
        private AntdUI.Select typelist;
        private AntdUI.Input pwdinput1;
        private AntdUI.Input phoneinput;
        private Sunny.UI.UISmoothLabel uiSmoothLabel1;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIHeaderButton uiHeaderButton1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.LinkLabel phoneSign;
        private AntdUI.Progress AntdUIProgress;
    }
}