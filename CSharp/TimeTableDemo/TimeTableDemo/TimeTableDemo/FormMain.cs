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
    //参考资料：https://ke.qq.com/webcourse/index.html#course_id=180951&term_id=100213879&taid=1059783180468951&vid=p1415ckkv22
    //使用C# WinForm创建个人日程管理
    public partial class FormMain : Form
    {
        DBDataContext db = new DBDataContext();
        public FormMain()
        {
            InitializeComponent();
            Closed += FormMain_Closed;
            Load += FormMain_Load;
        }

        void FormMain_Load(object sender, EventArgs e)
        {
            BoundType();
            BoundItems();
        }

        private void BoundItems()
        {
            //where用于过滤
            dgvItems.DataSource = db.TimeTable
                .Where(item=>item.Title.Contains(txtTitle.Text))
                .Where(item=>cboType.SelectedIndex==0?true:item.TypeId ==Convert.ToInt32(cboType.SelectedValue))
                .Where(item=>rdAll.Checked?true:item.IsFinished==Convert.ToBoolean(rdFinished.Checked))
                .Select(item=> new
                {
                    编号=item.Id,
                    标题=item.Title,
                    分类=item.Type.Name,
                    开始时间=item.BeginTime,
                    结束时间=item.EndTime,
                    状态=Convert.ToBoolean(item.IsFinished)?"已完成":"未完成"
                }).ToList();


            //MessageBox.Show("1"); 
                
        }

        private void BoundType()
        {
            //为combolbox绑定数据源
            var types = db.Type.ToList();
            types.Insert(0, new Type { Id=0,Name="全部"});
            cboType.DataSource = types;
            cboType.DisplayMember = "Name";
            cboType.ValueMember = "Id";
        }

        void FormMain_Closed(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 新建项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEdit fm = new FormEdit {TimeTable=null };//新增操作
            fm.ShowDialog();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BoundItems();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count > 0)
            {
                var id = Convert.ToInt32(dgvItems.SelectedRows[0].Cells[0].Value);
                var item = db.TimeTable.FirstOrDefault(t => t.Id == id);
                FormEdit fm = new FormEdit {TimeTable=item };
                fm.ShowDialog();
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count > 0)
            {
                var id = Convert.ToInt32(dgvItems.SelectedRows[0].Cells[0].Value);
                var item = db.TimeTable.FirstOrDefault(t => t.Id == id);
                db.TimeTable.DeleteOnSubmit(item);
                db.SubmitChanges();
                BoundItems();
            }
        }    
      
    }
}
