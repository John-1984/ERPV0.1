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

    $(document).on('change', '#drpCompTypeRegion', function () {
        //alert("Test");
        // debugger;
        varregionText = $("#drpCompTypeRegion").val();
        $("#hdnRegion").val(varregionText);
        var drpCompTypeCountry = $("#drpCompTypeCountry");
        // alert("Test");
        $.ajax({
            type: 'POST',
            url: '/CompanyType/Country',
            data: JSON.stringify({ identity: $("#drpCompTypeRegion").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpCompTypeCountry.empty().append('<option selected="selected" value="0">Select Country</option>');
                $.each(response, function () {
                    drpCompTypeCountry.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpCompTypeCountry', function () {
        //alert("Test");
        // debugger;
        varcountryText = $("#drpCompTypeCountry").val();
        $("#hdnCountry").val(varcountryText);
        var drpCompTypeState = $("#drpCompTypeState");
        //alert("Test");
        $.ajax({
            type: 'POST',
            url: '/CompanyType/State',
            data: JSON.stringify({ identity: $("#drpCompTypeCountry").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpCompTypeState.empty().append('<option selected="selected" value="0">Select State</option>');
                $.each(response, function () {
                    drpCompTypeState.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpCompTypeState', function () {
        //alert("Test");
        // debugger;
       // alert("Test");
        varstateText = $("#drpCompTypeState").val();
        $("#hdnState").val(varstateText);
        var drpCompTypedistrict = $("#drpCompTypedistrict");
        //alert("Test");
        $.ajax({
            type: 'POST',
            url: '/CompanyType/District',
            data: JSON.stringify({ identity: $("#drpCompTypeState").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpCompTypedistrict.empty().append('<option selected="selected" value="0">Select District</option>');
                $.each(response, function () {
                    drpCompTypedistrict.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpCompTypedistrict', function () {
        //alert("Test");
        // debugger;
        //alert("Test");
        varstateText = $("#drpCompTypedistrict").val();
        $("#hdnDistrict").val(varstateText);
        var drpCompTypelocation = $("#drpCompTypelocation");
        //alert("Test");
        $.ajax({
            type: 'POST',
            url: '/CompanyType/Location',
            data: JSON.stringify({ identity: $("#drpCompTypedistrict").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpCompTypelocation.empty().append('<option selected="selected" value="0">Select District</option>');
                $.each(response, function () {
                    drpCompTypelocation.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpCompTypelocation', function () {
        //alert("Test");
        // debugger;
        alert("Test");
        varlocationText = $("#drpCompTypelocation").val();
        $("#hdnLocation").val(varlocationText);
        var drpCompTypecompany = $("#drpCompTypecompany");
        //alert("Test");
        $.ajax({
            type: 'POST',
            url: '/CompanyType/Company',
            data: JSON.stringify({ identity: $("#drpCompTypelocation").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpCompTypecompany.empty().append('<option selected="selected" value="0">Select District</option>');
                $.each(response, function () {
                    drpCompTypecompany.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpCompTypecompany', function () {
        //alert("Test");
        // debugger;
        varcompanyText = $("#drpCompTypecompany").val();
        $("#hdnCompany").val(varcompanyText);

      //  alert(vardistrictText);
    });

    $(document).off("click", ".CompanyTypeCancel");
    $(document).on("click", ".CompanyTypeCancel", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View CompanyType Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.CompanyTypeSearchDetials').show();
                $('.CompanyTypeAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });
    $(document).off("click", ".CompanyTypeView");
    $(document).on("click", ".CompanyTypeView", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Company Type Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            success: function (data, status, xhr) {
                $('.CompanyTypeSearchDetials').hide();
                $('.CompanyTypeAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".CompanyTypeEdit, .CompanyTypeAdd");
    $(document).on("click", ".CompanyTypeEdit, .CompanyTypeAdd", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Company Type Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.CompanyTypeSearchDetials').hide();
                $('.CompanyTypeAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".CompanyTypeDelete");
    $(document).on("click", ".CompanyTypeDelete", function (event) {
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

    $(document).off("click", ".CompanyTypeAddEdit");
    $(document).on("click", ".CompanyTypeAddEdit", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Company Type Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".CompanyTypeDetails").find("input").serialize(),
            success: function (data, status, xhr) {
                $('.CompanyTypeSearchDetials').show();
                $('.CompanyTypeAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".CompanyTypeSearch");
    $(document).on("click", ".CompanyTypeSearch", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Company Type Info');
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



