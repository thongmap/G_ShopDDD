//Bảo
$(function () {
    $(".custom_datepicker").one("focusin", function () {
        // Về cơ bản thì khi click vào datepicker nó sẽ lấy dữ liệu mm/dd/yyyy từ value
        // trong khi datepicker lại được thể hiện dạng dd/mm/yyyy
        // vì vậy khi sự kiện focusin xãy ra phải biến đổi value dd/mm sang mm/dd
        var currentDate = $(this).val();
        var d = new Date(currentDate);
        var date = d.getDate(); // getDate trả về Month
        var month = d.getMonth() + 1;
        var year = d.getFullYear();        
        $(this).val(date + "/" + month + "/" + year);        
        $(this).datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "1950:2030"
        });
        $(".custom_datepicker").datepicker("option", "dateFormat", "dd/mm/yy");
        $(".custom_datepicker").datepicker("option", "showAnim", "slideDown");
    })
});
$(document).ready(function () {
    $('.gioHang').tooltip();
});
