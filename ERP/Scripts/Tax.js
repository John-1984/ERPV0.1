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

    $(document).on('change', '#drpTaxItemMaster', function () {
        
        // debugger;
        varTaxItemText = $("#drpTaxItemMaster").val();
        $("#hdnItemMaster").val(varTaxItemText);

       
    });


    $(document).off("click", ".TaxCancel");
    $(document).on("click", ".TaxCancel", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Tax Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.TaxDetials').show();
                $('.TaxAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });
    $(document).off("click", ".TaxView");
    $(document).on("click", ".TaxView", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Tax Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            success: function (data, status, xhr) {
                $('.TaxSearchDetials').hide();
                $('.TaxAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".TaxEdit, .TaxAdd");
    $(document).on("click", ".TaxEdit, .TaxAdd", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Tax Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.TaxSearchDetials').hide();
                $('.TaxAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".TaxDelete");
    $(document).on("click", ".TaxDelete", function (event) {
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

    $(document).off("click", ".TaxAddEdit");
    $(document).on("click", ".TaxAddEdit", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Tax Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".TaxDetails").find("input").serialize(),
            success: function (data, status, xhr) {
                $('.TaxSearchDetials').show();
                $('.TaxAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".TaxSearch");
    $(document).on("click", ".TaxSearch", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Tax Info');
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



