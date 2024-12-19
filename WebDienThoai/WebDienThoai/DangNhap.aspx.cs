using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebGiaoHang
{
    public partial class DangNhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button_Click(object sender, EventArgs e)
        {
            if (TxtName.Text.Trim() == "admin" && txtPassWord.Text.Trim() == "123")
            {
                Response.Redirect("admin.aspx");

            }
            if (TxtName.Text.Trim() == "" || txtPassWord.Text.Trim() == "")
            {
                lblError.Text = "Không được để trống!!!";
            }
            else
            {
                ArrayList arrayList = (ArrayList)Application["member"];

                int ok = 0;
                int check = 0;

                foreach (Member i in arrayList)
                {
                    if (i.username == TxtName.Text.Trim() && i.password.Trim() == txtPassWord.Text.Trim())
                    {
                        ok = 1;
                        break;
                    }
                    else if (i.username == TxtName.Text.Trim())
                    {
                        check = 1;
                    }
                }
                if (ok == 1)
                {
                    Session["user"] = TxtName.Text.Trim();
                    Response.Redirect("TrangChu.aspx");
                }
                else
                {
                    if (check == 1)
                    {
                        lblError.Text = "Sai mật khẩu vui lòng nhập lại!!!";
                    }
                    else
                    {
                        lblError.Text = "Tài khoản không có trong hệ thống !!!";
                    }
                }
            }
        }
    }
}
