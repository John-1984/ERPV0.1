

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

    $(document).off("click", ".PurchaseQuotationCancel");
    $(document).on("click", ".PurchaseQuotationCancel", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Purchase Quotation Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {
                $('.PurchaseQuotationSearchDetials').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });


    $(document).on('change', '#drpPurchaseQuotationEmployee', function () {
        // debugger;  
       // alert($("#drpPurchaseQuotationEmployee").val());
        var pendASalesEmpText = $("#drpPurchaseQuotationEmployee").val();
        $("#hdnPurchaseQuotationEmployee").val(pendASalesEmpText);
    });

    $(document).on('change', '#drpPurchaseQuotationPaymentType', function () {
        // debugger;  
       // alert($("#drpPurchaseQuotationEmployee").val());
        var pendASalestypeText = $("#drpPurchaseQuotationPaymentType").val();
        $("#hdnPurchaseQuotationPaymentType").val(pendASalestypeText);
    });

    $(document).on('change', '#drpPurchaseQuotationPaymentMode', function () {
        // debugger;  
        // alert($("#drpPurchaseQuotationEmployee").val());
        var pendASalesmodeText = $("#drpPurchaseQuotationPaymentMode").val();
        $("#hdnPurchaseQuotationPaymentMode").val(pendASalesmodeText);
    });

    $(document).off("click", ".PurchaseQuotationView");
    $(document).on("click", ".PurchaseQuotationView", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Purchase Quotation Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            success: function (data, status, xhr) {
                $('.PurchaseQuotationSearchDetials').hide();
                $('.PurchaseQuotationAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".PurchaseQuotationDetEdit, .PurchaseQuotationDetailsAdd");
    $(document).on("click", ".PurchaseQuotationDetEdit, .PurchaseQuotationDetailsAdd", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Purchase Quotation Details');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.PurchaseQuotationSearchDetials').hide();
                // $('.PurchaseQuotationAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".PurchaseQuotationAdd, .PurchaseQuotationCommentsEdit");
    $(document).on("click", ".PurchaseQuotationAdd, .PurchaseQuotationCommentsEdit", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Purchase Quotation');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.PurchaseQuotationSearchDetials').hide();
                // $('.PurchaseQuotationAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".PurchaseQuotationDelete");
    $(document).on("click", ".PurchaseQuotationDelete", function (event) {
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

    $(document).off("click", ".PurchaseQuotationItemDelete");
    $(document).on("click", ".PurchaseQuotationItemDelete", function (event) {
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

    $(document).off("click", ".PurchaseQuotationVerification");
    $(document).on("click", ".PurchaseQuotationVerification", function (event) {
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

    $(document).off("click", ".PurchaseQuotationAddEdit");
    $(document).on("click", ".PurchaseQuotationAddEdit", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        alert("updae")
        $('.headermode').html('View Purchase Quotation Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".PurchaseQuotationDetails").find("input, textarea, hidden").serialize(),
            success: function (data, status, xhr) {
                $('.PurchaseQuotationSearchDetials').show();
                $('.PurchaseQuotationAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".PurchaseQuotationSearch");
    $(document).on("click", ".ProductEnquirySearch", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Purchase Quotation Info');
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



