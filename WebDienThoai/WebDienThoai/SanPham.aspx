<%@ Page Title="" Language="C#" MasterPageFile="~/_layout.Master" AutoEventWireup="true" CodeBehind="SanPham.aspx.cs" Inherits="WebGiaoHang.SanPham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/css/SanPham.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="main">
        <div class="main__group1" id="main__group1" runat="server">
                     
        </div>      
    </main>
    <main class="details"> 
        <div class="details__content">
            <div class="details__content--img"></div>
            <div class="details__content--info">
                <div class="details__content--item1">
                    <h3 class="details__content--info--title"></h3>
                    <div class="details__money">
                        <p class="details__money--first"></p>
                        <p class="details__money--second"></p>
                    </div>
                    <p style="color: var(--primary-color); font-size: 1.3rem;"> Mô tả:</p>
                    <div class="details__note">
                    </div>
                    <div class="details__icon">
                        <div class="details__icon--first">
                            <i class="fa-solid fa-truck-fast details__icon--size"></i>
                            <span class="details__icon--text">Miễn phí giao hàng cho đơn hàng từ 2.000.000đ</span>
                        </div>
                        <div class="details__icon--second">
                            <i class="fa-solid fa-people-carry-box details__icon--size"></i>
                            <span class="details__icon--text">Miễn phí đổi hàng nếu giao hàng lỗi</span>
                        </div>
                    </div>
                </div>
                <div class="details__content--item2">
                    <button class="details__btn--first">Mua hàng</button>
                    <button class="details__btn--second" onclick="comeback()">Trở lại</button>
                </div>
            </div>
        </div>
    </main>

    <div class="SearchProduct">
    </div>
</asp:Content>
