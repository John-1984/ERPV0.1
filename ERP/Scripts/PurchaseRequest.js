

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

    $(document).off("click", ".PurchaseRequestCancel");
    $(document).on("click", ".PurchaseRequestCancel", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Purchase Request Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.PurchaseRequestSearchDetials').show();
                $('.PurchaseRequestAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });



    $(document).on('change', '#drpPurchaseRequestDetProductMaster', function () {

        // debugger;

        var productMasterText = $("#drpPurchaseRequestDetProductMaster").val();
        $("#hdnProductMaster").val(productMasterText);
        var drpPurchaseRequestDetVendor = $("#drpPurchaseRequestDetVendor");

        $.ajax({
            type: 'POST',
            url: '/PurchaseRequest/Vendor',
            data: JSON.stringify({ identity: $("#drpPurchaseRequestDetProductMaster").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpPurchaseRequestDetVendor.empty().append('<option selected="selected" value="0">Select Vendor</option>');
                $.each(response, function () {
                    drpPurchaseRequestDetVendor.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpPurchaseRequestDetVendor', function () {

        // debugger;

        var VendorText = $("#drpPurchaseRequestDetVendor").val();
        $("#hdnVendor").val(VendorText);
        var drpPurchaseRequestDetBrand = $("#drpPurchaseRequestDetBrand");

        $.ajax({
            type: 'POST',
            url: '/PurchaseRequest/Brand',
            data: JSON.stringify({ identity: $("#drpPurchaseRequestDetVendor").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpPurchaseRequestDetBrand.empty().append('<option selected="selected" value="0">Select Brand</option>');
                $.each(response, function () {
                    drpPurchaseRequestDetBrand.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpPurchaseRequestDetBrand', function () {

        // debugger;

        var brandText = $("#drpPurchaseRequestDetBrand").val();
        $("#hdnBrand").val(brandText);
        var drpPurchaseRequestDetItem = $("#drpPurchaseRequestDetItem");

        $.ajax({
            type: 'POST',
            url: '/PurchaseRequest/Brand',
            data: JSON.stringify({ identity: $("#drpPurchaseRequestDetBrand").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpPurchaseRequestDetItem.empty().append('<option selected="selected" value="0">Select Brand</option>');
                $.each(response, function () {
                    drpPurchaseRequestDetItem.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpPurchaseRequestDetItem', function () {

        // debugger;
        var itemText = $("#drpPurchaseRequestDetItem").val();
        $("#hdnItem").val(itemText);

        $.ajax({
            type: 'POST',
            url: '/PurchaseRequest/Item',
            data: JSON.stringify({ identity: $("#drpPurchaseRequestDetItem").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                //  alert(response.RetailPrice);
                // alert($("#ItemPrice").val());
                //drpPurchaseRequestDetItem.empty().append('<option selected="selected" value="0">Select Brand</option>');
                $("#ItemPrice").val(response.RetailPrice);
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });


    $(document).on('change', '#drpurchaserequesttype', function () {
        // debugger;
        
        var itemText = $("#drpurchaserequesttype").val();
        $("#hdnpurReqType").val(itemText);      
    });

    $(document).on('change', '#drpPurchaseRequestDetenquirylevel', function () {
        // debugger;
        alert("hii");
        var enqText = $("#drpPurchaseRequestDetenquirylevel").val();
        $("#hdnporequestenqlvel").val(enqText);
    });

    $(document).off("click", ".PurchaseRequestView");
    $(document).on("click", ".PurchaseRequestView", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Purchase Request Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            success: function (data, status, xhr) {
                $('.PurchaseRequestSearchDetials').hide();
                $('.PurchaseRequestAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".PurchaseRequestDetEdit, .PurchaseRequestDetailsAdd");
    $(document).on("click", ".PurchaseRequestDetEdit, .PurchaseRequestDetailsAdd", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Purchase Request Item Details');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.PurchaseRequestSearchDetials').hide();
                // $('.PurchaseRequestAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".PurchaseRequestAdd, .PurchaseRequestCommentsEdit");
    $(document).on("click", ".PurchaseRequestAdd, .PurchaseRequestCommentsEdit", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Purchase Request');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.PurchaseRequestSearchDetials').hide();
                // $('.PurchaseRequestAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".PurchaseRequestDelete");
    $(document).on("click", ".PurchaseRequestDelete", function (event) {
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

    $(document).off("click", ".PurchaseRequestItemDelete");
    $(document).on("click", ".PurchaseRequestItemDelete", function (event) {
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

    $(document).off("click", ".PurchaseRequestVerification");
    $(document).on("click", ".PurchaseRequestVerification", function (event) {
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

    $(document).off("click", ".PurchaseRequestAddEdit");
    $(document).on("click", ".PurchaseRequestAddEdit", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Purchase Request Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".PurchaseRequestDetails").find("input, textarea").serialize(),
            success: function (data, status, xhr) {
                $('.PurchaseRequestSearchDetials').show();
                $('.PurchaseRequestAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".PurchaseRequestSearch");
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



