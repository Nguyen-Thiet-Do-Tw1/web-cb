using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebGiaoHang
{
    public partial class _layout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = (string)Session["user"];
            if (s != null)
            {
                btnDangNhap.Text = s;
                btnDangKy.Text = "Đăng Xuất";
            }

            ArrayList arr = (ArrayList)Application["giohang"];
            int cnt = 0;

            foreach (inforproduct i in arr)
            {
                cnt++;
            }

            lblCountProduct.Text = cnt.ToString();
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
    }
}