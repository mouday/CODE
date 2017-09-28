using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace AccessTest
{
    class AccessHelper_PSY
    {

        public static DataTable GetDataTable(string Accesspath, string tableName)
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"" + Accesspath + "\"");
            //Jet OLEDB:Database Password=
            OleDbCommand cmd = conn.CreateCommand();

            cmd.CommandText = "select * from " + tableName + "\"";
            conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            if (dr.HasRows)
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    dt.Columns.Add(dr.GetName(i));
                }
                dt.Rows.Clear();
            }
            while (dr.Read())
            {
                DataRow row = dt.NewRow();
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    row[i] = dr[i];
                }
                dt.Rows.Add(row);
            }
            cmd.Dispose();
            conn.Close();
            return dt;
        }
    }
}
