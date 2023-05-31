using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using CustomerIPShowTool.Task;
using CustomerStatementReportTool;

namespace CustomerIPShowTool
{
    public partial class Main : Form
    {
        Load load = new Load();
        TaskLogic taskLogic = new TaskLogic();

        public Main()
        {
            InitializeComponent();
            OnRegisterEvents();
            OnShowTypeList();
            OnShowCustomerTypeList();
        }

        private void OnRegisterEvents()
        {
            btngenerate.Click += Btngenerate_Click;
            tmclose.Click += Tmclose_Click;
        }

        /// <summary>
        /// 运算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btngenerate_Click(object sender, EventArgs e)
        {
            try
            {
                //获取下拉列表所选值(客户端类型)
                var dvordertylelist = (DataRowView)comtype.Items[comtype.SelectedIndex];
                //获取下拉列表所选值(账号类型)
                var dvcusttypelist = (DataRowView)comtype.Items[comcusttype.SelectedIndex];

                // 获取输出地址
                var saveFileDialog = new SaveFileDialog { Filter = $"Xlsx文件|*.xlsx" };
                if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
                var fileAdd = saveFileDialog.FileName;

                //相关参数赋值
                taskLogic.Sdt = dtStr.Value.ToString("yyyy-MM-dd");  //开始日期
                taskLogic.Edt = dtEnd.Value.ToString("yyyy-MM-dd");  //结束日期
                taskLogic.Clienttype = Convert.ToString(dvordertylelist["Id"]);  //客户端类型
                taskLogic.Custtype = Convert.ToString(dvcusttypelist["Id"]);     //账号类型
                taskLogic.FileAddress = fileAdd;                     //输出地址

                //子线程调用
                new Thread(ExportGenerateRecordToExcel).Start();
                load.StartPosition = FormStartPosition.CenterScreen;
                load.ShowDialog();

                if (!taskLogic.ResultMark) throw new Exception("导出异常,请联系管理员");
                else
                {
                    MessageBox.Show($"导出成功!可从EXCEL中查阅导出效果", $"成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, $"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tmclose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, $"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        ///客户端类型下拉列表
        /// </summary>
        private void OnShowTypeList()
        {
            var dt = new DataTable();

            //创建表头
            for (var i = 0; i < 2; i++)
            {
                var dc = new DataColumn();
                switch (i)
                {
                    case 0:
                        dc.ColumnName = "Id";
                        break;
                    case 1:
                        dc.ColumnName = "Name";
                        break;
                }
                dt.Columns.Add(dc);
            }

            //创建行内容
            for (var j = 0; j < 7; j++)
            {
                var dr = dt.NewRow();

                switch (j)
                {
                    case 0:
                        dr[0] = "0";
                        dr[1] = "PC";
                        break;
                    case 1:
                        dr[0] = "2";
                        dr[1] = "Android";
                        break;
                    case 2:
                        dr[0] = "3";
                        dr[1] = "Phone(Android)";
                        break;
                    case 3:
                        dr[0] = "4";
                        dr[1] = "Phone(IOS)";
                        break;
                    case 4:
                        dr[0] = "5";
                        dr[1] = "Web";
                        break;
                    case 5:
                        dr[0] = "6";
                        dr[1] = "WebChat";
                        break;
                }
                dt.Rows.Add(dr);
            }

            comtype.DataSource = dt;
            comtype.DisplayMember = "Name"; //设置显示值
            comtype.ValueMember = "Id";    //设置默认值内码
        }


        /// <summary>
        ///账号类型下拉列表
        /// </summary>
        private void OnShowCustomerTypeList()
        {
            var dt = new DataTable();

            //创建表头
            for (var i = 0; i < 2; i++)
            {
                var dc = new DataColumn();
                switch (i)
                {
                    case 0:
                        dc.ColumnName = "Id";
                        break;
                    case 1:
                        dc.ColumnName = "Name";
                        break;
                }
                dt.Columns.Add(dc);
            }

            //创建行内容
            for (var j = 0; j < 2; j++)
            {
                var dr = dt.NewRow();

                switch (j)
                {
                    case 0:
                        dr[0] = "0";
                        dr[1] = "国内";
                        break;
                    case 1:
                        dr[0] = "1";
                        dr[1] = "海外";
                        break;
                }
                dt.Rows.Add(dr);
            }

            comcusttype.DataSource = dt;
            comcusttype.DisplayMember = "Name"; //设置显示值
            comcusttype.ValueMember = "Id";    //设置默认值内码
        }

        /// <summary>
        ///子线程使用(重:用于监视功能调用情况,当完成时进行关闭LoadForm)
        /// </summary>
        private void ExportGenerateRecordToExcel()
        {
            //查询历史记录
            taskLogic.GenerateRecordToExcel();

            //当完成后将Load子窗体关闭
            this.Invoke((ThreadStart)(() =>
            {
                load.Close();
            }));
        }
    }
}
