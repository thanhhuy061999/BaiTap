using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class QLDangNhap
    {
        public int Check_config()
        {
            if (Properties.Settings.Default.conn == string.Empty)
                return 1;
            SqlConnection _SqlConn = new SqlConnection(Properties.Settings.Default.conn);
            try
            {
                if (_SqlConn.State == System.Data.ConnectionState.Closed)
                    _SqlConn.Open();
                return 0;
            }
            catch
            {
                return 2;
            }
        }
        public int Check_User(string pUser, string pPass)
        {
            SqlDataAdapter daUser = new SqlDataAdapter("select * from QuanLyVeXemPhim where TenDangNhap='" + pUser + "' and MatKhau ='" + pPass + "'", Properties.Settings.Default.conn);
            DataTable dt = new DataTable();
            daUser.Fill(dt);
            if (dt.Rows.Count == 0)
                return 99;
            else if (dt.Rows[0][2] == null || dt.Rows[0][2].ToString() == "False")
            {
                return 100;
            }
            return 101;
        }
        public DataTable GetServerName()
        {
            DataTable dt = new DataTable();
            dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            return dt;
        }

        public DataTable GetDBName(string pServer, string pUser, string pPass)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select name from sys.Databases", "Data Source=" + pServer + ";Initial Catalog=master;User ID=" + pUser + ";pwd = " + pPass + "");
            da.Fill(dt);
            return dt;
        }
        public void SaveConfig(string pServer, string pUser, string pPass, string pDBname)
        {
            {
                GUI.Properties.Settings.Default.conn = "Data Source=" + pServer +
                ";Initial Catalog=" + pDBname + ";User ID=" + pUser + ";pwd = " + pPass + "";
                GUI.Properties.Settings.Default.Save();
            }
        }

    }
}
