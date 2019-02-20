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


    $(document).off("click", ".LocalSupplierView");
    $(document).on("click", ".LocalSupplierView", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Local Supplier Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            success: function (data, status, xhr) {
                $('.LocalSupplierSearchDetials').hide();
                $('.LocalSupplierAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".LocalSupplierEdit, .LocalSupplierAdd");
    $(document).on("click", ".LocalSupplierEdit, .LocalSupplierAdd", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Local Supplier Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.LocalSupplierSearchDetials').hide();
                $('.LocalSupplierAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".LocalSupplierDelete");
    $(document).on("click", ".LocalSupplierDelete", function (event) {
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

    $(document).off("click", ".LocalSupplierAddEdit");
    $(document).on("click", ".LocalSupplierAddEdit", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Local Supplier Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".LocalSupplierDetails").find("input").serialize(),
            success: function (data, status, xhr) {
                $('.LocalSupplierSearchDetials').show();
                $('.LocalSupplierAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".LocalSupplierSearch");
    $(document).on("click", ".LocalSupplierSearch", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Local Supplier Info');
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



