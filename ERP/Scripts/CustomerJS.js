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
};

$('#datepicker').datepicker({
    uiLibrary: 'bootstrap4'
});

$(document).off("click", ".CustomerView");
$(document).on("click", ".CustomerView", function(event){
    event.stopImmediatePropagation();
    $('.headermode').html('View Customer Info');
var theUrl = $(this).attr("data-url");
$.ajax({
    url:theUrl,
    type: 'GET',  // http method
    data: { "identity": $(this).attr("data-identity") }, 
    success: function (data, status, xhr) {

        $('.CustomerSearchDetials').hide();
      
        $('.resultView').html(data);
        showMessage(status, "Success");
    },
    error: function (jqXhr, textStatus, errorMessage) {
         showMessage(textStatus, errorMessage);
    }
});
});

$(document).off("click", ".CustomerEdit, .CustomerAdd");
$(document).on("click", ".CustomerEdit, .CustomerAdd", function(event){
event.stopImmediatePropagation();
   
    var theUrl = $(this).attr("data-url");
    $('.headermode').html('Manage Customer Info');
    $.ajax({
        url:theUrl,
        type: 'GET',  // http method
        data: { "identity": $(this).attr("data-identity") }, 
        success: function (data, status, xhr) {
            $('.CustomerSearchDetials').hide();
            //$('.CustomerAdd').hide();
            
            $('.resultView').html(data);
            showMessage(status, "Success");
        },
        error: function (jqXhr, textStatus, errorMessage) {
            showMessage(textStatus, errorMessage);
        }
    });
});

$(document).off("click", ".CustomerDelete");
$(document).on("click", ".CustomerDelete", function(event){
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

    $(document).on('change', '#drpcustomerEmp', function () {
        
        // debugger;
        var empText = $("#drpcustomerEmp").val();
        $("#hdnemployee").val(empText);
    });

    $(document).on('change', '#drpcustomerEnquirylvl', function () {

        // debugger;
        var eqText = $("#drpcustomerEnquirylvl").val();
        $("#hdncustenquirylevel").val(eqText);
    });


    $(document).on('change', '#drpcustomerpurpose', function () {
        
        // debugger;
        var emp1Text = $("#drpcustomerpurpose").val();
        $("#hdncuspupose").val(emp1Text);
    });


    $(document).on('change', '#drpcustomerstatus', function () {
        
        // debugger;
        var emp3Text = $("#drpcustomerstatus").val();
        $("#hdncuststatus").val(emp3Text);
    });

$(document).off("click", ".CustomerAddEdit");
$(document).on("click", ".CustomerAddEdit", function(event){
event.stopImmediatePropagation();
    var theUrl = $(this).attr("data-url");
    $('.headermode').html('View Customer Info');
$.ajax({
    url:theUrl,
    type: 'POST',  // http method
    data: $(".CustomerDetails").find("input, textarea").serialize(), 
    success: function (data, status, xhr) {

        $('.CustomerSearchDetials').show();
    
        $('.resultView').html(data);
        showMessage(status, "Success");
    },
    error: function (jqXhr, textStatus, errorMessage) {
        showMessage(textStatus, errorMessage);
    }
});
});

$(document).off("click", ".CustomerSearch");
$(document).on("click", ".CustomerSearch", function(event){
    event.stopImmediatePropagation();
    $('.headermode').html('View Customer Info');
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
    $(document).off("click", ".CustomerCancel");
    $(document).on("click", ".CustomerCancel", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Customer Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {

                $('.CustomerSearchDetials').show();
                $('.CustomerAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });
$("#customerName").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: '/Customer/AutoComplete/',
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



