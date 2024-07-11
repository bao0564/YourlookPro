$(document).ready(function () {
    
    // Thêm vào giỏ hàng
    $('body').on('click', '.btnAddToCart', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var quantity = 1;
        var tQuantity = $('#quantity_value').text();
        if (tQuantity != '') {
            quantity = parseInt(tQuantity);
        }
        $.ajax({
            url: '/shoppingcart/addtocart',
            type: 'POST',
            data: { masp: id, quantity: quantity },
            success: function (rs) {
                if (rs.success) {
                    alert(rs.msg);
                } else {
                    alert("Thêm sản phẩm không thành công");
                }
            }
        });
    });

    // Đưa sản phẩm được chọn,thông tin khách hàng vào trang thanh toán
    $('.pay-btn').off('click').on('click', function (e) {
        e.preventDefault();
        var selectedProducts = [];
        $('.cart-checkbox:checked').each(function () {
            var id = $(this).data('id');
            var quantityElement = $(this).closest('.cart-container').find('.quantity_value-cart');
            var quantity = parseInt(quantityElement.text());
            selectedProducts.push({ ProductId: id, ProductQuantity: quantity });
        });

        var orderInfo = {
            TenKh: $('#TenKh').val(),
            Sdt: $('#Sdt').val(),
            City: $('#City').val(),
            District: $('#District').val(),
            Ward: $('#Ward').val(),
            DiaChi: $('#DiaChi').val(),
            GhiChu: $('#GhiChu').val()
        };

        if (selectedProducts.length > 0) {
            var data = {
                selectedProducts: selectedProducts,
                selectInfors: orderInfo
            };
            $.ajax({
                url: '/shoppingcart/checkout',
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(data),
                success: function (response) {
                    window.location.href = '/shoppingcart/order';
                }
            });
        } else {
            alert("Vui lòng chọn ít nhất một sản phẩm để thanh toán.");
        }
    });
    // Xóa sản phẩm
    $('body').off('click', '.deletebtn').on('click', '.deletebtn', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var msg = confirm('Bạn có muốn xóa sản phẩm này ra khỏi giỏ hàng ?');
        if (msg == true) {
            $.ajax({
                url: '/ShoppingCart/Delete',
                type: 'POST',
                data: { id: id },
                success: function (rs) {
                    if (rs.success) {
                        $('#sp-' + id).remove();
                        calculateTotal();
                    }
                }
            });
        }
    });

    // Tính tổng tiền
    function calculateTotal() {
        var total = 0;
        $('.cart-checkbox:checked').each(function () {
            var price = parseFloat($(this).data('price'));
            var quantity = parseInt($(this).closest('.cart-container').find('.quantity_value-cart').text());
            total += price * quantity;
        });
        $('#TongTien').text(total.toLocaleString() + ' VNĐ');
    }

    // Cập nhật giá tiền
    function updatePrice(element, quantity) {
        var priceElement = element.closest('.flex-cart').find('.product_price');
        var unitPrice = parseFloat(priceElement.data('price'));
        var newPrice = unitPrice * quantity;
        priceElement.text(newPrice.toLocaleString() + ' VNĐ');
    }

     //Hàm cập nhật số lượng sản phẩm trong giỏ hàng
    function Update(id, quantity) {
        $.ajax({
            url: '/ShoppingCart/Update',
            type: 'POST',
            data: { id: id, quantity: quantity },
            success: function (rs) {
                if (!rs.success) {
                    alert("Cập nhật số lượng không thành công");
                }
            }
        });
    }

    // Sự kiện thay đổi checkbox
    $(document).off('change', '.cart-checkbox').on('change', '.cart-checkbox', function () {
        calculateTotal();
    });

    // Sự kiện tăng số lượng
    $(document).off('click', '.plus-cart').on('click', '.plus-cart', function () {
        var quantityElement = $(this).siblings('.quantity_value-cart');
        var newQuantity = parseInt(quantityElement.text()) + 1;
        var id = $(this).closest('.cart-container').find('.cart-checkbox').data('id');
        quantityElement.text(newQuantity);
        updatePrice($(this), newQuantity);
        calculateTotal();
        Update(id, newQuantity); // Cập nhật số lượng trong giỏ hàng
    });

    // Sự kiện giảm số lượng
    $(document).off('click', '.minus-cart').on('click', '.minus-cart', function () {
        var quantityElement = $(this).siblings('.quantity_value-cart');
        var newQuantity = parseInt(quantityElement.text()) - 1;
        if (newQuantity > 0) {
            var id = $(this).closest('.cart-container').find('.cart-checkbox').data('id');
            quantityElement.text(newQuantity);
            updatePrice($(this), newQuantity);
            calculateTotal();
            Update(id, newQuantity); // Cập nhật số lượng trong giỏ hàng
        }
    });

    // Tính tổng tiền ban đầu khi tải trang
    calculateTotal();
});

    //đặt hàng thành công
    //$('.checkout-btn').off('click').on('click', function (e) {
    //    e.preventDefault();
    //    $.ajax({
    //        url: '/shoppingcart/payorder',
    //        type: 'POST',
    //        success: function (response) {
    //            if (response.success) {
    //                window.location.href = '/shoppingcart/payordersuccess';
    //            } else {
    //                alert('Có lỗi xảy ra khi xử lý đơn hàng của bạn. Vui lòng thử lại.');
    //            }
    //        }
    //    });
//});