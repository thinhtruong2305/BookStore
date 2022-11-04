function OnLoadImage(idInput, idDisplay) {
    image_input = document.querySelector(idInput);
    var upload_imaged = "";

    image_input.addEventListener("change", function () {
        const reader = new FileReader();
        reader.addEventListener("load", () => {
            upload_imaged = reader.result;
            document.querySelector(idDisplay).src = upload_imaged;
        });
        reader.readAsDataURL(this.files[0]);
    })
}

function AddCreateThingToBook(url, title) {
    $.ajax({
        type: "GET",
        url: url,
        success: (res) => {
            $("#form-modal .modal-body").html(res);
            $("#form-modal .modal-title").html(title);
            $("#form-modal").modal('show');
        }
    })
}

function ChangeStatus(url, returnUrl) {
    Swal.fire({
        title: 'Thông báo',
        text: "Bạn có chắc muốn thay đổi trạng thái",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Confirm'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "GET",
                url: url,
                success: (res) => {
                    if (res.success === true) {
                        Swal.fire(
                            'Thông báo',
                            'Bạn đã thay đổi thành công',
                            'success'
                        )
                        $.ajax({
                            url: returnUrl,
                            success: (res) => {
                                $('#body-list').empty();
                                $('#body-list').html(res);
                            }
                        })
                    }
                    else {
                        swal({
                            title: 'Thông báo',
                            text: res.message,
                            icon: 'error'
                        })
                    }
                }
            })
        }
    });
}
function OnDelete(url, returnUrl) {
    Swal.fire({
        title: 'Thông báo',
        text: "Bạn có chắc chắn xóa nó?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Confirm'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "GET",
                url: url,
                success: (res) => {
                    if (res.success === true) {
                        Swal.fire(
                            'Thành công',
                            'Bạn đã xóa thành công',
                            'success'
                        )
                        $.ajax({
                            url: returnUrl,
                            success: (res) => {
                                $('#body-list').empty();
                                $('#body-list').html(res);
                            }
                        })
                    }
                    else {
                        swal({
                            title: 'Thông báo',
                            text: res.message,
                            icon: 'error'
                        })
                    }
                }
            })
        }
    });
}