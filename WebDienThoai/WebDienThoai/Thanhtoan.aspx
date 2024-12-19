<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Thanhtoan.aspx.cs" Inherits="WebDienThoai.Thanhtoan" %>

<!DOCTYPE html>
<link href="assets/css/Thanhtoan.css" rel="stylesheet" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div class="payment-container">
        <h2>Thanh Toán Đơn Hàng</h2>
        <form id="paymentForm" runat="server">
            <div class="form-group">
                <label for="name">Tên Khách Hàng:</label>
                <input type="text" id="name" name="customer_name" required="required" />
            </div>
            <div class="form-group">
                <label for="phone">Số Điện Thoại:</label>
                <input type="tel" id="phone" name="customer_phone" pattern="[0-9]{10}" required="required" title="Số điện thoại" />
                <small>Vui lòng nhập 10 chữ số.</small>
            </div>
            <div class="form-group">
                <label for="email">Email:</label>
                <input type="email" id="email" name="customer_email" required="required" />
            </div>
            <div class="form-group">
                <label for="address">Địa Chỉ Giao Hàng:</label>
                <input type="text" id="address" name="shipping_address" required="required" />
            </div>
            <div class="form-group">
                <label for="card-name">Tên Trên Thẻ:</label>
                <input type="text" id="card-name" name="card_name" required="required" />
            </div>
            <div class="form-group">
                <label for="card-number">Số Thẻ:</label>
                <input type="text" id="card-number" name="card_number" pattern="[0-9]{16}" required="required" title="Số Thẻ" />
                <small>Vui lòng nhập 16 chữ số.</small>
            </div>
            <div class="form-group">
                <label for="card-expiry">Ngày Hết Hạn:</label>
                <input type="text" id="card-expiry" name="card_expiry" pattern="(0[1-9]|1[0-2])\/?([0-9]{4}|[0-9]{2})" required="required" title="Ngày hết hạn"/>
                <small>Vui lòng nhập theo định dạng&nbsp; MM/YYYY.</small>
            </div>
            <div class="form-group">
                <label for="card-cvc">CVC:</label>
                <input type="text" id="card-cvc" name="card_cvc" pattern="[0-9]{3,4}" required="required" title="CVC"/>
                <small>Vui lòng nhập 3 hoặc 4 chữ số.</small>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Thanh Toán" Width="478px" />
            </div>
        </form>
    </div>
</body>
</html>
