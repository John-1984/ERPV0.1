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

    $(document).off("click", ".BrandCancel");
    $(document).on("click", ".BrandCancel", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Brand Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.BrandSearchDetials').show();
                $('.BrandAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).on('change', '#drpBrandVendor', function () {
        //alert("Test");
        // debugger;
        varvendorText = $("#drpBrandVendor").val();
        $("#hdnVendor").val(varvendorText);
    });

    $(document).off("click", ".BrandView");
    $(document).on("click", ".BrandView", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Brand Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            success: function (data, status, xhr) {
                $('.BrandSearchDetials').hide();
                $('.BrandAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".BrandEdit, .BrandAdd");
    $(document).on("click", ".BrandEdit, .BrandAdd", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Brand Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.BrandSearchDetials').hide();
                $('.BrandAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".BrandDelete");
    $(document).on("click", ".BrandDelete", function (event) {
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

    $(document).off("click", ".BrandAddEdit");
    $(document).on("click", ".BrandAddEdit", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Brand Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".BrandDetails").find("input").serialize(),
            success: function (data, status, xhr) {
                $('.BrandSearchDetials').show();
                $('.BrandAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".BrandSearch");
    $(document).on("click", ".BrandSearch", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Brand Info');
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



