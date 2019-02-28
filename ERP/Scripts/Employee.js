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
        
        // debugger;
        varregionText = $("#drpEmployeeRegion").val();
        $("#hdnRegion").val(varregionText);
        var drpEmployeeCountry = $("#drpEmployeeCountry");
        
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
        
        // debugger;
        varcountryText = $("#drpEmployeeCountry").val();
        $("#hdnCountry").val(varcountryText);
        var drpEmployeeState = $("#drpEmployeeState");
        
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
        
        // debugger;
       
        varstateText = $("#drpEmployeeState").val();
        $("#hdnState").val(varstateText);
        var drpEmployeedistrict = $("#drpEmployeedistrict");
        
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
        
        // debugger;
        
        vardistrictText = $("#drpEmployeedistrict").val();
        $("#hdnDistrict").val(vardistrictText);
        var drpEmployeelocation = $("#drpEmployeelocation");
        
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
        
        // debugger;
       
        var locationText = $("#drpEmployeelocation").val();
        $("#hdnLocation").val(locationText);
        var drpEmployeecompany = $("#drpEmployeecompany");
        
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
        
        // debugger;
        
        varcompText = $("#drpEmployeecompany").val();
        $("#hdnCompany").val(varcompText);
        var drpEmployeecompanyType = $("#drpEmployeecompanyType");
        
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
        
        // debugger;
        
        varcomptypeText = $("#drpEmployeecompanyType").val();
        $("#hdnCompanyType").val(varcomptypeText);
        var drpEmployeeFloorMaster = $("#drpEmployeeFloorMaster");
        
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
        
        // debugger;
        var FloorMasterText = $("#drpEmployeeFloorMaster").val();
        $("#hdnFloorMaster").val(FloorMasterText);

       
    });

    $(document).on('change', '#drpEmployeeRoleMaster', function () {
        
        // debugger;
        var EmployeeRoleMasterText = $("#drpEmployeeRoleMaster").val();
        $("#hdnRoleMaster").val(EmployeeRoleMasterText);

        
    });

    $(document).on('change', '#drpEmployeeidentificationType', function () {
        
        // debugger;
        var EmployeeidentificationTypeText = $("#drpEmployeeidentificationType").val();
        $("#hdnempidentification").val(EmployeeidentificationTypeText);

        
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



