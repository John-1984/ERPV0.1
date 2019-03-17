﻿$(document).ready(function () {

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


    $(document).off("click", ".RegionView");
    $(document).on("click", ".RegionView", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Region Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            success: function (data, status, xhr) {
                $('.RegionSearchDetials').hide();
                $('.RegionAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".RegionEdit, .RegionAdd");
    $(document).on("click", ".RegionEdit, .RegionAdd", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('Manage Region Info');
        $.ajax({
            url: theUrl,
            type: 'GET',  // http method
            data: { "identity": $(this).attr("data-identity") },
            //async: true,
            success: function (data, status, xhr) {
               
                $('.RegionSearchDetials').hide();
                $('.RegionAdd').hide();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).off("click", ".RegionDelete");
    $(document).on("click", ".RegionDelete", function (event) {
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

    $(document).off("click", ".RegionAddEdit");
    $(document).on("click", ".RegionAddEdit", function (event) {
        var theUrl = $(this).attr("data-url");
        $('.headermode').html('View Region Info');
        $.ajax({
            url: theUrl,
            type: 'POST',  // http method
            data: $(".RegionDetails").find("input").serialize(),
            success: function (data, status, xhr) {
                $('.RegionSearchDetials').show();
                $('.RegionAdd').show();
                $('.resultView').html(data);
                showMessage(status, "Success");
            },
            error: function (jqXhr, textStatus, errorMessage) {
                showMessage(textStatus, errorMessage);
            }
        });
    });

    $(document).find("#RegionName").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Region/AutoComplete/',
                data: "{ 'prefix': '" + request.term + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: item.RegionName,
                            value: item.RegionName,
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
            $("#RegionID").val(i.item.identity);
        },
        minLength: 1,
        cache: false
    });

    $(document).off("click", ".RegionSearch");
    $(document).on("click", ".RegionSearch", function (event) {
        event.stopImmediatePropagation();
        $('.headermode').html('View Region Info');
        var theUrl = $(this).attr("data-url");
        $.ajax({
            url: theUrl,
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



