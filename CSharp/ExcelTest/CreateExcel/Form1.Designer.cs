namespace CreateExcel
{
    partial class Form1
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
            this.btnCreateExcel = new System.Windows.Forms.Button();
            this.btnAddSheet = new System.Windows.Forms.Button();
            this.cmbSheets = new System.Windows.Forms.ComboBox();
            this.btnDeleteSheet = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSaveAsXls = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreateExcel
            // 
            this.btnCreateExcel.Location = new System.Drawing.Point(36, 12);
            this.btnCreateExcel.Name = "btnCreateExcel";
            this.btnCreateExcel.Size = new System.Drawing.Size(75, 23);
            this.btnCreateExcel.TabIndex = 0;
            this.btnCreateExcel.Text = "新建Excel";
            this.btnCreateExcel.UseVisualStyleBackColor = true;
            this.btnCreateExcel.Click += new System.EventHandler(this.btnCreateExcel_Click);
            // 
            // btnAddSheet
            // 
            this.btnAddSheet.Location = new System.Drawing.Point(36, 84);
            this.btnAddSheet.Name = "btnAddSheet";
            this.btnAddSheet.Size = new System.Drawing.Size(75, 23);
            this.btnAddSheet.TabIndex = 1;
            this.btnAddSheet.Text = "添加sheet";
            this.btnAddSheet.UseVisualStyleBackColor = true;
            this.btnAddSheet.Click += new System.EventHandler(this.btnAddSheet_Click);
            // 
            // cmbSheets
            // 
            this.cmbSheets.FormattingEnabled = true;
            this.cmbSheets.Location = new System.Drawing.Point(36, 44);
            this.cmbSheets.Name = "cmbSheets";
            this.cmbSheets.Size = new System.Drawing.Size(121, 20);
            this.cmbSheets.TabIndex = 2;
            // 
            // btnDeleteSheet
            // 
            this.btnDeleteSheet.Location = new System.Drawing.Point(172, 84);
            this.btnDeleteSheet.Name = "btnDeleteSheet";
            this.btnDeleteSheet.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteSheet.TabIndex = 3;
            this.btnDeleteSheet.Text = "删除sheet";
            this.btnDeleteSheet.UseVisualStyleBackColor = true;
            this.btnDeleteSheet.Click += new System.EventHandler(this.btnDeleteSheet_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(172, 41);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSaveAsXls
            // 
            this.btnSaveAsXls.Location = new System.Drawing.Point(36, 136);
            this.btnSaveAsXls.Name = "btnSaveAsXls";
            this.btnSaveAsXls.Size = new System.Drawing.Size(104, 23);
            this.btnSaveAsXls.TabIndex = 5;
            this.btnSaveAsXls.Text = "txt转换为excel";
            this.btnSaveAsXls.UseVisualStyleBackColor = true;
            this.btnSaveAsXls.Click += new System.EventHandler(this.btnSaveAsXls_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 299);
            this.Controls.Add(this.btnSaveAsXls);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDeleteSheet);
            this.Controls.Add(this.cmbSheets);
            this.Controls.Add(this.btnAddSheet);
            this.Controls.Add(this.btnCreateExcel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateExcel;
        private System.Windows.Forms.Button btnAddSheet;
        private System.Windows.Forms.ComboBox cmbSheets;
        private System.Windows.Forms.Button btnDeleteSheet;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSaveAsXls;
    }
}

