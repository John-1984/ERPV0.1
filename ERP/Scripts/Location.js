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

    $(document).on('change', '#drpRegion', function () {
        
        // debugger;
        varregionText = $("#drpRegion").val();
        $("#hdnRegion").val(varregionText);
        var drpCountry = $("#drpCountry");
        
        $.ajax({
            type: 'POST',
            url: '/Location/Country',
            data: JSON.stringify({ identity: $("#drpRegion").val() }),
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
        
        // debugger;
        varcountryText = $("#drpCountry").val();
        $("#hdnCountry").val(varcountryText);
        var drpState = $("#drpState");
        
        $.ajax({
            type: 'POST',
            url: '/Location/State',
            data: JSON.stringify({ identity: $("#drpCountry").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpState.empty().append('<option selected="selected" value="0">Select State</option>');
                $.each(response, function () {
                    drpState.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpState', function () {
        
        // debugger;
       
        varstateText = $("#drpState").val();
        $("#hdnState").val(varstateText);
        var drpDistrict = $("#drpdistrict");
        
        $.ajax({
            type: 'POST',
            url: '/Location/District',
            data: JSON.stringify({ identity: $("#drpState").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpDistrict.empty().append('<option selected="selected" value="0">Select District</option>');
                $.each(response, function () {
                    drpDistrict.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });


    $(document).on('change', '#drpdistrict', function () {
        
        // debugger;
        vardistrictText = $("#drpdistrict").val();
        $("#hdnDistrict").val(vardistrictText);

       
    });

    $(document).off("click", ".LocationCancel");
    $(document).on("click", ".LocationCancel", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Location Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.LocationSearchDetials').show();
                $('.LocationAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".LocationView");
    $(document).on("click", ".LocationView", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Location Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            success: function (data, status, xhr) {
                $('.LocationSearchDetials').hide();
                $('.LocationAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".LocationEdit, .LocationAdd");
    $(document).on("click", ".LocationEdit, .LocationAdd", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Location Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.LocationSearchDetials').hide();
                $('.LocationAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".LocationDelete");
    $(document).on("click", ".LocationDelete", function (event) {
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

    $(document).off("click", ".LocationAddEdit");
    $(document).on("click", ".LocationAddEdit", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Location Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".LocationDetails").find("input").serialize(),
            success: function (data, status, xhr) {
                $('.LocationSearchDetials').show();
                $('.LocationAdd').show();
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

    $(document).off("click", ".LocationSearch");
    $(document).on("click", ".LocationSearch", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Location Info');
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



