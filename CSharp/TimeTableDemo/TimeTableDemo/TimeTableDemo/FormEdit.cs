using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTableDemo
{
    public partial class FormEdit : Form
    {
        DBDataContext db = new DBDataContext();
        public TimeTable TimeTable { get; set; }
        public FormEdit()
        {
            InitializeComponent();
            Load+=FormEdit_Load;
        }

        private void FormEdit_Load(object sender, EventArgs e)
        {

            BoundType();
            BoundTimeTable();
        }

        private void BoundTimeTable()
        {
            //初始化传递过来的item参数
            if (TimeTable == null) return;
            try
            {
                txtTitle.Text = TimeTable.Title;
                txtAddress.Text = TimeTable.Address;
                cboType.SelectedValue = TimeTable.TypeId;
                dtBeginTime.Value = Convert.ToDateTime(TimeTable.BeginTime);
                dtEndTime.Value = Convert.ToDateTime(TimeTable.EndTime);
                txtContent.Rtf = TimeTable.MainContent;
                cbStatus.Checked = Convert.ToBoolean(TimeTable.IsFinished);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void BoundType()
        {
            cboType.DataSource = db.Type.ToList();
            cboType.DisplayMember = "Name";
            cboType.ValueMember = "Id";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //判断是否为新增
            if (TimeTable == null)
            {
                db.TimeTable.InsertOnSubmit(new TimeTable
                {
                    Title = txtTitle.Text,
                    Address = txtAddress.Text,
                    TypeId = Convert.ToInt32(cboType.SelectedValue),
                    BeginTime = dtBeginTime.Value,
                    EndTime = dtEndTime.Value,
                    MainContent = txtContent.Rtf,
                    IsFinished = cbStatus.Checked
                });
                MessageBox.Show("新增成功！");
            }
            else
            {
                var item = db.TimeTable.FirstOrDefault(t => t.Id == TimeTable.Id);
                item.Title = txtTitle.Text;
                item.Address = txtAddress.Text;
                item.TypeId = Convert.ToInt32(cboType.SelectedValue);
                item.BeginTime = dtBeginTime.Value;
                item.EndTime = dtEndTime.Value;
                item.MainContent = txtContent.Rtf;
                item.IsFinished = cbStatus.Checked;
                MessageBox.Show("修改成功！");
            }
            db.SubmitChanges();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
