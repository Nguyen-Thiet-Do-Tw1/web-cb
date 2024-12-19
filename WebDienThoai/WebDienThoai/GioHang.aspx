<%@ Page Title="" Language="C#" MasterPageFile="~/_layout.Master" AutoEventWireup="true" CodeBehind="GioHang.aspx.cs" Inherits="WebGiaoHang.GioHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/css/GioHang.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main class="main">
        <br />
        <br />
        <br />
        <span style="margin-left: 40px; font-weight: 500;">Số lượng sản phẩm có trong giỏ hàng: </span>
        <asp:Label runat="server" ID="SoluongSP" CssClass=""></asp:Label>
        <hr />
        <br />
        <br />

        <asp:DataList runat="server" ID="d2" Width="100%">
            <HeaderTemplate >
            <table style="border:0; padding:0;" class="ktb">
                <td class="ktb" style="width:20px; font-size:1.3rem; height:20px; text-align:center; font-weight: 600;">ID</td>
                <td class="ktb" style="width:200px; font-size:1.3rem; height:20px; text-align:center; font-weight: 600;">Tên sản phẩm</td>
                <td class="ktb" style="width:150px; font-size:1.3rem; height:20px; text-align:center; font-weight: 600;">Ảnh</td>
                <td class="ktb" style="width:50px; font-size:1.3rem; height:20px;  text-align:center; font-weight: 600;">Số lượng</td>
                <td class="ktb" style="width:50px; font-size:1.3rem; height:20px;  text-align:center; font-weight: 600;">Giá tiền</td>
                <td class="ktb" style="width:50px; font-size:1.3rem; height:20px;  text-align:center; font-weight: 600;">Thành tiền</td>
                <td class="ktb" style="width:50px; font-size:1.3rem; height:20px;  text-align:center; font-weight: 600;"></td>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="ktb">
                <td class="ktb" style="text-align:center;"><%#Eval("productID")%>
                    <asp:Label runat="server" ID="lblProductID" Visible="false" Text='<%#Eval("productID")%>'> </asp:Label>
                </td>
                <td class="ktb" style="text-align:center;"><%#Eval("name") %></td>
                <td class="ktb" style="text-align:center;"> 
                <img src="<%# Eval("img") %>" width="100" height="100"/></td>
                <td class="ktb" style="text-align:center;"><%#Eval("soluong") %></td>
                <td class="ktb" style="text-align:center;"><%#Eval("giatien") %></td>
                <td class="ktb" style="text-align:center;"><%#Eval("thanhtien") %></td>
                <td class="ktb" style="text-align:center;">
                    <asp:LinkButton runat="server" CssClass="xoaSP" Text="Xóa" OnClick="delete"/>
                </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
            </table>
            </FooterTemplate>

        </asp:DataList>
        <br />
        <br />
        <span style="margin-left: 40px; font-weight: 500;">Tổng tiền: </span>
        <asp:Label runat="server" ID="lblTongTien"></asp:Label>
        <br />
        <br />
        <asp:Button runat="server" ID="btnMuaHang" CssClass="buttonMuaHang" Text="Mua hàng" OnClick="Muahang"/>
        <br />
        <br />
        <asp:Label runat="server" ID="lblMuaHangLoi" CssClass="lblthongbaoloi"></asp:Label>
        <br />
        <hr />
        <h2 style="text-align: center;">Thay đổi số lượng của mặt hàng</h2>
        <span style="margin-left: 40px; font-weight: 500;">Nhập id sản phẩm muốn thay đổi số lượng:</span>
        <asp:TextBox runat="server" ID="IDThaydoi"></asp:TextBox>
        <br />
        <br />
        <span style="margin-left: 115px;font-weight: 500;">Nhập số lượng muốn thay đổi:</span>
        <asp:TextBox runat="server" ID="SLThaydoi"></asp:TextBox>
        <br />
        <br />
        <asp:Label runat="server" ID="lblLoiUpdate" CssClass="lblthongbaoloi"></asp:Label>
        <br />
        <asp:Button runat="server" Text="Thay đổi" CssClass="buttonThayDoi" OnClick="Update"/> 
        <br />
        <br />
    </main>    
</asp:Content>
