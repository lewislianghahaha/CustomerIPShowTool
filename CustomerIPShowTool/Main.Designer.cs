namespace CustomerIPShowTool
{
    partial class Main
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtStr = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tmclose = new System.Windows.Forms.ToolStripMenuItem();
            this.txtadd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnsetadd = new System.Windows.Forms.Button();
            this.btngenerate = new System.Windows.Forms.Button();
            this.comtype = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtEnd
            // 
            this.dtEnd.CustomFormat = "yyyy-MM-dd";
            this.dtEnd.Location = new System.Drawing.Point(101, 86);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(140, 21);
            this.dtEnd.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "结束日期:";
            // 
            // dtStr
            // 
            this.dtStr.CustomFormat = "yyyy-MM-dd";
            this.dtStr.Location = new System.Drawing.Point(101, 49);
            this.dtStr.Name = "dtStr";
            this.dtStr.Size = new System.Drawing.Size(140, 21);
            this.dtStr.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "开始日期:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmclose});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(336, 25);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tmclose
            // 
            this.tmclose.Name = "tmclose";
            this.tmclose.Size = new System.Drawing.Size(44, 21);
            this.tmclose.Text = "关闭";
            // 
            // txtadd
            // 
            this.txtadd.Enabled = false;
            this.txtadd.Location = new System.Drawing.Point(101, 177);
            this.txtadd.Name = "txtadd";
            this.txtadd.Size = new System.Drawing.Size(223, 21);
            this.txtadd.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "设置导出地址:";
            // 
            // btnsetadd
            // 
            this.btnsetadd.Location = new System.Drawing.Point(101, 210);
            this.btnsetadd.Name = "btnsetadd";
            this.btnsetadd.Size = new System.Drawing.Size(75, 23);
            this.btnsetadd.TabIndex = 15;
            this.btnsetadd.Text = "浏览";
            this.btnsetadd.UseVisualStyleBackColor = true;
            // 
            // btngenerate
            // 
            this.btngenerate.Location = new System.Drawing.Point(249, 210);
            this.btngenerate.Name = "btngenerate";
            this.btngenerate.Size = new System.Drawing.Size(75, 23);
            this.btngenerate.TabIndex = 16;
            this.btngenerate.Text = "运算";
            this.btngenerate.UseVisualStyleBackColor = true;
            // 
            // comtype
            // 
            this.comtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comtype.FormattingEnabled = true;
            this.comtype.Location = new System.Drawing.Point(101, 119);
            this.comtype.Name = "comtype";
            this.comtype.Size = new System.Drawing.Size(140, 20);
            this.comtype.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "客户端类型:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 20;
            this.label5.Text = "账号类型:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(101, 146);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(140, 20);
            this.comboBox1.TabIndex = 19;
            // 
            // Main
            // 
            this.AcceptButton = this.btngenerate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 242);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comtype);
            this.Controls.Add(this.btngenerate);
            this.Controls.Add(this.btnsetadd);
            this.Controls.Add(this.txtadd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dtEnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtStr);
            this.Controls.Add(this.label1);
            this.Name = "Main";
            this.Text = "配方客户API明细信息导出工具";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtStr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tmclose;
        private System.Windows.Forms.TextBox txtadd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnsetadd;
        private System.Windows.Forms.Button btngenerate;
        private System.Windows.Forms.ComboBox comtype;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

