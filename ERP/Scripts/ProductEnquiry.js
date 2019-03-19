

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

    $(document).off("click", ".ProductEnquiryCancel");
    $(document).on("click", ".ProductEnquiryCancel", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Product Enquiry Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.ProductEnquirySearchDetials').show();
                $('.ProductEnquiryAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

   

    $(document).on('change', '#drpProductEnquiryDetProductMaster', function () {

        // debugger;

        var productMasterText = $("#drpProductEnquiryDetProductMaster").val();
        $("#hdnProductMaster").val(productMasterText);
        var drpProductEnquiryDetVendor = $("#drpProductEnquiryDetVendor");

        $.ajax({
            type: 'POST',
            url: '/ProductEnquiry/Vendor',
            data: JSON.stringify({ identity: $("#drpProductEnquiryDetProductMaster").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpProductEnquiryDetVendor.empty().append('<option selected="selected" value="0">Select Vendor</option>');
                $.each(response, function () {
                    drpProductEnquiryDetVendor.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpProductEnquiryDetVendor', function () {

        // debugger;

        var VendorText = $("#drpProductEnquiryDetVendor").val();
        $("#hdnVendor").val(VendorText);
        var drpProductEnquiryDetBrand = $("#drpProductEnquiryDetBrand");

        $.ajax({
            type: 'POST',
            url: '/ProductEnquiry/Brand',
            data: JSON.stringify({ identity: $("#drpProductEnquiryDetVendor").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpProductEnquiryDetBrand.empty().append('<option selected="selected" value="0">Select Brand</option>');
                $.each(response, function () {
                    drpProductEnquiryDetBrand.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpProductEnquiryDetBrand', function () {

        // debugger;

        var brandText = $("#drpProductEnquiryDetBrand").val();
        $("#hdnBrand").val(brandText);
        var drpProductEnquiryDetItem = $("#drpProductEnquiryDetItem");

        $.ajax({
            type: 'POST',
            url: '/ProductEnquiry/Brand',
            data: JSON.stringify({ identity: $("#drpProductEnquiryDetBrand").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpProductEnquiryDetItem.empty().append('<option selected="selected" value="0">Select Brand</option>');
                $.each(response, function () {
                    drpProductEnquiryDetItem.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpProductEnquiryDetItem', function () {

        // debugger;
        var itemText = $("#drpProductEnquiryDetItem").val();
        $("#hdnItem").val(itemText);

        $.ajax({
            type: 'POST',
            url: '/ProductEnquiry/Item',
            data: JSON.stringify({ identity: $("#drpProductEnquiryDetItem").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
              //  alert(response.RetailPrice);
               // alert($("#ItemPrice").val());
                //drpProductEnquiryDetItem.empty().append('<option selected="selected" value="0">Select Brand</option>');
                $("#ItemPrice").val(response.RetailPrice);
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });
   

   

    $(document).off("click", ".ProductEnquiryView");
    $(document).on("click", ".ProductEnquiryView", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Product Enquiry Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            success: function (data, status, xhr) {
                $('.ProductEnquirySearchDetials').hide();
                $('.ProductEnquiryAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".ProductEnquiryEdit, .ProductEnquiryAdd, .ProductEnquiryDetailsAdd");
    $(document).on("click", ".ProductEnquiryEdit, .ProductEnquiryAdd, .ProductEnquiryDetailsAdd", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Product Enquiry Item Details');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.ProductEnquirySearchDetials').hide();
               // $('.ProductEnquiryAdd').hide();
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

    $(document).off("click", ".ProductEnquiryDelete");
    $(document).on("click", ".ProductEnquiryDelete", function (event) {
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

    $(document).off("click", ".ProductEnquiryVerification");
    $(document).on("click", ".ProductEnquiryVerification", function (event) {
        if (!confirm("Do you want to submit for verifcation")) {
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

    $(document).off("click", ".ProductEnquiryAddEdit");
    $(document).on("click", ".ProductEnquiryAddEdit", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Product Enquiry Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".ProductEnquiryDetails").find("input").serialize(),
            success: function (data, status, xhr) {
                $('.ProductEnquirySearchDetials').show();
                $('.ProductEnquiryAdd').show();
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

    $(document).off("click", ".ProductEnquirySearch");
    $(document).on("click", ".ProductEnquirySearch", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Product Enquiry Info');
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



