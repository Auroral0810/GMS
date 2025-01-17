namespace GMS
{
    partial class frmSignIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSignIn));
            this.panel1 = new AntdUI.Panel();
            this.label4 = new AntdUI.Label();
            this.veritySign = new AntdUI.Button();
            this.quitSign = new AntdUI.Button();
            this.idin = new AntdUI.Input();
            this.phonein = new AntdUI.Input();
            this.pwdin = new AntdUI.Input();
            this.verpwdin = new AntdUI.Input();
            this.emailin = new AntdUI.Input();
            this.IDcardin = new AntdUI.Input();
            this.agein = new AntdUI.InputNumber();
            this.namein = new AntdUI.Input();
            this.flowLayoutPanel1 = new AntdUI.In.FlowLayoutPanel();
            this.gridPanel1 = new AntdUI.GridPanel();
            this.female = new AntdUI.Radio();
            this.male = new AntdUI.Radio();
            this.birthdayin = new AntdUI.DatePicker();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.YanZhenMain = new AntdUI.Input();
            this.uiVerificationCode1 = new Sunny.UI.UIVerificationCode();
            this.panel2 = new AntdUI.Panel();
            this.button3 = new AntdUI.Button();
            this.button2 = new AntdUI.Button();
            this.label1 = new AntdUI.Label();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.gridPanel1.SuspendLayout();
            this.uiPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Radius = 0;
            this.panel1.Size = new System.Drawing.Size(703, 1087);
            this.panel1.TabIndex = 29;
            this.panel1.Text = "panel1";
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("华文彩云", 34.875F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(189, 414);
            this.label4.Name = "label4";
            this.label4.Shadow = 30;
            this.label4.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.label4.ShadowOpacity = 0.6F;
            this.label4.Size = new System.Drawing.Size(300, 163);
            this.label4.TabIndex = 30;
            this.label4.Text = "注   册";
            this.label4.TooltipConfig = null;
            // 
            // veritySign
            // 
            this.veritySign.BackActive = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(134)))), ((int)(((byte)(244)))));
            this.veritySign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.veritySign.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(157)))), ((int)(((byte)(251)))));
            this.veritySign.Cursor = System.Windows.Forms.Cursors.Hand;
            this.veritySign.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.veritySign.Font = new System.Drawing.Font("华文楷体", 10.875F, System.Drawing.FontStyle.Bold);
            this.veritySign.LoadingWaveColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(70)))), ((int)(((byte)(125)))));
            this.veritySign.LoadingWaveCount = 10;
            this.veritySign.LoadingWaveValue = 11F;
            this.veritySign.Location = new System.Drawing.Point(576, 976);
            this.veritySign.Name = "veritySign";
            this.veritySign.Shape = AntdUI.TShape.Round;
            this.veritySign.Size = new System.Drawing.Size(225, 83);
            this.veritySign.TabIndex = 34;
            this.veritySign.Text = "确认";
            this.veritySign.Click += new System.EventHandler(this.veritySign_Click);
            // 
            // quitSign
            // 
            this.quitSign.BackActive = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.quitSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(142)))), ((int)(((byte)(144)))));
            this.quitSign.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(172)))), ((int)(((byte)(175)))));
            this.quitSign.BadgeBack = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.quitSign.Cursor = System.Windows.Forms.Cursors.Hand;
            this.quitSign.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.quitSign.Font = new System.Drawing.Font("华文楷体", 10.875F, System.Drawing.FontStyle.Bold);
            this.quitSign.LoadingWaveColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(70)))), ((int)(((byte)(125)))));
            this.quitSign.LoadingWaveCount = 10;
            this.quitSign.LoadingWaveValue = 11F;
            this.quitSign.Location = new System.Drawing.Point(175, 976);
            this.quitSign.Name = "quitSign";
            this.quitSign.Shape = AntdUI.TShape.Round;
            this.quitSign.Size = new System.Drawing.Size(225, 83);
            this.quitSign.TabIndex = 35;
            this.quitSign.Text = "取消";
            this.quitSign.Click += new System.EventHandler(this.quitSign_Click);
            // 
            // idin
            // 
            this.idin.AllowClear = true;
            this.idin.BorderActive = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(181)))), ((int)(((byte)(239)))));
            this.idin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(226)))), ((int)(((byte)(241)))));
            this.idin.BorderHover = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(202)))), ((int)(((byte)(237)))));
            this.idin.BorderWidth = 3F;
            this.idin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.idin.Font = new System.Drawing.Font("隶书", 12F);
            this.idin.HandCursor = System.Windows.Forms.Cursors.IBeam;
            this.idin.IconRatio = 0.8F;
            this.idin.Location = new System.Drawing.Point(3, 3);
            this.idin.MaxLength = 20;
            this.idin.Name = "idin";
            this.idin.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(183)))), ((int)(((byte)(189)))));
            this.idin.PlaceholderText = "用户名";
            this.idin.Prefix = ((System.Drawing.Image)(resources.GetObject("idin.Prefix")));
            this.idin.Radius = 30;
            this.idin.Round = true;
            this.idin.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(181)))), ((int)(((byte)(239)))));
            this.idin.Size = new System.Drawing.Size(632, 64);
            this.idin.TabIndex = 37;
            this.idin.TextChanged += new System.EventHandler(this.input1_TextChanged);
            // 
            // phonein
            // 
            this.phonein.AllowClear = true;
            this.phonein.BorderActive = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(181)))), ((int)(((byte)(239)))));
            this.phonein.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(226)))), ((int)(((byte)(241)))));
            this.phonein.BorderHover = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(202)))), ((int)(((byte)(237)))));
            this.phonein.BorderWidth = 3F;
            this.phonein.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.phonein.Font = new System.Drawing.Font("隶书", 12F);
            this.phonein.HandCursor = System.Windows.Forms.Cursors.IBeam;
            this.phonein.IconRatio = 0.8F;
            this.phonein.Location = new System.Drawing.Point(3, 414);
            this.phonein.MaxLength = 11;
            this.phonein.Name = "phonein";
            this.phonein.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(183)))), ((int)(((byte)(189)))));
            this.phonein.PlaceholderText = "手机号码";
            this.phonein.Prefix = ((System.Drawing.Image)(resources.GetObject("phonein.Prefix")));
            this.phonein.Radius = 30;
            this.phonein.Round = true;
            this.phonein.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(181)))), ((int)(((byte)(239)))));
            this.phonein.Size = new System.Drawing.Size(632, 64);
            this.phonein.TabIndex = 37;
            this.phonein.TextChanged += new System.EventHandler(this.input1_TextChanged);
            // 
            // pwdin
            // 
            this.pwdin.AllowClear = true;
            this.pwdin.BorderActive = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(181)))), ((int)(((byte)(239)))));
            this.pwdin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(226)))), ((int)(((byte)(241)))));
            this.pwdin.BorderHover = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(202)))), ((int)(((byte)(237)))));
            this.pwdin.BorderWidth = 3F;
            this.pwdin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pwdin.Font = new System.Drawing.Font("隶书", 12F);
            this.pwdin.HandCursor = System.Windows.Forms.Cursors.IBeam;
            this.pwdin.IconRatio = 0.85F;
            this.pwdin.Location = new System.Drawing.Point(3, 554);
            this.pwdin.MaxLength = 6;
            this.pwdin.Name = "pwdin";
            this.pwdin.PasswordChar = '·';
            this.pwdin.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(183)))), ((int)(((byte)(189)))));
            this.pwdin.PlaceholderText = "密码";
            this.pwdin.Prefix = ((System.Drawing.Image)(resources.GetObject("pwdin.Prefix")));
            this.pwdin.Radius = 30;
            this.pwdin.Round = true;
            this.pwdin.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(181)))), ((int)(((byte)(239)))));
            this.pwdin.Size = new System.Drawing.Size(632, 64);
            this.pwdin.TabIndex = 37;
            this.pwdin.UseSystemPasswordChar = true;
            this.pwdin.TextChanged += new System.EventHandler(this.input1_TextChanged);
            // 
            // verpwdin
            // 
            this.verpwdin.AllowClear = true;
            this.verpwdin.BorderActive = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(181)))), ((int)(((byte)(239)))));
            this.verpwdin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(226)))), ((int)(((byte)(241)))));
            this.verpwdin.BorderHover = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(202)))), ((int)(((byte)(237)))));
            this.verpwdin.BorderWidth = 3F;
            this.verpwdin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.verpwdin.Font = new System.Drawing.Font("隶书", 12F);
            this.verpwdin.HandCursor = System.Windows.Forms.Cursors.IBeam;
            this.verpwdin.IconRatio = 0.8F;
            this.verpwdin.Location = new System.Drawing.Point(3, 624);
            this.verpwdin.MaxLength = 6;
            this.verpwdin.Name = "verpwdin";
            this.verpwdin.PasswordChar = '·';
            this.verpwdin.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(183)))), ((int)(((byte)(189)))));
            this.verpwdin.PlaceholderText = "确认密码";
            this.verpwdin.Prefix = ((System.Drawing.Image)(resources.GetObject("verpwdin.Prefix")));
            this.verpwdin.Radius = 30;
            this.verpwdin.Round = true;
            this.verpwdin.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(181)))), ((int)(((byte)(239)))));
            this.verpwdin.Size = new System.Drawing.Size(632, 64);
            this.verpwdin.TabIndex = 37;
            this.verpwdin.UseSystemPasswordChar = true;
            this.verpwdin.TextChanged += new System.EventHandler(this.input1_TextChanged);
            // 
            // emailin
            // 
            this.emailin.AllowClear = true;
            this.emailin.BorderActive = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(181)))), ((int)(((byte)(239)))));
            this.emailin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(226)))), ((int)(((byte)(241)))));
            this.emailin.BorderHover = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(202)))), ((int)(((byte)(237)))));
            this.emailin.BorderWidth = 3F;
            this.emailin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.emailin.Font = new System.Drawing.Font("隶书", 12F);
            this.emailin.HandCursor = System.Windows.Forms.Cursors.IBeam;
            this.emailin.IconRatio = 0.8F;
            this.emailin.Location = new System.Drawing.Point(3, 484);
            this.emailin.MaxLength = 20;
            this.emailin.Name = "emailin";
            this.emailin.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(183)))), ((int)(((byte)(189)))));
            this.emailin.PlaceholderText = "邮箱";
            this.emailin.Prefix = ((System.Drawing.Image)(resources.GetObject("emailin.Prefix")));
            this.emailin.Radius = 30;
            this.emailin.Round = true;
            this.emailin.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(181)))), ((int)(((byte)(239)))));
            this.emailin.Size = new System.Drawing.Size(632, 64);
            this.emailin.TabIndex = 37;
            this.emailin.TextChanged += new System.EventHandler(this.input1_TextChanged);
            // 
            // IDcardin
            // 
            this.IDcardin.AllowClear = true;
            this.IDcardin.BorderActive = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(181)))), ((int)(((byte)(239)))));
            this.IDcardin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(226)))), ((int)(((byte)(241)))));
            this.IDcardin.BorderHover = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(202)))), ((int)(((byte)(237)))));
            this.IDcardin.BorderWidth = 3F;
            this.IDcardin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.IDcardin.Font = new System.Drawing.Font("隶书", 12F);
            this.IDcardin.HandCursor = System.Windows.Forms.Cursors.IBeam;
            this.IDcardin.IconRatio = 0.9F;
            this.IDcardin.Location = new System.Drawing.Point(3, 344);
            this.IDcardin.MaxLength = 18;
            this.IDcardin.Name = "IDcardin";
            this.IDcardin.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(183)))), ((int)(((byte)(189)))));
            this.IDcardin.PlaceholderText = "身份证";
            this.IDcardin.Prefix = ((System.Drawing.Image)(resources.GetObject("IDcardin.Prefix")));
            this.IDcardin.Radius = 30;
            this.IDcardin.Round = true;
            this.IDcardin.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(181)))), ((int)(((byte)(239)))));
            this.IDcardin.Size = new System.Drawing.Size(632, 64);
            this.IDcardin.TabIndex = 37;
            this.IDcardin.TextChanged += new System.EventHandler(this.input1_TextChanged);
            // 
            // agein
            // 
            this.agein.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(226)))), ((int)(((byte)(241)))));
            this.agein.BorderHover = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(202)))), ((int)(((byte)(237)))));
            this.agein.BorderWidth = 3F;
            this.agein.Cursor = System.Windows.Forms.Cursors.Hand;
            this.agein.Font = new System.Drawing.Font("隶书", 12F);
            this.agein.IconRatio = 0.9F;
            this.agein.Location = new System.Drawing.Point(3, 204);
            this.agein.MaxLength = 120;
            this.agein.Name = "agein";
            this.agein.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(183)))), ((int)(((byte)(189)))));
            this.agein.PlaceholderText = "年龄";
            this.agein.Prefix = ((System.Drawing.Image)(resources.GetObject("agein.Prefix")));
            this.agein.Round = true;
            this.agein.Size = new System.Drawing.Size(632, 64);
            this.agein.TabIndex = 36;
            this.agein.Text = "20";
            this.agein.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.agein.WaveSize = 2;
            // 
            // namein
            // 
            this.namein.AllowClear = true;
            this.namein.BorderActive = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(181)))), ((int)(((byte)(239)))));
            this.namein.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(226)))), ((int)(((byte)(241)))));
            this.namein.BorderHover = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(202)))), ((int)(((byte)(237)))));
            this.namein.BorderWidth = 3F;
            this.namein.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.namein.Font = new System.Drawing.Font("隶书", 12F);
            this.namein.HandCursor = System.Windows.Forms.Cursors.IBeam;
            this.namein.IconRatio = 0.9F;
            this.namein.Location = new System.Drawing.Point(3, 73);
            this.namein.MaxLength = 20;
            this.namein.Name = "namein";
            this.namein.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(183)))), ((int)(((byte)(189)))));
            this.namein.PlaceholderText = "姓名";
            this.namein.Prefix = ((System.Drawing.Image)(resources.GetObject("namein.Prefix")));
            this.namein.Radius = 30;
            this.namein.Round = true;
            this.namein.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(181)))), ((int)(((byte)(239)))));
            this.namein.Size = new System.Drawing.Size(632, 64);
            this.namein.TabIndex = 37;
            this.namein.TextChanged += new System.EventHandler(this.input1_TextChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.idin);
            this.flowLayoutPanel1.Controls.Add(this.namein);
            this.flowLayoutPanel1.Controls.Add(this.gridPanel1);
            this.flowLayoutPanel1.Controls.Add(this.agein);
            this.flowLayoutPanel1.Controls.Add(this.birthdayin);
            this.flowLayoutPanel1.Controls.Add(this.IDcardin);
            this.flowLayoutPanel1.Controls.Add(this.phonein);
            this.flowLayoutPanel1.Controls.Add(this.emailin);
            this.flowLayoutPanel1.Controls.Add(this.pwdin);
            this.flowLayoutPanel1.Controls.Add(this.verpwdin);
            this.flowLayoutPanel1.Controls.Add(this.uiPanel1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(169, 141);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(658, 786);
            this.flowLayoutPanel1.TabIndex = 39;
            // 
            // gridPanel1
            // 
            this.gridPanel1.Controls.Add(this.female);
            this.gridPanel1.Controls.Add(this.male);
            this.gridPanel1.Location = new System.Drawing.Point(3, 143);
            this.gridPanel1.Name = "gridPanel1";
            this.gridPanel1.Size = new System.Drawing.Size(632, 55);
            this.gridPanel1.Span = "50% 50%;";
            this.gridPanel1.TabIndex = 39;
            this.gridPanel1.Text = "gridPanel1";
            // 
            // female
            // 
            this.female.AutoCheck = true;
            this.female.Cursor = System.Windows.Forms.Cursors.Hand;
            this.female.Font = new System.Drawing.Font("隶书", 12F);
            this.female.Location = new System.Drawing.Point(319, 3);
            this.female.Name = "female";
            this.female.Size = new System.Drawing.Size(310, 49);
            this.female.TabIndex = 38;
            this.female.Text = "女";
            // 
            // male
            // 
            this.male.AutoCheck = true;
            this.male.Checked = true;
            this.male.Cursor = System.Windows.Forms.Cursors.Hand;
            this.male.Font = new System.Drawing.Font("隶书", 12F);
            this.male.Location = new System.Drawing.Point(3, 3);
            this.male.Name = "male";
            this.male.Size = new System.Drawing.Size(310, 49);
            this.male.TabIndex = 38;
            this.male.Text = "男";
            // 
            // birthdayin
            // 
            this.birthdayin.BorderActive = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(181)))), ((int)(((byte)(239)))));
            this.birthdayin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(226)))), ((int)(((byte)(241)))));
            this.birthdayin.BorderHover = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(202)))), ((int)(((byte)(237)))));
            this.birthdayin.BorderWidth = 3F;
            this.birthdayin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.birthdayin.Font = new System.Drawing.Font("隶书", 12F);
            this.birthdayin.IconRatio = 0.9F;
            this.birthdayin.Location = new System.Drawing.Point(3, 274);
            this.birthdayin.Name = "birthdayin";
            this.birthdayin.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(183)))), ((int)(((byte)(189)))));
            this.birthdayin.PlaceholderText = "出生日期";
            this.birthdayin.Prefix = ((System.Drawing.Image)(resources.GetObject("birthdayin.Prefix")));
            this.birthdayin.Size = new System.Drawing.Size(632, 64);
            this.birthdayin.TabIndex = 42;
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.YanZhenMain);
            this.uiPanel1.Controls.Add(this.uiVerificationCode1);
            this.uiPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.uiPanel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel1.Location = new System.Drawing.Point(4, 696);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.RectColor = System.Drawing.Color.Empty;
            this.uiPanel1.Size = new System.Drawing.Size(631, 88);
            this.uiPanel1.TabIndex = 43;
            this.uiPanel1.Text = "uiPanel1";
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // YanZhenMain
            // 
            this.YanZhenMain.AllowClear = true;
            this.YanZhenMain.BorderActive = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(181)))), ((int)(((byte)(239)))));
            this.YanZhenMain.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(226)))), ((int)(((byte)(241)))));
            this.YanZhenMain.BorderHover = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(202)))), ((int)(((byte)(237)))));
            this.YanZhenMain.BorderWidth = 3F;
            this.YanZhenMain.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.YanZhenMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.YanZhenMain.Font = new System.Drawing.Font("隶书", 12F);
            this.YanZhenMain.HandCursor = System.Windows.Forms.Cursors.IBeam;
            this.YanZhenMain.IconRatio = 0.8F;
            this.YanZhenMain.Location = new System.Drawing.Point(0, 0);
            this.YanZhenMain.MaxLength = 6;
            this.YanZhenMain.Name = "YanZhenMain";
            this.YanZhenMain.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(183)))), ((int)(((byte)(189)))));
            this.YanZhenMain.PlaceholderText = "验证码";
            this.YanZhenMain.Prefix = ((System.Drawing.Image)(resources.GetObject("YanZhenMain.Prefix")));
            this.YanZhenMain.Radius = 5;
            this.YanZhenMain.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(181)))), ((int)(((byte)(239)))));
            this.YanZhenMain.Size = new System.Drawing.Size(366, 88);
            this.YanZhenMain.TabIndex = 37;
            this.YanZhenMain.TextChanged += new System.EventHandler(this.input1_TextChanged);
            // 
            // uiVerificationCode1
            // 
            this.uiVerificationCode1.CausesValidation = false;
            this.uiVerificationCode1.Dock = System.Windows.Forms.DockStyle.Right;
            this.uiVerificationCode1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiVerificationCode1.Location = new System.Drawing.Point(366, 0);
            this.uiVerificationCode1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiVerificationCode1.Name = "uiVerificationCode1";
            this.uiVerificationCode1.Radius = 0;
            this.uiVerificationCode1.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiVerificationCode1.Size = new System.Drawing.Size(265, 88);
            this.uiVerificationCode1.TabIndex = 32;
            this.uiVerificationCode1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.veritySign);
            this.panel2.Controls.Add(this.quitSign);
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(703, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(988, 1087);
            this.panel2.TabIndex = 30;
            this.panel2.Text = "panel2";
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel2MouseDown);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button3.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button3.Icon = ((System.Drawing.Image)(resources.GetObject("button3.Icon")));
            this.button3.IconRatio = 1F;
            this.button3.Location = new System.Drawing.Point(870, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 37);
            this.button3.TabIndex = 42;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button2.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button2.Icon = ((System.Drawing.Image)(resources.GetObject("button2.Icon")));
            this.button2.IconRatio = 1F;
            this.button2.Location = new System.Drawing.Point(926, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 37);
            this.button2.TabIndex = 43;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("方正舒体", 22.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(142)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(292, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(410, 71);
            this.label1.TabIndex = 41;
            this.label1.Text = "个人基本信息";
            this.label1.TooltipConfig = null;
            // 
            // frmSignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1691, 1087);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "frmSignIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "注册用户账号";
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.gridPanel1.ResumeLayout(false);
            this.uiPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Panel panel1;
        private AntdUI.Label label4;
        private AntdUI.Button veritySign;
        private AntdUI.Button quitSign;
        private AntdUI.Input verpwdin;
        private AntdUI.Input pwdin;
        private AntdUI.Input phonein;
        private AntdUI.Input idin;
        private AntdUI.Input IDcardin;
        private AntdUI.Input emailin;
        private AntdUI.In.FlowLayoutPanel flowLayoutPanel1;
        private AntdUI.InputNumber agein;
        private AntdUI.Input namein;
        private AntdUI.Radio male;
        private AntdUI.DatePicker birthdayin;
        private AntdUI.Panel panel2;
        private AntdUI.Radio female;
        private AntdUI.GridPanel gridPanel1;
        private AntdUI.Label label1;
        private AntdUI.Button button3;
        private AntdUI.Button button2;
        private AntdUI.Input YanZhenMain;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UIVerificationCode uiVerificationCode1;
    }
}