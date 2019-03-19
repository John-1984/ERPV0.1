

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

    $(document).off("click", ".StockInCancel");
    $(document).on("click", ".StockInCancel", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Stock In Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {
                $('.StockInSearchDetials').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });


    $(document).on('change', '#drpStockInEmployee', function () {
        // debugger;  
       // alert($("#drpStockInEmployee").val());
        var pendASalesEmpText = $("#drpStockInEmployee").val();
        $("#hdnStockInEmployee").val(pendASalesEmpText);
    });

    $(document).on('change', '#drpStockInPaymentType', function () {
        // debugger;  
       // alert($("#drpStockInEmployee").val());
        var pendASalestypeText = $("#drpStockInPaymentType").val();
        $("#hdnStockInPaymentType").val(pendASalestypeText);
    });

    $(document).on('change', '#drpStockInPaymentMode', function () {
        // debugger;  
        // alert($("#drpStockInEmployee").val());
        var pendASalesmodeText = $("#drpStockInPaymentMode").val();
        $("#hdnStockInPaymentMode").val(pendASalesmodeText);
    });

    $(document).on('change', '#drpStockInEmployee', function () {
        // debugger;  
        // alert($("#drpStockInEmployee").val());
        var StockInEmployee = $("#drpStockInEmployee").val();
        $("#hdnStockInEmployee").val(StockInEmployee);
    });


    $(document).on('change', '#drpStockInLocation', function () {
        // debugger;
        varregionText = $("#drpStockInLocation").val();
        $("#hdnStockInLocation").val(varregionText);
        var drpStockInEmployee = $("#drpStockInEmployee");

        $.ajax({
            type: 'POST',
            url: '/StockIn/Employee',
            data: JSON.stringify({ identity: $("#drpStockInLocation").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpStockInEmployee.empty().append('<option selected="selected" value="0">Select Warehouse Supervisor</option>');
                $.each(response, function () {
                    drpStockInEmployee.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpstockinexcessitemid', function () {
        // debugger;  
        // alert($("#drpStockOutEmployee").val());
        var itemValue = $("#drpstockinexcessitemid").val();
        $("#hdnstockinexcessitemid").val(itemValue);
    });

    $(document).off("click", ".StockInExcessAdd");
    $(document).on("click", ".StockInExcessAdd", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Stock In Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".StockInExcessDetails").find("input, textarea, hidden").serialize(),
            //async: true,
            success: function (data, status, xhr) {
                $('.StockInSearchDetials').hide();
                $('.StockInAdd').hide();
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


    $(document).on('change', '#drpStockInDamageditemid', function () {
        // debugger;  
        // alert($("#drpStockOutEmployee").val());
        var itemValue = $("#drpStockInDamageditemid").val();
        $("#hdnStockInDamageditemid").val(itemValue);
    });

    $(document).off("click", ".StockInDamagedAdd");
    $(document).on("click", ".StockInDamagedAdd", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Stock In Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".StockInDamagedDetails").find("input, textarea, hidden").serialize(),
            //async: true,
            success: function (data, status, xhr) {
                $('.StockInSearchDetials').hide();
                $('.StockInAdd').hide();
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


    $(document).on('change', '#drpStockInShortageitemid', function () {
        // debugger;  
        // alert($("#drpStockOutEmployee").val());
        var itemValue = $("#drpStockInShortageitemid").val();
        $("#hdnStockInShortageitemid").val(itemValue);
    });

    $(document).off("click", ".StockInShortageAdd");
    $(document).on("click", ".StockInShortageAdd", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Stock In Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".StockInShortageDetails").find("input, textarea, hidden").serialize(),
            //async: true,
            success: function (data, status, xhr) {
                $('.StockInSearchDetials').hide();
                $('.StockInAdd').hide();
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
    $(document).off("click", ".StockInView");
    $(document).on("click", ".StockInView", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Stock In Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            success: function (data, status, xhr) {
                $('.StockInSearchDetials').hide();
                $('.StockInAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".StockInDetEdit, .StockInDetailsAdd");
    $(document).on("click", ".StockInDetEdit, .StockInDetailsAdd", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Stock In Details');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.StockInSearchDetials').hide();
                // $('.StockInAdd').hide();
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

    $(document).off("click", ".StockInAdd, .StockInCommentsEdit");
    $(document).on("click", ".StockInAdd, .StockInCommentsEdit", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Stock In');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.StockInSearchDetials').hide();
                // $('.StockInAdd').hide();
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

    $(document).off("click", ".StockInDelete");
    $(document).on("click", ".StockInDelete", function (event) {
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

    $(document).off("click", ".StockInItemDelete");
    $(document).on("click", ".StockInItemDelete", function (event) {
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

    $(document).off("click", ".StockInVerification");
    $(document).on("click", ".StockInVerification", function (event) {
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

    $(document).off("click", ".StockInAddEdit");
    $(document).on("click", ".StockInAddEdit", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        alert("updae")
        $('.headermode').html('View Stock In Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".StockInDetails").find("input, textarea, hidden").serialize(),
            success: function (data, status, xhr) {
                $('.StockInSearchDetials').show();
                $('.StockInAdd').show();
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

    $(document).off("click", ".StockInSearch");
    $(document).on("click", ".ProductEnquirySearch", function (event) {
        event.stopImmediatePropagation();
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Stock In Info');
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



