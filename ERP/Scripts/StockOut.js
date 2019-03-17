

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

    $(document).off("click", ".StockOutCancel");
    $(document).on("click", ".StockOutCancel", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Stock Out Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {
                $('.StockOutSearchDetials').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });


    $(document).on('change', '#drpStockOutEmployee', function () {
        // debugger;  
       // alert($("#drpStockOutEmployee").val());
        var pendASalesEmpText = $("#drpStockOutEmployee").val();
        $("#hdnStockOutEmployee").val(pendASalesEmpText);
    });

    $(document).on('change', '#drpStockOutPaymentType', function () {
        // debugger;  
       // alert($("#drpStockOutEmployee").val());
        var pendASalestypeText = $("#drpStockOutPaymentType").val();
        $("#hdnStockOutPaymentType").val(pendASalestypeText);
    });

    $(document).on('change', '#drpstockoutexpensetype', function () {
        // debugger;  
        // alert($("#drpStockOutEmployee").val());
        var pendASalesmodeText = $("#drpstockoutexpensetype").val();
        $("#hdnstockoutexpensetype").val(pendASalesmodeText);
    });

    $(document).on('change', '#drpStockOutPaymentMode', function () {
        // debugger;  
        // alert($("#drpStockOutEmployee").val());
        var pendASalesmodeText = $("#drpStockOutPaymentMode").val();
        $("#hdnStockOutPaymentMode").val(pendASalesmodeText);
    });

    $(document).off("click", ".StockOutView");
    $(document).on("click", ".StockOutView", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Stock Out Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            success: function (data, status, xhr) {
                $('.StockOutSearchDetials').hide();
                $('.StockOutAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".StockOutDetEdit, .StockOutDetailsAdd");
    $(document).on("click", ".StockOutDetEdit, .StockOutDetailsAdd", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Stock Out Details');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.StockOutSearchDetials').hide();
                // $('.StockOutAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".StockOutAdd, .StockOutCommentsEdit");
    $(document).on("click", ".StockOutAdd, .StockOutCommentsEdit", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Stock Out Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.StockOutSearchDetials').hide();
                // $('.StockOutAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".StockOutExpenseAdd");
    $(document).on("click", ".StockOutExpenseAdd", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Stock Out Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".StockOutExpenseDetails").find("input, textarea, hidden").serialize(),
            //async: true,
            success: function (data, status, xhr) {
                $('.StockOutSearchDetials').hide();
                $('.StockOutAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".StockOutDelete");
    $(document).on("click", ".StockOutDelete", function (event) {
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

    $(document).off("click", ".StockOutItemDelete");
    $(document).on("click", ".StockOutItemDelete", function (event) {
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

    $(document).off("click", ".StockOutVerification");
    $(document).on("click", ".StockOutVerification", function (event) {
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

    $(document).off("click", ".StockOutAddEdit");
    $(document).on("click", ".StockOutAddEdit", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        alert("updae")
        $('.headermode').html('View Stock Out Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".StockOutDetails").find("input, textarea, hidden").serialize(),
            success: function (data, status, xhr) {
                $('.StockOutSearchDetials').show();
                $('.StockOutAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".StockOutSearch");
    $(document).on("click", ".ProductEnquirySearch", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Stock Out Info');
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



