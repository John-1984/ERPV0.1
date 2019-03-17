

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

    $(document).off("click", ".PurchaseOrderCancel");
    $(document).on("click", ".PurchaseOrderCancel", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Purchase Order Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {
                $('.PurchaseOrderSearchDetials').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });


    $(document).on('change', '#drpPurchaseOrderEmployee', function () {
        // debugger;  
       // alert($("#drpPurchaseOrderEmployee").val());
        var pendASalesEmpText = $("#drpPurchaseOrderEmployee").val();
        $("#hdnPurchaseOrderEmployee").val(pendASalesEmpText);
    });

    $(document).on('change', '#drpPurchaseOrderPaymentType', function () {
        // debugger;  
       // alert($("#drpPurchaseOrderEmployee").val());
        var pendASalestypeText = $("#drpPurchaseOrderPaymentType").val();
        $("#hdnPurchaseOrderPaymentType").val(pendASalestypeText);
    });

    $(document).on('change', '#drpPurchaseOrderPaymentMode', function () {
        // debugger;  
        // alert($("#drpPurchaseOrderEmployee").val());
        var pendASalesmodeText = $("#drpPurchaseOrderPaymentMode").val();
        $("#hdnPurchaseOrderPaymentMode").val(pendASalesmodeText);
    });

    $(document).on('change', '#drpPurchaseOrderEmployee', function () {
        // debugger;  
        // alert($("#drpPurchaseOrderEmployee").val());
        var PurchaseOrderEmployee = $("#drpPurchaseOrderEmployee").val();
        $("#hdnPurchaseOrderEmployee").val(PurchaseOrderEmployee);
    });


    $(document).on('change', '#drpPurchaseOrderLocation', function () {
        // debugger;
        varregionText = $("#drpPurchaseOrderLocation").val();
        $("#hdnPurchaseOrderLocation").val(varregionText);
        var drpPurchaseOrderEmployee = $("#drpPurchaseOrderEmployee");

        $.ajax({
            type: 'POST',
            url: '/PurchaseOrder/Employee',
            data: JSON.stringify({ identity: $("#drpPurchaseOrderLocation").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpPurchaseOrderEmployee.empty().append('<option selected="selected" value="0">Select Warehouse Manager</option>');
                $.each(response, function () {
                    drpPurchaseOrderEmployee.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });


    $(document).off("click", ".PurchaseOrderView");
    $(document).on("click", ".PurchaseOrderView", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Purchase Order Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            success: function (data, status, xhr) {
                $('.PurchaseOrderSearchDetials').hide();
                $('.PurchaseOrderAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".PurchaseOrderDetEdit, .PurchaseOrderDetailsAdd");
    $(document).on("click", ".PurchaseOrderDetEdit, .PurchaseOrderDetailsAdd", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Purchase Order Details');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.PurchaseOrderSearchDetials').hide();
                // $('.PurchaseOrderAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".PurchaseOrderAdd, .PurchaseOrderCommentsEdit");
    $(document).on("click", ".PurchaseOrderAdd, .PurchaseOrderCommentsEdit", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Purchase Order');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.PurchaseOrderSearchDetials').hide();
                // $('.PurchaseOrderAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".PurchaseOrderDelete");
    $(document).on("click", ".PurchaseOrderDelete", function (event) {
        event.stopImmediatePropagation();
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

    $(document).off("click", ".PurchaseOrderItemDelete");
    $(document).on("click", ".PurchaseOrderItemDelete", function (event) {
        event.stopImmediatePropagation();
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

    $(document).off("click", ".PurchaseOrderVerification");
    $(document).on("click", ".PurchaseOrderVerification", function (event) {
        event.stopImmediatePropagation();
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

    $(document).off("click", ".PurchaseOrderAddEdit");
    $(document).on("click", ".PurchaseOrderAddEdit", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        alert("updae")
        $('.headermode').html('View Purchase Order Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".PurchaseOrderDetails").find("input, textarea, hidden").serialize(),
            success: function (data, status, xhr) {
                $('.PurchaseOrderSearchDetials').show();
                $('.PurchaseOrderAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".PurchaseOrderSearch");
    $(document).on("click", ".ProductEnquirySearch", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Purchase Order Info');
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



