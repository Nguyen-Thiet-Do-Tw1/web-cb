<%@ Page Title="" Language="C#" MasterPageFile="~/_layout.Master" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="WebGiaoHang.DangNhap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/css/DangNhap.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>
        <div class="form__dangnhap">
            <div class="form__title">
                <a href="DangNhap.aspx" class="form__title--first">
                    <span class="form__title--text">ĐĂNG  NHẬP</span>
                </a>
                <a href="DangKy.aspx" class="form__title--second">
                    <span class="form__title--text"> ĐĂNG  KÝ </span>
                </a>
            </div>
            <div class="form__content">
                <p style="font-size: 1.3rem; margin-left: 20px;">Cảm ơn bạn đã trở lại !</p>
                <span style="margin-left:20px; font-size:1.5rem; font-weight:500; margin-top:10px">UserName: </span>
                <asp:TextBox ID="TxtName" runat="server" CssClass="form__content--username"></asp:TextBox>
                <br />
                <span style="margin-left:20px; font-size:1.5rem; font-weight:500;">PassWord: </span>
                <asp:TextBox ID="txtPassWord" runat="server" CssClass="form__content--password" TextMode="Password"></asp:TextBox>
                <br />
                <asp:Label ID="lblError" runat="server" CssClass="BaoLoi"></asp:Label>
                <br />
            </div>
            <div class="form__footer">
                <asp:Button ID="Button1" runat="server" OnClick="Button_Click" Text="Login" CssClass="form__footer--btn" />
            </div>
        </div>
    </main>
</asp:Content>
