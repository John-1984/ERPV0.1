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

    $(document).on('change', '#drpEmployeeRegion', function () {
        //alert("Test");
        // debugger;
        varregionText = $("#drpEmployeeRegion").val();
        $("#hdnRegion").val(varregionText);
        var drpEmployeeCountry = $("#drpEmployeeCountry");
        // alert("Test");
        $.ajax({
            type: 'POST',
            url: '/Employee/Country',
            data: JSON.stringify({ identity: $("#drpEmployeeRegion").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpEmployeeCountry.empty().append('<option selected="selected" value="0">Select Country</option>');
                $.each(response, function () {
                    drpEmployeeCountry.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpEmployeeCountry', function () {
        //alert("Test");
        // debugger;
        varcountryText = $("#drpEmployeeCountry").val();
        $("#hdnCountry").val(varcountryText);
        var drpEmployeeState = $("#drpEmployeeState");
        //alert("Test");
        $.ajax({
            type: 'POST',
            url: '/Employee/State',
            data: JSON.stringify({ identity: $("#drpEmployeeCountry").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpEmployeeState.empty().append('<option selected="selected" value="0">Select State</option>');
                $.each(response, function () {
                    drpEmployeeState.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpEmployeeState', function () {
        //alert("Test");
        // debugger;
        alert("Test");
        varstateText = $("#drpEmployeeState").val();
        $("#hdnState").val(varstateText);
        var drpEmployeedistrict = $("#drpEmployeedistrict");
        //alert("Test");
        $.ajax({
            type: 'POST',
            url: '/Employee/District',
            data: JSON.stringify({ identity: $("#drpEmployeeState").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpEmployeedistrict.empty().append('<option selected="selected" value="0">Select District</option>');
                $.each(response, function () {
                    drpEmployeedistrict.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpEmployeedistrict', function () {
        //alert("Test");
        // debugger;
        //alert("Test");
        vardistrictText = $("#drpEmployeedistrict").val();
        $("#hdnDistrict").val(vardistrictText);
        var drpEmployeelocation = $("#drpEmployeelocation");
        //alert("Test");
        $.ajax({
            type: 'POST',
            url: '/Employee/Location',
            data: JSON.stringify({ identity: $("#drpEmployeedistrict").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpEmployeelocation.empty().append('<option selected="selected" value="0">Select Location</option>');
                $.each(response, function () {
                    drpEmployeelocation.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpEmployeelocation', function () {
        //alert("Test");
        // debugger;
        alert("Test");
        varlocationText = $("#drpEmployeelocation").val();
        $("#hdnLocation").val(varlocationText);
        var drpEmployeecompany = $("#drpEmployeecompany");
        //alert("Test");
        $.ajax({
            type: 'POST',
            url: '/Employee/Company',
            data: JSON.stringify({ identity: $("#drpEmployeelocation").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpEmployeecompany.empty().append('<option selected="selected" value="0">Select Company</option>');
                $.each(response, function () {
                    drpEmployeecompany.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpEmployeecompany', function () {
        //alert("Test");
        // debugger;
        //alert("Test");
        varcompText = $("#drpEmployeecompany").val();
        $("#hdnCompany").val(varcompText);
        var drpEmployeecompanyType = $("#drpEmployeecompanyType");
        //alert("Test");
        $.ajax({
            type: 'POST',
            url: '/Employee/CompanyType',
            data: JSON.stringify({ identity: $("#drpEmployeecompany").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpEmployeecompanyType.empty().append('<option selected="selected" value="0">Select Company Type</option>');
                $.each(response, function () {
                    drpEmployeecompanyType.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpEmployeecompanyType', function () {
        //alert("Test");
        // debugger;
        //alert("Test");
        varcomptypeText = $("#drpEmployeecompanyType").val();
        $("#hdnCompanyType").val(varcomptypeText);
        var drpEmployeeFloorMaster = $("#drpEmployeeFloorMaster");
        //alert("Test");
        $.ajax({
            type: 'POST',
            url: '/Employee/FloorMaster',
            data: JSON.stringify({ identity: $("#drpEmployeecompanyType").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpEmployeeFloorMaster.empty().append('<option selected="selected" value="0">Select Floor</option>');
                $.each(response, function () {
                    drpEmployeeFloorMaster.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

    $(document).on('change', '#drpEmployeeFloorMaster', function () {
        //alert("Test");
        // debugger;
        varFloorMasterText = $("#drpEmployeeFloorMaster").val();
        $("#hdnFloorMaster").val(varFloorMasterText);

        // alert(vardistrictText);
    });

    $(document).on('change', '#drpEmployeeRoleMaster', function () {
        //alert("Test");
        // debugger;
        varEmployeeRoleMasterText = $("#drpEmployeeRoleMaster").val();
        $("#hdnRoleMaster").val(varEmployeeRoleMasterText);

        // alert(vardistrictText);
    });

    $(document).on('change', '#drpEmployeeidentificationType', function () {
        //alert("Test");
        // debugger;
        varEmployeeidentificationTypeText = $("#drpEmployeeidentificationType").val();
        $("#hdnidentification").val(varEmployeeidentificationTypeText);

        // alert(vardistrictText);
    });

    $(document).off("click", ".EmployeeCancel");
    $(document).on("click", ".EmployeeCancel", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Employee Master Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.EmployeeSearchDetials').show();
                $('.EmployeeAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });


    $(document).off("click", ".EmployeeView");
    $(document).on("click", ".EmployeeView", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Employee Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            success: function (data, status, xhr) {
                $('.EmployeeSearchDetials').hide();
                $('.EmployeeAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".EmployeeEdit, .EmployeeAdd");
    $(document).on("click", ".EmployeeEdit, .EmployeeAdd", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Employee Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.EmployeeSearchDetials').hide();
                $('.EmployeeAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".EmployeeDelete");
    $(document).on("click", ".EmployeeDelete", function (event) {
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

    $(document).off("click", ".EmployeeAddEdit");
    $(document).on("click", ".EmployeeAddEdit", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Employee Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".EmployeeDetails").find("input").serialize(),
            success: function (data, status, xhr) {
                $('.EmployeeSearchDetials').show();
                $('.EmployeeAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".EmployeeSearch");
    $(document).on("click", ".EmployeeSearch", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Employee Info');
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



