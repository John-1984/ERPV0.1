

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

    $(document).off("click", ".DeadStockCancel");
    $(document).on("click", ".DeadStockCancel", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Dead Stock Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.DeadStockSearchDetials').show();
                $('.DeadStockAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });



    $(document).on('change', '#drpDeadStockDetProductMaster', function () {

        // debugger;

        var productMasterText = $("#drpDeadStockDetProductMaster").val();
        $("#hdnProductMaster").val(productMasterText);
        var drpDeadStockDetVendor = $("#drpDeadStockDetVendor");

        $.ajax({
            type: 'POST',
            url: '/DeadStock/Vendor',
            data: JSON.stringify({ identity: $("#drpDeadStockDetProductMaster").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpDeadStockDetVendor.empty().append('<option selected="selected" value="0">Select Vendor</option>');
                $.each(response, function () {
                    drpDeadStockDetVendor.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpDeadStockDetVendor', function () {

        // debugger;

        var VendorText = $("#drpDeadStockDetVendor").val();
        $("#hdnVendor").val(VendorText);
        var drpDeadStockDetBrand = $("#drpDeadStockDetBrand");

        $.ajax({
            type: 'POST',
            url: '/DeadStock/Brand',
            data: JSON.stringify({ identity: $("#drpDeadStockDetVendor").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpDeadStockDetBrand.empty().append('<option selected="selected" value="0">Select Brand</option>');
                $.each(response, function () {
                    drpDeadStockDetBrand.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpDeadStockDetBrand', function () {

        // debugger;

        var brandText = $("#drpDeadStockDetBrand").val();
        $("#hdnBrand").val(brandText);
        var drpDeadStockDetItem = $("#drpDeadStockDetItem");

        $.ajax({
            type: 'POST',
            url: '/DeadStock/Brand',
            data: JSON.stringify({ identity: $("#drpDeadStockDetBrand").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpDeadStockDetItem.empty().append('<option selected="selected" value="0">Select Brand</option>');
                $.each(response, function () {
                    drpDeadStockDetItem.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpDeadStockDetItem', function () {

        // debugger;
        var itemText = $("#drpDeadStockDetItem").val();
        $("#hdnItem").val(itemText);

        $.ajax({
            type: 'POST',
            url: '/DeadStock/Item',
            data: JSON.stringify({ identity: $("#drpDeadStockDetItem").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                //  alert(response.RetailPrice);
                // alert($("#ItemPrice").val());
                //drpDeadStockDetItem.empty().append('<option selected="selected" value="0">Select Brand</option>');
                $("#ItemPrice").val(response.RetailPrice);
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });




    $(document).off("click", ".DeadStockView");
    $(document).on("click", ".DeadStockView", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Dead Stock Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            success: function (data, status, xhr) {
                $('.DeadStockSearchDetials').hide();
                $('.DeadStockAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".DeadStockEdit, .DeadStockAdd, .DeadStockDetailsAdd");
    $(document).on("click", ".DeadStockEdit, .DeadStockAdd, .DeadStockDetailsAdd", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Dead Stock Item Details');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.DeadStockSearchDetials').hide();
                // $('.DeadStockAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".DeadStockDelete");
    $(document).on("click", ".DeadStockDelete", function (event) {
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



    $(document).off("click", ".DeadStockAddEdit");
    $(document).on("click", ".DeadStockAddEdit", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Dead Stock Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".DeadStockDetails").find("input").serialize(),
            success: function (data, status, xhr) {
                $('.DeadStockSearchDetials').show();
                $('.DeadStockAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".DeadStockSearch");
    $(document).on("click", ".DeadStockSearch", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Dead Stock Info');
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



