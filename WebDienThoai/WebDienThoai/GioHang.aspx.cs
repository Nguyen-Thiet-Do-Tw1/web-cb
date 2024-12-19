using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebGiaoHang
{
    public partial class GioHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string jsonFilePath = Server.MapPath("~/product.json");
            string jsonData = File.ReadAllText(jsonFilePath);

            // Chuyển JSON thành danh sách sản phẩm
            var list = JsonConvert.DeserializeObject<List<product>>(jsonData);
            // Danh sách sản phẩm         
            
            ArrayList arr = (ArrayList)Application["giohang"];
            int cnt = 0;
            Int64 sum = 0;

            foreach (inforproduct i in arr)
            {
                cnt++;
            }

            SoluongSP.Text = cnt.ToString() + "<br/>";

            if (cnt > 0)
            {

                if (System.Web.HttpContext.Current.Session["cart"] == null)
                {
                    crateCart();
                }

                System.Web.HttpContext.Current.Session["cart"] = null;
                DataTable dt = new DataTable();
                dt.Columns.Add("productID", typeof(Int32));
                dt.Columns.Add("name", typeof(string));
                dt.Columns.Add("img", typeof(string));
                dt.Columns.Add("soluong", typeof(Int32));
                dt.Columns.Add("giatien", typeof(string));
                dt.Columns.Add("thanhtien", typeof(Int32));
                DataRow dr;


                foreach (inforproduct i in arr)
                {
                    foreach (product product in list)
                    {
                        if (product.image.ToString().CompareTo(i.img.ToString().Trim()) == 0)
                        {
                            dr = dt.NewRow();
                            dr["productID"] = product.id;
                            dr["name"] = product.ten.ToString();
                            dr["img"] = product.image.ToString();
                            dr["soluong"] = i.soluong;
                            dr["giatien"] = product.tien;
                            dr["thanhtien"] = i.soluong * product.tien;

                            sum += i.soluong * product.tien;
                            dt.Rows.Add(dr);
                        }
                    }
                }

                System.Web.HttpContext.Current.Session["cart"] = dt;
                DataTable u = new DataTable();
                u = (DataTable)System.Web.HttpContext.Current.Session["cart"];
                d2.DataSource = u;
                d2.DataBind();
            }
            lblTongTien.Text = sum.ToString() + "VND";
        }


        protected void crateCart()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("productID", typeof(Int32));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("img", typeof(string));
            dt.Columns.Add("soluong", typeof(Int32));
            dt.Columns.Add("giatien", typeof(string));
            dt.Columns.Add("thanhtien", typeof(Int32));

            d2.DataSource = dt;
            d2.DataBind();
            System.Web.HttpContext.Current.Session["cart"] = dt;
        }


        protected void delete(object sender, EventArgs e)
        {
            int id = int.Parse(((sender as LinkButton).NamingContainer.FindControl("lblProductID") as Label).Text);
            var cart = (ArrayList)Application["giohang"];

            // Tạo biến j để lưu trữ chỉ số cần xóa
            int j = -1;
            for (int i = 0; i < cart.Count; i++)
            {
                if ((cart[i] as inforproduct).id == id)
                {
                    j = i;
                    break;
                }
            }

            // Kiểm tra xem phần tử cần xóa có tồn tại không trước khi thực hiện xóa
            if (j != -1)
            {
                cart.RemoveAt(j);
            }
            else
            {
                
            }

            Response.Redirect("GioHang.aspx");
        }


        protected int KiemTra(string s)
        {
            int ans = 0;
            int ok = 1;

            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] - 48 > 9 || s[i] - 48 < 0)
                {
                    ok = 0;
                    break;
                }
                else
                {
                    ans = ans * 10 + (s[i] - 48);
                }
            }
            if (ok == 1) return ans;
            else return -1;
        }

        protected void Update(object sender, EventArgs e)
        {

            string s = IDThaydoi.Text;
            string ss = SLThaydoi.Text;
           

            if (s == "" || ss == "")
            {
                lblLoiUpdate.Text = "Không được để trống !!!!" + "<br/>";
            }
            else
            {
                int u = KiemTra(s);
                int v = KiemTra(ss);

                if (u == -1 || v == -1)
                {
                    lblLoiUpdate.Text = "Chỉ chấp nhận ký tự là số !!! Hãy thử nhập lại" + "<br/>";
                    IDThaydoi.Text = string.Empty;
                    SLThaydoi.Text = string.Empty;
                }
                else
                {
                    if (v <= 0)
                    {
                        lblLoiUpdate.Text = "Số lượng thay đổi không thể nhỏ hơn hoặc bằng 0 !!!!" + "<br/>";
                    }
                    else
                    {
                        int ok = 1;
                        string k = "";
                        ArrayList arr = (ArrayList)Application["giohang"];
                        foreach (inforproduct i in arr)
                        {
                            if (u == i.id)
                            {
                                i.soluong = v;
                                ok = 0;
                                break;
                            }

                            k += i.id;
                        }

                        if (ok == 1)
                        {
                            lblLoiUpdate.Text = "Không tìm thấy ID của sản phẩm trong giỏ hàng!!!!" + "<br/>";
                        }
                        else
                        {
                            Response.Redirect("GioHang.aspx");
                        }
                    }
                }
            }
        }

        protected void Muahang(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                lblMuaHangLoi.Text = "Vui lòng đăng nhập vô hệ thống để tiến hành thanh toán!!!" + "<br/>";
            }
            else
            {
                ArrayList arr = (ArrayList)Application["giohang"];
                int j = 0;
                arr.Clear();
                Response.Redirect("Thanhtoan.aspx");
            }
        }

        
    }
}