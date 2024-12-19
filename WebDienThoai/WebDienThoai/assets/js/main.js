/* nav Menu */
var btn__header = document.querySelector('.header__content-nav--item0');
var btn__header__item1 = document.querySelector('.header__content-nav');
var check = btn__header__item1.clientHeight;

btn__header.onclick = function () {
    var isClose = btn__header__item1.clientHeight <= check;
    if (isClose) {
        btn__header__item1.style.height = 'auto';
    } else {
        btn__header__item1.style.height = null;
    }
}

// Khởi tạo mảng để lưu dữ liệu từ JSON
var jsonProducts = [];

// Đọc và parse file JSON
fetch('product.json')
    .then(response => response.json())
    .then(json => {
        // Gán dữ liệu từ JSON vào biến jsonProducts
        jsonProducts = json;
    })
    .catch(error => console.error('Lỗi khi đọc file JSON:', error));

/* Chi tiết sản phẩm */
function convert(temp) {
    var cache = temp;
    temp = "url" + '("' + temp + '")';
    var img = document.querySelector('.details__content--img');
    var title = document.querySelector('.details__content--info--title');
    var money1 = document.querySelector('.details__money--first');
    var money2 = document.querySelector('.details__money--second');
    var content = document.querySelector('.details__note');
    var item1 = document.querySelector('.main');
    var item2 = document.querySelector('.details');

    jsonProducts.forEach(function (e) {
        if (temp === 'url("' + e.image + '")') {
            item1.style.display = 'none';
            item2.style.display = 'flex';
            img.style.backgroundImage = 'url("' + e.image + '")';
            title.innerHTML = e.ten;
            money1.innerHTML = e.tien + "đ";
            money2.innerHTML = e.giamgia + "đ";
            content.innerHTML = e.information;
        }
    });
}

function comeback() {
    var item1 = document.querySelector('.main');
    var item2 = document.querySelector('.details');
    item1.style.display = 'block';
    item2.style.display = 'none';
}

/* Thanh tìm kiếm */
var enter__search = document.querySelector('.header__content-search--input');
enter__search.oninput = function (e) {
    SearchProduct();
};

function SearchProduct() {
    var item1 = document.querySelector('.main');
    var item2 = document.querySelector('.details');
    var item3 = document.querySelector('.SearchProduct');
    var item4 = document.getElementById('haeder__search-input');
    var item5 = document.querySelector('.main__group1--product-item.item6');

    item1.style.display = 'none';
    item2.style.display = 'none';
    item3.style.display = 'flex';

    var child = item3.firstElementChild;
    var check = 1;

    for (; child;) {
        item3.removeChild(child);
        child = item3.firstElementChild;
    }

    jsonProducts.forEach(function (e) {
        if (e.ten.toUpperCase().includes(item4.value.toUpperCase()) && item4.value != "") {

            var img = document.createElement('div');
            var content = document.createElement('div');
            var title = document.createElement('div');
            var money = document.createElement('div');
            var money1 = document.createElement('div');
            var money2 = document.createElement('div');

            img.className = 'showproduct__img';
            content.className = 'showproduct__content';
            title.className = 'showproduct__title';
            money.className = 'showproduct__money';
            money1.className = 'showproduct__money--first';
            money2.className = 'showproduct__money--second';

            img.style.backgroundImage = 'url("' + e.image + '")';
            title.innerHTML = e.ten;
            money1.innerHTML = e.tien + "đ";
            money2.innerHTML = e.giamgia + "đ";

            money.appendChild(money1);
            money.appendChild(money2);

            content.appendChild(title);
            content.appendChild(money);

            var temp = document.createElement('div');
            temp.className = 'showproduct';
            temp.appendChild(img);
            temp.appendChild(content);

            temp.onclick = function () {
                var img1 = document.querySelector('.details__content--img');
                var title1 = document.querySelector('.details__content--info--title');
                var money11 = document.querySelector('.details__money--first');
                var money12 = document.querySelector('.details__money--second');
                var content = document.querySelector('.details__note');
                var item11 = document.querySelector('.main');
                var item12 = document.querySelector('.details');
                var item13 = document.querySelector('.SearchProduct');

                jsonProducts.forEach(function (k) {
                    if ('url("' + e.image + '")' === 'url("' + k.image + '")') {
                        item11.style.display = 'none';
                        item13.style.display = 'none';
                        item12.style.display = 'flex';
                        img1.style.backgroundImage = 'url("' + k.image + '")';
                        title1.innerHTML = k.ten;
                        money11.innerHTML = k.tien + "đ";
                        money12.innerHTML = k.giamgia + "đ";
                        content.innerHTML = k.information;
                    }
                });
            };
            item3.appendChild(temp);
            check = 0;
        }
    });

    if (check) {
        var error = document.createElement('div');
        var txtconten = document.createElement('span');
        error.className = 'Error';
        error.appendChild(txtconten);
        item3.appendChild(error);
        txtconten.innerText = 'Không tìm thấy sản phẩm!!!';
        console.log(error);
    }
}

