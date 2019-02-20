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


    $(document).off("click", ".DiscountView");
    $(document).on("click", ".DiscountView", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Discount Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            success: function (data, status, xhr) {
                $('.DiscountSearchDetials').hide();
                $('.DiscountAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".DiscountEdit, .DiscountAdd");
    $(document).on("click", ".DiscountEdit, .DiscountAdd", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Discount Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.DiscountSearchDetials').hide();
                $('.DiscountAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".DiscountDelete");
    $(document).on("click", ".DiscountDelete", function (event) {
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

    $(document).off("click", ".DiscountAddEdit");
    $(document).on("click", ".DiscountAddEdit", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Discount Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".DiscountDetails").find("input").serialize(),
            success: function (data, status, xhr) {
                $('.DiscountSearchDetials').show();
                $('.DiscountAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".DiscountSearch");
    $(document).on("click", ".DiscountSearch", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Discount Info');
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



