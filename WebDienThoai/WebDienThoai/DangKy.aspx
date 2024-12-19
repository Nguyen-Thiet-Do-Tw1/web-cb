<%@ Page Title="" Language="C#" MasterPageFile="~/_layout.Master" AutoEventWireup="true" CodeBehind="DangKy.aspx.cs" Inherits="WebGiaoHang.DangKy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/css/DangKy.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>
        <div class="form">
            <div class="form__title">
                <a href="DangNhap.aspx" class="form__title--first">
                    <span class="form__title--text">ĐĂNG  NHẬP</span>
                </a>
                <a href="DangKy.aspx" class="form__title--second">
                    <span class="form__title--text"> ĐĂNG  KÝ </span>
                </a>
            </div>
            <div class="form__content">
                <p style="font-size: 1.3rem; margin-left: 20px; margin-top:20px;"> Đăng ký để chúng tôi phục vụ bạn tốt hơn  !</p>
                <span style="margin-left:20px; font-size:1.5rem; font-weight:500; margin-top:20px;">Nhập tên: </span>
                <asp:TextBox ID="txtName" runat="server" CssClass="txtTen"></asp:TextBox>
                <br />
                <span style="margin-left:20px; font-size:1.5rem; font-weight:500;">Mật Khẩu: </span>
                <asp:TextBox ID="txtPassWord" runat="server" CssClass="txtMatKhau" TextMode="Password"></asp:TextBox>
                <br />
                <span style="margin-left:20px; font-size:1.5rem; font-weight:500;">Nhập lại mật khẩu: </span>
                <asp:TextBox ID="txtRetypePassWord" runat="server" CssClass="txtNhapLaiMK" TextMode="Password"></asp:TextBox>
                <asp:Label ID="lblError" runat="server" CssClass="BaoLoi"></asp:Label>
            </div>
            <div class="form__footer">
                <asp:Button ID="Button" runat="server" OnClick="Button_Click" Text="Đăng Ký" CssClass="btnBam" />
            </div>
           
        </div>
    </main>
</asp:Content>
