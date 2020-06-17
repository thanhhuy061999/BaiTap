using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi4
{
    public partial class Form_CauHinh : Form
    {
        QL_NguoiDung CauHinh = new QL_NguoiDung();
        public Form_CauHinh()
        {
            InitializeComponent();
        }

        private void cbbServername_DropDown(object sender, EventArgs e)
        {
            cbbServername.DataSource = CauHinh.GetServerName();
            cbbServername.DisplayMember = "ServerName";
        }

        private void cbbDatabase_DropDown(object sender, EventArgs e)
        {
            cbbDatabase.DataSource = CauHinh.GetDBName(cbbServername.Text, txtUsername.Text, txtPassword.Text);
            cbbDatabase.DisplayMember = "name";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CauHinh.SaveConfig(cbbServername.Text, txtUsername.Text, txtPassword.Text,cbbDatabase.Text);
            this.Close();
        }
    }
}
