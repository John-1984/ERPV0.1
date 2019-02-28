

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

    $(document).off("click", ".StocksCancel");
    $(document).on("click", ".StocksCancel", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Stocks Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.StocksSearchDetials').show();
                $('.StocksAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

   

    $(document).on('change', '#drpStocksDetProductMaster', function () {

        // debugger;

        var productMasterText = $("#drpStocksDetProductMaster").val();
        $("#hdnProductMaster").val(productMasterText);
        var drpStocksDetVendor = $("#drpStocksDetVendor");

        $.ajax({
            type: 'POST',
            url: '/Stocks/Vendor',
            data: JSON.stringify({ identity: $("#drpStocksDetProductMaster").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpStocksDetVendor.empty().append('<option selected="selected" value="0">Select Vendor</option>');
                $.each(response, function () {
                    drpStocksDetVendor.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpStocksDetVendor', function () {

        // debugger;

        var VendorText = $("#drpStocksDetVendor").val();
        $("#hdnVendor").val(VendorText);
        var drpStocksDetBrand = $("#drpStocksDetBrand");

        $.ajax({
            type: 'POST',
            url: '/Stocks/Brand',
            data: JSON.stringify({ identity: $("#drpStocksDetVendor").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpStocksDetBrand.empty().append('<option selected="selected" value="0">Select Brand</option>');
                $.each(response, function () {
                    drpStocksDetBrand.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpStocksDetBrand', function () {

        // debugger;

        var brandText = $("#drpStocksDetBrand").val();
        $("#hdnBrand").val(brandText);
        var drpStocksDetItem = $("#drpStocksDetItem");

        $.ajax({
            type: 'POST',
            url: '/Stocks/Brand',
            data: JSON.stringify({ identity: $("#drpStocksDetBrand").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpStocksDetItem.empty().append('<option selected="selected" value="0">Select Brand</option>');
                $.each(response, function () {
                    drpStocksDetItem.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpStocksDetItem', function () {

        // debugger;
        var itemText = $("#drpStocksDetItem").val();
        $("#hdnItem").val(itemText);

        $.ajax({
            type: 'POST',
            url: '/Stocks/Item',
            data: JSON.stringify({ identity: $("#drpStocksDetItem").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
              //  alert(response.RetailPrice);
               // alert($("#ItemPrice").val());
                //drpStocksDetItem.empty().append('<option selected="selected" value="0">Select Brand</option>');
                $("#ItemPrice").val(response.RetailPrice);
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });
   

   

    $(document).off("click", ".StocksView");
    $(document).on("click", ".StocksView", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Stocks Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            success: function (data, status, xhr) {
                $('.StocksSearchDetials').hide();
                $('.StocksAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".StocksEdit, .StocksAdd, .StocksDetailsAdd");
    $(document).on("click", ".StocksEdit, .StocksAdd, .StocksDetailsAdd", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Stocks Item Details');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.StocksSearchDetials').hide();
               // $('.StocksAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".StocksDelete");
    $(document).on("click", ".StocksDelete", function (event) {
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

   

    $(document).off("click", ".StocksAddEdit");
    $(document).on("click", ".StocksAddEdit", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Stocks Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".StocksDetails").find("input").serialize(),
            success: function (data, status, xhr) {
                $('.StocksSearchDetials').show();
                $('.StocksAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".StocksSearch");
    $(document).on("click", ".StocksSearch", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Stocks Info');
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



