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

    $(document).on('change', '#drpRegion', function () {
        //alert("Test");
        // debugger;
        varregionText = $("#drpRegion").val();
        $("#hdnRegion").val(varregionText);
        var drpCountry = $("#drpCountry");
      //  alert("Test");
        $.ajax({            
            type: 'POST',
            url: '/State/Country',
            data: JSON.stringify({ identity: $("#drpRegion").val()}),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpCountry.empty().append('<option selected="selected" value="0">Select Country</option>');
                $.each(response, function () {
                    drpCountry.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpCountry', function () {
        //alert("Test");
        // debugger;
        varregionText = $("#drpCountry").val();
        $("#hdnCountry").val(varregionText);
    });

    $(document).off("click", ".StateCancel");
    $(document).on("click", ".StateCancel", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View State Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.StateSearchDetials').show();
                $('.StateAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".StateView");
    $(document).on("click", ".StateView", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View State Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            success: function (data, status, xhr) {
                $('.StateSearchDetials').hide();
                $('.StateAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".StateEdit, .StateAdd");
    $(document).on("click", ".StateEdit, .StateAdd", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage State Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.StateSearchDetials').hide();
                $('.StateAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".StateDelete");
    $(document).on("click", ".StateDelete", function (event) {
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

    $(document).off("click", ".StateAddEdit");
    $(document).on("click", ".StateAddEdit", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View State Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".StateDetails").find("input").serialize(),
            success: function (data, status, xhr) {
                $('.StateSearchDetials').show();
                $('.StateAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".StateSearch");
    $(document).on("click", ".StateSearch", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View State Info');
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



