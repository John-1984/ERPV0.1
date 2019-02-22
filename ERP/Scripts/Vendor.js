$(document).ready(function () {

    //Common Message Handling functions. Need to be separated.
    var showMessage = function (status, message) {
        if (status == "success") {
            $.growl.notice({ message: message });
        } else if (status == "fail") {
            $.growl.error({ message: message });
        } else if (status == "warning") {
            $.growl.warning({ message: message });
        } else if (status == "notice") {
            $.growl({ title: "Notice", message: message });
        }
    };

    $(document).off("click", ".VendorCancel");
    $(document).on("click", ".VendorCancel", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Vendor Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.VendorSearchDetials').show();
                $('.VendorAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).on('change', '#drpVendorProductMaster', function () {
        //alert("Test");
        // debugger;
        varprodmastText = $("#drpVendorProductMaster").val();
        $("#hdnProductMaster").val(varprodmastText);
    });

    $(document).off("click", ".VendorView");
    $(document).on("click", ".VendorView", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Vendor Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            success: function (data, status, xhr) {
                $('.VendorSearchDetials').hide();
                $('.VendorAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".VendorEdit, .VendorAdd");
    $(document).on("click", ".VendorEdit, .VendorAdd", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Vendor Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.VendorSearchDetials').hide();
                $('.VendorAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".VendorDelete");
    $(document).on("click", ".VendorDelete", function (event) {
        if (!confirm("Do you want to delete")) {
            return false;
        } else {
            var theUrl = $(this).attr("data-url");
            $.ajax({
                url: theUrl,
                type: 'POST',  // http method
                data: { "identity": $(this).attr("data-identity") },
                success: function (data, status, xhr) {
                    $('.resultView').html(data);
                    showMessage(status, "Success");
                },
                error: function (jqXhr, textStatus, errorMessage) {
                    showMessage(textStatus, errorMessage);
                }
            });
        }
    });

    $(document).off("click", ".VendorAddEdit");
    $(document).on("click", ".VendorAddEdit", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Vendor Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".VendorDetails").find("input").serialize(),
            success: function (data, status, xhr) {
                $('.VendorSearchDetials').show();
                $('.VendorAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".VendorSearch");
    $(document).on("click", ".VendorSearch", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Vendor Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: { "searchString": $(".searchText").val() },
            success: function (data, status, xhr) {
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

});



