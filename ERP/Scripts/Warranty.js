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


    $(document).off("click", ".WarrantyView");
    $(document).on("click", ".WarrantyView", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Warranty Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            success: function (data, status, xhr) {
                $('.WarrantySearchDetials').hide();
                $('.WarrantyAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".WarrantyEdit, .WarrantyAdd");
    $(document).on("click", ".WarrantyEdit, .WarrantyAdd", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Warranty Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.WarrantySearchDetials').hide();
                $('.WarrantyAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".WarrantyDelete");
    $(document).on("click", ".WarrantyDelete", function (event) {
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

    $(document).off("click", ".WarrantyAddEdit");
    $(document).on("click", ".WarrantyAddEdit", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Warranty Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".WarrantyDetails").find("input").serialize(),
            success: function (data, status, xhr) {
                $('.WarrantySearchDetials').show();
                $('.WarrantyAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".WarrantySearch");
    $(document).on("click", ".WarrantySearch", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Warranty Info');
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



