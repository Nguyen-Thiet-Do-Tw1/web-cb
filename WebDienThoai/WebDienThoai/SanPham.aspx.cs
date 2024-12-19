using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGiaoHang;
using Newtonsoft.Json;
using System.IO;

namespace WebGiaoHang
{
    public partial class SanPham : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayProducts();
        }
        protected void DisplayProducts()
        {
            string jsonFilePath = Server.MapPath("~/product.json");
            string jsonData = File.ReadAllText(jsonFilePath);

            // Chuyển JSON thành danh sách sản phẩm
            var products = JsonConvert.DeserializeObject<List<product>>(jsonData);
            // Danh sách sản phẩm
            
            foreach (var product in products)
            {
                // Tạo phần tử HTML tương ứng cho mỗi sản phẩm
                var productDiv = new Panel();
                productDiv.CssClass = "main__group1--product-item";

                var productImgContainer = new Panel();
                productImgContainer.Attributes.Add("onclick", $"convert('{product.image}')");
                productImgContainer.CssClass = "product__img";
                productImgContainer.Style.Add("background-image", $"url('{product.image}')");

                var productName = new Literal();
                productName.Text = $"<div class='product__title' onclick='convert(\"{product.image}\")'>{product.ten}</div>";

                var productPrice = new Literal();
                productPrice.Text = $"<div class='product__money'><span class='product__money-first'>{product.giamgia}đ</span><span class='product__money-second'>{product.tien}đ</span></div>";

                var addToCartBtn = new LinkButton();
                addToCartBtn.CssClass = "btnShoppingCart";
                addToCartBtn.Click += (s, e) => AddToCart_Click(product.image);

                var addToCartIcon = new Literal();
                addToCartIcon.Text = "<i class='fa-solid fa-cart-plus iconshoppingCart'></i>";

                addToCartBtn.Controls.Add(addToCartIcon);
                addToCartBtn.Text = "Thêm vào giỏ hàng";

                // Thêm các phần tử vào trong productDiv
                productDiv.Controls.Add(productImgContainer); 
                productDiv.Controls.Add(productName);
                productDiv.Controls.Add(productPrice);
                productDiv.Controls.Add(addToCartBtn);

                // Thêm productDiv vào trong main__group1
                main__group1.Controls.Add(productDiv);
            }
        }

        // Hàm thêm sản phẩm vào giỏ hàng
        protected void AddToCart_Click(string image)
        {
            var cart = (ArrayList)Application["giohang"];
            var itemExists = false;

            // Đọc danh sách sản phẩm từ tệp JSON
            string jsonFilePath = Server.MapPath("~/product.json");
            string jsonData = File.ReadAllText(jsonFilePath);
            var products = JsonConvert.DeserializeObject<List<product>>(jsonData);

            // Tìm sản phẩm với hình ảnh được chọn
            foreach (var product in products)
            {
                if (product.image == image)
                {
                    foreach (inforproduct item in cart)
                    {
                        if (item.img == image)
                        {
                            item.soluong++;
                            itemExists = true;
                            break;
                        }
                    }

                    // Thêm sản phẩm vào giỏ hàng nếu chưa tồn tại trong giỏ hàng
                    if (!itemExists)
                    {
                        cart.Add(new inforproduct { img = image, soluong = 1, id = product.id }); // Thêm ID vào
                    }

                    break;
                }
            }

            Response.Redirect("SanPham.aspx");
        }

    }
}