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

$(document).off("click", ".EmployeeView");
$(document).on("click", ".EmployeeView", function(event){
event.stopImmediatePropagation();
var theUrl = $(this).attr("data-url");
$.ajax({
    url:theUrl,
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
$(document).on("click", ".EmployeeEdit, .EmployeeAdd", function(event){
event.stopImmediatePropagation();
    var theUrl = $(this).attr("data-url");
    $.ajax({
        url:theUrl,
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

$(document).off("click", ".EmployeeDelete");
$(document).on("click", ".EmployeeDelete", function(event){
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

$(document).off("click", ".EmployeeAddEdit");
$(document).on("click", ".EmployeeAddEdit", function(event){
event.stopImmediatePropagation();
var theUrl = $(this).attr("data-url");
$.ajax({
    url:theUrl,
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
$(document).on("click", ".EmployeeSearch", function(event){
event.stopImmediatePropagation();
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

});



