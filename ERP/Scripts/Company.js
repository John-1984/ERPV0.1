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

    $(document).on('change', '#drpCompRegion', function () {
        //alert("Test");
        // debugger;
        varregionText = $("#drpCompRegion").val();
        $("#hdnRegion").val(varregionText);
        var drpCompCountry = $("#drpCompCountry");
        // alert("Test");
        $.ajax({
            type: 'POST',
            url: '/Company/Country',
            data: JSON.stringify({ identity: $("#drpCompRegion").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpCompCountry.empty().append('<option selected="selected" value="0">Select Country</option>');
                $.each(response, function () {
                    drpCompCountry.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpCompCountry', function () {
        //alert("Test");
        // debugger;
        varcountryText = $("#drpCompCountry").val();
        $("#hdnCountry").val(varcountryText);
        var drpCompState = $("#drpCompState");
        //alert("Test");
        $.ajax({
            type: 'POST',
            url: '/Company/State',
            data: JSON.stringify({ identity: $("#drpCompCountry").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpCompState.empty().append('<option selected="selected" value="0">Select State</option>');
                $.each(response, function () {
                    drpCompState.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpCompState', function () {
        //alert("Test");
        // debugger;
       // alert("Test");
        varstateText = $("#drpCompState").val();
        $("#hdnState").val(varstateText);
        var drpcompdistrict = $("#drpcompdistrict");
        //alert("Test");
        $.ajax({
            type: 'POST',
            url: '/Company/District',
            data: JSON.stringify({ identity: $("#drpCompState").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpcompdistrict.empty().append('<option selected="selected" value="0">Select District</option>');
                $.each(response, function () {
                    drpcompdistrict.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpcompdistrict', function () {
        //alert("Test");
        // debugger;
        alert("Test");
        vardistrictText = $("#drpcompdistrict").val();
        $("#hdnDistrict").val(vardistrictText);
        var drpComplocation = $("#drpComplocation");
        //alert("Test");
        $.ajax({
            type: 'POST',
            url: '/Company/Location',
            data: JSON.stringify({ identity: $("#drpcompdistrict").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpComplocation.empty().append('<option selected="selected" value="0">Select Location</option>');
                $.each(response, function () {
                    drpComplocation.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });


    $(document).on('change', '#drpComplocation', function () {
        //alert("Test");
        // debugger;
        vardistrictText = $("#drpComplocation").val();
        $("#hdnLocation").val(vardistrictText);

       // alert(vardistrictText);
    });

    $(document).off("click", ".CompanyCancel");
    $(document).on("click", ".CompanyCancel", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Company Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.CompanySearchDetials').show();
                $('.CompanyAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });
    $(document).off("click", ".CompanyView");
    $(document).on("click", ".CompanyView", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Company Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            success: function (data, status, xhr) {
                $('.CompanySearchDetials').hide();
                $('.CompanyAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".CompanyEdit, .CompanyAdd");
    $(document).on("click", ".CompanyEdit, .CompanyAdd", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Company Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.CompanySearchDetials').hide();
                $('.CompanyAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".CompanyDelete");
    $(document).on("click", ".CompanyDelete", function (event) {
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

    $(document).off("click", ".CompanyAddEdit");
    $(document).on("click", ".CompanyAddEdit", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Company Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".CompanyDetails").find("input").serialize(),
            success: function (data, status, xhr) {
                $('.CompanySearchDetials').show();
                $('.CompanyAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".CompanySearch");
    $(document).on("click", ".CompanySearch", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Company Info');
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



