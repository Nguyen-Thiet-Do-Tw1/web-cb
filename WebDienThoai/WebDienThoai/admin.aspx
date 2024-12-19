<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="WebDienThoai.WebForm1" %>

<!DOCTYPE html>
<link href="assets/css/admin.css" rel="stylesheet" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin</title>
    <style type="text/css">
        .auto-style1 {
            width: 201px;
        }
        .auto-style2 {
            width: 201px;
            height: 42px;
        }
        .auto-style3 {
            height: 42px;
            width: 903px;
        }
        .auto-style4 {
            width: 903px;
        }
    </style>
</head>
<body>
    <form id="admin" runat="server">
        <div>
            <table>
                <tr>
                    <td class="auto-style1">ID:</td>
                    <td class="auto-style4"><asp:TextBox ID="TextBoxID" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style1">Tên:</td>
                    <td class="auto-style4"><asp:TextBox ID="TextBoxTen" runat="server" Width="372px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style1">Thương Hiệu:</td>
                    <td class="auto-style4"><asp:TextBox ID="TextBoxTH" runat="server" Width="372px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style1">ảnh:</td>
                    <td class="auto-style4"><asp:FileUpload ID="FileUploadImage" runat="server" /></td>
                </tr>
                <tr>
                    <td class="auto-style1">Số lượng:</td>
                    <td class="auto-style4"><asp:TextBox ID="TextBoxSoluong" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style1">Giảm giá:</td>
                    <td class="auto-style4"><asp:TextBox ID="TextBoxGiamgia" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style2">Tiền:</td>
                    <td class="auto-style3"><asp:TextBox ID="TextBoxTien" runat="server"></asp:TextBox></td>
                </tr>
                
                <tr>
                    <td class="auto-style1">Thông tin:</td>
                    <td class="auto-style4"><asp:TextBox ID="TextBoxInformation" runat="server" Width="830px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style1">
                       <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"><asp:Button ID="AddButton" runat="server" Text="Thêm" OnClick="AddButton_Click" /></td>
                    <td class="auto-style4"><asp:Button ID="DeleteButton" runat="server" Text="Xóa" OnClick="DeleteButton_Click" /></td>
                    
                </tr>
            </table>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" >
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="ID" />
                    <asp:BoundField DataField="ten" HeaderText="Tên" />
                    <asp:BoundField DataField="TH" HeaderText="Thương Hiệu" />
                    <asp:BoundField DataField="image" HeaderText="Ảnh" />
                    <asp:BoundField DataField="soluong" HeaderText="Số Lượng" />
                    <asp:BoundField DataField="giamgia" HeaderText="Giảm Giá" />
                    <asp:BoundField DataField="tien" HeaderText="Tiền" />
                    <asp:BoundField DataField="PTgiam" HeaderText="% giảm giá" />
                    <asp:BoundField DataField="information" HeaderText="Thông Tin" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
