using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CellMerge
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dt;

        public Form1()
        {
            InitializeComponent();
            dt = new DataTable();
            //为DataTable添加列
            //班级
            dt.Columns.Add("Class", typeof(string));
            //学生名称
            dt.Columns.Add("StuName", typeof(string));
            //成绩
            dt.Columns.Add("Score", typeof(string));
            //用以标识合并数据集
            dt.Columns.Add("GroupIndex", typeof(int));

            //grid控件绑定数据
            gridControl1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dt.Rows.Add("三年1班", "赵", "60", 1);
            dt.Rows.Add("三年1班", "李", "63", 1);
            dt.Rows.Add("三年1班", "钱", "62", 1);
            dt.Rows.Add("三年1班", "刘", "64", 1);

            dt.Rows.Add("三年2班", "赵", "60", 2);
            dt.Rows.Add("三年2班", "李", "63", 2);
            dt.Rows.Add("三年2班", "钱", "62", 2);
            dt.Rows.Add("三年2班", "刘", "64", 2);

            dt.Rows.Add("三年3班", "赵", "60", 3);
            dt.Rows.Add("三年3班", "李", "63", 3);
            dt.Rows.Add("三年3班", "钱", "62", 3);
            dt.Rows.Add("三年3班", "刘", "64", 3);

            dt.Rows.Add("三年4班", "赵", "60", 4);
            dt.Rows.Add("三年4班", "李", "63", 4);
            dt.Rows.Add("三年4班", "钱", "62", 4);
            dt.Rows.Add("三年4班", "刘", "64", 4);
        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            //根据鼠标位置获取点击信息
            GridHitInfo hInfo = view.CalcHitInfo(e.X, e.Y);
            if (hInfo.InRowCell && hInfo.Column.FieldName == "Class")
            {
                //获取单元格信息
                GridViewInfo vInfo = view.GetViewInfo() as GridViewInfo;
                GridCellInfo cInfo = vInfo.GetGridCellInfo(hInfo);
                //如果单元格为可合并的
                if (cInfo is GridMergedCellInfo)
                {
                    //MemoEdit控件属性
                    var edit = new MemoEdit();
                    edit.Bounds = cInfo.Bounds;
                    edit.Text = cInfo.CellValue.ToString();
                    //控件名称 定义为 memoedit+列名+GroupIndex值
                    edit.Name = "memoedit_" + hInfo.Column.FieldName + "_" + dt.Rows[hInfo.RowHandle]["GroupIndex"];
                    //控件鼠标离开事件
                    edit.MouseLeave += Edit_MouseLeave1;
                    //控件值改变事件
                    edit.EditValueChanged += Edit_EditValueChanged;
                    //将控件添加到GridControl中
                    gridControl1.Controls.Add(edit);
                }
            }
        }
        /// <summary>
        /// 当鼠标离开合并单元格时，删除添加的MemoEdit控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Edit_MouseLeave1(object sender, EventArgs e)
        {
            //遍历GridControl子控件，若名称含memoedit关键字，则获取并删除该控件
            List<int> removeList = new List<int>();
            for (int i = 0; i < gridControl1.Controls.Count; i++)
            {
                if (gridControl1.Controls[i].Name.Contains("memoedit"))
                {
                    removeList.Add(i);
                }
            }
            removeList.OrderByDescending(a => a);
            foreach (var r in removeList)
                gridControl1.Controls.RemoveAt(r);
        }
        /// <summary>
        /// 当MemoEdit控件值发生改变时，修改DataTable中的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Edit_EditValueChanged(object sender, EventArgs e)
        {
            MemoEdit memo = sender as MemoEdit;

            var strList = memo.Name.Split('_');

            if (strList[1] == "Class")
            {
                var group = dt.Rows.Cast<DataRow>().Where(a => a["GroupIndex"].ToString() == strList[2]).AsEnumerable();
                foreach (var g in group)
                {
                    dt.Rows[dt.Rows.IndexOf(g)]["Class"] = memo.EditValue.ToString();
                }
            }
        }
        /// <summary>
        /// GridControl控件单元格合并控制，只有当单元格为Class，且GroupIndex值相等时的才可以合并
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_CellMerge(object sender, CellMergeEventArgs e)
        {
            GridView view = sender as GridView;
            string value1 = view.GetDataRow(e.RowHandle1)["GroupIndex"].ToString();
            string value2 = view.GetDataRow(e.RowHandle2)["GroupIndex"].ToString();
            if (e.Column.FieldName == "Class")
            {
                string value3 = view.GetDataRow(e.RowHandle1)["Class"].ToString();
                string value4 = view.GetDataRow(e.RowHandle2)["Class"].ToString();
                e.Merge = value1 == value2 && value3 == value4;
                e.Handled = true;
            }
        }
    }
}
