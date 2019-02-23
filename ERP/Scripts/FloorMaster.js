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
    $(document).on('change', '#drpFloorRegion', function () {
        //alert("Test");
        // debugger;
        varregionText = $("#drpFloorRegion").val();
        $("#hdnRegion").val(varregionText);
        var drpFloorCountry = $("#drpFloorCountry");
        // alert("Test");
        $.ajax({
            type: 'POST',
            url: '/FloorMaster/Country',
            data: JSON.stringify({ identity: $("#drpFloorRegion").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpFloorCountry.empty().append('<option selected="selected" value="0">Select Country</option>');
                $.each(response, function () {
                    drpFloorCountry.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpFloorCountry', function () {
        //alert("Test");
        // debugger;
        varcountryText = $("#drpFloorCountry").val();
        $("#hdnCountry").val(varcountryText);
        var drpFloorState = $("#drpFloorState");
        //alert("Test");
        $.ajax({
            type: 'POST',
            url: '/FloorMaster/State',
            data: JSON.stringify({ identity: $("#drpFloorCountry").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpFloorState.empty().append('<option selected="selected" value="0">Select State</option>');
                $.each(response, function () {
                    drpFloorState.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpFloorState', function () {
        //alert("Test");
        // debugger;
        alert("Test");
        varstateText = $("#drpFloorState").val();
        $("#hdnState").val(varstateText);
        var drpFloordistrict = $("#drpFloordistrict");
        //alert("Test");
        $.ajax({
            type: 'POST',
            url: '/FloorMaster/District',
            data: JSON.stringify({ identity: $("#drpFloorState").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpFloordistrict.empty().append('<option selected="selected" value="0">Select District</option>');
                $.each(response, function () {
                    drpFloordistrict.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpFloordistrict', function () {
        //alert("Test");
        // debugger;
        //alert("Test");
        vardistrictText = $("#drpFloordistrict").val();
        $("#hdnDistrict").val(vardistrictText);
        var drpfloorlocation = $("#drpfloorlocation");
        //alert("Test");
        $.ajax({
            type: 'POST',
            url: '/FloorMaster/Location',
            data: JSON.stringify({ identity: $("#drpFloordistrict").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpfloorlocation.empty().append('<option selected="selected" value="0">Select Location</option>');
                $.each(response, function () {
                    drpfloorlocation.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpfloorlocation', function () {
        //alert("Test");
        // debugger;
        alert("Test");
        varlocationText = $("#drpfloorlocation").val();
        $("#hdnLocation").val(varlocationText);
        var drpfloorcompany = $("#drpfloorcompany");
        //alert("Test");
        $.ajax({
            type: 'POST',
            url: '/FloorMaster/Company',
            data: JSON.stringify({ identity: $("#drpfloorlocation").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpfloorcompany.empty().append('<option selected="selected" value="0">Select District</option>');
                $.each(response, function () {
                    drpfloorcompany.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpfloorcompany', function () {
        //alert("Test");
        // debugger;
        alert("Test");
        varcompText = $("#drpfloorcompany").val();
        $("#hdnCompany").val(varcompText);
        var drpfloorcompanyType = $("#drpfloorcompanyType");
        //alert("Test");
        $.ajax({
            type: 'POST',
            url: '/FloorMaster/CompanyType',
            data: JSON.stringify({ identity: $("#drpfloorcompany").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpfloorcompanyType.empty().append('<option selected="selected" value="0">Select Company Type</option>');
                $.each(response, function () {
                    drpfloorcompanyType.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });
    $(document).on('change', '#drpfloorcompanytype', function () {
        //alert("Test");
        // debugger;
        varcompanyTypeText = $("#drpfloorcompanytype").val();
        $("#hdnCompanyType").val(varcompanyTypeText);

       // alert(vardistrictText);
    });

    $(document).off("click", ".FloorMasterCancel");
    $(document).on("click", ".FloorMasterCancel", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Floor Master Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.FloorMasterSearchDetials').show();
                $('.FloorMasterAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".FloorMasterView");
    $(document).on("click", ".FloorMasterView", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Floor Master Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            success: function (data, status, xhr) {
                $('.FloorMasterSearchDetials').hide();
                $('.FloorMasterAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".FloorMasterEdit, .FloorMasterAdd");
    $(document).on("click", ".FloorMasterEdit, .FloorMasterAdd", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Floo rMaster Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.FloorMasterSearchDetials').hide();
                $('.FloorMasterAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".FloorMasterDelete");
    $(document).on("click", ".FloorMasterDelete", function (event) {
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

    $(document).off("click", ".FloorMasterAddEdit");
    $(document).on("click", ".FloorMasterAddEdit", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Floor Master Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".FloorMasterDetails").find("input").serialize(),
            success: function (data, status, xhr) {
                $('.FloorMasterSearchDetials').show();
                $('.FloorMasterAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".FloorMasterSearch");
    $(document).on("click", ".FloorMasterSearch", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Floor Master Info');
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



