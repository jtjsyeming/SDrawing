using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Text;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;

namespace SmallPaint
{
    public partial class SmallPaint : Form
    {
        public SmallPaint()
        {
            InitializeComponent();
        }
        private DrawTools dt;
        private string sType;//绘图样式
        private string sFileName;//打开的文件名
        private bool bReSize = false;//是否改变画布大小
        private Size DefaultPicSize;//储存原始画布大小，用来新建文件时使用
        bool Moving = false;                // 标识是否在拖动控件
        Point MouseFirstLocation;           // 鼠标按下时, 相对于控件的坐标
        
        //鼠标在画板按下事件处理方法
        private void pbImg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (dt != null)
                {
                    dt.startDraw = true;//相当于所选工具被激活，可以开始绘图
                    dt.startPointF = new PointF(e.X, e.Y);
                }
                //隐藏按钮
                foreach (Control control in this.Controls)
                {
                    if (control is Button)
                    {
                        Button btn = (Button)control;
                        btn.Visible = false;
                    }
                    ActiveControl = null;//关闭光标激活状态
                }
            }
        }

        //pbimg＂鼠标移动＂事件处理方法
        private void pbImg_MouseMove(object sender, MouseEventArgs e)
        {
            Thread.Sleep(6);//减少cpu占用率
            mousePostion.Text = e.Location.ToString();
            if (dt.startDraw)
            {
                switch (sType)
                {
                    case "Pointer": dt.Pointer(e); break;
                    case "ColorPick": dt.ColorPick(e); break;
                    case "Dot": dt.DrawDot(e); break;
                    case "Eraser": dt.Eraser(e); break;
                    default: dt.Draw(e, sType); break;
                }
            }
        }

        //pbimg＂鼠标松开＂事件处理方法
        private void pbImg_MouseUp(object sender, MouseEventArgs e)
        {
            if (dt != null)
            {
                dt.EndDraw();
            }
        }

        //＂窗体加载＂事件处理方法
        private void Form1_Load(object sender, EventArgs e)
        {
            //减少闪烁提高效率
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();
            //定义控件宽高
            Bitmap bmp = new Bitmap(pbImg.Width, pbImg.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(new SolidBrush(pbImg.BackColor), new Rectangle(0, 0, pbImg.Width, pbImg.Height));
            g.Dispose();
            dt = new DrawTools(this.pbImg.CreateGraphics(), colorHatch1.HatchColor, bmp);//实例化工具类
            DefaultPicSize = pbImg.Size;

        }

        //＂打开文件＂事件处理方法
        private void openPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();//实例化文件打开对话框
            ofd.Filter = "JPG|*.jpg|Bmp|*.bmp|所有文件|*.*";//设置对话框打开文件的括展名
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmpformfile = new Bitmap(ofd.FileName);//获取打开的文件
                panel2.AutoScrollPosition = new Point(0, 0);//将滚动条复位
                pbImg.Size = bmpformfile.Size;//调整绘图区大小为图片大小

                reSize.Location = new Point(bmpformfile.Width, bmpformfile.Height);//reSize为用来实现手动调节画布大小用的
                //因为初始时的空白画布大小有限，"打开"操作可能引起画板大小改变，所以要将画板重新传入工具类
                dt.DrawTools_Graphics = pbImg.CreateGraphics();

                Bitmap bmp = new Bitmap(pbImg.Width, pbImg.Height);
                Graphics g = Graphics.FromImage(bmp);
                g.FillRectangle(new SolidBrush(pbImg.BackColor), new Rectangle(0, 0, pbImg.Width, pbImg.Height));//不使用这句话，那么这个bmp的背景就是透明的
                g.DrawImage(bmpformfile, 0, 0, bmpformfile.Width, bmpformfile.Height);//将图片画到画板上
                g.Dispose();//释放画板所占资源
                //不直接使用pbImg.Image = Image.FormFile(ofd.FileName)是因为这样会让图片一直处于打开状态，也就无法保存修改后的图片；
                bmpformfile.Dispose();//释放图片所占资源
                g = pbImg.CreateGraphics();
                g.DrawImage(bmp, 0, 0);
                g.Dispose();
                dt.OrginalImg = bmp;
                bmp.Dispose();
                sFileName = ofd.FileName;//储存打开的图片文件的详细路径，用来稍后能覆盖这个文件
                ofd.Dispose();

            }
        }

        //＂保存＂事件处理方法
        private void savePic_Click(object sender, EventArgs e)
        {
            if (sFileName != null)
            {

                if (MessageBox.Show("是否要保存文件？", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dt.OrginalImg.Save(sFileName);
                }
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "JPG(*.jpg)|*.jpg|BMP(*.bmp)|*.bmp";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    dt.OrginalImg.Save(sfd.FileName);
                    sFileName = sfd.FileName;
                }
            }

        }

        //窗体移动最小化等造成的pbimg＂重画＂事件处理方法
        private void pbImg_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(dt.OrginalImg, 0, 0);

        }

        //＂绘图工具选用＂事件处理方法
        private void tool_Click(object sender, EventArgs e)
        {
            ToolStripButton tsb = sender as ToolStripButton;
            if (tsb != null)
            {
                sType = tsb.Name;
                currentDrawType.Text = tsb.Text;
                if (sType == "Eraser")
                {
                    pbImg.Cursor = new Cursor(Application.StartupPath + @"\img\pb.cur");
                }
                else if (sType == "Write")
                {
                    pbImg.Cursor = Cursors.IBeam;
                }
                else if (sType == "ColorPick")
                {
                    pbImg.Cursor = new Cursor(Application.StartupPath + @"\img\ColorPicker.ico");
                }
                else if (sType == "Pointer")
                {
                    pbImg.Cursor = Cursor.Current;
                }
                else
                {
                    pbImg.Cursor = Cursors.Cross;
                }
            }
        }

        //＂清除图像＂事件处理方法
        private void clearPic_Click(object sender, EventArgs e)
        {
            Bitmap newpic = new Bitmap(pbImg.Width, pbImg.Height);
            Graphics g = Graphics.FromImage(newpic);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, pbImg.Width, pbImg.Height);
            g.Dispose();
            g = pbImg.CreateGraphics();
            g.DrawImage(newpic, 0, 0);
            g.Dispose();
            dt.OrginalImg = newpic;
        }

        //＂另存为＂事件处理方法
        private void SaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JPG(*.jpg)|*.jpg|BMP(*.bmp)|*.bmp";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                dt.OrginalImg.Save(sfd.FileName);
                sFileName = sfd.FileName;
            }
        }

        //＂退出＂事件处理方法
        private void Quit_Click(object sender, EventArgs e)
        {
            dt.ClearVar();
            Application.Exit();
        }

        //＂颜色改变＂事件处理方法
        private void colorHatch1_ColorChanged(object sender, ColorHatch.ColorChangedEventArgs e)
        {
            dt.DrawColor = e.GetColor;
        }


        private void reSize_MouseDown(object sender, MouseEventArgs e)
        {
            bReSize = true;//当鼠标按下时，说明要开始调节大小
        }

        private void reSize_MouseMove(object sender, MouseEventArgs e)
        {
            if (bReSize)
            {
                reSize.Location = new Point(reSize.Location.X + e.X, reSize.Location.Y + e.Y);
            }
        }

        private void reSize_MouseUp(object sender, MouseEventArgs e)
        {
            bReSize = false;//大小改变结束

            pbImg.Size = new Size(reSize.Location.X - (this.panel2.AutoScrollPosition.X), reSize.Location.Y - (this.panel2.AutoScrollPosition.Y));
            dt.DrawTools_Graphics = pbImg.CreateGraphics();//因为画板的大小被改变所以必须重新赋值

            //另外画布也被改变所以也要重新赋值
            Bitmap bmp = new Bitmap(pbImg.Width, pbImg.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, pbImg.Width, pbImg.Height);
            g.DrawImage(dt.OrginalImg, 0, 0);
            g.Dispose();
            g = pbImg.CreateGraphics();
            g.DrawImage(bmp, 0, 0);
            g.Dispose();
            dt.OrginalImg = bmp;

            bmp.Dispose();
        }
        //定义“新建”事件处理方法
        private void BuildNewPic_Click(object sender, EventArgs e)
        {

            pbImg.Size = DefaultPicSize;
            this.panel2.AutoScrollPosition = new Point(0, 0);
            Bitmap bmp = new Bitmap(DefaultPicSize.Width, DefaultPicSize.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, DefaultPicSize.Width, DefaultPicSize.Height);
            g.Dispose();
            g = pbImg.CreateGraphics();
            g.DrawImage(bmp, 0, 0);
            g.Dispose();
            reSize.Location = new Point(DefaultPicSize.Width, DefaultPicSize.Height);
            dt.OrginalImg = bmp;
            sFileName = null;
        }

        //定义“图片属性”事件处理方法
        private void AttributePic_Click(object sender, EventArgs e)
        {
            MessageBox.Show("图像高:" + pbImg.Height + " px ,图像宽:" + pbImg.Width + " px", "图像属性");
        }

        //创建分支导图
        private void Branch_Guides_Click(object sender, EventArgs e)
        {
            TextBox box = new TextBox();
            Button btnleft1 = new Button();//左上角的按钮
            Button btnleft2 = new Button();//左下角的按钮
            Button btnright1 = new Button();//右上角的按钮
            Button btnright2 = new Button();//右下角的按钮
            //设置按钮名字在生成的时候会用到
            btnleft1.Name = "left1";
            btnleft2.Name = "left2";
            btnright1.Name = "right1";
            btnright2.Name = "right2";
            box.Size = new Size(100, 30);//设置文本框大小
            box.Location = new Point(150, 150);//设置文本框位置
            //设置四个按钮的位置
            btnleft1.Location = new Point(box.Location.X - 10, box.Location.Y - 10);
            btnleft2.Location = new Point(box.Location.X - 10, box.Location.Y + box.Size.Height + 10);
            btnright1.Location = new Point(box.Location.X + box.Size.Width, box.Location.Y - 10);
            btnright2.Location = new Point(box.Location.X + box.Size.Width, box.Location.Y + box.Size.Height + 10);
            //设置四个按钮的大小
            btnleft1.Size = new Size(10, 10);
            btnleft2.Size = new Size(10, 10);
            btnright1.Size = new Size(10, 10);
            btnright2.Size = new Size(10, 10);
            box.Multiline = true;//多行显示自动换行
            box.BackColor = Color.Beige;//设置文本框背景颜色
            box.TextAlign = (HorizontalAlignment)2;//设置文字居中
            box.BorderStyle = BorderStyle.None;//设置无边框模式
            //控件加入控件集合
            this.Controls.Add(box);
            this.Controls.Add(btnleft1);
            this.Controls.Add(btnleft2);
            this.Controls.Add(btnright1);
            this.Controls.Add(btnright2);
            //设置控件显示最上层
            box.BringToFront();
            btnleft1.BringToFront();
            btnleft2.BringToFront();
            btnright1.BringToFront();
            btnright2.BringToFront();
            //删除
            box.KeyDown += Form1_KeyDown;
            //隐藏按钮
            //btnleft1.Visible = false;
            //btnleft2.Visible = false;
            //btnright1.Visible = false;
            //btnright2.Visible = false;
            btnleft1.Click += new System.EventHandler(this.New_Branch_Guides_Click);
            btnleft2.Click += new System.EventHandler(this.New_Branch_Guides_Click);
            btnright1.Click += new System.EventHandler(this.New_Branch_Guides_Click);
            btnright2.Click += new System.EventHandler(this.New_Branch_Guides_Click);
            box.Enter += new EventHandler(SetTextBoxOnEnterStyle);
            box.Leave += new EventHandler(SetTextBoxOnLeaveStyle);
            box.MouseEnter += new EventHandler(SetMouseEnter);
            box.MouseLeave += new EventHandler(SetMouseLeave);
        }

        //新建分支导图分支
        private void New_Branch_Guides_Click(object sender, EventArgs e)
        {
            Button Btn = sender as Button;//获取按下的按钮
            //实例化textbox控件
            TextBox box = new TextBox();
            //实例化新建的四个按钮
            Button btnleft1 = new Button();
            Button btnleft2 = new Button();
            Button btnright1 = new Button();
            Button btnright2 = new Button();
            box.Size = new Size(100, 30);
            //给新建的按钮命名
            btnleft1.Name = "left1";
            btnleft2.Name = "left2";
            btnright1.Name = "right1";
            btnright2.Name = "right2";
            //判断按下的是哪个按钮，确定新建的textbox的位置
            if (Btn.Name == "left1")
            {
                box.Location = new Point(Btn.Location.X - 110, Btn.Location.Y - 40);
            }
            else if (Btn.Name == "left2")
            {
                box.Location = new Point(Btn.Location.X - 110, Btn.Location.Y + 20 );
            }
            else if (Btn.Name == "right1")
            {
                box.Location = new Point(Btn.Location.X + 20, Btn.Location.Y - 40);
            }
            else
            {
                box.Location = new Point(Btn.Location.X + 20, Btn.Location.Y + 20);
            }
            //确定四个按钮的位置
            btnleft1.Location = new Point(box.Location.X - 10, box.Location.Y - 10);
            btnleft2.Location = new Point(box.Location.X - 10, box.Location.Y + box.Size.Height + 10);
            btnright1.Location = new Point(box.Location.X + box.Size.Width, box.Location.Y - 10);
            btnright2.Location = new Point(box.Location.X + box.Size.Width, box.Location.Y + box.Size.Height + 10);
            //设置四个按钮的大小
            btnleft1.Size = new Size(10, 10);
            btnleft2.Size = new Size(10, 10);
            btnright1.Size = new Size(10, 10);
            btnright2.Size = new Size(10, 10);
            box.Multiline = true;//多行显示自动换行
            box.BackColor = Color.Beige;//设置背景颜色
            box.TextAlign = (HorizontalAlignment)2;//设置文字居中
            box.BorderStyle = BorderStyle.None;//设置无边框模式
            //把控件添加到控件集合中
            this.Controls.Add(box);
            this.Controls.Add(btnleft1);
            this.Controls.Add(btnleft2);
            this.Controls.Add(btnright1);
            this.Controls.Add(btnright2);
            //把控件制顶
            box.BringToFront();
            btnleft1.BringToFront();
            btnleft2.BringToFront();
            btnright1.BringToFront();
            btnright2.BringToFront();
            if (box.Location.X <= 50 || box.Location.Y <= 20)
            {
                this.Controls.Remove(box);
                this.Controls.Remove(btnleft1);
                this.Controls.Remove(btnleft2);
                this.Controls.Remove(btnright1);
                this.Controls.Remove(btnright2);
            }
            box.KeyDown += Form1_KeyDown;
            //每个按钮的点击事件
            btnleft1.Click += new System.EventHandler(this.New_Branch_Guides_Click);
            btnleft2.Click += new System.EventHandler(this.New_Branch_Guides_Click);
            btnright1.Click += new System.EventHandler(this.New_Branch_Guides_Click);
            btnright2.Click += new System.EventHandler(this.New_Branch_Guides_Click);
            box.Enter += new EventHandler(SetTextBoxOnEnterStyle);
            box.Leave += new EventHandler(SetTextBoxOnLeaveStyle);
            box.MouseEnter += new EventHandler(SetMouseEnter);
            box.MouseLeave += new EventHandler(SetMouseLeave);
        }
        //创建循环导图
        private void Circular_Guide_Click(object sender, EventArgs e)
        {
            TextBox box = new TextBox();
            Button btnunder = new Button();
            Button btnleft = new Button();
            Button btndown = new Button();
            Button btnright = new Button();
            btnunder.Name = "under";
            btndown.Name = "down";
            btnleft.Name = "left";
            btnright.Name = "right";
            box.Size = new Size(100, 30);
            box.Location = new Point(150, 150);
            btnunder.Location = new Point(box.Location.X + box.Size.Width / 2 - 5, box.Location.Y - 10);
            btnleft.Location = new Point(box.Location.X - 10, box.Location.Y + box.Size.Height / 2);
            btndown.Location = new Point(box.Location.X + box.Size.Width / 2 - 5, box.Location.Y + box.Size.Height +10);
            btnright.Location = new Point(box.Location.X + box.Size.Width, box.Location.Y + box.Size.Height / 2);
            btnunder.Size = new Size(10, 10);
            btnleft.Size = new Size(10, 10);
            btndown.Size = new Size(10, 10);
            btnright.Size = new Size(10, 10);
            box.Multiline = true;//多行显示自动换行
            box.BackColor = Color.Beige;
            box.TextAlign = (HorizontalAlignment)2;//设置文字居中
            box.BorderStyle = BorderStyle.None;//设置无边框模式
            this.Controls.Add(box);
            this.Controls.Add(btnunder);
            this.Controls.Add(btnleft);
            this.Controls.Add(btndown);
            this.Controls.Add(btnright);
            box.BringToFront();
            btnunder.BringToFront();
            btnleft.BringToFront();
            btndown.BringToFront();
            btnright.BringToFront();
            box.KeyDown += Form1_KeyDown;
            btnunder.Click += new System.EventHandler(this.New_Circular_Guide_Click);
            btnleft.Click += new System.EventHandler(this.New_Circular_Guide_Click);
            btndown.Click += new System.EventHandler(this.New_Circular_Guide_Click);
            btnright.Click += new System.EventHandler(this.New_Circular_Guide_Click);
            box.Enter += new EventHandler(SetTextBoxOnEnterStyle);
            box.Leave += new EventHandler(SetTextBoxOnLeaveStyle);
            box.MouseEnter += new EventHandler(SetMouseEnter);
            box.MouseLeave += new EventHandler(SetMouseLeave);
        }

        //新建循环导图分支
        private void New_Circular_Guide_Click(object sender, EventArgs e)
        {
            Button Btn = sender as Button;
            TextBox box = new TextBox();
            Button btnunder = new Button();
            Button btnleft = new Button();
            Button btndown = new Button();
            Button btnright = new Button();
            btnunder.Name = "under";
            btndown.Name = "down";
            btnleft.Name = "left";
            btnright.Name = "right";
            box.Size = new Size(100, 30);
            if(Btn.Name == "under")
            {
                box.Location = new Point(Btn.Location.X - 45, Btn.Location.Y - 40);
            }
            else if(Btn.Name == "left")
            {
                box.Location = new Point(Btn.Location.X - 110, Btn.Location.Y -10);
            }
            else if(Btn.Name == "down")
            {
                box.Location = new Point(Btn.Location.X - 45, Btn.Location.Y + 20);
            }
            else if(Btn.Name == "right")
            {
                box.Location = new Point(Btn.Location.X + 20, Btn.Location.Y - 10);
            }
            btnunder.Location = new Point(box.Location.X + box.Size.Width / 2 - 5, box.Location.Y - 10);
            btnleft.Location = new Point(box.Location.X - 10, box.Location.Y + box.Size.Height / 2);
            btndown.Location = new Point(box.Location.X + box.Size.Width / 2 - 5, box.Location.Y + box.Size.Height + 10);
            btnright.Location = new Point(box.Location.X + box.Size.Width, box.Location.Y + box.Size.Height / 2);
            btnunder.Size = new Size(10, 10);
            btnleft.Size = new Size(10, 10);
            btndown.Size = new Size(10, 10);
            btnright.Size = new Size(10, 10);
            box.Multiline = true;//多行显示自动换行
            box.BackColor = Color.Beige;
            box.TextAlign = (HorizontalAlignment)2;//设置文字居中
            box.BorderStyle = BorderStyle.None;//设置无边框模式
            this.Controls.Add(box);
            this.Controls.Add(btnunder);
            this.Controls.Add(btnleft);
            this.Controls.Add(btndown);
            this.Controls.Add(btnright);
            box.BringToFront();
            box.Show();
            btnunder.BringToFront();
            btnleft.BringToFront();
            btndown.BringToFront();
            btnright.BringToFront();
            if(box.Location.X <= 50  || box.Location.Y <= 20)
            {
                this.Controls.Remove(box);
                this.Controls.Remove(btnunder);
                this.Controls.Remove(btnleft);
                this.Controls.Remove(btndown);
                this.Controls.Remove(btnright);
            }
            box.KeyDown += Form1_KeyDown;
            btnunder.Click += new System.EventHandler(this.New_Circular_Guide_Click);
            btnleft.Click += new System.EventHandler(this.New_Circular_Guide_Click);
            btndown.Click += new System.EventHandler(this.New_Circular_Guide_Click);
            btnright.Click += new System.EventHandler(this.New_Circular_Guide_Click);
            box.Enter += new EventHandler(SetTextBoxOnEnterStyle);
            box.Leave += new EventHandler(SetTextBoxOnLeaveStyle);
            box.MouseEnter += new EventHandler(SetMouseEnter);
            box.MouseLeave += new EventHandler(SetMouseLeave);
        }

        //文本框
        private void text_Click(object sender, EventArgs e)
        {
            TextBox box = new TextBox();
            box.Multiline = true;//多行显示自动换行
            box.Size = new Size(100, 30);
            box.BackColor = Color.Beige;
            box.TextAlign = (HorizontalAlignment)2;//设置文字居中
            box.BorderStyle = BorderStyle.None;//设置无边框模式
            box.Location = new Point(150, 150);
            this.Controls.Add(box);
            box.KeyDown += Form1_KeyDown;
            box.KeyDown += Form2_KeyDown;
            box.BringToFront();
            box.MouseDown += Exemple_MouseDown;
            box.MouseMove += Exemple_MouseMove;
            box.MouseUp += Exemple_MouseUp;
            box.Enter += new EventHandler(SetTextBoxOnEnterStyle);
            box.Leave += new EventHandler(SetTextBoxOnLeaveStyle);
            box.MouseLeave += new EventHandler(SetMouseLeave);
            box.MouseEnter += new EventHandler(SetMouseEnter);
        }
        //鼠标按键删除
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    Control control = this.Controls[i] as Control;
                    if (control.Focused)
                    {
                        this.Controls.Remove(control);
                    }
                }
            }
        }
        //按F5键保存到画板上
        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                dt.startDraw = true;
                if (dt.startDraw)
                {
                    dt.Guide(sender, e);
                }
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    Control control = this.Controls[i] as Control;
                    if (control.Focused)
                    {
                        this.Controls.Remove(control);

                    }
                }
            }
        }
        //鼠标在Textbox上时设置为高亮
        public void SetMouseEnter(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                //设置黄色
                TextBox tbox = sender as TextBox;
                if (!tbox.ReadOnly)
                {
                    tbox.BackColor = Color.Yellow;
                }
            }
        }

        //鼠标在Textbox外时,把文本框变回默认颜色
        public void SetMouseLeave(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                //设为默认颜色
                TextBox tbox = sender as TextBox;
                if (!tbox.ReadOnly)
                {
                    tbox.BackColor = Color.Beige;
                }
            }
        }
        //鼠标点击文本框显示按钮
        public virtual void SetTextBoxOnEnterStyle(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox tbox = new TextBox();
                //设置显示按钮
                if (!tbox.ReadOnly)
                {
                    foreach (Control control in this.Controls)
                    {
                        if (control is Button)
                        {
                            Button btn = (Button)control;
                            btn.Visible = true;
                        }
                    }
                }
            }
        }
        //鼠标点击其他控件变为默认颜色
        public virtual void SetTextBoxOnLeaveStyle(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox tbox = sender as TextBox;
                if (!tbox.ReadOnly)
                {
                    tbox.BackColor = Color.Beige;
                }
            }

        }

        //鼠标按下移动控件
        private void Exemple_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox box = sender as TextBox;
            Moving = true;   // 表示进入拖动控件的状态
            Point MousePoint = Control.MousePosition;    // 获取鼠标相对屏幕的坐标
            MouseFirstLocation = box.PointToClient(MousePoint);    // 获取坐标相对于控件的相对坐标并赋值给MouseFirstLocation
        }
        private void Exemple_MouseMove(object sender, MouseEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (Moving)
            {
                Point MousePoint = Control.MousePosition;  // 获取鼠标相对屏幕的坐标
                Point MousePointToContainer = box.Parent.PointToClient(MousePoint);  // 获取鼠标相对控件父容器的坐标
                Point ControlNewLocation = new Point(MousePointToContainer.X - MouseFirstLocation.X, MousePointToContainer.Y - MouseFirstLocation.Y);       // 计算控件应处于的, 新的坐标
                box.Location = ControlNewLocation; // 移动控件
            }
        }

        private void Exemple_MouseUp(object sender, MouseEventArgs e)
        {
            Moving = false;   // 脱离拖动控件的状态
        }

        private void 完成导图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dt.startDraw = true;
            if (dt.startDraw)
            {
                dt.Guide(sender, e);
            }
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void status_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void colorHatch1_Load(object sender, EventArgs e)
        {

        }

        private void pbImg_Click(object sender, EventArgs e)
        {

        }


        private void ColorPick_Click(object sender, EventArgs e)
        {

        }

        private void 图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 思维导图ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void 图形工具ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("图形工具在软件的左侧工具栏上半部分，依次为：箭头工具、直线工具、矩形工具、橡皮工具、圆形工具、铅笔工具单向箭头工具、双向箭头工具、文本框背景工具和吸管工具");
        }

        private void 思维导图工具ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("思维导图工具分为：分支导图、循环导图、文本和绘制完成按钮\r\n分支导图：分支导图可以创建出一个带有四个按钮的文本框，四个按钮分别在文本框的四个顶点，用户可以在文本框内部输入文字，点击文本框的四个顶点所在的按钮，会在顶点相应位置创建一个新的带有四个按钮的文本框，同样可以输入文字和创建新文本框。\r\n循环导图：循环导图可以创建出一个类似分支导图的文本框，但不同的是，循环导图创建的按钮在文本框的上下左右中点的位置除。\r\n文本：文本按钮可以创建一个独立的文本框，可以输入文字，并且点击鼠标左键可以拖动，但是不能创建新的分支。\r\n完成绘图：把文本框画到画板上。");
        }

        private void 颜色版选取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("颜色选择工具可以供用户选择自动生成的颜色，并且用户可以自主选择颜色的RGB值来创建新的颜色");
        }
    }
}