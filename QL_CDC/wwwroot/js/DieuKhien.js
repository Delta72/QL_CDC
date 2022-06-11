

// Cap nhat san pham trong gio hang
function hiensanphamtronggio() {
    $.ajax({
        url: '/GioHang/HienSanPhamTrongGio',
        type: 'get',
        success: function (data) {
            document.getElementById("sanphamtronggio").innerText = data;
        }
    })
}

// format gia tien


// Ready
$(document).ready(function () {
    hiensanphamtronggio();
})

