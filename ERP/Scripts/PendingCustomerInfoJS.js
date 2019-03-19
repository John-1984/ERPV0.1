$(document).ready(function(){

//Common Message Handling functions. Need to be separated.
var showMessage = function(status, message){
    if(status == "success"){
        $.growl.notice({ message: message });
    }else if(status == "fail"){
        $.growl.error({ message: message });
    }else if(status == "warning"){
        $.growl.warning({ message: message });
    }else if(status == "notice"){
        $.growl({ title: "Notice", message: message });
    }
    else if (status == "ModelError") {
        $.growl.error({ message: message });
    }
};

$('#datepicker').datepicker({
    uiLibrary: 'bootstrap4'
});

$(document).off("click", ".PendingCustomerInfoView");
$(document).on("click", ".PendingCustomerInfoView", function(event){
    event.stopImmediatePropagation();
    $('.headermode').html('View Pending Customer Info');
var theUrl = $(this).attr("data-url");
$.ajax({
    url:theUrl,
    type: 'GET',  // http method
    data: { "identity": $(this).attr("data-identity") }, 
    success: function (data, status, xhr) {

        $('.PendingCustomerInfoSearchDetials').hide();
      
        $('.resultView').html(data);
        showMessage(status, "Success");
    },
    error: function (jqXhr, textStatus, errorMessage) {
         showMessage(textStatus, errorMessage);
    }
});
});

$(document).off("click", ".PendingCustomerInfoEdit, .PendingCustomerInfoAdd");
$(document).on("click", ".PendingCustomerInfoEdit, .PendingCustomerInfoAdd", function(event){
event.stopImmediatePropagation();
   
    var theUrl = $(this).attr("data-url");
    $('.headermode').html('Manage Customer Info');
    $.ajax({
        url:theUrl,
        type: 'GET',  // http method
        data: { "identity": $(this).attr("data-identity") }, 
        success: function (data, status, xhr) {
            $('.PendingCustomerInfoSearchDetials').hide();
            //$('.PendingCustomerInfoAdd').hide();
            
            $('.resultView').html(data);
            showMessage(status, "Success");
        },
        error: function (jqXhr, textStatus, errorMessage) {
            showMessage(textStatus, errorMessage);
        }
    });
});

$(document).off("click", ".PendingCustomerInfoDelete");
$(document).on("click", ".PendingCustomerInfoDelete", function(event){
event.stopImmediatePropagation();
    if (!confirm("Do you want to delete")){
          return false;
        }else  {
        var theUrl = $(this).attr("data-url");
        $.ajax({
            url:theUrl,
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

    $(document).on('change', '#drpPendingCustomerInfoEmp', function () {
        
        // debugger;
        var empText = $("#drpPendingCustomerInfoEmp").val();
        $("#hdnemployee").val(empText);
    });

    $(document).on('change', '#drpPendingCustomerInfoEnquirylvl', function () {

        // debugger;
        var eqText = $("#drpPendingCustomerInfoEnquirylvl").val();
        $("#hdncustenquirylevel").val(eqText);
    });


    $(document).on('change', '#drpPendingCustomerInfopurpose', function () {
        
        // debugger;
        var emp1Text = $("#drpPendingCustomerInfopurpose").val();
        $("#hdncuspupose").val(emp1Text);
    });


    $(document).on('change', '#drpPendingCustomerInfostatus', function () {
        
        // debugger;
        var emp3Text = $("#drpPendingCustomerInfostatus").val();
        $("#hdncuststatus").val(emp3Text);
    });

$(document).off("click", ".PendingCustomerInfoAddEdit");
$(document).on("click", ".PendingCustomerInfoAddEdit", function(event){
event.stopImmediatePropagation();
    var theUrl = $(this).attr("data-url");
    $('.headermode').html('View Pending Customer Info');
$.ajax({
    url:theUrl,
    type: 'POST',  // http method
    data: $(".PendingCustomerInfoDetails").find("input, textarea").serialize(), 
    success: function (data, status, xhr) {

        $('.PendingCustomerInfoSearchDetials').show();
    
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

$(document).off("click", ".PendingCustomerInfoSearch");
$(document).on("click", ".PendingCustomerInfoSearch", function(event){
    event.stopImmediatePropagation();
    $('.headermode').html('View Pending Customer Info');
var theUrl = $(this).attr("data-url");
$.ajax({
    url:theUrl,
    type: 'POST',  // http method
    data: { "searchString": $(".searchText").val(), "createdDate": $("#datepicker").val() }, 
    success: function (data, status, xhr) {
        $('.resultView').html(data);
        showMessage(status, "Success");
    },
    error: function (jqXhr, textStatus, errorMessage) {
        showMessage(textStatus, errorMessage);
    }
});
});
    $(document).off("click", ".PendingCustomerInfoCancel");
    $(document).on("click", ".PendingCustomerInfoCancel", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Pending Customer Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.PendingCustomerInfoSearchDetials').show();
                $('.PendingCustomerInfoAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });
$("#PendingCustomerInfoName").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: '/PendingCustomerInfo/AutoComplete/',
                    data: "{ 'prefix': '" + request.term + "'}",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        response($.map(data, function (item) {
                            return {
                                label: item.CustomerName,
                                value: item.CustomerName,
                                identity: item.Identity
                            };
                        }))
                    },
                    error: function (response) {
                        alert(response.responseText);
                    },
                    failure: function (response) {
                        alert(response.responseText);
                    }
                });
            },
            select: function (e, i) {
                $("#customerID").val(i.item.identity);
            },
            minLength: 1,
            cache: false
        });
});



