<%@ Page Title="" Language="C#" MasterPageFile="~/_layout.Master" AutoEventWireup="true" CodeBehind="TrangChu.aspx.cs" Inherits="WebGiaoHang.TrangChu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/css/TrangChu.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="main">
    <div class="main__img">
        <img src="assets/img/benner.png" alt="" class="main__img--item">
    </div>
    <div class="main__group">
        <div class="main__group1--title">
            <h3 class="main__group1--title-text">SẢN PHẨM NỔI BẬT</h3>
            <div class="main__group1--title-boder">
                <div class="group1__border"></div>
                <div class="group1__border"></div>
            </div>
        </div>
        <div class="main__group1--product" id="noibat" runat="server">

        </div>     
        
    </div>
        <div class="main__group1--img">
            <img class="main__group1--img-1" src="assets/img/bener1.png" alt="">
        </div>
    <div class="main__group">
        <div class="main__group1--title">
            <h3 class="main__group1--title-text">Sản Phẩm MỚI</h3>
            <div class="main__group1--title-boder">
                <div class="group1__border"></div>
                <div class="group1__border"></div>
            </div>
        </div>
        <div class="main__group1--product" id="moi" runat="server">
        </div> 
        
    </div>
        <div class="main__group1--img">
            <img class="main__group1--img-1" src="assets/img/benner2.png" alt="">
        </div>
    <div class="main__group">
        <div class="main__group1--title">
            <h3 class="main__group1--title-text">SẢN PHẨM BÁN CHẠY</h3>
            <div class="main__group1--title-boder">
                <div class="group1__border"></div>
                <div class="group1__border"></div>
            </div>
        </div>
        <div class="main__group1--product" id="banchay" runat="server">
            
        </div>
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
                <asp:Button runat="server" Text="Mua hàng" CssClass="details__btn--first"/>
                <button class="details__btn--second" onclick="comeback()">Trở lại</button>
            </div>
        </div>
    </div>
</main>
    
    <div class="SearchProduct">
    </div>
</asp:Content>
