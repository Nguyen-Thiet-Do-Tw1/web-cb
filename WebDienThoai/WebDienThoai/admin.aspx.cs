using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebDienThoai
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        // Đường dẫn đến tệp JSON chứa dữ liệu sản phẩm
        private string jsonFilePath = HttpContext.Current.Server.MapPath("~/product.json");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            if (IsValidInput())
            {
                if (FileUploadImage.HasFile)
                {
                    string fileName = Path.GetFileName(FileUploadImage.PostedFile.FileName);
                    string filePath = "~/assets/img/" + fileName; // Đường dẫn tới thư mục assets/img/ với tên file ảnh

                    string relativeImagePath = ResolveUrl("assets/img/") + fileName;

                    FileUploadImage.SaveAs(Server.MapPath(filePath));
                    double gia = double.Parse(TextBoxTien.Text);
                    double giamgia = double.Parse(TextBoxGiamgia.Text);
                    double PTgiamgia = 100 - (giamgia / gia * 100);

                    // Tạo một đối tượng JObject mới từ dữ liệu nhập vào từ người dùng, bao gồm đường dẫn đến ảnh
                    JObject newProduct = new JObject(
                        new JProperty("id", TextBoxID.Text),
                        new JProperty("ten", TextBoxTen.Text),
                        new JProperty("TH", TextBoxTH.Text),
                        new JProperty("image", relativeImagePath),
                        new JProperty("soluong", TextBoxSoluong.Text),
                        new JProperty("giamgia", TextBoxGiamgia.Text),
                        new JProperty("PTgiam", PTgiamgia),
                        new JProperty("tien", TextBoxTien.Text),
                        new JProperty("information", TextBoxInformation.Text)
                    );

                    // Đọc dữ liệu từ tệp JSON hiện có
                    string json = File.ReadAllText(jsonFilePath);
                    JArray products = JArray.Parse(json);
                    // Thêm đối tượng mới vào mảng sản phẩm
                    products.Add(newProduct);
                    // Ghi lại dữ liệu vào tệp JSON
                    File.WriteAllText(jsonFilePath, products.ToString());
                    // Cập nhật GridView
                    BindGrid();
                }
            }
            
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            if (IsValidInput())
            {
                if (FileUploadImage.HasFile)
                {
                    string fileName = Path.GetFileName(FileUploadImage.PostedFile.FileName);
                    string filePath = "assets/img/" + fileName;

                    FileUploadImage.SaveAs(Server.MapPath(filePath));

                    // Đọc dữ liệu từ tệp JSON hiện có
                    string json = File.ReadAllText(jsonFilePath);
                    JArray products = JArray.Parse(json);

                    // Tìm sản phẩm cần sửa và cập nhật thông tin, bao gồm đường dẫn đến ảnh
                    foreach (JObject product in products)
                    {
                        if (product["id"].ToString() == TextBoxID.Text)
                        {
                            product["ten"] = TextBoxTen.Text;
                            product["image"] = filePath;
                            product["soluong"] = TextBoxSoluong.Text;
                            product["giamgia"] = TextBoxGiamgia.Text;
                            product["tien"] = TextBoxTien.Text;
                            product["information"] = TextBoxInformation.Text;
                            break;
                        }
                    }

                    // Ghi lại dữ liệu vào tệp JSON
                    File.WriteAllText(jsonFilePath, products.ToString());

                    // Cập nhật GridView
                    BindGrid();
                }
            }
            
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            string productIdToDelete = TextBoxID.Text;

            // Đọc dữ liệu từ tệp JSON hiện có
            string json = File.ReadAllText(jsonFilePath);
            JArray products = JArray.Parse(json);

            // Tìm sản phẩm cần xóa theo mã sản phẩm
            JObject productToDelete = null;
            foreach (JObject product in products)
            {
                if (product["id"].ToString() == productIdToDelete)
                {
                    productToDelete = product;
                    break;
                }
            }

            if (productToDelete != null)
            {
                // Xóa sản phẩm khỏi danh sách
                products.Remove(productToDelete);

                // Ghi lại dữ liệu vào tệp JSON
                File.WriteAllText(jsonFilePath, products.ToString());

                // Cập nhật GridView
                BindGrid();
            }
            else
            {
                ErrorLabel.Text = "Không tìm thấy sản phẩm có mã số " + productIdToDelete + " để xóa.";
            }
        }


        private void BindGrid()
        {
            string json = File.ReadAllText(jsonFilePath);
            GridView1.DataSource = JsonConvert.DeserializeObject(json);
            GridView1.DataBind();
        }

        private bool IsValidInput()
        {
            // Kiểm tra ID đã tồn tại chưa
            string json = File.ReadAllText(jsonFilePath);
            JArray products = JArray.Parse(json);
            foreach (JObject product in products)
            {
                if (product["id"].ToString() == TextBoxID.Text)
                {
                    ErrorLabel.Text = "Mã Sp đã tồn tại";
                    return false;
                }
            }

            // Kiểm tra các trường không được để trống và giá trị > 0
            if (string.IsNullOrWhiteSpace(TextBoxID.Text) ||
                string.IsNullOrWhiteSpace(TextBoxTen.Text) ||
                string.IsNullOrWhiteSpace(TextBoxSoluong.Text) ||
                string.IsNullOrWhiteSpace(TextBoxGiamgia.Text) ||
                string.IsNullOrWhiteSpace(TextBoxTien.Text) ||
                string.IsNullOrWhiteSpace(TextBoxInformation.Text))
            {
                ErrorLabel.Text = "Vui lòng điền đầy đủ thông tin.";
                return false;
            }

            if (!int.TryParse(TextBoxSoluong.Text, out int soLuong) || soLuong <= 0)
            {
                ErrorLabel.Text = "Số lượng không hợp lệ";
                
                return false;
            }

            if (!int.TryParse(TextBoxGiamgia.Text, out int giamGia) || giamGia < 0)
            {
                ErrorLabel.Text = "Giảm giá không hợp lệ";

                // Giảm giá không hợp lệ
                return false;
            }

            if (!decimal.TryParse(TextBoxTien.Text, out decimal tien) || tien <= 0)
            {
                ErrorLabel.Text = "Tiền không hợp lệ";

                // Tiền không hợp lệ
                return false;
            }

            return true;
        }
        

    }
}
