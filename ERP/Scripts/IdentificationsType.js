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
        else if (status == "ModelError") {
            $.growl.error({ message: message });
        }
    };

    $(document).off("click", ".IdentificationsTypeCancel");
    $(document).on("click", ".IdentificationsTypeCancel", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Identifications Type Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.IdentificationsTypeSearchDetials').show();
                $('.IdentificationsTypeAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".IdentificationsTypeView");
    $(document).on("click", ".IdentificationsTypeView", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Identifications Type Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            success: function (data, status, xhr) {
                $('.IdentificationsTypeSearchDetials').hide();
                $('.IdentificationsTypeAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".IdentificationsTypeEdit, .IdentificationsTypeAdd");
    $(document).on("click", ".IdentificationsTypeEdit, .IdentificationsTypeAdd", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Identifications Type Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.IdentificationsTypeSearchDetials').hide();
                $('.IdentificationsTypeAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".IdentificationsTypeDelete");
    $(document).on("click", ".IdentificationsTypeDelete", function (event) {
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

    $(document).off("click", ".IdentificationsTypeAddEdit");
    $(document).on("click", ".IdentificationsTypeAddEdit", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Identifications Type Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".IdentificationsTypeDetails").find("input").serialize(),
            success: function (data, status, xhr) {
                $('.IdentificationsTypeSearchDetials').show();
                $('.IdentificationsTypeAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                if (errorMessage == "Model Validation Failed") {
                    var errorString = "";
                    $.each(jqXhr.responseJSON.Error, function (index, value) {
                        errorString = errorString + value + '</br>';
                    });
                    showMessage("ModelError", errorString);
                } else {
                    showMessage(textStatus, errorMessage);
                }
            }
        });
    });

    $(document).off("click", ".IdentificationsTypeSearch");
    $(document).on("click", ".IdentificationsTypeSearch", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Identifications Type Info');
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



