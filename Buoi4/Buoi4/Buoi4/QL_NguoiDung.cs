using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi4
{

   public class QL_NguoiDung
    {
       public int Check_Config()
       {
           if (Properties.Settings.Default.testBuoi4 == string.Empty)
               return 1;
           SqlConnection _Sqlconn = new SqlConnection(Properties.Settings.Default.testBuoi4);
           try
           {
               if (_Sqlconn.State == System.Data.ConnectionState.Closed)
                   _Sqlconn.Open();
               return 0;
           }
           catch
           {
               return 2;
           }
       }
       public int Check_User(string pUser, string pPass)
       {
          SqlDataAdapter daUser = new SqlDataAdapter("select * from QL_NguoiDung where TenDangNhap='" + pUser + "' and MatKhau ='" + pPass + "'",Properties.Settings.Default.testBuoi4);
          DataTable dt = new DataTable();
          daUser.Fill(dt);
          if (dt.Rows.Count == 0)
              return 99;//user k ton tai
          else if(dt.Rows[0][2]==null||dt.Rows[0][2].ToString()=="False")
          {
              return 100;//khong hoat dong
          }
          return 101;//dang nhap thanh cong
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
           SqlDataAdapter da = new SqlDataAdapter("select name from sys.Databases",
           "Data Source=" + pServer + ";Initial Catalog=master;User ID=" + pUser + ";pwd = " +
           pPass + "");
           da.Fill(dt);
           return dt;
       }
       public void SaveConfig(string pServer, string pUser, string pPass, string pDBname)
       {
           Properties.Settings.Default.testBuoi4 = "Data Source=" + pServer +";Initial Catalog=" + pDBname + ";User ID=" + pUser + ";pwd = " + pPass + "";
           Properties.Settings.Default.Save();
       }
    }
}
