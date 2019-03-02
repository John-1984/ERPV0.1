

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

    $(document).off("click", ".StocksShortageCancel");
    $(document).on("click", ".StocksShortageCancel", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Stocks Shortage Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.StocksShortageSearchDetials').show();
                $('.StocksShortageAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".StocksShortageCreateRequest");
    $(document).on("click", ".StocksShortageCreateRequest", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Stocks Shortage Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.StocksShortageSearchDetials').show();
                $('.StocksShortageAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });



    $(document).on('change', '#drpStocksShortageDetProductMaster', function () {

        // debugger;

        var productMasterText = $("#drpStocksShortageDetProductMaster").val();
        $("#hdnProductMaster").val(productMasterText);
        var drpStocksShortageDetVendor = $("#drpStocksShortageDetVendor");

        $.ajax({
            type: 'POST',
            url: '/StocksShortage/Vendor',
            data: JSON.stringify({ identity: $("#drpStocksShortageDetProductMaster").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpStocksShortageDetVendor.empty().append('<option selected="selected" value="0">Select Vendor</option>');
                $.each(response, function () {
                    drpStocksShortageDetVendor.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpStocksShortageDetVendor', function () {

        // debugger;

        var VendorText = $("#drpStocksShortageDetVendor").val();
        $("#hdnVendor").val(VendorText);
        var drpStocksShortageDetBrand = $("#drpStocksShortageDetBrand");

        $.ajax({
            type: 'POST',
            url: '/StocksShortage/Brand',
            data: JSON.stringify({ identity: $("#drpStocksShortageDetVendor").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpStocksShortageDetBrand.empty().append('<option selected="selected" value="0">Select Brand</option>');
                $.each(response, function () {
                    drpStocksShortageDetBrand.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpStocksShortageDetBrand', function () {

        // debugger;

        var brandText = $("#drpStocksShortageDetBrand").val();
        $("#hdnBrand").val(brandText);
        var drpStocksShortageDetItem = $("#drpStocksShortageDetItem");

        $.ajax({
            type: 'POST',
            url: '/StocksShortage/Brand',
            data: JSON.stringify({ identity: $("#drpStocksShortageDetBrand").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpStocksShortageDetItem.empty().append('<option selected="selected" value="0">Select Brand</option>');
                $.each(response, function () {
                    drpStocksShortageDetItem.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpStocksShortageDetItem', function () {

        // debugger;
        var itemText = $("#drpStocksShortageDetItem").val();
        $("#hdnItem").val(itemText);

        $.ajax({
            type: 'POST',
            url: '/StocksShortage/Item',
            data: JSON.stringify({ identity: $("#drpStocksShortageDetItem").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                //  alert(response.RetailPrice);
                // alert($("#ItemPrice").val());
                //drpStocksShortageDetItem.empty().append('<option selected="selected" value="0">Select Brand</option>');
                $("#ItemPrice").val(response.RetailPrice);
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });




    $(document).off("click", ".StocksShortageView");
    $(document).on("click", ".StocksShortageView", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Stocks Shortage Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            success: function (data, status, xhr) {
                $('.StocksShortageSearchDetials').hide();
                $('.StocksShortageAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".StocksShortageEdit, .StocksShortageAdd, .StocksShortageDetailsAdd");
    $(document).on("click", ".StocksShortageEdit, .StocksShortageAdd, .StocksShortageDetailsAdd", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Stocks Shortage Item Details');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.StocksShortageSearchDetials').hide();
                // $('.StocksShortageAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".StocksShortageDelete");
    $(document).on("click", ".StocksShortageDelete", function (event) {
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



    $(document).off("click", ".StocksShortageAddEdit");
    $(document).on("click", ".StocksShortageAddEdit", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Stocks Shortage Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".StocksShortageDetails").find("input").serialize(),
            success: function (data, status, xhr) {
                $('.StocksShortageSearchDetials').show();
                $('.StocksShortageAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".StocksShortageSearch");
    $(document).on("click", ".StocksShortageSearch", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Stocks Shortage Info');
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



