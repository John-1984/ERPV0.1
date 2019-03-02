

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

    $(document).off("click", ".OfficeExpenseCancel");
    $(document).on("click", ".OfficeExpenseCancel", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Office Expense Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.OfficeExpenseSearchDetials').show();
                $('.OfficeExpenseAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

   
    $(document).on('change', '#drpOfficeExpenseTpe', function () {

        // debugger;
        var itemText = $("#drpOfficeExpenseTpe").val();
        $("#hdnOfficeexpensetype").val(itemText);

       
    });
   

   

    $(document).off("click", ".OfficeExpenseView");
    $(document).on("click", ".OfficeExpenseView", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Office Expense Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            success: function (data, status, xhr) {
                $('.OfficeExpenseSearchDetials').hide();
                $('.OfficeExpenseAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".OfficeExpenseEdit, .OfficeExpenseAdd, .OfficeExpenseDetailsAdd");
    $(document).on("click", ".OfficeExpenseEdit, .OfficeExpenseAdd, .OfficeExpenseDetailsAdd", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Office Expense Item Details');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.OfficeExpenseSearchDetials').hide();
               // $('.OfficeExpenseAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".OfficeExpenseDelete");
    $(document).on("click", ".OfficeExpenseDelete", function (event) {
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

    $(document).off("click", ".OfficeExpenseVerification");
    $(document).on("click", ".OfficeExpenseVerification", function (event) {
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

    $(document).off("click", ".OfficeExpenseAddEdit");
    $(document).on("click", ".OfficeExpenseAddEdit", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Office Expense Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".OfficeExpenseDetails").find("input, textarea").serialize(),
            success: function (data, status, xhr) {
                $('.OfficeExpenseSearchDetials').show();
                $('.OfficeExpenseAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".OfficeExpenseSearch");
    $(document).on("click", ".OfficeExpenseSearch", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Office Expense Info');
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



