using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SQLServerTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            // 数据库连接字符串,database设置为自己的数据库名，以Windows身份验证
            //string constr = @"server=(localdb)\Projects;integrated security=sspi;database=MyDB";
            SqlConnectionStringBuilder sqlconsb = new SqlConnectionStringBuilder();
            sqlconsb.DataSource = @"(localdb)\Projects";
            sqlconsb.IntegratedSecurity = true;
            sqlconsb.InitialCatalog = "MyDB";

            try
            {
                using (SqlConnection sqlcon = new SqlConnection())
                {
                    // 打开数据库连接
                    sqlcon.ConnectionString = sqlconsb.ToString();
                    sqlcon.Open();

                    // 查询语句
                    string sql = "select * from newtable";

                    // 实例化适配器
                    SqlDataAdapter sqladp = new SqlDataAdapter(sql,sqlcon);

                    // 实例化数据表
                    DataTable dt = new DataTable();
                    
                    // 保存数据 
                    sqladp.Fill(dt);

                    // 设置到DataGridView中
                    dataGridView1.DataSource = dt;
                    //dataGridView1.Refresh();

                    // 关闭数据库连接
                    sqlcon.Close();
                
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"错误提示");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb.DataSource = @"(localdb)\Projects";
            sb.IntegratedSecurity = true;
            sb.InitialCatalog = "MyDB";
            SqlConnection sqlcon = new SqlConnection();
            sqlcon.ConnectionString = sb.ToString();
            string sql = "update newtable set department=N'女' where id=3";
            try
            {
                sqlcon.Open();
                SqlCommand sqlcom = new SqlCommand(sql,sqlcon);
                sqlcom.ExecuteNonQuery();
                MessageBox.Show("ok");
            }
            finally
            {
                sqlcon.Close();
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string constr = @"server=(localdb)\Projects;integrated security=sspi;database=MyDB";
            SqlConnection sqlcon = new SqlConnection();
            sqlcon.ConnectionString = constr;
            string sql = "insert newtable(name,department,tel,jointime,age) values(N'李四',N'测试部','170123456789','2018-5-6',23)";
            try
            {
                sqlcon.Open();
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);

                sqlcom.ExecuteNonQuery();
                MessageBox.Show("Test");
            }
            finally
            {
                sqlcon.Close();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string constr = @"server=(localdb)\Projects;integrated security=sspi;database=MyDB";
            SqlConnection sqlcon = new SqlConnection(constr);
            string sql = "delete newtable where name=N'李四'";
            SqlCommand sqlcom = new SqlCommand(sql,sqlcon);
            try
            {
                sqlcon.Open();
                sqlcom.ExecuteNonQuery();
                MessageBox.Show("ok");
            }
            finally {
                sqlcon.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
