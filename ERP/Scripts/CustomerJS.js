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

$(document).off("click", ".customerView");
$(document).on("click", ".customerView", function(event){
event.stopImmediatePropagation();
var theUrl = $(this).attr("data-url");
$.ajax({
    url:theUrl,
    type: 'GET',  // http method
    data: { "identity": $(this).attr("data-identity") }, 
    success: function (data, status, xhr) {
        $('.customerSearchDetials').hide();
        $('.customerAdd').hide();
        $('.resultView').html(data);
        showMessage(status, "Success");
    },
    error: function (jqXhr, textStatus, errorMessage) {
         showMessage(textStatus, errorMessage);
    }
});
});

$(document).off("click", ".customerEdit, .customerAdd");
$(document).on("click", ".customerEdit, .customerAdd", function(event){
event.stopImmediatePropagation();
    var theUrl = $(this).attr("data-url");
    $.ajax({
        url:theUrl,
        type: 'GET',  // http method
        data: { "identity": $(this).attr("data-identity") }, 
        success: function (data, status, xhr) {
            $('.customerSearchDetials').hide();
            $('.customerAdd').hide();
            
            $('.resultView').html(data);
            showMessage(status, "Success");
        },
        error: function (jqXhr, textStatus, errorMessage) {
            showMessage(textStatus, errorMessage);
        }
    });
});

$(document).off("click", ".customerDelete");
$(document).on("click", ".customerDelete", function(event){
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

$(document).off("click", ".customerAddEdit");
$(document).on("click", ".customerAddEdit", function(event){
event.stopImmediatePropagation();
var theUrl = $(this).attr("data-url");
$.ajax({
    url:theUrl,
    type: 'POST',  // http method
    data: $(".customerDetails").find("input").serialize(), 
    success: function (data, status, xhr) {
        $('.customerSearchDetials').show();
        $('.customerAdd').show();
        $('.resultView').html(data);
        showMessage(status, "Success");
    },
    error: function (jqXhr, textStatus, errorMessage) {
        showMessage(textStatus, errorMessage);
    }
});
});

$(document).off("click", ".customerSearch");
$(document).on("click", ".customerSearch", function(event){
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



