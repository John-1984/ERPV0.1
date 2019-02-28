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


    $(document).off("click", ".LocalSupplierView");
    $(document).on("click", ".LocalSupplierView", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Local Supplier Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            success: function (data, status, xhr) {
                $('.LocalSupplierSearchDetials').hide();
                $('.LocalSupplierAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".LocalSupplierEdit, .LocalSupplierAdd");
    $(document).on("click", ".LocalSupplierEdit, .LocalSupplierAdd", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Local Supplier Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.LocalSupplierSearchDetials').hide();
                $('.LocalSupplierAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".LocalSupplierDelete");
    $(document).on("click", ".LocalSupplierDelete", function (event) {
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

    $(document).on('change', '#drpLocalSupplierRegion', function () {
        
        // debugger;
        varLocalSupplierregionText = $("#drpLocalSupplierRegion").val();
        $("#hdnRegion").val(varLocalSupplierregionText);
        var drpLocalSupplierCountry = $("#drpLocalSupplierCountry");
        
        $.ajax({
            type: 'POST',
            url: '/LocalSupplier/Country',
            data: JSON.stringify({ identity: $("#drpLocalSupplierRegion").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpLocalSupplierCountry.empty().append('<option selected="selected" value="0">Select Country</option>');
                $.each(response, function () {
                    drpLocalSupplierCountry.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpLocalSupplierCountry', function () {
        
        // debugger;
        varLocalSuppliercountryText = $("#drpLocalSupplierCountry").val();
        $("#hdnCountry").val(varLocalSuppliercountryText);
        var drpLocalSupplierState = $("#drpLocalSupplierState");
        
        $.ajax({
            type: 'POST',
            url: '/LocalSupplier/State',
            data: JSON.stringify({ identity: $("#drpLocalSupplierCountry").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpLocalSupplierState.empty().append('<option selected="selected" value="0">Select State</option>');
                $.each(response, function () {
                    drpLocalSupplierState.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpLocalSupplierState', function () {
        
        // debugger;
        
        varLocalSupplierstateText = $("#drpLocalSupplierState").val();
        $("#hdnState").val(varLocalSupplierstateText);
        var drpLocalSupplierdistrict = $("#drpLocalSupplierdistrict");
        
        $.ajax({
            type: 'POST',
            url: '/LocalSupplier/District',
            data: JSON.stringify({ identity: $("#drpLocalSupplierState").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpLocalSupplierdistrict.empty().append('<option selected="selected" value="0">Select District</option>');
                $.each(response, function () {
                    drpLocalSupplierdistrict.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpLocalSupplierdistrict', function () {
        
        // debugger;
      
        varLocalSupplierdistrictText = $("#drpLocalSupplierdistrict").val();
        $("#hdnDistrict").val(varLocalSupplierdistrictText);
        var drpLocalSupplierlocation = $("#drpLocalSupplierlocation");
        
        $.ajax({
            type: 'POST',
            url: '/LocalSupplier/Location',
            data: JSON.stringify({ identity: $("#drpLocalSupplierdistrict").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpLocalSupplierlocation.empty().append('<option selected="selected" value="0">Select Location</option>');
                $.each(response, function () {
                    drpLocalSupplierlocation.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });


    $(document).on('change', '#drpLocalSupplierlocation', function () {
        
        // debugger;
        varLocalSupplierlocText = $("#drpLocalSupplierlocation").val();
        $("#hdnLocation").val(varLocalSupplierlocText);

       
    });


    $(document).on('change', '#drpLocalSupplierItemMaster', function () {
        
        // debugger;
        varLocalSupplieritemText = $("#drpLocalSupplierItemMaster").val();
        $("#hdnItemMaster").val(varLocalSupplieritemText);

       
    });

    $(document).off("click", ".LocalSupplierCancel");
    $(document).on("click", ".LocalSupplierCancel", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Local Supplier Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.LocalSupplierSearchDetials').show();
                $('.LocalSupplierAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".LocalSupplierAddEdit");
    $(document).on("click", ".LocalSupplierAddEdit", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Local Supplier Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".LocalSupplierDetails").find("input").serialize(),
            success: function (data, status, xhr) {
                $('.LocalSupplierSearchDetials').show();
                $('.LocalSupplierAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".LocalSupplierSearch");
    $(document).on("click", ".LocalSupplierSearch", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Local Supplier Info');
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



