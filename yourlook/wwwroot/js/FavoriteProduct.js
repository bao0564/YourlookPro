function addToFavorites(masp){
    $.ajax({
        url: '/Home/FavoriteProduct/',
        type: 'POST',
        data: { masp: masp },
        success: function (Response) {
            if (Response.success) {
                alert('Sản Phẩm thêm vào yêu thích thành công');
            }
            else {
                alert('Bạn chưa đăng nhập nên không thể thực hiện thao tác này');
            }
        },
        error: function () {
            alert('Có lỗi xảy ra khi thêm sản phẩm vào yêu thích.');
        }
    });
}