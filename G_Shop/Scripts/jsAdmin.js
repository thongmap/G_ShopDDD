var maloai = $("#getMaLoai").val(); 
$("MaLoai").val(maloai);
        
autoProcessQueue: false;
Dropzone.autoDiscover = false;
$("#dZUpload").dropzone({ //Đăng hình ảnh
    maxFilesize: 2,
    maxFiles: 4,
    acceptedFiles: "image/*",
    maxfilesexceeded: function (file) {
        this.removeFile(file);
        alert("Giới hạn số lượng hình ảnh là 4!");
    },
    url: "/AdminHome/SaveUploadedFile",
    addRemoveLinks: true,
    success: function (file, response) {
        var imgName = response;
        file.previewElement.classList.add("dz-success");
        console.log("Successfully uploaded :" + imgName);
    },
    error: function (file, response) {
        file.previewElement.classList.add("dz-error");
    },
    removedfile: function (file) {
        var name = file.name;
        $.ajax({
            type: 'POST',
            url: '/AdminHome/DeleteFile',
            data: "id=" + name,
            dataType: 'html',
            success: function () {
            }
        });
        var _ref;
        return (_ref = file.previewElement) != null ? _ref.parentNode.removeChild(file.previewElement) : void 0;
    },
});

$("#btnThem").off('click').on('click', function () { //Nút thêm cá thể
    $("#form").submit();
});

$("input").on("change", function () {
    this.setAttribute(
        "data-date",
        moment(this.value, "YYYY-MM-DD")
        .format(this.getAttribute("data-date-format"))
    )
}).trigger("change")

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

    $("input[type='radio']").checkboxradio({      
    });
});

