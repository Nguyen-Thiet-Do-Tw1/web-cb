using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebGiaoHang
{
    public partial class DangKy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_DangNhap(object sender, EventArgs e)
        {
            string s = (string)Session["user"];

            if (s == null)
            {
                Response.Redirect("DangNhap.aspx");
            }
        }

        protected void btn_DangKy(object sender, EventArgs e)
        {
            string s = (string)Session["user"];
            if (s == null)
            {
                Response.Redirect("DangKy.aspx");
            }
            else
            {
                Session["user"] = null;
                Response.Redirect("TrangChu.aspx");
            }
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            string s = txtName.Text.Trim();

            if (txtName.Text.Trim() == "" || txtPassWord.Text.Trim() == "" || txtRetypePassWord.Text.Trim() == "")
            {
                lblError.Text = "Không được để trống !!!";
            }
            else if (txtPassWord.Text.Trim().Length < 8)
            {
                lblError.Text = "Mật Khẩu Phải Có Độ Dài Đủ 8 ký tự";
            }
            else if (!Kiemtra3so(txtPassWord.Text.Trim()))
            {
                lblError.Text = "Mật khẩu phải bắt đầu bằng 3 chữ số";
            }
            else if (!Kiemtrachuhoa(txtPassWord.Text.Trim()))
            {
                lblError.Text = "Mật khẩu phải có ít nhất một chữ cái viết hoa";
            }
            else if (txtPassWord.Text.Trim() != txtRetypePassWord.Text.Trim())
            {
                lblError.Text = "Mật khẩu nhập lại không đúng !!!";
            }
            else if (Check(s) == 1)
            {
                ArrayList arrayList = (ArrayList)Application["member"];

                Member u = new Member();
                u.username = txtName.Text.Trim();
                u.password = txtPassWord.Text.Trim();

                arrayList.Add(u);

                lblError.Text = Check(s).ToString();

                Response.Redirect("TrangChu.aspx");
            }
            else
            {
                lblError.Text = "Tên người dùng đã tồn tại!!!";
            }
        }

        private int Check(string s)
        {
            ArrayList arr = (ArrayList)Application["member"];

            int ok = 1;

            foreach (Member i in arr)
            {
                if (i.username.ToString().CompareTo(s) == 0)
                {
                    return 0;
                }
            }
            return ok;
        }

        // kiểm tra bắt đầu bằng số
        private bool Kiemtra3so(string password)
        {
            return password.Length >= 3 && password.Substring(0, 3).All(char.IsDigit);
        }

        // Kiểm tra viết hoa
        private bool Kiemtrachuhoa(string password)
        {
            return password.Any(char.IsUpper);
        }

    }
}