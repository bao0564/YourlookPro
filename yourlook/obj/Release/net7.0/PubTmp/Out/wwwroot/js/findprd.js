$(document).ready(function () {
    $('#searchButton').click(function () {
        var keyw = $('#searchKeyword').val();
        window.location.href = '/Home/KeyWord' + '?keyword=' + encodeURIComponent(keyw);
    });
});