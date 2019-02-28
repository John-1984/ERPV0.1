

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

    $(document).off("click", ".PendingPRVerificationCancel");
    $(document).on("click", ".PendingPRVerificationCancel", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Purchase Request Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.PendingPRVerificationSearchDetials').show();
                $('.PendingPRVerificationAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });



    $(document).on('change', '#drpPendingPRVerificationDetProductMaster', function () {

        // debugger;

        var productMasterText = $("#drpPendingPRVerificationDetProductMaster").val();
        $("#hdnProductMaster").val(productMasterText);
        var drpPendingPRVerificationDetVendor = $("#drpPendingPRVerificationDetVendor");

        $.ajax({
            type: 'POST',
            url: '/PendingPRVerification/Vendor',
            data: JSON.stringify({ identity: $("#drpPendingPRVerificationDetProductMaster").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpPendingPRVerificationDetVendor.empty().append('<option selected="selected" value="0">Select Vendor</option>');
                $.each(response, function () {
                    drpPendingPRVerificationDetVendor.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpPendingPRVerificationDetVendor', function () {

        // debugger;

        var VendorText = $("#drpPendingPRVerificationDetVendor").val();
        $("#hdnVendor").val(VendorText);
        var drpPendingPRVerificationDetBrand = $("#drpPendingPRVerificationDetBrand");

        $.ajax({
            type: 'POST',
            url: '/PendingPRVerification/Brand',
            data: JSON.stringify({ identity: $("#drpPendingPRVerificationDetVendor").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpPendingPRVerificationDetBrand.empty().append('<option selected="selected" value="0">Select Brand</option>');
                $.each(response, function () {
                    drpPendingPRVerificationDetBrand.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpPendingPRVerificationDetBrand', function () {

        // debugger;

        var brandText = $("#drpPendingPRVerificationDetBrand").val();
        $("#hdnBrand").val(brandText);
        var drpPendingPRVerificationDetItem = $("#drpPendingPRVerificationDetItem");

        $.ajax({
            type: 'POST',
            url: '/PendingPRVerification/Brand',
            data: JSON.stringify({ identity: $("#drpPendingPRVerificationDetBrand").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpPendingPRVerificationDetItem.empty().append('<option selected="selected" value="0">Select Brand</option>');
                $.each(response, function () {
                    drpPendingPRVerificationDetItem.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpPendingPRVerificationDetItem', function () {

        // debugger;
        var itemText = $("#drpPendingPRVerificationDetItem").val();
        $("#hdnItem").val(itemText);

        $.ajax({
            type: 'POST',
            url: '/PendingPRVerification/Item',
            data: JSON.stringify({ identity: $("#drpPendingPRVerificationDetItem").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                //  alert(response.RetailPrice);
                // alert($("#ItemPrice").val());
                //drpPendingPRVerificationDetItem.empty().append('<option selected="selected" value="0">Select Brand</option>');
                $("#ItemPrice").val(response.RetailPrice);
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });


    $(document).on('change', '#drPendingPRVerificationtype', function () {
        // debugger;
        var itemText = $("#drPendingPRVerificationtype").val();
        $("#hdnpurReqType").val(itemText);
    });

    $(document).on('change', '#drpPendingPRVerificationDetenquirylevel', function () {
        // debugger;
        var enqText = $("#drpPendingPRVerificationDetenquirylevel").val();
        $("#hdnporequestenqlvel").val(enqText);
    });

    $(document).on('change', '#drpPendingPRVerificationStatus', function () {
        // debugger;
        var statPendingPRText = $("#drpPendingPRVerificationStatus").val();
        $("#hdnPendingPRVerStatus").val(statPendingPRText);
    });

    $(document).off("click", ".PendingPRVerificationView");
    $(document).on("click", ".PendingPRVerificationView", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Purchase Request Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            success: function (data, status, xhr) {
                $('.PendingPRVerificationSearchDetials').hide();
                $('.PendingPRVerificationAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".PendingPRVerificationDetEdit, .PendingPRVerificationDetailsAdd");
    $(document).on("click", ".PendingPRVerificationDetEdit, .PendingPRVerificationDetailsAdd", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Purchase Request Item Details');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.PendingPRVerificationSearchDetials').hide();
                // $('.PendingPRVerificationAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".PendingPRVerificationAdd, .PendingPRVerificationCommentsEdit");
    $(document).on("click", ".PendingPRVerificationAdd, .PendingPRVerificationCommentsEdit", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Purchase Request');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.PendingPRVerificationSearchDetials').hide();
                // $('.PendingPRVerificationAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".PendingPRVerificationDelete");
    $(document).on("click", ".PendingPRVerificationDelete", function (event) {
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

    $(document).off("click", ".PendingPRVerificationItemDelete");
    $(document).on("click", ".PendingPRVerificationItemDelete", function (event) {
        if (!confirm("Do you want to delete the item")) {
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

    $(document).off("click", ".PendingPRVerificationVerification");
    $(document).on("click", ".PendingPRVerificationVerification", function (event) {
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

    $(document).off("click", ".PendingPRVerificationAddEdit");
    $(document).on("click", ".PendingPRVerificationAddEdit", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Purchase Request Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".PendingPRVerificationDetails").find("input, textarea").serialize(),
            success: function (data, status, xhr) {
                $('.PendingPRVerificationSearchDetials').show();
                $('.PendingPRVerificationAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".PendingPRVerificationSearch");
    $(document).on("click", ".ProductEnquirySearch", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Purchase Request Info');
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



