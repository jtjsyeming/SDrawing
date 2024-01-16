namespace SmallPaint
{
    partial class SmallPaint
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmallPaint));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPic = new System.Windows.Forms.ToolStripMenuItem();
            this.BuildNewPic = new System.Windows.Forms.ToolStripMenuItem();
            this.savePic = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.Quit = new System.Windows.Forms.ToolStripMenuItem();
            this.图片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearPic = new System.Windows.Forms.ToolStripMenuItem();
            this.AttributePic = new System.Windows.Forms.ToolStripMenuItem();
            this.思维导图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分支导图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.循环导图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.text = new System.Windows.Forms.ToolStripMenuItem();
            this.完成导图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图形工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.思维导图工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.颜色版选取ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.status = new System.Windows.Forms.StatusStrip();
            this.currentDrawType = new System.Windows.Forms.ToolStripStatusLabel();
            this.mousePostion = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.colorHatch1 = new ColorHatch.ColorHatch();
            this.DrawtoolStrip = new System.Windows.Forms.ToolStrip();
            this.Pointer = new System.Windows.Forms.ToolStripButton();
            this.Line = new System.Windows.Forms.ToolStripButton();
            this.Rect = new System.Windows.Forms.ToolStripButton();
            this.Eraser = new System.Windows.Forms.ToolStripButton();
            this.Circle = new System.Windows.Forms.ToolStripButton();
            this.Dot = new System.Windows.Forms.ToolStripButton();
            this.Arrows = new System.Windows.Forms.ToolStripButton();
            this.TArrows = new System.Windows.Forms.ToolStripButton();
            this.Write = new System.Windows.Forms.ToolStripButton();
            this.ColorPick = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.reSize = new System.Windows.Forms.PictureBox();
            this.pbImg = new System.Windows.Forms.PictureBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.status.SuspendLayout();
            this.panel1.SuspendLayout();
            this.DrawtoolStrip.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImg)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.图片ToolStripMenuItem,
            this.思维导图ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(870, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openPic,
            this.BuildNewPic,
            this.savePic,
            this.SaveAs,
            this.Quit});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.文件ToolStripMenuItem.Text = "文件";
            this.文件ToolStripMenuItem.Click += new System.EventHandler(this.文件ToolStripMenuItem_Click);
            // 
            // openPic
            // 
            this.openPic.Name = "openPic";
            this.openPic.Size = new System.Drawing.Size(137, 26);
            this.openPic.Text = "打开";
            this.openPic.Click += new System.EventHandler(this.openPic_Click);
            // 
            // BuildNewPic
            // 
            this.BuildNewPic.Name = "BuildNewPic";
            this.BuildNewPic.Size = new System.Drawing.Size(137, 26);
            this.BuildNewPic.Text = "新建";
            this.BuildNewPic.Click += new System.EventHandler(this.BuildNewPic_Click);
            // 
            // savePic
            // 
            this.savePic.Name = "savePic";
            this.savePic.Size = new System.Drawing.Size(137, 26);
            this.savePic.Text = "保存";
            this.savePic.Click += new System.EventHandler(this.savePic_Click);
            // 
            // SaveAs
            // 
            this.SaveAs.Name = "SaveAs";
            this.SaveAs.Size = new System.Drawing.Size(137, 26);
            this.SaveAs.Text = "另存为";
            this.SaveAs.Click += new System.EventHandler(this.SaveAs_Click);
            // 
            // Quit
            // 
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(137, 26);
            this.Quit.Text = "退出";
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // 图片ToolStripMenuItem
            // 
            this.图片ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearPic,
            this.AttributePic});
            this.图片ToolStripMenuItem.Name = "图片ToolStripMenuItem";
            this.图片ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.图片ToolStripMenuItem.Text = "图像";
            this.图片ToolStripMenuItem.Click += new System.EventHandler(this.图片ToolStripMenuItem_Click);
            // 
            // clearPic
            // 
            this.clearPic.Name = "clearPic";
            this.clearPic.Size = new System.Drawing.Size(224, 26);
            this.clearPic.Text = "清除图像";
            this.clearPic.Click += new System.EventHandler(this.clearPic_Click);
            // 
            // AttributePic
            // 
            this.AttributePic.Name = "AttributePic";
            this.AttributePic.Size = new System.Drawing.Size(224, 26);
            this.AttributePic.Text = "图像属性";
            this.AttributePic.Click += new System.EventHandler(this.AttributePic_Click);
            // 
            // 思维导图ToolStripMenuItem
            // 
            this.思维导图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.分支导图ToolStripMenuItem,
            this.循环导图ToolStripMenuItem,
            this.text,
            this.完成导图ToolStripMenuItem});
            this.思维导图ToolStripMenuItem.Name = "思维导图ToolStripMenuItem";
            this.思维导图ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.思维导图ToolStripMenuItem.Text = "思维导图";
            this.思维导图ToolStripMenuItem.Click += new System.EventHandler(this.思维导图ToolStripMenuItem_Click);
            // 
            // 分支导图ToolStripMenuItem
            // 
            this.分支导图ToolStripMenuItem.Name = "分支导图ToolStripMenuItem";
            this.分支导图ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.分支导图ToolStripMenuItem.Text = "分支导图";
            this.分支导图ToolStripMenuItem.Click += new System.EventHandler(this.Branch_Guides_Click);
            // 
            // 循环导图ToolStripMenuItem
            // 
            this.循环导图ToolStripMenuItem.Name = "循环导图ToolStripMenuItem";
            this.循环导图ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.循环导图ToolStripMenuItem.Text = "循环导图";
            this.循环导图ToolStripMenuItem.Click += new System.EventHandler(this.Circular_Guide_Click);
            // 
            // text
            // 
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(152, 26);
            this.text.Text = "文本";
            this.text.Click += new System.EventHandler(this.text_Click);
            // 
            // 完成导图ToolStripMenuItem
            // 
            this.完成导图ToolStripMenuItem.Name = "完成导图ToolStripMenuItem";
            this.完成导图ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.完成导图ToolStripMenuItem.Text = "完成导图";
            this.完成导图ToolStripMenuItem.Click += new System.EventHandler(this.完成导图ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.图形工具ToolStripMenuItem,
            this.思维导图工具ToolStripMenuItem,
            this.颜色版选取ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 图形工具ToolStripMenuItem
            // 
            this.图形工具ToolStripMenuItem.Name = "图形工具ToolStripMenuItem";
            this.图形工具ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.图形工具ToolStripMenuItem.Text = "图形工具";
            this.图形工具ToolStripMenuItem.Click += new System.EventHandler(this.图形工具ToolStripMenuItem_Click);
            // 
            // 思维导图工具ToolStripMenuItem
            // 
            this.思维导图工具ToolStripMenuItem.Name = "思维导图工具ToolStripMenuItem";
            this.思维导图工具ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.思维导图工具ToolStripMenuItem.Text = "思维导图工具";
            this.思维导图工具ToolStripMenuItem.Click += new System.EventHandler(this.思维导图工具ToolStripMenuItem_Click);
            // 
            // 颜色版选取ToolStripMenuItem
            // 
            this.颜色版选取ToolStripMenuItem.Name = "颜色版选取ToolStripMenuItem";
            this.颜色版选取ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.颜色版选取ToolStripMenuItem.Text = "颜色版选取";
            this.颜色版选取ToolStripMenuItem.Click += new System.EventHandler(this.颜色版选取ToolStripMenuItem_Click);
            // 
            // status
            // 
            this.status.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentDrawType,
            this.mousePostion});
            this.status.Location = new System.Drawing.Point(0, 525);
            this.status.Name = "status";
            this.status.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.status.Size = new System.Drawing.Size(870, 22);
            this.status.TabIndex = 1;
            this.status.Text = "statusStrip1";
            this.status.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.status_ItemClicked);
            // 
            // currentDrawType
            // 
            this.currentDrawType.Name = "currentDrawType";
            this.currentDrawType.Size = new System.Drawing.Size(0, 16);
            // 
            // mousePostion
            // 
            this.mousePostion.Name = "mousePostion";
            this.mousePostion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mousePostion.Size = new System.Drawing.Size(0, 16);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.colorHatch1);
            this.panel1.Controls.Add(this.DrawtoolStrip);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(83, 497);
            this.panel1.TabIndex = 2;
            // 
            // colorHatch1
            // 
            this.colorHatch1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorHatch1.Location = new System.Drawing.Point(7, 210);
            this.colorHatch1.Margin = new System.Windows.Forms.Padding(5);
            this.colorHatch1.Name = "colorHatch1";
            this.colorHatch1.Size = new System.Drawing.Size(68, 281);
            this.colorHatch1.TabIndex = 2;
            this.colorHatch1.ColorChanged += new ColorHatch.ColorHatch.ColorChangedEventHandler(this.colorHatch1_ColorChanged);
            this.colorHatch1.Load += new System.EventHandler(this.colorHatch1_Load);
            // 
            // DrawtoolStrip
            // 
            this.DrawtoolStrip.AutoSize = false;
            this.DrawtoolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.DrawtoolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.DrawtoolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Pointer,
            this.Line,
            this.Rect,
            this.Eraser,
            this.Circle,
            this.Dot,
            this.Arrows,
            this.TArrows,
            this.Write,
            this.ColorPick});
            this.DrawtoolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.DrawtoolStrip.Location = new System.Drawing.Point(8, 0);
            this.DrawtoolStrip.Name = "DrawtoolStrip";
            this.DrawtoolStrip.Size = new System.Drawing.Size(73, 165);
            this.DrawtoolStrip.TabIndex = 0;
            this.DrawtoolStrip.Text = "toolStrip1";
            // 
            // Pointer
            // 
            this.Pointer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Pointer.Image = global::SmallPaint.Properties.Resources.mouse;
            this.Pointer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Pointer.Name = "Pointer";
            this.Pointer.Size = new System.Drawing.Size(29, 24);
            this.Pointer.Text = "指针";
            this.Pointer.Click += new System.EventHandler(this.tool_Click);
            // 
            // Line
            // 
            this.Line.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Line.Image = global::SmallPaint.Properties.Resources.line;
            this.Line.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Line.Name = "Line";
            this.Line.Size = new System.Drawing.Size(29, 24);
            this.Line.Text = "直线";
            this.Line.Click += new System.EventHandler(this.tool_Click);
            // 
            // Rect
            // 
            this.Rect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Rect.Image = global::SmallPaint.Properties.Resources.rect;
            this.Rect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Rect.Name = "Rect";
            this.Rect.Size = new System.Drawing.Size(29, 24);
            this.Rect.Text = "空心矩形";
            this.Rect.Click += new System.EventHandler(this.tool_Click);
            // 
            // Eraser
            // 
            this.Eraser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Eraser.Image = global::SmallPaint.Properties.Resources.eraser1;
            this.Eraser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Eraser.Name = "Eraser";
            this.Eraser.Size = new System.Drawing.Size(29, 24);
            this.Eraser.Text = "橡皮";
            this.Eraser.Click += new System.EventHandler(this.tool_Click);
            // 
            // Circle
            // 
            this.Circle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Circle.Image = global::SmallPaint.Properties.Resources.Circle;
            this.Circle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Circle.Name = "Circle";
            this.Circle.Size = new System.Drawing.Size(29, 24);
            this.Circle.Text = "空心圆";
            this.Circle.Click += new System.EventHandler(this.tool_Click);
            // 
            // Dot
            // 
            this.Dot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Dot.Image = global::SmallPaint.Properties.Resources.Pencil;
            this.Dot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Dot.Name = "Dot";
            this.Dot.Size = new System.Drawing.Size(29, 24);
            this.Dot.Text = "铅笔";
            this.Dot.Click += new System.EventHandler(this.tool_Click);
            // 
            // Arrows
            // 
            this.Arrows.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Arrows.Image = global::SmallPaint.Properties.Resources.Arrows;
            this.Arrows.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Arrows.Name = "Arrows";
            this.Arrows.Size = new System.Drawing.Size(29, 24);
            this.Arrows.Text = "单向箭头";
            this.Arrows.Click += new System.EventHandler(this.tool_Click);
            // 
            // TArrows
            // 
            this.TArrows.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TArrows.Image = global::SmallPaint.Properties.Resources.tArrows1;
            this.TArrows.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TArrows.Name = "TArrows";
            this.TArrows.Size = new System.Drawing.Size(29, 24);
            this.TArrows.Text = "双向箭头";
            this.TArrows.Click += new System.EventHandler(this.tool_Click);
            // 
            // Write
            // 
            this.Write.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Write.Image = ((System.Drawing.Image)(resources.GetObject("Write.Image")));
            this.Write.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Write.Name = "Write";
            this.Write.Size = new System.Drawing.Size(29, 24);
            this.Write.Text = "文本框";
            this.Write.Click += new System.EventHandler(this.tool_Click);
            // 
            // ColorPick
            // 
            this.ColorPick.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ColorPick.Image = global::SmallPaint.Properties.Resources.ColorPicker_;
            this.ColorPick.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ColorPick.Name = "ColorPick";
            this.ColorPick.Size = new System.Drawing.Size(29, 24);
            this.ColorPick.Text = "取色器";
            this.ColorPick.Click += new System.EventHandler(this.tool_Click);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Controls.Add(this.reSize);
            this.panel2.Controls.Add(this.pbImg);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(870, 547);
            this.panel2.TabIndex = 3;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // reSize
            // 
            this.reSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.reSize.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.reSize.Location = new System.Drawing.Point(858, 515);
            this.reSize.Margin = new System.Windows.Forms.Padding(4);
            this.reSize.Name = "reSize";
            this.reSize.Size = new System.Drawing.Size(10, 10);
            this.reSize.TabIndex = 1;
            this.reSize.TabStop = false;
            this.reSize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.reSize_MouseDown);
            this.reSize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.reSize_MouseMove);
            this.reSize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.reSize_MouseUp);
            // 
            // pbImg
            // 
            this.pbImg.BackColor = System.Drawing.Color.White;
            this.pbImg.Location = new System.Drawing.Point(0, 0);
            this.pbImg.Margin = new System.Windows.Forms.Padding(4);
            this.pbImg.Name = "pbImg";
            this.pbImg.Size = new System.Drawing.Size(868, 525);
            this.pbImg.TabIndex = 0;
            this.pbImg.TabStop = false;
            this.pbImg.Click += new System.EventHandler(this.pbImg_Click);
            this.pbImg.Paint += new System.Windows.Forms.PaintEventHandler(this.pbImg_Paint);
            this.pbImg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbImg_MouseDown);
            this.pbImg.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbImg_MouseMove);
            this.pbImg.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbImg_MouseUp);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(113, 20);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // SmallPaint
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 547);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.status);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel2);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(873, 543);
            this.Name = "SmallPaint";
            this.Text = "绘图";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.DrawtoolStrip.ResumeLayout(false);
            this.DrawtoolStrip.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.reSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPic;
        private System.Windows.Forms.ToolStripMenuItem savePic;
        private System.Windows.Forms.ToolStripMenuItem SaveAs;
        private System.Windows.Forms.ToolStripMenuItem Quit;
        private System.Windows.Forms.ToolStripMenuItem 图片ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearPic;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip DrawtoolStrip;
        private System.Windows.Forms.ToolStripButton Line;
        private System.Windows.Forms.ToolStripButton Dot;
        private System.Windows.Forms.ToolStripButton Rect;
        private System.Windows.Forms.ToolStripStatusLabel currentDrawType;
        private System.Windows.Forms.ToolStripStatusLabel mousePostion;
        private System.Windows.Forms.ToolStripButton Circle;
        private System.Windows.Forms.ToolStripButton Eraser;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.PictureBox reSize;
        private ColorHatch.ColorHatch colorHatch1;
        private System.Windows.Forms.ToolStripMenuItem BuildNewPic;
        private System.Windows.Forms.ToolStripMenuItem AttributePic;
        private System.Windows.Forms.ToolStripButton Write;
        private System.Windows.Forms.ToolStripButton ColorPick;
        private System.Windows.Forms.ToolStripMenuItem 思维导图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 分支导图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 循环导图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem text;
        private System.Windows.Forms.PictureBox pbImg;
        private System.Windows.Forms.ToolStripMenuItem 完成导图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton Pointer;
        private System.Windows.Forms.ToolStripButton Arrows;
        private System.Windows.Forms.ToolStripButton TArrows;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图形工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 思维导图工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 颜色版选取ToolStripMenuItem;
    }
}

