using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmDangNhap : Form
    {
        QLDangNhap CauHinh = new QLDangNhap();
        public frmDangNhap()
        {
            InitializeComponent();
        }

       
        private void ProcessConfig()
        {
            frmNguoiDung frm = new frmNguoiDung();
            frm.Show();

        }
        public void ProcessLogin()
        {
            int result;
            result = CauHinh.Check_User(txtTaiKhoan.Text, txtMatKhau.Text);
            if (result == 99)
            {
                MessageBox.Show("Sai ");
                return;
            }
            else if (result == 100)
            {
                MessageBox.Show("Tài khoản bị khóa");
                return;
            }
            if (Program.mainForm == null || Program.mainForm.IsDisposed)
            {
                Program.mainForm = new frmMain();
            }
            this.Visible = false;
            Program.mainForm.Show();
            MessageBox.Show("Đăng nhập thành công");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTaiKhoan.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống ");
                this.txtTaiKhoan.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMatKhau.Text.Trim()))
            {
                MessageBox.Show("không được bỏ trống ");
                this.txtMatKhau.Focus();
                return;
            }
            int kq = CauHinh.Check_config(); 
            if (kq == 0)
            {
                ProcessLogin();

            }
            if (kq == 1)
            {
                MessageBox.Show("Chuỗi cấu hình không tồn tại");
            }
            if (kq == 2)
            {
                MessageBox.Show("Chuỗi cấu hình không phù hợp");
                ProcessConfig();
            }
        }
    }
}
