function Jform(f) {
    $(f).submit(function (e) {
        e.preventDefault();
        var formAction = $(this).attr("action");
        var formData = new FormData($(f)[0]);

        var btnSubmit = $(this).find("button[type='submit']");
        btnSubmit.attr("disabled", true);
        
        $.ajax({
            type: 'post',
            url: formAction,
            data: formData,
            processData: false,
            contentType: false
        }).done(function (result) {
          btnSubmit.removeAttr("disabled", false);
            if (result.message === "success") {
                Swal.fire({
                    title: result.message,
                    icon: 'success',
                    timer: 1000
                });

                if (result.redirectUrl != null) {
                    setTimeout(function () {
                        window.location.href = result.redirectUrl;
                    }, 1000);
                }
                else {
                    $(f)[0].reset();
                }


            } else {
                Swal.fire({
                    title: result.message,
                    icon: 'error',
                });
            }
        });
    });
}