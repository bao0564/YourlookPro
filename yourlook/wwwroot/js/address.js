
//chọn địa chỉ +Hinhf thuwcs Thanh toans
$(document).on('change', '.address-val', function () {
    $('.address-val').not(this).prop('checked', false);
    // Kiểm tra
    if (this.checked) {
        // Lấy dữ liệu
        var name = $(this).data('name');
        var phone = $(this).data('phone');
        var city = $(this).data('city');
        var district = $(this).data('district');
        var ward = $(this).data('ward');
        var address = $(this).data('address');

        // Gán dữ liệu 
        $('#TenKh').val(name);
        $('#Sdt').val(phone);
        $('#City').val(city);
        $('#District').val(district);
        $('#Ward').val(ward);
        $('#DiaChi').val(address);
    }
});
$(document).on('change', '.pay-checked', function () {
    $('.pay-checked').not(this).prop('checked', false);
    if (this.checked) {
        var icon = $(this).data('payicon');
        var name = $(this).data('payname');
        var id = $(this).data('payid');

        $('#payicon').attr('src', icon);
        $('#payid').text(id);
        $('#payname').text(name);
    }
});