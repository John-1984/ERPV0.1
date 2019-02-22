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

    $(document).off("click", ".PurchaseRequestTypeCancel");
    $(document).on("click", ".PurchaseRequestTypeCancel", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Purchase Request Type Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.PurchaseRequestTypeSearchDetials').show();
                $('.PurchaseRequestTypeAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".PurchaseRequestTypeView");
    $(document).on("click", ".PurchaseRequestTypeView", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View PurchaseRequestType Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            success: function (data, status, xhr) {
                $('.PurchaseRequestTypeSearchDetials').hide();
                $('.PurchaseRequestTypeAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".PurchaseRequestTypeEdit, .PurchaseRequestTypeAdd");
    $(document).on("click", ".PurchaseRequestTypeEdit, .PurchaseRequestTypeAdd", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage PurchaseRequestType Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.PurchaseRequestTypeSearchDetials').hide();
                $('.PurchaseRequestTypeAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".PurchaseRequestTypeDelete");
    $(document).on("click", ".PurchaseRequestTypeDelete", function (event) {
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

    $(document).off("click", ".PurchaseRequestTypeAddEdit");
    $(document).on("click", ".PurchaseRequestTypeAddEdit", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View PurchaseRequestType Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".PurchaseRequestTypeDetails").find("input").serialize(),
            success: function (data, status, xhr) {
                $('.PurchaseRequestTypeSearchDetials').show();
                $('.PurchaseRequestTypeAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".PurchaseRequestTypeSearch");
    $(document).on("click", ".PurchaseRequestTypeSearch", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View PurchaseRequestType Info');
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



