

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

    $(document).off("click", ".PendingStockInCancel");
    $(document).on("click", ".PendingStockInCancel", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Purchase Order Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {
                $('.PendingStockInSearchDetials').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });


    $(document).on('change', '#drpPendingStockInEmployee', function () {
        // debugger;  
       // alert($("#drpPendingStockInEmployee").val());
        var pendASalesEmpText = $("#drpPendingStockInEmployee").val();
        $("#hdnPendingStockInEmployee").val(pendASalesEmpText);
    });

    $(document).on('change', '#drpPendingStockInPaymentType', function () {
        // debugger;  
       // alert($("#drpPendingStockInEmployee").val());
        var pendASalestypeText = $("#drpPendingStockInPaymentType").val();
        $("#hdnPendingStockInPaymentType").val(pendASalestypeText);
    });

    $(document).on('change', '#drpPendingStockInPaymentMode', function () {
        // debugger;  
        // alert($("#drpPendingStockInEmployee").val());
        var pendASalesmodeText = $("#drpPendingStockInPaymentMode").val();
        $("#hdnPendingStockInPaymentMode").val(pendASalesmodeText);
    });

    $(document).on('change', '#drpPendingStockInEmployee', function () {
        // debugger;  
        // alert($("#drpPendingStockInEmployee").val());
        var PendingStockInEmployee = $("#drpPendingStockInEmployee").val();
        $("#hdnPendingStockInEmployee").val(PendingStockInEmployee);
    });


    $(document).on('change', '#drpPendingStockInLocation', function () {
        // debugger;
        varregionText = $("#drpPendingStockInLocation").val();
        $("#hdnPendingStockInLocation").val(varregionText);
        var drpPendingStockInEmployee = $("#drpPendingStockInEmployee");

        $.ajax({
            type: 'POST',
            url: '/PendingStockIn/Employee',
            data: JSON.stringify({ identity: $("#drpPendingStockInLocation").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpPendingStockInEmployee.empty().append('<option selected="selected" value="0">Select Warehouse Supervisor</option>');
                $.each(response, function () {
                    drpPendingStockInEmployee.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });


    $(document).off("click", ".PendingStockInView");
    $(document).on("click", ".PendingStockInView", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Purchase Order Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            success: function (data, status, xhr) {
                $('.PendingStockInSearchDetials').hide();
                $('.PendingStockInAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".PendingStockInDetEdit, .PendingStockInDetailsAdd");
    $(document).on("click", ".PendingStockInDetEdit, .PendingStockInDetailsAdd", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Purchase Order Details');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.PendingStockInSearchDetials').hide();
                // $('.PendingStockInAdd').hide();
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

    $(document).off("click", ".PendingStockInAdd, .PendingStockInCommentsEdit");
    $(document).on("click", ".PendingStockInAdd, .PendingStockInCommentsEdit", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Purchase Order');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.PendingStockInSearchDetials').hide();
                // $('.PendingStockInAdd').hide();
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

    $(document).off("click", ".PendingStockInDelete");
    $(document).on("click", ".PendingStockInDelete", function (event) {
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

    $(document).off("click", ".PendingStockInItemDelete");
    $(document).on("click", ".PendingStockInItemDelete", function (event) {
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

    $(document).off("click", ".PendingStockInVerification");
    $(document).on("click", ".PendingStockInVerification", function (event) {
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

    $(document).off("click", ".PendingStockInAddEdit");
    $(document).on("click", ".PendingStockInAddEdit", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        alert("updae")
        $('.headermode').html('View Purchase Order Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".PendingStockInDetails").find("input, textarea, hidden").serialize(),
            success: function (data, status, xhr) {
                $('.PendingStockInSearchDetials').show();
                $('.PendingStockInAdd').show();
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

    $(document).off("click", ".PendingStockInSearch");
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



