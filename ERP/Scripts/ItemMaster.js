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

    $(document).off("click", ".ItemMasterCancel");
    $(document).on("click", ".ItemMasterCancel", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Item Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.ItemMasterSearchDetials').show();
                $('.ItemMasterAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).on('change', '#drpItemMasterProductMaster', function () {
        
        // debugger;
       
        varproductMasterText = $("#drpItemMasterProductMaster").val();
        $("#hdnProductMaster").val(varproductMasterText);
        var drpItemMasterVendor = $("#drpItemMasterVendor");
        
        $.ajax({
            type: 'POST',
            url: '/ItemMaster/Vendor',
            data: JSON.stringify({ identity: $("#drpItemMasterProductMaster").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpItemMasterVendor.empty().append('<option selected="selected" value="0">Select Vendor</option>');
                $.each(response, function () {
                    drpItemMasterVendor.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpItemMasterVendor', function () {
        
        // debugger;
       
        varVendorText = $("#drpItemMasterVendor").val();
        $("#hdnVendor").val(varVendorText);
        var drpItemMasterBrand = $("#drpItemMasterBrand");
        
        $.ajax({
            type: 'POST',
            url: '/ItemMaster/Brand',
            data: JSON.stringify({ identity: $("#drpItemMasterVendor").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpItemMasterBrand.empty().append('<option selected="selected" value="0">Select Brand</option>');
                $.each(response, function () {
                    drpItemMasterBrand.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpItemMasterBrand', function () {
        
        // debugger;
        varbrandText = $("#drpItemMasterBrand").val();
        $("#hdnBrand").val(varbrandText);

       
    });

    $(document).on('change', '#drpItemMasterUOM', function () {
        
        // debugger;
        varuomText = $("#drpItemMasterUOM").val();
        $("#hdnUOM").val(varuomText);

        
    });
    $(document).off("click", ".ItemMasterView");
    $(document).on("click", ".ItemMasterView", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Item Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            success: function (data, status, xhr) {
                $('.ItemMasterSearchDetials').hide();
                $('.ItemMasterAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".ItemMasterEdit, .ItemMasterAdd");
    $(document).on("click", ".ItemMasterEdit, .ItemMasterAdd", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Item Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.ItemMasterSearchDetials').hide();
                $('.ItemMasterAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".ItemMasterDelete");
    $(document).on("click", ".ItemMasterDelete", function (event) {
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

    $(document).off("click", ".ItemMasterAddEdit");
    $(document).on("click", ".ItemMasterAddEdit", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Item Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".ItemMasterDetails").find("input").serialize(),
            success: function (data, status, xhr) {
                $('.ItemMasterSearchDetials').show();
                $('.ItemMasterAdd').show();
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

    $(document).off("click", ".ItemMasterSearch");
    $(document).on("click", ".ItemMasterSearch", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Item Info');
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



