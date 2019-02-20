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


    $(document).off("click", ".RoleMasterView");
    $(document).on("click", ".RoleMasterView", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Role Master Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            success: function (data, status, xhr) {
                $('.RoleMasterSearchDetials').hide();
                $('.RoleMasterAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".RoleMasterEdit, .RoleMasterAdd");
    $(document).on("click", ".RoleMasterEdit, .RoleMasterAdd", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Role Master Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.RoleMasterSearchDetials').hide();
                $('.RoleMasterAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".RoleMasterDelete");
    $(document).on("click", ".RoleMasterDelete", function (event) {
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

    $(document).off("click", ".RoleMasterAddEdit");
    $(document).on("click", ".RoleMasterAddEdit", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Role Master Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".RoleMasterDetails").find("input").serialize(),
            success: function (data, status, xhr) {
                $('.RoleMasterSearchDetials').show();
                $('.RoleMasterAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".RoleMasterSearch");
    $(document).on("click", ".RoleMasterSearch", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Role Master Info');
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



