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

    $(document).off("click", ".UOMMasterCancel");
    $(document).on("click", ".UOMMasterCancel", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View UOM Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.UOMMasterSearchDetials').show();
                $('.UOMMasterAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });


    $(document).off("click", ".UOMMasterView");
    $(document).on("click", ".UOMMasterView", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View UOM Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            success: function (data, status, xhr) {
                $('.UOMMasterSearchDetials').hide();
                $('.UOMMasterAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".UOMMasterEdit, .UOMMasterAdd");
    $(document).on("click", ".UOMMasterEdit, .UOMMasterAdd", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage UOM Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.UOMMasterSearchDetials').hide();
                $('.UOMMasterAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".UOMMasterDelete");
    $(document).on("click", ".UOMMasterDelete", function (event) {
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

    $(document).off("click", ".UOMMasterAddEdit");
    $(document).on("click", ".UOMMasterAddEdit", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View UOM Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".UOMMasterDetails").find("input").serialize(),
            success: function (data, status, xhr) {
                $('.UOMMasterSearchDetials').show();
                $('.UOMMasterAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".UOMMasterSearch");
    $(document).on("click", ".UOMMasterSearch", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View UOM Info');
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



