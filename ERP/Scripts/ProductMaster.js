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

    $(document).off("click", ".ProductMasterCancel");
    $(document).on("click", ".ProductMasterCancel", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Product Master Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.ProductMasterSearchDetials').show();
                $('.ProductMasterAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".ProductMasterView");
    $(document).on("click", ".ProductMasterView", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Product Category Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            success: function (data, status, xhr) {
                $('.ProductMasterSearchDetials').hide();
                $('.ProductMasterAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".ProductMasterEdit, .ProductMasterAdd");
    $(document).on("click", ".ProductMasterEdit, .ProductMasterAdd", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Product Category Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.ProductMasterSearchDetials').hide();
                $('.ProductMasterAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".ProductMasterDelete");
    $(document).on("click", ".ProductMasterDelete", function (event) {
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

    $(document).off("click", ".ProductMasterAddEdit");
    $(document).on("click", ".ProductMasterAddEdit", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Product Category Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".ProductMasterDetails").find("input").serialize(),
            success: function (data, status, xhr) {
                $('.ProductMasterSearchDetials').show();
                $('.ProductMasterAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".ProductMasterSearch");
    $(document).on("click", ".ProductMasterSearch", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Product Category Info');
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



