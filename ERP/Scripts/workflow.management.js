
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

    $(document).on('change', '#drpWorkFlowItemType', function () {

        // debugger;
        var itemTypeText = $("#drpWorkFlowItemType").val();
        $("#hdnWorkFlowItemType").val(itemTypeText);
    });

    $(document).on('change', '#drpWorkFlowLocation', function () {

        // debugger;
        var workdlocypeText = $("#drpWorkFlowLocation").val();
        $("#hdnWorkFlowLocation").val(workdlocypeText);
    });

    $(document).on('change', '#drpWorkFlowStepEmployee', function () {
        // debugger;
        var itemTypeText = $("#drpWorkFlowStepEmployee").val();
        $("#hdnWorkFlowStepEmployee").val(itemTypeText);
    });

    $(document).on('change', '#drpWorkFlowStepLocation', function () {

        // debugger;
        var locTypeText = $("#drpWorkFlowStepLocation").val();
        $("#hdnWorkFlowStepLocation").val(locTypeText);
        var drpWorkFlowStepEmployee = $("#drpWorkFlowStepEmployee");
        $.ajax({
            type: 'POST',
            url: '/WorkflowManager/Employee',
            data: JSON.stringify({ identity: $("#drpWorkFlowStepLocation").val() }),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                drpWorkFlowStepEmployee.empty().append('<option selected="selected" value="0">Select Employee</option>');
                $.each(response, function () {
                    drpWorkFlowStepEmployee.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            },
            error: function (response) {
                showMessage(response.responseText);
            }
        });
    });

$(document).off("click", ".addWorkflow");
$(document).on("click", ".addWorkflow", function(event){
event.stopImmediatePropagation();
    var theUrl = $(this).attr("data-url");
    $.ajax({
        url:theUrl,
        type: 'POST',  // http method
        data: $(".workflowDetails").find("input, textarea").serialize(), 
        success: function (data, status, xhr) {
            $('.resultView').html(data);
            showMessage(status, "Success");
        },
        error: function (jqXhr, textStatus, errorMessage) {
            showMessage(textStatus, errorMessage);
        }
    });
});

$(document).off("click", ".deleteWorkflow");
$(document).on("click", ".deleteWorkflow", function(event){
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

$(document).off("click", ".addeditStep");
$(document).on("click", ".addeditStep", function(event){
event.stopImmediatePropagation();
    var theUrl = $(this).attr("data-url");
    $.ajax({
        url:theUrl,
        type: 'POST',  // http method
        data: $(".stepDetails").find("input, textarea").serialize(), 
        success: function (data, status, xhr) {
            $('.resultView').html(data);
            showMessage(status, "Success");
        },
        error: function (jqXhr, textStatus, errorMessage) {
            showMessage(textStatus, errorMessage);
        }
    });
});

$(document).off("click", ".deleteStep");
$(document).on("click", ".deleteStep", function(event){
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

$(document).off("click", ".editStep");
$(document).on("click", ".editStep", function(event){
event.stopImmediatePropagation();
    var theUrl = $(this).attr("data-url");
    $.ajax({
        url:theUrl,
        type: 'GET',  // http method
        data: { "identity": $(this).attr("data-identity") },
        success: function (data, status, xhr) {
            $('.stepDetailsView').html(data);
            showMessage(status, "Success");
        },
        error: function (jqXhr, textStatus, errorMessage) {
             showMessage(textStatus, errorMessage);
        }
    });
});

$(document).off("click", ".associateWorkflow");
$(document).on("click", ".associateWorkflow", function(event){
event.stopImmediatePropagation();
    var theUrl = $(this).attr("data-url");
    $.ajax({
        url:theUrl,
        type: 'GET',  // http method
        data: { "workflowID": $("#WorkflowID").val() },
        success: function (data, status, xhr) {
            $('.resultView').html(data);
            showMessage(status, "Success");
        },
        error: function (jqXhr, textStatus, errorMessage) {
            showMessage(textStatus, errorMessage);
        }
    });
});

$(document).off("click", ".associateStep");
$(document).on("click", ".associateStep", function(event){
event.stopImmediatePropagation();
    var theUrl = $(this).attr("data-url");
    $.ajax({
        url:theUrl,
        type: 'POST',  // http method
        data: { "workflowID": $("#WorkflowID").val(), "stepID": $("#StepID").val() },
        success: function (data, status, xhr) {
            $('.resultView').html(data);
            showMessage(status, "Success");
        },
        error: function (jqXhr, textStatus, errorMessage) {
            showMessage(textStatus, errorMessage);
        }
    });
});

$(document).off("click", ".deleteAssociatedWorkflowStep");
$(document).on("click", ".deleteAssociatedWorkflowStep", function(event){
event.stopImmediatePropagation();
    if (!confirm("Do you want to delete")){
          return false;
        }else  {
        var theUrl = $(this).attr("data-url");
        $.ajax({
            url:theUrl,
            type: 'POST',  // http method
            data: { "stepID": $(this).attr("data-identity"), "workflowID": $("#WorkflowID").val()},
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

$(document).find("#WorkflowName").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/WorkflowManager/WorkflowAutoComplete/',
                data: "{ 'prefix': '" + request.term + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: item.Name,
                            value: item.Name,
                            identity: item.Identity,
                            description: item.Description    
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
            $("#WorkflowID").val(i.item.identity);
            $("#WorkflowDescription").text(i.item.description);
        },
        minLength: 1,
        cache: false
        });

$(document).find("#StepName").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/WorkflowManager/StepAutoComplete/',
                data: "{ 'prefix': '" + request.term + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: item.Name,
                            value: item.Name,
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
            $("#StepID").val(i.item.identity);
        },
        minLength: 1,
        cache: false
    });

});