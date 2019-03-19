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


    $(document).off("click", ".CountryView");
    $(document).on("click", ".CountryView", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Country Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            success: function (data, status, xhr) {
                $('.CountrySearchDetials').hide();
                $('.CountryAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".CountryEdit, .CountryAdd");
    $(document).on("click", ".CountryEdit, .CountryAdd", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Country Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.CountrySearchDetials').hide();
                $('.CountryAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".CountryCancel");
    $(document).on("click", ".CountryCancel", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Country Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.CountrySearchDetials').show();
                $('.CountryAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".CountryDelete");
    $(document).on("click", ".CountryDelete", function (event) {
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

    $(document).on('change', '#drpRegion', function () {  
        
       // debugger;
        varregionText = $("#drpRegion").val();
        $("#hdnRegion").val(varregionText);
    });

    $(document).off("click", ".CountryAddEdit");
    $(document).on("click", ".CountryAddEdit", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Country Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".CountryDetails").find("input").serialize(),
            success: function (data, status, xhr) {
                $('.CountrySearchDetials').show();
                $('.CountryAdd').show();
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

    $(document).off("click", ".CountrySearch");
    $(document).on("click", ".CountrySearch", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Country Info');
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



