namespace CellMerge
{
    partial class Form1
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Class = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StuName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Score = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GroupIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(766, 356);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Class,
            this.StuName,
            this.Score,
            this.GroupIndex});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.AllowCellMerge = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellMerge += new DevExpress.XtraGrid.Views.Grid.CellMergeEventHandler(this.gridView1_CellMerge);
            this.gridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseDown);
            // 
            // Class
            // 
            this.Class.Caption = "班级";
            this.Class.FieldName = "Class";
            this.Class.Name = "Class";
            this.Class.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.Class.Visible = true;
            this.Class.VisibleIndex = 0;
            // 
            // StuName
            // 
            this.StuName.Caption = "姓名";
            this.StuName.FieldName = "StuName";
            this.StuName.Name = "StuName";
            this.StuName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.StuName.Visible = true;
            this.StuName.VisibleIndex = 1;
            // 
            // Score
            // 
            this.Score.Caption = "成绩";
            this.Score.FieldName = "Score";
            this.Score.Name = "Score";
            this.Score.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.Score.Visible = true;
            this.Score.VisibleIndex = 2;
            // 
            // GroupIndex
            // 
            this.GroupIndex.FieldName = "GroupIndex";
            this.GroupIndex.Name = "GroupIndex";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 380);
            this.Controls.Add(this.gridControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Class;
        private DevExpress.XtraGrid.Columns.GridColumn StuName;
        private DevExpress.XtraGrid.Columns.GridColumn Score;
        private DevExpress.XtraGrid.Columns.GridColumn GroupIndex;
    }
}

