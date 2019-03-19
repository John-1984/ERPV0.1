

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

    $(document).off("click", ".SalesQuotationCancel");
    $(document).on("click", ".SalesQuotationCancel", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Sales Quotation Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {
                $('.SalesQuotationSearchDetials').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });


    $(document).on('change', '#drpSalesQuotationEmployee', function () {
        // debugger;  
       // alert($("#drpSalesQuotationEmployee").val());
        var pendASalesEmpText = $("#drpSalesQuotationEmployee").val();
        $("#hdnSalesQuotationEmployee").val(pendASalesEmpText);
    });

    $(document).on('change', '#drpSalesQuotationPaymentType', function () {
        // debugger;  
       // alert($("#drpSalesQuotationEmployee").val());
        var pendASalestypeText = $("#drpSalesQuotationPaymentType").val();
        $("#hdnSalesQuotationPaymentType").val(pendASalestypeText);
    });

    $(document).on('change', '#drpSalesQuotationPaymentMode', function () {
        // debugger;  
        // alert($("#drpSalesQuotationEmployee").val());
        var pendASalesmodeText = $("#drpSalesQuotationPaymentMode").val();
        $("#hdnSalesQuotationPaymentMode").val(pendASalesmodeText);
    });

    $(document).off("click", ".SalesQuotationView");
    $(document).on("click", ".SalesQuotationView", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Sales Quotation Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            success: function (data, status, xhr) {
                $('.SalesQuotationSearchDetials').hide();
                $('.SalesQuotationAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".SalesQuotationDetEdit, .SalesQuotationDetailsAdd");
    $(document).on("click", ".SalesQuotationDetEdit, .SalesQuotationDetailsAdd", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Sales Quotation Details');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.SalesQuotationSearchDetials').hide();
                // $('.SalesQuotationAdd').hide();
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

    $(document).off("click", ".SalesQuotationAdd, .SalesQuotationCommentsEdit");
    $(document).on("click", ".SalesQuotationAdd, .SalesQuotationCommentsEdit", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Sales Quotation');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.SalesQuotationSearchDetials').hide();
                // $('.SalesQuotationAdd').hide();
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

    $(document).off("click", ".SalesQuotationDelete");
    $(document).on("click", ".SalesQuotationDelete", function (event) {
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

    $(document).off("click", ".SalesQuotationItemDelete");
    $(document).on("click", ".SalesQuotationItemDelete", function (event) {
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

    $(document).off("click", ".SalesQuotationVerification");
    $(document).on("click", ".SalesQuotationVerification", function (event) {
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

    $(document).off("click", ".SalesQuotationAddEdit");
    $(document).on("click", ".SalesQuotationAddEdit", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        alert("updae")
        $('.headermode').html('View Sales Quotation Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".SalesQuotationDetails").find("input, textarea, hidden").serialize(),
            success: function (data, status, xhr) {
                $('.SalesQuotationSearchDetials').show();
                $('.SalesQuotationAdd').show();
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

    $(document).off("click", ".SalesQuotationSearch");
    $(document).on("click", ".ProductEnquirySearch", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Sales Quotation Info');
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



